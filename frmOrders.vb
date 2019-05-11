Public Class frmOrders

    Private Sub FrmOrders_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmdNew.Visible = False
        inCustIdName.Text = GlobalVariables.Gl_tmpcustid & " - " & GlobalVariables.Gl_tmpcustname
        inacctNO.Text = GlobalVariables.Gl_tmpacctname
        inCustIdName.Enabled = False
        inacctNO.Enabled = False

        If (GlobalVariables.Gl_OrdCallFrmID = "COE") Then 'customer screen Existing order

        ElseIf (GlobalVariables.Gl_OrdCallFrmID = "CON") Then 'customer screen new order

        ElseIf (GlobalVariables.Gl_OrdCallFrmID = "COM") Then 'menu
            cmdNew.Visible = True
            inCustIdName.Visible = False
            inacctNO.Visible = False

        End If



    End Sub


    Private Sub CmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click

    End Sub

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub


End Class