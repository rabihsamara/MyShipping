Imports System.Data.SqlClient

Public Class frmUsers
    Dim sCommand As SqlCommand
    Dim sAdapter As SqlDataAdapter
    Dim sBuilder As SqlCommandBuilder
    Dim sDs As DataSet
    Dim sTable As DataTable

    Private selusrrow As Integer
    Private selusrid As String
    Private upmode As String

    Private slcountryid As Integer
    Private slstateid As Integer
    Private slcityid As Integer

    Private selsecID As Integer
    Private selsecuser As String

    Private selformrow As Integer
    Private selformNId As Integer

    Private selrow As Integer
    Private userrecord As userrec = New userrec()

    Private Sub FrmUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GBoxNewUser.Visible = False
        cmdSaveNewUser.Visible = False
        cmdCanNewUser.Visible = False
        cmdDelete.Visible = False
        GBMSec1.Visible = False
        GBEditSecMnu.visible = False
        GBFormSec.Visible = False
        GBEditSecForm.Visible = False
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
        GBFormSec.Visible = True
        GBEditSecMnu.Visible = True
        GBEditSecForm.Visible = True
        cmdsecupd.Enabled = False
        cmdseccanc.Enabled = False
        GBoxNewUser.Visible = True
        cmdSaveNewUser.Visible = True
        cmdCanNewUser.Visible = True
        cmdNewUser.Enabled = False
        cmdDelete.Visible = False
        upmode = "I" ' New insert.
        usrID.Enabled = True
        GlobalVariables.Gl_SQLStr = "select countryname, ID from countries where active = 1 order by countryname"
        ModMisc.ReadCountries(cmbUsrCountry)

    End Sub

    Private Sub CmdCanNewUser_Click(sender As Object, e As EventArgs) Handles cmdCanNewUser.Click

        GBoxNewUser.Text = "New User"
        cmdSaveNewUser.Text = "Save User"
        GBoxNewUser.Visible = False
        GBFormSec.Visible = False
        cmdSaveNewUser.Visible = False
        cmdCanNewUser.Visible = False
        cmdNewUser.Enabled = True
        GBMSec1.Visible = False
        GBEditSecMnu.Visible = False
        GBEditSecForm.Visible = False
        clrUserFields()
        usrID.Enabled = False
        cmdDelete.Visible = False

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
        ElseIf (Trim(usrID.Text) <> "" And upmode = "I") Then
            'check if userid is taken.
            GlobalVariables.Gl_SQLStr = "Select Count(*) from users where userid = '" & Trim(usrID.Text) & "'"
            If (ModMisc.ReadSQL("usridcnt") > 0) Then
                MsgBox("This UserID is taken!")
                Exit Sub
            End If
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
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "Values ('" & usrID.Text & "','" & Trim(usrfname.Text) & "','" & Trim(usrlname.Text) & "','" & DateOfBirth.Value & "','" & Trim(usradd1.Text) & "','" & Trim(usradd2.Text) & "','" & Trim(cmbUsrCity.Text) & "','" & Trim(cmbUsrState.Text) & "','" & Trim(usrpcode.Text) & "','" & Trim(cmbUsrCountry.Text) & "'," & tactive & ",'" & Trim(usrpassword.Text) & "','" & Trim(cmbUsrMode.Text).Substring(0, 1) & "','" & Trim(cmbUsrSecLvl.Text) & "') End"
            If (ModMisc.ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                MsgBox("Error Creating default user Record!")
                Exit Sub
            End If
            '
            'update user menu security levels (default).
            GlobalVariables.Gl_SQLStr = "insert into MenuUserSecurity (UserID, MenuMItem, MenuSitem, MenuS2Item, MenuShow, MenuActive) "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "Select '" & usrID.Text & "',MenuMItem,MenuSitem,MenuS2Item,MenuShow,MenuActive from MenuDfltSecurity where menuactive = 1"
            If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                MsgBox("Error Creating New user Menu security Level!")
                Exit Sub
            End If
            LoadUsers()

            For J As Integer = 0 To Me.DataGridVWUsers.Rows.Count - 1
                If (Trim(Me.DataGridVWUsers.Rows(J).Cells("UserID").Value) = Trim(usrID.Text)) Then
                    selusrrow = J
                    Exit For
                End If
            Next

            'check if user has default forms security.
            GlobalVariables.Gl_SQLStr = "If Not Exists(select 1 from FormUserSecurity where userid = '" & usrID.Text & "') Begin "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "insert into FormUserSecurity (UserID, FormName,FormType,FormMenuName,FormShow,Formenabled,FormControls) "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "Select '" & usrID.Text & "',FormName,FormType,FormMenuName,FormShow,Formenabled,FormControls from FormDfltSecurity End"
            If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                MsgBox("Error writing default admin security forms!")
                Exit Sub
            End If
            LoadUsersFormsSec()
        Else ' update
            GlobalVariables.Gl_SQLStr = "Update users  SET UserID = '" & usrID.Text & "', Fname = '" & Trim(usrfname.Text) & "', "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "Lname = '" & Trim(usrlname.Text) & "', "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "DateOfBirth = '" & DateOfBirth.Value & "', Address1 = '" & Trim(usradd1.Text) & "', "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "Address2 = '" & Trim(usradd2.Text) & "', City = '" & Trim(cmbUsrCity.Text) & "', "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "Province = '" & Trim(cmbUsrState.Text) & "', Pcode = '" & Trim(usrpcode.Text) & "', "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "Country = '" & Trim(cmbUsrCountry.Text) & "', Active = " & tactive & ", "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "usrPassword = '" & Trim(usrpassword.Text) & "', usrmode = '" & Trim(cmbUsrMode.Text).Substring(0, 1) & "', "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "usrseclvl = '" & Trim(cmbUsrSecLvl.Text) & "'"
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & " WHERE userID = '" & usrID.Text & "'"
            If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                MsgBox("Error Updating user!")
                Exit Sub
            End If
            DataGridVWUsers.Item(1, selusrrow).Value = Trim(usrfname.Text)
            DataGridVWUsers.Item(2, selusrrow).Value = Trim(usrlname.Text)
            DataGridVWUsers.Item(3, selusrrow).Value = Trim(cmbUsrMode.Text).Substring(0, 1)
            DataGridVWUsers.Item(4, selusrrow).Value = Trim(cmbUsrSecLvl.Text)
            DataGridVWUsers.Item(5, selusrrow).Value = tactive
        End If

        GBoxNewUser.Text = "Update User"
        cmdSaveNewUser.Text = "Update User"
        usrID.Enabled = False
        GBMSec1.Visible = True
        upmode = "U"

    End Sub

    Private Sub DataGridVWUsers_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridVWUsers.MouseClick

        Dim I As Integer
        selusrid = ""
        selusrrow = 0

        If (DataGridVWUsers.Rows.Count >= 1) Then

            I = DataGridVWUsers.CurrentRow.Index
            selusrrow = I
            selusrid = DataGridVWUsers.Item(0, I).Value
            'check if admin
            If (selusrid = "admin") Then
                Dim frm As Form
                frm = Frmchkadpwd
                frm.ShowDialog()
                If (GlobalVariables.GL_Stat = False) Then
                    MsgBox("Cannot edit admin Users!")
                    Exit Sub
                End If
            End If

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

            GlobalVariables.Gl_SQLStr = "select countryname, ID from countries where active = 1 order by countryname"
            ModMisc.ReadCountries(cmbUsrCountry)

            cmbUsrCountry.Text = userrecord.MyCountry
            slcountryid = cmbUsrCountry.SelectedValue

            GlobalVariables.Gl_SQLStr = "select provshort as countryname, ID from provinces where countryid = " & slcountryid & " and active = 1 order by provshort"
            ModMisc.ReadCountries(cmbUsrState)
            cmbUsrState.Text = userrecord.MyProvince
            slstateid = cmbUsrState.SelectedValue

            GlobalVariables.Gl_SQLStr = "select cityname as countryname, ID from cities where countryid = " & slcountryid & " and provid = " & slstateid & " and cityactive = 1 order by cityname"
            ModMisc.ReadCountries(cmbUsrCity)
            cmbUsrCity.Text = userrecord.MyCity
            slcityid = cmbUsrCity.SelectedValue

            usrpcode.Text = userrecord.MyPcode
            cmbUsrSecLvl.Text = userrecord.Myusrseclvl
            usrpassword.Text = userrecord.MyusrPassword
            cmbUsrMode.Text = userrecord.Myusrmode

            GBoxNewUser.Text = "update User: " & selusrid
            GBoxNewUser.Visible = True
            cmdSaveNewUser.Visible = True
            cmdCanNewUser.Visible = True
            cmdNewUser.Enabled = False
            LoadUsersMenSec()
            LoadUsersFormsSec()
            GBMSec1.Visible = True
            GBFormSec.Visible = True
            GBEditSecMnu.Visible = True
            GBEditSecForm.Visible = True
            cmdsecupd.Enabled = False
            cmdseccanc.Enabled = False
            usrID.Enabled = False
            cmdDelete.Visible = True

            'check if user has default forms security.
            GlobalVariables.Gl_SQLStr = "If Not Exists(select 1 from FormUserSecurity where userid = '" & usrID.Text & "') Begin "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "insert into FormUserSecurity (UserID, FormName,FormType,FormMenuName,FormShow,Formenabled,FormControls) "
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "Select '" & usrID.Text & "',FormName,FormType,FormMenuName,FormShow,Formenabled,FormControls from FormDfltSecurity End"
            If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                MsgBox("Error writing default admin security forms!")
                Exit Sub
            End If
            LoadUsersFormsSec()
        End If

    End Sub

    Private Sub DataGridForms_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridForms.MouseClick

        selformrow = 0
        selformNId = 0

        If (DataGridForms.Rows.Count >= 1) Then
            selformrow = DataGridForms.CurrentRow.Index
            selformNId = DataGridForms.Item(0, selformrow).Value
            If (DataGridForms.Item(7, selformrow).Value.ToString = "2") Then
                MsgBox("cannot edit form security level!")
                Exit Sub
            End If

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
        Dim sql As String = "SELECT ID,UserID,MenuMItem,MenuSitem,MenuS2Item,MenuShow,MenuActive FROM MenuUserSecurity where UserID = '" & selusrid & "'"
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
            Me.DataGridUsrMsec.Columns(5).HeaderText = "ShowMenu"
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

    Private Sub LoadUsersFormsSec()

        Dim sql As String = "SELECT ID,UserID,FormName,FormType,FormMenuName,FormShow,Formenabled,FormControls FROM FormUserSecurity where UserID = '" & selusrid & "'"
        Using connection As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)
            connection.Open()
            sCommand = New SqlCommand(sql, connection)
            sAdapter = New SqlDataAdapter(sCommand)
            sBuilder = New SqlCommandBuilder(sAdapter)
            sDs = New DataSet()
            sAdapter.Fill(sDs, "FormUserSecurity")
            sTable = sDs.Tables("FormUserSecurity")
            connection.Close()
            DataGridForms.DataSource = sDs.Tables("FormUserSecurity")
            DataGridForms.ReadOnly = True
            DataGridForms.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            'change header text
            Me.DataGridForms.Columns(0).HeaderText = "ID"
            Me.DataGridForms.Columns(1).HeaderText = "UserID"
            Me.DataGridForms.Columns(2).HeaderText = "FormName"
            Me.DataGridForms.Columns(3).HeaderText = "Type"
            Me.DataGridForms.Columns(4).HeaderText = "MenuName"
            Me.DataGridForms.Columns(5).HeaderText = "Show"
            Me.DataGridForms.Columns(6).HeaderText = "Enabled"
            Me.DataGridForms.Columns(7).HeaderText = "Controls"

            DataGridForms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            'disable sorting
            DataGridForms.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridForms.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridForms.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridForms.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridForms.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridForms.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridForms.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable

        End Using

    End Sub

    Private Sub DataGridUsrMsec_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridUsrMsec.MouseClick

        Dim I As Integer

        selsecuser = ""

        If (DataGridUsrMsec.Rows.Count >= 1) Then
            I = DataGridUsrMsec.CurrentRow.Index
            selrow = I
            selsecID = Trim(DataGridUsrMsec.Item(0, I).Value)
            selsecuser = Trim(DataGridUsrMsec.Item(1, I).Value)

            chsecshow.Checked = DataGridUsrMsec.Item(5, I).Value
            chactivesec.Checked = DataGridUsrMsec.Item(6, I).Value
            cmdsecupd.Enabled = True
            cmdseccanc.Enabled = True
        End If

    End Sub

    Private Sub Cmdsecupd_Click(sender As Object, e As EventArgs) Handles cmdsecupd.Click

        Dim tnewstat As Integer = 0
        Dim tshow As Integer = 0

        If (chactivesec.Checked = True) Then tnewstat = 1
        If (chsecshow.Checked = True) Then tshow = 1

        GlobalVariables.Gl_SQLStr = "update MenuUserSecurity set MenuShow = " & tshow & ", MenuActive = " & tnewstat
        GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & " where ID = " & selsecID
        If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
            MsgBox("Error update user Menu security Level!")
        Else
            DataGridUsrMsec.Item(6, selrow).Value = chactivesec.Checked
            DataGridUsrMsec.Item(5, selrow).Value = chsecshow.Checked
            chactivesec.Checked = False
            chsecshow.Checked = False
            cmdsecupd.Enabled = False
            cmdseccanc.Enabled = False
        End If

    End Sub

    Private Sub Cmdseccanc_Click(sender As Object, e As EventArgs) Handles cmdseccanc.Click

        chactivesec.Checked = False
        chsecshow.Checked = False
        cmdsecupd.Enabled = False
        cmdseccanc.Enabled = False
    End Sub

    Private Sub CmbUsrCountry_SelectedChangeCommitted(sender As Object, e As EventArgs) Handles cmbUsrCountry.SelectionChangeCommitted
        slcountryid = cmbUsrCountry.SelectedValue

        GlobalVariables.Gl_SQLStr = "select provshort as countryname, ID from provinces where countryid = " & slcountryid & " and active = 1 order by provshort"
        ModMisc.ReadCountries(cmbUsrState)
        cmbUsrState.Text = ""
        slstateid = cmbUsrState.SelectedValue

        GlobalVariables.Gl_SQLStr = "select cityname as countryname, ID from cities where countryid = " & slcountryid & " and provid = " & slstateid & " and cityactive = 1 order by cityname"
        ModMisc.ReadCountries(cmbUsrCity)
        cmbUsrCity.Text = ""
        slcityid = cmbUsrCity.SelectedValue
    End Sub

    Private Sub cmbUsrState_SelectedChangeCommitted(sender As Object, e As EventArgs) Handles cmbUsrState.SelectionChangeCommitted

        slstateid = cmbUsrState.SelectedValue
        GlobalVariables.Gl_SQLStr = "select cityname as countryname, ID from cities where countryid = " & slcountryid & " and provid = " & slstateid & " and cityactive = 1 order by cityname"
        ModMisc.ReadCountries(cmbUsrCity)
        cmbUsrCity.Text = ""
        slcityid = cmbUsrCity.SelectedValue

    End Sub

    Private Sub cmbUsrCity_SelectedChangeCommitted(sender As Object, e As EventArgs) Handles cmbUsrCity.SelectionChangeCommitted
        slcityid = cmbUsrCity.SelectedValue
    End Sub

    'Delete user - check if we can
    Private Sub CmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click

        If (selusrid = "admin") Then
            MsgBox("Cannot delete user admin!")
            Exit Sub
        End If

        'check if we can delete 

        If (GlobalVariables.GL_Stat = True) Then ' ok to delete
            GlobalVariables.Gl_SQLStr = "delete from users where userID = '" & selusrid & "'" 'menuusrsecurity deleted by constraint
            If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = True) Then
                'delete other !

            Else
                MsgBox("Error deleting user " & selusrid)
                Exit Sub
            End If

        Else
            MsgBox("Cannot delete user " & selusrid)
            Exit Sub
        End If


    End Sub

End Class