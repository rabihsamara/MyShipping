
Module ModRegSec
    Private ms As New MenuStrip

    Public Function BuildMenu() As MenuStrip

        ms.Parent = MainMenu

        'File Menu
        Dim fileItem As New ToolStripMenuItem("&File")
        Dim exitItem As New ToolStripMenuItem("&Exit", Nothing, New EventHandler(AddressOf MainMenu.OnExit))

        exitItem.ShortcutKeys = Keys.Control Or Keys.X
        fileItem.DropDownItems.Add(exitItem)

        ms.Items.Add(fileItem)

        'Edit Menu
        Dim EditItem As New ToolStripMenuItem("E&dit")

        ms.Items.Add(EditItem)

        '***********************************************************************************************
        'Utilities Menu
        '***********************************************************************************************
        Dim UtilItem As New ToolStripMenuItem("&Utilities")
        '                    ---- sub items of Utilities ----
        Dim UserItem As New ToolStripMenuItem("&Users", Nothing, New EventHandler(AddressOf MainMenu.Users))
        Dim mysetItem As New ToolStripMenuItem("&Settings", Nothing, New EventHandler(AddressOf MainMenu.Mysettings))

        UserItem.ShortcutKeys = Keys.Control Or Keys.U
        UtilItem.DropDownItems.Add(UserItem)
        UtilItem.DropDownItems.Add(mysetItem)

        ms.Items.Add(UtilItem)

        '***********************************************************************************************
        'Reports menu
        '***********************************************************************************************
        Dim RepItem As New ToolStripMenuItem("&Reports")



        ms.Items.Add(RepItem)

        '***********************************************************************************************
        'delete MenuDfltSecurity to - recreate

        GlobalVariables.Gl_SQLStr = "delete from MenuDfltSecurity"
        If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
            MsgBox("Error deleting Menu Default security table!")
        Else
            If (ModRegSec.RegisterMenu(ms) = False) Then
                MsgBox("Error Registering Menus")
            End If
            BuildMenu = ms
        End If

        If (RegisterForms() = False) Then
            MsgBox("Error Registering forms")
        End If

    End Function

    '***********************************************************************************************
    '* on startup register all forms for security levels.
    '* Menuseclevel - 0123456789 where 0 is all 9-admin etc.
    '***********************************************************************************************
    Public Function RegisterMenu(inmenu As MenuStrip) As Boolean

        Dim tret As Boolean = True
        Dim I As Integer = 0
        Dim S As Integer = 0
        Dim MenuMItem As String = ""
        Dim menuSubItem As String = ""
        Dim tsql As String = ""

        Do While I < inmenu.Items.Count
            MenuMItem = Replace(inmenu.Items(I).Text, "&", "") ' get top menu items File, edit...

            tsql = "If Not Exists(select 1 from MenuDfltSecurity where MenuMItem = '" & MenuMItem & "') "
            tsql = tsql & "Begin insert into MenuDfltSecurity (MenuMItem, MenuSitem, MenuS2Item, MenuShow, MenuActive) values ('" & MenuMItem & "','','',1,1) "
            tsql = tsql & "End"
            GlobalVariables.Gl_SQLStr = tsql
            If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                MsgBox("Error writing security menus!")
                RegisterMenu = False
                Exit Function
            End If

            Dim tmpMenuItem As ToolStripMenuItem = inmenu.Items(I)
            S = 0
            Do While S < tmpMenuItem.DropDownItems.Count
                menuSubItem = Replace(tmpMenuItem.DropDownItems(S).Text, "&", "")

                tsql = "If Not Exists(select 1 from MenuDfltSecurity where MenuMItem = '" & MenuMItem & "' and MenuSitem = '" & menuSubItem & "') "
                tsql = tsql & "Begin insert into MenuDfltSecurity (MenuMItem, MenuSitem, MenuS2Item, MenuShow, MenuActive) values ('" & MenuMItem & "','" & menuSubItem & "','',1,1) "
                tsql = tsql & "End"
                GlobalVariables.Gl_SQLStr = tsql
                If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                    MsgBox("error writing security sub menu of" & MenuMItem)
                    RegisterMenu = False
                    Exit Function
                End If

                S = S + 1
            Loop
            I = I + 1
        Loop

        RegisterMenu = tret

        'check if admin has a default user security record
        tsql = "If Not Exists(select 1 from MenuUserSecurity where userid = '" & GlobalVariables.GL_DfltConnValues.AppMyDFUser & "') Begin "
        tsql = tsql & "insert into MenuUserSecurity (UserID, MenuMItem, MenuSitem, MenuS2Item, MenuShow, MenuActive) "
        tsql = tsql & "Select '" & GlobalVariables.GL_DfltConnValues.AppMyDFUser & "',MenuMItem,MenuSitem,MenuS2Item,MenuShow,MenuActive from MenuDfltSecurity where MenuActive = 1 End"
        GlobalVariables.Gl_SQLStr = tsql
        If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
            MsgBox("Error writing default user security menu!")
            RegisterMenu = False
        End If

    End Function

    Public Function RegisterForms() As Boolean

        Dim tret As Boolean = True
        Dim tsql As String = String.Empty
        Dim tfrmtype As String = String.Empty
        Dim tmnuname As String = String.Empty
        Dim tcontorls As Integer = 1

        Dim myappforms As mymisc1 = New mymisc1()
        Dim frmarray As ArrayList = myappforms.Myfrms

        frmarray.Sort()
        For i As Integer = 0 To frmarray.Count - 1
            Dim val As String = Trim(frmarray(i).ToString())

            tfrmtype = "A"
            tmnuname = ""
            tcontorls = 2
            If (val = "frmsettings") Then
                tfrmtype = "M"
                tmnuname = "frmSettings"
                tcontorls = 1
            End If
            If (val = "frmUsers") Then
                tfrmtype = "M"
                tmnuname = "frmUsers"
                tcontorls = 1
            End If

            tsql = "If Not Exists(Select 1 from FormDfltSecurity where FormName = '" & val & "') Begin "
            tsql = tsql & "INSERT INTO FormDfltSecurity (FormName,FormType,FormMenuName,FormShow,Formenabled,FormControls) VALUES ('" & val & "','" & tfrmtype & "','" & tmnuname & "',1,1," & tcontorls & ") End"
            GlobalVariables.Gl_SQLStr = tsql
            If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                MsgBox("Error writing default form security!")
                RegisterForms = False
                Exit Function
            End If
        Next

        'check if admin user has default forms security.
        tsql = "If Not Exists(select 1 from FormUserSecurity where userid = '" & GlobalVariables.GL_DfltConnValues.AppMyDFUser & "') Begin "
        tsql = tsql & "insert into FormUserSecurity (UserID, FormName,FormType,FormMenuName,FormShow,Formenabled,FormControls) "
        tsql = tsql & "Select '" & GlobalVariables.GL_DfltConnValues.AppMyDFUser & "',FormName,FormType,FormMenuName,FormShow,Formenabled,FormControls from FormDfltSecurity End"
        GlobalVariables.Gl_SQLStr = tsql
        If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
            MsgBox("Error writing default admin security forms!")
            RegisterForms = False
            Exit Function
        End If

        RegisterForms = tret

    End Function

    '***********************************************************************************************
    '* Misc functions/subs                                                                         *
    '***********************************************************************************************
    Public Sub CloseAllforms()
        Dim openForms As Windows.Forms.FormCollection = Application.OpenForms

        For Each frm As Windows.Forms.Form In openForms
            If frm.Name.ToString() <> "MainNew" Then
                frm.Close()
            End If
        Next
    End Sub

    Public Sub RegisterCurrControls(ctl As Control.ControlCollection, inform As String)

        Dim control As Control
        Dim cttype As String = String.Empty
        Dim addcont As Boolean = False

        For Each control In ctl
            addcont = False

            If TypeOf (control) Is TextBox Then
                cttype = "TextBox"
                addcont = True
            ElseIf TypeOf (control) Is Button Then
                cttype = "Button"
                addcont = True
            ElseIf TypeOf (control) Is DataGridView Then
                cttype = "DataGridView"
                addcont = True
            ElseIf TypeOf (control) Is ComboBox Then
                cttype = "ComboBox"
                addcont = True
            ElseIf TypeOf (control) Is ListBox Then
                cttype = "ListBox"
                addcont = True
            End If

            If (addcont = True) Then
                'create default form controls.
                GlobalVariables.Gl_SQLStr = "if not Exists(select 1 from frmDfltcontrols where formname = 'frmControls') Begin "
                GlobalVariables.Gl_SQLStr = "insert into frmDfltcontrols (FormName, controlname, controltype, contvisible, contenabled,conteditable) values"
                GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "('" & inform & "','" & control.Name & "','" & cttype & "',1,1,1)"
                If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                    MsgBox("Error Creating Form Controls for form " & GlobalVariables.Gl_tmpfname)
                    Exit Sub
                End If
            End If

        Next

    End Sub
End Module
