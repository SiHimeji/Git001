<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPassWord
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPassWord))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.閉じるToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button確定 = New System.Windows.Forms.Button()
        Me.TextBox現パスワード = New System.Windows.Forms.TextBox()
        Me.TextBox新パスワード = New System.Windows.Forms.TextBox()
        Me.TextBox新パスワード再 = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.閉じるToolStripMenuItem, Me.IDToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.MenuStrip1.Size = New System.Drawing.Size(384, 25)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '閉じるToolStripMenuItem
        '
        Me.閉じるToolStripMenuItem.Name = "閉じるToolStripMenuItem"
        Me.閉じるToolStripMenuItem.Size = New System.Drawing.Size(49, 19)
        Me.閉じるToolStripMenuItem.Text = "閉じる"
        '
        'IDToolStripMenuItem
        '
        Me.IDToolStripMenuItem.Name = "IDToolStripMenuItem"
        Me.IDToolStripMenuItem.Size = New System.Drawing.Size(30, 19)
        Me.IDToolStripMenuItem.Text = "ID"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 36)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "現パスワード"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 75)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "新パスワード"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(35, 109)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(134, 19)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "新パスワード(再)"
        '
        'Button確定
        '
        Me.Button確定.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button確定.Location = New System.Drawing.Point(215, 148)
        Me.Button確定.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Button確定.Name = "Button確定"
        Me.Button確定.Size = New System.Drawing.Size(125, 37)
        Me.Button確定.TabIndex = 3
        Me.Button確定.Text = "確定"
        Me.Button確定.UseVisualStyleBackColor = False
        '
        'TextBox現パスワード
        '
        Me.TextBox現パスワード.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox現パスワード.Location = New System.Drawing.Point(176, 31)
        Me.TextBox現パスワード.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TextBox現パスワード.Name = "TextBox現パスワード"
        Me.TextBox現パスワード.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox現パスワード.Size = New System.Drawing.Size(164, 26)
        Me.TextBox現パスワード.TabIndex = 0
        '
        'TextBox新パスワード
        '
        Me.TextBox新パスワード.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox新パスワード.Location = New System.Drawing.Point(178, 70)
        Me.TextBox新パスワード.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TextBox新パスワード.Name = "TextBox新パスワード"
        Me.TextBox新パスワード.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox新パスワード.Size = New System.Drawing.Size(164, 26)
        Me.TextBox新パスワード.TabIndex = 1
        '
        'TextBox新パスワード再
        '
        Me.TextBox新パスワード再.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox新パスワード再.Location = New System.Drawing.Point(178, 105)
        Me.TextBox新パスワード再.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TextBox新パスワード再.Name = "TextBox新パスワード再"
        Me.TextBox新パスワード再.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox新パスワード再.Size = New System.Drawing.Size(164, 26)
        Me.TextBox新パスワード再.TabIndex = 2
        '
        'FormPassWord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 211)
        Me.Controls.Add(Me.TextBox新パスワード再)
        Me.Controls.Add(Me.TextBox新パスワード)
        Me.Controls.Add(Me.TextBox現パスワード)
        Me.Controls.Add(Me.Button確定)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "FormPassWord"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "パスワード変更"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 閉じるToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button確定 As Button
    Friend WithEvents TextBox現パスワード As TextBox
    Friend WithEvents TextBox新パスワード As TextBox
    Friend WithEvents TextBox新パスワード再 As TextBox
    Friend WithEvents IDToolStripMenuItem As ToolStripMenuItem
End Class
