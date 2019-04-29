Public Class Frmchkadpwd

    Private Sub Cmdchk_Click(sender As Object, e As EventArgs) Handles cmdchk.Click

        Dim tpwd As String = Trim(inmastpwd.Text)
        GlobalVariables.GL_Stat = False
        If (tpwd = "") Then
            MsgBox("Must Enter password!")
        ElseIf (tpwd <> My.Settings.mastpassword) Then
            MsgBox("Wrong password password!")
        Else
            GlobalVariables.GL_Stat = True
            Me.Close()
        End If

    End Sub

    Private Sub Frmchkadpwd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inmastpwd.Text = ""
        MsgBox(sender.ToString)
    End Sub

    Private Sub Frmchkadpwd_Closing(sender As Object, e As EventArgs) Handles MyBase.Load
        GlobalVariables.GL_Stat = False
    End Sub

End Class