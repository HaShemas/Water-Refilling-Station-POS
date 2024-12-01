Imports System.Collections.ObjectModel
Imports System.Data.Entity.Core
Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.Text
Imports System.Windows


Module Mod_Sales
    Public sqliteDataAdapter As SQLiteDataAdapter
    Public dataSet As DataSet
    Dim user_id As Integer
    Public insertedCustomerId As Integer



    Public Sub Insert_Data(ByVal name As String, ByVal contact_number As Long, ByVal customer_address As String,
                           ByVal product_name As String, ByVal price As Double, ByVal quantity As Long,
                           ByVal amount As Double, ByVal visibility As String, ByVal prod_typeId As Integer, ByVal prod_statusId As Integer)
        user_id = Mod_Login.LoggedInUserId
        Try
            SQLite_Open_Connection()

            Using insertCustomerCmd As New SQLiteCommand("INSERT INTO customer_tbl (name, contact_number,customer_address,user_id) VALUES (@name,@contact_number,@customer_address,@user_id); SELECT last_insert_rowid();", sqliteConnection)
                insertCustomerCmd.Parameters.AddWithValue("@name", name)
                insertCustomerCmd.Parameters.AddWithValue("@contact_number", contact_number)
                insertCustomerCmd.Parameters.AddWithValue("@customer_address", customer_address)
                insertCustomerCmd.Parameters.AddWithValue("@user_id", user_id)

                insertedCustomerId = Convert.ToInt32(insertCustomerCmd.ExecuteScalar())

                Using insertProductCmd As New SQLiteCommand("INSERT INTO product_tbl (product_name, price, quantity, amount, date, visibility, customer_id, productType_id, productStatus_id)
                                                                VALUES (@product_name, @price, @quantity, @amount, date(), @visibility, @customer_id, @productType_id, @productStatus_id);
                                                                ", sqliteConnection)
                    insertProductCmd.Parameters.AddWithValue("@product_name", product_name)
                    insertProductCmd.Parameters.AddWithValue("@price", price)
                    insertProductCmd.Parameters.AddWithValue("@quantity", quantity)
                    insertProductCmd.Parameters.AddWithValue("@amount", amount)
                    insertProductCmd.Parameters.AddWithValue("@visibility", visibility)
                    insertProductCmd.Parameters.AddWithValue("@customer_id", insertedCustomerId)
                    insertProductCmd.Parameters.AddWithValue("@productType_id", prod_typeId)
                    insertProductCmd.Parameters.AddWithValue("@productStatus_id", prod_statusId)
                    insertProductCmd.ExecuteNonQuery()
                End Using

            End Using
            MessageBox.Show("Created Successfully!")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLite_Close_Connection()
        End Try

    End Sub
    Public Sub Update_Data(ByVal customer_id As Integer, ByVal name As String, ByVal contact_number As Long, ByVal customer_address As String,
                       ByVal product_name As String, ByVal price As Double, ByVal quantity As Long,
                       ByVal amount As Double, ByVal visibility As String, ByVal prod_typeId As Integer, ByVal prod_statusId As Integer)
        user_id = Mod_Login.LoggedInUserId
        Try
            SQLite_Open_Connection()

            Using updateCustomerCmd As New SQLiteCommand("UPDATE customer_tbl SET name = @name, contact_number = @contact_number, customer_address = @customer_address, user_id = @user_id WHERE customer_id = @customer_id;", sqliteConnection)
                updateCustomerCmd.Parameters.AddWithValue("@name", name)
                updateCustomerCmd.Parameters.AddWithValue("@contact_number", contact_number)
                updateCustomerCmd.Parameters.AddWithValue("@customer_address", customer_address)
                updateCustomerCmd.Parameters.AddWithValue("@customer_id", customer_id)
                updateCustomerCmd.Parameters.AddWithValue("@user_id", user_id)
                updateCustomerCmd.ExecuteNonQuery()
            End Using

            Using updateProductCmd As New SQLiteCommand("UPDATE product_tbl SET product_name = @product_name, price = @price, quantity = @quantity, amount = @amount, visibility = @visibility, date = date(), productType_id = @productType_id, productStatus_id = @productStatus_id WHERE customer_id = @customer_id;", sqliteConnection)
                updateProductCmd.Parameters.AddWithValue("@product_name", product_name)
                updateProductCmd.Parameters.AddWithValue("@price", price)
                updateProductCmd.Parameters.AddWithValue("@quantity", quantity)
                updateProductCmd.Parameters.AddWithValue("@amount", amount)
                updateProductCmd.Parameters.AddWithValue("@visibility", visibility)
                updateProductCmd.Parameters.AddWithValue("@customer_id", customer_id)
                updateProductCmd.Parameters.AddWithValue("@productType_id", prod_typeId)
                updateProductCmd.Parameters.AddWithValue("@productStatus_id", prod_statusId)
                updateProductCmd.ExecuteNonQuery()
            End Using


            MessageBox.Show("Updated Successfully!")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            SQLite_Close_Connection()
        End Try
    End Sub

    Public Sub Load_Sales_Data()

        Try

            SQLite_Open_Connection()

            dataSet = New DataSet

            sqliteDataAdapter = New SQLiteDataAdapter("SELECT customer_tbl.customer_id, customer_tbl.name,product_tbl.product_name AS 'product',product_tbl.price,product_tbl.quantity,product_tbl.amount,productType_tbl.type,productStatus_tbl.status,customer_tbl.contact_number AS 'contact number',customer_tbl.customer_address AS 'address',product_tbl.date 
                                                        FROM product_tbl INNER JOIN customer_tbl ON product_tbl.customer_id=customer_tbl.customer_id INNER JOIN productType_tbl ON product_tbl.productType_id=productType_tbl.productType_id 
                                                        INNER JOIN productStatus_tbl ON product_tbl.productStatus_id=productStatus_tbl.productStatus_id WHERE product_tbl.visibility=1;", sqliteConnection)

            sqliteDataAdapter.Fill(dataSet, "customer_tbl")

            Form_Main.dgvSales.DataSource = dataSet.Tables(0)

        Catch ex As SQLiteException

            MessageBox.Show("Error: " & ex.Message)

        Finally

            SQLite_Close_Connection()

        End Try

    End Sub
    Public Sub Search_Sales_Data(ByVal searchSales As String)
        Try
            SQLite_Open_Connection()

            Dim searchResultsTable As New DataTable()

            Dim searchColumns As New List(Of String) From {"customer_tbl.name", "product_tbl.product_name", "product_tbl.price", "product_tbl.quantity", "product_tbl.amount", "productType_tbl.type", "productStatus_tbl.status", "customer_tbl.contact_number", "customer_tbl.customer_address"}

            Dim searchVariable As String = searchSales

            Dim whereClause As New StringBuilder()
            For Each column As String In searchColumns
                whereClause.Append("LOWER(" & column & ") LIKE @search OR ")
            Next

            whereClause.Length -= 4

            Dim query As String = "SELECT customer_tbl.customer_id, customer_tbl.name, product_tbl.product_name AS 'product', product_tbl.price, product_tbl.quantity, product_tbl.amount, productType_tbl.type, productStatus_tbl.status, customer_tbl.contact_number AS 'contact number', customer_tbl.customer_address AS 'address', product_tbl.date " &
                  "FROM product_tbl " &
                  "INNER JOIN customer_tbl ON product_tbl.customer_id = customer_tbl.customer_id " &
                  "INNER JOIN productType_tbl ON product_tbl.productType_id = productType_tbl.productType_id " &
                  "INNER JOIN productStatus_tbl ON product_tbl.productStatus_id = productStatus_tbl.productStatus_id " &
                  "WHERE product_tbl.visibility = 1 AND (" & whereClause.ToString() & ") " &
                  "COLLATE NOCASE;"

            Using adapter As New SQLiteDataAdapter(query, sqliteConnection)
                adapter.SelectCommand.Parameters.AddWithValue("@search", searchVariable & "%")
                adapter.Fill(searchResultsTable)
                Form_Main.dgvSales.DataSource = searchResultsTable
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Public Sub Empty_Sales_Data()

        Try

            SQLite_Open_Connection()

            dataSet = New DataSet

            sqliteDataAdapter = New SQLiteDataAdapter("UPDATE product_tbl SET visibility = 2", sqliteConnection)

            sqliteDataAdapter.Fill(dataSet, "customer_tbl")



        Catch ex As SQLiteException

            MessageBox.Show("Error: " & ex.Message)

        Finally

            SQLite_Close_Connection()

        End Try

    End Sub
    Public Sub Remove_Sales_Data(ByVal prodID As Integer)

        Try

            SQLite_Open_Connection()

            dataSet = New DataSet

            sqliteDataAdapter = New SQLiteDataAdapter("UPDATE product_tbl SET visibility = 0 WHERE product_tbl.product_id = " & prodID & "", sqliteConnection)

            sqliteDataAdapter.Fill(dataSet, "product_tbl")

            MessageBox.Show("Data Removed.")

        Catch ex As SQLiteException

            MessageBox.Show("Error: " & ex.Message)

        Finally

            SQLite_Close_Connection()

        End Try
    End Sub



End Module
