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

    Private userrecord As userrec = New userrec()

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
            DataGridVWUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End Using

    End Sub

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click

        Me.Close()

    End Sub

    Private Sub CmdNewUser_Click(sender As Object, e As EventArgs) Handles cmdNewUser.Click

        GBoxNewUser.Text = "New User"
        cmdSaveNewUser.Text = "Save User"
        clrUserFields()
        GBoxNewUser.Visible = True
        cmdSaveNewUser.Visible = True
        cmdCanNewUser.Visible = True
        cmdNewUser.Enabled = False
        upmode = "I" ' New insert.
    End Sub

    Private Sub CmdCanNewUser_Click(sender As Object, e As EventArgs) Handles cmdCanNewUser.Click

        GBoxNewUser.Text = "New User"
        cmdSaveNewUser.Text = "Save User"
        GBoxNewUser.Visible = False
        cmdSaveNewUser.Visible = False
        cmdCanNewUser.Visible = False
        cmdNewUser.Enabled = True
        clrUserFields()

    End Sub

    Private Sub CmdSaveNewUser_Click(sender As Object, e As EventArgs) Handles cmdSaveNewUser.Click

        'save or update user



        If (upmode = "I") Then
            'update user menu security levels (default).
            GlobalVariables.Gl_SQLStr = "insert into MenuUserSecurity (UserID, MenuMItem, MenuSitem, MenuS2Item, MenuSecLevel, MenuActive) "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "Select '" & usrID.Text & "',MenuMItem,MenuSitem,MenuS2Item,MenuSecLevel,MenuActive from MenuDfltSecurity where menuactive = 1"
            If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                MsgBox("Error Creating user Menu security Level!")
                Exit Sub
            End If
        End If

        GBoxNewUser.Text = "New User"
        cmdSaveNewUser.Text = "Save User"
        GBoxNewUser.Visible = False
        cmdSaveNewUser.Visible = False
        cmdCanNewUser.Visible = False
        cmdNewUser.Enabled = True
        clrUserFields()
    End Sub

    Private Sub DataGridVWUsers_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridVWUsers.MouseClick


        Dim I As Integer
        selusrid = ""

        If (DataGridVWUsers.Rows.Count >= 1) Then

            I = DataGridVWUsers.CurrentRow.Index
            selusrid = DataGridVWUsers.Item(0, I).Value
            upmode = "U"
            cmdSaveNewUser.Text = "Update User"
            'move data to fields

            GlobalVariables.Gl_SQLStr = "SELECT UserID,Fname,Lname,DateOfBirth,Address1,Address2,City,Province,Pcode,Country,Active,usrPassword,usrmode,usrseclvl FROM users where UserID = '" & selusrid & "'"
            userrecord = ModMisc.ReadSQL("userr", "")
            If (GlobalVariables.GL_Stat = False) Then
                MsgBox("error reading user info!")
                Exit Sub
            End If

            usrID.Text = userrecord.MyUserID
            DateOfBirth.Value = userrecord.MyDateOfBirth
            chactive.Checked = userrecord.MyActive
            usrfname.Text = userrecord.MyFname
            usrlname.Text = userrecord.MyLname
            usradd1.Text = userrecord.MyAddress1
            usradd2.Text = userrecord.MyAddress2
            cmbUsrCity.Text = userrecord.MyCity
            cmbUsrState.Text = userrecord.MyProvince
            usrpcode.Text = userrecord.MyPcode
            cmbUsrCountry.Text = userrecord.MyCountry
            cmbUsrSecLvl.Text = userrecord.Myusrseclvl
            usrpassword.Text = userrecord.MyusrPassword
            cmbUsrMode.Text = userrecord.Myusrmode

            GBoxNewUser.Text = "update User: " & selusrid
            GBoxNewUser.Visible = True
            cmdSaveNewUser.Visible = True
            cmdCanNewUser.Visible = True
            cmdNewUser.Enabled = False

        End If

    End Sub


    Private Sub clrUserFields()
        usrID.Text = ""
        DateOfBirth.Value = Now()
        chactive.Checked = 0
        usrfname.Text = ""
        usrlname.Text = ""
        usradd1.Text = ""
        usradd2.Text = ""
        cmbUsrCity.Text = ""
        cmbUsrState.Text = ""
        usrpcode.Text = ""
        cmbUsrCountry.Text = ""
        cmbUsrSecLvl.Text = ""
        usrpassword.Text = ""
        cmbUsrMode.Text = ""
    End Sub

End Class