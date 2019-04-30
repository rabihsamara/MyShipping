Imports System.Data.SqlClient

Public Class frmControls
    Private slusrfrmsecID As Integer = GlobalVariables.Gl_tmpfnameID
    Private sCommand As SqlCommand
    Private sAdapter As SqlDataAdapter
    Private sBuilder As SqlCommandBuilder
    Private sDs As DataSet
    Private sTable As DataTable

    Private Sub FrmControls_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dspuserdID.Text = GlobalVariables.Gl_tmpuserID
        dpsfname.Text = GlobalVariables.Gl_tmpfname

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
        Dim sql As String = "select * from frmUsercontrols where UserID = '" & GlobalVariables.Gl_tmpuserID & "' and Formname = '" & GlobalVariables.Gl_tmpfname & "'"
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


    'tmp
    Private Sub LoadAllControls()

        For Each formprop In My.Forms.GetType.GetProperties 'percorre todos os forms 
            Dim node = Me.TreeControls.Nodes.Add(formprop.Name)
            Dim frm As Form = CType(formprop.GetValue(My.Forms, Nothing), Form)
            ControlsTree(node, frm.Controls)
        Next

    End Sub
End Class