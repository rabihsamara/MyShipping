Imports System.Data.SqlClient

Public Class frmUsers
    Dim sCommand As SqlCommand
    Dim sAdapter As SqlDataAdapter
    Dim sBuilder As SqlCommandBuilder
    Dim sDs As DataSet
    Dim sTable As DataTable

    Private selusrid As String
    Private upmode As String

    Private selsecID As Integer
    Private selsecuser As String

    Private selrow As Integer
    Private userrecord As userrec = New userrec()

    Private Sub FrmUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GBoxNewUser.Visible = False
        cmdSaveNewUser.Visible = False
        cmdCanNewUser.Visible = False
        GBMSec1.Visible = False
        GBEditSecMnu.visible = False

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
        GBMSec1.Visible = True
        GBoxNewUser.Visible = True
        cmdSaveNewUser.Visible = True
        cmdCanNewUser.Visible = True
        cmdNewUser.Enabled = False
        upmode = "I" ' New insert.
        usrID.Enabled = True
    End Sub

    Private Sub CmdCanNewUser_Click(sender As Object, e As EventArgs) Handles cmdCanNewUser.Click

        GBoxNewUser.Text = "New User"
        cmdSaveNewUser.Text = "Save User"
        GBoxNewUser.Visible = False
        cmdSaveNewUser.Visible = False
        cmdCanNewUser.Visible = False
        cmdNewUser.Enabled = True
        LoadUsersMenSec()
        GBMSec1.Visible = False
        GBEditSecMnu.Visible = False
        clrUserFields()
        usrID.Enabled = False

    End Sub

    Private Sub CmdSaveNewUser_Click(sender As Object, e As EventArgs) Handles cmdSaveNewUser.Click

        Dim tactive As Integer = 0

        If (chactive.Checked = True) Then tactive = 1

        'edit entry

        If (usrID.Text = "") Then
            MsgBox("Must Enter UserID!")
            Exit Sub
        ElseIf (Trim(usrID.Text) = "admin" And upmode = "I") Then
            MsgBox("Must Not Use this UserID!")
            Exit Sub
        End If
        '
        If (usrfname.Text = "" Or usrlname.Text = "") Then
            MsgBox("Must Enter User first and last name!")
            Exit Sub
        End If


        'save or update user
        If (upmode = "I") Then
            'Create default user (admin) in table users
            GlobalVariables.Gl_SQLStr = "if not Exists(select 1 from users where UserID = '" & usrID.Text & "') Begin "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "insert into users (UserID,Fname,Lname,DateOfBirth,Address1,Address2,City,Province,Pcode,country,Active,usrPassword,usrmode,usrseclvl) "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "Values ('" & usrID.Text & "','" & Trim(usrfname.Text) & "','" & Trim(usrlname.Text) & "','" & DateOfBirth.Value & "','" & Trim(usradd1.Text) & "','" & Trim(usradd2.Text) & "','" & Trim(cmbUsrCity.Text) & "','" & Trim(cmbUsrState.Text) & "','" & Trim(usrpcode.Text) & "','" & Trim(cmbUsrCountry.Text) & "'," & tactive & ",'" & Trim(usrpassword.Text) & "','" & Trim(cmbUsrMode.Text) & "','" & Trim(cmbUsrSecLvl.Text) & "') End"
            If (ModMisc.ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                MsgBox("Error Creating default user Record!")
                Exit Sub
            End If
            '
            'update user menu security levels (default).
            GlobalVariables.Gl_SQLStr = "insert into MenuUserSecurity (UserID, MenuMItem, MenuSitem, MenuS2Item, MenuSecLevel, MenuActive) "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "Select '" & usrID.Text & "',MenuMItem,MenuSitem,MenuS2Item,MenuSecLevel,MenuActive from MenuDfltSecurity where menuactive = 1"
            If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                MsgBox("Error Creating New user Menu security Level!")
                Exit Sub
            End If
        Else ' update
            GlobalVariables.Gl_SQLStr = "Update users  SET UserID = '" & usrID.Text & "', Fname = '" & Trim(usrfname.Text) & "', "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "Lname = '" & Trim(usrlname.Text) & "', "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "DateOfBirth = '" & DateOfBirth.Value & "', Address1 = '" & Trim(usradd1.Text) & "', "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "Address2 = '" & Trim(usradd2.Text) & "', City = '" & Trim(cmbUsrCity.Text) & "', "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "Province = '" & Trim(cmbUsrState.Text) & "', Pcode = '" & Trim(usrpcode.Text) & "', "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "Country = '" & Trim(cmbUsrCountry.Text) & "', Active = " & tactive & ", "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "usrPassword = '" & Trim(usrpassword.Text) & "', usrmode = '" & Trim(cmbUsrMode.Text) & "', "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "usrseclvl = '" & Trim(cmbUsrSecLvl.Text) & "'"
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & " WHERE userID = '" & usrID.Text & "'"
            If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                MsgBox("Error Updating user!")
                Exit Sub
            End If

        End If

        GBoxNewUser.Text = "New User"
        cmdSaveNewUser.Text = "Save User"
        GBoxNewUser.Visible = False
        cmdSaveNewUser.Visible = False
        cmdCanNewUser.Visible = False
        cmdNewUser.Enabled = True
        GBMSec1.Visible = False
        clrUserFields()
        usrID.Enabled = False
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
            LoadUsersMenSec()
            GBMSec1.Visible = True
            usrID.Enabled = False
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

    Private Sub LoadUsersMenSec()
        Dim sql As String = "SELECT ID,UserID,MenuMItem,MenuSitem,MenuS2Item,MenuSecLevel,MenuActive FROM MenuUserSecurity where UserID = '" & selusrid & "'"
        Using connection As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)
            connection.Open()
            sCommand = New SqlCommand(sql, connection)
            sAdapter = New SqlDataAdapter(sCommand)
            sBuilder = New SqlCommandBuilder(sAdapter)
            sDs = New DataSet()
            sAdapter.Fill(sDs, "MenuUserSecurity")
            sTable = sDs.Tables("MenuUserSecurity")
            connection.Close()
            DataGridUsrMsec.DataSource = sDs.Tables("MenuUserSecurity")
            DataGridUsrMsec.ReadOnly = True
            DataGridUsrMsec.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            'change header text
            Me.DataGridUsrMsec.Columns(0).HeaderText = "ID"
            Me.DataGridUsrMsec.Columns(1).HeaderText = "UserID"
            Me.DataGridUsrMsec.Columns(2).HeaderText = "MItem"
            Me.DataGridUsrMsec.Columns(3).HeaderText = "SubItem1"
            Me.DataGridUsrMsec.Columns(4).HeaderText = "SubItem2"
            Me.DataGridUsrMsec.Columns(5).HeaderText = "SecLevel"
            Me.DataGridUsrMsec.Columns(6).HeaderText = "Active"

            DataGridUsrMsec.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            'disable sorting
            DataGridUsrMsec.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridUsrMsec.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridUsrMsec.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridUsrMsec.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridUsrMsec.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridUsrMsec.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridUsrMsec.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable

        End Using

    End Sub

    Private Sub DataGridUsrMsec_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridUsrMsec.MouseClick

        Dim I As Integer
        Dim slsec As String

        selsecuser = ""

        If (DataGridUsrMsec.Rows.Count >= 1) Then
            I = DataGridUsrMsec.CurrentRow.Index
            selrow = I
            selsecID = Trim(DataGridUsrMsec.Item(0, I).Value)
            selsecuser = Trim(DataGridUsrMsec.Item(1, I).Value)
            GBEditSecMnu.Visible = True

            slsec = Trim(DataGridUsrMsec.Item(5, I).Value.ToString)
            cmdSecLevel.SelectedIndex = cmdSecLevel.FindString(slsec).ToString

            chactivesec.Checked = DataGridUsrMsec.Item(6, I).Value


        End If

    End Sub

    Private Sub Cmdsecupd_Click(sender As Object, e As EventArgs) Handles cmdsecupd.Click

        Dim tnewstat As Integer = 0

        If (chactivesec.Checked = True) Then tnewstat = 1

        GlobalVariables.Gl_SQLStr = "update MenuUserSecurity set MenuSecLevel = '" & cmdSecLevel.SelectedItem & "', MenuActive = " & tnewstat
        GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & " where ID = " & selsecID
        If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
            MsgBox("Error update user Menu security Level!")
        Else
            DataGridUsrMsec.Item(6, selrow).Value = chactivesec.Checked
            DataGridUsrMsec.Item(5, selrow).Value = cmdSecLevel.SelectedItem
            chactivesec.Checked = False
            cmdSecLevel.SelectedIndex = -1
            GBEditSecMnu.Visible = False
        End If

    End Sub

    Private Sub Cmdseccanc_Click(sender As Object, e As EventArgs) Handles cmdseccanc.Click

        chactivesec.Checked = False
        cmdSecLevel.SelectedIndex = -1
        GBEditSecMnu.Visible = False

    End Sub

End Class