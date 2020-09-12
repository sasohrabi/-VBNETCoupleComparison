Public Class frm_menu

    Private object_cmd As New clsCommands
    Private sVariables As New clsVariables

    Private Sub PictureBox4_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseMove
        Dim ctrl As Control
        PictureBox4.Visible = False
        PictureBox2.Visible = True
        For Each ctrl In Me.Controls
            If (TypeOf ctrl Is Label) Then
                ctrl.Visible = False
            End If

        Next
        Label6.Visible = True
        Label1.Visible = True


    End Sub

    Private Sub PictureBox2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        PictureBox4.Visible = True
        PictureBox2.Visible = False
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        Dim ctrl As Control
        PictureBox1.Visible = False
        PictureBox3.Visible = True
        For Each ctrl In Me.Controls
            If (TypeOf ctrl Is Label) Then
                ctrl.Visible = False
            End If
        Next

        Label9.Visible = True
        Label3.Visible = True

    End Sub

    Private Sub PictureBox3_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseLeave
        PictureBox1.Visible = True
        PictureBox3.Visible = False
    End Sub

    Private Sub PictureBox5_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox5.MouseMove
        Dim ctrl As Control
        PictureBox5.Visible = False
        PictureBox8.Visible = True
        For Each ctrl In Me.Controls
            If (TypeOf ctrl Is Label) Then
                ctrl.Visible = False
            End If
        Next

        Label11.Visible = True

    End Sub

    Private Sub PictureBox8_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.MouseLeave
        PictureBox5.Visible = True
        PictureBox8.Visible = False
    End Sub

    Private Sub PictureBox6_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox6.MouseMove
        Dim ctrl As Control
        PictureBox6.Visible = False
        PictureBox9.Visible = True
        For Each ctrl In Me.Controls
            If (TypeOf ctrl Is Label) Then
                ctrl.Visible = False
            End If
        Next
        Label10.Visible = True

    End Sub

    Private Sub PictureBox9_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox9.MouseLeave
        PictureBox6.Visible = True
        PictureBox9.Visible = False
    End Sub



    Private Sub frm_menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'AxShockwaveFlash1.Movie = Application.StartupPath & "\Harborstone001-gray.swf"
    End Sub

    Private Sub PictureBox2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim strQ As String = ""
        strQ = "select count(*) from tblAcademy"
        If object_cmd.getOleDbCommand(strQ) = 1 Then
            Dim frm As New Form1
            frm.Show()
        Else
            MessageBox.Show(" لطفا ابتدا مشخصات مدرسه را وارد کنید سپس بر روی این دکمه کلیک کنید  ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub PictureBox3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Dim strQ As String = ""
        strQ = "select count(*) from tblAcademy"
        If object_cmd.getOleDbCommand(strQ) = 1 Then
            Dim frm As New frm_add
            frm.Show()
        Else
            MessageBox.Show(" لطفا ابتدا مشخصات مدرسه را وارد کنید سپس بر روی این دکمه کلیک کنید  ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox9.Click
        Dim frm As New frmabout
        frm.Show()
    End Sub

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        Application.Exit()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox14_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox14.MouseMove
        Dim ctrl As Control
        PictureBox14.Visible = False
        PictureBox15.Visible = True
        For Each ctrl In Me.Controls
            If (TypeOf ctrl Is Label) Then
                ctrl.Visible = False
            End If
        Next

        Label8.Visible = True


    End Sub

    Private Sub PictureBox15_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox15.MouseLeave
        PictureBox14.Visible = True
        PictureBox15.Visible = False
    End Sub

    Private Sub PictureBox15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox15.Click
        Dim frm As New Form3
        frm.Show()
    End Sub

    Private Sub PictureBox13_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox13.MouseMove
        Dim ctrl As Control
        PictureBox13.Visible = False
        PictureBox16.Visible = True
        For Each ctrl In Me.Controls
            If (TypeOf ctrl Is Label) Then
                ctrl.Visible = False
            End If
        Next
        Label5.Visible = True
    End Sub

    Private Sub PictureBox16_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox16.MouseLeave
        PictureBox13.Visible = True
        PictureBox16.Visible = False
    End Sub

    Private Sub PictureBox16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox16.Click
        Dim frm As New Form4
        frm.Show()
    End Sub

    Private Sub PictureBox17_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox17.MouseMove
        Dim ctrl As Control
        PictureBox17.Visible = False
        PictureBox18.Visible = True
        For Each ctrl In Me.Controls
            If (TypeOf ctrl Is Label) Then
                ctrl.Visible = False
            End If
        Next

        Label4.Visible = True
    End Sub

    Private Sub PictureBox18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox18.Click
        Dim frm As New Form7
        frm.Show()
    End Sub

    Private Sub PictureBox18_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox18.MouseLeave
        PictureBox17.Visible = True
        PictureBox18.Visible = False
    End Sub

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click
        Application.Exit()
    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub PictureBox14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox14.Click

    End Sub
End Class