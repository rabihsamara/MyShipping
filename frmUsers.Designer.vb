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
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridVWUsers, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DataGridVWUsers As DataGridView
    Friend WithEvents cmdNewUser As Button
    Friend WithEvents cmdExit As Button
    Friend WithEvents GBoxNewUser As GroupBox
    Friend WithEvents cmdSaveNewUser As Button
    Friend WithEvents cmdCanNewUser As Button
End Class
