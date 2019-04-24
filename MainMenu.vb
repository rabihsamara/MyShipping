Public Class MainMenu

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = GlobalVariables.Gl_LogUserID & " - " & GlobalVariables.Gl_Company

    End Sub

End Class