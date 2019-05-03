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
        Me.cmbSelType = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.chslactonly = New System.Windows.Forms.CheckBox()
        Me.txtmsg = New System.Windows.Forms.TextBox()
        Me.cmdLoadCust = New System.Windows.Forms.Button()
        Me.cmbCustName = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbCustID = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GBShipToAdd1 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ComboBox9 = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.ComboBox6 = New System.Windows.Forms.ComboBox()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.GBcustBillto = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GBcustAdd1 = New System.Windows.Forms.GroupBox()
        Me.cmbCustType = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GPCommands = New System.Windows.Forms.GroupBox()
        Me.cmdCanCust = New System.Windows.Forms.Button()
        Me.GBSelect.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GBShipToAdd1.SuspendLayout()
        Me.GBcustBillto.SuspendLayout()
        Me.GBcustAdd1.SuspendLayout()
        Me.GPCommands.SuspendLayout()
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
        Me.GroupBox1.Controls.Add(Me.cmbSelType)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.chslactonly)
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
        'cmbSelType
        '
        Me.cmbSelType.FormattingEnabled = True
        Me.cmbSelType.Location = New System.Drawing.Point(461, 10)
        Me.cmbSelType.Name = "cmbSelType"
        Me.cmbSelType.Size = New System.Drawing.Size(117, 21)
        Me.cmbSelType.TabIndex = 8
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(374, 13)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(81, 13)
        Me.Label24.TabIndex = 7
        Me.Label24.Text = "Customer Type:"
        '
        'chslactonly
        '
        Me.chslactonly.AutoSize = True
        Me.chslactonly.Location = New System.Drawing.Point(267, 12)
        Me.chslactonly.Name = "chslactonly"
        Me.chslactonly.Size = New System.Drawing.Size(80, 17)
        Me.chslactonly.TabIndex = 6
        Me.chslactonly.Text = "Active Only"
        Me.chslactonly.UseVisualStyleBackColor = True
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
        Me.TabPage1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.TabPage1.Controls.Add(Me.GPCommands)
        Me.TabPage1.Controls.Add(Me.GBShipToAdd1)
        Me.TabPage1.Controls.Add(Me.GBcustBillto)
        Me.TabPage1.Controls.Add(Me.GBcustAdd1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1412, 707)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Info"
        '
        'GBShipToAdd1
        '
        Me.GBShipToAdd1.Controls.Add(Me.Button3)
        Me.GBShipToAdd1.Controls.Add(Me.ComboBox9)
        Me.GBShipToAdd1.Controls.Add(Me.Label25)
        Me.GBShipToAdd1.Controls.Add(Me.Button2)
        Me.GBShipToAdd1.Controls.Add(Me.Button1)
        Me.GBShipToAdd1.Controls.Add(Me.TextBox9)
        Me.GBShipToAdd1.Controls.Add(Me.Label17)
        Me.GBShipToAdd1.Controls.Add(Me.ComboBox5)
        Me.GBShipToAdd1.Controls.Add(Me.ComboBox6)
        Me.GBShipToAdd1.Controls.Add(Me.TextBox10)
        Me.GBShipToAdd1.Controls.Add(Me.TextBox11)
        Me.GBShipToAdd1.Controls.Add(Me.Label18)
        Me.GBShipToAdd1.Controls.Add(Me.Label19)
        Me.GBShipToAdd1.Controls.Add(Me.Label20)
        Me.GBShipToAdd1.Controls.Add(Me.Label21)
        Me.GBShipToAdd1.Controls.Add(Me.TextBox12)
        Me.GBShipToAdd1.Controls.Add(Me.Label22)
        Me.GBShipToAdd1.Location = New System.Drawing.Point(440, 6)
        Me.GBShipToAdd1.Name = "GBShipToAdd1"
        Me.GBShipToAdd1.Size = New System.Drawing.Size(398, 262)
        Me.GBShipToAdd1.TabIndex = 2
        Me.GBShipToAdd1.TabStop = False
        Me.GBShipToAdd1.Text = "Shipping Address"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Azure
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Location = New System.Drawing.Point(234, 19)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(123, 21)
        Me.Button3.TabIndex = 28
        Me.Button3.Text = "Save Shipto ID"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'ComboBox9
        '
        Me.ComboBox9.FormattingEnabled = True
        Me.ComboBox9.Location = New System.Drawing.Point(65, 20)
        Me.ComboBox9.Name = "ComboBox9"
        Me.ComboBox9.Size = New System.Drawing.Size(117, 21)
        Me.ComboBox9.TabIndex = 27
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(7, 23)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(58, 13)
        Me.Label25.TabIndex = 26
        Me.Label25.Text = "ShipTo ID:"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Azure
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Location = New System.Drawing.Point(234, 142)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(126, 21)
        Me.Button2.TabIndex = 25
        Me.Button2.Text = "<<<<Same as Address"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Azure
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Location = New System.Drawing.Point(234, 177)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(126, 19)
        Me.Button1.TabIndex = 24
        Me.Button1.Text = "Same as Bill Address"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(259, 114)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(100, 20)
        Me.TextBox9.TabIndex = 23
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(188, 116)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(67, 13)
        Me.Label17.TabIndex = 22
        Me.Label17.Text = "Postal Code:"
        '
        'ComboBox5
        '
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Location = New System.Drawing.Point(65, 140)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(117, 21)
        Me.ComboBox5.TabIndex = 21
        '
        'ComboBox6
        '
        Me.ComboBox6.FormattingEnabled = True
        Me.ComboBox6.Location = New System.Drawing.Point(65, 113)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(117, 21)
        Me.ComboBox6.TabIndex = 20
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(65, 91)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(294, 20)
        Me.TextBox10.TabIndex = 19
        '
        'TextBox11
        '
        Me.TextBox11.Location = New System.Drawing.Point(65, 68)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(294, 20)
        Me.TextBox11.TabIndex = 18
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(13, 143)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(52, 13)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "Province:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(38, 113)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(27, 13)
        Me.Label19.TabIndex = 16
        Me.Label19.Text = "City:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(11, 91)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(54, 13)
        Me.Label20.TabIndex = 15
        Me.Label20.Text = "Address2:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(11, 71)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(54, 13)
        Me.Label21.TabIndex = 14
        Me.Label21.Text = "Address1:"
        '
        'TextBox12
        '
        Me.TextBox12.Location = New System.Drawing.Point(65, 43)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(294, 20)
        Me.TextBox12.TabIndex = 13
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(27, 46)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(38, 13)
        Me.Label22.TabIndex = 12
        Me.Label22.Text = "Name:"
        '
        'GBcustBillto
        '
        Me.GBcustBillto.Controls.Add(Me.Button4)
        Me.GBcustBillto.Controls.Add(Me.TextBox5)
        Me.GBcustBillto.Controls.Add(Me.Label11)
        Me.GBcustBillto.Controls.Add(Me.ComboBox3)
        Me.GBcustBillto.Controls.Add(Me.ComboBox4)
        Me.GBcustBillto.Controls.Add(Me.TextBox6)
        Me.GBcustBillto.Controls.Add(Me.TextBox7)
        Me.GBcustBillto.Controls.Add(Me.Label12)
        Me.GBcustBillto.Controls.Add(Me.Label13)
        Me.GBcustBillto.Controls.Add(Me.Label14)
        Me.GBcustBillto.Controls.Add(Me.Label15)
        Me.GBcustBillto.Controls.Add(Me.TextBox8)
        Me.GBcustBillto.Controls.Add(Me.Label16)
        Me.GBcustBillto.Location = New System.Drawing.Point(6, 274)
        Me.GBcustBillto.Name = "GBcustBillto"
        Me.GBcustBillto.Size = New System.Drawing.Size(428, 277)
        Me.GBcustBillto.TabIndex = 1
        Me.GBcustBillto.TabStop = False
        Me.GBcustBillto.Text = "BillTO Address"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Azure
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.Location = New System.Drawing.Point(251, 119)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(100, 19)
        Me.Button4.TabIndex = 24
        Me.Button4.Text = "Same as Above"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(251, 90)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(100, 20)
        Me.TextBox5.TabIndex = 23
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(180, 92)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Postal Code:"
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(57, 116)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(117, 21)
        Me.ComboBox3.TabIndex = 21
        '
        'ComboBox4
        '
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(57, 89)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(117, 21)
        Me.ComboBox4.TabIndex = 20
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(57, 67)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(294, 20)
        Me.TextBox6.TabIndex = 19
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(57, 44)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(294, 20)
        Me.TextBox7.TabIndex = 18
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(5, 119)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Province:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(30, 89)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(27, 13)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "City:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 67)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 13)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Address2:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 47)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 13)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Address1:"
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(57, 19)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(294, 20)
        Me.TextBox8.TabIndex = 13
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(19, 22)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(38, 13)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "Name:"
        '
        'GBcustAdd1
        '
        Me.GBcustAdd1.Controls.Add(Me.cmbCustType)
        Me.GBcustAdd1.Controls.Add(Me.Label23)
        Me.GBcustAdd1.Controls.Add(Me.CheckBox1)
        Me.GBcustAdd1.Controls.Add(Me.TextBox4)
        Me.GBcustAdd1.Controls.Add(Me.Label10)
        Me.GBcustAdd1.Controls.Add(Me.ComboBox2)
        Me.GBcustAdd1.Controls.Add(Me.ComboBox1)
        Me.GBcustAdd1.Controls.Add(Me.TextBox3)
        Me.GBcustAdd1.Controls.Add(Me.TextBox2)
        Me.GBcustAdd1.Controls.Add(Me.Label9)
        Me.GBcustAdd1.Controls.Add(Me.Label8)
        Me.GBcustAdd1.Controls.Add(Me.Label7)
        Me.GBcustAdd1.Controls.Add(Me.Label6)
        Me.GBcustAdd1.Controls.Add(Me.TextBox1)
        Me.GBcustAdd1.Controls.Add(Me.Label5)
        Me.GBcustAdd1.Location = New System.Drawing.Point(3, 6)
        Me.GBcustAdd1.Name = "GBcustAdd1"
        Me.GBcustAdd1.Size = New System.Drawing.Size(431, 262)
        Me.GBcustAdd1.TabIndex = 0
        Me.GBcustAdd1.TabStop = False
        Me.GBcustAdd1.Text = "Customer Information"
        '
        'cmbCustType
        '
        Me.cmbCustType.FormattingEnabled = True
        Me.cmbCustType.Location = New System.Drawing.Point(60, 150)
        Me.cmbCustType.Name = "cmbCustType"
        Me.cmbCustType.Size = New System.Drawing.Size(117, 21)
        Me.cmbCustType.TabIndex = 14
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(22, 153)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(34, 13)
        Me.Label23.TabIndex = 13
        Me.Label23.Text = "Type:"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(254, 122)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(56, 17)
        Me.CheckBox1.TabIndex = 12
        Me.CheckBox1.Text = "Active"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(254, 94)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(100, 20)
        Me.TextBox4.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(183, 96)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Postal Code:"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(60, 120)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(117, 21)
        Me.ComboBox2.TabIndex = 9
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(60, 93)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(117, 21)
        Me.ComboBox1.TabIndex = 8
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(60, 71)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(294, 20)
        Me.TextBox3.TabIndex = 7
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(60, 48)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(294, 20)
        Me.TextBox2.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 123)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Province:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(33, 93)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(27, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "City:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Address2:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Address1:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(60, 23)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(294, 20)
        Me.TextBox1.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Name:"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1412, 707)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Details"
        '
        'Timer1
        '
        '
        'GPCommands
        '
        Me.GPCommands.Controls.Add(Me.cmdCanCust)
        Me.GPCommands.Location = New System.Drawing.Point(6, 557)
        Me.GPCommands.Name = "GPCommands"
        Me.GPCommands.Size = New System.Drawing.Size(428, 76)
        Me.GPCommands.TabIndex = 3
        Me.GPCommands.TabStop = False
        Me.GPCommands.Text = "Commands"
        '
        'cmdCanCust
        '
        Me.cmdCanCust.BackColor = System.Drawing.Color.Azure
        Me.cmdCanCust.Location = New System.Drawing.Point(371, 19)
        Me.cmdCanCust.Name = "cmdCanCust"
        Me.cmdCanCust.Size = New System.Drawing.Size(51, 20)
        Me.cmdCanCust.TabIndex = 0
        Me.cmdCanCust.Text = "Cancel"
        Me.cmdCanCust.UseVisualStyleBackColor = False
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
        Me.TabPage1.ResumeLayout(False)
        Me.GBShipToAdd1.ResumeLayout(False)
        Me.GBShipToAdd1.PerformLayout()
        Me.GBcustBillto.ResumeLayout(False)
        Me.GBcustBillto.PerformLayout()
        Me.GBcustAdd1.ResumeLayout(False)
        Me.GBcustAdd1.PerformLayout()
        Me.GPCommands.ResumeLayout(False)
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
    Friend WithEvents GBcustAdd1 As GroupBox
    Friend WithEvents GBcustBillto As GroupBox
    Friend WithEvents GBShipToAdd1 As GroupBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents chslactonly As CheckBox
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents ComboBox5 As ComboBox
    Friend WithEvents ComboBox6 As ComboBox
    Friend WithEvents TextBox10 As TextBox
    Friend WithEvents TextBox11 As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents TextBox12 As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents ComboBox4 As ComboBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents cmbCustType As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents cmbSelType As ComboBox
    Friend WithEvents Label24 As Label
    Friend WithEvents ComboBox9 As ComboBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents GPCommands As GroupBox
    Friend WithEvents cmdCanCust As Button
End Class
