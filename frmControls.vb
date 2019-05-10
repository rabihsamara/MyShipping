Imports System.Data.SqlClient

Public Class frmControls
    Private slusrfrmsecID As Integer = GlobalVariables.Gl_tmpfnameID
    Private selrow As Integer = 0
    Private selid As Integer = 0
    Private selUserid As String = String.Empty

    Private sltreeform As String = String.Empty
    Private selmode As String = "U"
    Private tDGCnt As Integer = 0

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
            LoadUsrControls(GlobalVariables.Gl_tmpuserID, GlobalVariables.Gl_tmpfname)
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

    Private Sub LoadUsrControls(ByVal inuser As String, ByVal inform As String)

        Dim tsql As String = "SELECT ID,UserID,FormName,controlname,controltype,contvisible,contenabled,conteditable FROM frmUsercontrols where UserID = '" & inuser & "' and Formname = '" & inform & "' order by controlname asc, controltype asc"
        tDGCnt = ModMisc.LoadDataGrids(DataGridusrCont, tsql, "frmUsercontrols")

    End Sub

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub DataGridusrCont_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridusrCont.MouseClick

        If (DataGridusrCont.Rows.Count >= 1) Then
            lblmsg.Visible = False
            selrow = DataGridusrCont.CurrentRow.Index
            selid = DataGridusrCont.Item(0, selrow).Value
            selUserid = DataGridusrCont.Item(1, selrow).Value
            '
            If (GlobalVariables.GL_SecContcalledBy = "M" And selmode = "D") Then
                txtmsg.Text = DataGridusrCont.Item(1, selrow).Value & " : " & DataGridusrCont.Item(2, selrow).Value
                chkvisible.Checked = If(DataGridusrCont.Item(4, selrow).Value = 1, True, False)
                chkenabled.Checked = If(DataGridusrCont.Item(5, selrow).Value = 1, True, False)
                chkeditable.Checked = If(DataGridusrCont.Item(6, selrow).Value = 1, True, False)
            Else
                txtmsg.Text = DataGridusrCont.Item(1, selrow).Value & " : " & DataGridusrCont.Item(2, selrow).Value & " : " & DataGridusrCont.Item(3, selrow).Value
                chkvisible.Checked = If(DataGridusrCont.Item(5, selrow).Value = 1, True, False)
                chkenabled.Checked = If(DataGridusrCont.Item(6, selrow).Value = 1, True, False)
                chkeditable.Checked = If(DataGridusrCont.Item(7, selrow).Value = 1, True, False)
            End If

            GBeditContsec.Visible = True
        End If

    End Sub

    Private Sub CmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click

        'update file
        If (GlobalVariables.GL_SecContcalledBy = "M" And selmode = "D") Then
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
        If (GlobalVariables.GL_SecContcalledBy = "M" And selmode = "D") Then
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

            Dim childnum, index As Integer
            childnum = TreeControls.SelectedNode.GetNodeCount(False)
            index = TreeControls.SelectedNode.Index

            sltreeform = ""
            If (InStr(Trim(TreeControls.SelectedNode.Text), ":") = 0) Then
                sltreeform = Trim(TreeControls.SelectedNode.Text)
                If (cmbuserct.Text = "Default") Then
                    selmode = "D"
                    LoadDfltControls(sltreeform)
                Else
                    selmode = "U"
                    LoadUsrControls(Trim(cmbuserct.Text).ToString, Trim(sltreeform))
                End If

            End If

        End If

    End Sub

    Private Sub LoadDfltControls(ByVal inform As String)

        Dim tsql As String = "SELECT ID,FormName,controlname,controltype,contvisible,contenabled,conteditable FROM frmDFLTcontrols where Formname = '" & inform & "' order by controlname asc, controltype asc"
        tDGCnt = ModMisc.LoadDataGrids(DataGridusrCont, tsql, "frmDFLTcontrols")

    End Sub

    Private Sub cmbuserct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbuserct.SelectedIndexChanged

        selmode = If(cmbuserct.Text = "Default", "D", "U")
        Label5.Text = If(cmbuserct.Text = "Default", "Default Controls", "User Defined Form Controls")
        DataGridusrCont.DataSource = Nothing

    End Sub

End Class