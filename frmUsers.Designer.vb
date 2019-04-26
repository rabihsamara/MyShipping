<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsers
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DataGridVWUsers = New System.Windows.Forms.DataGridView()
        Me.cmdNewUser = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.GBoxNewUser = New System.Windows.Forms.GroupBox()
        Me.cmdSaveNewUser = New System.Windows.Forms.Button()
        Me.cmdCanNewUser = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DateOfBirth = New System.Windows.Forms.DateTimePicker()
        Me.usrfname = New System.Windows.Forms.TextBox()
        Me.usrlname = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.usradd1 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.usradd2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridVWUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxNewUser.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGridVWUsers)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(539, 207)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Application Users"
        '
        'DataGridVWUsers
        '
        Me.DataGridVWUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridVWUsers.Location = New System.Drawing.Point(0, 19)
        Me.DataGridVWUsers.Name = "DataGridVWUsers"
        Me.DataGridVWUsers.Size = New System.Drawing.Size(533, 181)
        Me.DataGridVWUsers.TabIndex = 0
        '
        'cmdNewUser
        '
        Me.cmdNewUser.Location = New System.Drawing.Point(12, 12)
        Me.cmdNewUser.Name = "cmdNewUser"
        Me.cmdNewUser.Size = New System.Drawing.Size(77, 25)
        Me.cmdNewUser.TabIndex = 1
        Me.cmdNewUser.Text = "New User"
        Me.cmdNewUser.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(287, 13)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(78, 23)
        Me.cmdExit.TabIndex = 2
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'GBoxNewUser
        '
        Me.GBoxNewUser.Controls.Add(Me.ComboBox4)
        Me.GBoxNewUser.Controls.Add(Me.Label11)
        Me.GBoxNewUser.Controls.Add(Me.ComboBox3)
        Me.GBoxNewUser.Controls.Add(Me.Label10)
        Me.GBoxNewUser.Controls.Add(Me.TextBox2)
        Me.GBoxNewUser.Controls.Add(Me.Label9)
        Me.GBoxNewUser.Controls.Add(Me.ComboBox2)
        Me.GBoxNewUser.Controls.Add(Me.Label8)
        Me.GBoxNewUser.Controls.Add(Me.ComboBox1)
        Me.GBoxNewUser.Controls.Add(Me.Label7)
        Me.GBoxNewUser.Controls.Add(Me.usradd2)
        Me.GBoxNewUser.Controls.Add(Me.Label6)
        Me.GBoxNewUser.Controls.Add(Me.usradd1)
        Me.GBoxNewUser.Controls.Add(Me.Label5)
        Me.GBoxNewUser.Controls.Add(Me.usrlname)
        Me.GBoxNewUser.Controls.Add(Me.usrfname)
        Me.GBoxNewUser.Controls.Add(Me.DateOfBirth)
        Me.GBoxNewUser.Controls.Add(Me.Label4)
        Me.GBoxNewUser.Controls.Add(Me.Label3)
        Me.GBoxNewUser.Controls.Add(Me.Label2)
        Me.GBoxNewUser.Controls.Add(Me.TextBox1)
        Me.GBoxNewUser.Controls.Add(Me.Label1)
        Me.GBoxNewUser.Location = New System.Drawing.Point(3, 285)
        Me.GBoxNewUser.Name = "GBoxNewUser"
        Me.GBoxNewUser.Size = New System.Drawing.Size(539, 497)
        Me.GBoxNewUser.TabIndex = 3
        Me.GBoxNewUser.TabStop = False
        Me.GBoxNewUser.Text = "New User"
        '
        'cmdSaveNewUser
        '
        Me.cmdSaveNewUser.Location = New System.Drawing.Point(12, 256)
        Me.cmdSaveNewUser.Name = "cmdSaveNewUser"
        Me.cmdSaveNewUser.Size = New System.Drawing.Size(69, 22)
        Me.cmdSaveNewUser.TabIndex = 4
        Me.cmdSaveNewUser.Text = "Save User"
        Me.cmdSaveNewUser.UseVisualStyleBackColor = True
        '
        'cmdCanNewUser
        '
        Me.cmdCanNewUser.Location = New System.Drawing.Point(118, 258)
        Me.cmdCanNewUser.Name = "cmdCanNewUser"
        Me.cmdCanNewUser.Size = New System.Drawing.Size(71, 19)
        Me.cmdCanNewUser.TabIndex = 5
        Me.cmdCanNewUser.Text = "Cancel"
        Me.cmdCanNewUser.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User ID:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(71, 28)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(138, 20)
        Me.TextBox1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "First Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(226, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Last Name:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(216, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Date Of Birth:"
        '
        'DateOfBirth
        '
        Me.DateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateOfBirth.Location = New System.Drawing.Point(293, 28)
        Me.DateOfBirth.Name = "DateOfBirth"
        Me.DateOfBirth.Size = New System.Drawing.Size(107, 20)
        Me.DateOfBirth.TabIndex = 5
        '
        'usrfname
        '
        Me.usrfname.Location = New System.Drawing.Point(71, 65)
        Me.usrfname.Name = "usrfname"
        Me.usrfname.Size = New System.Drawing.Size(138, 20)
        Me.usrfname.TabIndex = 6
        '
        'usrlname
        '
        Me.usrlname.Location = New System.Drawing.Point(293, 62)
        Me.usrlname.Name = "usrlname"
        Me.usrlname.Size = New System.Drawing.Size(107, 20)
        Me.usrlname.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Address1:"
        '
        'usradd1
        '
        Me.usradd1.Location = New System.Drawing.Point(71, 93)
        Me.usradd1.Name = "usradd1"
        Me.usradd1.Size = New System.Drawing.Size(329, 20)
        Me.usradd1.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 130)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Address2:"
        '
        'usradd2
        '
        Me.usradd2.Location = New System.Drawing.Point(71, 127)
        Me.usradd2.Name = "usradd2"
        Me.usradd2.Size = New System.Drawing.Size(329, 20)
        Me.usradd2.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(42, 159)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "City:"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(71, 159)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(230, 21)
        Me.ComboBox1.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 192)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Prov./State:"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(71, 192)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(138, 21)
        Me.ComboBox2.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(216, 195)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Postal Code:"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(293, 195)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(87, 20)
        Me.TextBox2.TabIndex = 17
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(23, 225)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Country:"
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(71, 222)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(138, 21)
        Me.ComboBox3.TabIndex = 19
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(216, 225)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Security Level:"
        '
        'ComboBox4
        '
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"})
        Me.ComboBox4.Location = New System.Drawing.Point(293, 221)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(86, 21)
        Me.ComboBox4.TabIndex = 21
        '
        'frmUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FloralWhite
        Me.ClientSize = New System.Drawing.Size(1379, 794)
        Me.Controls.Add(Me.cmdCanNewUser)
        Me.Controls.Add(Me.cmdSaveNewUser)
        Me.Controls.Add(Me.GBoxNewUser)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdNewUser)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmUsers"
        Me.Text = "Users"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridVWUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxNewUser.ResumeLayout(False)
        Me.GBoxNewUser.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DataGridVWUsers As DataGridView
    Friend WithEvents cmdNewUser As Button
    Friend WithEvents cmdExit As Button
    Friend WithEvents GBoxNewUser As GroupBox
    Friend WithEvents cmdSaveNewUser As Button
    Friend WithEvents cmdCanNewUser As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents usradd2 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents usradd1 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents usrlname As TextBox
    Friend WithEvents usrfname As TextBox
    Friend WithEvents DateOfBirth As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents ComboBox4 As ComboBox
    Friend WithEvents Label11 As Label
End Class
