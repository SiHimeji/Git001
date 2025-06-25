<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLogin))
        Me.TextBoxユーザーID = New System.Windows.Forms.TextBox()
        Me.TextBoxパスワード = New System.Windows.Forms.TextBox()
        Me.Button実行 = New System.Windows.Forms.Button()
        Me.Buttonキャンセル = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TextBoxユーザーID
        '
        Me.TextBoxユーザーID.Location = New System.Drawing.Point(169, 69)
        Me.TextBoxユーザーID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TextBoxユーザーID.MaxLength = 8
        Me.TextBoxユーザーID.Name = "TextBoxユーザーID"
        Me.TextBoxユーザーID.Size = New System.Drawing.Size(164, 26)
        Me.TextBoxユーザーID.TabIndex = 0
        '
        'TextBoxパスワード
        '
        Me.TextBoxパスワード.Location = New System.Drawing.Point(169, 110)
        Me.TextBoxパスワード.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TextBoxパスワード.MaxLength = 8
        Me.TextBoxパスワード.Name = "TextBoxパスワード"
        Me.TextBoxパスワード.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxパスワード.Size = New System.Drawing.Size(164, 26)
        Me.TextBoxパスワード.TabIndex = 1
        '
        'Button実行
        '
        Me.Button実行.Location = New System.Drawing.Point(207, 148)
        Me.Button実行.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Button実行.Name = "Button実行"
        Me.Button実行.Size = New System.Drawing.Size(140, 37)
        Me.Button実行.TabIndex = 2
        Me.Button実行.Text = "実行"
        Me.Button実行.UseVisualStyleBackColor = True
        '
        'Buttonキャンセル
        '
        Me.Buttonキャンセル.BackColor = System.Drawing.Color.Transparent
        Me.Buttonキャンセル.Location = New System.Drawing.Point(62, 148)
        Me.Buttonキャンセル.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Buttonキャンセル.Name = "Buttonキャンセル"
        Me.Buttonキャンセル.Size = New System.Drawing.Size(135, 37)
        Me.Buttonキャンセル.TabIndex = 3
        Me.Buttonキャンセル.Text = "キャンセル"
        Me.Buttonキャンセル.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(68, 70)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 19)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "ユーザーID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(75, 110)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 19)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "パスワード"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(97, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 19)
        Me.Label3.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(14, 9)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(353, 33)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "累積ポイント集計システム"
        '
        'FormLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SIAP002.My.Resources.Resources.姫路城2
        Me.ClientSize = New System.Drawing.Size(535, 342)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Buttonキャンセル)
        Me.Controls.Add(Me.Button実行)
        Me.Controls.Add(Me.TextBoxパスワード)
        Me.Controls.Add(Me.TextBoxユーザーID)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "FormLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "累積ポイント集計"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBoxユーザーID As TextBox
    Friend WithEvents TextBoxパスワード As TextBox
    Friend WithEvents Button実行 As Button
    Friend WithEvents Buttonキャンセル As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
