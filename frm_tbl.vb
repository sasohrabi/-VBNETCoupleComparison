Public Class frm_tbl
    Private object_cmd As New clsCommands
    Private sVariables As New clsVariables

    Private Function realize_col(ByVal strQ As String) As Integer
        Return object_cmd.getOleDbCommand(strQ)
    End Function
    Private Function set_col(ByVal strQ As String, ByVal End_index As Integer)
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
            tbl.Item(j, i).Value = sVariables.sOleDbDataReader(2)
        Loop
        '}

        Return ""
    End Function
    Private Function fillcombo(ByVal strQ As String)

        sVariables.sOleDbDataReader = object_cmd.setOledbCommandReader(strQ)
        Do While sVariables.sOleDbDataReader.Read()
            txtissue.Items.Add(sVariables.sOleDbDataReader(0))
        Loop

        Return ""
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim number_col As Integer = 0

        number_col = realize_col("select count(*) from tbl_issue where issue = '" & txtissue.Text & "'")


        tbl.RowCount = Math.Sqrt(number_col)
        tbl.ColumnCount = Math.Sqrt(number_col)


        set_col("select * from tbl_issue where issue = '" & txtissue.Text & "'", Math.Sqrt(number_col))

    End Sub

    Private Sub tbl_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles tbl.CellClick
        'MsgBox(e.ColumnInd)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim i, j As Integer
        Dim iDOTj As String = ""
        Dim strQ As String = ""

        For i = 0 To tbl.RowCount - 1
            For j = 0 To tbl.ColumnCount - 1
                iDOTj = i & "." & j
                strQ = "Update tbl_issue Set " _
                        & "issue='" & tbl.Item(0, 0).Value & "', " _
                        & "element_mat='" & i & "." & j & "', " _
                        & "value_mat='" & tbl.Item(j, i).Value & "' " _
                        & " WHERE issue = '" & tbl.Item(0, 0).Value & "'" & " and element_mat='" & iDOTj & "'"
                object_cmd.setOleDbCommand(strQ)
            Next
        Next
        MsgBox("تغییرات بدرستی ثبت شد")

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtissue.SelectedIndexChanged

    End Sub

    Private Sub frm_tbl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillcombo("select distinct issue from tbl_first")
    End Sub

    Private Sub tbl_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles tbl.CellContentClick

    End Sub
End Class
