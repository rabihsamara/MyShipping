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
End Class