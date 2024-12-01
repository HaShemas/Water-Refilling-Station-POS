Imports System.Data.SQLite

Module Mod_Login
    Public LoggedInUserId, LoggedInusertypeId, LoggedInuserstatus As Integer
    Public LoggedInusertype As String
    Public Function ValidateLogin(username As String, password As String) As Boolean
        Try
            SQLite_Open_Connection()
            Dim query As String = "SELECT user_tbl.user_id, user_tbl.firstname, user_tbl.lastname, user_tbl.status,user_tbl.usertype_id,usertype_tbl.usertype FROM user_tbl 
                    INNER JOIN usertype_tbl ON user_tbl.usertype_id = usertype_tbl.usertype_id WHERE user_tbl.username = @username AND user_tbl.password = @password AND user_tbl.status != 0;"
            Using cmd As New SQLiteCommand(query, sqliteConnection)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@password", password)

                Dim reader As SQLiteDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    If Not reader.IsDBNull(reader.GetOrdinal("user_id")) Then
                        LoggedInUserId = Convert.ToInt32(reader("user_id"))
                    End If
                    If Not reader.IsDBNull(reader.GetOrdinal("usertype_id")) Then
                        LoggedInusertypeId = Convert.ToInt32(reader("usertype_id"))
                    End If
                    If Not reader.IsDBNull(reader.GetOrdinal("usertype")) Then
                        LoggedInusertype = Convert.ToString(reader("usertype"))
                    End If
                    If Not reader.IsDBNull(reader.GetOrdinal("status")) Then
                        LoggedInuserstatus = Convert.ToInt32(reader("status"))
                    End If
                    If Not reader.IsDBNull(reader.GetOrdinal("firstname")) Then
                        Dim firstName As String = reader("firstname").ToString().ToUpper()
                        Form_Main.lblUser.Text = firstName
                    End If
                    reader.Close()
                    Return True
                End If


            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.ToString())
        Finally
            SQLite_Close_Connection()
        End Try


        Return False
    End Function




    Public Function IsAdminUser(username As String) As Boolean
        Try
            sqliteConnection.Open()

            Dim query As String = "SELECT usertype_tbl.usertype_id, usertype_tbl.usertype FROM usertype_tbl INNER JOIN user_tbl ON usertype_tbl.usertype_id = user_tbl.usertype_id WHERE user_tbl.username = @username;"
            Using cmd As New SQLiteCommand(query, sqliteConnection)
                cmd.Parameters.AddWithValue("@username", username)

                Dim result As Object = cmd.ExecuteScalar()

                Return If(result IsNot Nothing AndAlso result IsNot DBNull.Value, Convert.ToBoolean(result), False)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            Return False
        Finally
            SQLite_Close_Connection()
        End Try
    End Function
End Module
