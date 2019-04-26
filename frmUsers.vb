Imports System.Data.SqlClient

Public Class frmUsers
    Dim sCommand As SqlCommand
    Dim sAdapter As SqlDataAdapter
    Dim sBuilder As SqlCommandBuilder
    Dim sDs As DataSet
    Dim sTable As DataTable

    Private selusrid As String
    Private upmode As String
    Private selrow As Integer

    Private Sub FrmUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GBoxNewUser.Visible = False
        cmdSaveNewUser.Visible = False
        cmdCanNewUser.Visible = False

        LoadUsers()
    End Sub

    Private Sub LoadUsers()
        Dim sql As String = "SELECT UserID,Fname,Lname,usrmode,usrseclvl,active FROM users"
        Using connection As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)
            connection.Open()
            sCommand = New SqlCommand(sql, connection)
            sAdapter = New SqlDataAdapter(sCommand)
            sBuilder = New SqlCommandBuilder(sAdapter)
            sDs = New DataSet()
            sAdapter.Fill(sDs, "users")
            sTable = sDs.Tables("users")
            connection.Close()
            DataGridVWUsers.DataSource = sDs.Tables("users")
            DataGridVWUsers.ReadOnly = True
            DataGridVWUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End Using

    End Sub

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click

        Me.Close()

    End Sub

    Private Sub CmdNewUser_Click(sender As Object, e As EventArgs) Handles cmdNewUser.Click

        GBoxNewUser.Text = "New User"
        GBoxNewUser.Visible = True
        cmdSaveNewUser.Visible = True
        cmdCanNewUser.Visible = True
        cmdNewUser.Enabled = False
        upmode = "I" ' bew insert.
    End Sub

    Private Sub CmdCanNewUser_Click(sender As Object, e As EventArgs) Handles cmdCanNewUser.Click

        GBoxNewUser.Text = "New User"
        GBoxNewUser.Visible = False
        cmdSaveNewUser.Visible = False
        cmdCanNewUser.Visible = False
        cmdNewUser.Enabled = True

    End Sub

    Private Sub CmdSaveNewUser_Click(sender As Object, e As EventArgs) Handles cmdSaveNewUser.Click



        GBoxNewUser.Visible = False
        cmdSaveNewUser.Visible = False
        cmdCanNewUser.Visible = False
        cmdNewUser.Enabled = True
    End Sub

    Private Sub DataGridVWUsers_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridVWUsers.MouseClick


        Dim I As Integer
        selusrid = ""

        If (DataGridVWUsers.Rows.Count >= 1) Then

            I = DataGridVWUsers.CurrentRow.Index
            selusrid = DataGridVWUsers.Item(0, I).Value
            upmode = "U"

            'move data to fields






            GBoxNewUser.Text = "update User: " & selusrid
            GBoxNewUser.Visible = True
            cmdSaveNewUser.Visible = True
            cmdCanNewUser.Visible = True
            cmdNewUser.Enabled = False

        End If

    End Sub

End Class