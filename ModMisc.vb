Imports System.Configuration
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Module ModMisc

    Private mysqlConn As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private results As String

    '******************************************************************************************************
    '* Funcions to handle my,settings value
    '******************************************************************************************************
    Public Sub ChangeMyFirstRun(ByVal newfirstrun As Boolean)
        My.Settings.firstrun = newfirstrun
        My.Settings.Save()

    End Sub

    Public Sub ChangeSQLDfltYN(ByVal dfltsql As Boolean)
        My.Settings.MySqlDefault = dfltsql
        My.Settings.Save()

    End Sub

    Public Class UsersName
        Private m_userid As String

        Public Sub New(ByVal userID As String)
            m_userid = userID
        End Sub

        Public Overrides Function ToString() As String
            Return m_userid
        End Function
    End Class

    '******************************************************************************************************
    Public Function FillUsers() As Boolean

        Try

            FillUsers = False
            Login.cmbUsers.Items.Clear()

            Using mysqlConn

                Dim command As New SqlCommand("SELECT UserID FROM Users where active = 1 order by UserID desc", mysqlConn)
                mysqlConn.Open()

                myReader = command.ExecuteReader()
                Do While myReader.Read()
                    Login.cmbUsers.Items.Add(New UsersName(myReader.GetString(0)))
                Loop
                'add default user
                Login.cmbUsers.Items.Add(GlobalVariables.GL_DfltConnValues.AppMyDFUser.ToString())

                FillUsers = True
                Exit Function
            End Using

        Catch ex As Exception
            MsgBox(Err.Description)
            FillUsers = False
        Finally
            If Not (myReader Is Nothing) Then
                myReader.Close()
            End If
            If Not (mysqlConn Is Nothing) Then
                mysqlConn.Close()
            End If
        End Try

    End Function

    'use to read data only
    'inopt = CUP check user password.
    'actn = account name for graph
    'acttot = $total by account report detail tab by account
    'mxid = max entryid by date of last transaction
    'CatN = category name
    'chseq = sequence of cheques
    Public Function ReadSQL(ByVal inopt As String, Optional ByVal criteria As String = "") As Object

        Dim tsql As String
        Dim acctfulname As String
        Dim actotamt As Double
        Dim retint As Integer
        Dim catname As String

        tsql = ""
        acctfulname = ""
        actotamt = 0
        retint = 0
        GlobalVariables.GL_Stat = False
        ReadSQL = False

        Try
            If (inopt = "CUP") Then
                tsql = "SELECT usrpassword,usrmode From Users where Userid = '" & GlobalVariables.Gl_LogUserID & "' and active = 1 "
            Else
                tsql = GlobalVariables.Gl_SQLStr
            End If

            myCmd = mysqlConn.CreateCommand
            myCmd.CommandText = tsql

            mysqlConn.Open()

            myReader = myCmd.ExecuteReader()
            Do While myReader.Read()
                'Check user password option
                If (inopt = "CUP") Then
                    If (myReader.GetString(0).ToString = criteria) Then
                        ReadSQL = True
                        GlobalVariables.Gl_UserIDLevel = myReader.GetString(1).ToString 'U=User or A=admin
                    End If
                ElseIf (inopt = "actn") Then
                    'UserID,ActShortName,bankacctNo,AcctType
                    acctfulname = myReader.GetString(0).ToString & " - " & myReader.GetString(1).ToString & " - " & myReader.GetString(2).ToString
                    GlobalVariables.GL_Stat = True
                    ReadSQL = acctfulname
                ElseIf (inopt = "acttot") Then
                    actotamt = myReader.GetValue(0)
                    GlobalVariables.GL_Stat = True
                    ReadSQL = actotamt
                ElseIf (inopt = "mxid") Then
                    retint = myReader.GetValue(0)
                    GlobalVariables.GL_Stat = True
                    ReadSQL = retint
                ElseIf (inopt = "CatN") Then
                    catname = myReader.GetValue(0)
                    GlobalVariables.GL_Stat = True
                    ReadSQL = catname
                ElseIf (inopt = "chseq") Then
                    catname = Trim(myReader.GetString(1).ToString) & myReader.GetValue(2)
                    GlobalVariables.GL_Stat = True
                    ReadSQL = catname
                End If
            Loop

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            myReader.Close()
            mysqlConn.Close()
        End Try

    End Function

    Public Function ReadExcel(inFile As String, ByVal inaccount As String, ByVal inuser As String, ByVal delTrans As Boolean) As Boolean

        'Excel cells data
        'Number	TransDate	Payee	Account	amount	TransType	amtdeposit	amtwithdraw	category	subcat	subcat2	Status	Memo

        Dim XcelApp As New Excel.Application

        Dim J As Integer
        Dim chk As String
        Dim LArray() As String
        Dim Ldate() As String
        Dim cnvdate As String
        Dim taccount As String
        Dim chkdate As String
        Dim totrec As Integer
        Dim totamount As Double
        Dim tsql As String
        Dim tmode As String
        Dim getidbydate As Integer ' must get by date and reset on new date
        Dim rmvfield As String
        Dim tmpmemo As String

        ReadExcel = False
        GlobalVariables.GL_SLmsg = ""

        'inaccount ex: CIBC - 05-37535
        'tacount = 05-37535
        '
        LArray = Split(inaccount, " - ", 2)
        taccount = Trim(LArray(1))
        chkdate = ""

        XcelApp.ScreenUpdating = False
        XcelApp.Workbooks.Open(inFile)

        Using connection As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)
            connection.Open()

            Dim command As SqlCommand = connection.CreateCommand()
            Dim transaction As SqlTransaction

            transaction = connection.BeginTransaction("myaccrun")
            command.Connection = connection
            command.Transaction = transaction

            Try

                If (delTrans = False) Then
                    GlobalVariables.GL_SLmsg = "Records deleted from mytransactions for account: " & inaccount
                    GlobalVariables.Gl_SQLStr = "delete from mytransaction where mytransacct = '" & taccount & "' and mytransowner = '" & inuser & "'"
                    command.CommandText = GlobalVariables.Gl_SQLStr
                    command.ExecuteNonQuery()
                    getidbydate = 1
                End If

                If (XcelApp.Cells(1, 1).Text = "Number") Then

                    With XcelApp
                        chk = XcelApp.Cells(1, 1).Text
                        J = 2
                        Do While (chk <> "XXXX")
                            If (XcelApp.Cells(J, 1).Text <> "XXXX") Then
                                Ldate = Split(XcelApp.Cells(J, 2).Text, "/", 3)
                                cnvdate = Ldate(2) & "-" & Ldate(0) & "-" & Ldate(1)

                                'get id by date 1,2,3 etc
                                If (delTrans = True And J = 2) Then
                                    GlobalVariables.Gl_SQLStr = "Select COALESCE(max([mytransentid]), 0) as entid From [myaccounts].[dbo].[mytransaction] "
                                    GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "Where mytransacct = '" & taccount & "' and mytransdate = '" & cnvdate & "' and mytransowner = '" & inuser & "'"
                                    getidbydate = ReadSQL("mxid")
                                    getidbydate = getidbydate + 1
                                End If

                                If (chkdate = "") Then
                                    chkdate = XcelApp.Cells(J, 2).Text
                                Else
                                    If (CompDates(chkdate, XcelApp.Cells(J, 2).Text) = False) Then
                                        getidbydate = 1
                                        chkdate = XcelApp.Cells(J, 2).Text
                                    Else
                                        getidbydate = getidbydate + 1
                                    End If
                                End If

                                tsql = "Insert into mytransaction (mytransacct,mytransentid,mytranstype,mytransmode,"
                                tsql = tsql & "mytransFrom,mytranspayto,mytranspaytofor,mytranscat,mytranssubcat,mytranssubcat2,"
                                tsql = tsql & "mytransaentnum,mytransdate,mytransstat,mytransamount,mytransowner,"
                                tsql = tsql & "mytransinformation,mytransrecurr,mybalance) values ('"
                                tsql = tsql & taccount & "'," & getidbydate & ",'" & XcelApp.Cells(J, 6).Text & "','"
                                If (XcelApp.Cells(J, 6).Text = "DD") Then
                                    tmode = "D"
                                    rmvfield = Replace(XcelApp.Cells(J, 3).Text, "'", "")
                                    tsql = tsql & tmode & "','" & rmvfield & "','',''," & XcelApp.Cells(J, 9).Text & "," & XcelApp.Cells(J, 10).Text & "," & XcelApp.Cells(J, 11).Text & ",'"
                                Else
                                    tmode = "W"
                                    rmvfield = Replace(XcelApp.Cells(J, 3).Text, "'", "")
                                    tsql = tsql & tmode & "','','" & rmvfield & "',''," & XcelApp.Cells(J, 9).Text & "," & XcelApp.Cells(J, 10).Text & "," & XcelApp.Cells(J, 11).Text & ",'"
                                End If
                                tsql = tsql & XcelApp.Cells(J, 1).Text & "','" & cnvdate & "','" & XcelApp.Cells(J, 12).Text & "',"
                                '
                                If (XcelApp.Cells(J, 6).Text.ToString = "DD") Then
                                    'totdd = totdd + XcelApp.Cells(J, 7).Text
                                    tsql = tsql & CDbl(XcelApp.Cells(J, 7).value) & ",'" & inuser & "',"
                                    totamount = totamount + CDbl(XcelApp.Cells(J, 7).value)
                                Else
                                    'totww = totww + (XcelApp.Cells(J, 8).Text * -1)
                                    tsql = tsql & CDbl(XcelApp.Cells(J, 8).Value) & ",'" & inuser & "',"
                                    totamount = totamount + CDbl(XcelApp.Cells(J, 8).Value)
                                End If
                                tmpmemo = Replace(XcelApp.Cells(J, 13).Text, "'", "")
                                tmpmemo = Replace(tmpmemo, "#", "")
                                tsql = tsql & "'" & tmpmemo & "',0," & totamount & ")"

                                command.CommandText = tsql
                                command.ExecuteNonQuery()

                                totrec = totrec + 1
                            End If
                            J = J + 1
                            chk = XcelApp.Cells(J, 1).Text
                        Loop
                    End With
                    transaction.Commit()
                End If
                GoTo Exit_Excel

            Catch ex As Exception
                Console.WriteLine("Commit Exception Type: {0}", ex.GetType())
                Console.WriteLine("  Message: {0}", ex.Message)

                ' Attempt to roll back the transaction. 
                Try
                    transaction.Rollback()
                    GoTo Exit_Excel
                Catch ex2 As Exception
                    ' This catch block will handle any errors that may have occurred 
                    ' on the server that would cause the rollback to fail, such as 
                    ' a closed connection.
                    Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType())
                    Console.WriteLine("  Message: {0}", ex2.Message)
                End Try
            End Try
        End Using
Exit_Excel:
        XcelApp.Quit()
        ReadExcel = True

    End Function

    Private Function CompDates(ByVal indate1 As String, ByVal indate2 As String) As Boolean

        Dim dt1 As Date
        Dim dt2 As Date

        CompDates = False

        dt1 = Convert.ToDateTime(indate1)
        dt2 = Convert.ToDateTime(indate2)
        If (dt1 = dt2) Then
            CompDates = True
        End If

    End Function

    Public Function ExecuteSqlTransaction(ByVal connectionString As String) As Boolean

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim command As SqlCommand = connection.CreateCommand()
            Dim transaction As SqlTransaction

            transaction = connection.BeginTransaction("myaccrun")
            command.Connection = connection
            command.Transaction = transaction

            Try
                command.CommandText = GlobalVariables.Gl_SQLStr
                command.ExecuteNonQuery()

                transaction.Commit()
                ExecuteSqlTransaction = True

            Catch ex As Exception
                Console.WriteLine("Commit Exception Type: {0}", ex.GetType())
                Console.WriteLine("  Message: {0}", ex.Message)
                ExecuteSqlTransaction = False
                Try
                    transaction.Rollback()
                Catch ex2 As Exception
                    ExecuteSqlTransaction = False
                    Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType())
                    Console.WriteLine("  Message: {0}", ex2.Message)
                End Try
            End Try
        End Using

    End Function

    Public Function Check_user_authority(ByVal inScr As String) As Boolean

        'modify later to use screen option
        'Imp = Import excel must be admin
        'Set = setting

        Check_user_authority = If(GlobalVariables.Gl_UserIDLevel() = "A", True, False)

    End Function

    '******************************************************************************************************************
    ' Procedure: InsertTransData - It will Insert, update Transaction ecord and adjust balance value.
    '******************************************************************************************************************
    Public Sub RunProcedure(ByVal mytransRec As mytransRecord)

        Dim sqlCon = New SqlConnection(GlobalVariables.Gl_ConnectionSTR)

        Using (sqlCon)

            Dim sqlComm As New SqlCommand()

            sqlComm.Connection = sqlCon
            sqlComm.CommandText = "InsertTransData"
            sqlComm.CommandType = CommandType.StoredProcedure

            sqlComm.Parameters.AddWithValue("@ptransacct", mytransRec.Transptransacct)
            sqlComm.Parameters.AddWithValue("@ptransentid", mytransRec.Transptransentid)
            sqlComm.Parameters.AddWithValue("@ptranstype", mytransRec.Transptranstype)
            sqlComm.Parameters.AddWithValue("@ptransmode", mytransRec.Transptransmode)
            sqlComm.Parameters.AddWithValue("@ptransFrom", mytransRec.TransptransFrom)
            sqlComm.Parameters.AddWithValue("@ptranspayto", mytransRec.Transptranspayto)
            sqlComm.Parameters.AddWithValue("@ptranspaytofor", mytransRec.Transptranspaytofor)
            sqlComm.Parameters.AddWithValue("@ptranscat", mytransRec.Transptranscat)
            sqlComm.Parameters.AddWithValue("@ptranssubcat", mytransRec.Transptranssubcat)
            sqlComm.Parameters.AddWithValue("@ptranssubcat2", mytransRec.Transptranssubcat2)
            sqlComm.Parameters.AddWithValue("@ptransaentnum", mytransRec.Transptransaentnum)
            sqlComm.Parameters.AddWithValue("@ptransdate", mytransRec.Transptransdate)
            sqlComm.Parameters.AddWithValue("@ptransstat", mytransRec.Transptransstat)
            sqlComm.Parameters.AddWithValue("@ptransamount", mytransRec.Transptransamount)
            sqlComm.Parameters.AddWithValue("@ptransowner", mytransRec.Transptransowner)
            sqlComm.Parameters.AddWithValue("@ptransinformation", mytransRec.Transptransinformation)
            sqlComm.Parameters.AddWithValue("@ptransrecurr", mytransRec.Transptransrecurr)
            sqlComm.Parameters.AddWithValue("@Pbalance", mytransRec.TransPbalance)
            sqlComm.Parameters.AddWithValue("@Popert", mytransRec.TransPopert)
            sqlComm.Parameters.AddWithValue("@Pmyid", mytransRec.TransPmyid)

            sqlCon.Open()
            sqlComm.ExecuteNonQuery()

        End Using

    End Sub

End Module
