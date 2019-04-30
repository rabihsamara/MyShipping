<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControls
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
        Me.dspuserdID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dpsfname = New System.Windows.Forms.TextBox()
        Me.DataGridDspCont = New System.Windows.Forms.DataGridView()
        Me.cmdExit = New System.Windows.Forms.Button()
        CType(Me.DataGridDspCont, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "UserID:"
        '
        'dspuserdID
        '
        Me.dspuserdID.Enabled = False
        Me.dspuserdID.Location = New System.Drawing.Point(61, 6)
        Me.dspuserdID.Name = "dspuserdID"
        Me.dspuserdID.ReadOnly = True
        Me.dspuserdID.Size = New System.Drawing.Size(147, 20)
        Me.dspuserdID.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(214, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "FormName:"
        '
        'dpsfname
        '
        Me.dpsfname.Enabled = False
        Me.dpsfname.Location = New System.Drawing.Point(281, 6)
        Me.dpsfname.Name = "dpsfname"
        Me.dpsfname.ReadOnly = True
        Me.dpsfname.Size = New System.Drawing.Size(161, 20)
        Me.dpsfname.TabIndex = 3
        '
        'DataGridDspCont
        '
        Me.DataGridDspCont.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridDspCont.Location = New System.Drawing.Point(12, 32)
        Me.DataGridDspCont.Name = "DataGridDspCont"
        Me.DataGridDspCont.Size = New System.Drawing.Size(1107, 575)
        Me.DataGridDspCont.TabIndex = 4
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(736, 3)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(97, 25)
        Me.cmdExit.TabIndex = 5
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'frmControls
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1355, 744)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.DataGridDspCont)
        Me.Controls.Add(Me.dpsfname)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dspuserdID)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmControls"
        Me.Text = "frmControls"
        CType(Me.DataGridDspCont, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents dspuserdID As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dpsfname As TextBox
    Friend WithEvents DataGridDspCont As DataGridView
    Friend WithEvents cmdExit As Button
End Class
