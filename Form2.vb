Public Class Form2

    Private Shared frm_shared As frm_add
    Private row_shared As Integer
    Private col_shared As Integer

    Public Function set_form(ByRef frm As frm_add, ByVal row As Integer, ByVal col As Integer)

        frm_shared = frm
        row_shared = row
        col_shared = col

        Return ""
    End Function

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        TextBox1.Text = RadioButton1.Text
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        TextBox1.Text = RadioButton2.Text
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frm_shared.tbl1.Item(col_shared, row_shared).Value = TextBox1.Text
        Me.Close()

    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class