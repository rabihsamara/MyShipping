Imports System.Data.SqlClient

Public Class AppLocksScreen

    Private sCommand As SqlCommand
    Private sAdapter As SqlDataAdapter
    Private sBuilder As SqlCommandBuilder
    Private sDs As DataSet
    Private sTable As DataTable

    Private selrow As Integer = 0
    Private selid As Integer = 0

    Private Sub AppLocksScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SetEditInfo(False)
        LoadAppLocks()
    End Sub

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub LoadAppLocks()

        Dim tsql As String = "SELECT ID,Userid,Formname,ctrlname,ctrlvalue,ctrlopert,lockeddate FROM AppLocks order by Userid asc,Formname asc,ctrlname asc"
        ModMisc.LoadDataGrids(DataGridLocks, tsql, "AppLocks")

    End Sub

    Private Sub SetEditInfo(ByVal instat As Boolean)
        lblsel.Visible = instat
        sellock.Visible = instat
        cmdRelease.Visible = instat
        cmdCancel.Visible = instat

    End Sub

    Private Sub DataGridLocks_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridLocks.MouseClick

        If (DataGridLocks.Rows.Count >= 1) Then
            selrow = DataGridLocks.CurrentRow.Index
            selid = DataGridLocks.Item(0, selrow).Value
            SetEditInfo(True)
            sellock.Text = "ID:" & DataGridLocks.Item(0, selrow).Value & " : Userid:" & DataGridLocks.Item(1, selrow).Value & " : FormName:" & DataGridLocks.Item(2, selrow).Value & " : ControlName:" & DataGridLocks.Item(3, selrow).Value
        End If

    End Sub

    Private Sub CmdRelease_Click(sender As Object, e As EventArgs) Handles cmdRelease.Click

        'release log 
        If (AppLocking.WriteDelLock("D", selid) = False) Then 'lock it
            MsgBox("Error deting Lock record!")
        End If
        sellock.Text = ""
        LoadAppLocks()
        SetEditInfo(False)

    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        sellock.Text = ""
        SetEditInfo(False)
    End Sub

End Class