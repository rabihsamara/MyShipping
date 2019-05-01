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
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.TreeControls = New System.Windows.Forms.TreeView()
        Me.DataGridusrCont = New System.Windows.Forms.DataGridView()
        Me.GBeditContsec = New System.Windows.Forms.GroupBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.chkeditable = New System.Windows.Forms.CheckBox()
        Me.chkenabled = New System.Windows.Forms.CheckBox()
        Me.chkvisible = New System.Windows.Forms.CheckBox()
        Me.txtmsg = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblmsg = New System.Windows.Forms.Label()
        CType(Me.DataGridusrCont, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBeditContsec.SuspendLayout()
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
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(736, 3)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(97, 25)
        Me.cmdExit.TabIndex = 5
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'TreeControls
        '
        Me.TreeControls.Location = New System.Drawing.Point(15, 32)
        Me.TreeControls.Name = "TreeControls"
        Me.TreeControls.Size = New System.Drawing.Size(204, 680)
        Me.TreeControls.TabIndex = 6
        '
        'DataGridusrCont
        '
        Me.DataGridusrCont.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridusrCont.Location = New System.Drawing.Point(225, 32)
        Me.DataGridusrCont.Name = "DataGridusrCont"
        Me.DataGridusrCont.Size = New System.Drawing.Size(717, 680)
        Me.DataGridusrCont.TabIndex = 7
        '
        'GBeditContsec
        '
        Me.GBeditContsec.Controls.Add(Me.lblmsg)
        Me.GBeditContsec.Controls.Add(Me.Label3)
        Me.GBeditContsec.Controls.Add(Me.txtmsg)
        Me.GBeditContsec.Controls.Add(Me.cmdCancel)
        Me.GBeditContsec.Controls.Add(Me.cmdUpdate)
        Me.GBeditContsec.Controls.Add(Me.chkeditable)
        Me.GBeditContsec.Controls.Add(Me.chkenabled)
        Me.GBeditContsec.Controls.Add(Me.chkvisible)
        Me.GBeditContsec.Location = New System.Drawing.Point(955, 32)
        Me.GBeditContsec.Name = "GBeditContsec"
        Me.GBeditContsec.Size = New System.Drawing.Size(388, 131)
        Me.GBeditContsec.TabIndex = 8
        Me.GBeditContsec.TabStop = False
        Me.GBeditContsec.Text = "Edit control security"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(305, 89)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(67, 25)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point(185, 89)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(79, 25)
        Me.cmdUpdate.TabIndex = 3
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'chkeditable
        '
        Me.chkeditable.AutoSize = True
        Me.chkeditable.Location = New System.Drawing.Point(251, 57)
        Me.chkeditable.Name = "chkeditable"
        Me.chkeditable.Size = New System.Drawing.Size(64, 17)
        Me.chkeditable.TabIndex = 2
        Me.chkeditable.Text = "Editable"
        Me.chkeditable.UseVisualStyleBackColor = True
        '
        'chkenabled
        '
        Me.chkenabled.AutoSize = True
        Me.chkenabled.Location = New System.Drawing.Point(143, 57)
        Me.chkenabled.Name = "chkenabled"
        Me.chkenabled.Size = New System.Drawing.Size(65, 17)
        Me.chkenabled.TabIndex = 1
        Me.chkenabled.Text = "Enabled"
        Me.chkenabled.UseVisualStyleBackColor = True
        '
        'chkvisible
        '
        Me.chkvisible.AutoSize = True
        Me.chkvisible.Location = New System.Drawing.Point(45, 57)
        Me.chkvisible.Name = "chkvisible"
        Me.chkvisible.Size = New System.Drawing.Size(62, 17)
        Me.chkvisible.TabIndex = 0
        Me.chkvisible.Text = "Visiable"
        Me.chkvisible.UseVisualStyleBackColor = True
        '
        'txtmsg
        '
        Me.txtmsg.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtmsg.Enabled = False
        Me.txtmsg.Location = New System.Drawing.Point(40, 19)
        Me.txtmsg.Name = "txtmsg"
        Me.txtmsg.ReadOnly = True
        Me.txtmsg.Size = New System.Drawing.Size(332, 20)
        Me.txtmsg.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "For:"
        '
        'lblmsg
        '
        Me.lblmsg.AutoSize = True
        Me.lblmsg.BackColor = System.Drawing.Color.Yellow
        Me.lblmsg.Location = New System.Drawing.Point(13, 95)
        Me.lblmsg.Name = "lblmsg"
        Me.lblmsg.Size = New System.Drawing.Size(49, 13)
        Me.lblmsg.TabIndex = 7
        Me.lblmsg.Text = "message"
        '
        'frmControls
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1355, 744)
        Me.Controls.Add(Me.GBeditContsec)
        Me.Controls.Add(Me.DataGridusrCont)
        Me.Controls.Add(Me.TreeControls)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dpsfname)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dspuserdID)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmControls"
        Me.Text = "frmControls"
        CType(Me.DataGridusrCont, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBeditContsec.ResumeLayout(False)
        Me.GBeditContsec.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents dspuserdID As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dpsfname As TextBox
    Friend WithEvents cmdExit As Button
    Friend WithEvents TreeControls As TreeView
    Friend WithEvents DataGridusrCont As DataGridView
    Friend WithEvents GBeditContsec As GroupBox
    Friend WithEvents chkeditable As CheckBox
    Friend WithEvents chkenabled As CheckBox
    Friend WithEvents chkvisible As CheckBox
    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdUpdate As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtmsg As TextBox
    Friend WithEvents lblmsg As Label
End Class
