Public Class Form_Manage_User
    Public user_ids
    Private Sub Form_Manage_User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Users_Data()
    End Sub



    Private Sub btnMain_Click(sender As Object, e As EventArgs) Handles btnMain.Click
        Form_Main.Show()
        Me.Close()
    End Sub



    Private Sub btnToggle_Click(sender As Object, e As EventArgs) Handles btnToggle.Click
        If dgvUsers.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgvUsers.SelectedRows(0)
            user_ids = CInt(selectedRow.Cells(0).Value)
            If user_ids > 0 Then
                Toggle_User_Status(user_ids)
                Load_Users_Data()
            Else
                MessageBox.Show("Please select a user to toggle.")
            End If
        End If
    End Sub



    Private Sub btnCreateUser_Click(sender As Object, e As EventArgs) Handles btnCreateUser.Click
        Form_CRUD_User.Show()
        Form_CRUD_User.btnUpdate.Hide()
    End Sub

    Private Sub btnUpdateUsers_Click(sender As Object, e As EventArgs) Handles btnUpdateUsers.Click
        If dgvUsers.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgvUsers.SelectedRows(0)
            user_ids = CInt(selectedRow.Cells(0).Value)
            Dim fname As String = selectedRow.Cells("firstname").Value.ToString()
            Dim lname As String = selectedRow.Cells("lastname").Value.ToString()
            Dim uname As String = selectedRow.Cells("username").Value.ToString()
            Dim pass As String = selectedRow.Cells("password").Value.ToString()
            Form_CRUD_User.txtFname.Text = fname
            Form_CRUD_User.txtLname.Text = lname
            Form_CRUD_User.txtUname.Text = uname
            Form_CRUD_User.txtPass.Text = pass
            Form_CRUD_User.txtUname.Enabled = False
            Form_CRUD_User.Show()
            Form_CRUD_User.btnCreate.Hide()
        End If
    End Sub
End Class