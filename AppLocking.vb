﻿Imports System.Data.SqlClient

Module AppLocking

    Public Class AppLocks

        Private ID As String
        Private Userid As String
        Private Formname As String
        Private ctrlname As String
        Private ctrlvalue As String
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
                        AppLockings.Myctrlopert = myReader.GetString(5)
                        AppLockings.Mylockeddate = myReader.GetDateTime(6)
                        GetLockRec = AppLockings
                        GlobalVariables.GL_Stat = True
                    End If
                Loop

            Catch ex As Exception
                MsgBox(ex.ToString)
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
    Public Function WriteDelLock(ByVal inoper As String, ByVal infrmName As String, ByVal inctrlName As String, ByVal inctrlval As String, ByVal inwrupd As String) As Boolean

        WriteDelLock = True
        'WriteDelLock("W", "Customer", "Customer", selcustid, seluw2) = False) Then 'lock it
        If (inoper = "W") Then
            GlobalVariables.Gl_SQLStr = "insert into AppLocks (Userid,Formname,ctrlname,ctrlvalue,ctrlopert,lockeddate) values ('" & GlobalVariables.Gl_LogUserID & "','" & infrmName & "','" & inctrlName & "','" & inctrlval & "','" & inwrupd & "','" & Now() & "')"
            If (ModMisc.ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                WriteDelLock = False
            End If
        ElseIf (inoper = "D") Then
            GlobalVariables.Gl_SQLStr = "delete from AppLocks where Userid = '" & GlobalVariables.Gl_LogUserID & "',' and Formname = '" & infrmName & ", and ctrlname = " & inctrlName & "'"
            If (ModMisc.ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
                WriteDelLock = False
            End If
        End If

    End Function

End Module
