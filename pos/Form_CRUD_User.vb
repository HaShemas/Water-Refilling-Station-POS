Imports System.Data.SQLite

Public Class Form_CRUD_User
    Dim usertype, userstatus As Integer
    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Dim fname, lname, uname, password As String
        fname = txtFname.Text
        lname = txtLname.Text
        uname = txtUname.Text
        password = txtPass.Text
        usertype = 2
        userstatus = 1
        If String.IsNullOrWhiteSpace(txtFname.Text) Then
            MessageBox.Show("Please enter firstname.")
        ElseIf String.IsNullOrWhiteSpace(txtLname.Text) Then
            MessageBox.Show("Please enter lastname.")
        ElseIf String.IsNullOrWhiteSpace(txtUname.Text) Then
            MessageBox.Show("Please enter username.")
        ElseIf String.IsNullOrWhiteSpace(txtPass.Text) Then
            MessageBox.Show("Please enter password.")
        Else
            Create_User(fname, lname, uname, password, usertype, userstatus)
            Load_Users_Data()
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
        Form_Manage_User.Show()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Dim user_id = Form_Manage_User.user_ids
        Dim fname As String = txtFname.Text
        Dim lname As String = txtLname.Text
        Dim uname As String = txtUname.Text
        Dim pass As String = txtPass.Text
        usertype = 2
        userstatus = 1
        If String.IsNullOrWhiteSpace(txtFname.Text) Then
            MessageBox.Show("Please enter firstname.")
        ElseIf String.IsNullOrWhiteSpace(txtLname.Text) Then
            MessageBox.Show("Please enter lastname.")
        ElseIf String.IsNullOrWhiteSpace(txtUname.Text) Then
            MessageBox.Show("Please enter username.")
        ElseIf String.IsNullOrWhiteSpace(txtPass.Text) Then
            MessageBox.Show("Please enter password.")
        Else
            Update_User(fname, lname, uname, pass, usertype, userstatus, user_id)
            Load_Users_Data()
            Me.Close()
        End If
    End Sub

    Private Sub Form_CRUD_User_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form_CRUD_User_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class