Imports System.Data.SqlClient

Public Class frmControls
    Private slusrfrmsecID As Integer = GlobalVariables.Gl_tmpfnameID

    Private Sub FrmControls_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dspuserdID.Text = GlobalVariables.Gl_tmpuserID
        dpsfname.Text = GlobalVariables.Gl_tmpfname
        LoadFormControls()

    End Sub

    Private Sub LoadFormControls()

        For Each formprop In My.Forms.GetType.GetProperties 'percorre todos os forms 

            Dim node = Me.TreeControls.Nodes.Add(formprop.Name)

            Dim frm As Form = CType(formprop.GetValue(My.Forms, Nothing), Form)

            ControlsTree(node, frm.Controls)

        Next

    End Sub

    Private Sub ControlsTree(ByVal node As TreeNode, ByVal controls As Control.ControlCollection)

        For Each ctrl As Control In controls
            If ctrl.Name <> String.Empty And ctrl.GetType.Name <> "Label" Then
                Dim child = node.Nodes.Add(ctrl.Tag, ctrl.GetType.Name & ": " & ctrl.Name)
                ControlsTree(child, ctrl.Controls)
            End If
        Next

    End Sub

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

End Class