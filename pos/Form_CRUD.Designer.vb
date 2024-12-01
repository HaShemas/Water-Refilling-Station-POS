<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_CRUD
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
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Adding_Product = New System.Windows.Forms.TabControl()
        Me.WalkIn = New System.Windows.Forms.TabPage()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.WalkIn_Refill = New System.Windows.Forms.PictureBox()
        Me.Cap = New System.Windows.Forms.PictureBox()
        Me.WalkIn_Bundle = New System.Windows.Forms.PictureBox()
        Me.Delivery = New System.Windows.Forms.TabPage()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Del_Bundle = New System.Windows.Forms.PictureBox()
        Me.Del_Refill = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.cmbPayment = New System.Windows.Forms.ComboBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtContactnumber = New System.Windows.Forms.TextBox()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Adding_Product.SuspendLayout()
        Me.WalkIn.SuspendLayout()
        CType(Me.WalkIn_Refill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WalkIn_Bundle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Delivery.SuspendLayout()
        CType(Me.Del_Bundle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Del_Refill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtAddress
        '
        Me.txtAddress.Font = New System.Drawing.Font("Georgia", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtAddress.Location = New System.Drawing.Point(21, 94)
        Me.txtAddress.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(196, 34)
        Me.txtAddress.TabIndex = 2
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Georgia", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtName.Location = New System.Drawing.Point(21, 37)
        Me.txtName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(196, 29)
        Me.txtName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(21, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 18)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(21, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 18)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Address:"
        '
        'Adding_Product
        '
        Me.Adding_Product.Controls.Add(Me.WalkIn)
        Me.Adding_Product.Controls.Add(Me.Delivery)
        Me.Adding_Product.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Adding_Product.Location = New System.Drawing.Point(14, 136)
        Me.Adding_Product.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Adding_Product.Name = "Adding_Product"
        Me.Adding_Product.SelectedIndex = 0
        Me.Adding_Product.Size = New System.Drawing.Size(705, 287)
        Me.Adding_Product.TabIndex = 33
        '
        'WalkIn
        '
        Me.WalkIn.BackColor = System.Drawing.Color.White
        Me.WalkIn.Controls.Add(Me.Label8)
        Me.WalkIn.Controls.Add(Me.Label7)
        Me.WalkIn.Controls.Add(Me.Label6)
        Me.WalkIn.Controls.Add(Me.WalkIn_Refill)
        Me.WalkIn.Controls.Add(Me.Cap)
        Me.WalkIn.Controls.Add(Me.WalkIn_Bundle)
        Me.WalkIn.Location = New System.Drawing.Point(4, 27)
        Me.WalkIn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.WalkIn.Name = "WalkIn"
        Me.WalkIn.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.WalkIn.Size = New System.Drawing.Size(697, 256)
        Me.WalkIn.TabIndex = 0
        Me.WalkIn.Text = "WALK-IN"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label8.Location = New System.Drawing.Point(490, 195)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 18)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "Cap"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label7.Location = New System.Drawing.Point(278, 195)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 18)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "Bundle"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label6.Location = New System.Drawing.Point(72, 195)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 18)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "Refill"
        '
        'WalkIn_Refill
        '
        Me.WalkIn_Refill.BackColor = System.Drawing.Color.GreenYellow
        Me.WalkIn_Refill.Image = Global.pos.My.Resources.Resources.pic_walkinrefill
        Me.WalkIn_Refill.Location = New System.Drawing.Point(15, 20)
        Me.WalkIn_Refill.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.WalkIn_Refill.Name = "WalkIn_Refill"
        Me.WalkIn_Refill.Size = New System.Drawing.Size(184, 159)
        Me.WalkIn_Refill.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.WalkIn_Refill.TabIndex = 42
        Me.WalkIn_Refill.TabStop = False
        '
        'Cap
        '
        Me.Cap.BackColor = System.Drawing.Color.GreenYellow
        Me.Cap.Image = Global.pos.My.Resources.Resources.pic_cap
        Me.Cap.Location = New System.Drawing.Point(421, 20)
        Me.Cap.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Cap.Name = "Cap"
        Me.Cap.Size = New System.Drawing.Size(184, 159)
        Me.Cap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cap.TabIndex = 41
        Me.Cap.TabStop = False
        '
        'WalkIn_Bundle
        '
        Me.WalkIn_Bundle.BackColor = System.Drawing.Color.GreenYellow
        Me.WalkIn_Bundle.Image = Global.pos.My.Resources.Resources.pic_bundle
        Me.WalkIn_Bundle.Location = New System.Drawing.Point(217, 20)
        Me.WalkIn_Bundle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.WalkIn_Bundle.Name = "WalkIn_Bundle"
        Me.WalkIn_Bundle.Size = New System.Drawing.Size(184, 159)
        Me.WalkIn_Bundle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.WalkIn_Bundle.TabIndex = 39
        Me.WalkIn_Bundle.TabStop = False
        '
        'Delivery
        '
        Me.Delivery.BackColor = System.Drawing.Color.White
        Me.Delivery.Controls.Add(Me.Label10)
        Me.Delivery.Controls.Add(Me.Label9)
        Me.Delivery.Controls.Add(Me.Del_Bundle)
        Me.Delivery.Controls.Add(Me.Del_Refill)
        Me.Delivery.Location = New System.Drawing.Point(4, 27)
        Me.Delivery.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Delivery.Name = "Delivery"
        Me.Delivery.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Delivery.Size = New System.Drawing.Size(697, 256)
        Me.Delivery.TabIndex = 1
        Me.Delivery.Text = "DELIVERY"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label10.Location = New System.Drawing.Point(277, 193)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 18)
        Me.Label10.TabIndex = 51
        Me.Label10.Text = "Bundle"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label9.Location = New System.Drawing.Point(72, 193)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 18)
        Me.Label9.TabIndex = 50
        Me.Label9.Text = "Refill"
        '
        'Del_Bundle
        '
        Me.Del_Bundle.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Del_Bundle.Image = Global.pos.My.Resources.Resources.pic_bundle
        Me.Del_Bundle.Location = New System.Drawing.Point(218, 20)
        Me.Del_Bundle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Del_Bundle.Name = "Del_Bundle"
        Me.Del_Bundle.Size = New System.Drawing.Size(184, 159)
        Me.Del_Bundle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Del_Bundle.TabIndex = 49
        Me.Del_Bundle.TabStop = False
        '
        'Del_Refill
        '
        Me.Del_Refill.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Del_Refill.Image = Global.pos.My.Resources.Resources.pic_refill
        Me.Del_Refill.Location = New System.Drawing.Point(15, 20)
        Me.Del_Refill.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Del_Refill.Name = "Del_Refill"
        Me.Del_Refill.Size = New System.Drawing.Size(184, 159)
        Me.Del_Refill.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Del_Refill.TabIndex = 48
        Me.Del_Refill.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label3.Location = New System.Drawing.Point(33, 437)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 18)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Payment Status:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label4.Location = New System.Drawing.Point(462, 437)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 18)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Quantity:"
        '
        'txtQty
        '
        Me.txtQty.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtQty.Location = New System.Drawing.Point(462, 454)
        Me.txtQty.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(181, 33)
        Me.txtQty.TabIndex = 4
        '
        'cmbPayment
        '
        Me.cmbPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPayment.Font = New System.Drawing.Font("Georgia", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.cmbPayment.FormattingEnabled = True
        Me.cmbPayment.Items.AddRange(New Object() {"Paid", "Unpaid"})
        Me.cmbPayment.Location = New System.Drawing.Point(33, 454)
        Me.cmbPayment.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbPayment.Name = "cmbPayment"
        Me.cmbPayment.Size = New System.Drawing.Size(151, 31)
        Me.cmbPayment.TabIndex = 3
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnAdd.Location = New System.Drawing.Point(200, 512)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(105, 31)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnCancel.Location = New System.Drawing.Point(377, 512)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(105, 31)
        Me.btnCancel.TabIndex = 39
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label5.Location = New System.Drawing.Point(251, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 18)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Contact #:"
        '
        'txtContactnumber
        '
        Me.txtContactnumber.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtContactnumber.Location = New System.Drawing.Point(251, 37)
        Me.txtContactnumber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtContactnumber.Name = "txtContactnumber"
        Me.txtContactnumber.Size = New System.Drawing.Size(187, 33)
        Me.txtContactnumber.TabIndex = 1
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnUpdate.Location = New System.Drawing.Point(200, 512)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(105, 31)
        Me.btnUpdate.TabIndex = 42
        Me.btnUpdate.Text = "UPDATE"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnClear.Location = New System.Drawing.Point(609, 15)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(105, 48)
        Me.btnClear.TabIndex = 43
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Form_CRUD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSkyBlue
        Me.BackgroundImage = Global.pos.My.Resources.Resources.pic_mainbg
        Me.ClientSize = New System.Drawing.Size(731, 559)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtContactnumber)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.cmbPayment)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Adding_Product)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtAddress)
        Me.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Form_CRUD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TRANSACTION"
        Me.Adding_Product.ResumeLayout(False)
        Me.WalkIn.ResumeLayout(False)
        Me.WalkIn.PerformLayout()
        CType(Me.WalkIn_Refill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WalkIn_Bundle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Delivery.ResumeLayout(False)
        Me.Delivery.PerformLayout()
        CType(Me.Del_Bundle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Del_Refill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtAddress As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Adding_Product As TabControl
    Friend WithEvents WalkIn As TabPage
    Friend WithEvents Delivery As TabPage
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtQty As TextBox
    Friend WithEvents cmbPayment As ComboBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents Cap As PictureBox
    Friend WithEvents WalkIn_Bundle As PictureBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtContactnumber As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents WalkIn_Refill As PictureBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Del_Bundle As PictureBox
    Friend WithEvents Del_Refill As PictureBox
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnClear As Button
End Class
