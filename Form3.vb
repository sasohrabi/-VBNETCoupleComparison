Public Class Form3

    Private object_cmd As New clsCommands
    Private sVariables As New clsVariables
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim i As Integer = 0
        Dim strQ As String = ""
        Dim strIssue As String = ""

        If Me.MaskedTextBox1.Text <> "" AndAlso Me.TextBox1.Text <> "" Then
            If Me.MaskedTextBox1.Text.Length = 8 Then
                Try
                    strQ = "insert into master(codeP,namefamili) values('" & MaskedTextBox1.Text & "' , '" & TextBox1.Text & "')"
                    object_cmd.setOleDbCommand(strQ)
                    MsgBox("جدول بدرستی ثبت شد")
                    Me.MaskedTextBox1.Clear()
                    Me.TextBox1.Text = ""
                    Me.MaskedTextBox1.Focus()
                Catch ex As Exception
                    MessageBox.Show("اطلاعات این معلم قبلا ثبت شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                MessageBox.Show(" طول فیلد شماره پرسنلی باید 8 رقم باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Else
            MessageBox.Show(" لطفا ابتدا اطلاعات را وارد کنید سپس بر روی دکمه پبت کلیک کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


        '  TextBox2.Enabled = False
    End Sub

    Private Sub MaskedTextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If MaskedTextBox1.Text <> "" Then
                Me.TextBox1.Focus()
                Me.TextBox1.Text = object_cmd.getOleDbCommand2("select namefamili from master where codeP = " & Me.MaskedTextBox1.Text)
            End If
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Me.MaskedTextBox1.Text <> "" And Me.TextBox1.Text <> "" Then
            Try
                Dim strQ As String = ""

                strQ = "Update master Set " _
                & "namefamili='" & TextBox1.Text.ToString & "'  " _
                & "WHERE codeP = " & MaskedTextBox1.Text
                object_cmd.setOleDbCommand(strQ)

                strQ = "Update tbl_first Set " _
                & "case_compersion='" & TextBox1.Text.ToString & "'  " _
                & "WHERE codeP = " & MaskedTextBox1.Text
                object_cmd.setOleDbCommand(strQ)

                strQ = "Update tbl_issue Set " _
                & "value_mat='" & TextBox1.Text.ToString & "'  " _
                & "WHERE codeP = " & MaskedTextBox1.Text
                object_cmd.setOleDbCommand(strQ)

                clear()

            Catch ex As Exception
                MessageBox.Show("مشکلی در ثبت تغییرات رکورد جاری پیش آمده است" & vbCrLf & ex.Message)
                Exit Sub
            End Try

            MsgBox("اطلاعات به درستی ذخیره شد")
        Else
            MessageBox.Show(" لطفا ابتدا اطلاعات را وارد کنید سپس بر روی دکمه ثبت کلیک کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.MaskedTextBox1.Text <> "" Then
            Try
                Dim strQ As String = "delete from master WHERE codeP = " & MaskedTextBox1.Text
                object_cmd.setOleDbCommand(strQ)

                clear()

            Catch ex As Exception
                MessageBox.Show("مشکلی در ثبت تغییرات رکورد جاری پیش آمده است" & vbCrLf & ex.Message)
                Exit Sub
            End Try

            MsgBox("اطلاعات به درستی حذف شد")
        Else
            MessageBox.Show(" لطفا ابتدا اطلاعات را وارد کنید سپس بر روی دکمه پبت کلیک کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim i As Integer = 0
            Dim strQ As String = ""
            Dim strIssue As String = ""

            If Me.MaskedTextBox1.Text <> "" AndAlso Me.TextBox1.Text <> "" Then
                If Me.MaskedTextBox1.Text.Length = 8 Then
                    Try
                        strQ = "insert into master(codeP,namefamili) values('" & MaskedTextBox1.Text & "' , '" & TextBox1.Text & "')"
                        object_cmd.setOleDbCommand(strQ)
                        MsgBox("جدول بدرستی ثبت شد")
                        Me.MaskedTextBox1.Clear()
                        Me.TextBox1.Text = ""
                        Me.MaskedTextBox1.Focus()
                    Catch ex As Exception
                        MessageBox.Show("اطلاعات این معلم قبلا ثبت شده است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Else
                    MessageBox.Show(" طول فیلد شماره پرسنلی باید 8 رقم باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Else
                MessageBox.Show(" لطفا ابتدا اطلاعات را وارد کنید سپس بر روی دکمه پبت کلیک کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
End Class