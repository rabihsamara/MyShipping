Imports System.Data.SqlClient

Module AppLocking

    Public Class AppLocks

        Private ID As String
        Private Userid As String
        Private Formname As String
        Private ctrlname As String
        Private ctrlvalue As String
        Private ctrl2name As String
        Private ctrl2value As String
        Private ctrl3name As String
        Private ctrl3value As String
        Private ctrlopert As String
        Private lockeddate As DateTime

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

        Public Property MyUserid() As String
            Get
                Return Userid
            End Get
            Set(ByVal Value As String)
                Userid = Value
            End Set
        End Property

        Public Property MyFormname() As String
            Get
                Return Formname
            End Get
            Set(ByVal Value As String)
                Formname = Value
            End Set
        End Property

        Public Property Myctrlname() As String
            Get
                Return ctrlname
            End Get
            Set(ByVal Value As String)
                ctrlname = Value
            End Set
        End Property

        Public Property Myctrlvalue() As String
            Get
                Return ctrlvalue
            End Get
            Set(ByVal Value As String)
                ctrlvalue = Value
            End Set
        End Property

        Public Property Myctrl2name() As String
            Get
                Return ctrl2name
            End Get
            Set(ByVal Value As String)
                ctrl2name = Value
            End Set
        End Property

        Public Property Myctrl2value() As String
            Get
                Return ctrl2value
            End Get
            Set(ByVal Value As String)
                ctrl2value = Value
            End Set
        End Property

        Public Property Myctrl3name() As String
            Get
                Return ctrl3name
            End Get
            Set(ByVal Value As String)
                ctrl3name = Value
            End Set
        End Property

        Public Property Myctrl3value() As String
            Get
                Return ctrl3value
            End Get
            Set(ByVal Value As String)
                ctrl3value = Value
            End Set
        End Property

        Public Property Myctrlopert() As String
            Get
                Return ctrlopert
            End Get
            Set(ByVal Value As String)
                ctrlopert = Value
            End Set
        End Property

        Public Property Mylockeddate() As DateTime
            Get
                Return lockeddate
            End Get
            Set(ByVal Value As DateTime)
                lockeddate = Value
            End Set
        End Property

    End Class

    Public Function GetLockRec(ByVal inopt As String) As Object

        Dim myCmd As SqlCommand
        Dim myReader As SqlDataReader = Nothing
        Dim AppLockings As AppLocks = New AppLocks()

        GlobalVariables.GL_Stat = False
        GetLockRec = Nothing

        Using mysqlConn As New SqlConnection(GlobalVariables.Gl_ConnectionSTR)
            Try
                myCmd = mysqlConn.CreateCommand
                myCmd.CommandText = GlobalVariables.Gl_SQLStr
                mysqlConn.Open()

                myReader = myCmd.ExecuteReader()
                Do While myReader.Read()
                    If (inopt = "APPL") Then
                        AppLockings.MyID = myReader.GetValue(0)
                        AppLockings.MyUserid = myReader.GetString(1)
                        AppLockings.MyFormname = myReader.GetString(2)
                        AppLockings.Myctrlname = myReader.GetString(3)
                        AppLockings.Myctrlvalue = myReader.GetString(4)
                        AppLockings.Myctrl2name = myReader.GetString(5)
                        AppLockings.Myctrl2value = myReader.GetString(6)
                        AppLockings.Myctrl3name = myReader.GetString(7)
                        AppLockings.Myctrl3value = myReader.GetString(8)
                        AppLockings.Myctrlopert = myReader.GetString(9)
                        AppLockings.Mylockeddate = myReader.GetDateTime(10)
                        GetLockRec = AppLockings
                        GlobalVariables.GL_Stat = True
                    End If
                Loop

            Catch ex As Exception
                MsgBox(ex.ToString)
                GlobalVariables.GL_Stat = False
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

    'inoper - W=Write, D=Delete log.
    Public Function WriteDelLock(ByVal inoper As String, Optional slid As Integer = 0, Optional ByVal infrmName As String = "",
                                 Optional ByVal inctrlName As String = "", Optional ByVal inctrlval As String = "",
                                 Optional ByVal inctrl2Name As String = "", Optional ByVal inctrl2val As String = "",
                                 Optional ByVal inctrl3Name As String = "", Optional ByVal inctrl3val As String = "",
                                 Optional ByVal inwrupd As String = "") As Boolean

        WriteDelLock = True

        If (inoper = "W") Then
            GlobalVariables.Gl_SQLStr = "insert into AppLocks (Userid,Formname,ctrlname,ctrlvalue,ctrl2name,ctrl2value,ctrl3name,ctrl3value,ctrlopert,lockeddate) values ('" & GlobalVariables.Gl_LogUserID & "','" & infrmName & "','" & inctrlName & "','" & inctrlval & "','" & inctrl2Name & "','" & inctrl2val & "','" & inctrl3Name & "','" & inctrl3val & "','" & inwrupd & "','" & Now() & "')"
            If (ModMisc.ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                WriteDelLock = False
            End If
        ElseIf (inoper = "D") Then
            If (slid <> 0) Then
                GlobalVariables.Gl_SQLStr = "delete from AppLocks where ID = " & slid
            Else
                GlobalVariables.Gl_SQLStr = "delete from AppLocks where Userid = '" & GlobalVariables.Gl_LogUserID & "' and Formname = '" & infrmName & "' and ctrlname = '" & inctrlName & "' and ctrlvalue = '" & inctrlval & "'"
                If (inctrl2Name <> "") Then
                    GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & " and ctrl2name = '" & inctrl2Name & "' and ctrl2value = '" & inctrl2val & "'"
                End If
                If (inctrl3Name <> "") Then
                    GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & " and ctrl3name = '" & inctrl3Name & "' and ctrl3value = " & inctrl3val
                End If
            End If
            If (ModMisc.ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                WriteDelLock = False
            End If
        End If

    End Function

End Module
