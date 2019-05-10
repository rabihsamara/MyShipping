Public Class frmAccounts

    Private Sub FrmAccounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim tstat As Boolean = True

        Me.Text = "Accounts"

        cmbCustNO.Visible = False
        CustNO.Visible = False
        CustName.Visible = False
        CustNO.Enabled = False
        CustName.Enabled = False

        cmbAccountNo.Visible = False
        accountNO.Visible = False
        accountNO.Enabled = False
        accountName.Enabled = False

        cmdNew.Visible = False
        cmdSave.Visible = True

        If (GlobalVariables.Gl_acctCallFrmID = "CE") Then 'called from customer screen accounts click on account details.
            CustNO.Visible = True
            CustName.Visible = True
            CustNO.Text = GlobalVariables.Gl_tmpcustid
            CustName.Text = GlobalVariables.Gl_tmpcustname
            accountNO.Visible = True
            accountName.Enabled = True

            GlobalVariables.Gl_SQLStr = "select ID,custno,AccountNo,AccountName,active,CONVERT(date,datecreated) as datecreated,CONVERT(date,dateupdated) as dateupdated,CreatedBy from accounts where ID = " & GlobalVariables.Gl_tmpacctID
            If (ReadSQL("CACCT") = False) Then
                MsgBox("Error reading account info!")
            Else
                'GlobalVariables.TmpCusAcct.MyID
                'GlobalVariables.TmpCusAcct.MyCustNo
                accountNO.Text = GlobalVariables.TmpCusAcct.MyAccountNo
                accountName.Text = GlobalVariables.TmpCusAcct.MyAccountName
                active.Checked = If(GlobalVariables.TmpCusAcct.Myactive = 1, True, False)
                datecreated.Text = GlobalVariables.TmpCusAcct.Mydatecreated
                dateupdated.Text = GlobalVariables.TmpCusAcct.Mydateupdated
                createdby.Text = GlobalVariables.TmpCusAcct.MyCreatedBy
            End If
        ElseIf (GlobalVariables.Gl_acctCallFrmID = "CN") Then
            cmdNew.Visible = True
            CustNO.Visible = True
            CustName.Visible = True
            cmbAccountNo.Visible = True
            accountName.Enabled = True
            CustNO.Text = GlobalVariables.Gl_tmpcustid
            CustName.Text = GlobalVariables.Gl_tmpcustname
            'fill combo 
            tstat = ModMisc.FillCBox(cmbCustNO, "CSINA")
            'tstat = ModMisc.FillCBox(cmbAccountNo, "CANOA")

        ElseIf (GlobalVariables.Gl_acctCallFrmID = "MM") Then
            cmdNew.Visible = True
            cmbCustNO.Visible = True

        End If

    End Sub

    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

    End Sub

    Private Sub CmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click

    End Sub

End Class