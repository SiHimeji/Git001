<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMenu))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.パスワード変更ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.マスタToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CSVふぉまっとToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ユーザーToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ポイントToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ランクToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.記念品ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.名寄せToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.システムToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ログ表示ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DB設定ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DB指定ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DBバックアップToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.過去データ削除ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ツールTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ButtonCSV = New System.Windows.Forms.Button()
        Me.Button寄附者検索 = New System.Windows.Forms.Button()
        Me.Button明細検索 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了ToolStripMenuItem, Me.パスワード変更ToolStripMenuItem, Me.マスタToolStripMenuItem, Me.DB設定ToolStripMenuItem, Me.ツールTToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.MenuStrip1.Size = New System.Drawing.Size(423, 25)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(43, 19)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        'パスワード変更ToolStripMenuItem
        '
        Me.パスワード変更ToolStripMenuItem.Name = "パスワード変更ToolStripMenuItem"
        Me.パスワード変更ToolStripMenuItem.Size = New System.Drawing.Size(87, 19)
        Me.パスワード変更ToolStripMenuItem.Text = "パスワード変更"
        '
        'マスタToolStripMenuItem
        '
        Me.マスタToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CSVふぉまっとToolStripMenuItem, Me.ユーザーToolStripMenuItem, Me.ポイントToolStripMenuItem1, Me.ランクToolStripMenuItem, Me.記念品ToolStripMenuItem, Me.名寄せToolStripMenuItem, Me.システムToolStripMenuItem, Me.ログ表示ToolStripMenuItem})
        Me.マスタToolStripMenuItem.Name = "マスタToolStripMenuItem"
        Me.マスタToolStripMenuItem.Size = New System.Drawing.Size(46, 19)
        Me.マスタToolStripMenuItem.Text = "マスタ"
        '
        'CSVふぉまっとToolStripMenuItem
        '
        Me.CSVふぉまっとToolStripMenuItem.Name = "CSVふぉまっとToolStripMenuItem"
        Me.CSVふぉまっとToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.CSVふぉまっとToolStripMenuItem.Text = "CSVひな形登録"
        '
        'ユーザーToolStripMenuItem
        '
        Me.ユーザーToolStripMenuItem.Name = "ユーザーToolStripMenuItem"
        Me.ユーザーToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.ユーザーToolStripMenuItem.Text = "ユーザー"
        '
        'ポイントToolStripMenuItem1
        '
        Me.ポイントToolStripMenuItem1.Name = "ポイントToolStripMenuItem1"
        Me.ポイントToolStripMenuItem1.Size = New System.Drawing.Size(153, 22)
        Me.ポイントToolStripMenuItem1.Text = "ポイント"
        '
        'ランクToolStripMenuItem
        '
        Me.ランクToolStripMenuItem.Name = "ランクToolStripMenuItem"
        Me.ランクToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.ランクToolStripMenuItem.Text = "ランク"
        '
        '記念品ToolStripMenuItem
        '
        Me.記念品ToolStripMenuItem.Name = "記念品ToolStripMenuItem"
        Me.記念品ToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.記念品ToolStripMenuItem.Text = "記念品"
        '
        '名寄せToolStripMenuItem
        '
        Me.名寄せToolStripMenuItem.Name = "名寄せToolStripMenuItem"
        Me.名寄せToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.名寄せToolStripMenuItem.Text = "名寄せ"
        '
        'システムToolStripMenuItem
        '
        Me.システムToolStripMenuItem.Name = "システムToolStripMenuItem"
        Me.システムToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.システムToolStripMenuItem.Text = "システム"
        '
        'ログ表示ToolStripMenuItem
        '
        Me.ログ表示ToolStripMenuItem.Name = "ログ表示ToolStripMenuItem"
        Me.ログ表示ToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.ログ表示ToolStripMenuItem.Text = "アクセスログ表示"
        '
        'DB設定ToolStripMenuItem
        '
        Me.DB設定ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DB指定ToolStripMenuItem1, Me.DBバックアップToolStripMenuItem, Me.過去データ削除ToolStripMenuItem})
        Me.DB設定ToolStripMenuItem.Name = "DB設定ToolStripMenuItem"
        Me.DB設定ToolStripMenuItem.Size = New System.Drawing.Size(58, 19)
        Me.DB設定ToolStripMenuItem.Text = "DB設定"
        '
        'DB指定ToolStripMenuItem1
        '
        Me.DB指定ToolStripMenuItem1.Name = "DB指定ToolStripMenuItem1"
        Me.DB指定ToolStripMenuItem1.Size = New System.Drawing.Size(148, 22)
        Me.DB指定ToolStripMenuItem1.Text = "DB指定"
        '
        'DBバックアップToolStripMenuItem
        '
        Me.DBバックアップToolStripMenuItem.Name = "DBバックアップToolStripMenuItem"
        Me.DBバックアップToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.DBバックアップToolStripMenuItem.Text = "DBバックアップ"
        '
        '過去データ削除ToolStripMenuItem
        '
        Me.過去データ削除ToolStripMenuItem.Name = "過去データ削除ToolStripMenuItem"
        Me.過去データ削除ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.過去データ削除ToolStripMenuItem.Text = "過去データ削除"
        '
        'ツールTToolStripMenuItem
        '
        Me.ツールTToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ツールTToolStripMenuItem.Name = "ツールTToolStripMenuItem"
        Me.ツールTToolStripMenuItem.Size = New System.Drawing.Size(88, 19)
        Me.ツールTToolStripMenuItem.Text = "操作マニュアル"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 342)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 24, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(423, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(19, 17)
        Me.ToolStripStatusLabel1.Text = "＿"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(19, 17)
        Me.ToolStripStatusLabel2.Text = "＿"
        '
        'ButtonCSV
        '
        Me.ButtonCSV.Location = New System.Drawing.Point(31, 38)
        Me.ButtonCSV.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ButtonCSV.Name = "ButtonCSV"
        Me.ButtonCSV.Size = New System.Drawing.Size(369, 81)
        Me.ButtonCSV.TabIndex = 2
        Me.ButtonCSV.Text = "CSV取込・データ更新"
        Me.ButtonCSV.UseVisualStyleBackColor = True
        '
        'Button寄附者検索
        '
        Me.Button寄附者検索.Location = New System.Drawing.Point(31, 138)
        Me.Button寄附者検索.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Button寄附者検索.Name = "Button寄附者検索"
        Me.Button寄附者検索.Size = New System.Drawing.Size(369, 81)
        Me.Button寄附者検索.TabIndex = 4
        Me.Button寄附者検索.Text = "寄附者検索"
        Me.Button寄附者検索.UseVisualStyleBackColor = True
        '
        'Button明細検索
        '
        Me.Button明細検索.Location = New System.Drawing.Point(30, 236)
        Me.Button明細検索.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Button明細検索.Name = "Button明細検索"
        Me.Button明細検索.Size = New System.Drawing.Size(369, 81)
        Me.Button明細検索.TabIndex = 5
        Me.Button明細検索.Text = "明細検索"
        Me.Button明細検索.UseVisualStyleBackColor = True
        '
        'FormMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(423, 364)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button明細検索)
        Me.Controls.Add(Me.Button寄附者検索)
        Me.Controls.Add(Me.ButtonCSV)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "FormMenu"
        Me.Text = "累積ポイント集計システム"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ButtonCSV As Button
    Friend WithEvents Button寄附者検索 As Button
    Friend WithEvents マスタToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CSVふぉまっとToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 名寄せToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ユーザーToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents パスワード変更ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents システムToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ポイントToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ランクToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 記念品ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ツールTToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DB設定ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ログ表示ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DB指定ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DBバックアップToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button明細検索 As Button
    Friend WithEvents 過去データ削除ToolStripMenuItem As ToolStripMenuItem
End Class
