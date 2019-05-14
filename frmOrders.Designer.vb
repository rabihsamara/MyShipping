<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOrders
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.inCustIdName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.inacctNO = New System.Windows.Forms.TextBox()
        Me.GBOrdersIN = New System.Windows.Forms.GroupBox()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdNew = New System.Windows.Forms.Button()
        Me.GBSearch = New System.Windows.Forms.GroupBox()
        Me.GBOrdInfo = New System.Windows.Forms.GroupBox()
        Me.cmbshpmethod = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbShpType = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.OrdStat = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.OrderNO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.createdby = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.dateupdated = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.datecreated = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.GBSHBLInfo = New System.Windows.Forms.GroupBox()
        Me.cmdCopyshp = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbBLCountry = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
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
        Me.cmbSHCountry = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.ordshipID = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
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
        Me.TabContord = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GBModInfo = New System.Windows.Forms.GroupBox()
        Me.GBOrdersIN.SuspendLayout()
        Me.GBOrdInfo.SuspendLayout()
        Me.GBSHBLInfo.SuspendLayout()
        Me.TabContord.SuspendLayout()
        Me.GBModInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Customer ID/Name:"
        '
        'inCustIdName
        '
        Me.inCustIdName.Location = New System.Drawing.Point(103, 19)
        Me.inCustIdName.Name = "inCustIdName"
        Me.inCustIdName.Size = New System.Drawing.Size(282, 20)
        Me.inCustIdName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(49, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Account#:"
        '
        'inacctNO
        '
        Me.inacctNO.Location = New System.Drawing.Point(103, 44)
        Me.inacctNO.Name = "inacctNO"
        Me.inacctNO.Size = New System.Drawing.Size(154, 20)
        Me.inacctNO.TabIndex = 3
        '
        'GBOrdersIN
        '
        Me.GBOrdersIN.BackColor = System.Drawing.SystemColors.Control
        Me.GBOrdersIN.Controls.Add(Me.cmdSave)
        Me.GBOrdersIN.Controls.Add(Me.cmdExit)
        Me.GBOrdersIN.Controls.Add(Me.cmdNew)
        Me.GBOrdersIN.Controls.Add(Me.inCustIdName)
        Me.GBOrdersIN.Controls.Add(Me.inacctNO)
        Me.GBOrdersIN.Controls.Add(Me.Label1)
        Me.GBOrdersIN.Controls.Add(Me.Label2)
        Me.GBOrdersIN.Location = New System.Drawing.Point(1, 1)
        Me.GBOrdersIN.Name = "GBOrdersIN"
        Me.GBOrdersIN.Size = New System.Drawing.Size(508, 87)
        Me.GBOrdersIN.TabIndex = 4
        Me.GBOrdersIN.TabStop = False
        Me.GBOrdersIN.Text = "Orders"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(283, 45)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(73, 22)
        Me.cmdSave.TabIndex = 6
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(391, 44)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(74, 23)
        Me.cmdExit.TabIndex = 5
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdNew
        '
        Me.cmdNew.Location = New System.Drawing.Point(391, 19)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(74, 19)
        Me.cmdNew.TabIndex = 4
        Me.cmdNew.Text = "New"
        Me.cmdNew.UseVisualStyleBackColor = True
        '
        'GBSearch
        '
        Me.GBSearch.BackColor = System.Drawing.SystemColors.Control
        Me.GBSearch.Location = New System.Drawing.Point(509, 1)
        Me.GBSearch.Name = "GBSearch"
        Me.GBSearch.Size = New System.Drawing.Size(893, 87)
        Me.GBSearch.TabIndex = 5
        Me.GBSearch.TabStop = False
        Me.GBSearch.Text = "Search By"
        '
        'GBOrdInfo
        '
        Me.GBOrdInfo.Controls.Add(Me.cmbshpmethod)
        Me.GBOrdInfo.Controls.Add(Me.Label7)
        Me.GBOrdInfo.Controls.Add(Me.cmbShpType)
        Me.GBOrdInfo.Controls.Add(Me.Label6)
        Me.GBOrdInfo.Controls.Add(Me.OrdStat)
        Me.GBOrdInfo.Controls.Add(Me.Label4)
        Me.GBOrdInfo.Controls.Add(Me.OrderNO)
        Me.GBOrdInfo.Controls.Add(Me.Label3)
        Me.GBOrdInfo.Location = New System.Drawing.Point(1, 94)
        Me.GBOrdInfo.Name = "GBOrdInfo"
        Me.GBOrdInfo.Size = New System.Drawing.Size(385, 109)
        Me.GBOrdInfo.TabIndex = 6
        Me.GBOrdInfo.TabStop = False
        Me.GBOrdInfo.Text = "Order Information"
        '
        'cmbshpmethod
        '
        Me.cmbshpmethod.FormattingEnabled = True
        Me.cmbshpmethod.Location = New System.Drawing.Point(76, 70)
        Me.cmbshpmethod.Name = "cmbshpmethod"
        Me.cmbshpmethod.Size = New System.Drawing.Size(284, 21)
        Me.cmbshpmethod.TabIndex = 41
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "Ship Method:"
        '
        'cmbShpType
        '
        Me.cmbShpType.FormattingEnabled = True
        Me.cmbShpType.Location = New System.Drawing.Point(76, 43)
        Me.cmbShpType.Name = "cmbShpType"
        Me.cmbShpType.Size = New System.Drawing.Size(193, 21)
        Me.cmbShpType.TabIndex = 39
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Ship Type:"
        '
        'OrdStat
        '
        Me.OrdStat.FormattingEnabled = True
        Me.OrdStat.Location = New System.Drawing.Point(268, 16)
        Me.OrdStat.Name = "OrdStat"
        Me.OrdStat.Size = New System.Drawing.Size(92, 21)
        Me.OrdStat.TabIndex = 37
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(200, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Order Status:"
        '
        'OrderNO
        '
        Me.OrderNO.Location = New System.Drawing.Point(76, 17)
        Me.OrderNO.Name = "OrderNO"
        Me.OrderNO.Size = New System.Drawing.Size(120, 20)
        Me.OrderNO.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Order NO:"
        '
        'createdby
        '
        Me.createdby.BackColor = System.Drawing.SystemColors.Info
        Me.createdby.Enabled = False
        Me.createdby.Location = New System.Drawing.Point(276, 37)
        Me.createdby.Name = "createdby"
        Me.createdby.Size = New System.Drawing.Size(94, 20)
        Me.createdby.TabIndex = 35
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(212, 40)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(62, 13)
        Me.Label31.TabIndex = 34
        Me.Label31.Text = "Created By:"
        '
        'dateupdated
        '
        Me.dateupdated.BackColor = System.Drawing.SystemColors.Info
        Me.dateupdated.Enabled = False
        Me.dateupdated.Location = New System.Drawing.Point(87, 37)
        Me.dateupdated.Name = "dateupdated"
        Me.dateupdated.Size = New System.Drawing.Size(120, 20)
        Me.dateupdated.TabIndex = 33
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(10, 41)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(77, 13)
        Me.Label30.TabIndex = 32
        Me.Label30.Text = "Date Updated:"
        '
        'datecreated
        '
        Me.datecreated.BackColor = System.Drawing.SystemColors.Info
        Me.datecreated.Enabled = False
        Me.datecreated.Location = New System.Drawing.Point(87, 16)
        Me.datecreated.Name = "datecreated"
        Me.datecreated.Size = New System.Drawing.Size(120, 20)
        Me.datecreated.TabIndex = 31
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(13, 20)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(73, 13)
        Me.Label29.TabIndex = 30
        Me.Label29.Text = "Date Created:"
        '
        'GBSHBLInfo
        '
        Me.GBSHBLInfo.Controls.Add(Me.cmdCopyshp)
        Me.GBSHBLInfo.Controls.Add(Me.Label5)
        Me.GBSHBLInfo.Controls.Add(Me.cmbBLCountry)
        Me.GBSHBLInfo.Controls.Add(Me.Label27)
        Me.GBSHBLInfo.Controls.Add(Me.BLpcode)
        Me.GBSHBLInfo.Controls.Add(Me.Label11)
        Me.GBSHBLInfo.Controls.Add(Me.cmbBLProv)
        Me.GBSHBLInfo.Controls.Add(Me.cmbBLcity)
        Me.GBSHBLInfo.Controls.Add(Me.BLadd2)
        Me.GBSHBLInfo.Controls.Add(Me.BLadd1)
        Me.GBSHBLInfo.Controls.Add(Me.Label12)
        Me.GBSHBLInfo.Controls.Add(Me.Label13)
        Me.GBSHBLInfo.Controls.Add(Me.Label14)
        Me.GBSHBLInfo.Controls.Add(Me.Label15)
        Me.GBSHBLInfo.Controls.Add(Me.BLName)
        Me.GBSHBLInfo.Controls.Add(Me.Label16)
        Me.GBSHBLInfo.Controls.Add(Me.cmbSHCountry)
        Me.GBSHBLInfo.Controls.Add(Me.Label28)
        Me.GBSHBLInfo.Controls.Add(Me.ordshipID)
        Me.GBSHBLInfo.Controls.Add(Me.Label25)
        Me.GBSHBLInfo.Controls.Add(Me.SHPcode)
        Me.GBSHBLInfo.Controls.Add(Me.Label17)
        Me.GBSHBLInfo.Controls.Add(Me.cmbSHProv)
        Me.GBSHBLInfo.Controls.Add(Me.cmbSHCity)
        Me.GBSHBLInfo.Controls.Add(Me.SHadd2)
        Me.GBSHBLInfo.Controls.Add(Me.SHadd1)
        Me.GBSHBLInfo.Controls.Add(Me.Label18)
        Me.GBSHBLInfo.Controls.Add(Me.Label19)
        Me.GBSHBLInfo.Controls.Add(Me.Label20)
        Me.GBSHBLInfo.Controls.Add(Me.Label21)
        Me.GBSHBLInfo.Controls.Add(Me.SHName)
        Me.GBSHBLInfo.Controls.Add(Me.Label22)
        Me.GBSHBLInfo.Location = New System.Drawing.Point(1, 209)
        Me.GBSHBLInfo.Name = "GBSHBLInfo"
        Me.GBSHBLInfo.Size = New System.Drawing.Size(385, 325)
        Me.GBSHBLInfo.TabIndex = 7
        Me.GBSHBLInfo.TabStop = False
        Me.GBSHBLInfo.Text = "Shipping/Billing Information"
        '
        'cmdCopyshp
        '
        Me.cmdCopyshp.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdCopyshp.Location = New System.Drawing.Point(268, 161)
        Me.cmdCopyshp.Name = "cmdCopyshp"
        Me.cmdCopyshp.Size = New System.Drawing.Size(83, 30)
        Me.cmdCopyshp.TabIndex = 62
        Me.cmdCopyshp.Text = "Copy ShipTo"
        Me.cmdCopyshp.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = "Billing Information"
        '
        'cmbBLCountry
        '
        Me.cmbBLCountry.FormattingEnabled = True
        Me.cmbBLCountry.Location = New System.Drawing.Point(251, 292)
        Me.cmbBLCountry.Name = "cmbBLCountry"
        Me.cmbBLCountry.Size = New System.Drawing.Size(100, 21)
        Me.cmbBLCountry.TabIndex = 60
        Me.cmbBLCountry.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(201, 295)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(46, 13)
        Me.Label27.TabIndex = 59
        Me.Label27.Text = "Country:"
        '
        'BLpcode
        '
        Me.BLpcode.Location = New System.Drawing.Point(251, 266)
        Me.BLpcode.Name = "BLpcode"
        Me.BLpcode.Size = New System.Drawing.Size(100, 20)
        Me.BLpcode.TabIndex = 58
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(180, 268)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 13)
        Me.Label11.TabIndex = 57
        Me.Label11.Text = "Postal Code:"
        '
        'cmbBLProv
        '
        Me.cmbBLProv.FormattingEnabled = True
        Me.cmbBLProv.Location = New System.Drawing.Point(57, 292)
        Me.cmbBLProv.Name = "cmbBLProv"
        Me.cmbBLProv.Size = New System.Drawing.Size(117, 21)
        Me.cmbBLProv.TabIndex = 56
        '
        'cmbBLcity
        '
        Me.cmbBLcity.FormattingEnabled = True
        Me.cmbBLcity.Location = New System.Drawing.Point(57, 265)
        Me.cmbBLcity.Name = "cmbBLcity"
        Me.cmbBLcity.Size = New System.Drawing.Size(117, 21)
        Me.cmbBLcity.TabIndex = 55
        '
        'BLadd2
        '
        Me.BLadd2.Location = New System.Drawing.Point(57, 243)
        Me.BLadd2.Name = "BLadd2"
        Me.BLadd2.Size = New System.Drawing.Size(294, 20)
        Me.BLadd2.TabIndex = 54
        '
        'BLadd1
        '
        Me.BLadd1.Location = New System.Drawing.Point(57, 220)
        Me.BLadd1.Name = "BLadd1"
        Me.BLadd1.Size = New System.Drawing.Size(294, 20)
        Me.BLadd1.TabIndex = 53
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(5, 295)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 52
        Me.Label12.Text = "Province:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(30, 265)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(27, 13)
        Me.Label13.TabIndex = 51
        Me.Label13.Text = "City:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 243)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 13)
        Me.Label14.TabIndex = 50
        Me.Label14.Text = "Address2:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 223)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 13)
        Me.Label15.TabIndex = 49
        Me.Label15.Text = "Address1:"
        '
        'BLName
        '
        Me.BLName.Location = New System.Drawing.Point(57, 195)
        Me.BLName.Name = "BLName"
        Me.BLName.Size = New System.Drawing.Size(294, 20)
        Me.BLName.TabIndex = 48
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(19, 198)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(38, 13)
        Me.Label16.TabIndex = 47
        Me.Label16.Text = "Name:"
        '
        'cmbSHCountry
        '
        Me.cmbSHCountry.FormattingEnabled = True
        Me.cmbSHCountry.Location = New System.Drawing.Point(253, 139)
        Me.cmbSHCountry.Name = "cmbSHCountry"
        Me.cmbSHCountry.Size = New System.Drawing.Size(100, 21)
        Me.cmbSHCountry.TabIndex = 46
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(203, 142)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(46, 13)
        Me.Label28.TabIndex = 45
        Me.Label28.Text = "Country:"
        '
        'ordshipID
        '
        Me.ordshipID.FormattingEnabled = True
        Me.ordshipID.Location = New System.Drawing.Point(61, 19)
        Me.ordshipID.Name = "ordshipID"
        Me.ordshipID.Size = New System.Drawing.Size(295, 21)
        Me.ordshipID.TabIndex = 44
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(3, 22)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(58, 13)
        Me.Label25.TabIndex = 43
        Me.Label25.Text = "ShipTo ID:"
        '
        'SHPcode
        '
        Me.SHPcode.Location = New System.Drawing.Point(255, 113)
        Me.SHPcode.Name = "SHPcode"
        Me.SHPcode.Size = New System.Drawing.Size(100, 20)
        Me.SHPcode.TabIndex = 42
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(184, 115)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(67, 13)
        Me.Label17.TabIndex = 41
        Me.Label17.Text = "Postal Code:"
        '
        'cmbSHProv
        '
        Me.cmbSHProv.FormattingEnabled = True
        Me.cmbSHProv.Location = New System.Drawing.Point(61, 139)
        Me.cmbSHProv.Name = "cmbSHProv"
        Me.cmbSHProv.Size = New System.Drawing.Size(117, 21)
        Me.cmbSHProv.TabIndex = 40
        '
        'cmbSHCity
        '
        Me.cmbSHCity.FormattingEnabled = True
        Me.cmbSHCity.Location = New System.Drawing.Point(61, 112)
        Me.cmbSHCity.Name = "cmbSHCity"
        Me.cmbSHCity.Size = New System.Drawing.Size(117, 21)
        Me.cmbSHCity.TabIndex = 39
        '
        'SHadd2
        '
        Me.SHadd2.Location = New System.Drawing.Point(61, 90)
        Me.SHadd2.Name = "SHadd2"
        Me.SHadd2.Size = New System.Drawing.Size(294, 20)
        Me.SHadd2.TabIndex = 38
        '
        'SHadd1
        '
        Me.SHadd1.Location = New System.Drawing.Point(61, 67)
        Me.SHadd1.Name = "SHadd1"
        Me.SHadd1.Size = New System.Drawing.Size(294, 20)
        Me.SHadd1.TabIndex = 37
        '
        'Label18
        '
        Me.Label18.AllowDrop = True
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(9, 142)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(52, 13)
        Me.Label18.TabIndex = 36
        Me.Label18.Text = "Province:"
        Me.Label18.UseMnemonic = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(34, 112)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(27, 13)
        Me.Label19.TabIndex = 35
        Me.Label19.Text = "City:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(7, 90)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(54, 13)
        Me.Label20.TabIndex = 34
        Me.Label20.Text = "Address2:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(7, 70)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(54, 13)
        Me.Label21.TabIndex = 33
        Me.Label21.Text = "Address1:"
        '
        'SHName
        '
        Me.SHName.Location = New System.Drawing.Point(61, 42)
        Me.SHName.Name = "SHName"
        Me.SHName.Size = New System.Drawing.Size(294, 20)
        Me.SHName.TabIndex = 32
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(23, 45)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(38, 13)
        Me.Label22.TabIndex = 31
        Me.Label22.Text = "Name:"
        '
        'TabContord
        '
        Me.TabContord.Controls.Add(Me.TabPage1)
        Me.TabContord.Controls.Add(Me.TabPage2)
        Me.TabContord.Location = New System.Drawing.Point(393, 105)
        Me.TabContord.Name = "TabContord"
        Me.TabContord.SelectedIndex = 0
        Me.TabContord.Size = New System.Drawing.Size(1009, 501)
        Me.TabContord.TabIndex = 8
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FloralWhite
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1001, 475)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FloralWhite
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1001, 475)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        '
        'GBModInfo
        '
        Me.GBModInfo.Controls.Add(Me.Label31)
        Me.GBModInfo.Controls.Add(Me.Label29)
        Me.GBModInfo.Controls.Add(Me.createdby)
        Me.GBModInfo.Controls.Add(Me.datecreated)
        Me.GBModInfo.Controls.Add(Me.Label30)
        Me.GBModInfo.Controls.Add(Me.dateupdated)
        Me.GBModInfo.Location = New System.Drawing.Point(5, 540)
        Me.GBModInfo.Name = "GBModInfo"
        Me.GBModInfo.Size = New System.Drawing.Size(381, 66)
        Me.GBModInfo.TabIndex = 9
        Me.GBModInfo.TabStop = False
        Me.GBModInfo.Text = "Update Information"
        '
        'frmOrders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1421, 807)
        Me.Controls.Add(Me.GBModInfo)
        Me.Controls.Add(Me.TabContord)
        Me.Controls.Add(Me.GBSHBLInfo)
        Me.Controls.Add(Me.GBOrdInfo)
        Me.Controls.Add(Me.GBSearch)
        Me.Controls.Add(Me.GBOrdersIN)
        Me.Name = "frmOrders"
        Me.Text = "frmOrders"
        Me.GBOrdersIN.ResumeLayout(False)
        Me.GBOrdersIN.PerformLayout()
        Me.GBOrdInfo.ResumeLayout(False)
        Me.GBOrdInfo.PerformLayout()
        Me.GBSHBLInfo.ResumeLayout(False)
        Me.GBSHBLInfo.PerformLayout()
        Me.TabContord.ResumeLayout(False)
        Me.GBModInfo.ResumeLayout(False)
        Me.GBModInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents inCustIdName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents inacctNO As TextBox
    Friend WithEvents GBOrdersIN As GroupBox
    Friend WithEvents cmdNew As Button
    Friend WithEvents GBSearch As GroupBox
    Friend WithEvents cmdExit As Button
    Friend WithEvents GBOrdInfo As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents OrderNO As TextBox
    Friend WithEvents createdby As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents dateupdated As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents datecreated As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents cmdSave As Button
    Friend WithEvents OrdStat As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GBSHBLInfo As GroupBox
    Friend WithEvents cmbSHCountry As ComboBox
    Friend WithEvents Label28 As Label
    Friend WithEvents ordshipID As ComboBox
    Friend WithEvents Label25 As Label
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
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbBLCountry As ComboBox
    Friend WithEvents Label27 As Label
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
    Friend WithEvents cmdCopyshp As Button
    Friend WithEvents TabContord As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GBModInfo As GroupBox
    Friend WithEvents cmbShpType As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbshpmethod As ComboBox
    Friend WithEvents Label7 As Label
End Class
