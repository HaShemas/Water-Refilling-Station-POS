Imports System.Drawing.Text

Public Class Form_Login

    Dim username, password As String
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        username = txtUsername.Text
        password = txtPassword.Text
        If ValidateLogin(username, password) Then
            If LoggedInuserstatus = 1 Then
                If LoggedInusertypeId = 1 Then
                    If IsAdminUser(username) Then
                        Form_Main.lblUsertype.Text = LoggedInusertype
                        MessageBox.Show("Logged In Successfully!", "SUCCESS!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                ElseIf LoggedInusertypeId = 2 Then
                    Form_Main.btnManageUser.Hide()
                    Form_Main.btnMngHstrySls.Hide()
                    MessageBox.Show("Welcome, User!")
                    Form_Main.lblUsertype.Text = LoggedInusertype
                    MessageBox.Show("Logged In Successfully!", "SUCCESS!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                Me.Hide()
                Form_Main.Show()
            End If

        Else
                MessageBox.Show("Invalid username or password. Please try again.", "INVALID!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Text = ""
            txtPassword.Text = ""
        End If
    End Sub

    Private Sub Form_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub chkPass_CheckedChanged(sender As Object, e As EventArgs) Handles chkPass.CheckedChanged
        If chkPass.Checked Then

            txtPassword.UseSystemPasswordChar = False
        Else

            txtPassword.UseSystemPasswordChar = True
        End If

    End Sub
End Class
