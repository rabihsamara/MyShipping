Imports System.Data.SqlClient

Public Class GlobalVariables

    Public Shared Property Gl_ConnectionSTR As String
    Public Shared Property GL_DfltConnValues As MySQLConInfo = New MySQLConInfo()
    Public Shared Property GL_MySqlConn As SqlConnection
    Public Shared Property Gl_AppFirtR As Boolean
    Public Shared Property GL_DFLTMasterConn As masterconnrec = New masterconnrec()

    Public Shared Property Gl_LogUserID As String
    Public Shared Property Gl_UserIDLevel As String
    Public Shared Property Gl_SQLStr As String
    Public Shared Property GL_SLmsg As String
    Public Shared Property GL_Stat As Boolean

    Public Shared Property GL_skipOnce As Boolean

End Class

Public Class masterconnrec

    'Table: appconnmaster (companyID,sqlodbcdriver,sqlserver,sqldbase,sqluser,sqlpassword,sqltrusted,dfltconn,appfirstrun,active)

    Private mastcompID As Integer
    Private mastodbcdriver As String
    Private mastsqlserver As String
    Private mastsqldbase As String
    Private mastsqluser As String
    Private mastsqlpasswd As String
    Private mastsqltrusted As Integer
    Private mastdfltconn As Integer
    Private mastappfirstrun As Integer
    Private mastactive As Integer

    Public Sub New()   'parameterised constructor
        Console.WriteLine("My sqlConnect Object is being created")
    End Sub

    Protected Overrides Sub Finalize()  ' destructor
        Console.WriteLine("Object is being deleted")
    End Sub

    Public Property AppmastCompID() As Integer
        Get
            Return mastcompID
        End Get
        Set(ByVal Value As Integer)
            mastcompID = Value
        End Set
    End Property

    Public Property Appsqlodbcdriver() As String
        Get
            Return mastodbcdriver
        End Get
        Set(ByVal Value As String)
            mastodbcdriver = Value
        End Set
    End Property

    Public Property Appmastserver() As String
        Get
            Return mastsqlserver
        End Get
        Set(ByVal Value As String)
            mastsqlserver = Value
        End Set
    End Property

    Public Property Appmastdbase() As String
        Get
            Return mastsqldbase
        End Get
        Set(ByVal Value As String)
            mastsqldbase = Value
        End Set
    End Property

    Public Property Appmastsqluser() As String
        Get
            Return mastsqluser
        End Get
        Set(ByVal Value As String)
            mastsqluser = Value
        End Set
    End Property

    Public Property Appmastsqlpasswd() As String
        Get
            Return mastsqlpasswd
        End Get
        Set(ByVal Value As String)
            mastsqlpasswd = Value
        End Set
    End Property

    Public Property Appmasttrusted() As Integer
        Get
            Return mastsqltrusted
        End Get
        Set(ByVal Value As Integer)
            mastsqltrusted = Value
        End Set
    End Property

    Public Property Appmastdfltconn() As Integer
        Get
            Return mastdfltconn
        End Get
        Set(ByVal Value As Integer)
            mastdfltconn = Value
        End Set

    End Property

    Public Property Appappfirstrun() As Integer
        Get
            Return mastappfirstrun
        End Get
        Set(ByVal Value As Integer)
            mastappfirstrun = Value
        End Set
    End Property

    Public Property Appactive() As Integer
        Get
            Return mastactive
        End Get
        Set(ByVal Value As Integer)
            mastactive = Value
        End Set
    End Property

    Public Sub Setmaster(ByVal inmastcompID As Integer, ByVal inodbcDrvvr As String, ByVal inSQSrvr As String, ByVal inSQDbase As String, ByVal inSQUSER As String,
                         ByVal inSQPWD As String, ByVal inSQTrust As Boolean, inSQDflt As Boolean, ByVal inappfirstrun As Boolean, ByVal inactive As Boolean)

        Me.AppmastCompID = inmastcompID
        Me.Appsqlodbcdriver = inodbcDrvvr
        Me.Appmastserver = inSQSrvr
        Me.Appmastdbase = inSQDbase
        Me.Appmastsqluser = inSQUSER
        Me.Appmastsqlpasswd = inSQPWD
        Me.Appmasttrusted = inSQTrust
        Me.Appmastdfltconn = inSQDflt
        Me.Appappfirstrun = inappfirstrun
        Me.Appactive = inactive
    End Sub

End Class

Public Class MySQLConInfo
    Private MySqlODBCDriver As String
    Private MySqlServer As String
    Private MySqlDbase As String
    Private MySqlUserID As String
    Private MySqlPassword As String
    Private MySqlTrusted As Boolean
    Private MySqlDefault As Boolean
    Private MyAPPFirstRun As Boolean
    Private MyDFUser As String
    Private MyDFUPwd As String

    Public Sub New()   'parameterised constructor
        Console.WriteLine("My sqlConnect Object is being created")
    End Sub

    Protected Overrides Sub Finalize()  ' destructor
        Console.WriteLine("Object is being deleted")
    End Sub

    Public Property AppSqlODBCDriver() As String
        Get
            Return MySqlODBCDriver
        End Get
        Set(ByVal Value As String)
            MySqlODBCDriver = Value
        End Set
    End Property

    Public Property AppMySqlServer() As String
        Get
            Return MySqlServer
        End Get
        Set(ByVal Value As String)
            MySqlServer = Value
        End Set
    End Property

    Public Property AppMySqlDbase() As String
        Get
            Return MySqlDbase
        End Get
        Set(ByVal Value As String)
            MySqlDbase = Value
        End Set
    End Property

    Public Property AppMySqlUserID() As String
        Get
            Return MySqlUserID
        End Get
        Set(ByVal Value As String)
            MySqlUserID = Value
        End Set
    End Property

    Public Property AppMySqlPassword() As String
        Get
            Return MySqlPassword
        End Get
        Set(ByVal Value As String)
            MySqlPassword = Value
        End Set
    End Property

    Public Property AppMySqlTrusted() As Boolean
        Get
            Return MySqlTrusted
        End Get
        Set(ByVal Value As Boolean)
            MySqlTrusted = Value
        End Set
    End Property

    Public Property AppMySqlDefault() As Boolean
        Get
            Return MySqlDefault
        End Get
        Set(ByVal Value As Boolean)
            MySqlDefault = Value
        End Set
    End Property

    Public Property AppMyAPPFirstRun() As Boolean
        Get
            Return MyAPPFirstRun
        End Get
        Set(ByVal Value As Boolean)
            MyAPPFirstRun = Value
        End Set
    End Property

    Public Property AppMyDFUser() As String
        Get
            Return MyDFUser
        End Get
        Set(ByVal Value As String)
            MyDFUser = Value
        End Set
    End Property

    Public Property AppMyDFUpwd() As String
        Get
            Return MyDFUPwd
        End Get
        Set(ByVal Value As String)
            MyDFUPwd = Value
        End Set
    End Property

    Public Sub SetConn()
        Me.AppSqlODBCDriver = My.Settings.MySQLDriver
        Me.AppMySqlServer = My.Settings.MySQLServer
        Me.AppMySqlDbase = My.Settings.MySQLDbase
        Me.AppMySqlUserID = My.Settings.MySQLUserID
        Me.AppMySqlPassword = My.Settings.MySQLUserpwd
        Me.AppMySqlTrusted = My.Settings.Trusted
        Me.AppMySqlDefault = My.Settings.MySqlDefault
        Me.AppMyAPPFirstRun = My.Settings.firstrun
        Me.AppMyDFUser = My.Settings.DFLTuserID
        Me.AppMyDFUpwd = My.Settings.DFLTUserpwd
    End Sub

    Public Sub SetConnByVal(ByVal SQDRvr As String, ByVal SQSrvr As String, ByVal SQDbase As String, ByVal SQUSER As String, ByVal SQPWD As String, ByVal SQTrust As Boolean, SQDflt As Boolean, ByVal appfirstrun As Boolean, ByVal DFLTuser As String, ByVal DFLTUPwd As String)
        Me.AppSqlODBCDriver = SQDRvr
        Me.AppMySqlServer = SQSrvr
        Me.AppMySqlDbase = SQDbase
        Me.AppMySqlUserID = SQUSER
        Me.AppMySqlPassword = SQPWD
        Me.AppMySqlTrusted = SQTrust
        Me.AppMySqlDefault = SQDflt
        Me.AppMyAPPFirstRun = appfirstrun
        Me.AppMyDFUser = DFLTuser
        Me.AppMyDFUpwd = DFLTUPwd
    End Sub

End Class


Public Class mytransRecord
    Private ptransacct As String
    Private ptransentid As Integer
    Private ptranstype As String
    Private ptransmode As String
    Private ptransFrom As String
    Private ptranspayto As String
    Private ptranspaytofor As String
    Private ptranscat As Integer
    Private ptranssubcat As Integer
    Private ptranssubcat2 As Integer
    Private ptransaentnum As String
    Private ptransdate As String
    Private ptransstat As String
    Private ptransamount As Double
    Private ptransowner As String
    Private ptransinformation As String
    Private ptransrecurr As Integer
    Private Pbalance As Double
    Private Popert As String
    Private Pmyid As Integer

    Public Sub New()   'parameterised constructor
        Console.WriteLine("My sqlConnect Object is being created")
    End Sub

    Protected Overrides Sub Finalize()  ' destructor
        Console.WriteLine("Object is being deleted")
    End Sub

    Public Property Transptransacct() As String
        Get
            Return ptransacct
        End Get
        Set(ByVal Value As String)
            ptransacct = Value
        End Set
    End Property

    Public Property Transptransentid() As String
        Get
            Return ptransentid
        End Get
        Set(ByVal Value As String)
            ptransentid = Value
        End Set
    End Property

    Public Property Transptranstype() As String
        Get
            Return ptranstype
        End Get
        Set(ByVal Value As String)
            ptranstype = Value
        End Set
    End Property

    Public Property Transptransmode() As String
        Get
            Return ptransmode
        End Get
        Set(ByVal Value As String)
            ptransmode = Value
        End Set
    End Property

    Public Property TransptransFrom() As String
        Get
            Return ptransFrom
        End Get
        Set(ByVal Value As String)
            ptransFrom = Value
        End Set
    End Property

    Public Property Transptranspayto() As String
        Get
            Return ptranspayto
        End Get
        Set(ByVal Value As String)
            ptranspayto = Value
        End Set
    End Property

    Public Property Transptranspaytofor() As String
        Get
            Return ptranspaytofor
        End Get
        Set(ByVal Value As String)
            ptranspaytofor = Value
        End Set
    End Property

    Public Property Transptranscat() As String
        Get
            Return ptranscat
        End Get
        Set(ByVal Value As String)
            ptranscat = Value
        End Set
    End Property

    Public Property Transptranssubcat() As String
        Get
            Return ptranssubcat
        End Get
        Set(ByVal Value As String)
            ptranssubcat = Value
        End Set
    End Property

    Public Property Transptranssubcat2() As String
        Get
            Return ptranssubcat2
        End Get
        Set(ByVal Value As String)
            ptranssubcat2 = Value
        End Set
    End Property

    Public Property Transptransaentnum() As String
        Get
            Return ptransaentnum
        End Get
        Set(ByVal Value As String)
            ptransaentnum = Value
        End Set
    End Property

    Public Property Transptransdate() As String
        Get
            Return ptransdate
        End Get
        Set(ByVal Value As String)
            ptransdate = Value
        End Set
    End Property

    Public Property Transptransstat() As String
        Get
            Return ptransstat
        End Get
        Set(ByVal Value As String)
            ptransstat = Value
        End Set
    End Property

    Public Property Transptransamount() As String
        Get
            Return ptransamount
        End Get
        Set(ByVal Value As String)
            ptransamount = Value
        End Set
    End Property

    Public Property Transptransowner() As String
        Get
            Return ptransowner
        End Get
        Set(ByVal Value As String)
            ptransowner = Value
        End Set
    End Property

    Public Property Transptransinformation() As String
        Get
            Return ptransinformation
        End Get
        Set(ByVal Value As String)
            ptransinformation = Value
        End Set
    End Property

    Public Property Transptransrecurr() As String
        Get
            Return ptransrecurr
        End Get
        Set(ByVal Value As String)
            ptransrecurr = Value
        End Set
    End Property

    Public Property TransPbalance() As String
        Get
            Return Pbalance
        End Get
        Set(ByVal Value As String)
            Pbalance = Value
        End Set
    End Property

    Public Property TransPopert() As String
        Get
            Return Popert
        End Get
        Set(ByVal Value As String)
            Popert = Value
        End Set

    End Property

    Public Property TransPmyid() As String
        Get
            Return Pmyid
        End Get
        Set(ByVal Value As String)
            Pmyid = Value
        End Set

    End Property

    '******************************************************************************************************************
    '* Create a class of transaction record.
    '******************************************************************************************************************
    Public Sub SettransByVal(ByVal inptransacct As String, ByVal inptransentid As Integer, ByVal inptranstype As String,
                             ByVal inptransmode As String, ByVal inptransFrom As String, ByVal inptranspayto As String,
                             ByVal inptranspaytofor As String, ByVal inptranscat As Integer, ByVal inptranssubcat As Integer, ByVal inptranssubcat2 As Integer,
                             ByVal inptransaentnum As String, ByVal inptransdate As String,
                             ByVal inptransstat As String, ByVal inptransamount As Double, ByVal inptransowner As String, ByVal inptransinformation As String,
                             ByVal inPbalance As Double, ByVal inpopert As String, ByVal inpmyid As Integer)

        Me.ptransacct = inptransacct
        Me.ptransentid = inptransentid
        Me.ptranstype = inptranstype
        Me.ptransmode = inptransmode
        Me.ptransFrom = inptransFrom
        Me.ptranspayto = inptranspayto
        Me.ptranspaytofor = inptranspaytofor
        Me.ptranscat = inptranscat
        Me.ptranssubcat = inptranssubcat
        Me.ptranssubcat2 = inptranssubcat2
        Me.ptransaentnum = inptransaentnum
        Me.ptransdate = inptransdate
        Me.ptransstat = inptransstat
        Me.ptransamount = inptransamount
        Me.ptransowner = inptransowner
        Me.ptransinformation = inptransinformation
        Me.ptransinformation = inptransinformation
        Me.Pbalance = inPbalance
        Me.Popert = inpopert
        Me.Pmyid = inpmyid

    End Sub

End Class