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
        Me.createdby = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.dateupdated = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.datecreated = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.OrderNO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.active = New System.Windows.Forms.CheckBox()
        Me.GBOrdersIN.SuspendLayout()
        Me.GBOrdInfo.SuspendLayout()
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
        Me.cmdExit.Location = New System.Drawing.Point(391, 43)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(74, 24)
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
        Me.GBSearch.Location = New System.Drawing.Point(510, 1)
        Me.GBSearch.Name = "GBSearch"
        Me.GBSearch.Size = New System.Drawing.Size(892, 87)
        Me.GBSearch.TabIndex = 5
        Me.GBSearch.TabStop = False
        Me.GBSearch.Text = "Search By"
        '
        'GBOrdInfo
        '
        Me.GBOrdInfo.Controls.Add(Me.active)
        Me.GBOrdInfo.Controls.Add(Me.createdby)
        Me.GBOrdInfo.Controls.Add(Me.Label31)
        Me.GBOrdInfo.Controls.Add(Me.dateupdated)
        Me.GBOrdInfo.Controls.Add(Me.Label30)
        Me.GBOrdInfo.Controls.Add(Me.datecreated)
        Me.GBOrdInfo.Controls.Add(Me.Label29)
        Me.GBOrdInfo.Controls.Add(Me.OrderNO)
        Me.GBOrdInfo.Controls.Add(Me.Label3)
        Me.GBOrdInfo.Location = New System.Drawing.Point(1, 94)
        Me.GBOrdInfo.Name = "GBOrdInfo"
        Me.GBOrdInfo.Size = New System.Drawing.Size(508, 165)
        Me.GBOrdInfo.TabIndex = 6
        Me.GBOrdInfo.TabStop = False
        Me.GBOrdInfo.Text = "Order Information"
        '
        'createdby
        '
        Me.createdby.BackColor = System.Drawing.SystemColors.Info
        Me.createdby.Enabled = False
        Me.createdby.Location = New System.Drawing.Point(262, 136)
        Me.createdby.Name = "createdby"
        Me.createdby.Size = New System.Drawing.Size(94, 20)
        Me.createdby.TabIndex = 35
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(205, 139)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(62, 13)
        Me.Label31.TabIndex = 34
        Me.Label31.Text = "Created By:"
        '
        'dateupdated
        '
        Me.dateupdated.BackColor = System.Drawing.SystemColors.Info
        Me.dateupdated.Enabled = False
        Me.dateupdated.Location = New System.Drawing.Point(81, 136)
        Me.dateupdated.Name = "dateupdated"
        Me.dateupdated.Size = New System.Drawing.Size(120, 20)
        Me.dateupdated.TabIndex = 33
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(6, 143)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(77, 13)
        Me.Label30.TabIndex = 32
        Me.Label30.Text = "Date Updated:"
        '
        'datecreated
        '
        Me.datecreated.BackColor = System.Drawing.SystemColors.Info
        Me.datecreated.Enabled = False
        Me.datecreated.Location = New System.Drawing.Point(81, 115)
        Me.datecreated.Name = "datecreated"
        Me.datecreated.Size = New System.Drawing.Size(120, 20)
        Me.datecreated.TabIndex = 31
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(11, 119)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(73, 13)
        Me.Label29.TabIndex = 30
        Me.Label29.Text = "Date Created:"
        '
        'OrderNO
        '
        Me.OrderNO.Location = New System.Drawing.Point(61, 17)
        Me.OrderNO.Name = "OrderNO"
        Me.OrderNO.Size = New System.Drawing.Size(135, 20)
        Me.OrderNO.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Order NO:"
        '
        'active
        '
        Me.active.AutoSize = True
        Me.active.Location = New System.Drawing.Point(208, 19)
        Me.active.Name = "active"
        Me.active.Size = New System.Drawing.Size(56, 17)
        Me.active.TabIndex = 36
        Me.active.Text = "Active"
        Me.active.UseVisualStyleBackColor = True
        '
        'frmOrders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1421, 807)
        Me.Controls.Add(Me.GBOrdInfo)
        Me.Controls.Add(Me.GBSearch)
        Me.Controls.Add(Me.GBOrdersIN)
        Me.Name = "frmOrders"
        Me.Text = "frmOrders"
        Me.GBOrdersIN.ResumeLayout(False)
        Me.GBOrdersIN.PerformLayout()
        Me.GBOrdInfo.ResumeLayout(False)
        Me.GBOrdInfo.PerformLayout()
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
    Friend WithEvents active As CheckBox
End Class
