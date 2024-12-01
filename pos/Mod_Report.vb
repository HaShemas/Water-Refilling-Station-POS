Imports System.Data.SQLite
Imports System.Text
Module Mod_Report

    Public Sub Load_Sales_Report_Data()
        Try
            SQLite_Open_Connection()
            dataSet = New DataSet

            sqliteDataAdapter = New SQLiteDataAdapter("SELECT customer_tbl.name,product_tbl.product_name AS 'product',product_tbl.price,product_tbl.quantity,product_tbl.amount,productType_tbl.type,productStatus_tbl.status,customer_tbl.contact_number AS 'contact number',customer_tbl.customer_address AS 'address',product_tbl.date FROM product_tbl INNER JOIN customer_tbl ON product_tbl.customer_id=customer_tbl.customer_id INNER JOIN productType_tbl ON product_tbl.productType_id=productType_tbl.productType_id INNER JOIN productStatus_tbl ON product_tbl.productStatus_id=productStatus_tbl.productStatus_id WHERE product_tbl.visibility!= 0;", sqliteConnection)

            sqliteDataAdapter.Fill(dataSet, "customer_tbl")


            If dataSet.Tables("customer_tbl") IsNot Nothing AndAlso dataSet.Tables("customer_tbl").Rows.Count > 0 Then
                Form_Main.dgvSalesReport.DataSource = dataSet.Tables("customer_tbl")
            Else

                Form_Main.dgvSalesReport.DataSource = Nothing

            End If
        Catch ex As SQLiteException
            MessageBox.Show("SQLite Error: " & ex.Message)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            SQLite_Close_Connection()
        End Try
    End Sub



    Public Sub Search_Sales_Report_Data(ByVal searchReport As String)


        Try
            SQLite_Open_Connection()

            Dim searchResultsTable As New DataTable()


            Dim searchColumns As New List(Of String) From {"customer_tbl.name", "product_tbl.product_name", "product_tbl.price", "product_tbl.quantity", "product_tbl.amount", "productType_tbl.type", "productStatus_tbl.status", "customer_tbl.contact_number", "customer_tbl.customer_address"}


            Dim searchVariable As String = searchReport

            Dim whereClause As New StringBuilder()
            For Each column As String In searchColumns
                whereClause.Append("LOWER(" & column & ") LIKE @search OR ")
            Next

            whereClause.Length -= 4

            Dim searchPattern As String = If(Not String.IsNullOrEmpty(searchReport), String.Join("%", searchReport.ToCharArray()) & "%", "%")
            Dim query As String = "SELECT customer_tbl.name, product_tbl.product_name AS 'product', product_tbl.price, product_tbl.quantity, product_tbl.amount, productType_tbl.type, productStatus_tbl.status, customer_tbl.contact_number AS 'contact number', customer_tbl.customer_address AS 'address', product_tbl.date " &
                     "FROM product_tbl " &
                     "INNER JOIN customer_tbl ON product_tbl.customer_id = customer_tbl.customer_id " &
                     "INNER JOIN productType_tbl ON product_tbl.productType_id = productType_tbl.productType_id " &
                     "INNER JOIN productStatus_tbl ON product_tbl.productStatus_id = productStatus_tbl.productStatus_id " &
                     "WHERE product_tbl.visibility != 0 AND (" & whereClause.ToString() & ")"

            Using adapter As New SQLiteDataAdapter(query, sqliteConnection)

                adapter.SelectCommand.Parameters.AddWithValue("@search", searchPattern)

                adapter.Fill(searchResultsTable)

                Form_Main.dgvSalesReport.DataSource = searchResultsTable
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try


    End Sub

    Public Sub Load_Sales_Report_Data_Date(filterType As String)
        Try
            SQLite_Open_Connection()

            Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT customer_tbl.name,product_tbl.product_name AS 'product',product_tbl.price,product_tbl.quantity,product_tbl.amount,productType_tbl.type,productStatus_tbl.status,customer_tbl.contact_number AS 'contact number',customer_tbl.customer_address AS 'address',product_tbl.date 
                                                    FROM product_tbl INNER JOIN customer_tbl ON product_tbl.customer_id=customer_tbl.customer_id INNER JOIN productType_tbl ON product_tbl.productType_id=productType_tbl.productType_id 
                                                    INNER JOIN productStatus_tbl ON product_tbl.productStatus_id=productStatus_tbl.productStatus_id WHERE product_tbl.visibility != 0 AND productType_tbl.type = @filterType AND date BETWEEN @fromDate And @toDate;", sqliteConnection)
            cmd.Parameters.AddWithValue("@filterType", filterType)
            cmd.Parameters.AddWithValue("@fromDate", DateAdd(DateInterval.Day, -1, Form_Main.dtpFrom.Value))
            cmd.Parameters.AddWithValue("@toDate", Form_Main.dtpTo.Value)

            Dim dt As New DataTable
            Dim mda As New SQLiteDataAdapter(cmd)

            mda.Fill(dt)

            If dt.Rows.Count > 0 Then
                Form_Main.dgvSalesReport.DataSource = dt


            End If
        Catch ex As SQLiteException
            MessageBox.Show("Error: " & ex.Message)
        Finally
            SQLite_Close_Connection()
        End Try
    End Sub

    Public Sub Search_Sales_Report_Data_Date(ByVal searchReport As String, ByVal filterType As String)
        Try
            SQLite_Open_Connection()

            Dim searchResultsTable As New DataTable()

            Dim searchColumns As New List(Of String) From {"customer_tbl.name", "product_tbl.product_name", "product_tbl.price", "product_tbl.quantity", "product_tbl.amount", "productType_tbl.type", "productStatus_tbl.status", "customer_tbl.contact_number", "customer_tbl.customer_address"}

            Dim searchVariable As String = searchReport.ToLower()

            Dim whereClause As New StringBuilder()
            For Each column As String In searchColumns
                whereClause.Append("LOWER(" & column & ") LIKE @search OR ")
            Next

            whereClause.Length -= 4


            Dim searchPattern As String = String.Join("%", searchVariable.ToCharArray()) & "%"
            Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT customer_tbl.name, product_tbl.product_name AS 'product', product_tbl.price, product_tbl.quantity, product_tbl.amount, productType_tbl.type, productStatus_tbl.status, customer_tbl.contact_number AS 'contact number', customer_tbl.customer_address AS 'address', product_tbl.date " &
              "FROM product_tbl " &
              "INNER JOIN customer_tbl ON product_tbl.customer_id = customer_tbl.customer_id " &
              "INNER JOIN productType_tbl ON product_tbl.productType_id = productType_tbl.productType_id " &
              "INNER JOIN productStatus_tbl ON product_tbl.productStatus_id = productStatus_tbl.productStatus_id " &
              "WHERE product_tbl.visibility != 0 AND (" & whereClause.ToString() & ") COLLATE NOCASE AND productType_tbl.type = @filterType AND date BETWEEN @fromDate And @toDate;", sqliteConnection)

            cmd.Parameters.AddWithValue("@search", searchPattern)
            cmd.Parameters.AddWithValue("@filterType", filterType)
            cmd.Parameters.AddWithValue("@fromDate", DateAdd(DateInterval.Day, -1, Form_Main.dtpFrom.Value))
            cmd.Parameters.AddWithValue("@toDate", Form_Main.dtpTo.Value)
            Dim mda As New SQLiteDataAdapter(cmd)
            searchResultsTable.Clear()
            mda.Fill(searchResultsTable)
            Form_Main.dgvSalesReport.DataSource = searchResultsTable
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub





    Public Sub Search_Sales_Report_Data_Date_All(ByVal searchReport As String)
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

            Dim searchVariable As String = searchReport

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
             "WHERE product_tbl.visibility != 0 AND (" & whereClause.ToString() & ") AND date BETWEEN @fromDate And @toDate;", sqliteConnection)

            cmd.Parameters.AddWithValue("@search", searchPattern)

            cmd.Parameters.AddWithValue("@fromDate", DateAdd(DateInterval.Day, -1, Form_Main.dtpFrom.Value))
            cmd.Parameters.AddWithValue("@toDate", Form_Main.dtpTo.Value)
            Dim mda As New SQLiteDataAdapter(cmd)
            searchResultsTable.Clear()
            mda.Fill(searchResultsTable)
            Form_Main.dgvSalesReport.DataSource = searchResultsTable
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub


    Public Sub Search_Sales_Report_Data_Type(ByVal searchReport As String, ByVal filterType As String)
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
          "WHERE product_tbl.visibility != 0 AND (" & whereClause.ToString() & ") COLLATE NOCASE AND productType_tbl.type = @filterType;", sqliteConnection)

            cmd.Parameters.AddWithValue("@search", searchPattern)
            cmd.Parameters.AddWithValue("@filterType", filterType)

            Dim mda As New SQLiteDataAdapter(cmd)
            searchResultsTable.Clear()
            mda.Fill(searchResultsTable)
            Form_Main.dgvSalesReport.DataSource = searchResultsTable
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub





    Public Sub Load_Sales_Report_All_Data_Date()

        Try

            SQLite_Open_Connection()



            Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT customer_tbl.name,product_tbl.product_name AS 'product',product_tbl.price,product_tbl.quantity,product_tbl.amount,productType_tbl.type,productStatus_tbl.status,customer_tbl.contact_number AS 'contact number',customer_tbl.customer_address AS 'address',product_tbl.date 
                                                        FROM product_tbl INNER JOIN customer_tbl ON product_tbl.customer_id=customer_tbl.customer_id INNER JOIN productType_tbl ON product_tbl.productType_id=productType_tbl.productType_id 
                                                        INNER JOIN productStatus_tbl ON product_tbl.productStatus_id=productStatus_tbl.productStatus_id WHERE product_tbl.visibility!= 0  AND date BETWEEN @fromDate And @toDate;", sqliteConnection)

            cmd.Parameters.AddWithValue("@fromDate", DateAdd(DateInterval.Day, -1, Form_Main.dtpFrom.Value))
            cmd.Parameters.AddWithValue("@toDate", Form_Main.dtpTo.Value)
            Dim mda As New SQLiteDataAdapter(cmd)
            Dim dt As New DataTable
            dt.Clear()
            mda.Fill(dt)

            If dt.Rows.Count > 0 Then
                Form_Main.dgvSalesReport.DataSource = dt
            Else
                MessageBox.Show("No data found!")
            End If
        Catch ex As SQLiteException

            MessageBox.Show("Error: " & ex.Message)

        Finally

            SQLite_Close_Connection()

        End Try

    End Sub
    Public Sub Load_Sales_Report_Data_Type(ByVal filterType As String)
        Try
            SQLite_Open_Connection()
            dataSet = New DataSet


            Dim query As String = "SELECT customer_tbl.name,product_tbl.product_name AS 'product',product_tbl.price,product_tbl.quantity,product_tbl.amount,productType_tbl.type,productStatus_tbl.status,customer_tbl.contact_number AS 'contact number',customer_tbl.customer_address AS 'address',product_tbl.date 
                               FROM product_tbl INNER JOIN customer_tbl ON product_tbl.customer_id=customer_tbl.customer_id 
                               INNER JOIN productType_tbl ON product_tbl.productType_id=productType_tbl.productType_id 
                               INNER JOIN productStatus_tbl ON product_tbl.productStatus_id=productStatus_tbl.productStatus_id 
                               WHERE product_tbl.visibility!= 0 AND productType_tbl.type = @filterType;"

            Using cmd As New SQLiteCommand(query, sqliteConnection)
                cmd.Parameters.AddWithValue("@filterType", filterType)

                sqliteDataAdapter = New SQLiteDataAdapter(cmd)
                sqliteDataAdapter.Fill(dataSet, "customer_tbl")
            End Using

            If dataSet.Tables("customer_tbl").Rows.Count > 0 Then
                Form_Main.dgvSalesReport.DataSource = dataSet.Tables("customer_tbl")
            Else

                Form_Main.dgvSalesReport.DataSource = Nothing
                MessageBox.Show("No data found.")
            End If
        Catch ex As SQLiteException
            MessageBox.Show("SQLite Error: " & ex.Message)
        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message)
        Finally
            SQLite_Close_Connection()
        End Try
    End Sub

    Public Sub Transactions_Range(ByVal filterType As String)
        Try
            SQLite_Open_Connection()
            Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT COUNT(product_tbl.product_id) FROM product_tbl INNER JOIN productType_tbl ON product_tbl.productType_id = productType_tbl.productType_id
                 WHERE product_tbl.visibility != 0 AND productType_tbl.type = @filterType AND date BETWEEN @fromDate And @toDate;", sqliteConnection)

            cmd.Parameters.AddWithValue("@filterType", filterType)
            cmd.Parameters.AddWithValue("@fromDate", DateAdd(DateInterval.Day, -1, Form_Main.dtpFrom.Value))
            cmd.Parameters.AddWithValue("@toDate", Form_Main.dtpTo.Value)

            Dim transactionsCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            If transactionsCount > 0 Then
                Form_Main.lblRangeTrans.Text = transactionsCount.ToString()
            Else
                Form_Main.lblRangeTrans.Text = "0"
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            SQLite_Close_Connection()
        End Try
    End Sub

    Public Sub Transactions_Range_All_Type()
        Try
            SQLite_Open_Connection()
            Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT COUNT(product_tbl.product_id) FROM product_tbl INNER JOIN productType_tbl ON product_tbl.productType_id = productType_tbl.productType_id WHERE product_tbl.visibility != 0 AND date BETWEEN @fromDate AND @toDate;", sqliteConnection)

            cmd.Parameters.AddWithValue("@fromDate", DateAdd(DateInterval.Day, -1, Form_Main.dtpFrom.Value))
            cmd.Parameters.AddWithValue("@toDate", Form_Main.dtpTo.Value)
            Dim transactionsCount As Object = cmd.ExecuteScalar()

            If transactionsCount IsNot DBNull.Value Then
                Dim count As Integer = Convert.ToInt32(transactionsCount)
                Form_Main.lblRangeTrans.Text = count.ToString()
            Else
                Form_Main.lblRangeTrans.Text = "0"
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            SQLite_Close_Connection()
        End Try
    End Sub

    Public Sub Transactions_Range_Form()


        Try
            SQLite_Open_Connection()
            Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT COUNT(product_id) FROM product_tbl WHERE visibility != 0;", sqliteConnection)
            Dim transactionsCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            Form_Main.lblRangeTrans.Text = transactionsCount.ToString()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

    End Sub
    Public Sub Transactions_Range_Type(ByVal filterType As String)

        Try
            SQLite_Open_Connection()
            dataSet = New DataSet
            Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT COUNT(product_tbl.product_id) FROM product_tbl INNER JOIN productType_tbl ON 
            product_tbl.productType_id=productType_tbl.productType_id WHERE product_tbl.visibility != 0 AND productType_tbl.type = @filterType;", sqliteConnection)
            cmd.Parameters.AddWithValue("@filterType", filterType)
            Dim transactionsCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            If transactionsCount > 0 Then
                Form_Main.lblRangeTrans.Text = transactionsCount.ToString()
            Else

                Form_Main.lblRangeTrans.Text = "0"
            End If
        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message)
        Finally
            SQLite_Close_Connection()
        End Try


    End Sub

    Public Sub Sales_Range(ByVal filterType As String)
        Try
            SQLite_Open_Connection()

            Dim query As String = "SELECT SUM(product_tbl.amount) FROM product_tbl " &
                          "INNER JOIN productType_tbl ON product_tbl.productType_id = productType_tbl.productType_id " &
                          "WHERE product_tbl.visibility <> 0 " &
                          "AND productType_tbl.type = @filterType " &
                          "AND date BETWEEN @fromDate AND @toDate;"

            Using cmd As New SQLiteCommand(query, sqliteConnection)
                cmd.Parameters.AddWithValue("@filterType", filterType)
                cmd.Parameters.AddWithValue("@fromDate", DateAdd(DateInterval.Day, -1, Form_Main.dtpFrom.Value))
                cmd.Parameters.AddWithValue("@toDate", Form_Main.dtpTo.Value)

                Dim transactionsTotal As Object = cmd.ExecuteScalar()

                If transactionsTotal IsNot DBNull.Value Then
                    Form_Main.lblRangeSales.Text = Convert.ToDecimal(transactionsTotal).ToString()
                Else
                    Form_Main.lblRangeSales.Text = "0"
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


    Public Sub Sales_Range_All_Type()
        Try
            SQLite_Open_Connection()

            Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT SUM(product_tbl.amount) FROM product_tbl INNER JOIN productType_tbl ON product_tbl.productType_id = productType_tbl.productType_id WHERE product_tbl.visibility != 0 AND date BETWEEN @fromDate AND @toDate;", sqliteConnection)

            cmd.Parameters.AddWithValue("@fromDate", DateAdd(DateInterval.Day, -1, Form_Main.dtpFrom.Value))
            cmd.Parameters.AddWithValue("@toDate", Form_Main.dtpTo.Value)
            Dim transactionsTotal As Object = cmd.ExecuteScalar()

            If transactionsTotal IsNot DBNull.Value Then
                Dim totalAmount As Decimal = Convert.ToDecimal(transactionsTotal)
                Form_Main.lblRangeSales.Text = totalAmount.ToString()
            Else
                Form_Main.lblRangeSales.Text = "0"
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            SQLite_Close_Connection()
        End Try
    End Sub

    Public Sub Sales_Range_Form()
        Try
            SQLite_Open_Connection()
            Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT SUM(amount) FROM product_tbl WHERE visibility != 0;", sqliteConnection)
            Dim transactionsTotal As Object = cmd.ExecuteScalar()

            If transactionsTotal IsNot DBNull.Value Then
                Dim totalAmount As Decimal = Convert.ToDecimal(transactionsTotal)
                Form_Main.lblRangeSales.Text = totalAmount.ToString()
            Else
                Form_Main.lblRangeSales.Text = "0"
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            SQLite_Close_Connection()
        End Try
    End Sub

    Public Sub Sales_Range_Type(ByVal filterType As String)
        Try
            SQLite_Open_Connection()
            dataSet = New DataSet
            Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT SUM(product_tbl.amount) FROM product_tbl INNER JOIN productType_tbl ON product_tbl.productType_id=productType_tbl.productType_id WHERE product_tbl.visibility != 0 AND productType_tbl.type = @filterType;", sqliteConnection)
            cmd.Parameters.AddWithValue("@filterType", filterType)

            Dim result As Object = cmd.ExecuteScalar()

            If result IsNot DBNull.Value Then

                Dim transactionsTotal As Decimal = Convert.ToDecimal(result)
                Form_Main.lblRangeSales.Text = transactionsTotal.ToString()
            Else

                Form_Main.lblRangeSales.Text = "0"
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            SQLite_Close_Connection()
        End Try
    End Sub

    Public Sub Number_Sales_Range(ByVal filterType As String)


        Try
            SQLite_Open_Connection()

            Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT SUM(product_tbl.quantity) FROM product_tbl INNER JOIN productType_tbl ON product_tbl.productType_id = productType_tbl.productType_id
                     WHERE product_tbl.visibility != 0 AND productType_tbl.type = @filterType AND date BETWEEN @fromDate And @toDate;", sqliteConnection)

            cmd.Parameters.AddWithValue("@filterType", filterType)
            cmd.Parameters.AddWithValue("@fromDate", DateAdd(DateInterval.Day, -1, Form_Main.dtpFrom.Value))
            cmd.Parameters.AddWithValue("@toDate", Form_Main.dtpTo.Value)

            Dim transactionsCount As Object = cmd.ExecuteScalar()
            If Not DBNull.Value.Equals(transactionsCount) Then
                Dim count As Integer = Convert.ToInt32(transactionsCount)
                Form_Main.lblRangeNumSales.Text = count.ToString()
            Else
                Form_Main.lblRangeNumSales.Text = "0"
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

    End Sub
    Public Sub Number_Sales_Range_All_Type()
        Try
            SQLite_Open_Connection()

            Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT SUM(product_tbl.quantity) FROM product_tbl INNER JOIN productType_tbl ON product_tbl.productType_id = productType_tbl.productType_id WHERE product_tbl.visibility != 0 AND date BETWEEN @fromDate AND @toDate;", sqliteConnection)

            cmd.Parameters.AddWithValue("@fromDate", DateAdd(DateInterval.Day, -1, Form_Main.dtpFrom.Value))
            cmd.Parameters.AddWithValue("@toDate", Form_Main.dtpTo.Value)
            Dim transactionsCount As Object = cmd.ExecuteScalar()

            If transactionsCount IsNot DBNull.Value Then
                Dim count As Integer = Convert.ToInt32(transactionsCount)
                Form_Main.lblRangeNumSales.Text = count.ToString()
            Else
                Form_Main.lblRangeNumSales.Text = "0"
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            SQLite_Close_Connection()
        End Try
    End Sub

    Public Sub Number_Sales_Range_Form()
        Try
            SQLite_Open_Connection()
            Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT SUM(quantity) FROM product_tbl WHERE visibility != 0;", sqliteConnection)
            Dim transactionsCount As Object = cmd.ExecuteScalar()

            If transactionsCount IsNot DBNull.Value Then
                Dim count As Integer = Convert.ToInt32(transactionsCount)
                Form_Main.lblRangeNumSales.Text = count.ToString()
            Else
                Form_Main.lblRangeNumSales.Text = "0"
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            SQLite_Close_Connection()
        End Try
    End Sub

    Public Sub Number_Sales_Range_Type(ByVal filterType As String)
        Try
            SQLite_Open_Connection()
            dataSet = New DataSet
            Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT SUM(product_tbl.quantity) FROM product_tbl INNER JOIN productType_tbl ON product_tbl.productType_id=productType_tbl.productType_id WHERE product_tbl.visibility != 0 AND productType_tbl.type = @filterType;", sqliteConnection)
            cmd.Parameters.AddWithValue("@filterType", filterType)


            Dim result As Object = cmd.ExecuteScalar()

            If result IsNot DBNull.Value Then

                Dim transactionsCount As Integer = Convert.ToInt32(result)
                Form_Main.lblRangeNumSales.Text = transactionsCount.ToString()
            Else

                Form_Main.lblRangeNumSales.Text = "0"
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            SQLite_Close_Connection()
        End Try
    End Sub

    Public Sub Transaction_Month()
        Try
            SQLite_Open_Connection()
            Dim selectedDate As Date = Form_Main.dtpTransMth.Value
            Dim startOfMonth As Date = New Date(selectedDate.Year, selectedDate.Month, 1)
            Dim endOfMonth As Date = startOfMonth.AddMonths(1).AddDays(-1)

            Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT COUNT(product_id) FROM product_tbl WHERE visibility != 0 AND date BETWEEN @startDate AND @endDate;", sqliteConnection)
            cmd.Parameters.AddWithValue("@startDate", startOfMonth)
            cmd.Parameters.AddWithValue("@endDate", endOfMonth)

            Dim transactionsCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Form_Main.lblTransMth.Text = transactionsCount.ToString()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
    Public Sub Amount_Month()
        Try
            SQLite_Open_Connection()
            Dim selectedDate As Date = Form_Main.dtpAmountMth.Value
            Dim startOfMonth As Date = New Date(selectedDate.Year, selectedDate.Month, 1)
            Dim endOfMonth As Date = startOfMonth.AddMonths(1).AddDays(-1)

            Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT SUM(amount) FROM product_tbl WHERE visibility != 0 AND date BETWEEN @startDate AND @endDate;", sqliteConnection)
            cmd.Parameters.AddWithValue("@startDate", startOfMonth)
            cmd.Parameters.AddWithValue("@endDate", endOfMonth)

            Dim result As Object = cmd.ExecuteScalar()
            If Not IsDBNull(result) Then
                Dim transactionsCount As Decimal = Convert.ToDecimal(result)
                Form_Main.lblAmountMth.Text = transactionsCount.ToString()
            Else
                Form_Main.lblAmountMth.Text = "0"
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
    Public Sub Sales_Month()
        Try
            SQLite_Open_Connection()
            Dim selectedDate As Date = Form_Main.dtpSalesMth.Value
            Dim startOfMonth As Date = New Date(selectedDate.Year, selectedDate.Month, 1)
            Dim endOfMonth As Date = startOfMonth.AddMonths(1).AddDays(-1)

            Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT SUM(quantity) FROM product_tbl WHERE visibility != 0 AND date BETWEEN @startDate AND @endDate;", sqliteConnection)
            cmd.Parameters.AddWithValue("@startDate", startOfMonth)
            cmd.Parameters.AddWithValue("@endDate", endOfMonth)

            Dim result As Object = cmd.ExecuteScalar()
            If Not IsDBNull(result) Then

                Dim transactionsCount As Decimal = Convert.ToDecimal(result)
                Form_Main.lblSalesMth.Text = transactionsCount.ToString()
            Else
                Form_Main.lblSalesMth.Text = "0"
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
End Module
