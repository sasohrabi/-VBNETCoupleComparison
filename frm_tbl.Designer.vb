<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_tbl
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtissue2 = New System.Windows.Forms.TextBox
        Me.tbl = New System.Windows.Forms.DataGridView
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.txtissue = New System.Windows.Forms.ComboBox
        CType(Me.tbl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(452, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(90, 21)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "load table"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.UseWaitCursor = True
        '
        'txtissue2
        '
        Me.txtissue2.BackColor = System.Drawing.SystemColors.Info
        Me.txtissue2.Location = New System.Drawing.Point(548, 12)
        Me.txtissue2.Name = "txtissue2"
        Me.txtissue2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtissue2.Size = New System.Drawing.Size(102, 20)
        Me.txtissue2.TabIndex = 2
        Me.txtissue2.Text = "salary"
        Me.txtissue2.UseWaitCursor = True
        '
        'tbl
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.tbl.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tbl.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.tbl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tbl.Cursor = System.Windows.Forms.Cursors.WaitCursor
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.tbl.DefaultCellStyle = DataGridViewCellStyle3
        Me.tbl.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tbl.Location = New System.Drawing.Point(4, 38)
        Me.tbl.Name = "tbl"
        Me.tbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tbl.RowHeadersWidth = 45
        Me.tbl.Size = New System.Drawing.Size(646, 512)
        Me.tbl.TabIndex = 6
        Me.tbl.UseWaitCursor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(4, 38)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(646, 21)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "load table"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.UseWaitCursor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(358, 11)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(90, 21)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "update"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.UseWaitCursor = True
        '
        'txtissue
        '
        Me.txtissue.Font = New System.Drawing.Font("Nazanin", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtissue.FormattingEnabled = True
        Me.txtissue.Location = New System.Drawing.Point(162, -2)
        Me.txtissue.Name = "txtissue"
        Me.txtissue.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtissue.Size = New System.Drawing.Size(190, 34)
        Me.txtissue.TabIndex = 10
        Me.txtissue.UseWaitCursor = True
        '
        'frm_tbl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(655, 554)
        Me.Controls.Add(Me.txtissue)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.tbl)
        Me.Controls.Add(Me.txtissue2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "frm_tbl"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "›—„ ÊÌ—«Ì‘"
        Me.UseWaitCursor = True
        CType(Me.tbl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtissue2 As System.Windows.Forms.TextBox
    Friend WithEvents tbl As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txtissue As System.Windows.Forms.ComboBox

End Class
