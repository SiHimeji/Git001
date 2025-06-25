<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormRiseki
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormRiseki))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.閉じるToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextBoxEmailアドレス = New System.Windows.Forms.TextBox()
        Me.TextBox市区町村 = New System.Windows.Forms.TextBox()
        Me.TextBoxフリガナ = New System.Windows.Forms.TextBox()
        Me.TextBox名前 = New System.Windows.Forms.TextBox()
        Me.TextBox顧客ID = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox番地マンション名 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox備考 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.NumericUpDown寄付金額 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown寄付回数 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown累積石高 = New System.Windows.Forms.NumericUpDown()
        Me.ComboBoxランク = New System.Windows.Forms.ComboBox()
        Me.TextBox入金日 = New System.Windows.Forms.TextBox()
        Me.Button削除 = New System.Windows.Forms.Button()
        Me.Button更新 = New System.Windows.Forms.Button()
        Me.Button明細表示 = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TextBox郵便番号 = New System.Windows.Forms.MaskedTextBox()
        Me.ComboBox都道府県 = New System.Windows.Forms.ComboBox()
        Me.DataGridViewSoufu = New System.Windows.Forms.DataGridView()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Button追加 = New System.Windows.Forms.Button()
        Me.TextBox電話番号 = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.NumericUpDown寄付金額, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown寄付回数, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown累積石高, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DataGridViewSoufu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.閉じるToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(944, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '閉じるToolStripMenuItem
        '
        Me.閉じるToolStripMenuItem.Name = "閉じるToolStripMenuItem"
        Me.閉じるToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.閉じるToolStripMenuItem.Text = "閉じる"
        '
        'TextBoxEmailアドレス
        '
        Me.TextBoxEmailアドレス.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBoxEmailアドレス.Location = New System.Drawing.Point(495, 130)
        Me.TextBoxEmailアドレス.Name = "TextBoxEmailアドレス"
        Me.TextBoxEmailアドレス.Size = New System.Drawing.Size(285, 26)
        Me.TextBoxEmailアドレス.TabIndex = 5
        '
        'TextBox市区町村
        '
        Me.TextBox市区町村.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox市区町村.Location = New System.Drawing.Point(555, 162)
        Me.TextBox市区町村.Name = "TextBox市区町村"
        Me.TextBox市区町村.Size = New System.Drawing.Size(225, 26)
        Me.TextBox市区町村.TabIndex = 8
        '
        'TextBoxフリガナ
        '
        Me.TextBoxフリガナ.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBoxフリガナ.Location = New System.Drawing.Point(120, 127)
        Me.TextBoxフリガナ.Name = "TextBoxフリガナ"
        Me.TextBoxフリガナ.Size = New System.Drawing.Size(238, 26)
        Me.TextBoxフリガナ.TabIndex = 4
        '
        'TextBox名前
        '
        Me.TextBox名前.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox名前.Location = New System.Drawing.Point(120, 95)
        Me.TextBox名前.Name = "TextBox名前"
        Me.TextBox名前.Size = New System.Drawing.Size(238, 26)
        Me.TextBox名前.TabIndex = 2
        '
        'TextBox顧客ID
        '
        Me.TextBox顧客ID.BackColor = System.Drawing.SystemColors.HighlightText
        Me.TextBox顧客ID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox顧客ID.Location = New System.Drawing.Point(120, 63)
        Me.TextBox顧客ID.Name = "TextBox顧客ID"
        Me.TextBox顧客ID.ReadOnly = True
        Me.TextBox顧客ID.Size = New System.Drawing.Size(111, 26)
        Me.TextBox顧客ID.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(373, 131)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(118, 19)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "E-mailアドレス"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(406, 95)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 19)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "電話番号"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(464, 165)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 19)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "市区町村"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(252, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 19)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "都道府県"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 162)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 19)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "郵便番号"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(46, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 19)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "フリガナ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(49, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 19)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "名前"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(49, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 19)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "顧客ID"
        '
        'TextBox番地マンション名
        '
        Me.TextBox番地マンション名.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox番地マンション名.Location = New System.Drawing.Point(343, 194)
        Me.TextBox番地マンション名.Name = "TextBox番地マンション名"
        Me.TextBox番地マンション名.Size = New System.Drawing.Size(437, 26)
        Me.TextBox番地マンション名.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(193, 197)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 19)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "番地・マンション名"
        '
        'TextBox備考
        '
        Me.TextBox備考.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox備考.Location = New System.Drawing.Point(92, 509)
        Me.TextBox備考.MaxLength = 100
        Me.TextBox備考.Name = "TextBox備考"
        Me.TextBox備考.Size = New System.Drawing.Size(814, 26)
        Me.TextBox備考.TabIndex = 15
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(40, 512)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(47, 19)
        Me.Label18.TabIndex = 54
        Me.Label18.Text = "備考"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(706, 320)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(85, 19)
        Me.Label17.TabIndex = 53
        Me.Label17.Text = "寄付回数"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(690, 394)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(104, 19)
        Me.Label16.TabIndex = 52
        Me.Label16.Text = "最終入金日"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(668, 289)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(123, 19)
        Me.Label14.TabIndex = 50
        Me.Label14.Text = "累積寄付金額"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(58, 227)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 19)
        Me.Label12.TabIndex = 48
        Me.Label12.Text = "ランク"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(706, 352)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 19)
        Me.Label11.TabIndex = 47
        Me.Label11.Text = "累積石高"
        '
        'NumericUpDown寄付金額
        '
        Me.NumericUpDown寄付金額.Location = New System.Drawing.Point(794, 285)
        Me.NumericUpDown寄付金額.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.NumericUpDown寄付金額.Name = "NumericUpDown寄付金額"
        Me.NumericUpDown寄付金額.Size = New System.Drawing.Size(143, 26)
        Me.NumericUpDown寄付金額.TabIndex = 11
        Me.NumericUpDown寄付金額.ThousandsSeparator = True
        '
        'NumericUpDown寄付回数
        '
        Me.NumericUpDown寄付回数.Location = New System.Drawing.Point(794, 316)
        Me.NumericUpDown寄付回数.Name = "NumericUpDown寄付回数"
        Me.NumericUpDown寄付回数.Size = New System.Drawing.Size(143, 26)
        Me.NumericUpDown寄付回数.TabIndex = 12
        '
        'NumericUpDown累積石高
        '
        Me.NumericUpDown累積石高.Location = New System.Drawing.Point(794, 348)
        Me.NumericUpDown累積石高.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.NumericUpDown累積石高.Name = "NumericUpDown累積石高"
        Me.NumericUpDown累積石高.Size = New System.Drawing.Size(143, 26)
        Me.NumericUpDown累積石高.TabIndex = 13
        Me.NumericUpDown累積石高.ThousandsSeparator = True
        '
        'ComboBoxランク
        '
        Me.ComboBoxランク.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxランク.FormattingEnabled = True
        Me.ComboBoxランク.Location = New System.Drawing.Point(117, 227)
        Me.ComboBoxランク.Name = "ComboBoxランク"
        Me.ComboBoxランク.Size = New System.Drawing.Size(151, 27)
        Me.ComboBoxランク.TabIndex = 10
        '
        'TextBox入金日
        '
        Me.TextBox入金日.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox入金日.Location = New System.Drawing.Point(794, 390)
        Me.TextBox入金日.Name = "TextBox入金日"
        Me.TextBox入金日.Size = New System.Drawing.Size(143, 26)
        Me.TextBox入金日.TabIndex = 14
        '
        'Button削除
        '
        Me.Button削除.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button削除.Location = New System.Drawing.Point(843, 29)
        Me.Button削除.Margin = New System.Windows.Forms.Padding(4)
        Me.Button削除.Name = "Button削除"
        Me.Button削除.Size = New System.Drawing.Size(94, 29)
        Me.Button削除.TabIndex = 17
        Me.Button削除.Text = "削除"
        Me.Button削除.UseVisualStyleBackColor = False
        '
        'Button更新
        '
        Me.Button更新.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button更新.Location = New System.Drawing.Point(743, 29)
        Me.Button更新.Margin = New System.Windows.Forms.Padding(4)
        Me.Button更新.Name = "Button更新"
        Me.Button更新.Size = New System.Drawing.Size(94, 29)
        Me.Button更新.TabIndex = 16
        Me.Button更新.Text = "更新"
        Me.Button更新.UseVisualStyleBackColor = False
        '
        'Button明細表示
        '
        Me.Button明細表示.BackColor = System.Drawing.Color.Aqua
        Me.Button明細表示.Location = New System.Drawing.Point(251, 60)
        Me.Button明細表示.Name = "Button明細表示"
        Me.Button明細表示.Size = New System.Drawing.Size(107, 30)
        Me.Button明細表示.TabIndex = 1
        Me.Button明細表示.Text = "明細表示"
        Me.Button明細表示.UseVisualStyleBackColor = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 559)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(944, 22)
        Me.StatusStrip1.TabIndex = 80
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'TextBox郵便番号
        '
        Me.TextBox郵便番号.Location = New System.Drawing.Point(120, 162)
        Me.TextBox郵便番号.Mask = "000-0000"
        Me.TextBox郵便番号.Name = "TextBox郵便番号"
        Me.TextBox郵便番号.Size = New System.Drawing.Size(107, 26)
        Me.TextBox郵便番号.TabIndex = 6
        '
        'ComboBox都道府県
        '
        Me.ComboBox都道府県.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox都道府県.FormattingEnabled = True
        Me.ComboBox都道府県.Items.AddRange(New Object() {"", "北海道", "青森県", "岩手県", "宮城県", "秋田県", "山形県", "福島県", "茨城県", "栃木県", "群馬県", "埼玉県", "千葉県", "東京都", "神奈川県", "新潟県", "富山県", "石川県", "福井県", "山梨県", "長野県", "岐阜県", "静岡県", "愛知県", "三重県", "滋賀県", "京都府", "大阪府", "兵庫県", "奈良県", "和歌山県", "鳥取県", "島根県", "岡山県", "広島県", "山口県", "徳島県", "香川県", "愛媛県", "高知県", "福岡県", "佐賀県", "長崎県", "熊本県", "大分県", "宮崎県", "鹿児島県", "沖縄県"})
        Me.ComboBox都道府県.Location = New System.Drawing.Point(343, 162)
        Me.ComboBox都道府県.Name = "ComboBox都道府県"
        Me.ComboBox都道府県.Size = New System.Drawing.Size(121, 27)
        Me.ComboBox都道府県.TabIndex = 7
        '
        'DataGridViewSoufu
        '
        Me.DataGridViewSoufu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewSoufu.Location = New System.Drawing.Point(18, 285)
        Me.DataGridViewSoufu.Name = "DataGridViewSoufu"
        Me.DataGridViewSoufu.RowTemplate.Height = 21
        Me.DataGridViewSoufu.Size = New System.Drawing.Size(653, 202)
        Me.DataGridViewSoufu.TabIndex = 83
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(20, 271)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 12)
        Me.Label13.TabIndex = 86
        Me.Label13.Text = "送付履歴"
        '
        'Button追加
        '
        Me.Button追加.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button追加.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button追加.Location = New System.Drawing.Point(597, 259)
        Me.Button追加.Name = "Button追加"
        Me.Button追加.Size = New System.Drawing.Size(75, 23)
        Me.Button追加.TabIndex = 87
        Me.Button追加.Text = "追加"
        Me.Button追加.UseVisualStyleBackColor = False
        '
        'TextBox電話番号
        '
        Me.TextBox電話番号.Location = New System.Drawing.Point(498, 95)
        Me.TextBox電話番号.MaxLength = 13
        Me.TextBox電話番号.Name = "TextBox電話番号"
        Me.TextBox電話番号.Size = New System.Drawing.Size(186, 26)
        Me.TextBox電話番号.TabIndex = 3
        '
        'FormRiseki
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 581)
        Me.Controls.Add(Me.TextBox電話番号)
        Me.Controls.Add(Me.Button追加)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.DataGridViewSoufu)
        Me.Controls.Add(Me.ComboBox都道府県)
        Me.Controls.Add(Me.TextBox郵便番号)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Button明細表示)
        Me.Controls.Add(Me.Button削除)
        Me.Controls.Add(Me.Button更新)
        Me.Controls.Add(Me.TextBox入金日)
        Me.Controls.Add(Me.ComboBoxランク)
        Me.Controls.Add(Me.NumericUpDown累積石高)
        Me.Controls.Add(Me.NumericUpDown寄付回数)
        Me.Controls.Add(Me.NumericUpDown寄付金額)
        Me.Controls.Add(Me.TextBox備考)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TextBox番地マンション名)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxEmailアドレス)
        Me.Controls.Add(Me.TextBox市区町村)
        Me.Controls.Add(Me.TextBoxフリガナ)
        Me.Controls.Add(Me.TextBox名前)
        Me.Controls.Add(Me.TextBox顧客ID)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "FormRiseki"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "累積編集"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.NumericUpDown寄付金額, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown寄付回数, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown累積石高, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DataGridViewSoufu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 閉じるToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TextBoxEmailアドレス As TextBox
    Friend WithEvents TextBox市区町村 As TextBox
    Friend WithEvents TextBoxフリガナ As TextBox
    Friend WithEvents TextBox名前 As TextBox
    Friend WithEvents TextBox顧客ID As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox番地マンション名 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox備考 As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents NumericUpDown寄付金額 As NumericUpDown
    Friend WithEvents NumericUpDown寄付回数 As NumericUpDown
    Friend WithEvents NumericUpDown累積石高 As NumericUpDown
    Friend WithEvents ComboBoxランク As ComboBox
    Friend WithEvents TextBox入金日 As TextBox
    Friend WithEvents Button削除 As Button
    Friend WithEvents Button更新 As Button
    Friend WithEvents Button明細表示 As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents TextBox郵便番号 As MaskedTextBox
    Friend WithEvents ComboBox都道府県 As ComboBox
    Friend WithEvents DataGridViewSoufu As DataGridView
    Friend WithEvents Label13 As Label
    Friend WithEvents Button追加 As Button
    Friend WithEvents TextBox電話番号 As TextBox
End Class
