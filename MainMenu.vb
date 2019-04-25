Public Class MainMenu

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = GlobalVariables.Gl_Company & " - (" & GlobalVariables.Gl_LogUserID & ")"
        BuildMenu()

    End Sub

    Private Sub BuildMenu()

        Dim ms As New MenuStrip
        ms.Parent = Me

        'File Menu
        Dim fileItem As New ToolStripMenuItem("&File")
        Dim exitItem As New ToolStripMenuItem("&Exit", Nothing, New EventHandler(AddressOf OnExit))

        exitItem.ShortcutKeys = Keys.Control Or Keys.X
        fileItem.DropDownItems.Add(exitItem)

        ms.Items.Add(fileItem)

        'Edit Menu
        Dim EditItem As New ToolStripMenuItem("E&dit")

        ms.Items.Add(EditItem)

        'Utilities Menu
        Dim UtilItem As New ToolStripMenuItem("&Utilities")
        Dim UserItem As New ToolStripMenuItem("&Users", Nothing, New EventHandler(AddressOf Users))

        UserItem.ShortcutKeys = Keys.Control Or Keys.U
        UtilItem.DropDownItems.Add(userItem)

        ms.Items.Add(UtilItem)

        'Reports menu
        Dim RepItem As New ToolStripMenuItem("&Reports")

        ms.Items.Add(RepItem)

        '******************************************************************
        'Move to form menustrip.
        '******************************************************************
        MenuStrip1 = ms

    End Sub

    '*********************************************************************
    'Event handlers for items listed under Menu File
    '*********************************************************************
    Private Sub OnExit(ByVal sender As Object, ByVal e As EventArgs)
        Application.Exit()
    End Sub


    '*********************************************************************
    'Event handlers for items listed under Menu Edit
    '*********************************************************************


    '*********************************************************************
    'Event handlers for items listed under Menu Utilities
    '*********************************************************************
    Private Sub Users(ByVal sender As Object, ByVal e As EventArgs)
        Dim frm As New frmUsers()
        frm.TopLevel = False
        frm.TopMost = True
        SplitContainer1.Panel2.Controls.Add(frm)
        frm.Show()

    End Sub

    '*********************************************************************
    'Event handlers for items listed under Menu Reports
    '*********************************************************************






End Class