Imports System.Data.OleDb

Public Class Form1

    Private object_cmd As New clsCommands
    Private sVariables As New clsVariables

    Private IntCodeAcademy As Integer

    Public Function filllistview(ByVal Sqlstring As String)

        Me.ListView1.Items.Clear()
        'Me.ListView1.Sorting = SortOrder.Ascending

        Try
            sVariables.sOleDbDataReader = object_cmd.setOledbCommandReader(Sqlstring)

            Do While sVariables.sOleDbDataReader.Read()
                Dim strsearchrow As String() = {sVariables.sOleDbDataReader(1), sVariables.sOleDbDataReader(2)}
                Me.ListView1.Items.Add(New ListViewItem(strsearchrow))
            Loop

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally

        End Try

        Return ""
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
    Private Function fillcombo(ByVal strQ As String)

        ComboBox1.Text = ""
        ComboBox1.Items.Clear()

        sVariables.sOleDbDataReader = object_cmd.setOledbCommandReader(strQ)
        Do While sVariables.sOleDbDataReader.Read()
            ComboBox1.Items.Add(sVariables.sOleDbDataReader(0))
        Loop

        Return ""
    End Function
    Private Function check_reapet(ByVal strQ As String) As Integer
        Return object_cmd.getOleDbCommand(strQ)
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        IntCodeAcademy = object_cmd.getOleDbCommand("select code_academy from tblAcademy")
        ComboBox2.SelectedIndex = 1
        ' MsgBox(IntCodeAcademy)
        'fillcombo("select distinct issue from tbl_first")
    End Sub

    Private Sub TextBox3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyDown
    
    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        Dim i As Integer = 0
        Dim count As Integer = 0
        Dim strQ As String = ""
        Dim strIssue As String = ""

        If e.KeyCode = Keys.Enter Then
            If Me.TextBox2.Text <> "" Then
                If ComboBox2.SelectedIndex = 0 Then
                    strIssue = TextBox2.Text
                ElseIf ComboBox2.SelectedIndex = 1 Then
                    strIssue = ComboBox1.Text
                Else
                    MessageBox.Show("کاربر گرامی ابتدا از لیست بالا عنصری را انتخاب کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                filllistview("select * from tbl_first where issue = '" & strIssue & "'" & " order by row asc")
                count = CountListViewItems(ListView1)

                If count = 0 Then
                    strQ = "insert into tbl_first(issue,row,case_compersion,code_academy) values('" & strIssue & "' , '" & count & "','" & strIssue & "', '" & IntCodeAcademy & "')"
                    object_cmd.setOleDbCommand(strQ)
                    filllistview("select * from tbl_first where issue = '" & strIssue & "'" & " order by row asc")
                    MsgBox("جدول بدرستی ثبت شد")
                ElseIf count > 0 Then
                    MessageBox.Show("این موضوع قبلا برای مقایسه ثبت شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                '  TextBox2.Enabled = False
                MaskedTextBox2.Focus()
            ElseIf TextBox2.Text = "" Then
                MsgBox("موضوع مقايسه خالی بوده لذا امکان ثبت مورد جديد نمی باشد ")
            End If
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.SelectedIndex = 0 Then
            TextBox2.Visible = True
            ComboBox1.Visible = False
            TextBox2.Text = ""
            TextBox2.Focus()

        ElseIf ComboBox2.SelectedIndex = 1 Then
            ComboBox1.Items.Clear()
            fillcombo("select distinct issue from tbl_first")
            ComboBox1.Visible = True
            TextBox2.Visible = False
            ComboBox1.Focus()
            ComboBox1.TabIndex = 0
        End If
    End Sub

    Private Sub ComboBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyDown

        Dim i As Integer = 0
        Dim count As Integer = 0
        Dim strQ As String = ""
        Dim strIssue As String = ""



        If e.KeyCode = Keys.Enter Then
            If Me.ComboBox1.Text <> "" Then
                If ComboBox2.SelectedIndex = 0 Then
                    strIssue = TextBox2.Text
                ElseIf ComboBox2.SelectedIndex = 1 Then
                    strIssue = ComboBox1.Text
                Else
                    MessageBox.Show("کاربر گرامی ابتدا از لیست بالا عنصری را انتخاب کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                filllistview("select * from tbl_first where issue = '" & strIssue & "'" & " order by row asc")
                count = CountListViewItems(ListView1)

                If count = 0 Then
                    strQ = "insert into tbl_first(issue,row,case_compersion,code_academy) values('" & strIssue & "' , '" & count & "','" & strIssue & "', '" & IntCodeAcademy & "')"
                    object_cmd.setOleDbCommand(strQ)
                    filllistview("select * from tbl_first where issue = '" & strIssue & "'" & " order by row asc")
                    MsgBox("جدول بدرستی ثبت شد")
                ElseIf count > 0 Then
                    MessageBox.Show("این موضوع قبلا برای مقایسه ثبت شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                '  TextBox2.Enabled = False
                TextBox3.Focus()
            ElseIf ComboBox1.Text = "" Then
                MsgBox("موضوع مقايسه خالی بوده لذا امکان ثبت مورد جديد نمی باشد ")
            End If
        End If



        'Dim i As Integer = 0
        'Dim count As Integer = 0
        'Dim strQ As String = ""

        'If e.KeyCode = Keys.Enter Then
        '    filllistview("select * from tbl_first where issue = '" & ComboBox1.Text & "'")
        '    count = CountListViewItems(ListView1)

        '    If count = 0 Then
        '        strQ = "insert into tbl_first(issue,row,case_compersion) values('" & TextBox2.Text & "' , '" & count & "','" & TextBox2.Text & "')"
        '        object_cmd.setOleDbCommand(strQ)
        '        filllistview("select * from tbl_first where issue = '" & ComboBox1.Text & "'")
        '        MsgBox("جدول بدرستی ثبت شد")
        '    ElseIf count > 0 Then
        '        MsgBox("این موضوع قبلا ثبت شده است.")
        '    End If

        '    ' TextBox2.Enabled = False
        '    TextBox3.Focus()
        'End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New frm_add
        frm.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim strIssue As String = ""
        If ComboBox2.SelectedIndex = 0 Then
            strIssue = TextBox2.Text
        ElseIf ComboBox2.SelectedIndex = 1 Then
            strIssue = ComboBox1.Text
        Else
            MessageBox.Show("کاربر گرامی ابتدا از لیست بالا عنصری را انتخاب کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        filllistview("select * from tbl_first where issue = '" & strIssue & "'" & " order by row asc")
        Me.MaskedTextBox2.Focus()
    End Sub

    Private Sub ComboBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.Click

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MessageBox.Show("ایا مایل به ادامه عملیات حذف هستید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            Dim strQ As String = ""
            Dim strIssue As String = ""

            If ComboBox2.SelectedIndex = 0 Then
                strIssue = TextBox2.Text
            ElseIf ComboBox2.SelectedIndex = 1 Then
                strIssue = ComboBox1.Text
            Else
                MessageBox.Show("کاربر گرامی ابتدا از لیست بالا عنصری را انتخاب کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Try
                If Me.ListView1.SelectedItems(0).SubItems(1).Text = ListView1.Items(0).SubItems(1).Text Then
                    MessageBox.Show("شما نمی توانید اولین عنصر لیست را حذف کنید چون نام موضوع مقایسه می باشد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                Else
                    If check_reapet("select count(*) from tbl_issue where issue='" & ListView1.Items(0).SubItems(1).Text & "'") <> 0 Then

                        If MessageBox.Show("این موضوع قبلا در جدول مقایسه زوجی ثبت شده و با حذف این مورد کل جداول در جدول مقایسه زوجی حذف می شود", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then

                            strQ = "Delete from tbl_first " _
                                    & " WHERE  case_compersion='" & Me.ListView1.SelectedItems(0).SubItems(1).Text & "'"
                            object_cmd.setOleDbCommand(strQ)
                            strQ = "Delete from tbl_issue"
                            object_cmd.setOleDbCommand(strQ)
                            MessageBox.Show("اطلاعات رکورد انتخابی بدرستی در این جدول و جدول مقایسه زوجی حذف شد", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            filllistview("select * from tbl_first where issue = '" & strIssue & "'" & " order by row asc")
                        Else
                            Exit Sub
                        End If

                    Else
                        strQ = "Delete from tbl_first " _
                                & " WHERE case_compersion='" & Me.ListView1.SelectedItems(0).SubItems(1).Text & "'"
                        object_cmd.setOleDbCommand(strQ)
                        MessageBox.Show("اطلاعات رکورد انتخابی بدرستی در این جدول حذف شد", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        filllistview("select * from tbl_first where issue = '" & strIssue & "'" & " order by row asc")
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(" لطفا ابتدا بر روی ردیف مورد نظر در لیست کلیک کنید و سپس بر روی دکمه کلیک کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MessageBox.Show("ایا مایل به ادامه عملیات حذف کل موضوع جاری هستید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            Dim strQ As String = ""
            Dim strIssue As String = ""
            If ComboBox2.SelectedIndex = 0 Then
                strIssue = TextBox2.Text
            ElseIf ComboBox2.SelectedIndex = 1 Then
                strIssue = ComboBox1.Text
            Else
                MessageBox.Show("کاربر گرامی ابتدا از لیست بالا عنصری را انتخاب کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            strQ = "Delete from tbl_first " _
                    & " WHERE issue = '" & ListView1.Items(0).SubItems(1).Text & "'"
            object_cmd.setOleDbCommand(strQ)
            strQ = "Delete from tbl_issue " _
            & " WHERE issue = '" & ListView1.Items(0).SubItems(1).Text & "'"

            object_cmd.setOleDbCommand(strQ)
            MessageBox.Show("اطلاعات رکورد انتخابی بدرستی در این جدول و جدول مقایسه زوجی حذف شد", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information)
            filllistview("select * from tbl_first where issue = '" & strIssue & "'" & " order by row asc")
            fillcombo("select distinct issue from tbl_first")
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim i As Integer = 0
        Dim count As Integer = 0
        Dim strQ As String = ""
        Dim strIssue As String = ""
        Dim strInput As String = ""


        Try
            If ComboBox2.SelectedIndex = 0 Then
                strIssue = TextBox2.Text
            ElseIf ComboBox2.SelectedIndex = 1 Then
                strIssue = ComboBox1.Text
            Else
                MessageBox.Show("کاربر گرامی ابتدا از لیست بالا عنصری را انتخاب کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If Me.ListView1.SelectedItems(0).SubItems(1).Text = ListView1.Items(0).SubItems(1).Text Then
                strInput = InputBox("مقدار جدید را وارد کنید", "فرم تغییر").Trim
                If strInput <> "" Then
                    If check_reapet("select count(*) from tbl_first where issue ='" & strIssue & _
                    "'" & " and case_compersion = '" & strInput & "'") <> 0 Then
                        MessageBox.Show("این مورد قبلا برای مقایسه ثبت شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Else
                    MessageBox.Show(" مقدار جدید وارد نشده است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                strQ = "Update tbl_first Set " _
                       & "issue='" & strInput & "' " _
                       & " WHERE issue='" & Me.ListView1.SelectedItems(0).SubItems(1).Text & "'"
                object_cmd.setOleDbCommand(strQ)
                strQ = "Update tbl_first Set " _
                     & "case_compersion='" & strInput & "' " _
                     & " WHERE issue='" & strInput & "'" & " and case_compersion='" & ListView1.Items(0).SubItems(1).Text & "'"
            Else
                strInput = InputBox("مقدار جدید را وارد کنید", "لطفا").Trim
                If strInput <> "" Then
                    If check_reapet("select count(*) from tbl_first where issue ='" & strIssue & _
                    "'" & " and case_compersion = '" & strInput & "'") <> 0 Then
                        MessageBox.Show("این مورد قبلا برای مقایسه ثبت شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Else
                    MessageBox.Show(" مقدار جدید وارد نشده است ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                strQ = "Update tbl_first Set " _
                       & "case_compersion='" & strInput & "' " _
                       & " WHERE case_compersion='" & Me.ListView1.SelectedItems(0).SubItems(1).Text & "'"
            End If
            object_cmd.setOleDbCommand(strQ)
            strQ = "Update tbl_issue Set " _
                 & "value_mat='" & strInput & "' " _
                 & " WHERE value_mat='" & Me.ListView1.SelectedItems(0).SubItems(1).Text & "'"
            object_cmd.setOleDbCommand(strQ)
            MessageBox.Show("اطلاعات رکورد انتخابی بدرستی در این جدول و جدول مقایسه زوجی تغییر کرد", "تغییر", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If Me.ListView1.SelectedItems(0).SubItems(1).Text = ListView1.Items(0).SubItems(1).Text Then
                filllistview("select * from tbl_first where issue = '" & strInput & "'" & " order by row asc")
            Else
                filllistview("select * from tbl_first where issue = '" & strIssue & "'" & " order by row asc")
            End If

            fillcombo("select distinct issue from tbl_first")
        Catch
            MessageBox.Show(" لطفا ابتدا بر روی ردیف مورد نظر در لیست کلیک کنید و سپس بر روی دکمه کلیک کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Sub MaskedTextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox2.KeyDown
        Try
            Dim strIssue As String = ""

            If e.KeyCode = Keys.Enter Then

                If ComboBox2.SelectedIndex = 0 Then
                    strIssue = TextBox2.Text
                ElseIf ComboBox2.SelectedIndex = 1 Then
                    strIssue = ComboBox1.Text
                Else
                    MessageBox.Show("کاربر گرامی ابتدا از لیست بالا عنصری را انتخاب کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                If Me.MaskedTextBox2.Text = "" Then
                    MessageBox.Show("کاربر گرامی ابتدا شماره پرسنلی را وارد کنید  ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                If check_reapet("select count(*) from tbl_first where issue ='" & strIssue & _
                    "'" & " and codeP = " & MaskedTextBox2.Text) = 0 Then

                    If ComboBox2.SelectedIndex = 0 Then
                        strIssue = TextBox2.Text
                    ElseIf ComboBox2.SelectedIndex = 1 Then
                        strIssue = ComboBox1.Text
                    Else
                        MessageBox.Show("کاربر گرامی ابتدا از لیست بالا عنصری را انتخاب کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    If strIssue = "" Then
                        MessageBox.Show("لطفا موضوع را وارد کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    Else
                        TextBox3.Text = object_cmd.getOleDbCommand2("select namefamili from master where codeP=" & Me.MaskedTextBox2.Text)
                        If TextBox3.Text = "" Then
                            MessageBox.Show("کد پرسنلی نا معتبر می باشد لطفا دوباره آنرا وارد کنید و اگر پرسنل جدید می باشد از طریق فرم ثبت پرسنل اقدام به ثبت مشخصات آن نمایید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                    End If

                    '     TextBox2.Enabled = False
                    Dim strQ As String = ""
                    Dim count As Integer = 0
                    count = CountListViewItems(ListView1)

                    If count > 0 Then

                        'no no no. is compulsory
                        Dim sqldbcon As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\mdb.mdb" + ";Persist Security Info=False;")
                        Dim dr As OleDbDataReader

                        sqldbcon.Open()
                        Dim sqlcommand As New OleDbCommand


                        sqlcommand.CommandText = "select distinct issue from tbl_first where issue <> '" & strIssue & "'"
                        sqlcommand.Connection = sqldbcon

                        dr = sqlcommand.ExecuteReader

                        'end compulsory

                        Do While dr.Read()
                            strQ = "insert into tbl_first(issue,row,case_compersion,code_academy,codeP) values('" & dr(0) & "' , '" & count & "', '" & TextBox3.Text & "', '" & IntCodeAcademy & "','" & MaskedTextBox2.Text & "')"
                            object_cmd.setOleDbCommand(strQ)
                        Loop
                        strQ = "insert into tbl_first(issue,row,case_compersion,code_academy,codeP) values('" & strIssue & "' , '" & count & "','" & TextBox3.Text & "', '" & IntCodeAcademy & "','" & MaskedTextBox2.Text & "')"
                        object_cmd.setOleDbCommand(strQ)
                        MsgBox("جدول بدرستی ثبت شد")
                    Else
                        MsgBox("معتبر نیست" & count & "شماره")
                        Exit Sub
                    End If


                    filllistview("select * from tbl_first where issue = '" & strIssue & "'" & " order by row asc")


                    TextBox3.Clear()

                    Me.MaskedTextBox2.Clear()



                ElseIf TextBox3.Text = "" Then
                    MessageBox.Show("مورد مقايسه قبلا ثبت گردیده است لذا امکان ثبت مورد جديد نمی باشد ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("این مورد قبلا برای مقایسه ثبت شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If
        Catch ex As Exception
            MessageBox.Show("مشکلی در ثبت اطلاعات بوجود آمده که احتمالا داده ی ورودی معتبر نمی باشد" & vbCrLf & ex.Message, "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MaskedTextBox2.Clear()
        End Try

    End Sub
End Class