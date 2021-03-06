Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic

Public Class Form7

    Private Declare Function GetLogicalDrives Lib "Kernel32" () As Integer
    Private Declare Function GetDriveType Lib "Kernel32" Alias "GetDriveTypeA" (ByVal nDrive As String) As Integer
    Private Declare Function GetVolumeInformation Lib "Kernel32" Alias "GetVolumeInformationA" (ByVal lpRootPathName As String, ByVal lpVolumeNameBuffer As String, ByVal nVolumeNameSize As Integer, ByRef lpVolumeSerialNumber As Integer, ByRef lpMaximumComponentLength As Integer, ByRef lpFileSystemFlags As Integer, ByVal lpFileSystemNameBuffer As String, ByVal nFileSystemNameSize As Integer) As Integer
    'UPGRADE_WARNING: Lower bound of array F was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    'UPGRADE_WARNING: Lower bound of array C was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Dim A(25) As String
    Dim I, T As Short
    Dim C(10) As String
    Dim F(10) As String
    Dim Serial As Integer
    Dim VName, FSName As String

    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim H As Object
        Dim S As Object
        Dim B As Object
        Dim U As Object
        Dim K As Object
        Dim R As Object
        Dim LDs, Cnt As Integer
        Dim sDrives As String
        LDs = GetLogicalDrives
        I = 0
        T = 0
        Serial = 0
        Text1.Text = ""
        List1.Items.Clear()
        For R = 0 To 25
            'UPGRADE_WARNING: Couldn't resolve default property of object R. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            A(R) = ""
        Next R
        For K = 1 To 10
            'UPGRADE_WARNING: Couldn't resolve default property of object E. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            C(K) = ""
        Next K
        For U = 1 To 10
            'UPGRADE_WARNING: Couldn't resolve default property of object U. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            F(U) = ""
        Next U
        For Cnt = 0 To 25
            I = I + 1
            If (LDs And 2 ^ Cnt) <> 0 Then
                A(I) = Chr(65 + Cnt)
            End If
        Next Cnt
        For B = 0 To 25

            'UPGRADE_WARNING: Couldn't resolve default property of object B. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If A(B) <> "" Then
                'UPGRADE_WARNING: Couldn't resolve default property of object B. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Select Case GetDriveType(A(B) & ":\")
                    Case 2
                        T = T + 1
                        'UPGRADE_WARNING: Couldn't resolve default property of object B. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        C(T) = A(B) & ":\"
                End Select
            End If
        Next B
        For S = 1 To 10
            'UPGRADE_WARNING: Couldn't resolve default property of object S. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If C(S) <> "" Then
                'UPGRADE_WARNING: Couldn't resolve default property of object S. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If C(S) <> "A:\" Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object S. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    List1.Items.Add(C(S))
                    'UPGRADE_WARNING: Couldn't resolve default property of object S. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    F(S) = C(S)
                End If
            End If
        Next S
        Label1.Text = CStr(List1.Items.Count)
        For H = 1 To 10
            'UPGRADE_WARNING: Couldn't resolve default property of object H. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If F(H) <> "" Then
                VName = New String(Chr(0), 255)
                FSName = New String(Chr(0), 255)
                'UPGRADE_WARNING: Couldn't resolve default property of object H. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                GetVolumeInformation(F(H), VName, 255, Serial, 0, 0, FSName, 255)
                VName = VB.Left(VName, InStr(1, VName, Chr(0)) - 1)
                FSName = VB.Left(FSName, InStr(1, FSName, Chr(0)) - 1)
                If Serial = 0 Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object H. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Text1.Text = Text1.Text & "حالت درایو فلش :اتصال برقرار شده" & vbNewLine & "Drive : " & F(H) & vbNewLine & "The Volume name of " & F(H) & " is '" & VName & "', the File system name of " & F(H) & " is '" & FSName & "' and the serial number of " & F(H) & " is '" & Trim(Str(Serial)) & "'" & vbNewLine & vbNewLine
                    Button2.Enabled = True
                Else
                    'UPGRADE_WARNING: Couldn't resolve default property of object H. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Text1.Text = Text1.Text & "حالت درایو فلش :اتصال برقرار شده" & vbNewLine & "Drive : " & F(H) & vbNewLine & "The Volume name of " & F(H) & " is '" & VName & "', the File system name of " & F(H) & " is '" & FSName & "' and the serial number of " & F(H) & " is '" & Trim(Str(Serial)) & "'" & vbNewLine & vbNewLine
                    Button2.Enabled = True
                End If
            End If
        Next H

        If Text1.Text = "" Then
            MessageBox.Show(" کاربر گرامی لطفا ابتدا حافظه ی فلش را به کامپیوتر خود وصل کنید سپس بر روی دکمه اتصال کلیک کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Button2.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim P As Object
        On Error Resume Next
        Dim mdbPath As String
        'UPGRADE_WARNING: Couldn't resolve default property of object P. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        P = 0
        'UPGRADE_WARNING: App property App.EXEName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        mdbPath = My.Application.Info.DirectoryPath & "\mdb.mdb"
        For P = 1 To 10
            'UPGRADE_WARNING: Couldn't resolve default property of object P. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If F(P) <> "" Then
                'UPGRADE_WARNING: App property App.EXEName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                'UPGRADE_WARNING: Couldn't resolve default property of object P. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                FileCopy(mdbPath, F(P) & "mdb.mdb")
                MsgBox("انتقال فایل بدرستی انجام شد")
            End If
        Next P
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        On Error Resume Next
        Dim mdbPath As String
        'UPGRADE_WARNING: Couldn't resolve default property of object P. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'

        'UPGRADE_WARNING: App property App.EXEName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        mdbPath = My.Application.Info.DirectoryPath & "\mdb.mdb"

        'UPGRADE_WARNING: Couldn't resolve default property of object P. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'

        'UPGRADE_WARNING: App property App.EXEName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        'UPGRADE_WARNING: Couldn't resolve default property of object P. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        FileCopy(mdbPath, "D:\mdb.mdb")
        MsgBox("انتقال فایل بدرستی انجام شد")


    End Sub
End Class