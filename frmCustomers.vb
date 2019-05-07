Imports System.Data.SqlClient

Public Class frmCustomers

    Private mysqlConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Private results As String
    Private selcustid As String = String.Empty
    Private selcustname As String = String.Empty
    Private selShipToid As String = String.Empty

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
    Private CIcustshipto As shipto = New shipto()

    Dim sCommand As SqlCommand
    Dim sAdapter As SqlDataAdapter
    Dim sBuilder As SqlCommandBuilder
    Dim sDs As DataSet
    Dim sTable As DataTable

    Private Sub FrmCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtmsg.Visible = False
        inchslactonly.Checked = True
        cmdSaveShpto.Enabled = False
        TabControl1.Visible = False

        tstat = ModMisc.FillCBox(incmbSelType, "CST")
        tstat = ModMisc.FillCBox(cmbCustType, "CST")
        LoadData()

    End Sub

    Private Sub LoadData()

        Dim climode As String = "CRI"
        Dim clnmode As String = "CRN"
        If (inchslactonly.Checked = True) Then climode = "CRIA"
        If (inchslactonly.Checked = True) Then clnmode = "CRNA"
        '
        If (Trim(incmbSelType.Text) <> "") Then climode = climode & Trim(incmbSelType.Text).Substring(0, 2) 'CRI or CRICS CRIPR CRIAL or CRIACS CRIAPR CRIAAL
        If (Trim(incmbSelType.Text) <> "") Then clnmode = clnmode & Trim(incmbSelType.Text).Substring(0, 2) 'CRN or CRNCS CRNPR CRNAL or CRNACS CRNAPR CRNAAL
        '
        incmbCustID.Items.Clear()
        incmbCustName.Items.Clear()
        tstat = ModMisc.FillCBox(incmbCustID, climode)
        tstat = ModMisc.FillCBox(incmbCustName, clnmode)

    End Sub

    Private Sub InCustName_TextChanged(sender As Object, e As EventArgs) Handles inCustName.TextChanged
        CreateCustID()
    End Sub

    Private Sub CreateCustID()

        Dim L As Integer = inCustName.Text.Length
        Dim strArr() As String
        Dim tchr As String = ""
        Dim tmpt As String = ""

        If (inCustName.Text <> "" And L > 3 And InStr(inCustName.Text, " ") > 0) Then
            strArr = inCustName.Text.Split(" ")
            For count = 0 To strArr.Length - 1
                tmpt = Trim(strArr(count))
                tchr = tchr & If(tmpt <> "", tmpt.Substring(0, 1), "")
            Next
        Else
            inCustID.Text = If(inCustName.Text.Length > 3, inCustID.Text, "")
        End If
        If (inCustName.Text <> "") Then inCustID.Text = tchr & "01"

    End Sub

    'Process new customer
    Private Sub CmdProcess_Click(sender As Object, e As EventArgs) Handles cmdProcess.Click

        tmsg = EditEntry("N")
        If (tmsg = "X" Or tmsg <> "Customer Created Successfully!") Then Exit Sub ' user cancelled creating 
        EnableFields("S", False)
        TabControl1.Visible = True

    End Sub

    'Exit customer screen
    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click

        'release log 
        If (AppLocking.WriteDelLock("D", 0, "Customer", "Customer", selcustid, seluw2) = False) Then 'lock it
            MsgBox("Error deting Lock record!")
        End If
        Me.Close()

    End Sub

    'Load existing customer
    Private Sub cmdLoadCust_Click(sender As Object, e As EventArgs) Handles cmdLoadCust.Click
        tmsg = EditEntry("E")
        If (tmsg <> "") Then Exit Sub
        cmdSaveShpto.Enabled = True
        EnableFields("S", False)
        TabControl1.Visible = True

    End Sub

    Private Function EditEntry(ByVal inedit As String) As String

        Dim terr As String = String.Empty

        txtmsg.Visible = False
        terr = ""

        If (inedit = "N") Then
            If (inCustName.Text = "") Then
                terr = "Must Enter Customer Name!"
                GoTo EDIT_EXIT
            ElseIf (inCustID.Text = "") Then
                terr = "Must Enter Customer ID!"
                GoTo EDIT_EXIT
            End If

            inCustName.Text = Trim(inCustName.Text)
            inCustID.Text = Trim(inCustID.Text)
            GlobalVariables.Gl_SQLStr = "select count(*) as cnt from customers where CustID = '" & inCustID.Text & "' or CIName = '" & inCustName.Text & "'"
            If (ModMisc.ReadSQL("NCST", "") > 0) Then
                terr = "New Customer Exists!"
                GoTo EDIT_EXIT
            Else
                'create new customer message
                seluw = "I"
                seluw2 = "IU"
                selShipToid = ""
                inCustName.Text = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(inCustName.Text)
                selcustid = inCustID.Text
                selcustname = inCustName.Text

                Dim result As DialogResult = MessageBox.Show("Create New Customer?", "Confirm adding new customer", MessageBoxButtons.YesNo)
                If (result = DialogResult.Yes) Then
                    'Ok create new cust. load screen to database
                    GlobalVariables.Gl_SQLStr = "Insert into customers (CustID, CIName, cmbCustType, chCIactive) Values ('" & Trim(inCustID.Text) & "','" & inCustName.Text & "','PR',1)"
                    If (ModMisc.ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                        MsgBox("Error Creating new Customer!")
                        GoTo EDIT_EXIT
                    End If
                    terr = "Customer Created Successfully!"

                    CIName.Text = inCustName.Text
                    LoadData()
                    LoadCombCountries("ACT", seluw2)
                    tstat = ModMisc.FillCBox(incmbCustName, "CSHT") ' load shipto combobox
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
            selcustid = Trim(incmbCustID.Text)
            selcustname = Trim(incmbCustName.Text)
            If (selcustid = "" And selcustname = "") Then
                terr = "Must Select Customer ID Or Name!"
                GoTo EDIT_EXIT
            End If

            GlobalVariables.Gl_SQLStr = "SELECT CustID,CIName,ISNULL(CIadd1,'') as CIadd1,ISNULL(CIAdd2,'') as CIadd2,ISNULL(cmbCICity,'') as cmbCICity,ISNULL(CIpcode,'') as CIpcode ,ISNULL(cmbCIProv,'') as cmbCIProv ,ISNULL(cmbCICountry,'') as cmbCICountry,cmbCustType,chCIactive,"
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "ISNULL(BLName,'') as BLName, ISNULL(BLadd1,'') as BLadd1, ISNULL(BLadd2,'') as BLAdd2, ISNULL(cmbBLcity,'') as cmbBLcity, ISNULL(BLpcode,'') as BLpcode, ISNULL(cmbBLProv,'') as cmbBLProv, ISNULL(cmbBLCountry,'') as cmbBLCountry,"
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "ISNULL(cmbShpID,'') as cmbShpID, ISNULL(SHName,'') as SHName, ISNULL(SHadd1,'') as SHadd1, ISNULL(SHadd2,'') as SHAdd2,"
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "ISNULL(cmbSHCity,'') as cmbSHCity, ISNULL(SHPcode,'') as SHPcode, ISNULL(cmbSHProv,'') as cmbSHProv, ISNULL(cmbSHCountry,'') as cmbSHCountry FROM Customers  "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & If(selcustid <> "", " where CustID = '" & selcustid & "'", " where Custname = '" & selcustname & "'")
            If (ReadCustomer("C") = False) Then
                terr = "Error reading customer !"
                GoTo EDIT_EXIT
            End If
            seluw = "U"
            seluw2 = "U"
            selShipToid = Custrecord.MycmbShpID

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
            cmbShpID.Items.Clear()
            tstat = ModMisc.FillCBox(cmbShpID, "CSHT")
            LoadCombCountries("ACT", seluw2)
            LoadCustScreen("Customers")

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

    '****************************************************************************************
    '* Load data to screen
    '****************************************************************************************
    Private Function LoadCustScreen(ByVal crtable As String) As Boolean

        Dim sql As String = "SELECT * FROM " & crtable & " where Custid = '" & selcustid & "'"

        LoadCustScreen = False

        Using connection As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)
            connection.Open()
            sCommand = New SqlCommand(sql, connection)
            sAdapter = New SqlDataAdapter(sCommand)
            sBuilder = New SqlCommandBuilder(sAdapter)
            sDs = New DataSet()
            sAdapter.Fill(sDs, crtable)
            sTable = sDs.Tables(crtable)

            If sTable.Rows.Count > 0 Then
                ControlsRecr(Me.Controls)
                LoadCustScreen = True
            End If

            connection.Close()

        End Using

    End Function

    Private Sub ControlsRecr(ByVal controls As Control.ControlCollection)

        Dim tmpval As String = ""

        For Each ctrl As Control In controls
            If ctrl.Name <> String.Empty And ctrl.GetType.Name <> "Label" Then
                'MsgBox(ctrl.Name & " - " & ctrl.GetType.Name & " - " & ctrl.Text)
                tmpval = LoadFormControls(ctrl.Name, ctrl.GetType.Name, ctrl.Text)
                If GlobalVariables.GL_Stat = True Then
                    If (ctrl.Name = "chCIactive") Then
                        chCIactive.Checked = If(tmpval = 1, True, False)
                    Else
                        ctrl.Text = tmpval
                    End If

                End If
                ControlsRecr(ctrl.Controls)
            End If
        Next

    End Sub

    Private Function LoadFormControls(ByVal ctrlname As String, ByVal ctrltype As String, ByVal ctrlvalue As String) As Object

        Dim isInString As Boolean = False

        GlobalVariables.GL_Stat = False
        If (ctrlname.Substring(1, 2) <> "in") Then
            isInString = (GlobalVariables.typeAR.IndexOf(ctrltype) > -1)
            If ((isInString = True) Or ctrltype = "RadioButton") Then
                If (ctrlname = "chCIactive") Then
                    LoadFormControls = If(sTable.Rows(0)(ctrlname).ToString = "1", 1, 0)
                Else
                    LoadFormControls = sTable.Rows(0)(ctrlname).ToString()
                End If
                GlobalVariables.GL_Stat = True
            End If
        End If

    End Function

    '*************************************** End of Load data to screen functions ***************************************

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        txtmsg.Text = ""
        txtmsg.Visible = False
    End Sub

    'Reload existing customer filters custtype.
    Private Sub cmbSelType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles incmbSelType.SelectedIndexChanged
        incmbCustID.Text = ""
        incmbCustID.Items.Clear()
        incmbCustName.Text = ""
        incmbCustName.Items.Clear()
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
                    Custrecord.MyCIName = myReader.GetString(1).ToString
                    Custrecord.MyCIadd1 = myReader.GetString(2).ToString
                    Custrecord.MyCIAdd2 = myReader.GetString(3).ToString
                    Custrecord.MycmbCICity = myReader.GetString(4).ToString
                    Custrecord.MyCIpcode = myReader.GetString(5).ToString
                    Custrecord.MycmbCIProv = myReader.GetString(6).ToString
                    Custrecord.MycmbCICountry = myReader.GetString(7).ToString
                    Custrecord.MycmbCustType = myReader.GetString(8).ToString
                    Custrecord.MychCIactive = myReader.GetValue(9)

                    Custrecord.MyBLName = myReader.GetString(10).ToString
                    Custrecord.MyBLadd1 = myReader.GetString(11).ToString
                    Custrecord.MyBLadd2 = myReader.GetString(12).ToString
                    Custrecord.MycmbBLcity = myReader.GetString(13).ToString
                    Custrecord.MyBLpcode = myReader.GetString(14).ToString
                    Custrecord.MycmbBLProv = myReader.GetString(15).ToString
                    Custrecord.MycmbBLCountry = myReader.GetString(16).ToString

                    Custrecord.MycmbShpID = myReader.GetString(17).ToString
                    Custrecord.MySHName = myReader.GetString(18).ToString
                    Custrecord.MySHadd1 = myReader.GetString(19).ToString
                    Custrecord.MySHadd2 = myReader.GetString(20).ToString
                    Custrecord.MycmbSHCity = myReader.GetString(21).ToString
                    Custrecord.MySHPcode = myReader.GetString(22).ToString
                    Custrecord.MycmbSHProv = myReader.GetString(23).ToString
                    Custrecord.MycmbSHCountry = myReader.GetString(24).ToString

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
        If (AppLocking.WriteDelLock("D", 0, "Customer", "Customer", selcustid, seluw2) = False) Then
            MsgBox("Error deleting Lock record!")
        End If

        clrFields("A")
        cmdSaveShpto.Enabled = False
        EnableFields("S", True)
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

        SHName.Text = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(SHName.Text)

        If (seluw2 = "I" Or seluw2 = "IU") Then
            If (selShipToid = "") Then
                CIcustshipto = GetShiptoRec(selcustid, selShipToid)


                Dim result As DialogResult = MessageBox.Show("Create New Ship-to ID?", "Confirm add new ship-to ID", MessageBoxButtons.YesNo)
                If (result = DialogResult.Yes) Then
                    If (cmbShpID.Text = "") Then


                    End If

                Else
                    Exit Sub
                End If

            End If
        End If

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
    '* inmode - IU=insert, U=Update
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

    '*****************************************************************************************
    '* save customer
    '*****************************************************************************************
    Private Sub CmdSaveCust_Click(sender As Object, e As EventArgs) Handles cmdSaveCust.Click

        Dim topert As String = "LC" & seluw2

        GlobalVariables.Gl_tmpactive = 0
        If (chCIactive.Checked = True) Then
            GlobalVariables.Gl_tmpactive = 1
        End If

        ModUpdates.UpdateFormData(topert, Me, "Customers", selcustid)

        'New customer - save ship To
        If (topert = "LCIU") Then
            selShipToid = GetLastShipto(selcustid, Trim(SHName.Text))
            Dim result As String = InputBox("Use/Change Ship-to code!", "Accept Ship-to code", selShipToid, 100, 100)
            If (result = "") Then
                txtmsg.Text = "Must accept or enter a new shipto code!"
                txtmsg.Visible = True
                Timer1.Interval = 5000 'ms
                Timer1.Start()
                Exit Sub
            End If

            CIcustshipto.MyShipCustID = selcustid
            CIcustshipto.MyShiptoID = selShipToid
            CIcustshipto.MyShipName = Trim(SHName.Text)
            CIcustshipto.MyShipadd1 = Trim(SHadd1.Text)
            CIcustshipto.MyShipadd2 = Trim(SHadd2.Text)
            CIcustshipto.MyShipcity = Trim(cmbSHCity.Text)
            CIcustshipto.MyShippcode = Trim(SHPcode.Text)
            CIcustshipto.MyShipprov = Trim(cmbSHProv.Text)
            CIcustshipto.MyShipcountry = Trim(cmbSHCountry.Text)
            CIcustshipto.MyShipDflt = 1
            CIcustshipto.Myactive = 1
            If (UpdateCSShipTo(CIcustshipto, seluw2) = False) Then
                txtmsg.Text = "Error saving shipto info.!"
                txtmsg.Visible = True
                Timer1.Interval = 5000 'ms
                Timer1.Start()
                Exit Sub
            End If
        End If

        If (AppLocking.WriteDelLock("D", 0, "Customer", "Customer", selcustid, seluw2) = False) Then 'lock it
            MsgBox("Error Deleting Lock Record!")
        End If

        txtmsg.Text = "Customer Saved!"
        txtmsg.Visible = True
        Timer1.Interval = 5000 'ms
        Timer1.Start()

        clrFields("A")

        cmdSaveShpto.Enabled = False
        EnableFields("S", True)
        TabControl1.Visible = False

    End Sub

    'A=all, S=selection top
    Private Sub EnableFields(ByVal inopt As String, ByVal instat As Boolean)

        If (inopt = "A" Or inopt = "S") Then
            cmdProcess.Enabled = instat
            inCustID.Enabled = instat
            inCustName.Enabled = instat
            cmdLoadCust.Enabled = instat
            incmbCustID.Enabled = instat
            incmbCustName.Enabled = instat
            cmdExit.Enabled = instat
        End If

    End Sub

    'inopt - A= All , S=selection or new or existing customer top, F=tabcontrol data entry fields
    Private Sub clrFields(ByVal inopt As String)

        If (inopt = "A" Or inopt = "S") Then
            seluw = "I"
            seluw2 = ""
            selcustid = ""
            selcustname = ""
            selShipToid = ""
            inCustID.Text = ""
            inCustName.Text = ""
            incmbCustID.Text = ""
            incmbCustName.Text = ""
        End If

        If (inopt = "A" Or inopt = "F") Then
            CIName.Text = ""
            CIadd1.Text = ""
            CIAdd2.Text = ""
            cmbCICity.Text = ""
            CIpcode.Text = ""
            cmbCIProv.Text = ""
            cmbCICountry.Text = ""
            cmbCustType.Text = ""
            chCIactive.Checked = False

            BLName.Text = ""
            BLadd1.Text = ""
            BLadd2.Text = ""
            cmbBLcity.Text = ""
            BLpcode.Text = ""
            cmbBLProv.Text = ""
            cmbBLCountry.Text = ""

            SHName.Text = ""
            SHadd1.Text = ""
            SHadd2.Text = ""
            cmbSHCity.Text = ""
            SHPcode.Text = ""
            cmbSHProv.Text = ""
            cmbSHCountry.Text = ""
        End If

    End Sub

End Class