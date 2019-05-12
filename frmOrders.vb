﻿Imports System.Data.SqlClient

Public Class frmOrders

    Private sCommand As SqlCommand
    Private sAdapter As SqlDataAdapter
    Private sBuilder As SqlCommandBuilder
    Private sDs As DataSet
    Private sTable As DataTable
    Private myReader As SqlDataReader
    Private Ordrecord As Orders = New Orders()

    Private Sub FrmOrders_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmdNew.Visible = False

        inCustIdName.Text = GlobalVariables.Gl_tmpcustid & " - " & GlobalVariables.Gl_tmpcustname
        inacctNO.Text = GlobalVariables.Gl_tmpacctname
        inCustIdName.Enabled = False
        inacctNO.Enabled = False

        OrderNO.Text = GlobalVariables.Gl_SelOrder
        OrderNO.Enabled = False

        If (GlobalVariables.Gl_OrdCallFrmID = "COE") Then 'customer screen Existing order
            GlobalVariables.Gl_SQLStr = "SELECT ID,CustNo,AccountNo,OrderNO,ordStat,ordshipID,SHName,SHadd1,SHadd2,cmbSHCity,SHPcode,cmbSHProv,cmbSHCountry,"
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "BLName,BLadd1,BLadd2,cmbBLcity,BLpcode,cmbBLProv,cmbBLCountry,CONVERT(date,datecreated) as datecreated,CONVERT(date,dateupdated) as dateupdated,CreatedBy"
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & " FROM orders where  CustNo = '" & GlobalVariables.Gl_tmpcustid & "' and AccountNo  = '" & GlobalVariables.Gl_tmpacctname & "' and OrderNO = " & GlobalVariables.Gl_SelOrder
            If (ReadOrder() = False) Then
                MsgBox("Error reading Order !")
                Exit Sub
            End If
            LoadOrdToScreen()
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