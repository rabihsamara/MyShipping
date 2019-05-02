Public Class Login

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim tblld As Boolean = True
        Dim I As Integer = 0

        txtmsg.Visible = False

        If (GlobalVariables.GL_skipOnce = False) Then
            tblld = MyConn.BuildSQLStr()
        End If

        If (tblld = True) Then
            Me.Text = "myShipping"
            If (ModMisc.FillCBox(cmbUsers, "L") = False) Then
                Application.Exit()
            End If
            If (ModMisc.FillCBox(cmbCompany, "P") = False) Then
                Application.Exit()
            End If
        End If

    End Sub

    Private Sub cmdLogin_Click(sender As Object, e As EventArgs) Handles cmdLogin.Click

        Dim frm As Form = New Form()
        Dim tpasswd As String

        'frmMysetings.Tag = "Login" 'change wherever you called form frmMysetings

        txtmsg.Text = ""
        If (cmbUsers.Text = "" Or inPassword.Text = "") Then
            txtmsg.Text = "Must enter UserID and Password!"
            txtmsg.Visible = True
            Exit Sub
        End If

        GlobalVariables.Gl_LogUserID = cmbUsers.Text  'logged in user
        tpasswd = Me.inPassword.Text

        If (GlobalVariables.Gl_LogUserID = GlobalVariables.GL_DfltConnValues.AppMyDFUser) Then
            If (tpasswd = GlobalVariables.GL_DfltConnValues.AppMyDFUpwd) Then
                GlobalVariables.Gl_UserIDLevel = "A" ' admin
            Else
                txtmsg.Text = "Invalid Passowrd for admin user!"
                txtmsg.Visible = True
                Exit Sub
            End If
        Else
            If ModMisc.ReadSQL("CUP", tpasswd) = False Then ' check passowrd
                txtmsg.Text = "Invalid Passowrd"
                txtmsg.Visible = True
                Exit Sub
            End If
        End If

        If (cmbCompany.Text = "") Then
            txtmsg.Text = "Must Select company"
            txtmsg.Visible = True
            Exit Sub
        End If
        GlobalVariables.Gl_Company = cmbCompany.Text
        Me.Hide()

        'Check Entry user/password
        frm = MainMenu
        frm.Show()

    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Application.Exit()

    End Sub

End Class
