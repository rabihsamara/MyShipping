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
        Me.incmbSelType = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.inchslactonly = New System.Windows.Forms.CheckBox()
        Me.txtmsg = New System.Windows.Forms.TextBox()
        Me.cmdLoadCust = New System.Windows.Forms.Button()
        Me.incmbCustName = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.incmbCustID = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.datecreated = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.createdby = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.dateupdate = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.GBorders = New System.Windows.Forms.GroupBox()
        Me.cmdNewOrder = New System.Windows.Forms.Button()
        Me.DataGridOrders = New System.Windows.Forms.DataGridView()
        Me.GBAccounts = New System.Windows.Forms.GroupBox()
        Me.cmdNewAcct = New System.Windows.Forms.Button()
        Me.DataGridAccts = New System.Windows.Forms.DataGridView()
        Me.GPCommands = New System.Windows.Forms.GroupBox()
        Me.cmdSaveCust = New System.Windows.Forms.Button()
        Me.cmdCanCust = New System.Windows.Forms.Button()
        Me.GBShipToAdd1 = New System.Windows.Forms.GroupBox()
        Me.cmbSHCountry = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cmdSaveShpto = New System.Windows.Forms.Button()
        Me.cmbShpID = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cmdSaveshipasinfo = New System.Windows.Forms.Button()
        Me.cmdShSaveBill = New System.Windows.Forms.Button()
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
        Me.GBcustBillto = New System.Windows.Forms.GroupBox()
        Me.cmbBLCountry = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cmdBillCopy = New System.Windows.Forms.Button()
        Me.BLpcode = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbBLProv = New System.Windows.Forms.ComboBox()
        Me.cmbBLcity = New System.Windows.Forms.ComboBox()
        Me.BLadd2 = New System.Windows.Forms.TextBox()
        Me.BLadd1 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.BLName = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GBcustAdd1 = New System.Windows.Forms.GroupBox()
        Me.chCIactive = New System.Windows.Forms.CheckBox()
        Me.cmbCICountry = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmbCustType = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.CIpcode = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbCIProv = New System.Windows.Forms.ComboBox()
        Me.cmbCICity = New System.Windows.Forms.ComboBox()
        Me.CIAdd2 = New System.Windows.Forms.TextBox()
        Me.CIadd1 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CIName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GBSelect.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GBorders.SuspendLayout()
        CType(Me.DataGridOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBAccounts.SuspendLayout()
        CType(Me.DataGridAccts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GPCommands.SuspendLayout()
        Me.GBShipToAdd1.SuspendLayout()
        Me.GBcustBillto.SuspendLayout()
        Me.GBcustAdd1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GBSelect
        '
        Me.GBSelect.Controls.Add(Me.SplitContainer1)
        Me.GBSelect.Location = New System.Drawing.Point(2, -2)
        Me.GBSelect.Name = "GBSelect"
        Me.GBSelect.Size = New System.Drawing.Size(1426, 104)
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
        Me.SplitContainer1.Size = New System.Drawing.Size(1420, 85)
        Me.SplitContainer1.SplitterDistance = 473
        Me.SplitContainer1.TabIndex = 0
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.Azure
        Me.cmdExit.Location = New System.Drawing.Point(397, 26)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(65, 25)
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
        Me.GroupBox1.Controls.Add(Me.incmbSelType)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.inchslactonly)
        Me.GroupBox1.Controls.Add(Me.txtmsg)
        Me.GroupBox1.Controls.Add(Me.cmdLoadCust)
        Me.GroupBox1.Controls.Add(Me.incmbCustName)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.incmbCustID)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(933, 80)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Existing Customers"
        '
        'incmbSelType
        '
        Me.incmbSelType.FormattingEnabled = True
        Me.incmbSelType.Location = New System.Drawing.Point(358, 26)
        Me.incmbSelType.Name = "incmbSelType"
        Me.incmbSelType.Size = New System.Drawing.Size(117, 21)
        Me.incmbSelType.TabIndex = 8
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(278, 31)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(81, 13)
        Me.Label24.TabIndex = 7
        Me.Label24.Text = "Customer Type:"
        '
        'inchslactonly
        '
        Me.inchslactonly.AutoSize = True
        Me.inchslactonly.Location = New System.Drawing.Point(358, 4)
        Me.inchslactonly.Name = "inchslactonly"
        Me.inchslactonly.Size = New System.Drawing.Size(80, 17)
        Me.inchslactonly.TabIndex = 6
        Me.inchslactonly.Text = "Active Only"
        Me.inchslactonly.UseVisualStyleBackColor = True
        '
        'txtmsg
        '
        Me.txtmsg.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtmsg.Location = New System.Drawing.Point(555, 8)
        Me.txtmsg.Multiline = True
        Me.txtmsg.Name = "txtmsg"
        Me.txtmsg.Size = New System.Drawing.Size(378, 66)
        Me.txtmsg.TabIndex = 5
        '
        'cmdLoadCust
        '
        Me.cmdLoadCust.BackColor = System.Drawing.Color.Azure
        Me.cmdLoadCust.Location = New System.Drawing.Point(481, 24)
        Me.cmdLoadCust.Name = "cmdLoadCust"
        Me.cmdLoadCust.Size = New System.Drawing.Size(68, 50)
        Me.cmdLoadCust.TabIndex = 4
        Me.cmdLoadCust.Text = "Load Customer"
        Me.cmdLoadCust.UseVisualStyleBackColor = False
        '
        'incmbCustName
        '
        Me.incmbCustName.FormattingEnabled = True
        Me.incmbCustName.Location = New System.Drawing.Point(94, 53)
        Me.incmbCustName.Name = "incmbCustName"
        Me.incmbCustName.Size = New System.Drawing.Size(381, 21)
        Me.incmbCustName.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Customer Name:"
        '
        'incmbCustID
        '
        Me.incmbCustID.FormattingEnabled = True
        Me.incmbCustID.Location = New System.Drawing.Point(94, 23)
        Me.incmbCustID.Name = "incmbCustID"
        Me.incmbCustID.Size = New System.Drawing.Size(120, 21)
        Me.incmbCustID.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Customer ID:"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(5, 105)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1420, 714)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GBorders)
        Me.TabPage1.Controls.Add(Me.GBAccounts)
        Me.TabPage1.Controls.Add(Me.GPCommands)
        Me.TabPage1.Controls.Add(Me.GBShipToAdd1)
        Me.TabPage1.Controls.Add(Me.GBcustBillto)
        Me.TabPage1.Controls.Add(Me.GBcustAdd1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1412, 688)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Info"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.datecreated)
        Me.GroupBox3.Controls.Add(Me.Label29)
        Me.GroupBox3.Controls.Add(Me.createdby)
        Me.GroupBox3.Controls.Add(Me.Label30)
        Me.GroupBox3.Controls.Add(Me.dateupdate)
        Me.GroupBox3.Controls.Add(Me.Label31)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 381)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(354, 65)
        Me.GroupBox3.TabIndex = 25
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Update Information"
        '
        'datecreated
        '
        Me.datecreated.BackColor = System.Drawing.SystemColors.Info
        Me.datecreated.Enabled = False
        Me.datecreated.Location = New System.Drawing.Point(76, 19)
        Me.datecreated.Name = "datecreated"
        Me.datecreated.Size = New System.Drawing.Size(120, 20)
        Me.datecreated.TabIndex = 19
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(7, 22)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(66, 13)
        Me.Label29.TabIndex = 18
        Me.Label29.Text = "Created ON:"
        '
        'createdby
        '
        Me.createdby.BackColor = System.Drawing.SystemColors.Info
        Me.createdby.Enabled = False
        Me.createdby.Location = New System.Drawing.Point(257, 40)
        Me.createdby.Name = "createdby"
        Me.createdby.Size = New System.Drawing.Size(94, 20)
        Me.createdby.TabIndex = 23
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(2, 42)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(74, 13)
        Me.Label30.TabIndex = 20
        Me.Label30.Text = "Last Updated:"
        '
        'dateupdate
        '
        Me.dateupdate.BackColor = System.Drawing.SystemColors.Info
        Me.dateupdate.Enabled = False
        Me.dateupdate.Location = New System.Drawing.Point(76, 40)
        Me.dateupdate.Name = "dateupdate"
        Me.dateupdate.Size = New System.Drawing.Size(120, 20)
        Me.dateupdate.TabIndex = 21
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(200, 43)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(62, 13)
        Me.Label31.TabIndex = 22
        Me.Label31.Text = "Created By:"
        '
        'GBorders
        '
        Me.GBorders.Controls.Add(Me.cmdNewOrder)
        Me.GBorders.Controls.Add(Me.DataGridOrders)
        Me.GBorders.Location = New System.Drawing.Point(796, 6)
        Me.GBorders.Name = "GBorders"
        Me.GBorders.Size = New System.Drawing.Size(610, 375)
        Me.GBorders.TabIndex = 24
        Me.GBorders.TabStop = False
        Me.GBorders.Text = "Orders per Account"
        '
        'cmdNewOrder
        '
        Me.cmdNewOrder.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.cmdNewOrder.Location = New System.Drawing.Point(522, 11)
        Me.cmdNewOrder.Name = "cmdNewOrder"
        Me.cmdNewOrder.Size = New System.Drawing.Size(69, 25)
        Me.cmdNewOrder.TabIndex = 1
        Me.cmdNewOrder.Text = "New Order"
        Me.cmdNewOrder.UseVisualStyleBackColor = False
        '
        'DataGridOrders
        '
        Me.DataGridOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridOrders.Location = New System.Drawing.Point(10, 42)
        Me.DataGridOrders.Name = "DataGridOrders"
        Me.DataGridOrders.Size = New System.Drawing.Size(599, 326)
        Me.DataGridOrders.TabIndex = 0
        '
        'GBAccounts
        '
        Me.GBAccounts.Controls.Add(Me.cmdNewAcct)
        Me.GBAccounts.Controls.Add(Me.DataGridAccts)
        Me.GBAccounts.Location = New System.Drawing.Point(363, 211)
        Me.GBAccounts.Name = "GBAccounts"
        Me.GBAccounts.Size = New System.Drawing.Size(426, 170)
        Me.GBAccounts.TabIndex = 4
        Me.GBAccounts.TabStop = False
        Me.GBAccounts.Text = "Accounts For customer:"
        '
        'cmdNewAcct
        '
        Me.cmdNewAcct.BackColor = System.Drawing.Color.Azure
        Me.cmdNewAcct.Location = New System.Drawing.Point(339, 9)
        Me.cmdNewAcct.Name = "cmdNewAcct"
        Me.cmdNewAcct.Size = New System.Drawing.Size(80, 21)
        Me.cmdNewAcct.TabIndex = 1
        Me.cmdNewAcct.Text = "New Account"
        Me.cmdNewAcct.UseVisualStyleBackColor = False
        '
        'DataGridAccts
        '
        Me.DataGridAccts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridAccts.Location = New System.Drawing.Point(6, 31)
        Me.DataGridAccts.Name = "DataGridAccts"
        Me.DataGridAccts.Size = New System.Drawing.Size(414, 139)
        Me.DataGridAccts.TabIndex = 0
        '
        'GPCommands
        '
        Me.GPCommands.Controls.Add(Me.cmdSaveCust)
        Me.GPCommands.Controls.Add(Me.cmdCanCust)
        Me.GPCommands.Location = New System.Drawing.Point(363, 381)
        Me.GPCommands.Name = "GPCommands"
        Me.GPCommands.Size = New System.Drawing.Size(427, 65)
        Me.GPCommands.TabIndex = 3
        Me.GPCommands.TabStop = False
        Me.GPCommands.Text = "Commands"
        '
        'cmdSaveCust
        '
        Me.cmdSaveCust.BackColor = System.Drawing.Color.Azure
        Me.cmdSaveCust.Location = New System.Drawing.Point(6, 19)
        Me.cmdSaveCust.Name = "cmdSaveCust"
        Me.cmdSaveCust.Size = New System.Drawing.Size(43, 28)
        Me.cmdSaveCust.TabIndex = 1
        Me.cmdSaveCust.Text = "Save"
        Me.cmdSaveCust.UseVisualStyleBackColor = False
        '
        'cmdCanCust
        '
        Me.cmdCanCust.BackColor = System.Drawing.Color.Azure
        Me.cmdCanCust.Location = New System.Drawing.Point(297, 19)
        Me.cmdCanCust.Name = "cmdCanCust"
        Me.cmdCanCust.Size = New System.Drawing.Size(51, 28)
        Me.cmdCanCust.TabIndex = 0
        Me.cmdCanCust.Text = "Cancel"
        Me.cmdCanCust.UseVisualStyleBackColor = False
        '
        'GBShipToAdd1
        '
        Me.GBShipToAdd1.Controls.Add(Me.cmbSHCountry)
        Me.GBShipToAdd1.Controls.Add(Me.Label28)
        Me.GBShipToAdd1.Controls.Add(Me.cmdSaveShpto)
        Me.GBShipToAdd1.Controls.Add(Me.cmbShpID)
        Me.GBShipToAdd1.Controls.Add(Me.Label25)
        Me.GBShipToAdd1.Controls.Add(Me.cmdSaveshipasinfo)
        Me.GBShipToAdd1.Controls.Add(Me.cmdShSaveBill)
        Me.GBShipToAdd1.Controls.Add(Me.SHPcode)
        Me.GBShipToAdd1.Controls.Add(Me.Label17)
        Me.GBShipToAdd1.Controls.Add(Me.cmbSHProv)
        Me.GBShipToAdd1.Controls.Add(Me.cmbSHCity)
        Me.GBShipToAdd1.Controls.Add(Me.SHadd2)
        Me.GBShipToAdd1.Controls.Add(Me.SHadd1)
        Me.GBShipToAdd1.Controls.Add(Me.Label18)
        Me.GBShipToAdd1.Controls.Add(Me.Label19)
        Me.GBShipToAdd1.Controls.Add(Me.Label20)
        Me.GBShipToAdd1.Controls.Add(Me.Label21)
        Me.GBShipToAdd1.Controls.Add(Me.SHName)
        Me.GBShipToAdd1.Controls.Add(Me.Label22)
        Me.GBShipToAdd1.Location = New System.Drawing.Point(363, 6)
        Me.GBShipToAdd1.Name = "GBShipToAdd1"
        Me.GBShipToAdd1.Size = New System.Drawing.Size(427, 199)
        Me.GBShipToAdd1.TabIndex = 2
        Me.GBShipToAdd1.TabStop = False
        Me.GBShipToAdd1.Text = "Shipping Address"
        '
        'cmbSHCountry
        '
        Me.cmbSHCountry.FormattingEnabled = True
        Me.cmbSHCountry.Location = New System.Drawing.Point(257, 140)
        Me.cmbSHCountry.Name = "cmbSHCountry"
        Me.cmbSHCountry.Size = New System.Drawing.Size(100, 21)
        Me.cmbSHCountry.TabIndex = 30
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(207, 143)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(46, 13)
        Me.Label28.TabIndex = 29
        Me.Label28.Text = "Country:"
        '
        'cmdSaveShpto
        '
        Me.cmdSaveShpto.BackColor = System.Drawing.Color.Azure
        Me.cmdSaveShpto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdSaveShpto.Location = New System.Drawing.Point(277, 16)
        Me.cmdSaveShpto.Name = "cmdSaveShpto"
        Me.cmdSaveShpto.Size = New System.Drawing.Size(82, 21)
        Me.cmdSaveShpto.TabIndex = 28
        Me.cmdSaveShpto.Text = "ADD Ship To"
        Me.cmdSaveShpto.UseVisualStyleBackColor = False
        '
        'cmbShpID
        '
        Me.cmbShpID.FormattingEnabled = True
        Me.cmbShpID.Location = New System.Drawing.Point(65, 20)
        Me.cmbShpID.Name = "cmbShpID"
        Me.cmbShpID.Size = New System.Drawing.Size(117, 21)
        Me.cmbShpID.TabIndex = 27
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
        'cmdSaveshipasinfo
        '
        Me.cmdSaveshipasinfo.BackColor = System.Drawing.Color.Azure
        Me.cmdSaveshipasinfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdSaveshipasinfo.Location = New System.Drawing.Point(65, 166)
        Me.cmdSaveshipasinfo.Name = "cmdSaveshipasinfo"
        Me.cmdSaveshipasinfo.Size = New System.Drawing.Size(141, 27)
        Me.cmdSaveshipasinfo.TabIndex = 25
        Me.cmdSaveshipasinfo.Text = "Copy Customer Address"
        Me.cmdSaveshipasinfo.UseVisualStyleBackColor = False
        '
        'cmdShSaveBill
        '
        Me.cmdShSaveBill.BackColor = System.Drawing.Color.Azure
        Me.cmdShSaveBill.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdShSaveBill.Location = New System.Drawing.Point(231, 167)
        Me.cmdShSaveBill.Name = "cmdShSaveBill"
        Me.cmdShSaveBill.Size = New System.Drawing.Size(126, 26)
        Me.cmdShSaveBill.TabIndex = 24
        Me.cmdShSaveBill.Text = "Copy Billing Address"
        Me.cmdShSaveBill.UseVisualStyleBackColor = False
        '
        'SHPcode
        '
        Me.SHPcode.Location = New System.Drawing.Point(259, 114)
        Me.SHPcode.Name = "SHPcode"
        Me.SHPcode.Size = New System.Drawing.Size(100, 20)
        Me.SHPcode.TabIndex = 23
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
        'cmbSHProv
        '
        Me.cmbSHProv.FormattingEnabled = True
        Me.cmbSHProv.Location = New System.Drawing.Point(65, 140)
        Me.cmbSHProv.Name = "cmbSHProv"
        Me.cmbSHProv.Size = New System.Drawing.Size(117, 21)
        Me.cmbSHProv.TabIndex = 21
        '
        'cmbSHCity
        '
        Me.cmbSHCity.FormattingEnabled = True
        Me.cmbSHCity.Location = New System.Drawing.Point(65, 113)
        Me.cmbSHCity.Name = "cmbSHCity"
        Me.cmbSHCity.Size = New System.Drawing.Size(117, 21)
        Me.cmbSHCity.TabIndex = 20
        '
        'SHadd2
        '
        Me.SHadd2.Location = New System.Drawing.Point(65, 91)
        Me.SHadd2.Name = "SHadd2"
        Me.SHadd2.Size = New System.Drawing.Size(294, 20)
        Me.SHadd2.TabIndex = 19
        '
        'SHadd1
        '
        Me.SHadd1.Location = New System.Drawing.Point(65, 68)
        Me.SHadd1.Name = "SHadd1"
        Me.SHadd1.Size = New System.Drawing.Size(294, 20)
        Me.SHadd1.TabIndex = 18
        '
        'Label18
        '
        Me.Label18.AllowDrop = True
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(13, 143)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(52, 13)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "Province:"
        Me.Label18.UseMnemonic = False
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
        'SHName
        '
        Me.SHName.Location = New System.Drawing.Point(65, 43)
        Me.SHName.Name = "SHName"
        Me.SHName.Size = New System.Drawing.Size(294, 20)
        Me.SHName.TabIndex = 13
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
        Me.GBcustBillto.Controls.Add(Me.cmbBLCountry)
        Me.GBcustBillto.Controls.Add(Me.Label27)
        Me.GBcustBillto.Controls.Add(Me.cmdBillCopy)
        Me.GBcustBillto.Controls.Add(Me.BLpcode)
        Me.GBcustBillto.Controls.Add(Me.Label11)
        Me.GBcustBillto.Controls.Add(Me.cmbBLProv)
        Me.GBcustBillto.Controls.Add(Me.cmbBLcity)
        Me.GBcustBillto.Controls.Add(Me.BLadd2)
        Me.GBcustBillto.Controls.Add(Me.BLadd1)
        Me.GBcustBillto.Controls.Add(Me.Label12)
        Me.GBcustBillto.Controls.Add(Me.Label13)
        Me.GBcustBillto.Controls.Add(Me.Label14)
        Me.GBcustBillto.Controls.Add(Me.Label15)
        Me.GBcustBillto.Controls.Add(Me.BLName)
        Me.GBcustBillto.Controls.Add(Me.Label16)
        Me.GBcustBillto.Location = New System.Drawing.Point(3, 211)
        Me.GBcustBillto.Name = "GBcustBillto"
        Me.GBcustBillto.Size = New System.Drawing.Size(354, 170)
        Me.GBcustBillto.TabIndex = 1
        Me.GBcustBillto.TabStop = False
        Me.GBcustBillto.Text = "BillTO Address"
        '
        'cmbBLCountry
        '
        Me.cmbBLCountry.FormattingEnabled = True
        Me.cmbBLCountry.Location = New System.Drawing.Point(251, 116)
        Me.cmbBLCountry.Name = "cmbBLCountry"
        Me.cmbBLCountry.Size = New System.Drawing.Size(100, 21)
        Me.cmbBLCountry.TabIndex = 26
        Me.cmbBLCountry.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(201, 119)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(46, 13)
        Me.Label27.TabIndex = 25
        Me.Label27.Text = "Country:"
        '
        'cmdBillCopy
        '
        Me.cmdBillCopy.BackColor = System.Drawing.Color.Azure
        Me.cmdBillCopy.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdBillCopy.Location = New System.Drawing.Point(204, 140)
        Me.cmdBillCopy.Name = "cmdBillCopy"
        Me.cmdBillCopy.Size = New System.Drawing.Size(128, 24)
        Me.cmdBillCopy.TabIndex = 24
        Me.cmdBillCopy.Text = "Copy Customer Address"
        Me.cmdBillCopy.UseVisualStyleBackColor = False
        '
        'BLpcode
        '
        Me.BLpcode.Location = New System.Drawing.Point(251, 90)
        Me.BLpcode.Name = "BLpcode"
        Me.BLpcode.Size = New System.Drawing.Size(100, 20)
        Me.BLpcode.TabIndex = 23
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
        'cmbBLProv
        '
        Me.cmbBLProv.FormattingEnabled = True
        Me.cmbBLProv.Location = New System.Drawing.Point(57, 116)
        Me.cmbBLProv.Name = "cmbBLProv"
        Me.cmbBLProv.Size = New System.Drawing.Size(117, 21)
        Me.cmbBLProv.TabIndex = 21
        '
        'cmbBLcity
        '
        Me.cmbBLcity.FormattingEnabled = True
        Me.cmbBLcity.Location = New System.Drawing.Point(57, 89)
        Me.cmbBLcity.Name = "cmbBLcity"
        Me.cmbBLcity.Size = New System.Drawing.Size(117, 21)
        Me.cmbBLcity.TabIndex = 20
        '
        'BLadd2
        '
        Me.BLadd2.Location = New System.Drawing.Point(57, 67)
        Me.BLadd2.Name = "BLadd2"
        Me.BLadd2.Size = New System.Drawing.Size(294, 20)
        Me.BLadd2.TabIndex = 19
        '
        'BLadd1
        '
        Me.BLadd1.Location = New System.Drawing.Point(57, 44)
        Me.BLadd1.Name = "BLadd1"
        Me.BLadd1.Size = New System.Drawing.Size(294, 20)
        Me.BLadd1.TabIndex = 18
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
        'BLName
        '
        Me.BLName.Location = New System.Drawing.Point(57, 19)
        Me.BLName.Name = "BLName"
        Me.BLName.Size = New System.Drawing.Size(294, 20)
        Me.BLName.TabIndex = 13
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
        Me.GBcustAdd1.Controls.Add(Me.chCIactive)
        Me.GBcustAdd1.Controls.Add(Me.cmbCICountry)
        Me.GBcustAdd1.Controls.Add(Me.Label26)
        Me.GBcustAdd1.Controls.Add(Me.cmbCustType)
        Me.GBcustAdd1.Controls.Add(Me.Label23)
        Me.GBcustAdd1.Controls.Add(Me.CIpcode)
        Me.GBcustAdd1.Controls.Add(Me.Label10)
        Me.GBcustAdd1.Controls.Add(Me.cmbCIProv)
        Me.GBcustAdd1.Controls.Add(Me.cmbCICity)
        Me.GBcustAdd1.Controls.Add(Me.CIAdd2)
        Me.GBcustAdd1.Controls.Add(Me.CIadd1)
        Me.GBcustAdd1.Controls.Add(Me.Label9)
        Me.GBcustAdd1.Controls.Add(Me.Label8)
        Me.GBcustAdd1.Controls.Add(Me.Label7)
        Me.GBcustAdd1.Controls.Add(Me.Label6)
        Me.GBcustAdd1.Controls.Add(Me.CIName)
        Me.GBcustAdd1.Controls.Add(Me.Label5)
        Me.GBcustAdd1.Location = New System.Drawing.Point(3, 6)
        Me.GBcustAdd1.Name = "GBcustAdd1"
        Me.GBcustAdd1.Size = New System.Drawing.Size(354, 199)
        Me.GBcustAdd1.TabIndex = 0
        Me.GBcustAdd1.TabStop = False
        Me.GBcustAdd1.Text = "Customer Information"
        '
        'chCIactive
        '
        Me.chCIactive.AutoSize = True
        Me.chCIactive.Location = New System.Drawing.Point(254, 154)
        Me.chCIactive.Name = "chCIactive"
        Me.chCIactive.Size = New System.Drawing.Size(56, 17)
        Me.chCIactive.TabIndex = 17
        Me.chCIactive.Text = "Active"
        Me.chCIactive.UseVisualStyleBackColor = True
        '
        'cmbCICountry
        '
        Me.cmbCICountry.FormattingEnabled = True
        Me.cmbCICountry.Location = New System.Drawing.Point(254, 120)
        Me.cmbCICountry.Name = "cmbCICountry"
        Me.cmbCICountry.Size = New System.Drawing.Size(100, 21)
        Me.cmbCICountry.TabIndex = 16
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(204, 123)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(46, 13)
        Me.Label26.TabIndex = 15
        Me.Label26.Text = "Country:"
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
        'CIpcode
        '
        Me.CIpcode.Location = New System.Drawing.Point(254, 94)
        Me.CIpcode.Name = "CIpcode"
        Me.CIpcode.Size = New System.Drawing.Size(100, 20)
        Me.CIpcode.TabIndex = 11
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
        'cmbCIProv
        '
        Me.cmbCIProv.FormattingEnabled = True
        Me.cmbCIProv.Location = New System.Drawing.Point(60, 120)
        Me.cmbCIProv.Name = "cmbCIProv"
        Me.cmbCIProv.Size = New System.Drawing.Size(117, 21)
        Me.cmbCIProv.TabIndex = 9
        '
        'cmbCICity
        '
        Me.cmbCICity.FormattingEnabled = True
        Me.cmbCICity.Location = New System.Drawing.Point(60, 93)
        Me.cmbCICity.Name = "cmbCICity"
        Me.cmbCICity.Size = New System.Drawing.Size(117, 21)
        Me.cmbCICity.TabIndex = 8
        '
        'CIAdd2
        '
        Me.CIAdd2.Location = New System.Drawing.Point(60, 71)
        Me.CIAdd2.Name = "CIAdd2"
        Me.CIAdd2.Size = New System.Drawing.Size(294, 20)
        Me.CIAdd2.TabIndex = 7
        '
        'CIadd1
        '
        Me.CIadd1.Location = New System.Drawing.Point(60, 48)
        Me.CIadd1.Name = "CIadd1"
        Me.CIadd1.Size = New System.Drawing.Size(294, 20)
        Me.CIadd1.TabIndex = 6
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
        'CIName
        '
        Me.CIName.Location = New System.Drawing.Point(60, 23)
        Me.CIName.Name = "CIName"
        Me.CIName.Size = New System.Drawing.Size(294, 20)
        Me.CIName.TabIndex = 1
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
        Me.TabPage2.Size = New System.Drawing.Size(1412, 688)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Details"
        '
        'Timer1
        '
        '
        'frmCustomers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(1440, 821)
        Me.ControlBox = False
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
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GBorders.ResumeLayout(False)
        CType(Me.DataGridOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBAccounts.ResumeLayout(False)
        CType(Me.DataGridAccts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GPCommands.ResumeLayout(False)
        Me.GBShipToAdd1.ResumeLayout(False)
        Me.GBShipToAdd1.PerformLayout()
        Me.GBcustBillto.ResumeLayout(False)
        Me.GBcustBillto.PerformLayout()
        Me.GBcustAdd1.ResumeLayout(False)
        Me.GBcustAdd1.PerformLayout()
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
    Friend WithEvents incmbCustID As ComboBox
    Friend WithEvents cmdLoadCust As Button
    Friend WithEvents incmbCustName As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtmsg As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents GBcustAdd1 As GroupBox
    Friend WithEvents GBcustBillto As GroupBox
    Friend WithEvents GBShipToAdd1 As GroupBox
    Friend WithEvents CIpcode As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbCIProv As ComboBox
    Friend WithEvents cmbCICity As ComboBox
    Friend WithEvents CIAdd2 As TextBox
    Friend WithEvents CIadd1 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents CIName As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents inchslactonly As CheckBox
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
    Friend WithEvents BLpcode As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbBLProv As ComboBox
    Friend WithEvents cmbBLcity As ComboBox
    Friend WithEvents BLadd2 As TextBox
    Friend WithEvents BLadd1 As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents BLName As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents cmbCustType As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents incmbSelType As ComboBox
    Friend WithEvents Label24 As Label
    Friend WithEvents cmbShpID As ComboBox
    Friend WithEvents Label25 As Label
    Friend WithEvents cmdSaveshipasinfo As Button
    Friend WithEvents cmdShSaveBill As Button
    Friend WithEvents cmdSaveShpto As Button
    Friend WithEvents cmdBillCopy As Button
    Friend WithEvents GPCommands As GroupBox
    Friend WithEvents cmdCanCust As Button
    Friend WithEvents cmbBLCountry As ComboBox
    Friend WithEvents Label27 As Label
    Friend WithEvents cmbCICountry As ComboBox
    Friend WithEvents Label26 As Label
    Friend WithEvents cmbSHCountry As ComboBox
    Friend WithEvents Label28 As Label
    Friend WithEvents cmdSaveCust As Button
    Friend WithEvents chCIactive As CheckBox
    Friend WithEvents GBAccounts As GroupBox
    Friend WithEvents cmdNewAcct As Button
    Friend WithEvents DataGridAccts As DataGridView
    Friend WithEvents createdby As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents dateupdate As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents datecreated As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents GBorders As GroupBox
    Friend WithEvents DataGridOrders As DataGridView
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cmdNewOrder As Button
End Class
