Public Class Form1
    Private dataTable As New DataTable()
    Private dt As New DataTable()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dateValue As Date = MonthCalendar1.SelectionStart.Date
        Dim timeValue As String = DateTime.Now.ToString("hh:mm tt")
        Dim eventValue As String = TextBox1.Text

        dataTable.Rows.Add(dateValue, timeValue, eventValue)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dataTable.Columns.Add("Date", GetType(Date))
        dataTable.Columns.Add("Time", GetType(String))
        dataTable.Columns.Add("Event", GetType(String))
        TextBox2.Hide()
        Label2.Hide()
        Label3.Hide()


        DataGridView1.DataSource = dataTable
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Label2.Show()
        TextBox2.Show()
        Label3.Show()

        MessageBox.Show("Please Select The Row Then Type New Value in TextBox Above")

        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow = DataGridView1.SelectedRows(0)
            Dim rowIndex = DataGridView1.Rows.IndexOf(selectedRow)


            dataTable.Rows(rowIndex)("Time") = TextBox2.Text
            dataTable.Rows(rowIndex)("Event") = TextBox1.Text
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow = DataGridView1.SelectedRows(0)
            Dim rowIndex = DataGridView1.Rows.IndexOf(selectedRow)

            ' Delete the row from the DataTable
            dataTable.Rows.RemoveAt(rowIndex)
        End If
    End Sub 'The expression contains undefined function call Month().'


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim selectedOption As String = ComboBox1.SelectedItem.ToString()
        Dim selectedDate As Date = MonthCalendar1.SelectionStart.Date

        Select Case selectedOption
            Case "Daily"
                dataTable.DefaultView.RowFilter = $"Date = #{selectedDate.ToString("MM/dd/yyyy")}#"
            Case "Monthly"
                dataTable.DefaultView.RowFilter = $"Date >= #{selectedDate.ToString("MM/01/yyyy")}# AND Date < #{selectedDate.AddMonths(1).ToString("MM/01/yyyy")}#"
            Case "Yearly"
                dataTable.DefaultView.RowFilter = $"Date >= #{selectedDate.ToString("01/01/yyyy")}# AND Date < #{selectedDate.AddYears(1).ToString("01/01/yyyy")}#"
        End Select

        DataGridView1.DataSource = dataTable.DefaultView
    End Sub


    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        dt = dataTable
        DataGridView1.DataSource = dt
    End Sub
End Class
