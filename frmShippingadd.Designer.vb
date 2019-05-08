<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShippingadd
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
        Me.dspidname = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.cmdNew = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.GPshpAdd = New System.Windows.Forms.GroupBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.chactive = New System.Windows.Forms.CheckBox()
        Me.chdefault = New System.Windows.Forms.CheckBox()
        Me.inshpid = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbSHCountry = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.SHPcode = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbSHProv = New System.Windows.Forms.ComboBox()
        Me.cmbSHCity = New System.Windows.Forms.ComboBox()
        Me.SHadd2 = New System.Windows.Forms.TextBox()
        Me.SHadd1 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.SHName = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GPshpAdd.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Customer ID/Name:"
        '
        'dspidname
        '
        Me.dspidname.Location = New System.Drawing.Point(110, 6)
        Me.dspidname.Name = "dspidname"
        Me.dspidname.Size = New System.Drawing.Size(368, 20)
        Me.dspidname.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(3, 32)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1176, 210)
        Me.DataGridView1.TabIndex = 2
        '
        'cmdNew
        '
        Me.cmdNew.Location = New System.Drawing.Point(504, 7)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(62, 19)
        Me.cmdNew.TabIndex = 49
        Me.cmdNew.Text = "New "
        Me.cmdNew.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(631, 6)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(75, 21)
        Me.cmdExit.TabIndex = 50
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'GPshpAdd
        '
        Me.GPshpAdd.Controls.Add(Me.cmdCancel)
        Me.GPshpAdd.Controls.Add(Me.cmdSave)
        Me.GPshpAdd.Controls.Add(Me.chactive)
        Me.GPshpAdd.Controls.Add(Me.chdefault)
        Me.GPshpAdd.Controls.Add(Me.inshpid)
        Me.GPshpAdd.Controls.Add(Me.Label2)
        Me.GPshpAdd.Controls.Add(Me.cmbSHCountry)
        Me.GPshpAdd.Controls.Add(Me.Label28)
        Me.GPshpAdd.Controls.Add(Me.SHPcode)
        Me.GPshpAdd.Controls.Add(Me.Label17)
        Me.GPshpAdd.Controls.Add(Me.cmbSHProv)
        Me.GPshpAdd.Controls.Add(Me.cmbSHCity)
        Me.GPshpAdd.Controls.Add(Me.SHadd2)
        Me.GPshpAdd.Controls.Add(Me.SHadd1)
        Me.GPshpAdd.Controls.Add(Me.Label18)
        Me.GPshpAdd.Controls.Add(Me.Label19)
        Me.GPshpAdd.Controls.Add(Me.Label20)
        Me.GPshpAdd.Controls.Add(Me.Label21)
        Me.GPshpAdd.Controls.Add(Me.SHName)
        Me.GPshpAdd.Controls.Add(Me.Label22)
        Me.GPshpAdd.Location = New System.Drawing.Point(3, 248)
        Me.GPshpAdd.Name = "GPshpAdd"
        Me.GPshpAdd.Size = New System.Drawing.Size(1176, 183)
        Me.GPshpAdd.TabIndex = 51
        Me.GPshpAdd.TabStop = False
        Me.GPshpAdd.Text = "ShipTo Address"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(385, 125)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(74, 28)
        Me.cmdCancel.TabIndex = 68
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(387, 85)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(73, 23)
        Me.cmdSave.TabIndex = 67
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'chactive
        '
        Me.chactive.AutoSize = True
        Me.chactive.Location = New System.Drawing.Point(389, 51)
        Me.chactive.Name = "chactive"
        Me.chactive.Size = New System.Drawing.Size(56, 17)
        Me.chactive.TabIndex = 66
        Me.chactive.Text = "Active"
        Me.chactive.UseVisualStyleBackColor = True
        '
        'chdefault
        '
        Me.chdefault.AutoSize = True
        Me.chdefault.Location = New System.Drawing.Point(389, 28)
        Me.chdefault.Name = "chdefault"
        Me.chdefault.Size = New System.Drawing.Size(60, 17)
        Me.chdefault.TabIndex = 65
        Me.chdefault.Text = "Default"
        Me.chdefault.UseVisualStyleBackColor = True
        '
        'inshpid
        '
        Me.inshpid.Location = New System.Drawing.Point(66, 19)
        Me.inshpid.Name = "inshpid"
        Me.inshpid.Size = New System.Drawing.Size(110, 20)
        Me.inshpid.TabIndex = 64
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "ShipTo ID:"
        '
        'cmbSHCountry
        '
        Me.cmbSHCountry.FormattingEnabled = True
        Me.cmbSHCountry.Location = New System.Drawing.Point(258, 138)
        Me.cmbSHCountry.Name = "cmbSHCountry"
        Me.cmbSHCountry.Size = New System.Drawing.Size(100, 21)
        Me.cmbSHCountry.TabIndex = 62
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(208, 141)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(46, 13)
        Me.Label28.TabIndex = 61
        Me.Label28.Text = "Country:"
        '
        'SHPcode
        '
        Me.SHPcode.Location = New System.Drawing.Point(260, 112)
        Me.SHPcode.Name = "SHPcode"
        Me.SHPcode.Size = New System.Drawing.Size(100, 20)
        Me.SHPcode.TabIndex = 60
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(189, 114)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(67, 13)
        Me.Label17.TabIndex = 59
        Me.Label17.Text = "Postal Code:"
        '
        'cmbSHProv
        '
        Me.cmbSHProv.FormattingEnabled = True
        Me.cmbSHProv.Location = New System.Drawing.Point(66, 138)
        Me.cmbSHProv.Name = "cmbSHProv"
        Me.cmbSHProv.Size = New System.Drawing.Size(117, 21)
        Me.cmbSHProv.TabIndex = 58
        '
        'cmbSHCity
        '
        Me.cmbSHCity.FormattingEnabled = True
        Me.cmbSHCity.Location = New System.Drawing.Point(66, 111)
        Me.cmbSHCity.Name = "cmbSHCity"
        Me.cmbSHCity.Size = New System.Drawing.Size(117, 21)
        Me.cmbSHCity.TabIndex = 57
        '
        'SHadd2
        '
        Me.SHadd2.Location = New System.Drawing.Point(66, 89)
        Me.SHadd2.Name = "SHadd2"
        Me.SHadd2.Size = New System.Drawing.Size(294, 20)
        Me.SHadd2.TabIndex = 56
        '
        'SHadd1
        '
        Me.SHadd1.Location = New System.Drawing.Point(66, 66)
        Me.SHadd1.Name = "SHadd1"
        Me.SHadd1.Size = New System.Drawing.Size(294, 20)
        Me.SHadd1.TabIndex = 55
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(14, 141)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(52, 13)
        Me.Label18.TabIndex = 54
        Me.Label18.Text = "Province:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(39, 111)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(27, 13)
        Me.Label19.TabIndex = 53
        Me.Label19.Text = "City:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(12, 89)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(54, 13)
        Me.Label20.TabIndex = 52
        Me.Label20.Text = "Address2:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(12, 69)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(54, 13)
        Me.Label21.TabIndex = 51
        Me.Label21.Text = "Address1:"
        '
        'SHName
        '
        Me.SHName.Location = New System.Drawing.Point(66, 41)
        Me.SHName.Name = "SHName"
        Me.SHName.Size = New System.Drawing.Size(294, 20)
        Me.SHName.TabIndex = 50
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(28, 44)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(38, 13)
        Me.Label22.TabIndex = 49
        Me.Label22.Text = "Name:"
        '
        'frmShippingadd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1182, 438)
        Me.Controls.Add(Me.GPshpAdd)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdNew)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.dspidname)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmShippingadd"
        Me.Text = "frmShippingadd"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GPshpAdd.ResumeLayout(False)
        Me.GPshpAdd.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents dspidname As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents cmdNew As Button
    Friend WithEvents cmdExit As Button
    Friend WithEvents GPshpAdd As GroupBox
    Friend WithEvents chactive As CheckBox
    Friend WithEvents chdefault As CheckBox
    Friend WithEvents inshpid As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbSHCountry As ComboBox
    Friend WithEvents Label28 As Label
    Friend WithEvents SHPcode As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents cmbSHProv As ComboBox
    Friend WithEvents cmbSHCity As ComboBox
    Friend WithEvents SHadd2 As TextBox
    Friend WithEvents SHadd1 As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents SHName As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdSave As Button
End Class
