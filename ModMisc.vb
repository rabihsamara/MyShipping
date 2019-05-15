Imports System.Configuration
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

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
    '* 1) Fill combbox using query 
    '* L=login             - 
    '* C=Control screen    - 
    '* P=company
    '* CST=Customers screen seltype in selection of existing customers- 
    '* CRI CRIA or CRICS CRIPR CRIAL or CRIACS CRIAPR CRIAAL = Customers screen - customer ID Combo
    '* CRN CRNA or CRNCS CRNPR CRNAL or CRNACS CRNAPR CRNAAL = Customers screen - customer Name Combo
    '* CSINA = Customer id/name active only
    '* CANOA = Customer accounts per customer.
    '******************************************************************************************************
    Public Function FillCBox(incombo As ComboBox, ByVal callby As String) As Boolean

        Try
            Dim tsql As String = ""
            FillCBox = False

            If (callby = "L" Or callby = "C") Then
                tsql = "SELECT UserID FROM Users where active = 1 order by UserID asc"
            ElseIf (callby = "P") Then
                tsql = "SELECT CompName FROM company where CompActive = 1 order by CompName asc"
            ElseIf (callby = "CST") Then
                tsql = "Select concat(custtype,' - ',typename) as ctype from custtype where typeactive = 1 order by ID"
            ElseIf (callby.substring(0, 3) = "CRI") Then
                tsql = "SELECT CustID FROM Customers"
                If (callby = "CRIA" Or callby = "CRIACS" Or callby = "CRIAPR" Or callby = "CRIAAL") Then tsql = tsql & " where chCIactive = 1"
                If (callby = "CRIACS" Or callby = "CRIAPR") Then
                    tsql = tsql & " and cmbCustType = '" & callby.Substring(4, 2) & "'"
                End If
                tsql = tsql & " order by CustID asc"
            ElseIf (callby.substring(0, 3) = "CRN") Then
                tsql = "Select CIName  FROM Customers"
                If (callby = "CRNA" Or callby = "CRNACS" Or callby = "CRNAPR" Or callby = "CRNAAL") Then tsql = tsql & " where chCIactive = 1"
                If (callby = "CRNACS" Or callby = "CRNAPR") Then
                    tsql = tsql & " and cmbCustType = '" & callby.Substring(4, 2) & "'"
                End If
                tsql = tsql & " order by CIName asc"
            ElseIf (callby = "CSINA") Then
                tsql = "select Concat(custid,' - ',CIname) from Customers where chCIactive = 1 order by CIName asc"
            ElseIf (callby = "CANOA") Then
                tsql = "select concat(AccountNo,' - ',AccountName) from accounts order by AccountName"
            End If

            Using mysqlConn As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)

                Dim command As New SqlCommand(tsql, mysqlConn)
                mysqlConn.Open()

                myReader = command.ExecuteReader()
                Do While myReader.Read()
                    If (callby = "L" Or callby = "C") Then
                        incombo.Items.Add(New UsersName(myReader.GetString(0)))
                        FillCBox = True
                    ElseIf (callby = "P") Then
                        incombo.Items.Add(New CompanyName(myReader.GetString(0)))
                        FillCBox = True
                    Else
                        incombo.Items.Add(Trim(myReader.GetString(0)))
                        FillCBox = True
                    End If
                Loop
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

    '******************************************************************************************************
    '* 1) Fill combbox using object to get value dor displayed value
    '* ORST = Order status drom order entry screen'
    '* ORSC = order screen shipping country
    '* ORSP = order screen shipping Province
    '* ORSY = order screen shipping City
    '* ORBC = order screen Billing country
    '* ORSHT = order screen shipto id's by customer
    '* ORSTY = order screen shipping type
    '* ORSM = order screen shipping method
    '* ORCI = order screen customer id
    '* CANOA = Customer accounts per customer.
    '* ORHO = Order screen search orders.
    '******************************************************************************************************
    '*
    Public Function FillCBoxBytable(incombo As ComboBox, ByVal callby As String, Optional ByVal invalue As Integer = 0, Optional ByVal invalue2 As Integer = 0, Optional ByVal invalue3 As String = "") As Boolean

        Dim tsql As String = ""
        Dim vlname As String = ""
        Dim dspname As String

        FillCBoxBytable = False

        If (callby = "ORST") Then
            tsql = "SELECT  ordstatshort,ordstatfull FROM ordstatus order by ordstatfull"
            vlname = "ordstatshort"
            dspname = "ordstatfull"
        ElseIf (callby = "ORSC") Then
            tsql = "SELECT  ID,countryname FROM countries where active = 1 order by countryname"
            vlname = "ID"
            dspname = "countryname"
        ElseIf (callby = "ORSP") Then
            tsql = "SELECT  ID,Concat(provshort,' - ',provname) as Provname FROM provinces where active = 1 and countryid = " & invalue & " order by provname"
            vlname = "ID"
            dspname = "Provname"
        ElseIf (callby = "ORSY") Then
            tsql = "SELECT  ID, cityname FROM cities where cityactive = 1 and countryid = " & invalue & " and provid = " & invalue2 & "  order by cityname"
            vlname = "ID"
            dspname = "cityname"
        ElseIf (callby = "ORSHT") Then
            tsql = "select ShiptoID, Concat(shiptoID,' - ',shipname) as shpname from shipto where custid = '" & invalue3 & "'"
            vlname = "ShiptoID"
            dspname = "shpname"
        ElseIf (callby = "CSHT") Then
            tsql = "select ShiptoID from shipto where custid = '" & invalue3 & "'"
            vlname = "ShiptoID"
            dspname = "ShiptoID"
        ElseIf (callby = "ORSTY") Then
            tsql = "SELECT Concat(shptype,' - ',shptime) as shtype, ID FROM ordtypes order by shpdspord asc"
            vlname = "ID"
            dspname = "shtype"
        ElseIf (callby = "ORSM") Then
            tsql = "select Concat(shpmshort,' - ',shpmfull) as shpmfull,ID from shpmethods"
            vlname = "ID"
            dspname = "shpmfull"
        ElseIf (callby = "CANOA") Then
            tsql = "select concat(AccountNo,' - ',AccountName) as accountname,AccountNo from accounts where CustNO ='" & invalue3 & "' order by AccountName"
            vlname = "AccountNo"
            dspname = "accountname"
        ElseIf (callby = "ORCI") Then
            tsql = "select CustID, concat(CustID, ' - ',CIName) as CIName from customers where chCIactive = 1 order by CIName"
            vlname = "CustID"
            dspname = "CIName"
        ElseIf (callby = "ORHO") Then
            tsql = "SELECT Concat(CustNo,' - ',AccountNo,' - ',OrderNO) as OrderNO, Concat(CustNo,',',AccountNo,',',OrderNO) as  OrderNOID FROM Orders order by CustNo asc,AccountNo asc"
            vlname = "OrderNOID"
            dspname = "OrderNO"
        Else
            Exit Function
        End If

        Using mysqlConn As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)
            Try
                mysqlConn.Open()
                Dim Command = New SqlCommand(tsql, mysqlConn)
                Dim rs As SqlDataReader = Command.ExecuteReader
                Dim dt As DataTable = New DataTable
                dt.Load(rs)
                incombo.DataSource = dt
                incombo.DisplayMember = dspname
                incombo.ValueMember = vlname
                FillCBoxBytable = True
            Catch ex As Exception
                MsgBox(Err.Description)
            Finally
                If Not (mysqlConn Is Nothing) Then
                    mysqlConn.Close()
                End If
            End Try

        End Using

    End Function

    '**********************************************************************************************
    'Use to read data only
    'inopt = CUP check user password.
    'fldchk = company record exists but address1 empty
    'userr = read user record from table users.
    'usridcnt = count of userid >0 exists
    'MSEC = read security levels for menu show and active. 1 1
    'ALLM = all menus in an array
    'NCST= read count of cust for new custom if exists
    'SHPC= count of shipto id by customer
    'CACCT = account per customer
    'MXONO = maximum order number by custono and accountNo
    '**********************************************************************************************
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
                    tsql = "SELECT usrmode From Users where Userid = '" & GlobalVariables.Gl_LogUserID & "' and active = 1 and  Encryptedpassword = HashBytes('SHA2_512','" & criteria & "')"
                Else
                    tsql = GlobalVariables.Gl_SQLStr
                End If

                myCmd = mysqlConn.CreateCommand
                myCmd.CommandText = tsql

                mysqlConn.Open()

                myReader = myCmd.ExecuteReader()
                Do While myReader.Read()
                    If (inopt = "CUP") Then 'Check user password option
                        If (myReader.GetString(0).ToString <> "") Then
                            ReadSQL = True
                            GlobalVariables.Gl_UserIDLevel = myReader.GetString(0).ToString 'U=User or A=admin
                        Else
                            ReadSQL = False
                        End If
                    ElseIf (inopt = "fldchk") Then
                        fldtext = myReader.GetString(0).ToString
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
                    ElseIf (inopt = "usridcnt" Or inopt = "NCST" Or inopt = "SHPC" Or inopt = "MXONO") Then
                        ReadSQL = myReader.GetValue(0)
                        GlobalVariables.GL_Stat = True
                    ElseIf (inopt = "ALLM") Then
                        ReDim Preserve ModRegSec.tMyMenus(F)
                        ModRegSec.tMyMenus(F) = myReader.GetValue(0) & ":" & myReader.GetValue(1) & ":" & myReader.GetValue(2).ToString & ":" & myReader.GetValue(3).ToString
                        F = F + 1
                        ReadSQL = True
                        GlobalVariables.GL_Stat = True
                    ElseIf (inopt = "CACCT") Then
                        'ID,custno,AccountNo,AccountName, active, CONVERT(date,datecreated) as datecreated,CONVERT(date,dateupdated) as dateupdated,CreatedBy
                        GlobalVariables.TmpCusAcct.MyID = myReader.GetValue(0)
                        GlobalVariables.TmpCusAcct.MyCustNo = myReader.GetString(1)
                        GlobalVariables.TmpCusAcct.MyAccountNo = myReader.GetString(2)
                        GlobalVariables.TmpCusAcct.MyAccountName = myReader.GetString(3)
                        GlobalVariables.TmpCusAcct.Myactive = myReader.GetValue(4)
                        GlobalVariables.TmpCusAcct.Mydatecreated = myReader.GetDateTime(5)
                        GlobalVariables.TmpCusAcct.Mydateupdated = myReader.GetDateTime(6)
                        GlobalVariables.TmpCusAcct.MyCreatedBy = myReader.GetString(7)
                        ReadSQL = True
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
                    GlobalVariables.GL_Stat = True
                End Using 'comm

            Catch ex As Exception
                MsgBox("Error Reading countries!")
            Finally
                If Not (mysqlConn Is Nothing) Then
                    mysqlConn.Close()
                End If
            End Try

        End Using

    End Sub

    'Get id from shname
    Public Function GetLastShipto(ByVal inCustID As String, ByVal inshname As String) As String

        Dim L As Integer = inshname.Length
        Dim strArr() As String
        Dim tchr As String = ""
        Dim tmpt As String = ""
        Dim count As Integer
        Dim cnt As Integer = 0

        If (inshname <> "" And L > 3 And InStr(inshname, " ") > 0) Then
            strArr = inshname.Split(" ")
            For count = 0 To strArr.Length - 1
                tmpt = Trim(strArr(count))
                tchr = tchr & If(tmpt <> "", tmpt.Substring(0, 1), "")
            Next
        Else
            tchr = inshname.Substring(0, 3)
        End If
        tchr = tchr & "0"

        GlobalVariables.Gl_SQLStr = "select count(*) + 1 as cnt from shipto where custid = '" & inCustID & "'"
        cnt = ReadSQL("SHPC", "")
        tchr = tchr & cnt.ToString
        GetLastShipto = tchr

    End Function

    Public Function GetShiptoRec(ByVal shcustid As String, ByVal inshiptoID As String) As Object

        Dim myCmd As SqlCommand
        Dim myReader As SqlDataReader = Nothing
        Dim custshipto As shipto = New shipto()
        Dim SQLStr = "SELECT ID,custid,ShiptoID,ShipName,Shipadd1,Shipadd2,Shipcity,Shipprov,Shippcode,Shipcountry,ShipDflt,active,datecreated,dateupdated,createdby FROM shipto where custid = '" & shcustid & "' and shiptoID = '" & inshiptoID & "'"

        GlobalVariables.GL_Stat = False
        GetShiptoRec = Nothing

        Using mysqlConn As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)
            Try
                myCmd = mysqlConn.CreateCommand
                myCmd.CommandText = SQLStr
                mysqlConn.Open()

                myReader = myCmd.ExecuteReader()
                Do While myReader.Read()

                    custshipto.MyID = myReader.GetValue(0)
                    custshipto.MyShipCustID = myReader.GetString(1)
                    custshipto.MyShiptoID = myReader.GetString(2)
                    custshipto.MyShipName = myReader.GetString(3)
                    custshipto.MyShipadd1 = myReader.GetString(4)
                    custshipto.MyShipadd2 = myReader.GetString(5)
                    custshipto.MyShipcity = myReader.GetString(6)
                    custshipto.MyShipprov = myReader.GetString(7)
                    custshipto.MyShippcode = myReader.GetString(8)
                    custshipto.MyShipcountry = myReader.GetString(9)
                    custshipto.MyShipDflt = myReader.GetValue(10)
                    custshipto.Myactive = myReader.GetValue(11)
                    custshipto.Mydatecreated = myReader.GetDateTime(12)
                    custshipto.Mydateupdated = myReader.GetDateTime(13)
                    custshipto.MyShcreatedby = myReader.GetString(14)
                    GetShiptoRec = custshipto
                    GlobalVariables.GL_Stat = True
                Loop

            Catch ex As Exception
                MsgBox(ex.ToString)
                GlobalVariables.GL_Stat = False
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

    'inmode = I=Insert, U=update
    Public Function UpdateCSShipTo(ByVal custshipto As shipto, inmode As String) As Object

        UpdateCSShipTo = False

        If (inmode = "I" Or inmode = "IU") Then
            GlobalVariables.Gl_SQLStr = "If not exists(select 1 from shipto where custid = '" & custshipto.MyShipCustID & "' and shiptoID = '" & custshipto.MyShiptoID & "') Begin "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "insert into shipto (custid,ShiptoID,ShipName,Shipadd1,Shipadd2,Shipcity,Shipprov,Shippcode,Shipcountry,ShipDflt,active, datecreated,dateupdated,createdby) values ('"
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & custshipto.MyShipCustID & "','" & custshipto.MyShiptoID & "','" & custshipto.MyShipName & "','" & custshipto.MyShipadd1 & "','"
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & custshipto.MyShipadd2 & "','" & custshipto.MyShipcity & "','" & custshipto.MyShipprov & "','" & custshipto.MyShippcode & "','"
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & custshipto.MyShipcountry & "'," & custshipto.MyShipDflt & "," & custshipto.Myactive & ",'" & custshipto.Mydatecreated & "','" & custshipto.Mydateupdated & "','" & GlobalVariables.Gl_LogUserID & "') End"
            If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                MsgBox("Error creating shipto record!")
                Exit Function
            End If
            'update table customer of new customer shipto id.
            GlobalVariables.Gl_SQLStr = "update customers set cmbShpID = '" & Trim(custshipto.MyShiptoID) & "' where CustID = '" & Trim(custshipto.MyShipCustID) & "'"
            If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                MsgBox("Error updating Customer record with new shipto ID!")
                Exit Function
            End If
        Else
            GlobalVariables.Gl_SQLStr = "If exists(select 1 from shipto where custid = '" & custshipto.MyShipCustID & "' and shiptoID = '" & custshipto.MyShiptoID & "') Begin "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "update shipto set ShipName = '" & custshipto.MyShipName & "',Shipadd1 = '" & custshipto.MyShipadd1 & "',Shipadd2 = '" & custshipto.MyShipadd2
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "',Shipcity = '" & custshipto.MyShipcity & "',Shipprov = '" & custshipto.MyShipprov & "',Shippcode = '" & custshipto.MyShippcode
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "',Shipcountry = '" & custshipto.MyShipcountry & "',ShipDflt = " & custshipto.MyShipDflt & ",active = " & custshipto.Myactive & ", dateupdated = '" & custshipto.Mydateupdated
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "' where custid = '" & custshipto.MyShipCustID & "' and ShiptoID = '" & custshipto.MyShiptoID & "') End"
            If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                MsgBox("Error Updating shipto record!")
                Exit Function
            End If
        End If
        UpdateCSShipTo = True

    End Function

    Public Function LoadDataGrids(ByVal inGrid As DataGridView, ByVal tsql As String, ByVal intable As String) As Integer

        LoadDataGrids = 0
        Using connection As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)
            connection.Open()
            sCommand = New SqlCommand(tsql, connection)
            sAdapter = New SqlDataAdapter(sCommand)
            sBuilder = New SqlCommandBuilder(sAdapter)
            sDs = New DataSet()
            sAdapter.Fill(sDs, intable)
            sTable = sDs.Tables(intable)
            LoadDataGrids = sTable.Rows.Count
            With inGrid
                .DataSource = sDs.Tables(intable)
                .ReadOnly = True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                .AutoResizeColumns()
            End With
            connection.Close()
        End Using

    End Function

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
