Public Class Form4
    Private object_cmd As New clsCommands
    Private sVariables As New clsVariables
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
    Public Function filllistview(ByVal Sqlstring As String)

        Me.ListView1.Items.Clear()
        'Me.ListView1.Sorting = SortOrder.Ascending

        Try
            sVariables.sOleDbDataReader = object_cmd.setOledbCommandReader(Sqlstring)

            Do While sVariables.sOleDbDataReader.Read()
                Dim strsearchrow As String() = {sVariables.sOleDbDataReader(0), sVariables.sOleDbDataReader(1), sVariables.sOleDbDataReader(2), sVariables.sOleDbDataReader(3), sVariables.sOleDbDataReader(4)}
                Me.ListView1.Items.Add(New ListViewItem(strsearchrow))
            Loop

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally

        End Try

        Return ""
    End Function
    Public Function FillTextBox(ByVal Sqlstring As String)

        Try
            sVariables.sOleDbDataReader = object_cmd.setOledbCommandReader(Sqlstring)

            Do While sVariables.sOleDbDataReader.Read()
                Dim strsearchrow As String() = {sVariables.sOleDbDataReader(0), sVariables.sOleDbDataReader(1), sVariables.sOleDbDataReader(2), sVariables.sOleDbDataReader(3), sVariables.sOleDbDataReader(4)}
                Me.MaskedTextBox1.Text = strsearchrow(0)
                Me.TextBox1.Text = strsearchrow(1)
                Me.TextBox2.Text = strsearchrow(2)
                Me.TextBox3.Text = strsearchrow(3)
                Me.TextBox4.Text = strsearchrow(4)

                '   Me.MaskedTextBox1.Enabled = False

            Loop

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        Return ""
    End Function
    Private Function clear()
        Dim ctrl As Control

        For Each ctrl In Me.Controls
            If (TypeOf ctrl Is TextBox) Then
                ctrl.Text = ""
                Me.MaskedTextBox1.Clear()
            End If
        Next


        Return ""
    End Function

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        filllistview("select * from tblAcademy")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyDown
        Dim i As Integer = 0
        Dim strQ As String = ""
        Dim strIssue As String = ""
        If e.KeyCode = Keys.Enter Then
            filllistview("select * from tblAcademy")

            Try
                If CountListViewItems(ListView1) < 1 Then
                    strQ = "insert into tblAcademy(code_academy,province,region,academy,name_family_director) values('" & MaskedTextBox1.Text & "' , '" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "')"
                    object_cmd.setOleDbCommand(strQ)
                    filllistview("select * from tblAcademy")
                    clear()
                    MsgBox("جدول بدرستی ثبت شد")
                Else
                    MessageBox.Show("شما تنها می توانید مشخصات یک مدرسه را ثبت کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MsgBox("این موضوع قبلا ثبت شده است.")
            End Try
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ListView1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.Click
        Dim intcode As Integer = Me.ListView1.SelectedItems(0).SubItems(0).Text
        Dim SqlStr As String = ""
        SqlStr = "select * from tblAcademy where code_academy = " & intcode
        FillTextBox(SqlStr)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim i As Integer = 0
        Dim strQ As String = ""
        Dim strIssue As String = ""

        filllistview("select * from tblAcademy")

        Try
            If CountListViewItems(ListView1) < 1 Then
                strQ = "insert into tblAcademy(code_academy,province,region,academy,name_family_director) values('" & MaskedTextBox1.Text & "' , '" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "')"
                object_cmd.setOleDbCommand(strQ)
                filllistview("select * from tblAcademy")
                clear()
                MsgBox("جدول بدرستی ثبت شد")
            Else
                MessageBox.Show("شما تنها می توانید مشخصات یک مدرسه را ثبت کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox("این موضوع قبلا ثبت شده است.")
        End Try
        '  TextBox2.Enabled = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Me.MaskedTextBox1.Text <> "" And Me.TextBox1.Text <> "" And Me.TextBox2.Text <> "" And Me.TextBox3.Text <> "" And Me.TextBox4.Text <> "" Then
            Try
                Dim strQ As String = ""

                strQ = "Update tblAcademy Set " _
                & "code_academy='" & Me.MaskedTextBox1.Text.ToString & "', " _
                & "province='" & TextBox1.Text.ToString & "', " _
                & "region='" & TextBox2.Text.ToString & "', " _
                & "academy='" & TextBox3.Text.ToString & "', " _
                & "name_family_director='" & TextBox4.Text.ToString & "' " _
                & "WHERE code_academy = " & Me.ListView1.SelectedItems(0).SubItems(0).Text

                object_cmd.setOleDbCommand(strQ)

                strQ = "Update tbl_first Set " _
                & "code_academy='" & Me.MaskedTextBox1.Text.ToString & "'  "
                '         & "WHERE code_academy = " & Me.ListView1.SelectedItems(0).SubItems(0).Text

                object_cmd.setOleDbCommand(strQ)

                'Me.MaskedTextBox1.Enabled = True

                clear()

            Catch ex As Exception
                MessageBox.Show("لطفا ابتدا عنصر اول لیست را انتخاب کنید" & vbCrLf & ex.Message)
                Exit Sub
            End Try

            MsgBox("اطلاعات به درستی ذخیره شد")
            filllistview("select * from tblAcademy")
        Else
            MessageBox.Show("لطفا ابتدا تمام اطلاعات را وارد کنيد سپس روي دکمه ذخيره کليک کنيد")
        End If
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub MaskedTextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.TextBox1.Focus()
        End If
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.TextBox2.Focus()
        End If
    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.TextBox3.Focus()
        End If
    End Sub

    Private Sub TextBox3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.TextBox4.Focus()
        End If
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub
End Class