Imports System.Data.SQLite
Imports System.Text

Module Mod_History
    Public Sub Load_History_Data()

        Try

            SQLite_Open_Connection()

            dataSet = New DataSet

            sqliteDataAdapter = New SQLiteDataAdapter("SELECT customer_tbl.customer_id, customer_tbl.name,product_tbl.product_name AS 'product',product_tbl.price,product_tbl.quantity,product_tbl.amount,productType_tbl.type,productStatus_tbl.status,customer_tbl.contact_number AS 'contact number',customer_tbl.customer_address AS 'address',product_tbl.date 
                                                        FROM product_tbl INNER JOIN customer_tbl ON product_tbl.customer_id=customer_tbl.customer_id INNER JOIN productType_tbl ON product_tbl.productType_id=productType_tbl.productType_id 
                                                        INNER JOIN productStatus_tbl ON product_tbl.productStatus_id=productStatus_tbl.productStatus_id WHERE product_tbl.visibility!=1;", sqliteConnection)

            sqliteDataAdapter.Fill(dataSet, "customer_tbl")

            Form_Sales_History.dgvHistory.DataSource = dataSet.Tables(0)

        Catch ex As SQLiteException

            MessageBox.Show("Error: " & ex.Message)

        Finally

            SQLite_Close_Connection()

        End Try

    End Sub
    Public Sub Load_History_Type_Data(ByVal filterType As String)


        Try
            SQLite_Open_Connection()

            Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT customer_tbl.customer_id, customer_tbl.name, product_tbl.product_name AS 'product', product_tbl.price, product_tbl.quantity, product_tbl.amount, productType_tbl.type, productStatus_tbl.status, customer_tbl.contact_number AS 'contact number', customer_tbl.customer_address AS 'address', product_tbl.date " &
                     "FROM product_tbl " &
                     "INNER JOIN customer_tbl ON product_tbl.customer_id = customer_tbl.customer_id " &
                     "INNER JOIN productType_tbl ON product_tbl.productType_id = productType_tbl.productType_id " &
                     "INNER JOIN productStatus_tbl ON product_tbl.productStatus_id = productStatus_tbl.productStatus_id " &
                     "WHERE product_tbl.visibility != 1 AND productType_tbl.type = @filterType", sqliteConnection)


            cmd.Parameters.AddWithValue("@filterType", filterType)

            Dim mda As New SQLiteDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Clear()
            mda.Fill(dt)
            Form_Sales_History.dgvHistory.DataSource = dt


        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try



    End Sub
    Public Sub Search_Sales_History_Type_Data(ByVal searchReport As String, ByVal filterType As String)
        Try
            SQLite_Open_Connection()

            Dim searchResultsTable As New DataTable()

            Dim searchColumns As New List(Of String) From {
            "customer_tbl.name",
            "product_tbl.product_name",
            "product_tbl.price",
            "product_tbl.quantity",
            "product_tbl.amount",
            "productType_tbl.type",
            "productStatus_tbl.status",
            "customer_tbl.contact_number",
            "customer_tbl.customer_address"
        }

            Dim whereClause As New StringBuilder()
            For Each column As String In searchColumns
                whereClause.Append("LOWER(" & column & ") LIKE @search OR ")
            Next

            whereClause.Length -= 4

            Dim searchPattern As String = If(Not String.IsNullOrEmpty(searchReport), String.Join("%", searchReport.ToCharArray()) & "%", "%")

            Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT customer_tbl.name, product_tbl.product_name AS 'product', product_tbl.price, product_tbl.quantity, product_tbl.amount, productType_tbl.type, productStatus_tbl.status, customer_tbl.contact_number AS 'contact number', customer_tbl.customer_address AS 'address', product_tbl.date " &
          "FROM product_tbl " &
          "INNER JOIN customer_tbl ON product_tbl.customer_id = customer_tbl.customer_id " &
          "INNER JOIN productType_tbl ON product_tbl.productType_id = productType_tbl.productType_id " &
          "INNER JOIN productStatus_tbl ON product_tbl.productStatus_id = productStatus_tbl.productStatus_id " &
          "WHERE product_tbl.visibility != 1 AND (" & whereClause.ToString() & ") COLLATE NOCASE AND productType_tbl.type = @filterType;", sqliteConnection)

            cmd.Parameters.AddWithValue("@search", searchPattern)
            cmd.Parameters.AddWithValue("@filterType", filterType)

            Dim mda As New SQLiteDataAdapter(cmd)
            searchResultsTable.Clear()
            mda.Fill(searchResultsTable)
            Form_Sales_History.dgvHistory.DataSource = searchResultsTable
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Public Sub Search_Sales_History_All(ByVal searchReport As String)


        Try
            SQLite_Open_Connection()

            Dim searchResultsTable As New DataTable()


            Dim searchColumns As New List(Of String) From {"customer_tbl.name", "product_tbl.product_name", "product_tbl.price", "product_tbl.quantity", "product_tbl.amount", "productType_tbl.type", "productStatus_tbl.status", "customer_tbl.contact_number", "customer_tbl.customer_address"}


            Dim searchVariable As String = searchReport

            Dim whereClause As New StringBuilder()
            For Each column As String In searchColumns
                whereClause.Append(column & " LIKE @search OR ")
            Next

            whereClause.Length -= 4

            Dim searchPattern As String = If(Not String.IsNullOrEmpty(searchReport), String.Join("%", searchReport.ToCharArray()) & "%", "%")
            Dim query As String = "SELECT customer_tbl.customer_id, customer_tbl.name, product_tbl.product_name AS 'product', product_tbl.price, product_tbl.quantity, product_tbl.amount, productType_tbl.type, productStatus_tbl.status, customer_tbl.contact_number AS 'contact number', customer_tbl.customer_address AS 'address', product_tbl.date " &
                     "FROM product_tbl " &
                     "INNER JOIN customer_tbl ON product_tbl.customer_id = customer_tbl.customer_id " &
                     "INNER JOIN productType_tbl ON product_tbl.productType_id = productType_tbl.productType_id " &
                     "INNER JOIN productStatus_tbl ON product_tbl.productStatus_id = productStatus_tbl.productStatus_id " &
                     "WHERE product_tbl.visibility != 1 AND (" & whereClause.ToString() & ")"

            Using adapter As New SQLiteDataAdapter(query, sqliteConnection)

                adapter.SelectCommand.Parameters.AddWithValue("@search", searchPattern)

                adapter.Fill(searchResultsTable)

                Form_Sales_History.dgvHistory.DataSource = searchResultsTable
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try


    End Sub

    Public Sub Data_Undo(ByVal customer_id As Integer)
        Try
            SQLite_Open_Connection()
            dataSet = New DataSet

            Dim visibility As Integer = 1

            sqliteDataAdapter = New SQLiteDataAdapter("UPDATE product_tbl SET visibility = " & visibility & " WHERE customer_id = " & customer_id & "", sqliteConnection)

            sqliteDataAdapter.Fill(dataSet, "product_tbl")

            If visibility = 1 Then
                MessageBox.Show("Success.")
            Else
                MessageBox.Show("Failed.")
            End If

        Catch ex As SQLiteException
            MessageBox.Show("Error: " & ex.Message)
        Finally
            SQLite_Close_Connection()
        End Try
    End Sub


End Module
