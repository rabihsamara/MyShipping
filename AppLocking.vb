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

End Module
