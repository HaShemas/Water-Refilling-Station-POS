Imports System.Data.SQLite
Module Mod_Dashboard
    Public Sub Overall_Sales_Total()
        Try
            SQLite_Open_Connection()
            Dim query As String = "SELECT SUM(amount) FROM product_tbl WHERE visibility <> 0;"

            Using cmd As New SQLiteCommand(query, sqliteConnection)
                Dim overallSalesTotal As Object = cmd.ExecuteScalar()

                If overallSalesTotal IsNot DBNull.Value Then
                    Form_Main.lblTotSales.Text = Convert.ToDouble(overallSalesTotal).ToString()
                Else
                    Form_Main.lblTotSales.Text = "0"
                End If
            End Using
        Catch ex As SQLiteException
            MessageBox.Show("SQLite Error: " & ex.Message)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            SQLite_Close_Connection()
        End Try
    End Sub

    Public Sub Overall_Sales_Amount()
        Try
            SQLite_Open_Connection()

            Dim query As String = "SELECT SUM(quantity) FROM product_tbl WHERE visibility <> 0;"

            Using cmd As New SQLiteCommand(query, sqliteConnection)
                Dim overallSalesAmount As Object = cmd.ExecuteScalar()

                If overallSalesAmount IsNot DBNull.Value Then
                    Form_Main.lblTAS.Text = Convert.ToInt32(overallSalesAmount).ToString()
                Else
                    Form_Main.lblTAS.Text = "0"
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            SQLite_Close_Connection()
        End Try
    End Sub

    Public Sub Overall_Sales_WalKIn()

        Try
            SQLite_Open_Connection()
            Dim query As String = "SELECT COUNT(product_tbl.product_id)
                                    FROM product_tbl
                                    INNER JOIN productType_tbl ON product_tbl.productType_id = productType_tbl.productType_id
                                    WHERE product_tbl.visibility <>0 AND productType_tbl.type = 'WalkIn';"



            Using cmd As New SQLiteCommand(query, sqliteConnection)
                Dim overallSalesWalkIn As Double = Convert.ToDouble(cmd.ExecuteScalar())


                If overallSalesWalkIn > 0 Then
                    Form_Main.lblWalk.Text = overallSalesWalkIn.ToString()
                Else


                    Form_Main.lblWalk.Text = "0"
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            SQLite_Close_Connection()
        End Try

    End Sub
    Public Sub Overall_Sales_Delivery()

        Try
            SQLite_Open_Connection()
            Dim query As String = "SELECT COUNT(product_tbl.product_id)
                                    FROM product_tbl
                                    INNER JOIN productType_tbl ON product_tbl.productType_id = productType_tbl.productType_id
                                    WHERE product_tbl.visibility <>0 AND productType_tbl.type = 'Delivery';
                                    "


            Using cmd As New SQLiteCommand(query, sqliteConnection)
                Dim overallSalesDelivery As Double = Convert.ToDouble(cmd.ExecuteScalar())

                If overallSalesDelivery > 0 Then
                    Form_Main.lblDel.Text = overallSalesDelivery.ToString()
                Else


                    Form_Main.lblDel.Text = "0"
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            SQLite_Close_Connection()
        End Try

    End Sub

End Module
