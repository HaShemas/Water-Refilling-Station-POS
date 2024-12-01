Imports System.Data.SQLite

Module Mod_DBConnection
    Public sqliteConnection As New SQLiteConnection("Data Source = " & Application.StartupPath & "\waterpos.db")

    Public Sub SQLite_Open_Connection()
        Try
            If sqliteConnection.State = ConnectionState.Closed Then
                sqliteConnection.Open()

            End If
        Catch ex As SQLiteException
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Public Sub SQLite_Close_Connection()
        Try
            If sqliteConnection.State = ConnectionState.Open Then
                sqliteConnection.Close()

            End If
        Catch ex As SQLiteException
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
End Module
