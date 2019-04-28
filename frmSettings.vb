Imports System.Data.SqlClient

Public Class frmsettings

    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private tcompid As Integer = 0
    Dim connection As SqlConnection
    Dim sCommand As SqlCommand
    Dim sAdapter As SqlDataAdapter
    Dim sBuilder As SqlCommandBuilder
    Dim sDs As DataSet
    Dim sTable As DataTable

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DataGridCompany.Visible = False
        PropertyGrid1.SelectedObject = My.Settings

        ' Attribute for the user-scope settings.
        Dim userAttr As New System.Configuration.UserScopedSettingAttribute
        Dim attrs As New System.ComponentModel.AttributeCollection(userAttr)
        PropertyGrid1.BrowsableAttributes = attrs

        If Not (Me.Tag = "appstart") Then
            Initialize_DatGridMaster()
            Initiiaze_DataGridCompany()
        End If

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        Dim compcnt As String = String.Empty

        Try
            GlobalVariables.GL_skipOnce = False
            If (Me.Tag = "appstart") Then 'called on new install from ApplicationEvent.
                GlobalVariables.Gl_AppFirtR = My.Settings.firstrun
                My.Settings.Save()
                If (SaveMasterConn() = True) Then 'default first master record
                    Initialize_DatGridMaster()
                    DataGridCompany.Visible = True
                    Initiiaze_DataGridCompany()
                    GlobalVariables.Gl_SQLStr = "Select CompAddress1 as add1 from company where companyID = 1"
                    compcnt = ModMisc.ReadSQL("fldchk")
                    If (compcnt = "") Then
                        MsgBox("Must Update Company Information!")
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As ArgumentException
            MsgBox("Error saving Application settings.")
        Finally

        End Try

    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click

        Me.Close()
        If (Me.Tag = "appstart") Then
            Dim Lgform As Form
            Lgform = New Form()
            Lgform = Login
            Lgform.Show()
        Else
            My.Settings.Save()
            Me.Close()
        End If

    End Sub

    Private Function SaveMasterConn() As Boolean

        'Table: appconnmaster - companyID, sqlodbcdriver, sqlserver, sqldbase, sqluser, sqlpassword, sqltrusted, dfltconn, appfirstrun, active
        'ID = 1

        SaveMasterConn = False

        If (My.Settings.companyname = "") Then
            MsgBox("Must enter company name and update company file!")
            Exit Function
        End If

        tcompid = 1
        GlobalVariables.GL_DFLTMasterConn.AppmastCompID = tcompid
        GlobalVariables.GL_DFLTMasterConn.Appsqlodbcdriver = My.Settings.MySQLDriver
        GlobalVariables.GL_DFLTMasterConn.Appmastserver = My.Settings.MySQLServer
        GlobalVariables.GL_DFLTMasterConn.Appmastdbase = My.Settings.MySQLDbase
        GlobalVariables.GL_DFLTMasterConn.Appmastsqluser = My.Settings.MySQLUserID
        GlobalVariables.GL_DFLTMasterConn.Appmastsqlpasswd = My.Settings.MySQLUserpwd
        GlobalVariables.GL_DFLTMasterConn.Appmasttrusted = My.Settings.Trusted
        GlobalVariables.GL_DFLTMasterConn.Appmastdfltconn = My.Settings.MySqlDefault
        GlobalVariables.GL_DFLTMasterConn.Appappfirstrun = My.Settings.firstrun
        GlobalVariables.GL_DFLTMasterConn.Appactive = 1

        GlobalVariables.Gl_SQLStr = "If Not Exists(select 1 from appconnmaster where companyID = 1) Begin INSERT INTO appconnmaster (CompanyID,sqlodbcdriver, sqlserver,sqldbase,sqluser,sqlpassword,sqltrusted,dfltconn,appfirstrun,active) VALUES ("
        GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & GlobalVariables.GL_DFLTMasterConn.AppmastCompID & ",'" & GlobalVariables.GL_DFLTMasterConn.Appsqlodbcdriver & "','"
        GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & GlobalVariables.GL_DFLTMasterConn.Appmastserver & "','" & GlobalVariables.GL_DFLTMasterConn.Appmastdbase & "','"
        GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & GlobalVariables.GL_DFLTMasterConn.Appmastsqluser & "','" & GlobalVariables.GL_DFLTMasterConn.Appmastsqlpasswd & "',"
        GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & Math.Abs(GlobalVariables.GL_DFLTMasterConn.Appmasttrusted) & "," & Math.Abs(GlobalVariables.GL_DFLTMasterConn.Appmastdfltconn) & ","
        GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & Math.Abs(GlobalVariables.GL_DFLTMasterConn.Appappfirstrun) & "," & GlobalVariables.GL_DFLTMasterConn.Appactive & ") End"

        If (MyConn.BuildSQLStr() = True) Then
            GlobalVariables.GL_skipOnce = True
            If (ModMisc.ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                MsgBox("Error updating master table!")
                Exit Function
            Else
                'create empty company record with id = 1
                GlobalVariables.Gl_SQLStr = "If Not Exists(select 1 from company where CompName = '" & My.Settings.companyname & "') Begin INSERT INTO company (CompanyID,CompName,CompAddress1,CompAddress2,CompCity,CompProv,CompPcode,CompCountry,CompActive) VALUES (" & tcompid & ",'" & My.Settings.companyname & "','','','','','','Canada',1) End"
                If (ModMisc.ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                    MsgBox("Error Creating default company Record!")
                    Exit Function
                End If
                'Create default user (admin) in table users
                GlobalVariables.Gl_SQLStr = "if not Exists(select 1 from users where UserID = '" & My.Settings.DFLTuserID & "') Begin "
                GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "insert into users (UserID,Fname,Lname,DateOfBirth,Address1,Address2,City,Province,Pcode,country,Active,usrPassword,usrmode,usrseclvl) "
                GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "Values ('" & My.Settings.DFLTuserID & "','Rabih','Samara','','','','','','','',1,'" & My.Settings.DFLTUserpwd & "','A',0) End"
                If (ModMisc.ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                    MsgBox("Error Creating default user Record!")
                    Exit Function
                End If
            End If

        End If
        SaveMasterConn = True

    End Function

    Private Sub Initialize_DatGridMaster()

        Dim tID As Integer
        Dim tCompanyID As Integer
        Dim tsqlodbcdriver As String
        Dim tsqlserver As String
        Dim tsqlbase As String
        Dim tsqluser As String
        Dim tsqlpassword As String
        Dim tsqltrusted As Integer
        Dim tdfltconn As Integer
        Dim tappfirstrun As Integer
        Dim tactive As Integer

        Dim table As New DataTable("Table")
        Dim mysqlConn As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)

        Using mysqlConn

            Try
                Dim myCmd2 As New SqlCommand("SELECT ID,companyID,sqlodbcdriver,sqlserver,sqldbase,sqluser,sqlpassword,sqltrusted,dfltconn,appfirstrun,active FROM appconnmaster order by ID,companyID;", mysqlConn)
                mysqlConn.Open()

                'Add columns to your datatable, with the name of the columns and their type 
                table.Columns.Add("ID", Type.GetType("System.Int32"))
                table.Columns.Add("companyID", Type.GetType("System.Int32"))
                table.Columns.Add("sqlodbcdriver", Type.GetType("System.String"))
                table.Columns.Add("sqlserver", Type.GetType("System.String"))
                table.Columns.Add("sqldbase", Type.GetType("System.String"))
                table.Columns.Add("sqluser", Type.GetType("System.String"))
                table.Columns.Add("sqlpassword", Type.GetType("System.String"))
                table.Columns.Add("sqltrusted", Type.GetType("System.Int32"))
                table.Columns.Add("dfltconn", Type.GetType("System.Int32"))
                table.Columns.Add("appfirstrun", Type.GetType("System.Int32"))
                table.Columns.Add("active", Type.GetType("System.Int32"))

                myReader = myCmd2.ExecuteReader()
                Do While myReader.Read()
                    tID = myReader.GetInt32(0)
                    tCompanyID = myReader.GetInt32(1)
                    tsqlodbcdriver = myReader.GetString(2)
                    tsqlserver = myReader.GetString(3)
                    tsqlbase = myReader.GetString(4)
                    tsqluser = myReader.GetString(5)
                    tsqlpassword = myReader.GetString(6)
                    tsqltrusted = myReader.GetInt32(7)
                    tdfltconn = myReader.GetInt32(8)
                    tappfirstrun = myReader.GetInt32(9)
                    tactive = myReader.GetInt32(10)
                    table.Rows.Add(tID, tCompanyID, tsqlodbcdriver, tsqlserver, tsqlbase, tsqluser, tsqlpassword, tsqltrusted, tdfltconn, tappfirstrun, tactive)
                Loop

                DatGridMaster.DataSource = table
                DatGridMaster.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
                DatGridMaster.BackgroundColor = Color.Wheat
                DatGridMaster.RowsDefaultCellStyle.BackColor = Color.AliceBlue
                DatGridMaster.RowsDefaultCellStyle.SelectionBackColor = Color.CornflowerBlue
                DatGridMaster.RowsDefaultCellStyle.SelectionForeColor = Color.White

            Catch ex As Exception
                MsgBox(Err.Description)
            Finally
                myReader.Close()
                mysqlConn.Close()
            End Try
        End Using

    End Sub

    Private Sub Initiiaze_DataGridCompany()

        Dim sql As String = "SELECT * FROM company"
        connection = New SqlConnection(GlobalVariables.Gl_ConnectionSTR)

        connection.Open()
        sCommand = New SqlCommand(sql, connection)
        sAdapter = New SqlDataAdapter(sCommand)
        sBuilder = New SqlCommandBuilder(sAdapter)
        sDs = New DataSet()
        sAdapter.Fill(sDs, "company")
        sTable = sDs.Tables("company")
        connection.Close()
        DataGridCompany.DataSource = sDs.Tables("company")
        DataGridCompany.ReadOnly = False
        DataGridCompany.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        connection.Close()

    End Sub

    Private Sub CmdSaveComp_Click(sender As Object, e As EventArgs) Handles cmdSaveComp.Click

        sAdapter.Update(sTable)
        DataGridCompany.[ReadOnly] = True
        'cmdSave.Enabled = False

    End Sub

End Class