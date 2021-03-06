Imports System.Data
Imports System.Data.OleDb

Public Class frm_add

    Private object_cmd As New clsCommands
    Private sVariables As New clsVariables

    Private IntCodeAcademy As Integer
    Dim sortColumn As Integer = -1
    Private Function count_hal_giri() As Integer
        Return object_cmd.getOleDbCommand("select count(*) from tbl_issue")
    End Function

    Public Function CountListViewItems(ByRef lvwView As ListView) As Integer
        '==============================================================================
        ' Purpose      :  Get the number of Items in ListView
        ' Inputs       :  ListView
        ' Returns      :  Number of Items in ListView
        ' Calls        :  = ListViewItemCount(ListView) ' mod_ListView
        ' Use in       :  Any Procedure 
        ' Date/Time    :  Thursday, May 22, 2003  1:02:50 PM
        '==============================================================================

        Return lvwView.Items.Count

    End Function
    Private Function sort_listview(ByRef Lvw As ListView)

        ' Set the ListViewItemSorter property to a new ListViewItemComparer
        ' object.
        ' Determine whether the column is the same as the last column clicked.

        If 1 <> sortColumn Then
            ' Set the sort column to the new column.
            ' sortColumn = e.Column
            ' Set the sort order to ascending by default.
            Lvw.Sorting = SortOrder.Descending
        Else
            ' Determine what the last sort order was and change it.
            If Lvw.Sorting = SortOrder.Ascending Then
                Lvw.Sorting = SortOrder.Descending
            Else
                Lvw.Sorting = SortOrder.Ascending
            End If
        End If
        ' Call the sort method to manually sort.
        Lvw.Sort()
        ' Set the ListViewItemSorter property to a new ListViewItemComparer
        ' object.

        Lvw.ListViewItemSorter = New ListViewItemComparer(1, Lvw.Sorting)
    End Function
    Private Function sort_listview2(ByRef Lvw2 As ListView)

        ' Set the ListViewItemSorter property to a new ListViewItemComparer
        ' object.
        ' Determine whether the column is the same as the last column clicked.

        If 2 <> sortColumn Then
            ' Set the sort column to the new column.
            ' sortColumn = e.Column
            ' Set the sort order to ascending by default.
            Lvw2.Sorting = SortOrder.Descending
        Else
            ' Determine what the last sort order was and change it.
            If Lvw2.Sorting = SortOrder.Ascending Then
                Lvw2.Sorting = SortOrder.Descending
            Else
                Lvw2.Sorting = SortOrder.Ascending
            End If
        End If
        ' Call the sort method to manually sort.
        Lvw2.Sort()
        ' Set the ListViewItemSorter property to a new ListViewItemComparer
        ' object.

        Lvw2.ListViewItemSorter = New ListViewItemComparer(2, Lvw2.Sorting)
    End Function

    Private Sub ListView1_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick
        '' Set the ListViewItemSorter property to a new ListViewItemComparer
        '' object.
        '' Determine whether the column is the same as the last column clicked.

        'If e.Column <> sortColumn Then
        '    ' Set the sort column to the new column.
        '    sortColumn = e.Column
        '    ' Set the sort order to ascending by default.
        '    ListView1.Sorting = SortOrder.Ascending
        'Else
        '    ' Determine what the last sort order was and change it.
        '    If ListView1.Sorting = SortOrder.Ascending Then
        '        ListView1.Sorting = SortOrder.Descending
        '    Else
        '        ListView1.Sorting = SortOrder.Ascending
        '    End If
        'End If
        '' Call the sort method to manually sort.
        'ListView1.Sort()
        '' Set the ListViewItemSorter property to a new ListViewItemComparer
        '' object.

        'ListView1.ListViewItemSorter = New ListViewItemComparer(e.Column, ListView1.Sorting)
    End Sub

    ' Implements the manual sorting of items by column.
    ' Implements the manual sorting of items by columns.
    Class ListViewItemComparer
        Implements IComparer
        Private col As Integer
        Private order As SortOrder

        Public Sub New()
            col = 1
            order = SortOrder.Ascending
        End Sub

        Public Sub New(ByVal column As Integer, ByVal order As SortOrder)
            col = 1
            Me.order = order
        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
                            Implements System.Collections.IComparer.Compare
            Dim returnVal As Integer = -1
            returnVal = [String].Compare(CType(x, _
                            ListViewItem).SubItems(col).Text, _
                            CType(y, ListViewItem).SubItems(col).Text)
            ' Determine whether the sort order is descending.
            If order = SortOrder.Descending Then
                ' Invert the value returned by String.Compare.
                returnVal *= -1
            End If

            Return returnVal
        End Function
    End Class

    Public Function filllistview(ByRef listview As ListView, ByVal value_mat As String, ByVal count_value_mat As Integer)

        Try

            Dim lvi As New ListViewItem
            lvi.Text = value_mat
            lvi.SubItems.Add(count_value_mat)
            listview.Items.Add(lvi)


            'Dim strsearchrow As String() = {value_mat, count_value_mat}
            'listview.Items.Add(New ListViewItem(strsearchrow))
            ' = SortOrder.Ascending
            listview.ListViewItemSorter = New CLvwSorter(1, _
                                        CLvwSorter.colType.colNumber, _
                                        listview.Sorting)
            'sort_listview(listview)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally

        End Try

        Return ""
    End Function
    Public Function filllistview2(ByRef listview2 As ListView, ByVal dr As String, ByVal value_mat As String, ByVal count_value_mat As Integer)

        Try

            'Dim strsearchrow As String() = {dr, value_mat, count_value_mat}
            'listview2.Items.Add(New ListViewItem(strsearchrow))

            Dim lvi As New ListViewItem
            lvi.Text = dr
            lvi.SubItems.Add(value_mat)
            lvi.SubItems.Add(count_value_mat)
            listview2.Items.Add(lvi)


            listview2.ListViewItemSorter = New CLvwSorter(2, _
                            CLvwSorter.colType.colNumber, _
                            listview2.Sorting)
            ' = SortOrder.Ascending
            'sort_listview2(listview2)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally

        End Try

        Return ""
    End Function

    Private Function realize_col(ByVal strQ As String) As Integer
        Return object_cmd.getOleDbCommand(strQ)
    End Function

    Private Function fillcombo(ByVal strQ As String)

        sVariables.sOleDbDataReader = object_cmd.setOledbCommandReader(strQ)
        Do While sVariables.sOleDbDataReader.Read()
            ComboBox1.Items.Add(sVariables.sOleDbDataReader(0))
            ComboBox2.Items.Add(sVariables.sOleDbDataReader(0))
        Loop

        Return ""
    End Function
    Private Function set_col(ByVal strQ As String)
        Dim i, j As Integer
        Dim arr_matrix() As String
        Dim temp_str As String = ""
        Dim first_index As Integer = 0

        sVariables.sOleDbDataReader = object_cmd.setOledbCommandReader(strQ)

        'first method{
        'Do While sVariables.sOleDbDataReader.Read()
        '    temp_str = sVariables.sOleDbDataReader(1)

        '    first_index = temp_str.IndexOf(".")
        '    i = temp_str.Substring(0, first_index)

        '    first_index += 1
        '    j = temp_str.Substring(first_index)
        '    tbl.Item(j, i).Value = sVariables.sOleDbDataReader(2)
        '    first_index = 0

        'Loop}

        'second method{

        Do While sVariables.sOleDbDataReader.Read()
            temp_str = sVariables.sOleDbDataReader(1)

            arr_matrix = temp_str.Split(".")
            i = arr_matrix(0)
            j = arr_matrix(1)
            tbl1.Item(j, i).Value = sVariables.sOleDbDataReader(2)
        Loop
        '}

        Return ""
    End Function
    Private Function sort_list()

        ' Set the ListViewItemSorter property to a new ListViewItemComparer
        ' object.
        ' Determine whether the column is the same as the last column clicked.

        If 0 <> sortColumn Then
            ' Set the sort column to the new column.
            sortColumn = 1
            ' Set the sort order to ascending by default.
            ListView1.Sorting = SortOrder.Ascending
        Else
            ' Determine what the last sort order was and change it.
            If ListView1.Sorting = SortOrder.Ascending Then
                ListView1.Sorting = SortOrder.Descending
            Else
                ListView1.Sorting = SortOrder.Ascending
            End If
        End If
        ' Call the sort method to manually sort.
        ListView1.Sort()
        ' Set the ListViewItemSorter property to a new ListViewItemComparer
        ' object.

        ListView1.ListViewItemSorter = New ListViewItemComparer(1, ListView1.Sorting)

        Return ""
    End Function
    Private Function draw_chart(ByVal listview As ListView, ByRef barchart As BarChart.HBarChart)
        Dim i As Integer = 0
        Dim lvw As ListViewItem

        For Each lvw In listview.Items
            barchart.Items.Add(New BarChart.HBarItem(Convert.ToDouble(lvw.SubItems(1).Text), lvw.SubItems(0).Text, Color.FromArgb(255, 190, 200, 255)))
            barchart.AutoScroll = True

            barchart.SizingMode = Global.BarChart.HBarChart.BarSizingMode.AutoScale
            barchart.Enabled = False
            barchart.RedrawChart()

        Next

        barchart.BarTooltip.Active = True


        '        barChart.BarWidth = trackBarWidthBar.Value;
        'barChart.RedrawChart();

        'StringBuilder sb = new StringBuilder();
        'sb.AppendFormat("Bar Width({0})", trackBarWidthBar.Value.ToString());

        'labelBarWidthValue.Text = sb.ToString();

        'barchart.AutoScroll = True

        Return ""
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim strsql As String
        strsql = "select count(*) from tbl_issue where issue='" & ComboBox1.Text & "'"

        If object_cmd.getOleDbCommand(strsql) <> 0 Then
            MsgBox("enghablan sabt shodeh")
        End If

    End Sub

    Private Sub tbl_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles tbl1.CellValueChanged
        If e.RowIndex = 0 Then
            tbl1.Item(e.RowIndex, e.ColumnIndex).Value = tbl1.Item(e.ColumnIndex, e.RowIndex).Value
            tbl1.Item(e.RowIndex, e.ColumnIndex).Style.BackColor = Color.PaleTurquoise

        ElseIf e.RowIndex <> 0 AndAlso e.ColumnIndex <> 0 AndAlso e.RowIndex >= e.ColumnIndex Then
            If tbl1.Item(e.ColumnIndex, e.RowIndex).Value = "1" Then
                tbl1.Item(e.RowIndex, e.ColumnIndex).Value = "0"
            ElseIf tbl1.Item(e.ColumnIndex, e.RowIndex).Value = "0" Then
                tbl1.Item(e.RowIndex, e.ColumnIndex).Value = "1"
                'Else
                '    'MsgBox("Errorrrrrr!!!!!!!!!! in cell's value... please inter the 0 or 1 value in this cell then press tab key.")
                '    Exit Sub
            End If



        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'If count_hal_giri() <= 1500 Then
        If ComboBox1.Text = "" Then
            MessageBox.Show("لطفا ابتدا مورد مقایسه را از لیست نام جدول انتخاب کنید  ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim i, j As Integer
        Dim strQ As String = ""
        prg.Minimum = 0
        prg.Maximum = (tbl1.RowCount * tbl1.RowCount)

        prg.Value = 0

        strQ = "Delete from tbl_issue where issue='" & ComboBox1.Text & "'"
        object_cmd.setOleDbCommand(strQ)

        For i = 0 To tbl1.RowCount - 1
            For j = 0 To tbl1.ColumnCount - 1
                prg.Value += 1
                strQ = "insert into tbl_issue(issue,element_mat,value_mat,code_academy) values('" & ComboBox1.Text.Trim & "' , '" & i & "." & j & "','" & tbl1.Item(j, i).Value & "','" & IntCodeAcademy & "')"
                object_cmd.setOleDbCommand(strQ)
            Next
        Next
        MsgBox("جدول بدرستی ثبت شد")
        'Else
        '    MsgBox("این نرم افزار نسخه آزمایشی می باشد و امکان ذخیره کردن بیش از 1500 رکورد بیشتر در آن نمی باشد. در صورت تمایل به داشتن این نرم افزار با شماره 09188572877 تماس نمایید")
        'End If

    End Sub

    Private Sub frm_add_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        IntCodeAcademy = object_cmd.getOleDbCommand("select code_academy from tblAcademy")
        fillcombo("select distinct issue from tbl_first")
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim i, j, count As Integer

        count = object_cmd.getOleDbCommand("select count(*) from tbl_first where issue ='" & ComboBox1.SelectedItem & "'")
        tbl1.RowCount = count
        tbl1.ColumnCount = count
        For i = 0 To tbl1.RowCount - 1
            For j = 0 To tbl1.ColumnCount - 1
                tbl1.Item(j, i).Value = ""
            Next
        Next

        sVariables.sOleDbDataReader = object_cmd.setOledbCommandReader("select case_compersion from tbl_first where issue ='" & ComboBox1.SelectedItem & "'" & " order by row asc")

        j = 0
        Do While sVariables.sOleDbDataReader.Read()
            tbl1.Item(j, 0).Value = sVariables.sOleDbDataReader(0)
            tbl1.Item(j, 0).Style.BackColor = Color.PaleTurquoise
            tbl1.Item(j, 0).ReadOnly = True
            tbl1.Item(0, j).ReadOnly = True
            j += 1
        Loop

        tbl1.Item(0, 0).Value = "موارد مقايسه"

        For i = 1 To tbl1.RowCount - 1
            For j = i To 1 Step -1
                tbl1.Item(j, i).Value = "x"
                tbl1.Item(j, i).ReadOnly = True
                tbl1.Item(j, i).Style.BackColor = Color.AntiqueWhite
            Next
        Next

        If realize_col("select count(*) from tbl_issue where issue = '" & ComboBox1.Text & "'") <> 0 Then
            set_col("select * from tbl_issue where issue = '" & ComboBox1.Text & "'")
        End If

        tbl1.Focus()

    End Sub

    Private Sub tbl_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles tbl1.CellClick
        If e.RowIndex <> 0 AndAlso e.ColumnIndex <> 0 AndAlso tbl1.Item(e.ColumnIndex, e.RowIndex).Value <> "x" Then
            Dim frm As New Form2
            frm.RadioButton1.Text = tbl1.Item(0, e.RowIndex).Value
            frm.RadioButton2.Text = tbl1.Item(e.ColumnIndex, 0).Value
            frm.set_form(Me, e.RowIndex, e.ColumnIndex)
            frm.ShowDialog()
        End If

    End Sub

    Private Sub tbl_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles tbl1.CellContentClick

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim k As Integer = 0
        Dim strmin As String = ""
        Dim strmax As String = ""
        Dim intmin, intmax As Integer
        Dim sum As Integer = 0
        intmin = 1000
        intmax = 0

        Dim lvw As ListViewItem

        For Each lvw In ListView1.Items
            sum += lvw.SubItems(1).Text
            If CInt(lvw.SubItems(1).Text) > intmax Then
                intmax = lvw.SubItems(1).Text
                strmax = lvw.SubItems(0).Text
            ElseIf CInt(lvw.SubItems(1).Text) = intmax Then
                intmax = lvw.SubItems(1).Text
                strmax += "     " + lvw.SubItems(0).Text & "   "
            End If
            If CInt(lvw.SubItems(1).Text) < intmin Then
                intmin = lvw.SubItems(1).Text
                strmin = lvw.SubItems(0).Text
            ElseIf CInt(lvw.SubItems(1).Text) = intmin Then
                intmin = lvw.SubItems(1).Text
                strmin += "    " + lvw.SubItems(0).Text & "    "
            End If
        Next

        Label11.Text = sum
        Label7.Text = strmax

        TextBox2.Text = intmax
        Label8.Text = strmin

        TextBox1.Text = intmin
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i As Integer = 0
        Dim lvw As ListViewItem

        For Each lvw In ListView1.Items
            HBarChart1.Items.Add(New BarChart.HBarItem(Convert.ToDouble(lvw.SubItems(1).Text), lvw.SubItems(0).Text, Color.FromArgb(255, 190, 200, 255)))
            HBarChart1.RedrawChart()
        Next
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim number_col, i, count_value_mat As Integer
        Dim value_mat As String

        Me.ListView1.Items.Clear()

        number_col = realize_col("select count(*) from tbl_issue where issue = '" & ComboBox2.Text & "'")
        number_col = Math.Sqrt(number_col)
        For i = 1 To number_col - 1
            value_mat = object_cmd.getOleDbCommand2("SELECT value_mat FROM tbl_issue WHERE issue='" & ComboBox2.Text & "'" & " And element_mat='" & 0 & "." & i & "'")
            count_value_mat = object_cmd.getOleDbCommand("SELECT count(*) FROM tbl_issue WHERE issue='" & ComboBox2.Text & "'" & " And value_mat='" & value_mat & "'")
            count_value_mat = count_value_mat - 2
            filllistview(ListView1, value_mat, count_value_mat)

        Next
        HBarChart1.Items.Clear()
        draw_chart(ListView1, HBarChart1)
        Button4.PerformClick()


    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim number_col, i, count_value_mat As Integer
        Dim value_mat, strQ As String

        strQ = "Delete from temprep"
        object_cmd.setOleDbCommand(strQ)

        Me.ListView2.Items.Clear()

        'no no no. is compulsory
        Dim sqldbcon As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\mdb.mdb" + ";Persist Security Info=False;")
        Dim dr As OleDbDataReader

        ' ComboBox1.Items.Clear()

        sqldbcon.Open()
        Dim sqlcommand As New OleDbCommand

        sqlcommand.CommandText = "select distinct issue from tbl_first"
        sqlcommand.Connection = sqldbcon

        dr = sqlcommand.ExecuteReader

        'end compulsory

        Do While dr.Read
            'Me.ListView2.Items.Clear()

            'sVariables.sOleDbDataReader = object_cmd.setOledbCommandReader("select distinct issue from tbl_first")

            'Do While sVariables.sOleDbDataReader.Read()
            'value_reader = sVariables.sOleDbDataReader(0)

            number_col = realize_col("select count(*) from tbl_issue where issue = '" & dr(0) & "'")
            number_col = Math.Sqrt(number_col)
            For i = 1 To number_col - 1
                value_mat = object_cmd.getOleDbCommand2("SELECT value_mat FROM tbl_issue WHERE issue='" & dr(0) & "'" & " And element_mat='" & 0 & "." & i & "'")
                count_value_mat = object_cmd.getOleDbCommand("SELECT count(*) FROM tbl_issue WHERE issue='" & dr(0) & "'" & " And value_mat='" & value_mat & "'")
                count_value_mat = count_value_mat - 2
                filllistview2(ListView2, dr(0), value_mat, count_value_mat)
                strQ = "insert into temprep(issue,value_mat,count_value_mat) values('" & dr(0) & "' , '" & value_mat & "','" & count_value_mat.ToString & "')"
                object_cmd.setOleDbCommand(strQ)
            Next
        Loop

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub


    Private Sub TabPage4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage4.Click

    End Sub


    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        Dim frm As New Form5
        frm.Show()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim number_col, i, count_value_mat As Integer
        Dim value_mat As String

        Me.ListView3.Items.Clear()

        sVariables.sOleDbDataReader = object_cmd.setOledbCommandReader("select value_mat,sum(count_value_mat) from temprep group by value_mat order by sum(count_value_mat) desc")
        Do While sVariables.sOleDbDataReader.Read()
            filllistview(ListView3, sVariables.sOleDbDataReader(0), sVariables.sOleDbDataReader(1))
        Loop
        HBarChart2.Items.Clear()
        draw_chart(ListView3, HBarChart2)
    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

        Dim frm As New Form6
        frm.Show()
    End Sub

    Private Sub HBarChart1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HBarChart1.Load

    End Sub
End Class