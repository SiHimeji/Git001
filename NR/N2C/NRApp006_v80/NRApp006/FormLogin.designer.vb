<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLogin
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLogin))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxログイン = New System.Windows.Forms.TextBox()
        Me.TextBoxパスワード = New System.Windows.Forms.TextBox()
        Me.Buttonログイン = New System.Windows.Forms.Button()
        Me.Buttonキャンセル = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ユーザー"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "パスワード"
        '
        'TextBoxログイン
        '
        Me.TextBoxログイン.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBoxログイン.Location = New System.Drawing.Point(100, 14)
        Me.TextBoxログイン.Name = "TextBoxログイン"
        Me.TextBoxログイン.Size = New System.Drawing.Size(166, 19)
        Me.TextBoxログイン.TabIndex = 0
        '
        'TextBoxパスワード
        '
        Me.TextBoxパスワード.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBoxパスワード.Location = New System.Drawing.Point(100, 42)
        Me.TextBoxパスワード.Name = "TextBoxパスワード"
        Me.TextBoxパスワード.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxパスワード.Size = New System.Drawing.Size(166, 19)
        Me.TextBoxパスワード.TabIndex = 1
        '
        'Buttonログイン
        '
        Me.Buttonログイン.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Buttonログイン.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Buttonログイン.Location = New System.Drawing.Point(96, 67)
        Me.Buttonログイン.Name = "Buttonログイン"
        Me.Buttonログイン.Size = New System.Drawing.Size(75, 23)
        Me.Buttonログイン.TabIndex = 2
        Me.Buttonログイン.Text = "ログイン"
        Me.Buttonログイン.UseVisualStyleBackColor = False
        '
        'Buttonキャンセル
        '
        Me.Buttonキャンセル.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Buttonキャンセル.Location = New System.Drawing.Point(191, 67)
        Me.Buttonキャンセル.Name = "Buttonキャンセル"
        Me.Buttonキャンセル.Size = New System.Drawing.Size(75, 23)
        Me.Buttonキャンセル.TabIndex = 3
        Me.Buttonキャンセル.Text = "キャンセル"
        Me.Buttonキャンセル.UseVisualStyleBackColor = False
        '
        'FormLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(297, 125)
        Me.Controls.Add(Me.Buttonキャンセル)
        Me.Controls.Add(Me.Buttonログイン)
        Me.Controls.Add(Me.TextBoxパスワード)
        Me.Controls.Add(Me.TextBoxログイン)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxログイン As TextBox
    Friend WithEvents TextBoxパスワード As TextBox
    Friend WithEvents Buttonログイン As Button
    Friend WithEvents Buttonキャンセル As Button
End Class
