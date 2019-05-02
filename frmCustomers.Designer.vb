<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomers
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
        Me.GBSelect = New System.Windows.Forms.GroupBox()
        Me.SuspendLayout()
        '
        'GBSelect
        '
        Me.GBSelect.Location = New System.Drawing.Point(2, 3)
        Me.GBSelect.Name = "GBSelect"
        Me.GBSelect.Size = New System.Drawing.Size(1426, 80)
        Me.GBSelect.TabIndex = 0
        Me.GBSelect.TabStop = False
        Me.GBSelect.Text = "Select Customer"
        '
        'frmCustomers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1440, 821)
        Me.Controls.Add(Me.GBSelect)
        Me.Name = "frmCustomers"
        Me.Text = "Customers"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GBSelect As GroupBox
End Class
