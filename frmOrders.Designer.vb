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
        Me.cmdNew = New System.Windows.Forms.Button()
        Me.GBSearch = New System.Windows.Forms.GroupBox()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.GBOrdersIN.SuspendLayout()
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
        'cmdNew
        '
        Me.cmdNew.Location = New System.Drawing.Point(401, 19)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(49, 19)
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
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(402, 53)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(47, 24)
        Me.cmdExit.TabIndex = 5
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'frmOrders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1421, 807)
        Me.Controls.Add(Me.GBSearch)
        Me.Controls.Add(Me.GBOrdersIN)
        Me.Name = "frmOrders"
        Me.Text = "frmOrders"
        Me.GBOrdersIN.ResumeLayout(False)
        Me.GBOrdersIN.PerformLayout()
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
End Class
