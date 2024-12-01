Imports System.Security.Cryptography

Public Class Form_Sales_History

    Dim filterType, searchReport As String
    Private Sub Form_Sales_History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_History_Data()
        cmbHistoryType.SelectedIndex = 0
    End Sub

    Private Sub btnUndo_Click(sender As Object, e As EventArgs) Handles btnUndo.Click
        If dgvHistory.Rows.Count = 0 Then
            MessageBox.Show("The history is empty. There are no items to undo.", "Empty History", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim uID As Integer
        Dim selectedRow As DataGridViewRow = dgvHistory.CurrentRow

        If selectedRow IsNot Nothing Then
            uID = Convert.ToInt32(selectedRow.Cells(0).Value)
            Data_Undo(uID)
            Load_Sales_Data()
            Load_Sales_Report_Data()

            If cmbHistoryType.SelectedIndex = 1 OrElse cmbHistoryType.SelectedIndex = 2 Then
                Load_History_Type_Data(filterType)
            Else
                Load_History_Data()
            End If
        Else
            MessageBox.Show("Please select a row in the history to undo.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Private Sub cmbHistoryType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbHistoryType.SelectedIndexChanged
        filterType = cmbHistoryType.Text
        If cmbHistoryType.SelectedIndex = 1 OrElse cmbHistoryType.SelectedIndex = 2 Then
            Search_Sales_History_Type_Data(searchReport, filterType)
            Load_History_Type_Data(filterType)
        Else
            Search_Sales_History_All(searchReport)
            Load_History_Data()
        End If
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
        Form_Main.Show()
    End Sub

    Private Sub txtSearchHistory_TextChanged(sender As Object, e As EventArgs) Handles txtSearchHistory.TextChanged
        searchReport = txtSearchHistory.Text.Trim()


        If cmbHistoryType.SelectedIndex = 1 Or cmbHistoryType.SelectedIndex = 2 Then
            Search_Sales_History_Type_Data(searchReport, filterType)
        Else
            Search_Sales_History_All(searchReport)
        End If
    End Sub
End Class