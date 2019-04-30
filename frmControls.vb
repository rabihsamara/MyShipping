Imports System.Data.SqlClient

Public Class frmControls
    Private slusrfrmsecID As Integer = GlobalVariables.Gl_tmpfnameID

    Private Sub FrmControls_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dspuserdID.Text = GlobalVariables.Gl_tmpuserID
        dpsfname.Text = GlobalVariables.Gl_tmpfname
        LoadFormControls()

    End Sub

    Private Sub LoadFormControls()



        'DataGridDspCont.DataSource = sDs.Tables("users")
        'DataGridDspCont.ReadOnly = True
        'DataGridDspCont.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        'DataGridDspCont.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


    End Sub


    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

End Class