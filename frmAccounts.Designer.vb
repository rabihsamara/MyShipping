<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccounts
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.accountNO = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.accountName = New System.Windows.Forms.TextBox()
        Me.active = New System.Windows.Forms.CheckBox()
        Me.createdby = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.dateupdated = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.datecreated = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.cmdNew = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GroupBox1.Controls.Add(Me.cmdNew)
        Me.GroupBox1.Controls.Add(Me.createdby)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.dateupdated)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.datecreated)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.active)
        Me.GroupBox1.Controls.Add(Me.accountName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.accountNO)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(704, 233)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Account Info"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Account:"
        '
        'accountNO
        '
        Me.accountNO.Location = New System.Drawing.Point(51, 19)
        Me.accountNO.Name = "accountNO"
        Me.accountNO.Size = New System.Drawing.Size(111, 20)
        Me.accountNO.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Name:"
        '
        'accountName
        '
        Me.accountName.Location = New System.Drawing.Point(51, 45)
        Me.accountName.Name = "accountName"
        Me.accountName.Size = New System.Drawing.Size(252, 20)
        Me.accountName.TabIndex = 3
        '
        'active
        '
        Me.active.AutoSize = True
        Me.active.Location = New System.Drawing.Point(320, 46)
        Me.active.Name = "active"
        Me.active.Size = New System.Drawing.Size(56, 17)
        Me.active.TabIndex = 4
        Me.active.Text = "Active"
        Me.active.UseVisualStyleBackColor = True
        '
        'createdby
        '
        Me.createdby.BackColor = System.Drawing.SystemColors.Info
        Me.createdby.Enabled = False
        Me.createdby.Location = New System.Drawing.Point(256, 203)
        Me.createdby.Name = "createdby"
        Me.createdby.Size = New System.Drawing.Size(94, 20)
        Me.createdby.TabIndex = 29
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(199, 206)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(62, 13)
        Me.Label31.TabIndex = 28
        Me.Label31.Text = "Created By:"
        '
        'dateupdated
        '
        Me.dateupdated.BackColor = System.Drawing.SystemColors.Info
        Me.dateupdated.Enabled = False
        Me.dateupdated.Location = New System.Drawing.Point(75, 203)
        Me.dateupdated.Name = "dateupdated"
        Me.dateupdated.Size = New System.Drawing.Size(120, 20)
        Me.dateupdated.TabIndex = 27
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(0, 210)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(77, 13)
        Me.Label30.TabIndex = 26
        Me.Label30.Text = "Date Updated:"
        '
        'datecreated
        '
        Me.datecreated.BackColor = System.Drawing.SystemColors.Info
        Me.datecreated.Enabled = False
        Me.datecreated.Location = New System.Drawing.Point(75, 182)
        Me.datecreated.Name = "datecreated"
        Me.datecreated.Size = New System.Drawing.Size(120, 20)
        Me.datecreated.TabIndex = 25
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(5, 190)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(73, 13)
        Me.Label29.TabIndex = 24
        Me.Label29.Text = "Date Created:"
        '
        'cmdNew
        '
        Me.cmdNew.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.cmdNew.Location = New System.Drawing.Point(238, 15)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(65, 20)
        Me.cmdNew.TabIndex = 30
        Me.cmdNew.Text = "New"
        Me.cmdNew.UseVisualStyleBackColor = False
        '
        'frmAccounts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 236)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmAccounts"
        Me.Text = "Accounts"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents accountNO As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents active As CheckBox
    Friend WithEvents accountName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents createdby As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents dateupdated As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents datecreated As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents cmdNew As Button
End Class
