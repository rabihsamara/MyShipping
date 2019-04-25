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






End Class