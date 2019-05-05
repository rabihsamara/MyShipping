﻿Imports System.Data.SqlClient
Imports System.IO

Module ModUpdates

    Private al As ArrayList = New ArrayList()
    Private typeAR As String = "CheckBox,CheckedListBox,ComboBox,ListBox,ListView,Radio,Richtextbox,TextBox"
    Private crmode As String = ""
    Private crformname As String = ""
    Private crtable As String = ""
    Private crselID As String = ""
    Private updsql As String = ""
    Private updsql2 As String = ""
    Private updsql3 As String = ""

    Dim sCommand As SqlCommand
    Dim sAdapter As SqlDataAdapter
    Dim sBuilder As SqlCommandBuilder
    Dim sDs As DataSet
    Dim sTable As DataTable

    '************************************************************
    'inopert - LCS  = load customer data
    '        - LCIU = Insert new - update customer data to database
    '        - LCU  = update customer data to database
    '************************************************************
    Public Function UpdateFormData(ByVal inopert As String, ByVal infrm As Form, ByVal inTable As String, ByVal selID As String) As Boolean

        al.Clear()
        UpdateFormData = False

        crmode = inopert
        crformname = infrm.Name
        crtable = inTable
        crselID = selID

        ControlsRecr(infrm.Controls) 'Get all controls in a form into arraylist al

        If (Left(inopert, 2) = "LC") Then ' customers table
            If (inopert = "LCIU" Or inopert = "LCU") Then
                UpdateFormData = UpdateCustomers()
            End If
        End If

        DisplayControls() ' debugging

    End Function

    Private Sub ControlsRecr(ByVal controls As Control.ControlCollection)

        For Each ctrl As Control In controls
            If ctrl.Name <> String.Empty And ctrl.GetType.Name <> "Label" Then
                al.Add(ctrl.Name & " - " & ctrl.GetType.Name & " - " & ctrl.Text)
                ControlsRecr(ctrl.Controls)
            End If
        Next

    End Sub


    Private Function UpdateCustomers() As Boolean

        Dim arval(2) As String
        Dim chval As String = ""
        Dim ctrlname As String = ""
        Dim ctrltype As String = ""
        Dim ctrlvalue As String = ""
        Dim isInString As Boolean = False

        UpdateCustomers = False

        updsql = "update " & crtable & " set "

        For Each currentElement As String In al

            chval = currentElement.ToString
            arval = Split(chval, " - ")
            ctrlname = Trim(arval(0))
            ctrltype = Trim(arval(1))
            ctrlvalue = Trim(arval(2))

            isInString = (typeAR.IndexOf(ctrltype) > -1)
            If ((isInString = True And Left(ctrlname, 2) <> "in") Or ctrltype = "RadioButton") Then
                If (updsql2 <> "") Then
                    updsql2 = updsql2 & ","
                End If
                If (ctrlname = "chCIactive") Then
                    updsql2 = updsql2 & ctrlname & " = " & GlobalVariables.Gl_tmpactive
                Else
                    updsql2 = updsql2 & ctrlname & " = '" & ctrlvalue & "'"
                End If

            End If
        Next
        updsql3 = " where custid = '" & crselID & "'"
        GlobalVariables.Gl_SQLStr = updsql & updsql2 + updsql3
        If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
            MsgBox("Error updating Customer table!" & crformname)
            UpdateCustomers = False
            Exit Function
        End If
        UpdateCustomers = True

    End Function

    Public Sub DisplayControls()

        Dim theWriter As New StreamWriter("C:\SCC\Projects\VbNetProjects\SourceFiling\Project_MYShipping\REL_01\" & crtable & ".txt")

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
        theWriter.WriteLine(GlobalVariables.Gl_SQLStr)
        theWriter.Close()

    End Sub

End Module