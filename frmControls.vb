Imports System.Data.SqlClient

Public Class frmControls
    Private slusrfrmsecID As Integer = GlobalVariables.Gl_tmpfnameID

    Private Sub FrmControls_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dspuserdID.Text = GlobalVariables.Gl_tmpuserID
        dpsfname.Text = GlobalVariables.Gl_tmpfname
        LoadFormControls()
    End Sub

    Private Sub LoadFormControls()

        Dim frm As New Form()
        frm = frmUsers


        'DataGridDspCont.DataSource = sDs.Tables("users")
        'DataGridDspCont.ReadOnly = True
        'DataGridDspCont.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        'DataGridDspCont.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


        Dim control As Control
        For Each control In Me.Controls
            MessageBox.Show(control.Name)
        Next


    End Sub




    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

End Class