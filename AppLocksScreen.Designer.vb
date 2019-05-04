<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AppLocksScreen
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
        Me.DataGridLocks = New System.Windows.Forms.DataGridView()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.lblsel = New System.Windows.Forms.Label()
        Me.sellock = New System.Windows.Forms.TextBox()
        Me.cmdRelease = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        CType(Me.DataGridLocks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridLocks
        '
        Me.DataGridLocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridLocks.Location = New System.Drawing.Point(3, 33)
        Me.DataGridLocks.Name = "DataGridLocks"
        Me.DataGridLocks.Size = New System.Drawing.Size(945, 331)
        Me.DataGridLocks.TabIndex = 0
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(3, 3)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(81, 24)
        Me.cmdExit.TabIndex = 1
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'lblsel
        '
        Me.lblsel.AutoSize = True
        Me.lblsel.Location = New System.Drawing.Point(112, 9)
        Me.lblsel.Name = "lblsel"
        Me.lblsel.Size = New System.Drawing.Size(79, 13)
        Me.lblsel.TabIndex = 2
        Me.lblsel.Text = "Selected Lock:"
        '
        'sellock
        '
        Me.sellock.Location = New System.Drawing.Point(197, 6)
        Me.sellock.Name = "sellock"
        Me.sellock.Size = New System.Drawing.Size(375, 20)
        Me.sellock.TabIndex = 3
        '
        'cmdRelease
        '
        Me.cmdRelease.Location = New System.Drawing.Point(589, 3)
        Me.cmdRelease.Name = "cmdRelease"
        Me.cmdRelease.Size = New System.Drawing.Size(82, 23)
        Me.cmdRelease.TabIndex = 4
        Me.cmdRelease.Text = "Release"
        Me.cmdRelease.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(700, 5)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(77, 21)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'AppLocksScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(952, 375)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdRelease)
        Me.Controls.Add(Me.sellock)
        Me.Controls.Add(Me.lblsel)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.DataGridLocks)
        Me.Name = "AppLocksScreen"
        Me.Text = "AppLocksScreen"
        CType(Me.DataGridLocks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridLocks As DataGridView
    Friend WithEvents cmdExit As Button
    Friend WithEvents lblsel As Label
    Friend WithEvents sellock As TextBox
    Friend WithEvents cmdRelease As Button
    Friend WithEvents cmdCancel As Button
End Class
