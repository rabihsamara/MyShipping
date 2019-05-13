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
    Private selordshptoID As String = ""
    Private selSordShCountryID As Integer = 0
    Private selSordShProvID As Integer = 0
    Private selSordShCityID As Integer = 0
    Private selSordBLCountryID As Integer = 0
    Private selSordBLProvID As Integer = 0
    Private selSordBLCityID As Integer = 0
    Private ordshipto As shipto = New shipto()

    Private Sub FrmOrders_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmdNew.Visible = False

        inCustIdName.Text = GlobalVariables.Gl_tmpcustid & " - " & GlobalVariables.Gl_tmpcustname
        inacctNO.Text = GlobalVariables.Gl_tmpacctname
        inCustIdName.Enabled = False
        inacctNO.Enabled = False

        OrderNO.Text = GlobalVariables.Gl_SelOrder
        OrderNO.Enabled = False

        tstat = ModMisc.FillCBoxBytable(OrdStat, "ORST")
        tstat = ModMisc.FillCBoxBytable(cmbSHCountry, "ORSC")
        tstat = ModMisc.FillCBoxBytable(cmbBLCountry, "ORSC")
        ordshipID.Items.Clear()
        tstat = ModMisc.FillCBoxBytable(ordshipID, "ORSHT", , , GlobalVariables.Gl_tmpcustid)

        If (GlobalVariables.Gl_OrdCallFrmID = "COE") Then 'customer screen Existing order
            GlobalVariables.Gl_SQLStr = "SELECT ID,CustNo,AccountNo,OrderNO,(select ordstatfull from ordstatus where ordstatshort =  ordStat) as ordstat,ordshipID,SHName,SHadd1,SHadd2,cmbSHCity,SHPcode,cmbSHProv,cmbSHCountry,"
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "BLName,BLadd1,BLadd2,cmbBLcity,BLpcode,cmbBLProv,cmbBLCountry,"
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "CONVERT(date,datecreated) as datecreated,CONVERT(date,dateupdated) as dateupdated,CreatedBy"
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & " FROM orders where CustNo = '" & GlobalVariables.Gl_tmpcustid & "' and AccountNo  = '"
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & GlobalVariables.Gl_tmpacctname & "' and OrderNO = " & GlobalVariables.Gl_SelOrder
            If (ReadOrder() = False) Then
                MsgBox("Error reading Order !")
                Exit Sub
            End If
            LoadOrdToScreen()
        ElseIf (GlobalVariables.Gl_OrdCallFrmID = "CON") Then 'customer screen new order
            GlobalVariables.Gl_SQLStr = "select max(orderno) + 1 as cnt FROM orders where CustNo = '" & GlobalVariables.Gl_tmpcustid & "' and AccountNo  = '" & GlobalVariables.Gl_tmpacctname & "'"
            GlobalVariables.Gl_SelOrder = ReadSQL("MXONO")
            If (GlobalVariables.GL_Stat = False) Then
                MsgBox("error getting next order#!")
                Exit Sub
            End If
            OrderNO.Text = GlobalVariables.Gl_SelOrder
            OrdStat.Text = "New"
        ElseIf (GlobalVariables.Gl_OrdCallFrmID = "COM") Then 'menu
            cmdNew.Visible = True
            inCustIdName.Visible = False
            inacctNO.Visible = False


        End If

    End Sub

#Region "Commands"

    Private Sub CmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click
        'later

    End Sub

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        Dim topert As String = If(GlobalVariables.Gl_OrdCallFrmID = "CON", "LCOI", "LCOU")
        If (ModUpdates.UpdateFormData(topert, Me, "Orders", GlobalVariables.Gl_tmpacctname) = False) Then
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
                    Ordrecord.MySHName = myReader.GetString(6).ToString
                    Ordrecord.MySHadd1 = myReader.GetString(7).ToString
                    Ordrecord.MySHadd2 = myReader.GetString(8).ToString
                    Ordrecord.MycmbSHCity = myReader.GetString(9).ToString

                    Ordrecord.MySHPcode = myReader.GetString(10).ToString
                    Ordrecord.MycmbSHProv = myReader.GetString(11).ToString
                    Ordrecord.MycmbSHCountry = myReader.GetString(12).ToString
                    Ordrecord.MyBLName = myReader.GetString(13).ToString
                    Ordrecord.MyBLadd1 = myReader.GetString(14).ToString
                    Ordrecord.MyBLadd2 = myReader.GetString(15).ToString
                    Ordrecord.MycmbBLcity = myReader.GetString(16).ToString

                    Ordrecord.MyBLpcode = myReader.GetString(17).ToString
                    Ordrecord.MycmbBLProv = myReader.GetString(18).ToString
                    Ordrecord.MycmbBLCountry = myReader.GetString(19).ToString
                    Ordrecord.Mydatecreated = myReader.GetDateTime(20)
                    Ordrecord.Mydateupdated = myReader.GetDateTime(21)
                    Ordrecord.MyCreatedBy = myReader.GetString(22).ToString
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

#End Region

    Private Sub ordshipID_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ordshipID.SelectionChangeCommitted

        selordshptoID = ordshipID.SelectedValue
        ordshipto = ModMisc.GetShiptoRec(GlobalVariables.Gl_tmpcustid, selordshptoID)

        SHName.Text = ordshipto.MyShipName
        SHadd1.Text = ordshipto.MyShipadd1
        SHadd2.Text = ordshipto.MyShipadd2
        cmbSHCity.Text = ordshipto.MyShipcity
        cmbSHProv.Text = ordshipto.MyShipprov
        SHPcode.Text = ordshipto.MyShippcode
        cmbSHCountry.Text = ordshipto.MyShipcountry

    End Sub


End Class