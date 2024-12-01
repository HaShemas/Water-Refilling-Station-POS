<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Sales_History
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
        Me.dgvHistory = New System.Windows.Forms.DataGridView()
        Me.btnUndo = New System.Windows.Forms.Button()
        Me.cmbHistoryType = New System.Windows.Forms.ComboBox()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.txtSearchHistory = New System.Windows.Forms.TextBox()
        CType(Me.dgvHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvHistory
        '
        Me.dgvHistory.AllowUserToAddRows = False
        Me.dgvHistory.AllowUserToDeleteRows = False
        Me.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHistory.Location = New System.Drawing.Point(27, 152)
        Me.dgvHistory.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvHistory.Name = "dgvHistory"
        Me.dgvHistory.ReadOnly = True
        Me.dgvHistory.RowHeadersWidth = 51
        Me.dgvHistory.RowTemplate.Height = 29
        Me.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvHistory.Size = New System.Drawing.Size(913, 287)
        Me.dgvHistory.TabIndex = 2
        '
        'btnUndo
        '
        Me.btnUndo.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnUndo.Location = New System.Drawing.Point(257, 465)
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.Size = New System.Drawing.Size(119, 36)
        Me.btnUndo.TabIndex = 3
        Me.btnUndo.Text = "UNDO"
        Me.btnUndo.UseVisualStyleBackColor = True
        '
        'cmbHistoryType
        '
        Me.cmbHistoryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHistoryType.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.cmbHistoryType.FormattingEnabled = True
        Me.cmbHistoryType.Items.AddRange(New Object() {"All", "WalkIn", "Delivery"})
        Me.cmbHistoryType.Location = New System.Drawing.Point(27, 84)
        Me.cmbHistoryType.Name = "cmbHistoryType"
        Me.cmbHistoryType.Size = New System.Drawing.Size(166, 26)
        Me.cmbHistoryType.TabIndex = 4
        '
        'btnBack
        '
        Me.btnBack.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnBack.Location = New System.Drawing.Point(630, 465)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(119, 36)
        Me.btnBack.TabIndex = 5
        Me.btnBack.Text = "BACK"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'txtSearchHistory
        '
        Me.txtSearchHistory.Font = New System.Drawing.Font("Georgia", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtSearchHistory.Location = New System.Drawing.Point(369, 84)
        Me.txtSearchHistory.Name = "txtSearchHistory"
        Me.txtSearchHistory.PlaceholderText = "SEARCH"
        Me.txtSearchHistory.Size = New System.Drawing.Size(238, 29)
        Me.txtSearchHistory.TabIndex = 6
        '
        'Form_Sales_History
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.pos.My.Resources.Resources.pic_mainbg
        Me.ClientSize = New System.Drawing.Size(983, 530)
        Me.Controls.Add(Me.txtSearchHistory)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.cmbHistoryType)
        Me.Controls.Add(Me.btnUndo)
        Me.Controls.Add(Me.dgvHistory)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Name = "Form_Sales_History"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SALES HISTORY"
        CType(Me.dgvHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvHistory As DataGridView
    Friend WithEvents btnUndo As Button
    Friend WithEvents cmbHistoryType As ComboBox
    Friend WithEvents btnBack As Button
    Friend WithEvents txtSearchHistory As TextBox
End Class
