Imports System.Data.SqlClient

Public Class frmOrders

    Private sCommand As SqlCommand
    Private sAdapter As SqlDataAdapter
    Private sBuilder As SqlCommandBuilder
    Private sDs As DataSet
    Private sTable As DataTable

    Private Sub FrmOrders_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmdNew.Visible = False

        inCustIdName.Text = GlobalVariables.Gl_tmpcustid & " - " & GlobalVariables.Gl_tmpcustname
        inacctNO.Text = GlobalVariables.Gl_tmpacctname
        inCustIdName.Enabled = False
        inacctNO.Enabled = False

        OrderNO.Text = GlobalVariables.Gl_SelOrder
        OrderNO.Enabled = False

        If (GlobalVariables.Gl_OrdCallFrmID = "COE") Then 'customer screen Existing order
            LoadOrdToScreen("orders")
        ElseIf (GlobalVariables.Gl_OrdCallFrmID = "CON") Then 'customer screen new order

        ElseIf (GlobalVariables.Gl_OrdCallFrmID = "COM") Then 'menu
            cmdNew.Visible = True
            inCustIdName.Visible = False
            inacctNO.Visible = False

        End If

    End Sub

#Region "Commands"

    Private Sub CmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click

    End Sub

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

    End Sub
#End Region

#Region "ReadOrdinfotoscreen"

    '****************************************************************************************
    '* Load data to screen
    '****************************************************************************************
    Private Function LoadOrdToScreen(ByVal crtable As String) As Boolean

        Dim sql As String
        sql = "SELECT ID,CustNo,AccountNo,OrderNO,ordStat,ordshipID,SHName,SHadd1,SHadd2,cmbSHCity,SHPcode,cmbSHProv,cmbSHCountry,"
        sql = sql & "BLName,BLadd1,BLadd2,cmbBLcity,BLpcode,cmbBLProv,cmbBLCountry,CONVERT(date,datecreated) as datecreated,CONVERT(date,dateupdated) as dateupdated,CreatedBy"
        sql = sql & " FROM " & crtable & " where  CustNo = '" & GlobalVariables.Gl_tmpcustid & "' and AccountNo  = '" & GlobalVariables.Gl_tmpacctname & "' and OrderNO = " & GlobalVariables.Gl_SelOrder
        LoadOrdToScreen = False

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
                LoadOrdToScreen = True
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

End Class