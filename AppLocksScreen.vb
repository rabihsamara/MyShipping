Imports System.Data.SqlClient

Public Class AppLocksScreen
    Dim sCommand As SqlCommand
    Dim sAdapter As SqlDataAdapter
    Dim sBuilder As SqlCommandBuilder
    Dim sDs As DataSet
    Dim sTable As DataTable

    Private Sub AppLocksScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAppLocks()
    End Sub

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub LoadAppLocks()
        Dim sql As String = "SELECT ID,Userid,Formname,ctrlname,ctrlvalue,ctrlopert,lockeddate FROM AppLocks order by Userid asc,Formname asc,ctrlname asc"
        Using connection As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)
            connection.Open()
            sCommand = New SqlCommand(sql, connection)
            sAdapter = New SqlDataAdapter(sCommand)
            sBuilder = New SqlCommandBuilder(sAdapter)
            sDs = New DataSet()
            sAdapter.Fill(sDs, "AppLocks")
            sTable = sDs.Tables("AppLocks")
            connection.Close()
            DataGridLocks.DataSource = sDs.Tables("AppLocks")
            DataGridLocks.ReadOnly = True
            DataGridLocks.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridLocks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End Using

    End Sub

End Class