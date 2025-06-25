<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMeisaiMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMeisaiMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.閉じるToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.出力ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXCECLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Labelkai = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label件数 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ComboBox顧客ID結合 = New System.Windows.Forms.ComboBox()
        Me.TextBox顧客ID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Buttonクリア = New System.Windows.Forms.Button()
        Me.Button検索 = New System.Windows.Forms.Button()
        Me.ComboBox都道府県 = New System.Windows.Forms.ComboBox()
        Me.ComboBox電話番号結合 = New System.Windows.Forms.ComboBox()
        Me.ComboBox電話番号パターン = New System.Windows.Forms.ComboBox()
        Me.TextBox電話番号 = New System.Windows.Forms.TextBox()
        Me.ComboBox市区町村結合 = New System.Windows.Forms.ComboBox()
        Me.ComboBox市区町村パターン = New System.Windows.Forms.ComboBox()
        Me.TextBox市区町村 = New System.Windows.Forms.TextBox()
        Me.ComboBox都道府県結合 = New System.Windows.Forms.ComboBox()
        Me.ComboBoxカナ結合 = New System.Windows.Forms.ComboBox()
        Me.ComboBoxカナパターン = New System.Windows.Forms.ComboBox()
        Me.TextBoxカナ = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBox氏名結合 = New System.Windows.Forms.ComboBox()
        Me.ComboBox氏名パターン = New System.Windows.Forms.ComboBox()
        Me.TextBox氏名 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.閉じるToolStripMenuItem, Me.出力ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.MenuStrip1.Size = New System.Drawing.Size(1284, 25)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '閉じるToolStripMenuItem
        '
        Me.閉じるToolStripMenuItem.Name = "閉じるToolStripMenuItem"
        Me.閉じるToolStripMenuItem.Size = New System.Drawing.Size(49, 19)
        Me.閉じるToolStripMenuItem.Text = "閉じる"
        '
        '出力ToolStripMenuItem
        '
        Me.出力ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EXCECLToolStripMenuItem})
        Me.出力ToolStripMenuItem.Name = "出力ToolStripMenuItem"
        Me.出力ToolStripMenuItem.Size = New System.Drawing.Size(43, 19)
        Me.出力ToolStripMenuItem.Text = "出力"
        '
        'EXCECLToolStripMenuItem
        '
        Me.EXCECLToolStripMenuItem.Name = "EXCECLToolStripMenuItem"
        Me.EXCECLToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.EXCECLToolStripMenuItem.Text = "EXCEL"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Labelkai, Me.Label件数})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 639)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 23, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1284, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Labelkai
        '
        Me.Labelkai.Name = "Labelkai"
        Me.Labelkai.Size = New System.Drawing.Size(119, 17)
        Me.Labelkai.Text = "ToolStripStatusLabel1"
        '
        'Label件数
        '
        Me.Label件数.Name = "Label件数"
        Me.Label件数.Size = New System.Drawing.Size(119, 17)
        Me.Label件数.Text = "ToolStripStatusLabel1"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox顧客ID結合)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox顧客ID)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Buttonクリア)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button検索)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox都道府県)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox電話番号結合)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox電話番号パターン)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox電話番号)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox市区町村結合)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox市区町村パターン)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox市区町村)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox都道府県結合)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxカナ結合)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxカナパターン)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxカナ)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox氏名結合)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox氏名パターン)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox氏名)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1284, 614)
        Me.SplitContainer1.SplitterDistance = 160
        Me.SplitContainer1.TabIndex = 3
        '
        'ComboBox顧客ID結合
        '
        Me.ComboBox顧客ID結合.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox顧客ID結合.FormattingEnabled = True
        Me.ComboBox顧客ID結合.Items.AddRange(New Object() {"", "かつ", "または"})
        Me.ComboBox顧客ID結合.Location = New System.Drawing.Point(391, 21)
        Me.ComboBox顧客ID結合.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComboBox顧客ID結合.Name = "ComboBox顧客ID結合"
        Me.ComboBox顧客ID結合.Size = New System.Drawing.Size(67, 27)
        Me.ComboBox顧客ID結合.TabIndex = 1
        '
        'TextBox顧客ID
        '
        Me.TextBox顧客ID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox顧客ID.Location = New System.Drawing.Point(102, 22)
        Me.TextBox顧客ID.Name = "TextBox顧客ID"
        Me.TextBox顧客ID.Size = New System.Drawing.Size(111, 26)
        Me.TextBox顧客ID.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 19)
        Me.Label2.TabIndex = 125
        Me.Label2.Text = "顧客ID"
        '
        'Buttonクリア
        '
        Me.Buttonクリア.BackColor = System.Drawing.Color.Yellow
        Me.Buttonクリア.Location = New System.Drawing.Point(1142, 122)
        Me.Buttonクリア.Name = "Buttonクリア"
        Me.Buttonクリア.Size = New System.Drawing.Size(133, 34)
        Me.Buttonクリア.TabIndex = 17
        Me.Buttonクリア.Text = "検索クリア"
        Me.Buttonクリア.UseVisualStyleBackColor = False
        '
        'Button検索
        '
        Me.Button検索.BackColor = System.Drawing.Color.Aqua
        Me.Button検索.Location = New System.Drawing.Point(1142, 9)
        Me.Button検索.Name = "Button検索"
        Me.Button検索.Size = New System.Drawing.Size(133, 110)
        Me.Button検索.TabIndex = 16
        Me.Button検索.Text = "検索"
        Me.Button検索.UseVisualStyleBackColor = False
        '
        'ComboBox都道府県
        '
        Me.ComboBox都道府県.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox都道府県.FormattingEnabled = True
        Me.ComboBox都道府県.Items.AddRange(New Object() {"", "北海道", "青森県", "岩手県", "宮城県", "秋田県", "山形県", "福島県", "茨城県", "栃木県", "群馬県", "埼玉県", "千葉県", "東京都", "神奈川県", "新潟県", "富山県", "石川県", "福井県", "山梨県", "長野県", "岐阜県", "静岡県", "愛知県", "三重県", "滋賀県", "京都府", "大阪府", "兵庫県", "奈良県", "和歌山県", "鳥取県", "島根県", "岡山県", "広島県", "山口県", "徳島県", "香川県", "愛媛県", "高知県", "福岡県", "佐賀県", "長崎県", "熊本県", "大分県", "宮崎県", "鹿児島県", "沖縄県"})
        Me.ComboBox都道府県.Location = New System.Drawing.Point(675, 25)
        Me.ComboBox都道府県.Name = "ComboBox都道府県"
        Me.ComboBox都道府県.Size = New System.Drawing.Size(199, 27)
        Me.ComboBox都道府県.TabIndex = 8
        '
        'ComboBox電話番号結合
        '
        Me.ComboBox電話番号結合.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox電話番号結合.FormattingEnabled = True
        Me.ComboBox電話番号結合.Items.AddRange(New Object() {"", "かつ", "または"})
        Me.ComboBox電話番号結合.Location = New System.Drawing.Point(965, 89)
        Me.ComboBox電話番号結合.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComboBox電話番号結合.Name = "ComboBox電話番号結合"
        Me.ComboBox電話番号結合.Size = New System.Drawing.Size(67, 27)
        Me.ComboBox電話番号結合.TabIndex = 15
        '
        'ComboBox電話番号パターン
        '
        Me.ComboBox電話番号パターン.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox電話番号パターン.FormattingEnabled = True
        Me.ComboBox電話番号パターン.Items.AddRange(New Object() {"一致", "前方", "後方", "部分"})
        Me.ComboBox電話番号パターン.Location = New System.Drawing.Point(880, 89)
        Me.ComboBox電話番号パターン.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComboBox電話番号パターン.Name = "ComboBox電話番号パターン"
        Me.ComboBox電話番号パターン.Size = New System.Drawing.Size(78, 27)
        Me.ComboBox電話番号パターン.TabIndex = 14
        '
        'TextBox電話番号
        '
        Me.TextBox電話番号.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox電話番号.Location = New System.Drawing.Point(674, 89)
        Me.TextBox電話番号.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TextBox電話番号.Name = "TextBox電話番号"
        Me.TextBox電話番号.Size = New System.Drawing.Size(200, 26)
        Me.TextBox電話番号.TabIndex = 13
        '
        'ComboBox市区町村結合
        '
        Me.ComboBox市区町村結合.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox市区町村結合.FormattingEnabled = True
        Me.ComboBox市区町村結合.Items.AddRange(New Object() {"", "かつ", "または"})
        Me.ComboBox市区町村結合.Location = New System.Drawing.Point(966, 57)
        Me.ComboBox市区町村結合.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComboBox市区町村結合.Name = "ComboBox市区町村結合"
        Me.ComboBox市区町村結合.Size = New System.Drawing.Size(67, 27)
        Me.ComboBox市区町村結合.TabIndex = 12
        '
        'ComboBox市区町村パターン
        '
        Me.ComboBox市区町村パターン.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox市区町村パターン.FormattingEnabled = True
        Me.ComboBox市区町村パターン.Items.AddRange(New Object() {"一致", "前方", "後方", "部分"})
        Me.ComboBox市区町村パターン.Location = New System.Drawing.Point(881, 57)
        Me.ComboBox市区町村パターン.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComboBox市区町村パターン.Name = "ComboBox市区町村パターン"
        Me.ComboBox市区町村パターン.Size = New System.Drawing.Size(78, 27)
        Me.ComboBox市区町村パターン.TabIndex = 11
        '
        'TextBox市区町村
        '
        Me.TextBox市区町村.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox市区町村.Location = New System.Drawing.Point(675, 57)
        Me.TextBox市区町村.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TextBox市区町村.Name = "TextBox市区町村"
        Me.TextBox市区町村.Size = New System.Drawing.Size(200, 26)
        Me.TextBox市区町村.TabIndex = 10
        '
        'ComboBox都道府県結合
        '
        Me.ComboBox都道府県結合.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox都道府県結合.FormattingEnabled = True
        Me.ComboBox都道府県結合.Items.AddRange(New Object() {"", "かつ", "または"})
        Me.ComboBox都道府県結合.Location = New System.Drawing.Point(966, 25)
        Me.ComboBox都道府県結合.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComboBox都道府県結合.Name = "ComboBox都道府県結合"
        Me.ComboBox都道府県結合.Size = New System.Drawing.Size(67, 27)
        Me.ComboBox都道府県結合.TabIndex = 9
        '
        'ComboBoxカナ結合
        '
        Me.ComboBoxカナ結合.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxカナ結合.FormattingEnabled = True
        Me.ComboBoxカナ結合.Items.AddRange(New Object() {"", "かつ", "または"})
        Me.ComboBoxカナ結合.Location = New System.Drawing.Point(391, 88)
        Me.ComboBoxカナ結合.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComboBoxカナ結合.Name = "ComboBoxカナ結合"
        Me.ComboBoxカナ結合.Size = New System.Drawing.Size(67, 27)
        Me.ComboBoxカナ結合.TabIndex = 7
        '
        'ComboBoxカナパターン
        '
        Me.ComboBoxカナパターン.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxカナパターン.FormattingEnabled = True
        Me.ComboBoxカナパターン.Items.AddRange(New Object() {"一致", "前方", "後方", "部分"})
        Me.ComboBoxカナパターン.Location = New System.Drawing.Point(306, 88)
        Me.ComboBoxカナパターン.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComboBoxカナパターン.Name = "ComboBoxカナパターン"
        Me.ComboBoxカナパターン.Size = New System.Drawing.Size(78, 27)
        Me.ComboBoxカナパターン.TabIndex = 6
        '
        'TextBoxカナ
        '
        Me.TextBoxカナ.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBoxカナ.Location = New System.Drawing.Point(102, 88)
        Me.TextBoxカナ.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TextBoxカナ.Name = "TextBoxカナ"
        Me.TextBoxカナ.Size = New System.Drawing.Size(200, 26)
        Me.TextBoxカナ.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(579, 93)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 19)
        Me.Label5.TabIndex = 111
        Me.Label5.Text = "電話番号"
        '
        'ComboBox氏名結合
        '
        Me.ComboBox氏名結合.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox氏名結合.FormattingEnabled = True
        Me.ComboBox氏名結合.Items.AddRange(New Object() {"", "かつ", "または"})
        Me.ComboBox氏名結合.Location = New System.Drawing.Point(391, 56)
        Me.ComboBox氏名結合.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComboBox氏名結合.Name = "ComboBox氏名結合"
        Me.ComboBox氏名結合.Size = New System.Drawing.Size(67, 27)
        Me.ComboBox氏名結合.TabIndex = 4
        '
        'ComboBox氏名パターン
        '
        Me.ComboBox氏名パターン.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox氏名パターン.FormattingEnabled = True
        Me.ComboBox氏名パターン.Items.AddRange(New Object() {"一致", "前方", "後方", "部分"})
        Me.ComboBox氏名パターン.Location = New System.Drawing.Point(306, 56)
        Me.ComboBox氏名パターン.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComboBox氏名パターン.Name = "ComboBox氏名パターン"
        Me.ComboBox氏名パターン.Size = New System.Drawing.Size(78, 27)
        Me.ComboBox氏名パターン.TabIndex = 3
        '
        'TextBox氏名
        '
        Me.TextBox氏名.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox氏名.Location = New System.Drawing.Point(102, 56)
        Me.TextBox氏名.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TextBox氏名.Name = "TextBox氏名"
        Me.TextBox氏名.Size = New System.Drawing.Size(200, 26)
        Me.TextBox氏名.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(580, 61)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 19)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "市区町村"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(582, 29)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 19)
        Me.Label3.TabIndex = 106
        Me.Label3.Text = "都道府県"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 92)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 19)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "フリガナ"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(50, 60)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 19)
        Me.Label6.TabIndex = 104
        Me.Label6.Text = "名前"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(1284, 450)
        Me.DataGridView1.TabIndex = 0
        '
        'FormMeisaiMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 661)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "FormMeisaiMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "明細検索"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 閉じるToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 出力ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EXCECLToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ComboBox都道府県 As ComboBox
    Friend WithEvents ComboBox電話番号結合 As ComboBox
    Friend WithEvents ComboBox電話番号パターン As ComboBox
    Friend WithEvents TextBox電話番号 As TextBox
    Friend WithEvents ComboBox市区町村結合 As ComboBox
    Friend WithEvents ComboBox市区町村パターン As ComboBox
    Friend WithEvents TextBox市区町村 As TextBox
    Friend WithEvents ComboBox都道府県結合 As ComboBox
    Friend WithEvents ComboBoxカナ結合 As ComboBox
    Friend WithEvents ComboBoxカナパターン As ComboBox
    Friend WithEvents TextBoxカナ As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboBox氏名結合 As ComboBox
    Friend WithEvents ComboBox氏名パターン As ComboBox
    Friend WithEvents TextBox氏名 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Buttonクリア As Button
    Friend WithEvents Button検索 As Button
    Friend WithEvents ComboBox顧客ID結合 As ComboBox
    Friend WithEvents TextBox顧客ID As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Labelkai As ToolStripStatusLabel
    Friend WithEvents Label件数 As ToolStripStatusLabel
End Class
