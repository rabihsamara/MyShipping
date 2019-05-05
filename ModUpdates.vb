Imports System.Data.SqlClient
Imports System.IO

Module ModUpdates

    Private al As ArrayList = New ArrayList()
    Private typeAR As String = "CheckBox,CheckedListBox,ComboBox,ListBox,ListView,Radio,Richtextbox,TextBox"

    '************************************************************
    'inopert - LCS= load customer data
    '        - LCU = update customer data to database
    '************************************************************
    Public Function UpdateFormData(ByVal inopert As String, ByVal infrm As Form, ByVal inTable As String) As Boolean

        Dim tfname As String = infrm.Name
        al.Clear()
        ControlsRecr(infrm.Controls, tfname)

        DisplayControls(tfname, inTable)
        UpdateFormData = True

    End Function

    Private Sub ControlsRecr(ByVal controls As Control.ControlCollection, ByVal inform As String)

        For Each ctrl As Control In controls
            If ctrl.Name <> String.Empty And ctrl.GetType.Name <> "Label" Then
                al.Add(ctrl.Name & " - " & ctrl.GetType.Name & " - " & ctrl.Text)
                ControlsRecr(ctrl.Controls, inform)
            End If
        Next

    End Sub

    Public Sub DisplayControls(ByVal infname As String, ByVal intable As String)

        Dim theWriter As New StreamWriter("C:\SCC\Projects\VbNetProjects\SourceFiling\Project_MYShipping\REL_01\" & intable & ".txt")

        Dim arval(2) As String
        Dim chval As String = ""
        Dim ctrlname As String = ""
        Dim ctrltype As String = ""
        Dim ctrlvlaue As String = ""
        Dim isInString As Boolean = False

        For Each currentElement As String In al

            chval = currentElement.ToString
            arval = Split(chval, " - ")
            ctrlname = Trim(arval(0))
            ctrltype = Trim(arval(1))
            ctrlvlaue = Trim(arval(2))

            isInString = (typeAR.IndexOf(ctrltype) > -1)
            If ((isInString = True And Left(ctrlname, 2) <> "in") Or ctrltype = "RadioButton") Then
                theWriter.WriteLine(currentElement)
            End If

        Next

        theWriter.Close()

        'GlobalVariables.Gl_SQLStr = "if not Exists(select 1 from frmDfltcontrols where formname = '" & inform & "' and controlname ='" & ctrl.Name & " ') Begin "
        'GlobalVariables.Gl_SQLStr = "insert into frmDfltcontrols (FormName, controlname, controltype, contvisible, contenabled,conteditable) values"
        'GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "('" & inform & "','" & ctrl.Name & "','" & ctrl.GetType.Name & "',1,1,1)"
        'If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
        '    MsgBox("Error Creating Form Controls for form " & inform)
        '    Exit Sub
        'End If

    End Sub

End Module
