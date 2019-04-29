Public Class MainMenu


    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = GlobalVariables.Gl_Company & " - (" & GlobalVariables.Gl_LogUserID & ")"
        MenuStrip1 = ModRegSec.BuildMenu()



    End Sub

    '*********************************************************************
    'Event handlers for items listed under Menu File
    '*********************************************************************
    Public Sub OnExit(ByVal sender As Object, ByVal e As EventArgs)
        Application.Exit()
    End Sub


    '*********************************************************************
    'Event handlers for items listed under Menu Edit
    '*********************************************************************


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
    '*********************************************************************
    'Event handlers for items listed under Menu Reports
    '*********************************************************************






End Class