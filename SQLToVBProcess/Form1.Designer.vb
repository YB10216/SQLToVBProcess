<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意:  以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtLeft = New System.Windows.Forms.TextBox()
        Me.txtRight = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDictionaryName = New System.Windows.Forms.TextBox()
        Me.txtListName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtSD = New System.Windows.Forms.TextBox()
        Me.rdoWithNote = New System.Windows.Forms.RadioButton()
        Me.rdoWithoutNote = New System.Windows.Forms.RadioButton()
        Me.grpRdos = New System.Windows.Forms.GroupBox()
        Me.btnCls = New System.Windows.Forms.Button()
        Me.btnInverse = New System.Windows.Forms.Button()
        Me.btnTran = New System.Windows.Forms.Button()
        Me.grpRdos.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtLeft
        '
        Me.txtLeft.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLeft.Location = New System.Drawing.Point(19, 259)
        Me.txtLeft.Multiline = True
        Me.txtLeft.Name = "txtLeft"
        Me.txtLeft.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLeft.Size = New System.Drawing.Size(500, 440)
        Me.txtLeft.TabIndex = 0
        Me.txtLeft.Text = "Select Flow_Proc_No,Exm_Proc_Status,Cross_Exm_Mark" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "From IPLI_EXM_FLOW_CTRL" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Wher" & _
    "e sub_sys=:pSubSys" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "And Exm_Key_No = :SQL100.pKeyNo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "And Exm_E_Barcode=:中文" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "And " & _
    "Host_ID = :SQL100.中文"
        Me.txtLeft.WordWrap = False
        '
        'txtRight
        '
        Me.txtRight.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRight.Location = New System.Drawing.Point(597, 259)
        Me.txtRight.Multiline = True
        Me.txtRight.Name = "txtRight"
        Me.txtRight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRight.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtRight.Size = New System.Drawing.Size(650, 440)
        Me.txtRight.TabIndex = 1
        Me.txtRight.WordWrap = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 728)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1259, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1259, 24)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Dictionary :"
        '
        'txtDictionaryName
        '
        Me.txtDictionaryName.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDictionaryName.Location = New System.Drawing.Point(103, 27)
        Me.txtDictionaryName.Name = "txtDictionaryName"
        Me.txtDictionaryName.Size = New System.Drawing.Size(211, 26)
        Me.txtDictionaryName.TabIndex = 7
        Me.txtDictionaryName.Text = "sd"
        Me.ToolTip1.SetToolTip(Me.txtDictionaryName, "Dim sd As Dictionary(Of String, Object)")
        '
        'txtListName
        '
        Me.txtListName.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtListName.Location = New System.Drawing.Point(369, 27)
        Me.txtListName.Name = "txtListName"
        Me.txtListName.Size = New System.Drawing.Size(211, 26)
        Me.txtListName.TabIndex = 9
        Me.txtListName.Text = "paras"
        Me.ToolTip1.SetToolTip(Me.txtListName, "Dim paras As New List(Of Object)")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(326, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "List :"
        '
        'txtSD
        '
        Me.txtSD.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSD.Location = New System.Drawing.Point(597, 63)
        Me.txtSD.Multiline = True
        Me.txtSD.Name = "txtSD"
        Me.txtSD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSD.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSD.Size = New System.Drawing.Size(648, 168)
        Me.txtSD.TabIndex = 10
        Me.txtSD.WordWrap = False
        '
        'rdoWithNote
        '
        Me.rdoWithNote.AutoSize = True
        Me.rdoWithNote.Location = New System.Drawing.Point(133, 51)
        Me.rdoWithNote.Name = "rdoWithNote"
        Me.rdoWithNote.Size = New System.Drawing.Size(68, 16)
        Me.rdoWithNote.TabIndex = 12
        Me.rdoWithNote.Text = "WithNote"
        Me.rdoWithNote.UseVisualStyleBackColor = True
        '
        'rdoWithoutNote
        '
        Me.rdoWithoutNote.AutoSize = True
        Me.rdoWithoutNote.Checked = True
        Me.rdoWithoutNote.Location = New System.Drawing.Point(133, 32)
        Me.rdoWithoutNote.Name = "rdoWithoutNote"
        Me.rdoWithoutNote.Size = New System.Drawing.Size(83, 16)
        Me.rdoWithoutNote.TabIndex = 13
        Me.rdoWithoutNote.TabStop = True
        Me.rdoWithoutNote.Text = "WithoutNote"
        Me.rdoWithoutNote.UseVisualStyleBackColor = True
        '
        'grpRdos
        '
        Me.grpRdos.Controls.Add(Me.btnCls)
        Me.grpRdos.Controls.Add(Me.rdoWithNote)
        Me.grpRdos.Controls.Add(Me.btnInverse)
        Me.grpRdos.Controls.Add(Me.rdoWithoutNote)
        Me.grpRdos.Controls.Add(Me.btnTran)
        Me.grpRdos.Location = New System.Drawing.Point(103, 81)
        Me.grpRdos.Name = "grpRdos"
        Me.grpRdos.Size = New System.Drawing.Size(227, 116)
        Me.grpRdos.TabIndex = 15
        Me.grpRdos.TabStop = False
        '
        'btnCls
        '
        Me.btnCls.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnCls.Location = New System.Drawing.Point(21, 80)
        Me.btnCls.Name = "btnCls"
        Me.btnCls.Size = New System.Drawing.Size(75, 23)
        Me.btnCls.TabIndex = 3
        Me.btnCls.Text = "Clean"
        Me.btnCls.UseVisualStyleBackColor = True
        '
        'btnInverse
        '
        Me.btnInverse.Location = New System.Drawing.Point(21, 51)
        Me.btnInverse.Name = "btnInverse"
        Me.btnInverse.Size = New System.Drawing.Size(75, 23)
        Me.btnInverse.TabIndex = 11
        Me.btnInverse.Text = "Inverse"
        Me.btnInverse.UseVisualStyleBackColor = True
        '
        'btnTran
        '
        Me.btnTran.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnTran.Location = New System.Drawing.Point(21, 21)
        Me.btnTran.Name = "btnTran"
        Me.btnTran.Size = New System.Drawing.Size(75, 23)
        Me.btnTran.TabIndex = 2
        Me.btnTran.Text = "Transfer"
        Me.btnTran.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1259, 750)
        Me.Controls.Add(Me.grpRdos)
        Me.Controls.Add(Me.txtSD)
        Me.Controls.Add(Me.txtListName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDictionaryName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.txtRight)
        Me.Controls.Add(Me.txtLeft)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "SQL to VB Process"
        Me.grpRdos.ResumeLayout(False)
        Me.grpRdos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtLeft As System.Windows.Forms.TextBox
    Friend WithEvents txtRight As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDictionaryName As TextBox
    Friend WithEvents txtListName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents txtSD As System.Windows.Forms.TextBox
    Friend WithEvents rdoWithNote As System.Windows.Forms.RadioButton
    Friend WithEvents rdoWithoutNote As System.Windows.Forms.RadioButton
    Friend WithEvents grpRdos As System.Windows.Forms.GroupBox
    Friend WithEvents btnCls As System.Windows.Forms.Button
    Friend WithEvents btnInverse As System.Windows.Forms.Button
    Friend WithEvents btnTran As System.Windows.Forms.Button
End Class
