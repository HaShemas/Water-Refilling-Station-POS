Imports System.Data.Entity.ModelConfiguration.Configuration

Public Class Form_CRUD
    Public tabpages, nname, deliveryaddress, walkInRefillvalue, productType, walkIns, dlvrs As String
    Dim selectedTab As TabPage
    Public selectedTabIndex, quantity, visibility, price, amount As Integer
    Public Walk_In, Deliveries, lastClickedPictureBox As PictureBox
    Public tagValue, dated As String
    Dim customerID, productStatus As Integer
    Dim contactnum As Long
    Private Sub Delivery_Click(sender As Object, e As EventArgs) Handles Delivery.Click, Del_Refill.Click, Del_Bundle.Click
        If TypeOf sender Is PictureBox Then
            Deliveries = DirectCast(sender, PictureBox)
            Delivery.BorderStyle = BorderStyle.None
            Del_Refill.BorderStyle = BorderStyle.None
            Del_Bundle.BorderStyle = BorderStyle.None
            Deliveries.BorderStyle = BorderStyle.FixedSingle
            If Deliveries Is Del_Refill Then
                Deliveries.Image = My.Resources.pic_refill
                Deliveries.Tag = "Refill"
                price = 25
            ElseIf Deliveries Is Del_Bundle Then
                Deliveries.Image = My.Resources.pic_bundle
                Deliveries.Tag = "Bundle"
                price = 150

            End If
            lastClickedPictureBox = Deliveries
        Else
            MessageBox.Show("Please select a product.")
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Overall_Sales_Total()
        Overall_Sales_Amount()
        Overall_Sales_WalKIn()
        Overall_Sales_Delivery()
        Load_Sales_Data()
        Load_Sales_Report_Data()
        Transactions_Range_Form()
        Sales_Range_Form()
        Number_Sales_Range_Form()

        Transaction_Month()
        Amount_Month()
        Sales_Month()
        Me.Close()
    End Sub

    Private Sub WalkIn_Click(sender As Object, e As EventArgs) Handles WalkIn.DoubleClick, WalkIn_Refill.Click, WalkIn_Bundle.Click, Cap.Click
        If TypeOf sender Is PictureBox Then
            Walk_In = DirectCast(sender, PictureBox)
            WalkIn.BorderStyle = BorderStyle.None
            WalkIn_Refill.BorderStyle = BorderStyle.None
            WalkIn_Bundle.BorderStyle = BorderStyle.None
            Cap.BorderStyle = BorderStyle.None
            Walk_In.BorderStyle = BorderStyle.FixedSingle
            If Walk_In Is WalkIn_Refill Then
                Walk_In.Image = My.Resources.pic_walkinrefill
                Walk_In.Tag = "Refill"
                price = 15
            ElseIf Walk_In Is WalkIn_Bundle Then
                Walk_In.Image = My.Resources.pic_bundle
                Walk_In.Tag = "Bundle"
                price = 150
            ElseIf Walk_In Is Cap Then
                Walk_In.Image = My.Resources.pic_cap
                Walk_In.Tag = "Cap"
                price = 10
            End If
            lastClickedPictureBox = Walk_In
        Else
            MessageBox.Show("Please select a product.")
        End If
    End Sub

    Private Sub Adding_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub
    Public Sub New(ByVal utype As String)
        InitializeComponent()
        If utype = "WalkIn" Then
            Adding_Product.SelectedIndex = 0
        ElseIf utype = "Delivery" Then
            Adding_Product.SelectedIndex = 1
        End If
    End Sub

    Public Sub New()
        InitializeComponent()



        selectedTab = Adding_Product.SelectedTab
        selectedTabIndex = Adding_Product.SelectedIndex
        tabpages = selectedTab.Name
    End Sub

    Private Sub Adding_Product_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Adding_Product.SelectedIndexChanged
        selectedTab = Adding_Product.SelectedTab
        selectedTabIndex = Adding_Product.SelectedIndex
        tabpages = selectedTab.Name
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If String.IsNullOrWhiteSpace(txtName.Text) Then
            MessageBox.Show("Please enter a name.")
        ElseIf Not Long.TryParse(txtContactnumber.Text, Nothing) Then
            MessageBox.Show("Please enter a valid number for the contact number.")
        ElseIf String.IsNullOrWhiteSpace(txtContactnumber.Text) Then
            MessageBox.Show("Contact number cannot be empty.")
        ElseIf String.IsNullOrWhiteSpace(txtAddress.Text) Then
            MessageBox.Show("Please enter an address.")
        ElseIf String.IsNullOrWhiteSpace(cmbPayment.Text) Then
            MessageBox.Show("Please select a payment method.")
        ElseIf Not Long.TryParse(txtQty.Text, Nothing) Then
            MessageBox.Show("Please enter a valid number for the quantity.")
        ElseIf String.IsNullOrWhiteSpace(txtQty.Text) Then
            MessageBox.Show("Quantity cannot be empty.")
        ElseIf lastClickedPictureBox Is Nothing Then
            MessageBox.Show("Please select a product.")
        Else
            nname = txtName.Text
            contactnum = txtContactnumber.Text
            deliveryaddress = txtAddress.Text
            quantity = txtQty.Text
            amount = price * quantity
            visibility = 1

            If cmbPayment.SelectedIndex = 0 Then
                productStatus = 1
                If selectedTab Is WalkIn Then
                    If lastClickedPictureBox Is Walk_In Then
                        productType = 1
                        walkIns = Walk_In.Tag
                        Insert_Data(nname, contactnum, deliveryaddress, walkIns, price, quantity, amount, visibility, productType, productStatus)
                    Else
                        MessageBox.Show("Invalid combination of Tab and PictureBox selection.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                ElseIf selectedTab Is Delivery Then
                    If lastClickedPictureBox Is Deliveries Then
                        productType = 2
                        dlvrs = Deliveries.Tag
                        Insert_Data(nname, contactnum, deliveryaddress, dlvrs, price, quantity, amount, visibility, productType, productStatus)
                    Else
                        MessageBox.Show("Invalid combination of Tab and PictureBox selection.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            ElseIf cmbPayment.SelectedIndex = 1 Then
                productStatus = 2
                If selectedTab Is WalkIn Then
                    If lastClickedPictureBox Is Walk_In Then
                        productType = 1
                        walkIns = Walk_In.Tag
                        Insert_Data(nname, contactnum, deliveryaddress, walkIns, price, quantity, amount, visibility, productType, productStatus)
                    Else
                        MessageBox.Show("Invalid combination of Tab and PictureBox selection.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                ElseIf selectedTab Is Delivery Then
                    If lastClickedPictureBox Is Deliveries Then
                        productType = 2
                        dlvrs = Deliveries.Tag
                        Insert_Data(nname, contactnum, deliveryaddress, dlvrs, price, quantity, amount, visibility, productType, productStatus)
                    Else
                        MessageBox.Show("Invalid combination of Tab and PictureBox selection.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        End If

        Overall_Sales_Total()
        Overall_Sales_Amount()
        Overall_Sales_WalKIn()
        Overall_Sales_Delivery()

        Load_Sales_Data()
        Load_Sales_Report_Data()
        Transactions_Range_Form()
        Sales_Range_Form()
        Number_Sales_Range_Form()

        Transaction_Month()
        Amount_Month()
        Sales_Month()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        If String.IsNullOrWhiteSpace(txtName.Text) Then
            MessageBox.Show("Please enter a name.")
        ElseIf Not Long.TryParse(txtContactnumber.Text, Nothing) Then
            MessageBox.Show("Please enter a valid number for the contact number.")
        ElseIf String.IsNullOrWhiteSpace(txtContactnumber.Text) Then
            MessageBox.Show("Contact number cannot be empty.")
        ElseIf String.IsNullOrWhiteSpace(txtAddress.Text) Then
            MessageBox.Show("Please enter an address.")
        ElseIf String.IsNullOrWhiteSpace(cmbPayment.Text) Then
            MessageBox.Show("Please select a payment method.")
        ElseIf Not Long.TryParse(txtQty.Text, Nothing) Then
            MessageBox.Show("Please enter a valid number for the quantity.")
        ElseIf String.IsNullOrWhiteSpace(txtQty.Text) Then
            MessageBox.Show("Quantity cannot be empty.")

        Else
            customerID = Form_Main.customerId
            nname = txtName.Text
            contactnum = txtContactnumber.Text
            deliveryaddress = txtAddress.Text
            quantity = txtQty.Text
            amount = price * quantity
            productType = tabpages
            visibility = 1
            Dim values = Form_Main.utype

            Dim selectedProdIndex As Integer = Adding_Product.SelectedIndex
            Dim uproduct = Form_Main.utagValue
            If selectedProdIndex = 0 And lastClickedPictureBox Is Nothing And values = "WalkIn" Then
                Dim typeId = 1
                Dim productStatusIndex As Integer = cmbPayment.SelectedIndex
                If productStatusIndex = 0 Then
                    Dim productStatusId As Integer = 1

                    Update_Data(customerID, nname, contactnum, deliveryaddress, uproduct, price, quantity, amount, visibility, typeId, productStatusId)
                    Me.Close()
                ElseIf productStatusIndex = 1 Then
                    Dim productStatusIdUn As Integer = 2
                    Update_Data(customerID, nname, contactnum, deliveryaddress, uproduct, price, quantity, amount, visibility, typeId, productStatusIdUn)
                    Me.Close()
                Else
                    MessageBox.Show("Invalid combination of Tab and PictureBox selection.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If


            ElseIf selectedProdIndex = 1 And lastClickedPictureBox Is Nothing And values = "Delivery" Then
                Dim typeId = 2
                Dim productStatusIndex As Integer = cmbPayment.SelectedIndex
                If productStatusIndex = 0 Then
                    Dim productStatusId As Integer = 1

                    Update_Data(customerID, nname, contactnum, deliveryaddress, uproduct, price, quantity, amount, visibility, typeId, productStatusId)
                    Me.Close()
                ElseIf productStatusIndex = 1 Then
                    Dim productStatusIdUn As Integer = 2
                    Update_Data(customerID, nname, contactnum, deliveryaddress, uproduct, price, quantity, amount, visibility, typeId, productStatusIdUn)
                    Me.Close()
                Else
                    MessageBox.Show("Invalid combination of Tab and PictureBox selection.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            ElseIf selectedProdIndex = 0 And lastClickedPictureBox Is Walk_In Then
                If lastClickedPictureBox IsNot Nothing Then
                    walkIns = Walk_In.Tag
                    Dim typeId = 1
                    Dim productStatusIndex As Integer = cmbPayment.SelectedIndex
                    If productStatusIndex = 0 Then
                        Dim productStatusId As Integer = 1

                        Update_Data(customerID, nname, contactnum, deliveryaddress, walkIns, price, quantity, amount, visibility, typeId, productStatusId)
                        Me.Close()
                    ElseIf productStatusIndex = 1 Then
                        Dim productStatusIdUn As Integer = 2
                        Update_Data(customerID, nname, contactnum, deliveryaddress, walkIns, price, quantity, amount, visibility, typeId, productStatusIdUn)
                        Me.Close()
                    Else
                        MessageBox.Show("Invalid combination of Tab and PictureBox selection.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Invalid combination of Tab and PictureBox selection.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            ElseIf selectedProdIndex = 1 And lastClickedPictureBox Is Deliveries Then
                If lastClickedPictureBox IsNot Nothing Then
                    dlvrs = Deliveries.Tag
                    Dim typeId = 2
                    Dim productStatusIndex = cmbPayment.SelectedIndex
                    If productStatusIndex = 0 Then
                        Dim productStatusId As Integer = 1
                        Update_Data(customerID, nname, contactnum, deliveryaddress, dlvrs, price, quantity, amount, visibility, typeId, productStatusId)
                        Me.Close()
                    ElseIf productStatusIndex = 1 Then
                        Dim productStatusIdUn As Integer = 2
                        Update_Data(customerID, nname, contactnum, deliveryaddress, dlvrs, price, quantity, amount, visibility, typeId, productStatusIdUn)
                        Me.Close()
                    Else
                        MessageBox.Show("Invalid combination of Tab and PictureBox selection.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Invalid combination of Tab and PictureBox selection.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Else
                    MessageBox.Show("Invalid combination of Tab and PictureBox selection.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End If


        Overall_Sales_Total()
        Overall_Sales_Amount()
        Overall_Sales_WalKIn()
        Overall_Sales_Delivery()

        Load_Sales_Data()
        Load_Sales_Report_Data()
        Transactions_Range_Form()
        Sales_Range_Form()
        Number_Sales_Range_Form()

        Transaction_Month()
        Amount_Month()
        Sales_Month()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        lastClickedPictureBox = Nothing
        cmbPayment.SelectedIndex = -1
        txtName.Clear()
        txtContactnumber.Clear()
        txtAddress.Clear()
        txtQty.Clear()

    End Sub
End Class