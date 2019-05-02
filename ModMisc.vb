Imports System.Configuration
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Module ModMisc

    Private mysqlConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private results As String

    Private sCommand As SqlCommand
    Private sAdapter As SqlDataAdapter
    Private sBuilder As SqlCommandBuilder
    Private sDs As DataSet
    Private sTable As DataTable

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

    Public Class CompanyName
        Private m_CompName As String

        Public Sub New(ByVal inCompName As String)
            m_CompName = inCompName
        End Sub

        Public Overrides Function ToString() As String
            Return m_CompName
        End Function
    End Class

    '******************************************************************************************************
    'L=login, C=Control screen, P=company
    '******************************************************************************************************
    Public Function FillCBox(incombo As ComboBox, ByVal callby As String) As Boolean

        Try
            Dim tsql As String = ""
            FillCBox = False

            If (callby = "L" Or callby = "C") Then
                tsql = "SELECT UserID FROM Users where active = 1 order by UserID asc"
            ElseIf (callby = "P") Then
                tsql = "SELECT CompName FROM company where CompActive = 1 order by CompName asc"
            End If

            Using mysqlConn As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)

                Dim command As New SqlCommand(tsql, mysqlConn)
                mysqlConn.Open()

                myReader = command.ExecuteReader()
                Do While myReader.Read()
                    If (callby = "L" Or callby = "C") Then
                        incombo.Items.Add(New UsersName(myReader.GetString(0)))
                    ElseIf (callby = "P") Then
                        incombo.Items.Add(New CompanyName(myReader.GetString(0)))
                    End If
                Loop
                FillCBox = True
                Exit Function
            End Using

        Catch ex As Exception
            MsgBox(Err.Description)
            FillCBox = False
        Finally
            If Not (myReader Is Nothing) Then
                myReader.Close()
            End If
            If Not (mysqlConn Is Nothing) Then
                mysqlConn.Close()
            End If
        End Try

    End Function

    'Use to read data only
    'inopt = CUP check user password.
    'fldchk = company record exists but address1 empty
    'userr = read user record from table users.
    'usridcnt = count of userid >0 exists
    'MSEC = read security levels for menu show and active. 1 1
    'ALLM = all menus in an array
    Public Function ReadSQL(ByVal inopt As String, Optional ByVal criteria As String = "") As Object

        Dim tsql As String = String.Empty
        Dim fldtext As String = String.Empty
        Dim retint As Integer = 0
        Dim F As Integer = 0

        GlobalVariables.GL_Stat = False
        ReadSQL = Nothing

        Using mysqlConn As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)
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
                    If (inopt = "CUP") Then 'Check user password option
                        If (myReader.GetString(0).ToString = criteria) Then
                            ReadSQL = True
                            GlobalVariables.Gl_UserIDLevel = myReader.GetString(1).ToString 'U=User or A=admin
                        End If
                    ElseIf (inopt = "fldchk") Then
                        fldtext = myReader.GetString(0)
                        GlobalVariables.GL_Stat = True
                        ReadSQL = fldtext
                    ElseIf (inopt = "userr") Then
                        'UserID,Fname,Lname,DateOfBirth,Address1,Address2,City,Province,Pcode,Country,Active,usrPassword,usrmode,usrseclvl FROM users
                        GlobalVariables.Tmpuserrecord.MyUserID = myReader.GetString(0)
                        GlobalVariables.Tmpuserrecord.MyFname = myReader.GetString(1)
                        GlobalVariables.Tmpuserrecord.MyLname = myReader.GetString(2)
                        GlobalVariables.Tmpuserrecord.MyDateOfBirth = myReader.GetDateTime(3)
                        GlobalVariables.Tmpuserrecord.MyAddress1 = myReader.GetString(4)
                        GlobalVariables.Tmpuserrecord.MyAddress2 = myReader.GetString(5)
                        GlobalVariables.Tmpuserrecord.MyCity = myReader.GetString(6)
                        GlobalVariables.Tmpuserrecord.MyProvince = myReader.GetString(7)
                        GlobalVariables.Tmpuserrecord.MyPcode = myReader.GetString(8)
                        GlobalVariables.Tmpuserrecord.MyCountry = myReader.GetString(9)
                        GlobalVariables.Tmpuserrecord.MyActive = myReader.GetValue(10)
                        GlobalVariables.Tmpuserrecord.MyusrPassword = myReader.GetString(11)
                        GlobalVariables.Tmpuserrecord.Myusrmode = myReader.GetString(12)
                        GlobalVariables.Tmpuserrecord.Myusrseclvl = myReader.GetValue(13)

                        ReadSQL = GlobalVariables.Tmpuserrecord
                        GlobalVariables.GL_Stat = True
                    ElseIf (inopt = "usridcnt") Then
                        ReadSQL = myReader.GetValue(0)
                        GlobalVariables.GL_Stat = True
                        'ElseIf (inopt = "MSEC") Then
                        '    GlobalVariables.GL_mshow = myReader.GetValue(0)
                        '    GlobalVariables.GL_mactive = myReader.GetValue(1)
                        '    ReadSQL = True
                    ElseIf (inopt = "ALLM") Then
                        GlobalVariables.tMyMenus(F) = myReader.GetValue(0) & ":" & myReader.GetValue(1) & ":" & myReader.GetValue(2).ToString & ":" & myReader.GetValue(3).ToString
                        F = F + 1
                        ReadSQL = True
                        GlobalVariables.GL_Stat = True
                    End If
                Loop

            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                If Not (myReader Is Nothing) Then
                    myReader.Close()
                End If
                If Not (mysqlConn Is Nothing) Then
                    mysqlConn.Close()
                End If
            End Try
        End Using

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
    ' Procedure: InsertTransData - It will Insert, update Transaction record and adjust balance value.
    '******************************************************************************************************************
    Public Sub RunProcedure(ByVal mytransRec As mytransRecord)

        Using mysqlConn As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)

            Dim sqlCmd As New SqlCommand()

            sqlCmd.Connection = mysqlConn
            sqlCmd.CommandText = "InsertTransData"
            sqlCmd.CommandType = CommandType.StoredProcedure

            sqlCmd.Parameters.AddWithValue("@ptransacct", mytransRec.Transptransacct)
            sqlCmd.Parameters.AddWithValue("@ptransentid", mytransRec.Transptransentid)
            sqlCmd.Parameters.AddWithValue("@ptranstype", mytransRec.Transptranstype)
            sqlCmd.Parameters.AddWithValue("@ptransmode", mytransRec.Transptransmode)
            sqlCmd.Parameters.AddWithValue("@ptransFrom", mytransRec.TransptransFrom)
            sqlCmd.Parameters.AddWithValue("@ptranspayto", mytransRec.Transptranspayto)
            sqlCmd.Parameters.AddWithValue("@ptranspaytofor", mytransRec.Transptranspaytofor)
            sqlCmd.Parameters.AddWithValue("@ptranscat", mytransRec.Transptranscat)
            sqlCmd.Parameters.AddWithValue("@ptranssubcat", mytransRec.Transptranssubcat)
            sqlCmd.Parameters.AddWithValue("@ptranssubcat2", mytransRec.Transptranssubcat2)
            sqlCmd.Parameters.AddWithValue("@ptransaentnum", mytransRec.Transptransaentnum)
            sqlCmd.Parameters.AddWithValue("@ptransdate", mytransRec.Transptransdate)
            sqlCmd.Parameters.AddWithValue("@ptransstat", mytransRec.Transptransstat)
            sqlCmd.Parameters.AddWithValue("@ptransamount", mytransRec.Transptransamount)
            sqlCmd.Parameters.AddWithValue("@ptransowner", mytransRec.Transptransowner)
            sqlCmd.Parameters.AddWithValue("@ptransinformation", mytransRec.Transptransinformation)
            sqlCmd.Parameters.AddWithValue("@ptransrecurr", mytransRec.Transptransrecurr)
            sqlCmd.Parameters.AddWithValue("@Pbalance", mytransRec.TransPbalance)
            sqlCmd.Parameters.AddWithValue("@Popert", mytransRec.TransPopert)
            sqlCmd.Parameters.AddWithValue("@Pmyid", mytransRec.TransPmyid)

            mysqlConn.Open()
            sqlCmd.ExecuteNonQuery()

        End Using

    End Sub

    Public Sub ReadCountries(ByVal cbo As ComboBox)

        GlobalVariables.GL_Stat = False
        Using mysqlConn As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)

            Try
                mysqlConn.Open()
                Using comm As SqlCommand = New SqlCommand(GlobalVariables.Gl_SQLStr, mysqlConn)
                    Dim rs As SqlDataReader = comm.ExecuteReader
                    Dim dt As DataTable = New DataTable
                    dt.Load(rs)
                    cbo.DataSource = dt
                    cbo.DisplayMember = "countryname"
                    cbo.ValueMember = "ID"
                    mysqlConn.Close()
                    GlobalVariables.GL_Stat = True
                End Using 'comm

            Catch ex As Exception
                MsgBox("Error Reading countries!")
            End Try

        End Using

    End Sub

    '***********************************************************************************************
    '* Misc functions/subs                                                                         *
    '***********************************************************************************************
    Public Sub Closeforms(ByVal infrm As String)

        Dim formNames As New List(Of String)

        If (infrm = "E") Then
            Dim openForms As Windows.Forms.FormCollection = Application.OpenForms
            For Each currentForm As Form In openForms
                If currentForm.Name <> "MainMenu" Then
                    formNames.Add(currentForm.Name)
                End If
            Next
        Else
            formNames.Add(infrm)
        End If

        For Each currentFormName As String In formNames
            Application.OpenForms(currentFormName).Close()
        Next

    End Sub

End Module
