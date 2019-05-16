Imports System.Data.SqlClient

Public Class frmCustomers

    Private mysqlConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Private results As String
    Private selcustid As String = String.Empty
    Private selcustname As String = String.Empty
    Private selShipToid As String = String.Empty
    Private selacctrow As Integer = 0
    Private selacctID As Integer = 0
    Private selacctNO As String = ""
    Private selOrdrow As Integer = 0

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
        If (Trim(incmbSelType.Text) <> "") Then climode = climode & Trim(incmbSelType.Text).Substring(0, 2) 'CRI or CRICS CRIPR CRIAL or CRIACS CRIAPR CRIAAL

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
                    'Ok create new cust. load screen to 
                    GlobalVariables.Gl_SQLStr = "Insert into customers (CustID, CIName, cmbCustType, chCIactive,datecreated,dateupdate,createdby) Values ('" & Trim(inCustID.Text) & "','" & inCustName.Text & "','PR',1,'" & Now() & "','" & Now() & "','" & GlobalVariables.Gl_LogUserID & "')"
                    If (ModMisc.ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                        MsgBox("Error Creating new Customer!")
                        GoTo EDIT_EXIT
                    End If
                    terr = "Customer Created Successfully!"

                    CIName.Text = inCustName.Text
                    LoadData()
                    LoadCombCountries("ACT", seluw2)
                    tstat = ModMisc.FillCBoxBytable(cmbShpID, "CSHT", , , Trim(inCustID.Text)) ' load shipto combobox
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

            'GlobalVariables.Gl_SQLStr = "SELECT CustID,CIName,ISNULL(CIadd1,'') as CIadd1,ISNULL(CIAdd2,'') as CIadd2,ISNULL(cmbCICity,'') as cmbCICity,ISNULL(CIpcode,'') as CIpcode ,ISNULL(cmbCIProv,'') as cmbCIProv ,ISNULL(cmbCICountry,'') as cmbCICountry,cmbCustType,chCIactive,"
            'GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "ISNULL(BLName,'') as BLName, ISNULL(BLadd1,'') as BLadd1, ISNULL(BLadd2,'') as BLAdd2, ISNULL(cmbBLcity,'') as cmbBLcity, ISNULL(BLpcode,'') as BLpcode, ISNULL(cmbBLProv,'') as cmbBLProv, ISNULL(cmbBLCountry,'') as cmbBLCountry,"
            'GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "ISNULL(cmbShpID,'') as cmbShpID, ISNULL(SHName,'') as SHName, ISNULL(SHadd1,'') as SHadd1, ISNULL(SHadd2,'') as SHAdd2,"
            'GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "ISNULL(cmbSHCity,'') as cmbSHCity, ISNULL(SHPcode,'') as SHPcode, ISNULL(cmbSHProv,'') as cmbSHProv, ISNULL(cmbSHCountry,'') as cmbSHCountry, datecreated,dateupdate,createdby FROM Customers  "
            'GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & If(selcustid <> "", " where CustID = '" & selcustid & "'", " where CIname = '" & selcustname & "'")

            GlobalVariables.Gl_SQLCriteria = If(selcustid <> "", " where CustID = '" & selcustid & "'", " where CIname = '" & selcustname & "'")
            If (ModMisc.CreateSelectStatement("Customers", GlobalVariables.Gl_SQLCriteria) = True) Then
                If (ReadCustomer("C") = False) Then
                    MsgBox("Error reading Order !")
                    GoTo EDIT_EXIT
                End If
            Else
                MsgBox("Error Creating SQL Statement!")
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
                    'check if same user ! delete and continue or just continue ?
                    If (AppCustLocks.MyUserid <> GlobalVariables.Gl_LogUserID) Then
                        terr = "record for cust " & selcustid & " is locked by user " & AppCustLocks.MyUserid
                        GoTo EDIT_EXIT
                    End If
                End If
            End If

            'load data to screen
            cmbShpID.DataSource = Nothing
            cmbShpID.Items.Clear()
            tstat = ModMisc.FillCBoxBytable(cmbShpID, "CSHT", , , selcustid)

            LoadCombCountries("ACT", seluw2)
            LoadCustScreen("Customers")
            LoadAccts()
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

#Region "loadDTToSCR"


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

        LoadFormControls = Nothing

        GlobalVariables.GL_Stat = False
        If (ctrlname.Substring(0, 2) <> "in" And ctrlname.Substring(0, 2) <> "GB") Then
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
#End Region

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
                Dim columnIndex As Integer = 0

                myCmd = mysqlConn.CreateCommand
                myCmd.CommandText = GlobalVariables.Gl_SQLStr
                mysqlConn.Open()

                myReader = myCmd.ExecuteReader()
                Do While myReader.Read()

                    columnIndex = myReader.GetOrdinal("CustID")
                    Custrecord.MyCustID = myReader.GetString(columnIndex)
                    selcustid = Custrecord.MyCustID

                    columnIndex = myReader.GetOrdinal("CIName")
                    Custrecord.MyCIName = myReader.GetString(columnIndex)
                    selcustname = Custrecord.MyCIName

                    columnIndex = myReader.GetOrdinal("CIadd1")
                    Custrecord.MyCIadd1 = myReader.GetString(columnIndex)

                    columnIndex = myReader.GetOrdinal("CIAdd2")
                    Custrecord.MyCIAdd2 = myReader.GetString(columnIndex)

                    columnIndex = myReader.GetOrdinal("cmbCICity")
                    Custrecord.MycmbCICity = myReader.GetString(columnIndex)

                    columnIndex = myReader.GetOrdinal("CIpcode")
                    Custrecord.MyCIpcode = myReader.GetString(columnIndex)

                    columnIndex = myReader.GetOrdinal("cmbCIProv")
                    Custrecord.MycmbCIProv = myReader.GetString(columnIndex)

                    columnIndex = myReader.GetOrdinal("cmbCICountry")
                    Custrecord.MycmbCICountry = myReader.GetString(columnIndex)

                    columnIndex = myReader.GetOrdinal("cmbCustType")
                    Custrecord.MycmbCustType = myReader.GetString(columnIndex)

                    columnIndex = myReader.GetOrdinal("chCIactive")
                    Custrecord.MychCIactive = myReader.GetValue(columnIndex)

                    columnIndex = myReader.GetOrdinal("BLName")
                    Custrecord.MyBLName = myReader.GetString(columnIndex)

                    columnIndex = myReader.GetOrdinal("BLadd1")
                    Custrecord.MyBLadd1 = myReader.GetString(columnIndex)

                    columnIndex = myReader.GetOrdinal("BLadd2")
                    Custrecord.MyBLadd2 = myReader.GetString(columnIndex)

                    columnIndex = myReader.GetOrdinal("cmbBLcity")
                    Custrecord.MycmbBLcity = myReader.GetString(columnIndex)

                    columnIndex = myReader.GetOrdinal("BLpcode")
                    Custrecord.MyBLpcode = myReader.GetString(columnIndex)

                    columnIndex = myReader.GetOrdinal("cmbBLProv")
                    Custrecord.MycmbBLProv = myReader.GetString(columnIndex)

                    columnIndex = myReader.GetOrdinal("cmbBLCountry")
                    Custrecord.MycmbBLCountry = myReader.GetString(columnIndex)

                    columnIndex = myReader.GetOrdinal("cmbShpID")
                    Custrecord.MycmbShpID = myReader.GetString(columnIndex)

                    columnIndex = myReader.GetOrdinal("SHName")
                    Custrecord.MySHName = myReader.GetString(columnIndex)

                    columnIndex = myReader.GetOrdinal("SHadd1")
                    Custrecord.MySHadd1 = myReader.GetString(columnIndex)

                    columnIndex = myReader.GetOrdinal("SHadd2")
                    Custrecord.MySHadd2 = myReader.GetString(columnIndex)

                    columnIndex = myReader.GetOrdinal("cmbSHCity")
                    Custrecord.MycmbSHCity = myReader.GetString(columnIndex)

                    columnIndex = myReader.GetOrdinal("SHPcode")
                    Custrecord.MySHPcode = myReader.GetString(columnIndex)

                    columnIndex = myReader.GetOrdinal("cmbSHProv")
                    Custrecord.MycmbSHProv = myReader.GetString(columnIndex)

                    columnIndex = myReader.GetOrdinal("cmbSHCountry")
                    Custrecord.MycmbSHCountry = myReader.GetString(columnIndex)

                    columnIndex = myReader.GetOrdinal("datecreated")
                    Custrecord.Mydatecreated = myReader.GetDateTime(columnIndex)

                    columnIndex = myReader.GetOrdinal("dateupdate")
                    Custrecord.Mydateupdate = myReader.GetDateTime(columnIndex)

                    columnIndex = myReader.GetOrdinal("createdby")
                    Custrecord.MyCreatedby = myReader.GetString(columnIndex)

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

#Region "Commands"

    Private Sub CmdCanCust_Click(sender As Object, e As EventArgs) Handles cmdCanCust.Click
        'check if new was pressed or update

        'release log 
        If (AppLocking.WriteDelLock("D", 0, "Customer", "Customer", selcustid, seluw2) = False) Then
            MsgBox("Error deleting Lock record!")
        End If

        clrFields("A")
        cmdSaveShpto.Enabled = False
        EnableFields("S", True)
        GBorders.Text = "Orders per Account"
        TabControl1.Visible = False

    End Sub

    'Billto copy address from customer nfo address
    Private Sub cmdBillCopy_Click(sender As Object, e As EventArgs) Handles cmdBillCopy.Click
        BLName.Text = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(CIName.Text)
        BLadd1.Text = CIadd1.Text
        BLadd2.Text = CIAdd2.Text
        cmbBLcity.Text = cmbCICity.Text
        BLpcode.Text = CIpcode.Text
        cmbBLProv.Text = cmbCIProv.Text
        cmbBLCountry.Text = cmbCICountry.Text
    End Sub

    'shipto save it
    Private Sub CmdSaveShpto_Click(sender As Object, e As EventArgs) Handles cmdSaveShpto.Click

        GlobalVariables.Gl_tmpcustid = selcustid
        GlobalVariables.Gl_tmpcustname = selcustname

        Dim frm As New frmShippingadd()
        frm.ShowDialog()

    End Sub

    'shipto section copy from customer info
    Private Sub CmdSaveshipasinfo_Click(sender As Object, e As EventArgs) Handles cmdSaveshipasinfo.Click
        SHName.Text = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(CIName.Text)
        SHadd1.Text = CIadd1.Text
        SHadd2.Text = CIAdd2.Text
        cmbSHCity.Text = cmbCICity.Text
        SHPcode.Text = CIpcode.Text
        cmbSHProv.Text = cmbCIProv.Text
        cmbSHCountry.Text = cmbCICountry.Text
    End Sub

    'shipto section copy from billto
    Private Sub CmdShSaveBill_Click(sender As Object, e As EventArgs) Handles cmdShSaveBill.Click
        SHName.Text = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(BLName.Text)
        SHadd1.Text = BLadd1.Text
        SHadd2.Text = BLadd2.Text
        cmbSHCity.Text = cmbBLcity.Text
        SHPcode.Text = BLpcode.Text
        cmbSHProv.Text = cmbBLProv.Text
        cmbSHCountry.Text = cmbBLCountry.Text
    End Sub
#End Region

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
                slCICountry = cmbCICountry.SelectedValue
            End If
        End If

        If (inopt = "ACT" Or inopt = "BCT") Then
            'Set Customer Billto combobox: cmbBLCountry
            GlobalVariables.Gl_SQLStr = "Select countryname, ID from countries where active = 1 order by countryname"
            ModMisc.ReadCountries(cmbBLCountry)
            If (inmode = "U") Then
                slBLCountry = cmbBLCountry.SelectedValue
            End If
        End If

        If (inopt = "ACT" Or inopt = "SCT") Then
            'Set Shipto combobox: cmbSHCountry
            GlobalVariables.Gl_SQLStr = "Select countryname, ID from countries where active = 1 order by countryname"
            ModMisc.ReadCountries(cmbSHCountry)
            If (inmode = "U") Then
                slSHCountry = cmbSHCountry.SelectedValue
            End If
        End If

        If (inmode = "U") Then
            'Customer info prov,city 
            If (inopt = "ACT" Or inopt = "CCT") Then
                GlobalVariables.Gl_SQLStr = "Select provshort As countryname, ID from provinces where countryid = " & slCICountry & " And active = 1 order by provshort"
                ModMisc.ReadCountries(cmbCIProv)
                slCIProv = cmbCIProv.SelectedValue

                GlobalVariables.Gl_SQLStr = "Select cityname As countryname, ID from cities where countryid = " & slCICountry & " And provid = " & slCIProv & " And cityactive = 1 order by cityname"
                ModMisc.ReadCountries(cmbCICity)
                slCICity = cmbCICity.SelectedValue
            End If

            'Customer Billto prov,city 
            If (inopt = "ACT" Or inopt = "BCT") Then
                GlobalVariables.Gl_SQLStr = "Select provshort As countryname, ID from provinces where countryid = " & slBLCountry & " And active = 1 order by provshort"
                ModMisc.ReadCountries(cmbBLProv)
                slBLProv = cmbBLProv.SelectedValue

                GlobalVariables.Gl_SQLStr = "Select cityname As countryname, ID from cities where countryid = " & slBLCountry & " And provid = " & slBLProv & " And cityactive = 1 order by cityname"
                ModMisc.ReadCountries(cmbBLcity)
                slBLCity = cmbBLcity.SelectedValue
            End If


            'Customer Shipto prov,city
            If (inopt = "ACT" Or inopt = "SCT") Then
                GlobalVariables.Gl_SQLStr = "Select provshort As countryname, ID from provinces where countryid = " & slSHCountry & " And active = 1 order by provshort"
                ModMisc.ReadCountries(cmbSHProv)
                slSHProv = cmbSHProv.SelectedValue

                GlobalVariables.Gl_SQLStr = "Select cityname As countryname, ID from cities where countryid = " & slSHCountry & " And provid = " & slSHProv & " And cityactive = 1 order by cityname"
                ModMisc.ReadCountries(cmbSHCity)
                slSHCity = cmbSHCity.SelectedValue
            End If

        End If

    End Sub

    'Customer info country,prov, city changes
    Private Sub CmbCICountry_SelectedChangeCommitted(sender As Object, e As EventArgs) Handles cmbCICountry.SelectionChangeCommitted
        slCIcountry = cmbCICountry.SelectedValue

        GlobalVariables.Gl_SQLStr = "Select provshort As countryname, ID from provinces where countryid = " & slCICountry & " And active = 1 order by provshort"
        ModMisc.ReadCountries(cmbCIProv)
        cmbCIProv.Text = ""
        slCIProv = cmbCIProv.SelectedValue

        GlobalVariables.Gl_SQLStr = "Select cityname As countryname, ID from cities where countryid = " & slCICountry & " And provid = " & slCIProv & " And cityactive = 1 order by cityname"
        ModMisc.ReadCountries(cmbCICity)
        cmbCICity.Text = ""
        slCICity = cmbCICity.SelectedValue
    End Sub

    Private Sub cmbCIPROV_SelectedChangeCommitted(sender As Object, e As EventArgs) Handles cmbCIProv.SelectionChangeCommitted

        slCIProv = cmbCIProv.SelectedValue
        GlobalVariables.Gl_SQLStr = "Select cityname As countryname, ID from cities where countryid = " & slCICountry & " And provid = " & slCIProv & " And cityactive = 1 order by cityname"
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

        GlobalVariables.Gl_SQLStr = "Select provshort As countryname, ID from provinces where countryid = " & slBLCountry & " And active = 1 order by provshort"
        ModMisc.ReadCountries(cmbBLProv)
        cmbBLProv.Text = ""
        slBLProv = cmbBLProv.SelectedValue

        GlobalVariables.Gl_SQLStr = "Select cityname As countryname, ID from cities where countryid = " & slBLCountry & " And provid = " & slBLProv & " And cityactive = 1 order by cityname"
        ModMisc.ReadCountries(cmbBLcity)
        cmbBLcity.Text = ""
        slBLCity = cmbBLcity.SelectedValue
    End Sub

    Private Sub cmbBLPROV_SelectedChangeCommitted(sender As Object, e As EventArgs) Handles cmbBLProv.SelectionChangeCommitted

        slBLProv = cmbBLProv.SelectedValue
        GlobalVariables.Gl_SQLStr = "Select cityname As countryname, ID from cities where countryid = " & slBLCountry & " And provid = " & slBLProv & " And cityactive = 1 order by cityname"
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

        GlobalVariables.Gl_SQLStr = "Select provshort As countryname, ID from provinces where countryid = " & slSHCountry & " And active = 1 order by provshort"
        ModMisc.ReadCountries(cmbSHProv)
        cmbSHProv.Text = ""
        slSHProv = cmbSHProv.SelectedValue

        GlobalVariables.Gl_SQLStr = "Select cityname As countryname, ID from cities where countryid = " & slSHCountry & " And provid = " & slSHProv & " And cityactive = 1 order by cityname"
        ModMisc.ReadCountries(cmbSHCity)
        cmbSHCity.Text = ""
        slSHCity = cmbSHCity.SelectedValue
    End Sub

    Private Sub cmbSHPROV_SelectedChangeCommitted(sender As Object, e As EventArgs) Handles cmbSHProv.SelectionChangeCommitted

        slSHProv = cmbSHProv.SelectedValue
        GlobalVariables.Gl_SQLStr = "Select cityname As countryname, ID from cities where countryid = " & slSHCountry & " And provid = " & slSHProv & " And cityactive = 1 order by cityname"
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

        If (ModUpdates.UpdateFormData(topert, Me, "Customers", selcustid) = False) Then
            MsgBox("Error updating Customer table!")
            Exit Sub
        Else
            If (seluw2 = "U") Then
                GlobalVariables.Gl_SQLStr = "update Customers set dateupdate = '" & Now() & "' where custid = '" & selcustid & "'"
                    If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                    MsgBox("Error updating Customer update date!")
                    Exit Sub
                End If
            End If
        End If

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
            CIcustshipto.Mydatecreated = Now()
            CIcustshipto.Mydateupdated = Now()
            CIcustshipto.MyShcreatedby = GlobalVariables.Gl_LogUserID
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

            DataGridOrders.DataSource = Nothing
            DataGridAccts.DataSource = Nothing
        End If

    End Sub

    Private Sub CmdNewAcct_Click(sender As Object, e As EventArgs) Handles cmdNewAcct.Click
        GlobalVariables.Gl_tmpacctID = 0
        GlobalVariables.Gl_tmpcustid = selcustid
        GlobalVariables.Gl_tmpcustname = selcustname
        GlobalVariables.Gl_acctCallFrmID = "CN"
        Dim frm As New frmAccounts()
        frm.ShowDialog()
        LoadAccts()

    End Sub

    Private Sub LoadAccts()

        GBAccounts.Text = "Accounts for Customer: " & CIName.Text
        Dim tsql As String = "SELECT ID,AccountNo,AccountName,IIF(active = 1,'Y','N') as active, CONVERT(date,datecreated) as datecreated,CONVERT(date,dateupdated) as dateupdated,CreatedBy from accounts where CustNo = '" & selcustid & "'"
        GlobalVariables.GL_CSAcctsGridCNT = ModMisc.LoadDataGrids(DataGridAccts, tsql, "accounts")
        If (GlobalVariables.GL_CSAcctsGridCNT > 0) Then
            With DataGridAccts
                .Columns(0).HeaderText = "ID"
                .Columns(1).HeaderText = "Account"
                .Columns(2).HeaderText = "Name"
                .Columns(3).HeaderText = "Active"
                .Columns(4).HeaderText = "Created On"
                .Columns(5).HeaderText = "Update On"
                .Columns(6).HeaderText = "Created By"

                .Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
            End With
        End If

    End Sub

    Private Sub DataGridAccts_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DataGridAccts.MouseDoubleClick

        If (GlobalVariables.GL_CSAcctsGridCNT > 0) Then
            selacctrow = DataGridAccts.CurrentRow.Index
            If (selacctrow < GlobalVariables.GL_CSAcctsGridCNT) Then
                selacctID = DataGridAccts.Item(0, selacctrow).Value
                selacctNO = DataGridAccts.Item(1, selacctrow).Value
                GlobalVariables.Gl_tmpacctID = selacctID
                GlobalVariables.Gl_tmpacctname = selacctNO
                GlobalVariables.Gl_tmpcustid = selcustid
                GlobalVariables.Gl_tmpcustname = selcustname
                GlobalVariables.Gl_acctCallFrmID = "CE"
                Dim frm As New frmAccounts()
                frm.ShowDialog()
                LoadAccts()
            End If
        End If

    End Sub

    Private Sub DataGridAccts_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridAccts.MouseClick

        If (GlobalVariables.GL_CSAcctsGridCNT > 0) Then
            selacctrow = DataGridAccts.CurrentRow.Index
            If (selacctrow < GlobalVariables.GL_CSAcctsGridCNT) Then
                selacctID = DataGridAccts.Item(0, selacctrow).Value
                selacctNO = DataGridAccts.Item(1, selacctrow).Value
                GlobalVariables.Gl_tmpacctID = selacctID
                GlobalVariables.Gl_tmpacctname = selacctNO
                GlobalVariables.Gl_tmpcustid = selcustid
                GlobalVariables.Gl_tmpcustname = selcustname
                GBorders.Text = "Orders for Account " & selacctNO
                LoadOrders()
            End If
        End If

    End Sub

    Private Sub LoadOrders()

        Dim tsql As String
        tsql = "SELECT ID,OrderNo,(select ordstatfull from ordstatus where ordstatshort =  ordStat) as ordstat,CONVERT(date,datecreated) as datecreated,CONVERT(date,dateupdated) as dateupdated,CreatedBy"
        tsql = tsql & " from orders where CustNo = '" & selcustid & "' and AccountNO = '" & selacctNO & "'"

        GlobalVariables.GL_CSOrdsGridCNT = ModMisc.LoadDataGrids(DataGridOrders, tsql, "orders")
        If (GlobalVariables.GL_CSOrdsGridCNT > 0) Then
            With DataGridOrders
                .Columns(0).HeaderText = "ID"
                .Columns(1).HeaderText = "OrderNO"
                .Columns(2).HeaderText = "Status"
                .Columns(3).HeaderText = "Created On"
                .Columns(4).HeaderText = "Update On"
                .Columns(5).HeaderText = "Created By"

                .Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
                .Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
            End With
        End If

    End Sub

    Private Sub DataGridOrders_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridOrders.MouseClick

        If (GlobalVariables.GL_CSOrdsGridCNT > 0) Then
            selOrdrow = DataGridOrders.CurrentRow.Index
            If (selOrdrow < GlobalVariables.GL_CSOrdsGridCNT) Then
                GlobalVariables.Gl_OrdCallFrmID = "COE"
                GlobalVariables.Gl_SelOrderID = DataGridOrders.Item(0, selOrdrow).Value
                GlobalVariables.Gl_SelOrder = DataGridOrders.Item(1, selOrdrow).Value

                Dim frm As New frmOrders()
                frm.ShowDialog()
                LoadOrders()
            End If
        End If

    End Sub

    Private Sub CmdNewOrder_Click(sender As Object, e As EventArgs) Handles cmdNewOrder.Click

        If GBorders.Text.ToString.Contains("for") Then
            GlobalVariables.Gl_OrdCallFrmID = "CON"
            GlobalVariables.Gl_SelOrderID = 0
            GlobalVariables.Gl_SelOrder = 0

            Dim frm As New frmOrders()
            frm.ShowDialog()
            LoadOrders()
        End If

    End Sub

End Class