Public Class frmShippingadd
    Private Sub FrmShippingadd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim tsql As String = "select * from shipto order by ID asc"
        dspidname.Text = GlobalVariables.Gl_tmpcustid & " - " & GlobalVariables.Gl_tmpcustname

        ModMisc.LoadDataGrids(DataGridView1, tsql, "shipto")

        ''check if existing customer ship inof has not changes screen to saved
        'If (Custrecord.MySHName = SHName.Text And Custrecord.MySHadd1 = SHadd1.Text And
        '    Custrecord.MySHadd2 = SHadd2.Text And Custrecord.MycmbSHCity = cmbSHCity.Text And
        '    Custrecord.MycmbSHProv = cmbSHProv.Text And Custrecord.MySHPcode = SHPcode.Text And
        '    Custrecord.MycmbSHCountry = cmbSHCountry.Text) Then
        '    MsgBox("Shipto has not changed!")
        '    Exit Sub
        'End If

        'If (selShipToid = "") Then
        '        CIcustshipto = GetShiptoRec(selcustid, selShipToid)


        '        Dim result As DialogResult = MessageBox.Show("Create New Ship-to ID?", "Confirm add new ship-to ID", MessageBoxButtons.YesNo)
        '        If (result = DialogResult.Yes) Then
        '            If (cmbShpID.Text = "") Then


        '            End If

        '        Else
        '            Exit Sub
        '        End If

        '    End If

    End Sub

End Class