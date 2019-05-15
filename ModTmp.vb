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

    Public Function CreateSelectStatement(ByVal Intable As String) As Boolean

        Dim tcode As String = ""
        Dim tsql As String = ""
        Dim selstment As String = ""

        CreateSelectStatement = False
        Using mysqlConn As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)

            If (Intable <> "") Then
                tsql = "SELECT COLUMN_NAME,DATA_Type,ISnull(CHARACTER_MAXIMUM_LENGTH,0) as maxlngth FROM INFORMATION_SCHEMA.COLUMNS where  TABLE_NAME = '" & Intable & "'"
            Else
                Exit Function
            End If

            Dim cmd As New SqlCommand(tsql, mysqlConn)
            mysqlConn.Open()

            Dim dbr As SqlDataReader = cmd.ExecuteReader()
            Dim i = 0
            selstment = "select "

            While dbr.Read()
                If (i > 0) Then selstment = selstment & ","
                If (dbr.Item("Data_type") = "varchar" Or dbr.Item("Data_type") = "char" Or dbr.Item("Data_type") = "datetime") Then
                    selstment = selstment & "isnull(" & dbr.Item("Column_Name") & ",'') as " & dbr.Item("Column_Name")
                Else
                    selstment = selstment & dbr.Item("Column_Name")
                End If
                i = 1
            End While
            selstment = selstment & " from " & Intable
        End Using
        MsgBox(selstment)

        Dim theWriter As New StreamWriter("C:\SCC\Projects\VbNetProjects\SourceFiling\Project_MYShipping\REL_01\" & Intable & "_select.txt")

        theWriter.WriteLine(selstment)
        theWriter.Close()

        CreateSelectStatement = True

    End Function

End Module
