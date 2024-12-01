Imports System.Data.SQLite
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Module Mod_User
    Public Sub Create_User(ByVal fname As String, ByVal lname As String, ByVal uname As String, ByVal pass As String, ByVal usertype_id As Integer, ByVal status As Integer)
        Try
            SQLite_Open_Connection()
            Using insertUserCmd As New SQLiteCommand("INSERT INTO user_tbl (firstname, lastname,username,password,usertype_id,status) VALUES (@fname,@lname,@uname,@pass,@usertype_id,@status);", sqliteConnection)
                insertUserCmd.Parameters.AddWithValue("@fname", fname)
                insertUserCmd.Parameters.AddWithValue("@lname", lname)
                insertUserCmd.Parameters.AddWithValue("@uname", uname)
                insertUserCmd.Parameters.AddWithValue("@pass", pass)
                insertUserCmd.Parameters.AddWithValue("@usertype_id", usertype_id)
                insertUserCmd.Parameters.AddWithValue("@status", status)
                insertUserCmd.ExecuteNonQuery()
            End Using
            MessageBox.Show("Created Successfully!")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLite_Close_Connection()
        End Try
    End Sub
    Public Sub Update_User(ByVal fname As String, ByVal lname As String, ByVal uname As String, ByVal pass As String, ByVal usertype_id As Integer, ByVal status As Integer, ByVal user_id As Integer)
        Try
            SQLite_Open_Connection()
            Using updateUserCmd As New SQLiteCommand("UPDATE user_tbl SET firstname=@fname, lastname=@lname, username=@uname, password=@pass, usertype_id=@usertype_id, status=@status WHERE user_id=@user_id", sqliteConnection)
                updateUserCmd.Parameters.AddWithValue("@fname", fname)
                updateUserCmd.Parameters.AddWithValue("@lname", lname)
                updateUserCmd.Parameters.AddWithValue("@uname", uname)
                updateUserCmd.Parameters.AddWithValue("@pass", pass)
                updateUserCmd.Parameters.AddWithValue("@usertype_id", usertype_id)
                updateUserCmd.Parameters.AddWithValue("@status", status)
                updateUserCmd.Parameters.AddWithValue("@user_id", user_id)

                updateUserCmd.ExecuteNonQuery()
            End Using
            MessageBox.Show("Updated Successfully!")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLite_Close_Connection()
        End Try
    End Sub

    Public Sub Toggle_User_Status(ByVal user_id As Integer)
        Try
            SQLite_Open_Connection()
            dataSet = New DataSet
            Dim currentUserstatus, newUserstatus As Integer

            Using cmd As New SQLiteCommand("SELECT status FROM user_tbl WHERE user_id = @user_id", sqliteConnection)
                cmd.Parameters.AddWithValue("@user_id", user_id)
                currentUserstatus = CInt(cmd.ExecuteScalar())
            End Using


            If currentUserstatus = 0 Then
                newUserstatus = 1
            Else
                newUserstatus = 0
            End If

            Using cmd As New SQLiteCommand("UPDATE user_tbl SET status = @newUserstatus WHERE user_id = @user_id", sqliteConnection)
                cmd.Parameters.AddWithValue("@newUserstatus", newUserstatus)
                cmd.Parameters.AddWithValue("@user_id", user_id)
                cmd.ExecuteNonQuery()
            End Using

            If newUserstatus = 0 Then
                MessageBox.Show("User Disabled.")
            Else
                MessageBox.Show("User Enabled.")
            End If

        Catch ex As SQLiteException
            MessageBox.Show("Error: " & ex.Message)
        Finally
            SQLite_Close_Connection()
        End Try
    End Sub

    Public Sub Load_Users_Data()

        Try

            SQLite_Open_Connection()

            dataSet = New DataSet

            sqliteDataAdapter = New SQLiteDataAdapter("SELECT user_id,firstname,lastname,username,password,status FROM user_tbl where usertype_id <> 1;", sqliteConnection)

            sqliteDataAdapter.Fill(dataSet, "user_tbl")

            Form_Manage_User.dgvUsers.DataSource = dataSet.Tables(0)

        Catch ex As SQLiteException

            MessageBox.Show("Error: " & ex.Message)

        Finally

            SQLite_Close_Connection()

        End Try

    End Sub
End Module
