﻿Public Class Login

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim tblld As Boolean = False

        txtmsg.Visible = False

        If (GlobalVariables.GL_skipOnce = False) Then
            tblld = MyConn.BuildSQLStr()
        Else
            tblld = True
        End If

        If (tblld = True) Then
            'MsgBox(GlobalVariables.GL_DfltConnValues.AppMyDFUser)

            ' Set the caption bar text of the form.  
            Me.Text = "myShipping"
            If (ModMisc.FillUsers() = False) Then
                Application.Exit()
            End If
            If (FillCompanies() = False) Then
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
                txtmsg.Text = "Invalid Passowrd for default user!"
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

        Me.Hide()
        'Check Entry user/password
        frm = MainMenu
        frm.Show()

    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Application.Exit()

    End Sub

End Class
