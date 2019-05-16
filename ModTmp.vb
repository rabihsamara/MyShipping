Imports System.Data.SqlClient
Imports System.IO

Module ModTmp
    '********************************************************************************************
    '*                                    Tmp Functions                                         *
    '********************************************************************************************
    ' to get list of all tables Select Myshipping.INFORMATION_SCHEMA.TABLES.TABLE_NAME  from  Myshipping.INFORMATION_SCHEMA.TABLES
    ' to get table columns Select INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME from Myshipping.INFORMATION_SCHEMA.COLUMNS  where table_name = N'cities'
    '

    Public Sub RunClassGen(ByVal inTable As String)

        Dim myarlist As ArrayList = createClass(inTable)

        Dim theWriter As New StreamWriter("C:\SCC\Projects\VbNetProjects\SourceFiling\Project_MYShipping\REL_01\" & inTable & "_class.txt")

        For Each currentElement As String In myarlist
            theWriter.WriteLine(currentElement)
        Next

        theWriter.Close()

    End Sub

    Public Function createClass(ByVal inTable As String) As ArrayList

        Dim al As ArrayList = New ArrayList()
        Dim al2 As ArrayList = New ArrayList()

        Using mysqlConn As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)
            Dim dbase As String = "MyShipping"
            Dim tcode As String
            Dim tsql2 As String = ""

            If (inTable <> "") Then
                tsql2 = "Select " & dbase & ".INFORMATION_SCHEMA.TABLES.TABLE_NAME from " & dbase & ".INFORMATION_SCHEMA.TABLES where " & dbase & ".INFORMATION_SCHEMA.TABLES.TABLE_NAME = '" & inTable & "'"
            Else
                tsql2 = "Select " & dbase & ".INFORMATION_SCHEMA.TABLES.TABLE_NAME from " & dbase & ".INFORMATION_SCHEMA.TABLES"
            End If

            Dim cmd As New SqlCommand(tsql2, mysqlConn)

            mysqlConn.Open()
            Dim cols = 0
            Dim dbr As SqlDataReader = cmd.ExecuteReader()
            Dim i = 0

            While dbr.Read()
                Dim ColArr(20) As String

                tcode = "Public Class " & Trim(dbr.Item("Table_Name"))
                al.Add(tcode & vbNewLine)

                al.Add("Public Sub New() 'parameterised constructor" & vbNewLine)
                al.Add("Console.WriteLine('')" & vbNewLine)
                al.Add("End Sub" & vbNewLine)

                al.Add("Protected Overrides Sub Finalize()  ' destructor" & vbNewLine)
                al.Add("Console.WriteLine('')" & vbNewLine)
                al.Add("End Sub" & vbNewLine)

                al.Add(vbNewLine)

                Using mysqlConn1 As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)
                    Dim cmdcol As New SqlCommand("Select INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME from " & dbase & ".INFORMATION_SCHEMA.COLUMNS where table_name = N'" & dbr.Item("Table_Name") & "'", mysqlConn1)
                    mysqlConn1.Open()
                    Dim dcr As SqlDataReader = cmdcol.ExecuteReader()
                    While dcr.Read()
                        al2.Add("Private " & dcr.Item("Column_Name") & " As String" & vbNewLine)

                        al.Add("Public Property My" & dcr.Item("Column_Name") & "() As String" & vbNewLine)
                        al.Add("   Get" & vbNewLine)
                        al.Add("     Return " & dcr.Item("Column_Name") & vbNewLine)
                        al.Add("   End Get" & vbNewLine)
                        al.Add("   Set(ByVal Value As String)" & vbNewLine)
                        al.Add("      " & dcr.Item("Column_Name") & " = Value" & vbNewLine)
                        al.Add("   End Set" & vbNewLine)
                        al.Add("End Property" & vbNewLine)
                        al.Add(vbNewLine)
                    End While
                End Using
                al.Add(vbNewLine)

                For Each currentElement As String In al2
                    al.Add(currentElement)
                Next
                al.Add(vbNewLine)
                al.Add("End Class" & vbNewLine)
                i += 1
            End While

        End Using
        createClass = al

    End Function

    '********************************************END OF TMP FUNCTIONS *******************************************

    '************************************************************************************************************
    ' Procedure:  not used yet
    '************************************************************************************************************
    Public Sub RunProcedure()

        Using mysqlConn As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)

            Dim sqlCmd As New SqlCommand()

            sqlCmd.Connection = mysqlConn
            sqlCmd.CommandText = "InsertTransData"
            sqlCmd.CommandType = CommandType.StoredProcedure

            'sqlCmd.Parameters.AddWithValue("@ptransacct", mytransRec.Transptransacct)


            mysqlConn.Open()
            sqlCmd.ExecuteNonQuery()

        End Using

    End Sub


    Public Sub CreateReadercode(ByVal InTable As String)

        Dim tcode As String = ""
        Dim tsql As String = ""
        Dim al As ArrayList = New ArrayList()
        Dim selreader As String = "Dim columnIndex AS integer " & vbNewLine
        Dim tstval As String = ""

        al.Add(selreader)
        selreader = ""

        Using mysqlConn As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)

            If (InTable <> "") Then
                tsql = "SELECT COLUMN_NAME,DATA_Type,ISnull(CHARACTER_MAXIMUM_LENGTH,0) as maxlngth FROM INFORMATION_SCHEMA.COLUMNS where  TABLE_NAME = '" & InTable & "'"
            Else
                Exit Sub
            End If

            mysqlConn.Open()
            Dim cmd As New SqlCommand(tsql, mysqlConn)
            Dim dbr2 As SqlDataReader = cmd.ExecuteReader()

            While dbr2.Read()

                tstval = dbr2.Item("Column_Name")
                selreader = "columnIndex = myReader.GetOrdinal('" & dbr2.Item("Column_Name") & "')"
                al.Add(selreader)
                If (dbr2.Item("Data_type") = "varchar" Or dbr2.Item("Data_type") = "char") Then
                    selreader = "Ordrecord.My" & dbr2.Item("Column_Name") & " =  myReader.GetString(columnIndex)" & vbNewLine
                    al.Add(selreader)
                ElseIf (dbr2.Item("Data_type") = "datetime") Then
                    selreader = "Ordrecord.My" & dbr2.Item("Column_Name") & " =  myReader.GetDateTime(columnIndex)" & vbNewLine
                    al.Add(selreader)
                Else
                    selreader = "Ordrecord.My" & dbr2.Item("Column_Name") & " =  myReader.GetValue(columnIndex)" & vbNewLine
                    al.Add(selreader)
                End If

                If (InTable = "orders") Then

                    If (String.Compare(InTable, "Orders", StringComparison.InvariantCultureIgnoreCase) = 0 And String.Compare(tstval, "cmbShpType", StringComparison.InvariantCultureIgnoreCase) = 0) Then
                        selreader = "columnIndex = myReader.GetOrdinal('intshptype')"
                        al.Add(selreader)
                        selreader = "Ordrecord.Myintshptype = myReader.GetValue(columnIndex)" & vbNewLine
                        al.Add(selreader)
                    ElseIf (String.Compare(InTable, "Orders", StringComparison.InvariantCultureIgnoreCase) = 0 And String.Compare(tstval, "cmbshpmethod", StringComparison.InvariantCultureIgnoreCase) = 0) Then
                        selreader = "columnIndex = myReader.GetOrdinal('intshpmethod')"
                        al.Add(selreader)
                        selreader = "Ordrecord.Myintshpmethod = myReader.GetValue(columnIndex)" & vbNewLine
                        al.Add(selreader)
                    End If

                End If

                selreader = ""
            End While

            If (InTable = "orders") Then
                al.Add("GlobalVariables.Gl_SelOrder = Ordrecord.MyOrderNO" & vbNewLine)
                al.Add("GlobalVariables.GL_selOrdShipID = Ordrecord.MyordshipID" & vbNewLine)
                al.Add("GlobalVariables.GL_cmbShpType = Ordrecord.Myintshptype" & vbNewLine)
                al.Add("GlobalVariables.GL_selshpmethod = Ordrecord.Myintshpmethod" & vbNewLine)
                al.Add("cmbShpType.SelectedValue = Ordrecord.Myintshptype" & vbNewLine)
                al.Add("cmbshpmethod.SelectedValue = Ordrecord.Myintshpmethod" & vbNewLine)
            End If

            If Not (dbr2 Is Nothing) Then
                dbr2.Close()
            End If
            If Not (mysqlConn Is Nothing) Then
                mysqlConn.Close()
            End If

        End Using

        Dim theWriter As New StreamWriter("C:\SCC\Projects\VbNetProjects\SourceFiling\Project_MYShipping\REL_01\" & InTable & "_reader.txt")

        For Each currentElement As String In al
            theWriter.WriteLine(currentElement)
        Next
        theWriter.Close()

    End Sub


End Module
