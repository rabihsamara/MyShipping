Imports System.Data.SqlClient

Public Class frmControls
    Private slusrfrmsecID As Integer = GlobalVariables.Gl_tmpfnameID
    Private selrow As Integer
    Private selid As Integer
    Private selUserid As String = String.Empty

    Private sltreeform As String = String.Empty

    Private sCommand As SqlCommand
    Private sAdapter As SqlDataAdapter
    Private sBuilder As SqlCommandBuilder
    Private sDs As DataSet
    Private sTable As DataTable

    Private Sub FrmControls_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmbuserct.Visible = False
        dspuserID.Visible = False
        Label2.Visible = False
        dspfname.Visible = False
        If (GlobalVariables.GL_SecContcalledBy = "U") Then
            dspuserID.Visible = True
            Label2.Visible = True
            dspfname.Visible = True
            dspuserID.Text = GlobalVariables.Gl_tmpuserID
            dspfname.Text = GlobalVariables.Gl_tmpfname

            'check if user has form controls setup for this form.
            GlobalVariables.Gl_SQLStr = "select count(*) from frmUsercontrols where UserID = '" & GlobalVariables.Gl_tmpuserID & "' and Formname = '" & GlobalVariables.Gl_tmpfname & "'"
            If (ModMisc.ReadSQL("usridcnt") = 0) Then
                GlobalVariables.Gl_SQLStr = "insert into frmUsercontrols (UserID, FormName, controlname, controltype, contvisible, contenabled, conteditable) "
                GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "Select '" & GlobalVariables.Gl_tmpuserID & "',FormName,controlname,controltype,contvisible,contenabled,conteditable FROM frmDfltcontrols "
                GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "where Formname = '" & GlobalVariables.Gl_tmpfname & "'"
                If (ModMisc.ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                    MsgBox("Error Creating default user Form controls!")
                    Exit Sub
                End If
            End If
            LoadFormControls()
            LoadUsrControls()
        Else
            cmbuserct.Visible = True
            If (ModMisc.FillCBox(cmbuserct, "C") = False) Then
                Exit Sub
            End If
            cmbuserct.Items.Add("Default")
            LoadAllControls()
        End If

        GBeditContsec.Visible = False


    End Sub

    Private Sub LoadFormControls()
        For Each formprop In My.Forms.GetType.GetProperties
            If (formprop.Name = GlobalVariables.Gl_tmpfname) Then
                Dim node = Me.TreeControls.Nodes.Add(GlobalVariables.Gl_tmpfname)
                Dim frm As Form = CType(formprop.GetValue(My.Forms, Nothing), Form)
                ControlsTree(node, frm.Controls)
            End If
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

    Private Sub LoadUsrControls()
        'DataGridusrCont
        Dim sql As String = "SELECT ID,UserID,FormName,controlname,controltype,contvisible,contenabled,conteditable FROM frmUsercontrols where UserID = '" & GlobalVariables.Gl_tmpuserID & "' and Formname = '" & GlobalVariables.Gl_tmpfname & "' order by controlname asc, controltype asc"
        Using connection As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)
            connection.Open()
            sCommand = New SqlCommand(sql, connection)
            sAdapter = New SqlDataAdapter(sCommand)
            sBuilder = New SqlCommandBuilder(sAdapter)
            sDs = New DataSet()
            sAdapter.Fill(sDs, "frmUsercontrols")
            sTable = sDs.Tables("frmUsercontrols")
            connection.Close()
            DataGridusrCont.DataSource = sDs.Tables("frmUsercontrols")
            DataGridusrCont.ReadOnly = True
            DataGridusrCont.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridusrCont.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End Using

    End Sub

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub DataGridusrCont_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridusrCont.MouseClick
        Dim I As Integer
        selrow = 0
        selid = 0
        selUserid = ""

        If (DataGridusrCont.Rows.Count >= 1) Then
            lblmsg.Visible = False
            selrow = DataGridusrCont.CurrentRow.Index
            selid = DataGridusrCont.Item(0, I).Value
            selUserid = DataGridusrCont.Item(1, I).Value
            '
            If (GlobalVariables.GL_SecContcalledBy = "M") Then
                txtmsg.Text = DataGridusrCont.Item(1, I).Value & " : " & DataGridusrCont.Item(2, I).Value
                chkvisible.Checked = If(DataGridusrCont.Item(4, I).Value = 1, True, False)
                chkenabled.Checked = If(DataGridusrCont.Item(5, I).Value = 1, True, False)
                chkeditable.Checked = If(DataGridusrCont.Item(6, I).Value = 1, True, False)
            Else
                txtmsg.Text = DataGridusrCont.Item(1, I).Value & " : " & DataGridusrCont.Item(2, I).Value & " : " & DataGridusrCont.Item(3, I).Value
                chkvisible.Checked = If(DataGridusrCont.Item(5, I).Value = 1, True, False)
                chkenabled.Checked = If(DataGridusrCont.Item(6, I).Value = 1, True, False)
                chkeditable.Checked = If(DataGridusrCont.Item(7, I).Value = 1, True, False)

            End If

            GBeditContsec.Visible = True
        End If

    End Sub

    Private Sub CmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click

        'update file
        If (GlobalVariables.GL_SecContcalledBy = "M") Then
            GlobalVariables.Gl_SQLStr = "update frmDFLTcontrols  set contvisible = " & If(chkvisible.Checked = True, 1, 0) & ", contenabled = " & If(chkenabled.Checked = True, 1, 0)
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & ", conteditable = " & If(chkeditable.Checked = True, 1, 0)
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & " where ID = " & selid
            If (ModMisc.ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                MsgBox("Error updating User Form controls levels!")
                Exit Sub
            End If
        Else
            GlobalVariables.Gl_SQLStr = "update frmUsercontrols  set contvisible = " & If(chkvisible.Checked = True, 1, 0) & ", contenabled = " & If(chkenabled.Checked = True, 1, 0)
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & ", conteditable = " & If(chkeditable.Checked = True, 1, 0)
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & " where ID = " & selid
            If (ModMisc.ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                MsgBox("Error updating User Form controls levels!")
                Exit Sub
            End If
        End If

        'update screeen
        If (GlobalVariables.GL_SecContcalledBy = "M") Then
            DataGridusrCont.Item(4, selrow).Value = If(chkvisible.Checked = True, 1, 0)
            DataGridusrCont.Item(5, selrow).Value = If(chkenabled.Checked = True, 1, 0)
            DataGridusrCont.Item(6, selrow).Value = If(chkeditable.Checked = True, 1, 0)
        Else
            DataGridusrCont.Item(5, selrow).Value = If(chkvisible.Checked = True, 1, 0)
            DataGridusrCont.Item(6, selrow).Value = If(chkenabled.Checked = True, 1, 0)
            DataGridusrCont.Item(7, selrow).Value = If(chkeditable.Checked = True, 1, 0)
        End If

        lblmsg.Text = "Updated"
        lblmsg.Visible = True
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click

        lblmsg.Text = ""
        lblmsg.Visible = False
        chkvisible.Checked = False
        chkenabled.Checked = False
        chkeditable.Checked = False
        GBeditContsec.Visible = False

    End Sub

    'load all forms and controls
    Private Sub LoadAllControls()

        For Each formprop In My.Forms.GetType.GetProperties
            Dim node = Me.TreeControls.Nodes.Add(formprop.Name)
            Dim frm As Form = CType(formprop.GetValue(My.Forms, Nothing), Form)
            ControlsTree(node, frm.Controls)
        Next

    End Sub

    Private Sub treeControls_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeControls.AfterSelect
        If (GlobalVariables.GL_SecContcalledBy = "M") Then
            If (cmbuserct.Text = "") Then
                MsgBox("Must Select user/Default")
                Exit Sub
            ElseIf (cmbuserct.Text = "Default") Then
                Label5.Text = "Default Controls"
            Else
                Label5.Text = "User Defined Form Controls"
            End If

            Dim childnum, index, i As Int32
            childnum = TreeControls.SelectedNode.GetNodeCount(False)
            index = TreeControls.SelectedNode.Index

            'index = index + 1
            'ListView1.Items.Clear()
            'For i = 0 To childnum - 1
            '    ListView1.Items.Add(index.ToString + "." + i.ToString, 1)
            'Next
            'Label6.Text = TreeControls.SelectedNode.FullPath

            sltreeform = ""
            If (InStr(Trim(TreeControls.SelectedNode.Text), ":") = 0) Then
                sltreeform = Trim(TreeControls.SelectedNode.Text)
                LoadDfltControls(sltreeform)
            End If



        End If


    End Sub

    Private Sub LoadDfltControls(ByVal inform As String)
        'DataGridusrCont
        Dim sql As String = "SELECT ID,FormName,controlname,controltype,contvisible,contenabled,conteditable FROM frmDFLTcontrols where Formname = '" & inform & "' order by controlname asc, controltype asc"
        Using connection As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)
            connection.Open()
            sCommand = New SqlCommand(sql, connection)
            sAdapter = New SqlDataAdapter(sCommand)
            sBuilder = New SqlCommandBuilder(sAdapter)
            sDs = New DataSet()
            sAdapter.Fill(sDs, "frmDFLTcontrols")
            sTable = sDs.Tables("frmDFLTcontrols")
            connection.Close()
            DataGridusrCont.DataSource = sDs.Tables("frmDFLTcontrols")
            DataGridusrCont.ReadOnly = True
            DataGridusrCont.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridusrCont.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End Using

    End Sub


End Class