<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCustomers
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
        Me.components = New System.ComponentModel.Container()
        Me.GBSelect = New System.Windows.Forms.GroupBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdProcess = New System.Windows.Forms.Button()
        Me.inCustID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.inCustName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtmsg = New System.Windows.Forms.TextBox()
        Me.cmdLoadCust = New System.Windows.Forms.Button()
        Me.cmbCustName = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbCustID = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GBSelect.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GBSelect
        '
        Me.GBSelect.Controls.Add(Me.SplitContainer1)
        Me.GBSelect.Location = New System.Drawing.Point(2, -2)
        Me.GBSelect.Name = "GBSelect"
        Me.GBSelect.Size = New System.Drawing.Size(1426, 85)
        Me.GBSelect.TabIndex = 0
        Me.GBSelect.TabStop = False
        Me.GBSelect.Text = "Select Customer"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 16)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdExit)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmdProcess)
        Me.SplitContainer1.Panel1.Controls.Add(Me.inCustID)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.inCustName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1420, 66)
        Me.SplitContainer1.SplitterDistance = 473
        Me.SplitContainer1.TabIndex = 0
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.Azure
        Me.cmdExit.Location = New System.Drawing.Point(356, 26)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(65, 23)
        Me.cmdExit.TabIndex = 5
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'cmdProcess
        '
        Me.cmdProcess.BackColor = System.Drawing.Color.Azure
        Me.cmdProcess.Location = New System.Drawing.Point(218, 26)
        Me.cmdProcess.Name = "cmdProcess"
        Me.cmdProcess.Size = New System.Drawing.Size(64, 25)
        Me.cmdProcess.TabIndex = 4
        Me.cmdProcess.Text = "Process"
        Me.cmdProcess.UseVisualStyleBackColor = False
        '
        'inCustID
        '
        Me.inCustID.Location = New System.Drawing.Point(88, 29)
        Me.inCustID.Name = "inCustID"
        Me.inCustID.Size = New System.Drawing.Size(114, 20)
        Me.inCustID.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Customer ID:"
        '
        'inCustName
        '
        Me.inCustName.Location = New System.Drawing.Point(88, 3)
        Me.inCustName.Name = "inCustName"
        Me.inCustName.Size = New System.Drawing.Size(382, 20)
        Me.inCustName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Customer Name:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtmsg)
        Me.GroupBox1.Controls.Add(Me.cmdLoadCust)
        Me.GroupBox1.Controls.Add(Me.cmbCustName)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbCustID)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(933, 64)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Existing Customers"
        '
        'txtmsg
        '
        Me.txtmsg.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtmsg.Location = New System.Drawing.Point(461, 39)
        Me.txtmsg.Name = "txtmsg"
        Me.txtmsg.Size = New System.Drawing.Size(361, 20)
        Me.txtmsg.TabIndex = 5
        '
        'cmdLoadCust
        '
        Me.cmdLoadCust.BackColor = System.Drawing.Color.Azure
        Me.cmdLoadCust.Location = New System.Drawing.Point(850, 17)
        Me.cmdLoadCust.Name = "cmdLoadCust"
        Me.cmdLoadCust.Size = New System.Drawing.Size(68, 34)
        Me.cmdLoadCust.TabIndex = 4
        Me.cmdLoadCust.Text = "Load Customer"
        Me.cmdLoadCust.UseVisualStyleBackColor = False
        '
        'cmbCustName
        '
        Me.cmbCustName.FormattingEnabled = True
        Me.cmbCustName.Location = New System.Drawing.Point(94, 40)
        Me.cmbCustName.Name = "cmbCustName"
        Me.cmbCustName.Size = New System.Drawing.Size(361, 21)
        Me.cmbCustName.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Customer Name:"
        '
        'cmbCustID
        '
        Me.cmbCustID.FormattingEnabled = True
        Me.cmbCustID.Location = New System.Drawing.Point(94, 15)
        Me.cmbCustID.Name = "cmbCustID"
        Me.cmbCustID.Size = New System.Drawing.Size(136, 21)
        Me.cmbCustID.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Customer ID:"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(5, 86)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1420, 733)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1412, 707)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1412, 707)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'frmCustomers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(1440, 821)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GBSelect)
        Me.Name = "frmCustomers"
        Me.Text = "Customers"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GBSelect.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GBSelect As GroupBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents inCustID As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents inCustName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents cmdExit As Button
    Friend WithEvents cmdProcess As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbCustID As ComboBox
    Friend WithEvents cmdLoadCust As Button
    Friend WithEvents cmbCustName As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtmsg As TextBox
    Friend WithEvents Timer1 As Timer
End Class
