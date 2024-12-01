Imports System.Net

Public Class Form_Main

    Dim prod_id As Integer
    Public customerId As Integer
    Public utagValue, filterType As String
    Dim searchReport, searchText As String
    Dim filterType2 As String
    Dim searchReport2 As String
    Public utype As String
    Private Sub Main_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Overall_Sales_Total()
        Overall_Sales_Amount()
        Overall_Sales_WalKIn()
        Overall_Sales_Delivery()
        cmbType.SelectedIndex = 0

        Me.Refresh()

        Load_Sales_Data()
        Load_Sales_Report_Data()
        Transactions_Range_Form()
        Sales_Range_Form()
        Number_Sales_Range_Form()

        Transaction_Month()
        Amount_Month()
        Sales_Month()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then

            Dim formsToClose As New List(Of Form)
            For Each frm As Form In Application.OpenForms
                If frm IsNot Form_Login Then
                    formsToClose.Add(frm)
                End If
            Next

            For Each frm As Form In formsToClose
                frm.Close()
            Next

            Form_Login.txtUsername.Text = ""
            Form_Login.txtPassword.Text = ""

            MessageBox.Show("Logged Out Successfully")
            Form_Login.Show()
        End If
    End Sub



    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click


        Dim Form_Create As New Form_CRUD()
        Form_Create.btnUpdate.Visible = False
        Form_Create.ShowDialog()

    End Sub

    Private Sub btnSalesUpdate_Click(sender As Object, e As EventArgs) Handles btnSalesUpdate.Click
        If dgvSales.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgvSales.SelectedRows(0)

            customerId = CInt(selectedRow.Cells("customer_id").Value)
            Dim uname As String = selectedRow.Cells("name").Value.ToString()
            utagValue = selectedRow.Cells("product").Value.ToString()
            Dim uprice As Double = CDbl(selectedRow.Cells("price").Value)
            Dim uqty As Long = CLng(selectedRow.Cells("quantity").Value)
            Dim uamount As Double = CDbl(selectedRow.Cells("amount").Value)
            utype = selectedRow.Cells("type").Value.ToString()
            Dim ustatus As String = selectedRow.Cells("status").Value.ToString()
            Dim unumber As Long = CLng(selectedRow.Cells("contact number").Value)
            Dim uaddress As String = selectedRow.Cells("address").Value.ToString()
            Dim udate As String = selectedRow.Cells("date").Value.ToString()
            insertedCustomerId = customerId

            utype = selectedRow.Cells("type").Value.ToString()

            Dim Form_Update As New Form_CRUD(utype)

            Form_Update.txtName.Text = uname
            Form_Update.tagValue = utagValue
            Form_Update.price = uprice
            Form_Update.txtQty.Text = uqty
            Form_Update.amount = uamount
            Form_Update.productType = utype
            Form_Update.cmbPayment.Text = ustatus
            Form_Update.txtContactnumber.Text = unumber
            Form_Update.txtAddress.Text = uaddress
            Form_Update.dated = udate
            Form_Update.btnAdd.Visible = False
            If utype = "WalkIn" And utagValue = "Refill" Then
                Form_Update.WalkIn_Refill.BorderStyle = BorderStyle.Fixed3D

            ElseIf utype = "WalkIn" And utagValue = "Bundle" Then
                Form_Update.WalkIn_Bundle.BorderStyle = BorderStyle.Fixed3D

            ElseIf utype = "WalkIn" And utagValue = "Cap" Then
                Form_Update.Cap.BorderStyle = BorderStyle.Fixed3D

            End If
            If utype = "Delivery" And utagValue = "Refill" Then
                Form_Update.Del_Refill.BorderStyle = BorderStyle.Fixed3D

            ElseIf utype = "Delivery" And utagValue = "Bundle" Then
                Form_Update.Del_Bundle.BorderStyle = BorderStyle.Fixed3D

            End If

            Form_Update.ShowDialog()
        Else
            MessageBox.Show("Please select a row to update.")
        End If
    End Sub


    Private Sub btnSalesDelete_Click(sender As Object, e As EventArgs) Handles btnSalesDelete.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this data?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            If dgvSales.SelectedRows.Count > 0 Then
                Dim cellValue As Object = dgvSales.CurrentRow.Cells(0).Value

                If Not IsDBNull(cellValue) Then
                    prod_id = Convert.ToInt32(cellValue)

                End If
                Remove_Sales_Data(prod_id)

            End If
        End If
        Load_Sales_Data()
    End Sub




    Private Sub txtSalesSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSalesSearch.TextChanged
        searchText = txtSalesSearch.Text.Trim()

        Search_Sales_Data(searchText)

    End Sub

    Private filterApplied As Boolean = False
    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        txtSearchReport.Show()
        txtSearchType.Hide()
        txtSearchType.Clear()
        searchReport = txtSearchReport.Text.Trim()
        filterType = cmbType.Text
        filterApplied = True

        If filterApplied Then
            If dtpFrom.Value <= dtpTo.Value Then
                If cmbType.SelectedIndex = 1 Or cmbType.SelectedIndex = 2 Then
                    Transactions_Range(filterType)
                    Sales_Range(filterType)
                    Number_Sales_Range(filterType)
                    Search_Sales_Report_Data_Date(searchReport, filterType)

                    Load_Sales_Report_Data_Date(filterType)
                Else
                    Transactions_Range_All_Type()
                    Sales_Range_All_Type()
                    Number_Sales_Range_All_Type()
                    Search_Sales_Report_Data_Date_All(searchReport)
                    Load_Sales_Report_All_Data_Date()
                End If
            ElseIf dtpFrom.Value > dtpTo.Value Then
                MessageBox.Show("Please select a valid date range. The 'From Date' must be earlier than or equal to the 'To Date'.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf cmbType.SelectedIndex = 1 Or cmbType.SelectedIndex = 2 Then
                Search_Sales_Report_Data_Type(searchReport, filterType)
            End If
        End If



    End Sub

    Private Sub txtSearchReport_TextChanged(sender As Object, e As EventArgs) Handles txtSearchReport.TextChanged
        searchReport = txtSearchReport.Text.Trim()


        If filterApplied Then
            If cmbType.SelectedIndex = 0 Then
                Search_Sales_Report_Data(searchReport)
                Search_Sales_Report_Data_Date_All(searchReport)

            ElseIf cmbType.SelectedIndex = 1 Or cmbType.SelectedIndex = 2 Then
                Search_Sales_Report_Data_Date(searchReport, filterType)

            End If


        End If
    End Sub

    Private Sub btnReportClear_Click(sender As Object, e As EventArgs) Handles btnReportClear.Click
        txtSearchReport.Text = ""
        dtpFrom.Value = DateTime.Now
        dtpTo.Value = DateTime.Now.AddSeconds(1)
        dtpTransMth.Value = DateTime.Now
        dtpSalesMth.Value = DateTime.Now
        dtpAmountMth.Value = DateTime.Now
        cmbType.SelectedIndex = 0
        txtSearchType.Text = ""
        txtSearchType.Show()
        txtSearchReport.Clear()
        filterType2 = cmbType.Text

        If cmbType.SelectedIndex = 1 OrElse cmbType.SelectedIndex = 2 Then

            Transactions_Range_Type(filterType2)
            Sales_Range_Type(filterType2)
            Number_Sales_Range_Type(filterType2)
            Search_Sales_Report_Data_Type(searchReport2, filterType2)
            Load_Sales_Report_Data_Type(filterType2)
        Else
            Search_Sales_Report_Data(searchReport2)
            Load_Sales_Report_Data()
            Transactions_Range_Form()
            Sales_Range_Form()
            Number_Sales_Range_Form()

        End If
    End Sub

    Private Sub txtSearchType_TextChanged(sender As Object, e As EventArgs) Handles txtSearchType.TextChanged
        searchReport2 = txtSearchType.Text.Trim()

        If cmbType.SelectedIndex = 0 Then
            Search_Sales_Report_Data(searchReport2)

        ElseIf cmbType.SelectedIndex = 1 Or cmbType.SelectedIndex = 2 Then
            Search_Sales_Report_Data_Type(searchReport2, filterType2)
        End If
    End Sub
    Private Sub dtpTransMth_ValueChanged(sender As Object, e As EventArgs) Handles dtpTransMth.ValueChanged
        Transaction_Month()
    End Sub

    Private Sub dtpAmountMth_ValueChanged(sender As Object, e As EventArgs) Handles dtpAmountMth.ValueChanged
        Amount_Month()
    End Sub

    Private Sub dtpSalesMth_ValueChanged(sender As Object, e As EventArgs) Handles dtpSalesMth.ValueChanged
        Sales_Month()
    End Sub

    Private Sub btnManageUser_Click(sender As Object, e As EventArgs) Handles btnManageUser.Click
        Me.Hide()
        Form_Manage_User.Show()
    End Sub

    Private Sub btnMngHstrySls_Click(sender As Object, e As EventArgs) Handles btnMngHstrySls.Click
        Form_Sales_History.Show()
        Me.Hide()
    End Sub

    Private Sub btnEmpty_Click(sender As Object, e As EventArgs) Handles btnEmpty.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to remove all this data?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Empty_Sales_Data()
            Load_Sales_Data()
        End If
    End Sub

    Private Sub cmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged
        txtSearchReport.Hide()
        txtSearchType.Show()
        txtSearchReport.Clear()
        filterType2 = cmbType.Text

        If cmbType.SelectedIndex = 1 OrElse cmbType.SelectedIndex = 2 Then

            Transactions_Range_Type(filterType2)
            Sales_Range_Type(filterType2)
            Number_Sales_Range_Type(filterType2)
            Search_Sales_Report_Data_Type(searchReport2, filterType2)
            Load_Sales_Report_Data_Type(filterType2)
        Else
            Search_Sales_Report_Data(searchReport2)
            Load_Sales_Report_Data()
            Transactions_Range_Form()
            Sales_Range_Form()
            Number_Sales_Range_Form()

        End If
    End Sub

End Class