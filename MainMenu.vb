Public Class MainMenu

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = GlobalVariables.Gl_Company & " - (" & GlobalVariables.Gl_LogUserID & ")"
        MenuStrip1 = ModRegSec.BuildMenu("M")

    End Sub

    '*********************************************************************
    'Event handlers for items listed under Menu File
    '*********************************************************************
    Public Sub OnExit(ByVal sender As Object, ByVal e As EventArgs)
        ModMisc.Closeforms("E")
        Application.Exit()
    End Sub

    Private Sub MainMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            ModMisc.Closeforms("E")
            Application.Exit()
        End If

    End Sub

#Region "MnuEdit"

    '*********************************************************************
    'Event handlers for items listed under Menu Edit
    '*********************************************************************
    Public Sub frmCustomers(ByVal sender As Object, ByVal e As EventArgs)
        Dim frm As New frmCustomers()
        frm.TopLevel = False
        frm.TopMost = True
        SplitContainer1.Panel2.Controls.Add(frm)
        frm.Show()
    End Sub

    Public Sub frmOrders(ByVal sender As Object, ByVal e As EventArgs)
        Dim frm As New frmOrders()
        frm.TopLevel = False
        frm.TopMost = True
        GlobalVariables.Gl_OrdCallFrmID = "COM"
        SplitContainer1.Panel2.Controls.Add(frm)
        frm.Show()
    End Sub
#End Region

#Region "MUtilities"

    '*********************************************************************
    'Event handlers for items listed under Menu Utilities
    '*********************************************************************
    Public Sub Users(ByVal sender As Object, ByVal e As EventArgs)
        Dim frm As New frmUsers()
        frm.TopLevel = False
        frm.TopMost = True
        SplitContainer1.Panel2.Controls.Add(frm)
        frm.Show()

    End Sub

    Public Sub Mysettings(ByVal sender As Object, ByVal e As EventArgs)
        Dim frm As New frmsettings()
        frm.TopLevel = False
        frm.TopMost = True
        SplitContainer1.Panel2.Controls.Add(frm)
        frm.Show()
    End Sub

    Public Sub MenyMyControls(ByVal sender As Object, ByVal e As EventArgs)
        GlobalVariables.GL_SecContcalledBy = "M"
        Dim frm As New frmControls()
        frm.TopLevel = False
        frm.TopMost = True
        SplitContainer1.Panel2.Controls.Add(frm)
        frm.Show()

    End Sub

    Public Sub AppLocksScreen(ByVal sender As Object, ByVal e As EventArgs)
        GlobalVariables.GL_SecContcalledBy = "M"
        Dim frm As New AppLocksScreen()
        frm.TopLevel = False
        frm.TopMost = True
        SplitContainer1.Panel2.Controls.Add(frm)
        frm.Show()

    End Sub

#End Region

#Region "MReports"

    '*********************************************************************
    'Event handlers for items listed under Menu Reports
    '*********************************************************************

#End Region


    '************************* tmp function *************************

    Private Sub CmdTmp_Click(sender As Object, e As EventArgs) Handles cmdTmp.Click

        Dim ttable As String = InputBox("Enter Table", "Table", "", 100, 100)
        ModTmp.RunClassGen(ttable)
        ModTmp.CreateSelectStatement(ttable)

    End Sub

    '**********************End tmp function *************************

End Class