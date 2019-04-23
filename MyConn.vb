Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web

'Get Connection to SQL Server
Public Class MyConn

    Public Shared Function BuildSQLStr() As Boolean
        Dim connectionString As String
        Dim dfltconn As MySQLConInfo = New MySQLConInfo()

        Try

            BuildSQLStr = True
            dfltconn.SetConn()

            'with user id - Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password = myPassword;
            'Trusted      - Server=myServerAddress;Database=myDataBase;Trusted_Connection=

            If (dfltconn.AppMySqlTrusted) Then
                connectionString = "Server=" & dfltconn.AppMySqlServer & ";Database=" & dfltconn.AppMySqlDbase & ";Integrated Security=SSPI;"
            ElseIf (dfltconn.AppMySqlTrusted = False And dfltconn.AppMySqlUserID <> "" And dfltconn.AppMySqlPassword <> "") Then
                connectionString = "Server=" & dfltconn.AppMySqlServer & ";Database=" & dfltconn.AppMySqlDbase & ";User Id=" & dfltconn.AppMySqlUserID & ";Password=" & dfltconn.AppMySqlPassword
            Else
                connectionString = "Server=" & dfltconn.AppMySqlServer & ";Database=" & dfltconn.AppMySqlDbase & ";Integrated Security=SSPI;"
            End If

            GlobalVariables.Gl_ConnectionSTR = connectionString
            GlobalVariables.Gl_AppFirtR = dfltconn.AppMyAPPFirstRun
            GlobalVariables.GL_DfltConnValues = dfltconn
        Catch ex As Exception
            BuildSQLStr = False
            MsgBox("Error occured! " & Err.Description)
        End Try

    End Function

End Class