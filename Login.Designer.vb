<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtmsg = New System.Windows.Forms.TextBox()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.inPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbUsers = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdLogin = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbCompany = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'txtmsg
        '
        Me.txtmsg.BackColor = System.Drawing.SystemColors.Info
        Me.txtmsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmsg.ForeColor = System.Drawing.SystemColors.InfoText
        Me.txtmsg.Location = New System.Drawing.Point(59, 144)
        Me.txtmsg.Name = "txtmsg"
        Me.txtmsg.ReadOnly = True
        Me.txtmsg.Size = New System.Drawing.Size(249, 20)
        Me.txtmsg.TabIndex = 16
        Me.txtmsg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Location = New System.Drawing.Point(320, 2)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 15
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(133, 110)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(63, 22)
        Me.cmdExit.TabIndex = 14
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'inPassword
        '
        Me.inPassword.Location = New System.Drawing.Point(59, 44)
        Me.inPassword.Name = "inPassword"
        Me.inPassword.Size = New System.Drawing.Size(137, 20)
        Me.inPassword.TabIndex = 13
        Me.inPassword.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Password:"
        '
        'cmbUsers
        '
        Me.cmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsers.FormattingEnabled = True
        Me.cmbUsers.Location = New System.Drawing.Point(59, 5)
        Me.cmbUsers.Name = "cmbUsers"
        Me.cmbUsers.Size = New System.Drawing.Size(137, 21)
        Me.cmbUsers.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "User:"
        '
        'cmdLogin
        '
        Me.cmdLogin.Location = New System.Drawing.Point(59, 110)
        Me.cmdLogin.Name = "cmdLogin"
        Me.cmdLogin.Size = New System.Drawing.Size(63, 22)
        Me.cmdLogin.TabIndex = 9
        Me.cmdLogin.Text = "Login"
        Me.cmdLogin.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Company:"
        '
        'cmbCompany
        '
        Me.cmbCompany.FormattingEnabled = True
        Me.cmbCompany.Location = New System.Drawing.Point(59, 78)
        Me.cmbCompany.Name = "cmbCompany"
        Me.cmbCompany.Size = New System.Drawing.Size(249, 21)
        Me.cmbCompany.TabIndex = 18
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 168)
        Me.Controls.Add(Me.cmbCompany)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtmsg)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.inPassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbUsers)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdLogin)
        Me.Name = "Login"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtmsg As TextBox
    Friend WithEvents MonthCalendar1 As MonthCalendar
    Friend WithEvents cmdExit As Button
    Friend WithEvents inPassword As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbUsers As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdLogin As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbCompany As ComboBox
End Class
