Imports System.Data.SqlClient
Imports System.IO

Module ModUpdates

    Private al As ArrayList = New ArrayList()
    'Private typeAR As String = "Checkbox,CheckedListBox,ComboBox,ListBox,ListView,RadioButton,Richtextbox,TextBox"
    Private typeAR As String = "Checkbox,CheckedListBox,ComboBox,ListBox,ListView,Radio,Richtextbox,TextBox"

    '************************************************************
    'inopert - LCS= load customer data
    '        - LCU = update customer data to database
    '************************************************************
    Public Function UpdateFormData(ByVal inopert As String, ByVal infrm As Form) As Boolean

        Dim frm As New Form
        frm = infrm
        Dim tfname As String = frm.Name
        ControlsRecr(frm.Controls, tfname)


        DisplayControls(tfname)
        UpdateFormData = True

    End Function

    Private Sub ControlsRecr(ByVal controls As Control.ControlCollection, ByVal inform As String)

        Dim tstval As String = ""
        Dim t As Integer

        For Each ctrl As Control In controls
            If ctrl.Name <> String.Empty And ctrl.GetType.Name <> "Label" Then
                al.Add(ctrl.Name & " - " & ctrl.GetType.Name)
                ControlsRecr(ctrl.Controls, inform)
            End If
        Next

    End Sub


    '* Test reading all controls
    Public Sub DisplayControls(ByVal infname As String)

        Dim theWriter As New StreamWriter("C:\SCC\Projects\VbNetProjects\SourceFiling\Project_MYShipping\REL_01\" & infname & ".txt")

        Dim arval(2) As String
        Dim tstval As String = 0
        Dim isInString As Boolean

        For Each currentElement As String In al

            tstval = currentElement.ToString
            arval = Split(tstval, " - ")
            tstval = Trim(arval(1))

            isInString = (typeAR.IndexOf(tstval) > -1)

            If (isInString = True Or tstval = "RadioButton") Then
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
