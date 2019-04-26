

Module ModRegSec

    '***********************************************************************************************
    '* on startup register all forms for security levels.
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
            MsgBox(MenuMItem)

            tsql = "If Not Exists(select 1 from MenuDfltSecurity where MenuMItem = '" & MenuMItem & "') "
            tsql = tsql & "Begin insert into MenuDfltSecurity (MenuMItem, MenuSitem, MenuS2Item, MenuSecLevel, MenuActive) values ('" & MenuMItem & "','','',0,1) "
            tsql = tsql & "End"
            GlobalVariables.Gl_SQLStr = tsql
            If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                MsgBox("error wrting security menus!")
                RegisterMenu = False
                Exit Function
            End If

            Dim tmpMenuItem As ToolStripMenuItem = inmenu.Items(I)
            S = 0
            Do While S < tmpMenuItem.DropDownItems.Count
                menuSubItem = Replace(tmpMenuItem.DropDownItems(S).Text, "&", "")
                MsgBox(menuSubItem)
                tsql = "If Not Exists(select 1 from MenuDfltSecurity where MenuMItem = '" & MenuMItem & "' and MenuSitem = '" & menuSubItem & "') "
                tsql = tsql & "Begin insert into MenuDfltSecurity (MenuMItem, MenuSitem, MenuS2Item, MenuSecLevel, MenuActive) values ('" & MenuMItem & "','" & menuSubItem & "','',0,1) "
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

    End Function

    Public Function RegisterForms() As Boolean

        Dim tret As Boolean = True





        RegisterForms = tret

    End Function

    '***********************************************************************************************
    '* Misc functions/subs 
    '***********************************************************************************************
    Public Sub CloseAllforms()
        Dim openForms As Windows.Forms.FormCollection = Application.OpenForms

        For Each frm As Windows.Forms.Form In openForms
            If frm.Name.ToString() <> "MainNew" Then
                frm.Close()
            End If
        Next
    End Sub

End Module
