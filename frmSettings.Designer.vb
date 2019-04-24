<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmsettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.DatGridMaster = New System.Windows.Forms.DataGridView()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridCompany = New System.Windows.Forms.DataGridView()
        Me.cmdSaveComp = New System.Windows.Forms.Button()
        CType(Me.DatGridMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DatGridMaster
        '
        Me.DatGridMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DatGridMaster.Location = New System.Drawing.Point(528, 61)
        Me.DatGridMaster.Name = "DatGridMaster"
        Me.DatGridMaster.Size = New System.Drawing.Size(804, 238)
        Me.DatGridMaster.TabIndex = 7
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(125, 2)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(65, 28)
        Me.cmdExit.TabIndex = 6
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(12, 2)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(82, 28)
        Me.cmdSave.TabIndex = 5
        Me.cmdSave.Text = "Save Settings"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Location = New System.Drawing.Point(-1, 36)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(523, 263)
        Me.PropertyGrid1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 307)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Company Information"
        '
        'DataGridCompany
        '
        Me.DataGridCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridCompany.Location = New System.Drawing.Point(-1, 329)
        Me.DataGridCompany.Name = "DataGridCompany"
        Me.DataGridCompany.Size = New System.Drawing.Size(1333, 372)
        Me.DataGridCompany.TabIndex = 9
        '
        'cmdSaveComp
        '
        Me.cmdSaveComp.Location = New System.Drawing.Point(135, 304)
        Me.cmdSaveComp.Name = "cmdSaveComp"
        Me.cmdSaveComp.Size = New System.Drawing.Size(102, 19)
        Me.cmdSaveComp.TabIndex = 10
        Me.cmdSaveComp.Text = "Save Companies"
        Me.cmdSaveComp.UseVisualStyleBackColor = True
        '
        'frmsettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1335, 705)
        Me.Controls.Add(Me.cmdSaveComp)
        Me.Controls.Add(Me.DataGridCompany)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DatGridMaster)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.PropertyGrid1)
        Me.Name = "frmsettings"
        Me.Text = "frmSettings"
        CType(Me.DatGridMaster, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridCompany, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DatGridMaster As DataGridView
    Friend WithEvents cmdExit As Button
    Friend WithEvents cmdSave As Button
    Friend WithEvents PropertyGrid1 As PropertyGrid
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridCompany As DataGridView
    Friend WithEvents cmdSaveComp As Button
End Class
