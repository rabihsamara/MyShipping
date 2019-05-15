Imports System.Data.SqlClient

Public Class frmOrders

    Private sCommand As SqlCommand
    Private sAdapter As SqlDataAdapter
    Private sBuilder As SqlCommandBuilder
    Private sDs As DataSet
    Private sTable As DataTable
    Private myReader As SqlDataReader

    Private Ordrecord As Orders = New Orders()
    Private tstat As Boolean = False
    Private selordstatshort As String = ""

    Private selSordShCountryID As Integer = 0
    Private selSordShProvID As Integer = 0
    Private selSordShCityID As Integer = 0
    Private selSordBLCountryID As Integer = 0
    Private selSordBLProvID As Integer = 0
    Private selSordBLCityID As Integer = 0

    Private ordshipto As shipto = New shipto()

    Private Sub FrmOrders_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmdNew.Visible = False
        cmdCancel.Visible = False
        cmdLoad.Enabled = True
        incmbMcustID.Visible = False
        incmbMCustAcctID.Visible = False

        inCustIdName.Text = GlobalVariables.Gl_tmpcustid & " - " & GlobalVariables.Gl_tmpcustname
        inacctNO.Text = GlobalVariables.Gl_tmpacctname
        inCustIdName.Enabled = False
        inacctNO.Enabled = False

        OrderNO.Text = GlobalVariables.Gl_SelOrder
        OrderNO.Enabled = False

        tstat = ModMisc.FillCBoxBytable(OrdStat, "ORST")

        tstat = ModMisc.FillCBoxBytable(cmbShpType, "ORSTY")
        tstat = ModMisc.FillCBoxBytable(cmbshpmethod, "ORSM")

        tstat = ModMisc.FillCBoxBytable(cmbSHCountry, "ORSC")
        tstat = ModMisc.FillCBoxBytable(cmbBLCountry, "ORSC")

        tstat = ModMisc.FillCBoxBytable(incmbSrchOrd, "ORHO")
        incmbSrchOrd.SelectedItem = ""
        incmbSrchOrd.SelectedIndex = -1

        If (GlobalVariables.Gl_OrdCallFrmID = "COE") Then 'customer screen Existing order
            GlobalVariables.Gl_SQLStr = "SELECT ID,CustNo,AccountNo,OrderNO,(select ordstatfull from ordstatus where ordstatshort =  ordStat) as ordstat,isnull(ordshipID,'') as ordshipID,"
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "IIF(cmbShpType < 1,' ',(select Concat(shptype,' - ',shptime) from ordtypes where ID = cmbShpType)) as cmbShpType,cmbShpType as intshptype,"
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "IIF(cmbshpmethod < 1,' ',(select concat(shpmshort,' - ',shpmfull) from shpmethods where ID = cmbshpmethod)) as cmbshpmethod,cmbshpmethod as intshpmethod,"
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "isnull(SHName,'') as SHname,isnull(SHadd1,'') as SHadd1,isnull(SHadd2,'') as SHadd2,isnull(cmbSHCity,'') as cmbSHCity,"
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "isnull(SHPcode,'') as SHPcode,isnull(cmbSHProv,'') as cmbSHProv,isnull(cmbSHCountry,'') as cmbSHCountry,"
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "isnull(BLName,'') as BLName,isnull(BLadd1,'') as BLadd1,isnull(BLadd2,'') as BLadd2,isnull(cmbBLcity,'') as cmbBLCity,isnull(BLpcode,'') as BLPcode,"
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "isnull(cmbBLProv,'') as cmbBLProv,isnull(cmbBLCountry,'') as cmbBLCountry,datecreated,dateupdated,CreatedBy"
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & " FROM orders where CustNo = '" & GlobalVariables.Gl_tmpcustid & "' and AccountNo  = '"
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & GlobalVariables.Gl_tmpacctname & "' and OrderNO = " & GlobalVariables.Gl_SelOrder
            If (ReadOrder() = False) Then
                MsgBox("Error reading Order !")
                Exit Sub
            End If
            ordshipID.Items.Clear()
            tstat = ModMisc.FillCBoxBytable(ordshipID, "ORSHT", , , GlobalVariables.Gl_tmpcustid)
            ordshipID.Text = GlobalVariables.GL_selOrdShipID
            ordshipID.SelectedValue = GlobalVariables.GL_selOrdShipID
            LoadOrdToScreen()
        ElseIf (GlobalVariables.Gl_OrdCallFrmID = "CON") Then 'customer screen new order
            GlobalVariables.Gl_SQLStr = "select isnull(max(orderNO),0) + 1 as cnt FROM orders where CustNo = '" & GlobalVariables.Gl_tmpcustid & "' and AccountNo  = '" & GlobalVariables.Gl_tmpacctname & "'"
            GlobalVariables.Gl_SelOrder = ReadSQL("MXONO")
            If (GlobalVariables.GL_Stat = False) Then
                MsgBox("Error getting next order#!")
                Exit Sub
            End If
            OrderNO.Text = GlobalVariables.Gl_SelOrder
            OrdStat.Text = "New"

            ordshipID.Items.Clear()
            tstat = ModMisc.FillCBoxBytable(ordshipID, "ORSHT", , , GlobalVariables.Gl_tmpcustid)

            OrdStat.SelectedItem = ""
            OrdStat.SelectedIndex = -1
            cmbShpType.SelectedItem = ""
            cmbShpType.SelectedIndex = -1
            cmbshpmethod.SelectedItem = ""
            cmbshpmethod.SelectedIndex = -1
            ordshipID.SelectedItem = ""
            ordshipID.SelectedIndex = -1
            cmbSHCountry.SelectedItem = ""
            cmbSHCountry.SelectedIndex = -1
            cmbBLCountry.SelectedItem = ""
            cmbBLCountry.SelectedIndex = -1

            GlobalVariables.Gl_SQLStr = "if not Exists(select 1 from Orders where custNO = '" & GlobalVariables.Gl_tmpcustid & "' and AccountNo  = '" & GlobalVariables.Gl_tmpacctname & "' and OrderNO = " & GlobalVariables.Gl_SelOrder & ") Begin "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "INSERT INTO  Orders (CustNo,AccountNo,OrderNO,ordStat,ordshipID,cmbShpType,cmbshpmethod,datecreated,dateupdated,CreatedBy) VALUES "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "('" & GlobalVariables.Gl_tmpcustid & "','" & GlobalVariables.Gl_tmpacctname & "'," & GlobalVariables.Gl_SelOrder & ",'NW','','','','" & Now() & "','" & Now() & "','" & GlobalVariables.Gl_LogUserID & "') END"
            If (ModMisc.ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                MsgBox("Error Creating new Order!")
                Exit Sub
            End If
        ElseIf (GlobalVariables.Gl_OrdCallFrmID = "COM") Then 'menu
            cmdNew.Visible = True
            cmdSave.Enabled = False
            inCustIdName.Visible = False
            inacctNO.Visible = False
            incmbMcustID.Visible = True
            incmbMCustAcctID.Visible = True

            OrdStat.SelectedItem = ""
            OrdStat.SelectedIndex = -1
            cmbShpType.SelectedItem = ""
            cmbShpType.SelectedIndex = -1
            cmbshpmethod.SelectedItem = ""
            cmbshpmethod.SelectedIndex = -1
            ordshipID.SelectedItem = ""
            ordshipID.SelectedIndex = -1
            cmbSHCountry.SelectedItem = ""
            cmbSHCountry.SelectedIndex = -1
            cmbBLCountry.SelectedItem = ""
            cmbBLCountry.SelectedIndex = -1

            GBOrdInfo.Enabled = False
            GBSHBLInfo.Enabled = False
            GBModInfo.Enabled = False
            TabContord.Enabled = False

            tstat = ModMisc.FillCBoxBytable(incmbMcustID, "ORCI")
            incmbMcustID.SelectedItem = ""
            incmbMcustID.SelectedIndex = -1
        End If

    End Sub

#Region "Commands"

    Private Sub CmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click
        If (incmbMcustID.Text = "") Then
            MsgBox("Must select customer ID!")
            Exit sub
        End If
        If (incmbMCustAcctID.Text = "") Then
            MsgBox("Must select customer Account!")
            Exit Sub
        End If

        GlobalVariables.Gl_SQLStr = "select isnull(max(orderNO),0) + 1 as cnt FROM orders where CustNo = '" & GlobalVariables.Gl_tmpcustid & "' and AccountNo  = '" & GlobalVariables.Gl_tmpacctname & "'"
        GlobalVariables.Gl_SelOrder = ReadSQL("MXONO")
        If (GlobalVariables.GL_Stat = False) Then
            MsgBox("Error getting next order#!")
            Exit Sub
        End If
        OrderNO.Text = GlobalVariables.Gl_SelOrder
        OrdStat.Text = "New"

        GlobalVariables.Gl_SQLStr = "if not Exists(select 1 from Orders where custNO = '" & GlobalVariables.Gl_tmpcustid & "' and AccountNo  = '" & GlobalVariables.Gl_tmpacctname & "' and OrderNO = " & GlobalVariables.Gl_SelOrder & ") Begin "
        GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "INSERT INTO  Orders (CustNo,AccountNo,OrderNO,ordStat,ordshipID,cmbShpType,cmbshpmethod,datecreated,dateupdated,CreatedBy) VALUES "
        GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "('" & GlobalVariables.Gl_tmpcustid & "','" & GlobalVariables.Gl_tmpacctname & "'," & GlobalVariables.Gl_SelOrder & ",'NW','','','','" & Now() & "','" & Now() & "','" & GlobalVariables.Gl_LogUserID & "') END"
        If (ModMisc.ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
            MsgBox("Error Creating new Order!")
            Exit Sub
        End If

        cmdCancel.Visible = True
        GBOrdInfo.Enabled = True
        GBSHBLInfo.Enabled = True
        GBModInfo.Enabled = True
        TabContord.Enabled = True
        cmdNew.Enabled = False
        cmdExit.Enabled = False
        incmbMcustID.Enabled = False
        incmbMCustAcctID.Enabled = False

    End Sub

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        ClrFields()
        Me.Close()
    End Sub

    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        If (ModUpdates.UpdateFormData("LCOU", Me, "Orders", GlobalVariables.Gl_tmpacctname) = False) Then
            MsgBox("Error updating Orders table!")
            Exit Sub
        Else
            If (GlobalVariables.Gl_OrdCallFrmID = "COE") Then
                GlobalVariables.Gl_SQLStr = "update Orders set dateupdated = '" & Now() & "' where CustNo = '" & GlobalVariables.Gl_tmpcustid & "' and AccountNo  = '" & GlobalVariables.Gl_tmpacctname & "'"
                If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                    MsgBox("Error updating Customer order update date!")
                    Exit Sub
                End If
            End If
        End If
        MsgBox("Orders Updated OK!")
        tstat = ModMisc.FillCBoxBytable(incmbSrchOrd, "ORHO")
        incmbSrchOrd.SelectedItem = ""
        incmbSrchOrd.SelectedIndex = -1

    End Sub

#End Region

#Region "ReadORDintoObject"

    Public Function ReadOrder() As Boolean

        GlobalVariables.GL_Stat = False
        ReadOrder = False

        Using mysqlConn As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)
            Try

                sCommand = mysqlConn.CreateCommand
                sCommand.CommandText = GlobalVariables.Gl_SQLStr
                mysqlConn.Open()

                myReader = sCommand.ExecuteReader()
                Do While myReader.Read()

                    Ordrecord.MyID = myReader.GetValue(0)
                    Ordrecord.MyCustNo = myReader.GetString(1).ToString
                    Ordrecord.MyAccountNo = myReader.GetString(2).ToString
                    Ordrecord.MyOrderNO = myReader.GetValue(3)
                    Ordrecord.MyordStat = myReader.GetString(4).ToString
                    Ordrecord.MyorshipID = myReader.GetString(5).ToString
                    GlobalVariables.GL_selOrdShipID = Ordrecord.MyorshipID

                    Ordrecord.MycmbShpType = myReader.GetString(6).ToString
                    Ordrecord.Myintshptype = myReader.GetValue(7)
                    GlobalVariables.GL_cmbShpType = Ordrecord.Myintshptype
                    cmbShpType.SelectedValue = Ordrecord.Myintshptype

                    Ordrecord.Mycmbshpmethod = myReader.GetString(8).ToString
                    Ordrecord.Myintshpmethod = myReader.GetValue(9)
                    GlobalVariables.GL_selshpmethod = Ordrecord.Myintshpmethod
                    cmbshpmethod.SelectedValue = Ordrecord.Myintshpmethod

                    Ordrecord.MySHName = myReader.GetString(10).ToString
                    Ordrecord.MySHadd1 = myReader.GetString(11).ToString
                    Ordrecord.MySHadd2 = myReader.GetString(12).ToString
                    Ordrecord.MycmbSHCity = myReader.GetString(13).ToString

                    Ordrecord.MySHPcode = myReader.GetString(14).ToString
                    Ordrecord.MycmbSHProv = myReader.GetString(15).ToString
                    Ordrecord.MycmbSHCountry = myReader.GetString(16).ToString
                    Ordrecord.MyBLName = myReader.GetString(17).ToString
                    Ordrecord.MyBLadd1 = myReader.GetString(18).ToString
                    Ordrecord.MyBLadd2 = myReader.GetString(19).ToString
                    Ordrecord.MycmbBLcity = myReader.GetString(20).ToString

                    Ordrecord.MyBLpcode = myReader.GetString(21).ToString
                    Ordrecord.MycmbBLProv = myReader.GetString(22).ToString
                    Ordrecord.MycmbBLCountry = myReader.GetString(23).ToString
                    Ordrecord.Mydatecreated = myReader.GetDateTime(24)
                    Ordrecord.Mydateupdated = myReader.GetDateTime(25)
                    Ordrecord.MyCreatedBy = myReader.GetString(26).ToString
                    ReadOrder = True
                Loop

            Catch ex As Exception
                MsgBox(ex.ToString)
                ReadOrder = False
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

#End Region

#Region "ReadOrdinfotoscreen"

    '****************************************************************************************
    '* Load data to screen
    '****************************************************************************************
    Private Function LoadOrdToScreen() As Boolean

        LoadOrdToScreen = False

        Using connection As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)
            connection.Open()
            sCommand = New SqlCommand(GlobalVariables.Gl_SQLStr, connection)
            sAdapter = New SqlDataAdapter(sCommand)
            sBuilder = New SqlCommandBuilder(sAdapter)
            sDs = New DataSet()
            sAdapter.Fill(sDs, "Orders")
            sTable = sDs.Tables("Orders")

            If sTable.Rows.Count > 0 Then
                ControlsRecr(Me.Controls)
                LoadOrdToScreen = True
            End If

            connection.Close()

        End Using

    End Function

    Private Sub ControlsRecr(ByVal controls As Control.ControlCollection)

        Dim tmpval As String = ""

        For Each ctrl As Control In controls
            If ctrl.Name <> String.Empty And ctrl.GetType.Name <> "Label" Then
                tmpval = LoadFormControls(ctrl.Name, ctrl.GetType.Name, ctrl.Text)
                If GlobalVariables.GL_Stat = True Then
                    ctrl.Text = tmpval
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
                LoadFormControls = sTable.Rows(0)(ctrlname).ToString()
                GlobalVariables.GL_Stat = True
            End If
        End If

    End Function
#End Region

#Region "ComboboxShpcommit"

    Private Sub OrdStat_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles OrdStat.SelectionChangeCommitted
        selordstatshort = OrdStat.SelectedValue.ToString ' NW for new etc
    End Sub

    Private Sub cmbSHCountry_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbSHCountry.SelectionChangeCommitted
        selSordShCountryID = cmbSHCountry.SelectedValue
        'change prov bycountry id
        FIllSHProv()
    End Sub

    Private Sub cmbSHProv_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbSHProv.SelectionChangeCommitted
        selSordShProvID = cmbSHProv.SelectedValue
        tstat = ModMisc.FillCBoxBytable(cmbSHCity, "ORSY", selSordShCountryID, selSordShProvID)
    End Sub

    Private Sub FIllSHProv()
        tstat = ModMisc.FillCBoxBytable(cmbSHProv, "ORSP", selSordShCountryID)
    End Sub

    Private Sub cmbSHcity_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbSHCity.SelectionChangeCommitted
        selSordShCityID = cmbSHCity.SelectedValue
    End Sub

#End Region

#Region "ComboboxBillcommit"
    Private Sub cmbBLCountry_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbBLCountry.SelectionChangeCommitted
        selSordBLCountryID = cmbBLCountry.SelectedValue
        'change prov bycountry id
        FIllBLProv()
    End Sub

    Private Sub cmbBLProv_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbBLProv.SelectionChangeCommitted
        selSordBLProvID = cmbBLProv.SelectedValue
        tstat = ModMisc.FillCBoxBytable(cmbBLcity, "ORSY", selSordBLCountryID, selSordBLProvID)
    End Sub

    Private Sub FIllBLProv()
        tstat = ModMisc.FillCBoxBytable(cmbBLProv, "ORSP", selSordBLCountryID)
    End Sub

    Private Sub cmbBLcity_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbBLcity.SelectionChangeCommitted
        selSordBLCityID = cmbBLcity.SelectedValue
    End Sub

    Private Sub cmbShpType_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbShpType.SelectionChangeCommitted

        GlobalVariables.GL_cmbShpType = cmbShpType.SelectedValue

    End Sub

    Private Sub cmbshpmethod_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbshpmethod.SelectionChangeCommitted

        GlobalVariables.GL_selshpmethod = cmbshpmethod.SelectedValue

    End Sub

    Private Sub incmbMcustID_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles incmbMcustID.SelectionChangeCommitted
        GlobalVariables.Gl_tmpcustid = incmbMcustID.SelectedValue
        tstat = ModMisc.FillCBoxBytable(incmbMCustAcctID, "CANOA", , , GlobalVariables.Gl_tmpcustid)
        incmbMCustAcctID.SelectedItem = ""
        incmbMCustAcctID.SelectedIndex = -1
    End Sub

    Private Sub incmbMCustAcctID_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles incmbMCustAcctID.SelectionChangeCommitted
        GlobalVariables.Gl_tmpacctname = incmbMCustAcctID.SelectedValue
    End Sub

    Private Sub ordshipID_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ordshipID.SelectionChangeCommitted

        GlobalVariables.GL_selOrdShipID = ordshipID.SelectedValue
        ordshipto = ModMisc.GetShiptoRec(GlobalVariables.Gl_tmpcustid, GlobalVariables.GL_selOrdShipID)

        SHName.Text = ordshipto.MyShipName
        SHadd1.Text = ordshipto.MyShipadd1
        SHadd2.Text = ordshipto.MyShipadd2
        cmbSHCity.Text = ordshipto.MyShipcity
        cmbSHProv.Text = ordshipto.MyShipprov
        SHPcode.Text = ordshipto.MyShippcode
        cmbSHCountry.Text = ordshipto.MyShipcountry

    End Sub

    Private Sub cmdCopyshp_Click(sender As Object, e As EventArgs) Handles cmdCopyshp.Click

        BLName.Text = SHName.Text
        BLadd1.Text = SHadd1.Text
        BLadd2.Text = SHadd2.Text
        cmbBLcity.Text = cmbSHCity.Text
        cmbBLProv.Text = cmbSHProv.Text
        BLpcode.Text = SHPcode.Text
        cmbBLCountry.Text = cmbSHCountry.Text

    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click

        ClrFields()
        cmdCancel.Visible = False
        GBOrdInfo.Enabled = False
        GBSHBLInfo.Enabled = False
        GBModInfo.Enabled = False
        TabContord.Enabled = False
        cmdLoad.Enabled = True
        cmdNew.Enabled = True
        cmdExit.Enabled = True
        incmbMcustID.SelectedItem = ""
        incmbMcustID.SelectedIndex = -1
        incmbMCustAcctID.SelectedItem = ""
        incmbMCustAcctID.SelectedIndex = -1

    End Sub

    Private Sub cmdLoad_Click(sender As Object, e As EventArgs) Handles cmdLoad.Click

        If (incmbSrchOrd.Text = "") Then
            MsgBox("Must select order!")
            Exit Sub
        End If

        cmdCancel.Visible = True
        cmdSave.Enabled = True
        cmdExit.Enabled = False
        cmdLoad.Enabled = False
        cmdNew.Enabled = False

        GBOrdInfo.Enabled = True
        GBSHBLInfo.Enabled = True
        GBModInfo.Enabled = True
        TabContord.Enabled = True

        GlobalVariables.Gl_SQLStr = "SELECT ID,CustNo,AccountNo,OrderNO,(select ordstatfull from ordstatus where ordstatshort =  ordStat) as ordstat,isnull(ordshipID,'') as ordshipID,"
        GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "IIF(cmbShpType < 1,' ',(select Concat(shptype,' - ',shptime) from ordtypes where ID = cmbShpType)) as cmbShpType,cmbShpType as intshptype,"
        GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "IIF(cmbshpmethod < 1,' ',(select concat(shpmshort,' - ',shpmfull) from shpmethods where ID = cmbshpmethod)) as cmbshpmethod,cmbshpmethod as intshpmethod,"
        GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "isnull(SHName,'') as SHname,isnull(SHadd1,'') as SHadd1,isnull(SHadd2,'') as SHadd2,isnull(cmbSHCity,'') as cmbSHCity,"
        GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "isnull(SHPcode,'') as SHPcode,isnull(cmbSHProv,'') as cmbSHProv,isnull(cmbSHCountry,'') as cmbSHCountry,"
        GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "isnull(BLName,'') as BLName,isnull(BLadd1,'') as BLadd1,isnull(BLadd2,'') as BLadd2,isnull(cmbBLcity,'') as cmbBLCity,isnull(BLpcode,'') as BLPcode,"
        GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "isnull(cmbBLProv,'') as cmbBLProv,isnull(cmbBLCountry,'') as cmbBLCountry,datecreated,dateupdated,CreatedBy"
        GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & " FROM orders where CustNo = '" & GlobalVariables.Gl_tmpcustid & "' and AccountNo  = '"
        GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & GlobalVariables.Gl_tmpacctname & "' and OrderNO = " & GlobalVariables.Gl_SelOrder
        If (ReadOrder() = False) Then
            MsgBox("Error reading Order !")
            Exit Sub
        End If

        ordshipID.Items.Clear()
        tstat = ModMisc.FillCBoxBytable(ordshipID, "ORSHT", , , GlobalVariables.Gl_tmpcustid)
        ordshipID.Text = GlobalVariables.GL_selOrdShipID
        ordshipID.SelectedValue = GlobalVariables.GL_selOrdShipID
        LoadOrdToScreen()
        incmbMcustID.Enabled = False
        incmbMCustAcctID.Enabled = False

    End Sub

    Private Sub incmbSrchOrd_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles incmbSrchOrd.SelectionChangeCommitted

        Dim slval As String = incmbSrchOrd.SelectedValue
        Dim strArr() As String = slval.Split(",")

        GlobalVariables.Gl_tmpcustid = Trim(strArr(0))
        GlobalVariables.Gl_tmpacctname = Trim(strArr(1))
        GlobalVariables.Gl_SelOrder = Convert.ToInt32(Trim(strArr(2)))

    End Sub

    Private Sub ClrFields()

        OrdStat.DataSource = Nothing
        cmbShpType.DataSource = Nothing
        cmbshpmethod.DataSource = Nothing
        ordshipID.DataSource = Nothing
        cmbSHCity.DataSource = Nothing
        cmbSHProv.DataSource = Nothing
        cmbSHCountry.DataSource = Nothing
        cmbBLcity.DataSource = Nothing
        cmbBLProv.DataSource = Nothing
        cmbBLCountry.DataSource = Nothing

        incmbMcustID.Enabled = True
        incmbMCustAcctID.Enabled = True

        'incmbSrchOrd.DataSource = Nothing
        'incmbSrchOrd.Items.Clear()

        incmbSrchOrd.Text = ""

        OrderNO.Text = ""
        OrdStat.Items.Clear()
        cmbShpType.Items.Clear()
        cmbshpmethod.Items.Clear()
        ordshipID.Items.Clear()

        ordshipID.Text = ""
        SHName.Text = ""
        SHadd1.Text = ""
        SHadd2.Text = ""
        cmbSHCity.Items.Clear()
        cmbSHCity.Text = ""
        SHPcode.Text = ""
        cmbSHProv.Items.Clear()
        cmbSHProv.Text = ""
        cmbSHCountry.Items.Clear()
        BLName.Text = ""
        BLadd1.Text = ""
        BLadd2.Text = ""
        cmbBLcity.Items.Clear()
        cmbBLcity.Text = ""
        BLpcode.Text = ""
        cmbBLProv.Items.Clear()
        cmbBLProv.Text = ""
        cmbBLCountry.Items.Clear()
        datecreated.Text = ""
        dateupdated.Text = ""
        createdby.Text = ""

    End Sub

#End Region

End Class