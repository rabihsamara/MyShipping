Imports System.Data.SqlClient

Public Class frmCustomers

    Private mysqlConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Private results As String
    Private selcustid As String = String.Empty
    Private selcustname As String = String.Empty

    Private tmsg As String = String.Empty

    Private Custrecord As Customers = New Customers()

    Private Sub FrmCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim tstat As Boolean = True
        txtmsg.Visible = False
        TabControl1.Visible = False

        tstat = ModMisc.FillCBox(cmbCustID, "CRI")
        tstat = ModMisc.FillCBox(cmbCustName, "CRN")

        'RunClassGen() 'tmp

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
        If (tmsg <> "") Then
            MsgBox(tmsg)
            Exit Sub
        End If
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

        If (inedit = "N") Then
            If (inCustID.Text = "") Then
                terr = "Must Enter Customer ID!"
                GoTo EDIT_EXIT
            ElseIf (inCustName.Text = "") Then
                terr = "Must Enter Customer Name!"
                GoTo EDIT_EXIT
            End If
            GlobalVariables.Gl_SQLStr = "select count(*) as cnt from customers where ID = '" & Trim(inCustID.Text) & "'"
            If (ModMisc.ReadSQL("NCST", "") > 0) Then
                terr = "New Customer ID Exists!"
                GoTo EDIT_EXIT
            End If
        End If

        If (inedit = "E") Then
            selcustid = Trim(cmbCustID.Text)
            selcustname = Trim(cmbCustName.Text)
            If (selcustid = "" And selcustname = "") Then
                terr = "Must Select Customer ID Or Name!"
                GoTo EDIT_EXIT
            End If

            GlobalVariables.Gl_SQLStr = "select * From customers where ID = '" & selcustid & "'"
            If (ReadCustomer("C") = False) Then
                terr = "Error reading customer !"
                GoTo EDIT_EXIT
            End If

        End If

EDIT_EXIT:
        If (terr <> "") Then
            txtmsg.Text = terr
            txtmsg.Visible = True

            timer1.Interval = 3000 'ms
            timer1.Start()
        End If
        EditEntry = terr

    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        txtmsg.Text = ""
        txtmsg.Visible = False
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
                    Custrecord.MyID = myReader.GetValue("ID")
                    Custrecord.MyCustName = myReader.GetValue("CustName")

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

End Class