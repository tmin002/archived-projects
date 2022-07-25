<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExcWnd
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.removebtn = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.addspacebtn = New System.Windows.Forms.Button()
        Me.addtabbtn = New System.Windows.Forms.Button()
        Me.addnbtn = New System.Windows.Forms.Button()
        Me.addbtn = New System.Windows.Forms.Button()
        Me.textbox1 = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 12
        Me.ListBox1.Location = New System.Drawing.Point(13, 13)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(262, 184)
        Me.ListBox1.TabIndex = 0
        '
        'removebtn
        '
        Me.removebtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.removebtn.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.removebtn.Location = New System.Drawing.Point(13, 212)
        Me.removebtn.Name = "removebtn"
        Me.removebtn.Size = New System.Drawing.Size(262, 23)
        Me.removebtn.TabIndex = 1
        Me.removebtn.Text = "Remove Selected"
        Me.removebtn.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.addspacebtn)
        Me.GroupBox1.Controls.Add(Me.addtabbtn)
        Me.GroupBox1.Controls.Add(Me.addnbtn)
        Me.GroupBox1.Controls.Add(Me.addbtn)
        Me.GroupBox1.Controls.Add(Me.textbox1)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 252)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(262, 118)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "New Exception Word"
        '
        'addspacebtn
        '
        Me.addspacebtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.addspacebtn.Location = New System.Drawing.Point(175, 72)
        Me.addspacebtn.Name = "addspacebtn"
        Me.addspacebtn.Size = New System.Drawing.Size(81, 23)
        Me.addspacebtn.TabIndex = 6
        Me.addspacebtn.Text = "Add Space"
        Me.addspacebtn.UseVisualStyleBackColor = False
        '
        'addtabbtn
        '
        Me.addtabbtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.addtabbtn.Location = New System.Drawing.Point(90, 72)
        Me.addtabbtn.Name = "addtabbtn"
        Me.addtabbtn.Size = New System.Drawing.Size(79, 23)
        Me.addtabbtn.TabIndex = 5
        Me.addtabbtn.Text = "Add Tab"
        Me.addtabbtn.UseVisualStyleBackColor = False
        '
        'addnbtn
        '
        Me.addnbtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.addnbtn.Location = New System.Drawing.Point(7, 72)
        Me.addnbtn.Name = "addnbtn"
        Me.addnbtn.Size = New System.Drawing.Size(77, 23)
        Me.addnbtn.TabIndex = 4
        Me.addnbtn.Text = "Add \n"
        Me.addnbtn.UseVisualStyleBackColor = False
        '
        'addbtn
        '
        Me.addbtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.addbtn.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.addbtn.Location = New System.Drawing.Point(186, 30)
        Me.addbtn.Name = "addbtn"
        Me.addbtn.Size = New System.Drawing.Size(70, 23)
        Me.addbtn.TabIndex = 3
        Me.addbtn.Text = "Add"
        Me.addbtn.UseVisualStyleBackColor = False
        '
        'textbox1
        '
        Me.textbox1.Location = New System.Drawing.Point(7, 32)
        Me.textbox1.Name = "textbox1"
        Me.textbox1.Size = New System.Drawing.Size(173, 21)
        Me.textbox1.TabIndex = 0
        '
        'ExcWnd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(291, 380)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.removebtn)
        Me.Controls.Add(Me.ListBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(307, 419)
        Me.MinimumSize = New System.Drawing.Size(307, 382)
        Me.Name = "ExcWnd"
        Me.Text = "Count Exception Words"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents removebtn As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents addspacebtn As Button
    Friend WithEvents addtabbtn As Button
    Friend WithEvents addnbtn As Button
    Friend WithEvents addbtn As Button
    Friend WithEvents textbox1 As TextBox
End Class
