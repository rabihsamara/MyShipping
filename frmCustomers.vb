Imports System.Data.SqlClient

Public Class frmCustomers

    Private mysqlConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Private results As String
    Private selcustid As String = String.Empty
    Private selcustname As String = String.Empty
    Private seluw As String = "I"
    Private seluw2 As String = ""
    Private tmsg As String = String.Empty
    Private tstat As Boolean = True

    Private slCICountry As Integer
    Private slBLCountry As Integer
    Private slSHCountry As Integer

    Private slCIProv As Integer
    Private slBLProv As Integer
    Private slSHProv As Integer

    Private slCICity As Integer
    Private slBLCity As Integer
    Private slSHCity As Integer

    Private Custrecord As Customers = New Customers()
    Private AppCustLocks As AppLocks = New AppLocks()

    Private Sub FrmCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RunClassGen() 'tmp

        txtmsg.Visible = False
        chslactonly.Checked = True
        TabControl1.Visible = False

        tstat = ModMisc.FillCBox(cmbSelType, "CST")
        tstat = ModMisc.FillCBox(cmbCustType, "CST")
        LoadData()

    End Sub

    Private Sub LoadData()

        Dim climode As String = "CRI"
        Dim clnmode As String = "CRN"
        If (chslactonly.Checked = True) Then climode = "CRIA"
        If (chslactonly.Checked = True) Then clnmode = "CRNA"
        '
        If (Trim(cmbSelType.Text) <> "") Then climode = climode & Trim(cmbSelType.Text).Substring(0, 2) 'CRI or CRICS CRIPR CRIAL or CRIACS CRIAPR CRIAAL
        If (Trim(cmbSelType.Text) <> "") Then clnmode = clnmode & Trim(cmbSelType.Text).Substring(0, 2) 'CRN or CRNCS CRNPR CRNAL or CRNACS CRNAPR CRNAAL
        '
        cmbCustID.Items.Clear()
        cmbCustName.Items.Clear()
        tstat = ModMisc.FillCBox(cmbCustID, climode)
        tstat = ModMisc.FillCBox(cmbCustName, clnmode)

    End Sub

    Private Sub InCustName_TextChanged(sender As Object, e As EventArgs) Handles inCustName.TextChanged
        CreateCustID()
    End Sub

    Private Sub CreateCustID()

        Dim L As Integer = inCustName.Text.Length

        If (inCustName.Text <> "" And L < 7) Then
            inCustID.Text = inCustName.Text.Substring(0, L)
        ElseIf (inCustName.Text = "") Then
            inCustID.Text = ""
        End If

    End Sub

    'Process new customer
    Private Sub CmdProcess_Click(sender As Object, e As EventArgs) Handles cmdProcess.Click

        tmsg = EditEntry("N")
        If (tmsg = "X" Or tmsg <> "Customer Created Successfully!") Then Exit Sub ' user cancelled creating 

        TabControl1.Visible = True

    End Sub

    'Exit customer screen
    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    'Load existing customer
    Private Sub cmdLoadCust_Click(sender As Object, e As EventArgs) Handles cmdLoadCust.Click
        tmsg = EditEntry("E")
        If (tmsg <> "") Then Exit Sub

        TabControl1.Visible = True



    End Sub

    Private Function EditEntry(ByVal inedit As String) As String

        Dim terr As String = String.Empty

        txtmsg.Visible = False
        terr = ""

        If (inedit = "N") Then
            If (inCustID.Text = "") Then
                terr = "Must Enter Customer ID!"
                GoTo EDIT_EXIT
            ElseIf (inCustName.Text = "") Then
                terr = "Must Enter Customer Name!"
                GoTo EDIT_EXIT
            End If
            GlobalVariables.Gl_SQLStr = "select count(*) as cnt from customers where CustID = '" & Trim(inCustID.Text) & "'"
            If (ModMisc.ReadSQL("NCST", "") > 0) Then
                terr = "New Customer ID Exists!"
                GoTo EDIT_EXIT
            Else
                'create new customer message
                seluw = "I"
                seluw2 = "I"
                inCustName.Text = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(inCustName.Text)

                Dim result As DialogResult = MessageBox.Show("Create New Customer?", "Confirm adding new customer", MessageBoxButtons.YesNo)
                If (result = DialogResult.Yes) Then
                    'Ok create new cust. load screen to database
                    GlobalVariables.Gl_SQLStr = "Insert into customers (CustID, CustName, CustType, Custactive) Values ('" & Trim(inCustID.Text) & "','" & inCustName.Text & "','PR',1)"
                    If (ModMisc.ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                        MsgBox("Error Creating new Customer!")
                        GoTo EDIT_EXIT
                    End If
                    terr = "Customer Created Successfully!"
                    seluw = "U"
                    CIName.Text = Trim(inCustName.Text)
                    LoadData()
                    LoadCombCountries("ACT", seluw2)
                    'lock record
                    If (AppLocking.WriteDelLock("W", 0, "Customer", "Customer", selcustid, seluw2) = False) Then 'lock it
                        terr = "Error Creating Lock Record!"
                        GoTo EDIT_EXIT
                    End If
                Else
                    inCustID.Text = ""
                    inCustName.Text = ""
                    terr = "X"
                    GoTo EDIT_EXIT
                End If
            End If
        End If

        If (inedit = "E") Then
            selcustid = Trim(cmbCustID.Text)
            selcustname = Trim(cmbCustName.Text)
            If (selcustid = "" And selcustname = "") Then
                terr = "Must Select Customer ID Or Name!"
                GoTo EDIT_EXIT
            End If

            GlobalVariables.Gl_SQLStr = If(selcustid <> "", "select CustID,CustName,CustType,Custactive From customers where CustID = '" & selcustid & "'", "select CustID,CustName, Custtype, Custactive From customers where Custname = '" & selcustname & "'")
            If (ReadCustomer("C") = False) Then
                terr = "Error reading customer !"
                GoTo EDIT_EXIT
            End If
            seluw = "U"
            seluw2 = "U"

            'check if locked
            GlobalVariables.Gl_SQLStr = "SELECT ID,Userid,Formname,ctrlname,ctrlvalue,ctrlopert,lockeddate FROM AppLocks where FormName = 'Customer' and ctrlname = 'Customer' and ctrlvalue = '" & selcustid & "'"
            AppCustLocks = AppLocking.GetLockRec("APPL")
            If (GlobalVariables.GL_Stat = False) Then
                If (AppLocking.WriteDelLock("W", 0, "Customer", "Customer", selcustid, seluw2) = False) Then 'lock it
                    terr = "Error Creating Lock Record!"
                    GoTo EDIT_EXIT
                End If
            Else
                'check if same user or another
                If (AppCustLocks.MyFormname = "Customer" And AppCustLocks.Myctrlname = "Customer" And AppCustLocks.Myctrlvalue = selcustid) Then
                    terr = "record for cust " & selcustid & " is locked by user " & AppCustLocks.MyUserid
                    GoTo EDIT_EXIT
                End If
            End If

            'load data to screen
            ModUpdates.UpdateFormData("LCS", Me)
            LoadCombCountries("ACT", seluw2)

        End If

EDIT_EXIT:
        If (terr <> "" And terr <> "X") Then
            txtmsg.Text = terr
            txtmsg.Visible = True
            Timer1.Interval = 5000 'ms
            Timer1.Start()
        End If
        EditEntry = terr

    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        txtmsg.Text = ""
        txtmsg.Visible = False
    End Sub

    'Reload existing customer filters custtype.
    Private Sub cmbSelType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSelType.SelectedIndexChanged
        cmbCustID.Text = ""
        cmbCustID.Items.Clear()
        cmbCustName.Text = ""
        cmbCustName.Items.Clear()
        LoadData()
    End Sub

    Public Function ReadCustomer(ByVal inopt As String) As Boolean

        GlobalVariables.GL_Stat = False
        ReadCustomer = False

        Using mysqlConn As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)
            Try

                myCmd = mysqlConn.CreateCommand
                myCmd.CommandText = GlobalVariables.Gl_SQLStr
                mysqlConn.Open()

                myReader = myCmd.ExecuteReader()
                Do While myReader.Read()
                    Custrecord.MyCustID = myReader.GetString(0).ToString
                    Custrecord.MyCustName = myReader.GetString(1).ToString
                    Custrecord.MyCustType = myReader.GetString(2).ToString
                    Custrecord.MyCustActive = myReader.GetValue(3)

                    ReadCustomer = True
                Loop

            Catch ex As Exception
                MsgBox(ex.ToString)
                ReadCustomer = False
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

    Private Sub CmdCanCust_Click(sender As Object, e As EventArgs) Handles cmdCanCust.Click
        'check if new was pressed or update


        'release log 
        If (AppLocking.WriteDelLock("D", 0, "Customer", "Customer", selcustid, seluw2) = False) Then 'lock it
            MsgBox("Error deting Lock record!")
        End If

        inCustID.Text = ""
        inCustName.Text = ""
        cmbCustID.Text = ""
        cmbCustName.Text = ""
        LoadData() ' inacse new 
        TabControl1.Visible = False

    End Sub

    'Billto copy aaddres from customer nfo address
    Private Sub cmdBillCopy_Click(sender As Object, e As EventArgs) Handles cmdBillCopy.Click
        BLName.Text = CIName.Text
        BLadd1.Text = CIadd1.Text
        BLadd2.Text = CIAdd2.Text
        cmbBLcity.Text = cmbCICity.Text
        BLpcode.Text = CIpcode.Text
        cmbBLProv.Text = cmbCIProv.Text
        cmbBLCountry.Text = cmbCICountry.Text
    End Sub

    'shipto save it
    Private Sub CmdSaveShpto_Click(sender As Object, e As EventArgs) Handles cmdSaveShpto.Click

    End Sub

    'shipto section copy from customer info
    Private Sub CmdSaveshipasinfo_Click(sender As Object, e As EventArgs) Handles cmdSaveshipasinfo.Click
        SHName.Text = CIName.Text
        SHadd1.Text = CIadd1.Text
        SHadd2.Text = CIAdd2.Text
        cmbSHCity.Text = cmbCICity.Text
        SHPcode.Text = CIpcode.Text
        cmbSHProv.Text = cmbCIProv.Text
        cmbSHCountry.Text = cmbCICountry.Text
    End Sub

    'shipto section copy from billto
    Private Sub CmdShSaveBill_Click(sender As Object, e As EventArgs) Handles cmdShSaveBill.Click
        SHName.Text = BLName.Text
        SHadd1.Text = BLadd1.Text
        SHadd2.Text = BLadd2.Text
        cmbSHCity.Text = cmbBLcity.Text
        SHPcode.Text = BLpcode.Text
        cmbSHProv.Text = cmbBLProv.Text
        cmbSHCountry.Text = cmbBLCountry.Text
    End Sub

    '************************************************************************************************************
    '* inopt  - ACT=All
    '*          CCT=customer info   Combo country
    '*          BCT=Customer bill   Combo country
    '*          SCT=Customer shipto Combo country
    '* inmode - I=insert, U=Update
    '************************************************************************************************************
    Private Sub LoadCombCountries(ByVal inopt As String, ByVal inmode As String)

        If (inopt = "ACT" Or inopt = "CCT") Then
            'Set Customer info combobox: cmbCICountry
            GlobalVariables.Gl_SQLStr = "select countryname, ID from countries where active = 1 order by countryname"
            ModMisc.ReadCountries(cmbCICountry)
            If (inmode = "U") Then
                'cmbCICountry.Text = userrecord.MyCountry
                slCICountry = cmbCICountry.SelectedValue
            End If
        End If

        If (inopt = "ACT" Or inopt = "BCT") Then
            'Set Customer Billto combobox: cmbBLCountry
            GlobalVariables.Gl_SQLStr = "select countryname, ID from countries where active = 1 order by countryname"
            ModMisc.ReadCountries(cmbBLCountry)
            If (inmode = "U") Then
                'cmbBLCountry.Text = userrecord.MyCountry
                slBLCountry = cmbBLCountry.SelectedValue
            End If
        End If

        If (inopt = "ACT" Or inopt = "SCT") Then
            'Set Shipto combobox: cmbSHCountry
            GlobalVariables.Gl_SQLStr = "select countryname, ID from countries where active = 1 order by countryname"
            ModMisc.ReadCountries(cmbSHCountry)
            If (inmode = "U") Then
                'cmbSHCountry.Text = userrecord.MyCountry
                slSHCountry = cmbSHCountry.SelectedValue
            End If
        End If

        If (inmode = "U") Then
            'Customer info prov,city 
            If (inopt = "ACT" Or inopt = "CCT") Then
                GlobalVariables.Gl_SQLStr = "select provshort as countryname, ID from provinces where countryid = " & slCICountry & " and active = 1 order by provshort"
                ModMisc.ReadCountries(cmbCIProv)
                'cmbCIProv.Text = userrecord.MyCity
                slCIProv = cmbCIProv.SelectedValue

                GlobalVariables.Gl_SQLStr = "select cityname as countryname, ID from cities where countryid = " & slCICountry & " and provid = " & slCIProv & " and cityactive = 1 order by cityname"
                ModMisc.ReadCountries(cmbCICity)
                'cmbCICity.Text = userrecord.MyCity
                slCICity = cmbCICity.SelectedValue
            End If

            'Customer Billto prov,city 
            If (inopt = "ACT" Or inopt = "BCT") Then
                GlobalVariables.Gl_SQLStr = "select provshort as countryname, ID from provinces where countryid = " & slBLCountry & " and active = 1 order by provshort"
                ModMisc.ReadCountries(cmbBLProv)
                'cmbBLProv.Text = userrecord.MyCity
                slBLProv = cmbBLProv.SelectedValue

                GlobalVariables.Gl_SQLStr = "select cityname as countryname, ID from cities where countryid = " & slBLCountry & " and provid = " & slBLProv & " and cityactive = 1 order by cityname"
                ModMisc.ReadCountries(cmbBLcity)
                'cmbBLCity.Text = userrecord.MyCity
                slBLCity = cmbBLcity.SelectedValue
            End If


            'Customer Shipto prov,city
            If (inopt = "ACT" Or inopt = "SCT") Then
                GlobalVariables.Gl_SQLStr = "select provshort as countryname, ID from provinces where countryid = " & slSHCountry & " and active = 1 order by provshort"
                ModMisc.ReadCountries(cmbSHProv)
                'cmbSHProv.Text = userrecord.MyCity
                slSHProv = cmbSHProv.SelectedValue

                GlobalVariables.Gl_SQLStr = "select cityname as countryname, ID from cities where countryid = " & slSHCountry & " and provid = " & slSHProv & " and cityactive = 1 order by cityname"
                ModMisc.ReadCountries(cmbSHCity)
                'cmbSHCity.Text = userrecord.MyCity
                slSHCity = cmbSHCity.SelectedValue
            End If

        End If

    End Sub

    'Customer info country,prov, city changes
    Private Sub CmbCICountry_SelectedChangeCommitted(sender As Object, e As EventArgs) Handles cmbCICountry.SelectionChangeCommitted
        slCIcountry = cmbCICountry.SelectedValue

        GlobalVariables.Gl_SQLStr = "select provshort as countryname, ID from provinces where countryid = " & slCICountry & " and active = 1 order by provshort"
        ModMisc.ReadCountries(cmbCIProv)
        cmbCIProv.Text = ""
        slCIProv = cmbCIProv.SelectedValue

        GlobalVariables.Gl_SQLStr = "select cityname as countryname, ID from cities where countryid = " & slCICountry & " and provid = " & slCIProv & " and cityactive = 1 order by cityname"
        ModMisc.ReadCountries(cmbCICity)
        cmbCICity.Text = ""
        slCICity = cmbCICity.SelectedValue
    End Sub

    Private Sub cmbCIPROV_SelectedChangeCommitted(sender As Object, e As EventArgs) Handles cmbCIProv.SelectionChangeCommitted

        slCIProv = cmbCIProv.SelectedValue
        GlobalVariables.Gl_SQLStr = "select cityname as countryname, ID from cities where countryid = " & slCICountry & " and provid = " & slCIProv & " and cityactive = 1 order by cityname"
        ModMisc.ReadCountries(cmbCICity)
        cmbCICity.Text = ""
        slCICity = cmbCICity.SelectedValue

    End Sub

    Private Sub cmbCICity_SelectedChangeCommitted(sender As Object, e As EventArgs) Handles cmbCICity.SelectionChangeCommitted
        slCICity = cmbCICity.SelectedValue
    End Sub

    'Customer Billto country,prov, city changes
    Private Sub CmbBLCountry_SelectedChangeCommitted(sender As Object, e As EventArgs) Handles cmbBLCountry.SelectionChangeCommitted
        slBLCountry = cmbBLCountry.SelectedValue

        GlobalVariables.Gl_SQLStr = "select provshort as countryname, ID from provinces where countryid = " & slBLCountry & " and active = 1 order by provshort"
        ModMisc.ReadCountries(cmbBLProv)
        cmbBLProv.Text = ""
        slBLProv = cmbBLProv.SelectedValue

        GlobalVariables.Gl_SQLStr = "select cityname as countryname, ID from cities where countryid = " & slBLCountry & " and provid = " & slBLProv & " and cityactive = 1 order by cityname"
        ModMisc.ReadCountries(cmbBLcity)
        cmbBLcity.Text = ""
        slBLCity = cmbBLcity.SelectedValue
    End Sub

    Private Sub cmbBLPROV_SelectedChangeCommitted(sender As Object, e As EventArgs) Handles cmbBLProv.SelectionChangeCommitted

        slBLProv = cmbBLProv.SelectedValue
        GlobalVariables.Gl_SQLStr = "select cityname as countryname, ID from cities where countryid = " & slBLCountry & " and provid = " & slBLProv & " and cityactive = 1 order by cityname"
        ModMisc.ReadCountries(cmbBLcity)
        cmbBLcity.Text = ""
        slBLCity = cmbBLcity.SelectedValue

    End Sub

    Private Sub cmbBLCity_SelectedChangeCommitted(sender As Object, e As EventArgs) Handles cmbBLcity.SelectionChangeCommitted
        slBLCity = cmbBLcity.SelectedValue
    End Sub

    'Customer Shipto country,prov, city changes
    Private Sub CmbSHCountry_SelectedChangeCommitted(sender As Object, e As EventArgs) Handles cmbSHCountry.SelectionChangeCommitted
        slSHCountry = cmbSHCountry.SelectedValue

        GlobalVariables.Gl_SQLStr = "select provshort as countryname, ID from provinces where countryid = " & slSHCountry & " and active = 1 order by provshort"
        ModMisc.ReadCountries(cmbSHProv)
        cmbSHProv.Text = ""
        slSHProv = cmbSHProv.SelectedValue

        GlobalVariables.Gl_SQLStr = "select cityname as countryname, ID from cities where countryid = " & slSHCountry & " and provid = " & slSHProv & " and cityactive = 1 order by cityname"
        ModMisc.ReadCountries(cmbSHCity)
        cmbSHCity.Text = ""
        slSHCity = cmbSHCity.SelectedValue
    End Sub

    Private Sub cmbSHPROV_SelectedChangeCommitted(sender As Object, e As EventArgs) Handles cmbSHProv.SelectionChangeCommitted

        slSHProv = cmbSHProv.SelectedValue
        GlobalVariables.Gl_SQLStr = "select cityname as countryname, ID from cities where countryid = " & slSHCountry & " and provid = " & slSHProv & " and cityactive = 1 order by cityname"
        ModMisc.ReadCountries(cmbSHCity)
        cmbSHCity.Text = ""
        slSHCity = cmbSHCity.SelectedValue

    End Sub

    Private Sub cmbSHCity_SelectedChangeCommitted(sender As Object, e As EventArgs) Handles cmbSHCity.SelectionChangeCommitted
        slSHCity = cmbSHCity.SelectedValue
    End Sub

    'save customer
    Private Sub CmdSaveCust_Click(sender As Object, e As EventArgs) Handles cmdSaveCust.Click




        If (AppLocking.WriteDelLock("D", 0, "Customer", "Customer", selcustid, seluw2) = False) Then 'lock it
            MsgBox("Error Creating Lock Record!")
        End If

    End Sub

End Class