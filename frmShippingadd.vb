Public Class frmShippingadd

    Private selshprow As Integer = 0
    Private selID As Integer = 0
    Private selshpid As String = ""
    Private selcustid As String = ""
    Private selmode As String = "I"

    Private slcountryid As Integer
    Private slstateid As Integer

    Private Sub FrmShippingadd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadShipTos()

        GlobalVariables.Gl_SQLStr = "select countryname, ID from countries where active = 1 order by countryname"
        ModMisc.ReadCountries(cmbSHCountry)

    End Sub

    Private Sub LoadShipTos()

        Dim tsql As String = "select ID,custid,ShiptoID,ShipName,Shipadd1,Shipadd2,Shipcity,Shipprov,Shippcode,Shipcountry,ShipDflt,active,datecreated,dateupdated from shipto order by ID asc"
        If (ModMisc.LoadDataGrids(DataGridView1, tsql, "shipto") > 0) Then
            Me.DataGridView1.Columns(0).HeaderText = "ID"
            Me.DataGridView1.Columns(1).HeaderText = "CustomerID"
            Me.DataGridView1.Columns(2).HeaderText = "ShiptoID"
            Me.DataGridView1.Columns(3).HeaderText = "Name"
            Me.DataGridView1.Columns(4).HeaderText = "Address1"
            Me.DataGridView1.Columns(5).HeaderText = "Address2"
            Me.DataGridView1.Columns(6).HeaderText = "City"
            Me.DataGridView1.Columns(7).HeaderText = "Province"
            Me.DataGridView1.Columns(8).HeaderText = "Pcode"
            Me.DataGridView1.Columns(9).HeaderText = "Country"
            Me.DataGridView1.Columns(10).HeaderText = "Default"
            Me.DataGridView1.Columns(11).HeaderText = "Active"
            Me.DataGridView1.Columns(12).HeaderText = "Created On"
            Me.DataGridView1.Columns(13).HeaderText = "Updated On"
        End If

        dspidname.Text = GlobalVariables.Gl_tmpcustid & " - " & GlobalVariables.Gl_tmpcustname
        selcustid = GlobalVariables.Gl_tmpcustid
        GPshpAdd.Visible = False

    End Sub

    Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseClick

        If (DataGridView1.Rows.Count >= 1) Then
            selmode = "U"
            inshpid.Enabled = False
            selshprow = DataGridView1.CurrentRow.Index
            selID = DataGridView1.Item(0, selshprow).Value
            selshpid = DataGridView1.Item(2, selshprow).Value
            cmdNew.Enabled = False
            cmdExit.Enabled = False
            GPshpAdd.Visible = True
            inshpid.Text = selshpid
            selcustid = DataGridView1.Item(1, selshprow).Value
            SHName.Text = DataGridView1.Item(3, selshprow).Value
            SHadd1.Text = DataGridView1.Item(4, selshprow).Value
            SHadd2.Text = DataGridView1.Item(5, selshprow).Value
            cmbSHCity.Text = DataGridView1.Item(6, selshprow).Value
            SHPcode.Text = DataGridView1.Item(7, selshprow).Value
            cmbSHProv.Text = DataGridView1.Item(8, selshprow).Value
            cmbSHCountry.Text = DataGridView1.Item(9, selshprow).Value
            chdefault.Checked = If(DataGridView1.Item(10, selshprow).Value = 1, True, False)
            chactive.Checked = If(DataGridView1.Item(11, selshprow).Value = 1, True, False)
        End If

    End Sub

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub CmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click
        selmode = "I"
        inshpid.Enabled = True
        GPshpAdd.Visible = True
        cmdNew.Enabled = False
        cmdExit.Enabled = False

    End Sub

    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        Dim strArr() As String
        Dim tmpt As String = ""
        Dim tchr As String = ""

        'edit entry
        If (SHName.Text = "") Then
            MsgBox("Must Enter Shipping Name!")
            Exit Sub
        End If

        SHName.Text = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(SHName.Text)
        inshpid.Text = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(inshpid.Text)

        If (selmode = "I") Then
            strArr = SHName.Text.Split(" ")
            For count = 0 To strArr.Length - 1
                tmpt = Trim(strArr(count))
                tchr = tchr & If(tmpt <> "", tmpt.Substring(0, 1), "")
            Next
            inshpid.Text = tchr
            Dim result As String = InputBox("Use/Change Ship-to code!", "Accept Ship-to code", tchr, 100, 100)
            If (result = "") Then
                MsgBox("Must accept or enter a new shipto code!")
                Exit Sub
            End If
            result = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(result)
            selshpid = Trim(result)
            inshpid.Text = selshpid

            GlobalVariables.Gl_SQLStr = "Insert into shipto (custid,ShiptoID,ShipName,Shipadd1,Shipadd2,Shipcity,Shipprov,Shippcode,Shipcountry,ShipDflt,active,datecreated,dateupdated) values ('"
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & selcustid & "','" & selshpid & "','" & Trim(SHName.Text) & "','" & Trim(SHadd1.Text) & "','" & Trim(SHadd2.Text) & "','"
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & cmbSHCity.Text & "','" & cmbSHProv.Text & "','" & SHPcode.Text & "','" & cmbSHCountry.Text & "',"
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & If(chdefault.Checked = True, 1, 0) & "," & If(chactive.Checked = True, 1, 0) & ",'" & Now() & "','" & Now() & "')"
        Else
            GlobalVariables.Gl_SQLStr = "update shipto set ShipName = '" & Trim(SHName.Text) & "',shipadd1 = '" & SHadd1.Text & "', Shipadd2 = '" & Trim(SHadd2.Text)
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "',Shipcity = '" & cmbSHCity.Text & "',Shipprov = '" & cmbSHProv.Text & "',Shippcode ='" & SHPcode.Text
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "',Shipcountry = '" & cmbSHCountry.Text & "', ShipDflt = " & If(chdefault.Checked = True, 1, 0) & ", active = " & If(chactive.Checked = True, 1, 0) & ",dateupdated = '" & Now()
            GlobalVariables.Gl_SQLStr = GlobalVariables.Gl_SQLStr & "' where ID = " & selID
        End If

        If (ExecuteSqlTransaction(GlobalVariables.Gl_ConnectionSTR) = False) Then
            MsgBox("Error updating Shipto address!")
        End If
        LoadShipTos()
        GPshpAdd.Visible = False
        cmdNew.Enabled = True
        cmdExit.Enabled = True
        clearfields()

    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        GPshpAdd.Visible = False
        cmdNew.Enabled = True
        cmdExit.Enabled = True
        clearfields()

    End Sub

    Private Sub clearfields()
        inshpid.Text = ""
        SHName.Text = ""
        SHadd1.Text = ""
        SHadd2.Text = ""
        cmbSHCity.Text = ""
        SHPcode.Text = ""
        cmbSHProv.Text = ""
        cmbSHCountry.Text = ""
        chdefault.Checked = False
        chactive.Checked = False

    End Sub

    Private Sub cmbSHCountry_SelectedChangeCommitted(sender As Object, e As EventArgs) Handles cmbSHCountry.SelectionChangeCommitted
        slcountryid = cmbSHCountry.SelectedValue

        GlobalVariables.Gl_SQLStr = "select provshort as countryname, ID from provinces where countryid = " & slcountryid & " and active = 1 order by provshort"
        ModMisc.ReadCountries(cmbSHProv)

    End Sub

    Private Sub cmbSHProv_SelectedChangeCommitted(sender As Object, e As EventArgs) Handles cmbSHProv.SelectionChangeCommitted

        slstateid = cmbSHProv.SelectedValue
        GlobalVariables.Gl_SQLStr = "select cityname as countryname, ID from cities where countryid = " & slcountryid & " and provid = " & slstateid & " and cityactive = 1 order by cityname"
        ModMisc.ReadCountries(cmbSHCity)

    End Sub


End Class