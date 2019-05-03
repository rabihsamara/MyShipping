﻿Imports System.Data.SqlClient

Public Class frmCustomers

    Private mysqlConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Private results As String
    Private selcustid As String = String.Empty
    Private selcustname As String = String.Empty
    Private seluw As String = "I"
    Private tmsg As String = String.Empty
    Private tstat As Boolean = True

    Private Custrecord As Customers = New Customers()

    Private Sub FrmCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtmsg.Visible = False
        chslactonly.Checked = True
        TabControl1.Visible = False

        tstat = ModMisc.FillCBox(cmbSelType, "CST")
        tstat = ModMisc.FillCBox(cmbCustType, "CST")
        LoadData()

    End Sub

    Private Sub LoadData()

        Dim climode As String = "CRI"
        Dim clnmode As String = "CRN"
        If (chslactonly.Checked = True) Then climode = "CRIA"
        If (chslactonly.Checked = True) Then clnmode = "CRNA"
        '
        If (Trim(cmbSelType.Text) <> "") Then climode = climode & Trim(cmbSelType.Text).Substring(0, 2) 'CRI or CRICS CRIPR CRIAL or CRIACS CRIAPR CRIAAL
        If (Trim(cmbSelType.Text) <> "") Then clnmode = clnmode & Trim(cmbSelType.Text).Substring(0, 2) 'CRN or CRNCS CRNPR CRNAL or CRNACS CRNAPR CRNAAL
        '
        tstat = ModMisc.FillCBox(cmbCustID, climode)
        tstat = ModMisc.FillCBox(cmbCustName, clnmode)

    End Sub

    Private Sub InCustName_TextChanged(sender As Object, e As EventArgs) Handles inCustName.TextChanged
        CreateCustID()
    End Sub

    Private Sub CreateCustID()

        Dim L As Integer = inCustName.Text.Length

        If (inCustName.Text <> "" And L < 7) Then
            inCustID.Text = inCustName.Text.Substring(0, L)
        ElseIf (inCustName.Text = "") Then
            inCustID.Text = ""
        End If

    End Sub

    'Process new customer
    Private Sub CmdProcess_Click(sender As Object, e As EventArgs) Handles cmdProcess.Click

        tmsg = EditEntry("N")
        If (tmsg = "X" Or tmsg <> "Customer Created Successfully!") Then Exit Sub ' user cancelled creating 

        TabControl1.Visible = True

    End Sub

    'Exit customer screen
    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    'Load existing customer
    Private Sub cmdLoadCust_Click(sender As Object, e As EventArgs) Handles cmdLoadCust.Click
        tmsg = EditEntry("E")
        If (tmsg <> "") Then Exit Sub

        TabControl1.Visible = True



    End Sub

    Private Function EditEntry(ByVal inedit As String) As String

        Dim terr As String = String.Empty

        txtmsg.Visible = False
        terr = ""

        If (inedit = "N") Then
            If (inCustID.Text = "") Then
                terr = "Must Enter Customer ID!"
                GoTo EDIT_EXIT
            ElseIf (inCustName.Text = "") Then
                terr = "Must Enter Customer Name!"
                GoTo EDIT_EXIT
            End If
            GlobalVariables.Gl_SQLStr = "select count(*) as cnt from customers where CustID = '" & Trim(inCustID.Text) & "'"
            If (ModMisc.ReadSQL("NCST", "") > 0) Then
                terr = "New Customer ID Exists!"
                GoTo EDIT_EXIT
            Else
                'create new customer message
                seluw = "I"
                Dim result As DialogResult = MessageBox.Show("Create New Customer?", "Confirm adding new customer", MessageBoxButtons.YesNo)
                If (result = DialogResult.Yes) Then
                    'Ok create new cust. load screen to database
                    GlobalVariables.Gl_SQLStr = "Insert into customers (CustID, CustName, CustType, Custactive) Values ('" & Trim(inCustID.Text) & "','" & inCustName.Text & "','PR',1)"
                    If (ModMisc.ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                        MsgBox("Error Creating new Customer!")
                        GoTo EDIT_EXIT
                    End If
                    terr = "Customer Created Successfully!"
                    seluw = "U"
                    LoadData()
                Else
                    inCustID.Text = ""
                    inCustName.Text = ""
                    terr = "X"
                    GoTo EDIT_EXIT
                End If
            End If
        End If

        If (inedit = "E") Then
            selcustid = Trim(cmbCustID.Text)
            selcustname = Trim(cmbCustName.Text)
            If (selcustid = "" And selcustname = "") Then
                terr = "Must Select Customer ID Or Name!"
                GoTo EDIT_EXIT
            End If

            GlobalVariables.Gl_SQLStr = If(selcustid <> "", "select CustID,CustName,CustType,Custactive From customers where CustID = '" & selcustid & "'", "select CustID,CustName, Custtype, Custactive From customers where Custname = '" & selcustname & "'")
            If (ReadCustomer("C") = False) Then
                terr = "Error reading customer !"
                GoTo EDIT_EXIT
            End If
            'load data to screen
            seluw = "U"

        End If

EDIT_EXIT:
        If (terr <> "" And terr <> "X") Then
            txtmsg.Text = terr
            txtmsg.Visible = True

            Timer1.Interval = 3000 'ms
            Timer1.Start()
        End If
        EditEntry = terr

    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        txtmsg.Text = ""
        txtmsg.Visible = False
    End Sub

    'Reload existing customer filters custtype.
    Private Sub cmbSelType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSelType.SelectedIndexChanged
        cmbCustID.Text = ""
        cmbCustID.Items.Clear()
        cmbCustName.Text = ""
        cmbCustName.Items.Clear()
        LoadData()
    End Sub

    Public Function ReadCustomer(ByVal inopt As String) As Boolean

        GlobalVariables.GL_Stat = False
        ReadCustomer = False

        Using mysqlConn As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)
            Try

                myCmd = mysqlConn.CreateCommand
                myCmd.CommandText = GlobalVariables.Gl_SQLStr
                mysqlConn.Open()

                myReader = myCmd.ExecuteReader()
                Do While myReader.Read()
                    Custrecord.MyCustID = myReader.GetString(0).ToString
                    Custrecord.MyCustName = myReader.GetString(1).ToString
                    Custrecord.MyCustType = myReader.GetString(2).ToString
                    Custrecord.MyCustActive = myReader.GetValue(3)

                    ReadCustomer = True
                Loop

            Catch ex As Exception
                MsgBox(ex.ToString)
                ReadCustomer = False
            Finally
                If Not (myReader Is Nothing) Then
                    myReader.Close()
                End If
                If Not (mysqlConn Is Nothing) Then
                    mysqlConn.Close()
                End If
            End Try
        End Using

    End Function

    Private Sub CmdCanCust_Click(sender As Object, e As EventArgs) Handles cmdCanCust.Click
        'check if new was pressed or update


        'release log later


        inCustID.Text = ""
        inCustName.Text = ""
        cmbCustID.Text = ""
        cmbCustName.Text = ""
        LoadData() ' inacse new 
        TabControl1.Visible = False

    End Sub

End Class