Imports System.Data.SqlClient
Imports System.IO

Module ModUpdates

    Private al As ArrayList = New ArrayList()
    Private typeAR As String = "CheckBox,CheckedListBox,ComboBox,ListBox,ListView,Radio,Richtextbox,TextBox"
    Private crmode As String = ""
    Private crformname As String = ""
    Private crselID As String = ""
    Private updsql As String = ""
    Private updsql2 As String = ""
    Private updsql3 As String = ""

    Dim sCommand As SqlCommand
    Dim sAdapter As SqlDataAdapter
    Dim sBuilder As SqlCommandBuilder
    Dim sDs As DataSet
    Dim sTable As DataTable

    '*********************************************************************
    '*inopert:
    '*1) *** Customer screen ***
    '*        - LCIU = Insert new - update customer data to database - OK
    '*        - LCU  = update customer data to database  - OK
    '*
    '*2) *** Order screen ***
    '*        - LCOI  = Insert new update - working on
    '*        - LCOU  = Update customer orders - working on
    '*********************************************************************
    Public Function UpdateFormData(ByVal inopert As String, ByVal infrm As Form, ByVal inTable As String, ByVal selID As String) As Boolean

        UpdateFormData = False

        crmode = inopert
        crformname = infrm.Name
        crselID = selID

        al.Clear()
        ControlsRecr(infrm.Controls) 'Get all controls in a form into arraylist al
        DisplayControls(inTable) ' debugging

        UpdateFormData = UpdateTables(inTable, inopert)

    End Function

    Private Sub ControlsRecr(ByVal controls As Control.ControlCollection)

        For Each ctrl As Control In controls
            If ctrl.Name <> String.Empty And ctrl.GetType.Name <> "Label" Then
                al.Add(ctrl.Name & " # " & ctrl.GetType.Name & " # " & ctrl.Text)
                ControlsRecr(ctrl.Controls)
            End If
        Next

    End Sub

    Private Function UpdateTables(ByVal seltable As String, ByVal inopert As String) As Boolean

        Dim arval(3) As String
        Dim chval As String = ""
        Dim ctrlname As String = ""
        Dim ctrltype As String = ""
        Dim ctrlvalue As String = ""
        Dim isInString As Boolean = False
        Dim tskip As Boolean = False
        Dim tsql As String = ""

        UpdateTables = False

        updsql = "update " & seltable & " set "
        updsql2 = ""
        updsql3 = ""

        For Each currentElement As String In al

            chval = currentElement.ToString
            arval = Split(chval, " # ")
            ctrlname = Trim(arval(0))
            ctrltype = Trim(arval(1))
            ctrlvalue = Trim(arval(2))

            isInString = (typeAR.IndexOf(ctrltype) > -1)
            If ((isInString = True And Left(ctrlname, 2) <> "in") Or ctrltype = "RadioButton") Then
                If (updsql2 <> "" And tskip = False) Then
                    updsql2 = updsql2 & ","
                End If

                If (inopert = "LCIU" Or inopert = "LCU") Then
                    If (ctrlname = "chCIactive") Then
                        updsql2 = updsql2 & ctrlname & " = " & GlobalVariables.Gl_tmpactive
                    ElseIf (ctrlname = "cmbShpID") Then
                        tskip = True
                    Else
                        If (ctrlname = "cmbCustType") Then ctrlvalue = ctrlvalue.Substring(0, 2)
                        updsql2 = updsql2 & ctrlname & " = '" & ctrlvalue & "'"
                        tskip = False
                    End If
                Else ' order screen
                    If (ctrlname = "OrdStat") Then
                        GlobalVariables.Gl_SQLStr = "select ordstatshort  from ordstatus where  ordstatfull =  '" & Trim(ctrlvalue) & "'"
                        ctrlvalue = ModMisc.ReadSQL("fldchk")
                    End If

                    If (ctrlname = "dateupdated") Then
                        ctrlvalue = Now()
                    ElseIf (ctrlname = "ordshipID") Then
                        ctrlvalue = GlobalVariables.GL_selOrdShipID
                    ElseIf (ctrlname = "cmbShpType") Then
                        ctrlvalue = GlobalVariables.GL_cmbShpType
                    ElseIf (ctrlname = "cmbshpmethod") Then
                        ctrlvalue = Trim(GlobalVariables.GL_selshpmethod)
                    End If

                    If (ctrlname = "datecreated" Or ctrlname = "createdby" Or ctrlname = "OrderNO") Then
                        tskip = True
                    Else
                        updsql2 = updsql2 & ctrlname & " = '" & ctrlvalue & "'"
                        tskip = False
                    End If
                End If
            End If
        Next

        If (Right(updsql2, 1) = ",") Then
            updsql2 = Left(updsql2, (Len(updsql2) - 1))
        End If

        If (inopert = "LCIU" Or inopert = "LCU") Then
            updsql3 = " where custid = '" & crselID & "'"
        Else
            updsql3 = " where custNO = '" & GlobalVariables.Gl_tmpcustid & "' and AccountNo  = '" & crselID & "' and OrderNO = " & GlobalVariables.Gl_SelOrder
        End If

        GlobalVariables.Gl_SQLStr = updsql & updsql2 + updsql3
        If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
            UpdateTables = False
            Exit Function
        End If
        UpdateTables = True

    End Function

    Public Sub DisplayControls(ByVal sltable As String)

        Dim theWriter As New StreamWriter("C:\SCC\Projects\VbNetProjects\SourceFiling\Project_MYShipping\REL_01\" & sltable & ".txt")

        Dim arval(2) As String
        Dim chval As String = ""
        Dim ctrlname As String = ""
        Dim ctrltype As String = ""
        Dim ctrlvlaue As String = ""
        Dim isInString As Boolean = False

        For Each currentElement As String In al

            chval = currentElement.ToString
            arval = Split(chval, " # ")
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