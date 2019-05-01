
Module ModRegSec
    Private ms As New MenuStrip

    'inopt = "R" new setup, M = Menu load
    Public Function BuildMenu(ByVal inopt As String) As MenuStrip

        ModRegSec.GetALLMenuSecLevel(GlobalVariables.Gl_LogUserID)

        ms.Parent = MainMenu
        '***********************************************************************************************
        'File Menu
        '***********************************************************************************************
        Dim fileItem As New ToolStripMenuItem("&File")
        Dim exitItem As New ToolStripMenuItem("&Exit", Nothing, New EventHandler(AddressOf MainMenu.OnExit))

        If (inopt = "M") Then
            If (GetMenuSecLevel(GlobalVariables.Gl_LogUserID, "File", "", "") = True) Then
                If (GlobalVariables.GL_mshow = 1) Then
                    ms.Items.Add(fileItem)
                    If (GlobalVariables.GL_mactive = 0) Then
                        fileItem.Enabled = False
                    Else
                        If (GetMenuSecLevel(GlobalVariables.Gl_LogUserID, "File", "Exit", "") = True) Then
                            If (GlobalVariables.GL_mshow = 1) Then
                                exitItem.ShortcutKeys = Keys.Control Or Keys.X
                                fileItem.DropDownItems.Add(exitItem)
                                If (GlobalVariables.GL_mactive = 0) Then
                                    exitItem.Enabled = False
                                End If
                            End If
                        End If
                    End If
                End If
            Else
                exitItem.ShortcutKeys = Keys.Control Or Keys.X
                fileItem.DropDownItems.Add(exitItem)
            End If
        Else
            exitItem.ShortcutKeys = Keys.Control Or Keys.X
            fileItem.DropDownItems.Add(exitItem)
            ms.Items.Add(fileItem)
        End If

        '***********************************************************************************************
        'Edit Menu
        '***********************************************************************************************
        Dim EditItem As New ToolStripMenuItem("E&dit")

        ms.Items.Add(EditItem)

        '***********************************************************************************************
        'Utilities Menu
        '***********************************************************************************************

        Dim UtilItem As New ToolStripMenuItem("&Utilities")

        '---- sub items of Utilities ----
        Dim UserItem As New ToolStripMenuItem("&Users", Nothing, New EventHandler(AddressOf MainMenu.Users))
        Dim mysecControls As New ToolStripMenuItem("&Security Controls", Nothing, New EventHandler(AddressOf MainMenu.MenyMyControls))
        Dim mysetItem As New ToolStripMenuItem("&Settings", Nothing, New EventHandler(AddressOf MainMenu.Mysettings))

        If (inopt = "M") Then
            If (GetMenuSecLevel(GlobalVariables.Gl_LogUserID, "Utilities", "", "") = True) Then
                If (GlobalVariables.GL_mshow = 1) Then
                    ms.Items.Add(UtilItem)
                    If (GlobalVariables.GL_mactive = 0) Then
                        UtilItem.Enabled = False
                    Else
                        If (GetMenuSecLevel(GlobalVariables.Gl_LogUserID, "Utilities", "Users", "") = True) Then
                            If (GlobalVariables.GL_mshow = 1) Then
                                UserItem.ShortcutKeys = Keys.Control Or Keys.U
                                UtilItem.DropDownItems.Add(UserItem)
                                If (GlobalVariables.GL_mactive = 0) Then
                                    UserItem.Enabled = False
                                End If
                            End If
                        End If
                        If (GetMenuSecLevel(GlobalVariables.Gl_LogUserID, "Utilities", "Security Controls", "") = True) Then
                            If (GlobalVariables.GL_mshow = 1) Then
                                mysecControls.ShortcutKeys = Keys.Control Or Keys.C
                                UtilItem.DropDownItems.Add(mysecControls)
                                If (GlobalVariables.GL_mactive = 0) Then
                                    mysecControls.Enabled = False
                                End If
                            End If
                        End If
                        If (GetMenuSecLevel(GlobalVariables.Gl_LogUserID, "Utilities", "Settings", "") = True) Then
                            If (GlobalVariables.GL_mshow = 1) Then
                                mysetItem.ShortcutKeys = Keys.Control Or Keys.S
                                UtilItem.DropDownItems.Add(mysetItem)
                                If (GlobalVariables.GL_mactive = 0) Then
                                    mysetItem.Enabled = False
                                End If
                            End If
                        End If
                    End If
                End If
            Else
                UserItem.ShortcutKeys = Keys.Control Or Keys.U
                UtilItem.DropDownItems.Add(UserItem)
                UtilItem.DropDownItems.Add(mysecControls)
                UtilItem.DropDownItems.Add(mysetItem)
                ms.Items.Add(UtilItem)
            End If
        Else
            UserItem.ShortcutKeys = Keys.Control Or Keys.U
            UtilItem.DropDownItems.Add(UserItem)
            UtilItem.DropDownItems.Add(mysecControls)
            UtilItem.DropDownItems.Add(mysetItem)
            ms.Items.Add(UtilItem)
        End If

        '***********************************************************************************************
        'Reports menu
        '***********************************************************************************************
        Dim RepItem As New ToolStripMenuItem("&Reports")
        If (inopt = "M") Then
            'fix later 
            ms.Items.Add(RepItem)




        Else
            ms.Items.Add(RepItem)
        End If

        '***********************************************************************************************
        'delete MenuDfltSecurity to - recreate
        If (inopt = "R") Then
            GlobalVariables.Gl_SQLStr = "delete from MenuDfltSecurity"
            If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                MsgBox("Error deleting Menu Default security table!")
            Else
                If (ModRegSec.RegisterMenu(ms) = False) Then
                    MsgBox("Error Registering Menus")
                End If
            End If
        End If
        BuildMenu = ms

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

    '*************************************************************************************************
    '* register forms controls
    '*************************************************************************************************
    Public Function RegisterFormControls() As Boolean

        Try
            RegisterFormControls = False

            For Each formprop In My.Forms.GetType.GetProperties 'percorre todos os forms 
                Dim tfname As String = formprop.Name
                Dim frm As Form = CType(formprop.GetValue(My.Forms, Nothing), Form)
                ControlsRecr(frm.Controls, tfname)
            Next
            RegisterFormControls = True
            Exit Function
        Catch ex As Exception
            MsgBox(ex.ToString)
            RegisterFormControls = False
        End Try

    End Function

    Private Sub ControlsRecr(ByVal controls As Control.ControlCollection, ByVal inform As String)

        For Each ctrl As Control In controls
            If ctrl.Name <> String.Empty And ctrl.GetType.Name <> "Label" Then
                'create default form controls.
                GlobalVariables.Gl_SQLStr = "if not Exists(select 1 from frmDfltcontrols where formname = '" & inform & "' and controlname ='" & ctrl.Name & " ') Begin "
                GlobalVariables.Gl_SQLStr = "insert into frmDfltcontrols (FormName, controlname, controltype, contvisible, contenabled,conteditable) values"
                GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "('" & inform & "','" & ctrl.Name & "','" & ctrl.GetType.Name & "',1,1,1)"
                If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                    MsgBox("Error Creating Form Controls for form " & inform)
                    Exit Sub
                End If
                ControlsRecr(ctrl.Controls, inform)
            End If
        Next

    End Sub

    '*************************************ENF Form controls Registration ***************************

    Public Function GetMenuSecLevel(ByVal userid As String, ByVal mitem As String, mitems1 As String, mitems2 As String) As Boolean

        Dim F As Integer = 0
        Dim strArr() As String

        GetMenuSecLevel = False
        GlobalVariables.GL_mshow = 1
        GlobalVariables.GL_mactive = 1
        For F = 0 To 100
            strArr = Split(GlobalVariables.tMyMenus(F), ":")
            If (Trim(strArr(0).ToString) = mitem) Then
                If (Trim(strArr(1).ToString) = mitems1) Then
                    GlobalVariables.GL_mshow = strArr(2)
                    GlobalVariables.GL_mactive = strArr(3)
                    GetMenuSecLevel = True
                    Exit For
                End If
            End If
        Next

    End Function

    '* Get Menu security levels by user into an array

    Public Function GetALLMenuSecLevel(ByVal userid As String) As Boolean

        GlobalVariables.Gl_SQLStr = "SELECT MenuMItem,MenuSitem,MenuShow,MenuActive,MenuS2Item FROM MenuUserSecurity where userid = '" & userid & "'"
        GetALLMenuSecLevel = ModMisc.ReadSQL("ALLM", "")

    End Function

    'Public Function GetMenuSecLevel(ByVal userid As String, ByVal mitem As String, mitems1 As String, mitems2 As String) As Boolean

    '    GetMenuSecLevel = False
    '    GlobalVariables.Gl_SQLStr = "select MenuShow, Menuactive FROM MenuUserSecurity where userid = '" & userid & "' and MenuMItem = '" & mitem & "' and menuSitem = '" & mitems1 & "'"
    '    GetMenuSecLevel = ModMisc.ReadSQL("MSEC", "") 'returns GlobalVariables.GL_mshow & GlobalVariables.GL_mactive

    'End Function

End Module
