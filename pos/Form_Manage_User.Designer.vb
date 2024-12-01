<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Manage_User
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
        Me.btnCreateUser = New System.Windows.Forms.Button()
        Me.btnUpdateUsers = New System.Windows.Forms.Button()
        Me.dgvUsers = New System.Windows.Forms.DataGridView()
        Me.btnToggle = New System.Windows.Forms.Button()
        Me.btnMain = New System.Windows.Forms.Button()
        CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCreateUser
        '
        Me.btnCreateUser.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnCreateUser.Location = New System.Drawing.Point(41, 330)
        Me.btnCreateUser.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCreateUser.Name = "btnCreateUser"
        Me.btnCreateUser.Size = New System.Drawing.Size(95, 39)
        Me.btnCreateUser.TabIndex = 41
        Me.btnCreateUser.Text = "CREATE"
        Me.btnCreateUser.UseVisualStyleBackColor = True
        '
        'btnUpdateUsers
        '
        Me.btnUpdateUsers.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnUpdateUsers.Location = New System.Drawing.Point(233, 330)
        Me.btnUpdateUsers.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnUpdateUsers.Name = "btnUpdateUsers"
        Me.btnUpdateUsers.Size = New System.Drawing.Size(95, 39)
        Me.btnUpdateUsers.TabIndex = 40
        Me.btnUpdateUsers.Text = "UPDATE"
        Me.btnUpdateUsers.UseVisualStyleBackColor = True
        '
        'dgvUsers
        '
        Me.dgvUsers.AllowUserToAddRows = False
        Me.dgvUsers.AllowUserToDeleteRows = False
        Me.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsers.Location = New System.Drawing.Point(12, 72)
        Me.dgvUsers.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvUsers.Name = "dgvUsers"
        Me.dgvUsers.ReadOnly = True
        Me.dgvUsers.RowHeadersWidth = 51
        Me.dgvUsers.RowTemplate.Height = 29
        Me.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUsers.Size = New System.Drawing.Size(527, 212)
        Me.dgvUsers.TabIndex = 39
        '
        'btnToggle
        '
        Me.btnToggle.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnToggle.Location = New System.Drawing.Point(418, 330)
        Me.btnToggle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnToggle.Name = "btnToggle"
        Me.btnToggle.Size = New System.Drawing.Size(95, 39)
        Me.btnToggle.TabIndex = 38
        Me.btnToggle.Text = "TOGGLE"
        Me.btnToggle.UseVisualStyleBackColor = True
        '
        'btnMain
        '
        Me.btnMain.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnMain.Location = New System.Drawing.Point(218, 15)
        Me.btnMain.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMain.Name = "btnMain"
        Me.btnMain.Size = New System.Drawing.Size(140, 40)
        Me.btnMain.TabIndex = 37
        Me.btnMain.Text = "Main"
        Me.btnMain.UseVisualStyleBackColor = True
        '
        'Form_Manage_User
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.pos.My.Resources.Resources.pic_mainbg
        Me.ClientSize = New System.Drawing.Size(553, 383)
        Me.Controls.Add(Me.btnCreateUser)
        Me.Controls.Add(Me.btnUpdateUsers)
        Me.Controls.Add(Me.dgvUsers)
        Me.Controls.Add(Me.btnToggle)
        Me.Controls.Add(Me.btnMain)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Name = "Form_Manage_User"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "USER MANAGER"
        CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCreateUser As Button
    Friend WithEvents btnUpdateUsers As Button
    Friend WithEvents dgvUsers As DataGridView
    Friend WithEvents btnToggle As Button
    Friend WithEvents btnMain As Button
End Class
