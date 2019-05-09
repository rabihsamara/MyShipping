Public Class frmAccounts

    Private Sub FrmAccounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Accounts for user: " & GlobalVariables.Gl_tmpcustid & " - " & GlobalVariables.Gl_tmpcustname
        cmdNew.Visible = False
        If (GlobalVariables.Gl_tmpacctID <> 0) Then 'called from customer screen accounts click on account details.
            accountNO.Enabled = False
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
                dateupdated.text = GlobalVariables.TmpCusAcct.Mydateupdated
                createdby.Text = GlobalVariables.TmpCusAcct.MyCreatedBy
            End If
        Else
            cmdNew.Visible = True

        End If

    End Sub


End Class