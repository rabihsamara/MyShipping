Imports System.Data.SqlClient

#Region "GLVARS"
Public Class GlobalVariables

    Public Shared Property Gl_ConnectionSTR As String
    Public Shared Property GL_DfltConnValues As MySQLConInfo = New MySQLConInfo()
    Public Shared Property GL_MySqlConn As SqlConnection
    Public Shared Property Gl_AppFirtR As Boolean
    Public Shared Property GL_DFLTMasterConn As masterconnrec = New masterconnrec()

    Public Shared Property Gl_LogUserID As String
    Public Shared Property Gl_UserIDLevel As String
    Public Shared Tmpuserrecord As userrec = New userrec()
    Public Shared TmpCusAcct As Accounts = New Accounts()

    Public Shared Property Gl_Company As String
    Public Shared Property Gl_SQLStr As String
    Public Shared Property GL_SLmsg As String
    Public Shared Property GL_Stat As Boolean
    Public Shared Property GL_Stattxt As String

    Public Shared Property GL_skipOnce As Boolean

    Public Shared Property Gl_tmpuserID As String
    Public Shared Property Gl_tmpfname As String
    Public Shared Property Gl_tmpfnameID As Integer
    Public Shared Property Gl_tmpactive As Integer

    Public Shared Property GL_SecContcalledBy As String
    Public Shared Property GL_mshow As Integer
    Public Shared Property GL_mactive As Integer
    Public Shared Property typeAR As String = "CheckBox,CheckedListBox,ComboBox,ListBox,ListView,Radio,Richtextbox,TextBox"

    Public Shared Property Gl_tmpcustid As String
    Public Shared Property Gl_tmpcustname As String
    Public Shared Property Gl_tmpacctID As Integer
    Public Shared Property Gl_tmpacctname As String
    'Customer screen
    Public Shared Property Gl_acctCallFrmID As String 'CE=customer existing account, CN=Customer New account, MM=menu call
    Public Shared Property Gl_OrdCallFrmID As String 'COE=customer existing Order, CN=Customer New Order, MM=menu call
    Public Shared Property Gl_SelOrder As Integer
    Public Shared Property Gl_SelOrderID As Integer

    '**************Datagrid rows per screen*********************************
    '* 1) Customers
    '*
    Public Shared Property GL_CSAcctsGridCNT As Integer
    Public Shared Property GL_CSOrdsGridCNT As Integer
    '* 2) Orders
    Public Shared Property GL_selOrdShipID As String
    Public Shared Property GL_selshpmethod As Integer
    Public Shared Property GL_cmbShpType As Integer

    '***********************************************************************
End Class
#End Region

#Region "TableClasses"
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

Public Class userrec

    Private userID As String
    Private Fname As String
    Private Lname As String
    Private DateOfBirth As Date
    Private Address1 As String
    Private Address2 As String
    Private City As String
    Private Province As String
    Private Pcode As String
    Private Country As String
    Private Active As Integer
    Private usrPassword As String
    Private usrmode As String
    Private usrseclvl As Integer

    Public Sub New()   'parameterised constructor
        Console.WriteLine("My sqlConnect Object is being created")
    End Sub

    Protected Overrides Sub Finalize()  ' destructor
        Console.WriteLine("Object is being deleted")
    End Sub

    Public Property MyUserID() As String
        Get
            Return userID
        End Get
        Set(ByVal Value As String)
            userID = Value
        End Set
    End Property


    Public Property MyFname() As String
        Get
            Return Fname
        End Get
        Set(ByVal Value As String)
            Fname = Value
        End Set
    End Property

    Public Property MyLname() As String
        Get
            Return Lname
        End Get
        Set(ByVal Value As String)
            Lname = Value
        End Set
    End Property

    Public Property MyDateOfBirth() As Date
        Get
            Return DateOfBirth
        End Get
        Set(ByVal Value As Date)
            DateOfBirth = Value
        End Set
    End Property

    Public Property MyAddress1() As String
        Get
            Return Address1
        End Get
        Set(ByVal Value As String)
            Address1 = Value
        End Set
    End Property

    Public Property MyAddress2() As String
        Get
            Return Address2
        End Get
        Set(ByVal Value As String)
            Address2 = Value
        End Set
    End Property

    Public Property MyCity() As String
        Get
            Return City
        End Get
        Set(ByVal Value As String)
            City = Value
        End Set
    End Property

    Public Property MyProvince() As String
        Get
            Return Province
        End Get
        Set(ByVal Value As String)
            Province = Value
        End Set
    End Property

    Public Property MyPcode() As String
        Get
            Return Pcode
        End Get
        Set(ByVal Value As String)
            Pcode = Value
        End Set
    End Property

    Public Property MyCountry() As String
        Get
            Return Country
        End Get
        Set(ByVal Value As String)
            Country = Value
        End Set
    End Property

    Public Property MyActive() As Integer
        Get
            Return Active
        End Get
        Set(ByVal Value As Integer)
            Active = Value
        End Set
    End Property

    Public Property MyusrPassword() As String
        Get
            Return usrPassword
        End Get
        Set(ByVal Value As String)
            usrPassword = Value
        End Set
    End Property

    Public Property Myusrmode() As String
        Get
            Return usrmode
        End Get
        Set(ByVal Value As String)
            usrmode = Value
        End Set
    End Property

    Public Property Myusrseclvl() As Integer
        Get
            Return usrseclvl
        End Get
        Set(ByVal Value As Integer)
            usrseclvl = Value
        End Set
    End Property

    Public Sub setUsers(tUserID, tFname, tLname, tDateOfBirth, tAddress1, tAddress2, tCity, tProvince, tPcode, tCountry, tActive, tusrPassword, tusrmode, tusrseclvl)

        Me.MyUserID = tUserID
        Me.MyFname = tFname
        Me.MyLname = tLname
        Me.MyDateOfBirth = tDateOfBirth
        Me.MyAddress1 = tAddress1
        Me.MyAddress2 = tAddress2
        Me.MyCity = tCity
        Me.MyProvince = tProvince
        Me.MyPcode = tPcode
        Me.MyCountry = tCountry
        Me.MyActive = tActive
        'Me.MyusrPassword = tusrPassword
        Me.Myusrmode = tusrmode
        Me.Myusrseclvl = tusrseclvl

    End Sub

End Class

Public Class mymisc1

    Private myFormArray As New ArrayList

    Public Property Myfrms() As ArrayList
        Get
            Dim myAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
            Dim types As Type() = myAssembly.GetTypes()
            For Each myType In types
                If Not IsNothing(myType.BaseType) Then
                    If myType.BaseType.FullName = "System.Windows.Forms.Form" Then
                        myFormArray.Add(Trim(myType.Name))
                    End If
                End If
            Next
            Return myFormArray
        End Get
        Set(ByVal Value As ArrayList)
            myFormArray = Value
        End Set
    End Property

    Public Sub New()   'parameterised constructor
        Console.WriteLine("My sqlConnect Object is being created")
    End Sub

    Protected Overrides Sub Finalize()  ' destructor
        Console.WriteLine("Object is being deleted")
    End Sub

End Class

Public Class Customers

    Private CustID As String
    Private CIName As String
    Private CIadd1 As String
    Private CIAdd2 As String
    Private cmbCICity As String
    Private CIpcode As String
    Private cmbCIProv As String
    Private cmbCICountry As String
    Private cmbCustType As String
    Private chCIactive As String

    Private BLName As String
    Private BLadd1 As String
    Private BLadd2 As String
    Private cmbBLcity As String
    Private BLpcode As String
    Private cmbBLProv As String
    Private cmbBLCountry As String

    Private cmbShpID As String
    Private SHName As String
    Private SHadd1 As String
    Private SHadd2 As String
    Private cmbSHCity As String
    Private SHPcode As String
    Private cmbSHProv As String
    Private cmbSHCountry As String
    Private dtcreated As DateTime
    Private dtupdated As DateTime
    Private CScreatedby As String

    Public Sub New() 'parameterised constructor
        Console.WriteLine("Class created")
    End Sub

    Protected Overrides Sub Finalize()  ' destructor
        Console.WriteLine("Class destroyed")
    End Sub

    Public Property MyCustID() As String

        Get
            Return CustID
        End Get
        Set(ByVal Value As String)
            CustID = Value
        End Set

    End Property

    Public Property MyCIName() As String

        Get
            Return CIName
        End Get
        Set(ByVal Value As String)
            CIName = Value
        End Set

    End Property

    Public Property MyCIadd1() As String

        Get
            Return CIadd1
        End Get
        Set(ByVal Value As String)
            CIadd1 = Value
        End Set

    End Property

    Public Property MyCIAdd2() As String

        Get
            Return CIAdd2
        End Get
        Set(ByVal Value As String)
            CIAdd2 = Value
        End Set

    End Property

    Public Property MycmbCICity() As String

        Get
            Return cmbCICity
        End Get
        Set(ByVal Value As String)
            cmbCICity = Value
        End Set

    End Property

    Public Property MyCIpcode() As String

        Get
            Return CIpcode
        End Get
        Set(ByVal Value As String)
            CIpcode = Value
        End Set

    End Property

    Public Property MycmbCIProv() As String

        Get
            Return cmbCIProv
        End Get
        Set(ByVal Value As String)
            cmbCIProv = Value
        End Set

    End Property

    Public Property MycmbCICountry() As String

        Get
            Return cmbCICountry
        End Get
        Set(ByVal Value As String)
            cmbCICountry = Value
        End Set

    End Property

    Public Property MycmbCustType() As String

        Get
            Return cmbCustType
        End Get
        Set(ByVal Value As String)
            cmbCustType = Value
        End Set

    End Property

    Public Property MychCIactive() As String

        Get
            Return chCIactive
        End Get
        Set(ByVal Value As String)
            chCIactive = Value
        End Set

    End Property

    Public Property MyBLName() As String
        Get
            Return BLName
        End Get

        Set(ByVal Value As String)
            BLName = Value
        End Set

    End Property

    Public Property MyBLadd1() As String

        Get
            Return BLadd1
        End Get
        Set(ByVal Value As String)
            BLadd1 = Value
        End Set

    End Property

    Public Property MyBLadd2() As String

        Get
            Return BLadd2
        End Get
        Set(ByVal Value As String)
            BLadd2 = Value
        End Set

    End Property

    Public Property MycmbBLcity() As String

        Get
            Return cmbBLcity
        End Get
        Set(ByVal Value As String)
            cmbBLcity = Value
        End Set

    End Property

    Public Property MyBLpcode() As String

        Get
            Return BLpcode
        End Get
        Set(ByVal Value As String)
            BLpcode = Value
        End Set

    End Property

    Public Property MycmbBLProv() As String

        Get
            Return cmbBLProv
        End Get
        Set(ByVal Value As String)
            cmbBLProv = Value
        End Set

    End Property

    Public Property MycmbBLCountry() As String

        Get
            Return cmbBLCountry
        End Get
        Set(ByVal Value As String)
            cmbBLCountry = Value
        End Set

    End Property

    Public Property MycmbShpID() As String

        Get
            Return cmbShpID
        End Get
        Set(ByVal Value As String)
            cmbShpID = Value
        End Set

    End Property

    Public Property MySHName() As String

        Get
            Return SHName
        End Get
        Set(ByVal Value As String)
            SHName = Value
        End Set

    End Property

    Public Property MySHadd1() As String

        Get
            Return SHadd1
        End Get
        Set(ByVal Value As String)
            SHadd1 = Value
        End Set

    End Property

    Public Property MySHadd2() As String

        Get
            Return SHadd2
        End Get

        Set(ByVal Value As String)
            SHadd2 = Value
        End Set

    End Property

    Public Property MycmbSHCity() As String

        Get
            Return cmbSHCity
        End Get
        Set(ByVal Value As String)
            cmbSHCity = Value
        End Set

    End Property

    Public Property MySHPcode() As String

        Get
            Return SHPcode
        End Get
        Set(ByVal Value As String)
            SHPcode = Value
        End Set

    End Property

    Public Property MycmbSHProv() As String

        Get
            Return cmbSHProv
        End Get
        Set(ByVal Value As String)
            cmbSHProv = Value
        End Set

    End Property

    Public Property MycmbSHCountry() As String

        Get
            Return cmbSHCountry
        End Get
        Set(ByVal Value As String)
            cmbSHCountry = Value
        End Set

    End Property

    Public Property Mydatecreated() As DateTime

        Get
            Return dtcreated
        End Get
        Set(ByVal Value As DateTime)
            dtcreated = Value
        End Set

    End Property

    Public Property Mydateupdated() As DateTime

        Get
            Return dtupdated
        End Get
        Set(ByVal Value As DateTime)
            dtupdated = Value
        End Set

    End Property

    Public Property MyCScreatedby() As String

        Get
            Return CScreatedby
        End Get
        Set(ByVal Value As String)
            CScreatedby = Value
        End Set

    End Property

End Class

Public Class shipto

    Private ID As Integer
    Private ShipCustID As String
    Private ShiptoID As String
    Private ShipName As String
    Private Shipadd1 As String
    Private Shipadd2 As String
    Private Shipcity As String
    Private Shipprov As String
    Private Shippcode As String
    Private Shipcountry As String
    Private ShipDflt As String
    Private active As Integer
    Private dtcreated As DateTime
    Private dtupdated As DateTime
    Private Shcreatedby As String

    Public Sub New() 'parameterised constructor

        Console.WriteLine("Class Created")

    End Sub

    Protected Overrides Sub Finalize()  ' destructor

        Console.WriteLine("Class destroyed")

    End Sub

    Public Property MyID() As Integer
        Get
            Return ID
        End Get
        Set(ByVal Value As Integer)
            ID = Value
        End Set

    End Property

    Public Property MyShipCustID() As String

        Get
            Return ShipCustID
        End Get
        Set(ByVal Value As String)
            ShipCustID = Value
        End Set

    End Property

    Public Property MyShiptoID() As String

        Get
            Return ShiptoID
        End Get
        Set(ByVal Value As String)
            ShiptoID = Value
        End Set

    End Property

    Public Property MyShipName() As String

        Get
            Return ShipName
        End Get
        Set(ByVal Value As String)
            ShipName = Value
        End Set

    End Property

    Public Property MyShipadd1() As String

        Get
            Return Shipadd1
        End Get
        Set(ByVal Value As String)
            Shipadd1 = Value
        End Set

    End Property

    Public Property MyShipadd2() As String

        Get
            Return Shipadd2
        End Get
        Set(ByVal Value As String)
            Shipadd2 = Value
        End Set

    End Property

    Public Property MyShipcity() As String

        Get
            Return Shipcity
        End Get
        Set(ByVal Value As String)
            Shipcity = Value
        End Set

    End Property

    Public Property MyShipprov() As String

        Get
            Return Shipprov
        End Get

        Set(ByVal Value As String)
            Shipprov = Value
        End Set

    End Property

    Public Property MyShippcode() As String

        Get
            Return Shippcode
        End Get
        Set(ByVal Value As String)
            Shippcode = Value
        End Set

    End Property

    Public Property MyShipcountry() As String

        Get
            Return Shipcountry
        End Get
        Set(ByVal Value As String)
            Shipcountry = Value
        End Set

    End Property

    Public Property MyShipDflt() As String

        Get
            Return ShipDflt
        End Get
        Set(ByVal Value As String)
            ShipDflt = Value
        End Set

    End Property

    Public Property Myactive() As String

        Get
            Return active
        End Get
        Set(ByVal Value As String)
            active = Value
        End Set

    End Property

    Public Property Mydatecreated() As DateTime

        Get
            Return dtcreated
        End Get
        Set(ByVal Value As DateTime)
            dtcreated = Value
        End Set

    End Property

    Public Property Mydateupdated() As DateTime

        Get
            Return dtupdated
        End Get
        Set(ByVal Value As DateTime)
            dtupdated = Value
        End Set

    End Property

    Public Property MyShcreatedby() As String

        Get
            Return Shcreatedby
        End Get
        Set(ByVal Value As String)
            Shcreatedby = Value
        End Set

    End Property

End Class

Public Class Accounts

    Private ID As Integer
    Private CustNo As String
    Private AccountNo As String
    Private AccountName As String
    Private active As Integer
    Private datecreated As DateTime
    Private dateupdated As DateTime
    Private CreatedBy As String

    Public Sub New() 'parameterised constructor

        Console.WriteLine("")

    End Sub

    Protected Overrides Sub Finalize()  ' destructor

        Console.WriteLine("")

    End Sub

    Public Property MyID() As Integer

        Get
            Return ID
        End Get
        Set(ByVal Value As Integer)
            ID = Value
        End Set

    End Property

    Public Property MyCustNo() As String

        Get
            Return CustNo
        End Get
        Set(ByVal Value As String)
            CustNo = Value
        End Set

    End Property

    Public Property MyAccountNo() As String

        Get
            Return AccountNo
        End Get
        Set(ByVal Value As String)
            AccountNo = Value
        End Set

    End Property

    Public Property MyAccountName() As String

        Get
            Return AccountName
        End Get
        Set(ByVal Value As String)
            AccountName = Value
        End Set

    End Property

    Public Property Myactive() As Integer

        Get
            Return active
        End Get
        Set(ByVal Value As Integer)
            active = Value
        End Set

    End Property

    Public Property Mydatecreated() As DateTime

        Get
            Return datecreated
        End Get
        Set(ByVal Value As DateTime)
            datecreated = Value
        End Set

    End Property

    Public Property Mydateupdated() As DateTime

        Get
            Return dateupdated
        End Get
        Set(ByVal Value As DateTime)
            dateupdated = Value
        End Set

    End Property

    Public Property MyCreatedBy() As String

        Get
            Return CreatedBy
        End Get
        Set(ByVal Value As String)
            CreatedBy = Value
        End Set

    End Property

End Class

Public Class Orders

    Private ID As Integer
    Private CustNo As String
    Private AccountNo As String
    Private OrderNO As Integer
    Private ordStat As String
    Private cmbShpType As String
    Private cmbshpmethod As String
    Private orshipID As String
    Private cmbShpID As String
    Private SHName As String
    Private SHadd1 As String
    Private SHadd2 As String
    Private cmbSHCity As String
    Private SHPcode As String
    Private cmbSHProv As String
    Private cmbSHCountry As String
    Private BLName As String
    Private BLadd1 As String
    Private BLadd2 As String
    Private cmbBLcity As String
    Private BLpcode As String
    Private cmbBLProv As String
    Private cmbBLCountry As String
    Private datecreated As DateTime
    Private dateupdated As DateTime
    Private CreatedBy As String

    Public Sub New() 'parameterised constructor

        Console.WriteLine("Class Created")

    End Sub

    Protected Overrides Sub Finalize()  ' destructor

        Console.WriteLine("Class Destructed")

    End Sub

    Public Property MyID() As Integer

        Get
            Return ID
        End Get
        Set(ByVal Value As Integer)
            ID = Value
        End Set

    End Property

    Public Property MyCustNo() As String

        Get
            Return CustNo
        End Get
        Set(ByVal Value As String)
            CustNo = Value
        End Set

    End Property

    Public Property MyAccountNo() As String

        Get
            Return AccountNo
        End Get
        Set(ByVal Value As String)
            AccountNo = Value
        End Set

    End Property

    Public Property MyOrderNO() As Integer

        Get
            Return OrderNO
        End Get
        Set(ByVal Value As Integer)
            OrderNO = Value
        End Set

    End Property

    Public Property MyordStat() As String

        Get
            Return ordStat
        End Get
        Set(ByVal Value As String)
            ordStat = Value
        End Set

    End Property

    Public Property MycmbShpType() As String

        Get
            Return cmbShpType
        End Get
        Set(ByVal Value As String)
            cmbShpType = Value
        End Set

    End Property

    Public Property Mycmbshpmethod() As String

        Get
            Return cmbshpmethod
        End Get
        Set(ByVal Value As String)
            cmbshpmethod = Value
        End Set

    End Property

    Public Property MyorshipID() As String

        Get
            Return orshipID
        End Get
        Set(ByVal Value As String)
            orshipID = Value
        End Set

    End Property

    Public Property MySHName() As String

        Get
            Return SHName
        End Get
        Set(ByVal Value As String)
            SHName = Value
        End Set

    End Property

    Public Property MySHadd1() As String

        Get
            Return SHadd1
        End Get
        Set(ByVal Value As String)
            SHadd1 = Value
        End Set

    End Property

    Public Property MySHadd2() As String

        Get
            Return SHadd2
        End Get

        Set(ByVal Value As String)
            SHadd2 = Value
        End Set

    End Property

    Public Property MycmbSHCity() As String

        Get
            Return cmbSHCity
        End Get
        Set(ByVal Value As String)
            cmbSHCity = Value
        End Set

    End Property

    Public Property MySHPcode() As String

        Get
            Return SHPcode
        End Get
        Set(ByVal Value As String)
            SHPcode = Value
        End Set

    End Property

    Public Property MycmbSHProv() As String

        Get
            Return cmbSHProv
        End Get
        Set(ByVal Value As String)
            cmbSHProv = Value
        End Set

    End Property

    Public Property MycmbSHCountry() As String

        Get
            Return cmbSHCountry
        End Get
        Set(ByVal Value As String)
            cmbSHCountry = Value
        End Set

    End Property

    Public Property MyBLName() As String

        Get
            Return BLName
        End Get
        Set(ByVal Value As String)
            BLName = Value
        End Set

    End Property

    Public Property MyBLadd1() As String

        Get
            Return BLadd1
        End Get
        Set(ByVal Value As String)
            BLadd1 = Value
        End Set

    End Property

    Public Property MyBLadd2() As String

        Get
            Return BLadd2
        End Get
        Set(ByVal Value As String)
            BLadd2 = Value
        End Set

    End Property

    Public Property MycmbBLcity() As String

        Get
            Return cmbBLcity
        End Get
        Set(ByVal Value As String)
            cmbBLcity = Value
        End Set

    End Property

    Public Property MyBLpcode() As String
        Get
            Return BLpcode
        End Get
        Set(ByVal Value As String)
            BLpcode = Value
        End Set

    End Property

    Public Property MycmbBLProv() As String
        Get

            Return cmbBLProv
        End Get
        Set(ByVal Value As String)
            cmbBLProv = Value
        End Set

    End Property

    Public Property MycmbBLCountry() As String

        Get
            Return cmbBLCountry
        End Get
        Set(ByVal Value As String)
            cmbBLCountry = Value
        End Set

    End Property

    Public Property Mydatecreated() As DateTime

        Get
            Return datecreated
        End Get
        Set(ByVal Value As DateTime)
            datecreated = Value
        End Set

    End Property

    Public Property Mydateupdated() As DateTime

        Get
            Return dateupdated
        End Get
        Set(ByVal Value As DateTime)
            dateupdated = Value
        End Set

    End Property

    Public Property MyCreatedBy() As String

        Get
            Return CreatedBy
        End Get
        Set(ByVal Value As String)
            CreatedBy = Value
        End Set

    End Property

End Class

Public Class ordstatus

    Private ID As String
    Private ordstatshort As String
    Private ordstatfull As String

    Public Sub New() 'parameterised constructor

        Console.WriteLine("Class Created")

    End Sub

    Protected Overrides Sub Finalize()  ' destructor

        Console.WriteLine("Class destroyed")

    End Sub

    Public Property MyID() As String

        Get
            Return ID
        End Get
        Set(ByVal Value As String)
            ID = Value
        End Set

    End Property

    Public Property Myordstatshort() As String

        Get
            Return ordstatshort
        End Get
        Set(ByVal Value As String)
            ordstatshort = Value
        End Set

    End Property

    Public Property Myordstatfull() As String

        Get
            Return ordstatfull
        End Get
        Set(ByVal Value As String)
            ordstatfull = Value
        End Set

    End Property

End Class

#End Region
