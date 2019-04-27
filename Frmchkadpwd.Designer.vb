<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmchkadpwd
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.inmastpwd = New System.Windows.Forms.TextBox()
        Me.cmdchk = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter Mastwer Password:"
        '
        'inmastpwd
        '
        Me.inmastpwd.Location = New System.Drawing.Point(145, 6)
        Me.inmastpwd.Name = "inmastpwd"
        Me.inmastpwd.Size = New System.Drawing.Size(174, 20)
        Me.inmastpwd.TabIndex = 1
        '
        'cmdchk
        '
        Me.cmdchk.Location = New System.Drawing.Point(348, 6)
        Me.cmdchk.Name = "cmdchk"
        Me.cmdchk.Size = New System.Drawing.Size(82, 19)
        Me.cmdchk.TabIndex = 2
        Me.cmdchk.Text = "Process"
        Me.cmdchk.UseVisualStyleBackColor = True
        '
        'Frmchkadpwd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(454, 37)
        Me.Controls.Add(Me.cmdchk)
        Me.Controls.Add(Me.inmastpwd)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Frmchkadpwd"
        Me.Text = "Enter master Password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents inmastpwd As TextBox
    Friend WithEvents cmdchk As Button
End Class
