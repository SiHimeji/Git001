<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormKifuKensaku
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormKifuKensaku))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.閉じるToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.出力ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXCELToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ランク及び累積石高の通知ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.記念品送り状ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.記念品送り状WORDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.RadioButton送付日すべて = New System.Windows.Forms.RadioButton()
        Me.RadioButton最終送付日 = New System.Windows.Forms.RadioButton()
        Me.Button検索クリア = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ComboBox入金日結合 = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.DateTimePicker入金日To = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker入金日From = New System.Windows.Forms.DateTimePicker()
        Me.CheckBox全選択 = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ComboBox都道府県 = New System.Windows.Forms.ComboBox()
        Me.ComboBox記念品結合 = New System.Windows.Forms.ComboBox()
        Me.ComboBox累積石高結合 = New System.Windows.Forms.ComboBox()
        Me.ComboBox寄付金額結合 = New System.Windows.Forms.ComboBox()
        Me.Button検索 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.NumericUpDown寄附金額To = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown寄附金額From = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown累積石高To = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown累積石高From = New System.Windows.Forms.NumericUpDown()
        Me.DateTimePicker記念品送付日To = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker記念品送付日From = New System.Windows.Forms.DateTimePicker()
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
        Me.ComboBoxランク = New System.Windows.Forms.ComboBox()
        Me.ComboBoxランク結合 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBox氏名結合 = New System.Windows.Forms.ComboBox()
        Me.ComboBox氏名パターン = New System.Windows.Forms.ComboBox()
        Me.TextBox氏名 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button検索２ = New System.Windows.Forms.Button()
        Me.CheckBox全選択2 = New System.Windows.Forms.CheckBox()
        Me.RadioButtonランクアップ者 = New System.Windows.Forms.RadioButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.NumericUpDown寄附金額To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown寄附金額From, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown累積石高To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown累積石高From, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
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
        Me.MenuStrip1.TabIndex = 0
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
        Me.出力ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EXCELToolStripMenuItem, Me.ランク及び累積石高の通知ToolStripMenuItem, Me.記念品送り状ToolStripMenuItem, Me.記念品送り状WORDToolStripMenuItem})
        Me.出力ToolStripMenuItem.Name = "出力ToolStripMenuItem"
        Me.出力ToolStripMenuItem.Size = New System.Drawing.Size(43, 19)
        Me.出力ToolStripMenuItem.Text = "出力"
        '
        'EXCELToolStripMenuItem
        '
        Me.EXCELToolStripMenuItem.Name = "EXCELToolStripMenuItem"
        Me.EXCELToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.EXCELToolStripMenuItem.Text = "EXCEL"
        '
        'ランク及び累積石高の通知ToolStripMenuItem
        '
        Me.ランク及び累積石高の通知ToolStripMenuItem.Name = "ランク及び累積石高の通知ToolStripMenuItem"
        Me.ランク及び累積石高の通知ToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.ランク及び累積石高の通知ToolStripMenuItem.Text = "ランク及び累積石高の通知"
        '
        '記念品送り状ToolStripMenuItem
        '
        Me.記念品送り状ToolStripMenuItem.Name = "記念品送り状ToolStripMenuItem"
        Me.記念品送り状ToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.記念品送り状ToolStripMenuItem.Text = "記念品送り状"
        '
        '記念品送り状WORDToolStripMenuItem
        '
        Me.記念品送り状WORDToolStripMenuItem.Name = "記念品送り状WORDToolStripMenuItem"
        Me.記念品送り状WORDToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.記念品送り状WORDToolStripMenuItem.Text = "記念品送り状(WORD)"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 639)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 24, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1284, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(37, 17)
        Me.ToolStripStatusLabel1.Text = "120件"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(0, 17)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TabControl1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1284, 614)
        Me.SplitContainer1.SplitterDistance = 242
        Me.SplitContainer1.SplitterWidth = 6
        Me.SplitContainer1.TabIndex = 2
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1284, 242)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.RadioButton送付日すべて)
        Me.TabPage1.Controls.Add(Me.RadioButton最終送付日)
        Me.TabPage1.Controls.Add(Me.Button検索クリア)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.ComboBox入金日結合)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.DateTimePicker入金日To)
        Me.TabPage1.Controls.Add(Me.DateTimePicker入金日From)
        Me.TabPage1.Controls.Add(Me.CheckBox全選択)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.ComboBox都道府県)
        Me.TabPage1.Controls.Add(Me.ComboBox記念品結合)
        Me.TabPage1.Controls.Add(Me.ComboBox累積石高結合)
        Me.TabPage1.Controls.Add(Me.ComboBox寄付金額結合)
        Me.TabPage1.Controls.Add(Me.Button検索)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.NumericUpDown寄附金額To)
        Me.TabPage1.Controls.Add(Me.NumericUpDown寄附金額From)
        Me.TabPage1.Controls.Add(Me.NumericUpDown累積石高To)
        Me.TabPage1.Controls.Add(Me.NumericUpDown累積石高From)
        Me.TabPage1.Controls.Add(Me.DateTimePicker記念品送付日To)
        Me.TabPage1.Controls.Add(Me.DateTimePicker記念品送付日From)
        Me.TabPage1.Controls.Add(Me.ComboBox電話番号結合)
        Me.TabPage1.Controls.Add(Me.ComboBox電話番号パターン)
        Me.TabPage1.Controls.Add(Me.TextBox電話番号)
        Me.TabPage1.Controls.Add(Me.ComboBox市区町村結合)
        Me.TabPage1.Controls.Add(Me.ComboBox市区町村パターン)
        Me.TabPage1.Controls.Add(Me.TextBox市区町村)
        Me.TabPage1.Controls.Add(Me.ComboBox都道府県結合)
        Me.TabPage1.Controls.Add(Me.ComboBoxカナ結合)
        Me.TabPage1.Controls.Add(Me.ComboBoxカナパターン)
        Me.TabPage1.Controls.Add(Me.TextBoxカナ)
        Me.TabPage1.Controls.Add(Me.ComboBoxランク)
        Me.TabPage1.Controls.Add(Me.ComboBoxランク結合)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.ComboBox氏名結合)
        Me.TabPage1.Controls.Add(Me.ComboBox氏名パターン)
        Me.TabPage1.Controls.Add(Me.TextBox氏名)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1276, 209)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "検索１"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'RadioButton送付日すべて
        '
        Me.RadioButton送付日すべて.AutoSize = True
        Me.RadioButton送付日すべて.Location = New System.Drawing.Point(736, 77)
        Me.RadioButton送付日すべて.Name = "RadioButton送付日すべて"
        Me.RadioButton送付日すべて.Size = New System.Drawing.Size(131, 23)
        Me.RadioButton送付日すべて.TabIndex = 97
        Me.RadioButton送付日すべて.Text = "送付日すべて"
        Me.RadioButton送付日すべて.UseVisualStyleBackColor = True
        '
        'RadioButton最終送付日
        '
        Me.RadioButton最終送付日.AutoSize = True
        Me.RadioButton最終送付日.Checked = True
        Me.RadioButton最終送付日.Location = New System.Drawing.Point(608, 78)
        Me.RadioButton最終送付日.Name = "RadioButton最終送付日"
        Me.RadioButton最終送付日.Size = New System.Drawing.Size(122, 23)
        Me.RadioButton最終送付日.TabIndex = 96
        Me.RadioButton最終送付日.TabStop = True
        Me.RadioButton最終送付日.Text = "最終送付日"
        Me.RadioButton最終送付日.UseVisualStyleBackColor = True
        '
        'Button検索クリア
        '
        Me.Button検索クリア.BackColor = System.Drawing.Color.Yellow
        Me.Button検索クリア.Location = New System.Drawing.Point(1093, 179)
        Me.Button検索クリア.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Button検索クリア.Name = "Button検索クリア"
        Me.Button検索クリア.Size = New System.Drawing.Size(173, 26)
        Me.Button検索クリア.TabIndex = 31
        Me.Button検索クリア.Text = "検索クリア"
        Me.Button検索クリア.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(499, 174)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 19)
        Me.Label13.TabIndex = 94
        Me.Label13.Text = "最終入金日"
        '
        'ComboBox入金日結合
        '
        Me.ComboBox入金日結合.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox入金日結合.FormattingEnabled = True
        Me.ComboBox入金日結合.Items.AddRange(New Object() {"", "かつ", "または"})
        Me.ComboBox入金日結合.Location = New System.Drawing.Point(1005, 170)
        Me.ComboBox入金日結合.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComboBox入金日結合.Name = "ComboBox入金日結合"
        Me.ComboBox入金日結合.Size = New System.Drawing.Size(67, 27)
        Me.ComboBox入金日結合.TabIndex = 29
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(793, 174)
        Me.Label14.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(28, 19)
        Me.Label14.TabIndex = 93
        Me.Label14.Text = "～"
        '
        'DateTimePicker入金日To
        '
        Me.DateTimePicker入金日To.Location = New System.Drawing.Point(821, 170)
        Me.DateTimePicker入金日To.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.DateTimePicker入金日To.Name = "DateTimePicker入金日To"
        Me.DateTimePicker入金日To.Size = New System.Drawing.Size(176, 26)
        Me.DateTimePicker入金日To.TabIndex = 28
        Me.DateTimePicker入金日To.Value = New Date(2023, 10, 3, 11, 50, 46, 0)
        '
        'DateTimePicker入金日From
        '
        Me.DateTimePicker入金日From.Location = New System.Drawing.Point(608, 170)
        Me.DateTimePicker入金日From.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.DateTimePicker入金日From.Name = "DateTimePicker入金日From"
        Me.DateTimePicker入金日From.Size = New System.Drawing.Size(181, 26)
        Me.DateTimePicker入金日From.TabIndex = 27
        Me.DateTimePicker入金日From.Value = New Date(2023, 10, 1, 0, 0, 0, 0)
        '
        'CheckBox全選択
        '
        Me.CheckBox全選択.AutoSize = True
        Me.CheckBox全選択.Font = New System.Drawing.Font("MS UI Gothic", 14.0!)
        Me.CheckBox全選択.Location = New System.Drawing.Point(9, 186)
        Me.CheckBox全選択.Name = "CheckBox全選択"
        Me.CheckBox全選択.Size = New System.Drawing.Size(85, 23)
        Me.CheckBox全選択.TabIndex = 32
        Me.CheckBox全選択.Text = "全選択"
        Me.CheckBox全選択.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(481, 105)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(123, 19)
        Me.Label12.TabIndex = 88
        Me.Label12.Text = "記念品送付日"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(519, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 19)
        Me.Label11.TabIndex = 87
        Me.Label11.Text = "累積石高"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(555, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 19)
        Me.Label10.TabIndex = 86
        Me.Label10.Text = "ランク"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(482, 140)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(123, 19)
        Me.Label9.TabIndex = 85
        Me.Label9.Text = "累積寄附金額"
        '
        'ComboBox都道府県
        '
        Me.ComboBox都道府県.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox都道府県.FormattingEnabled = True
        Me.ComboBox都道府県.Items.AddRange(New Object() {"", "北海道", "青森県", "岩手県", "宮城県", "秋田県", "山形県", "福島県", "茨城県", "栃木県", "群馬県", "埼玉県", "千葉県", "東京都", "神奈川県", "新潟県", "富山県", "石川県", "福井県", "山梨県", "長野県", "岐阜県", "静岡県", "愛知県", "三重県", "滋賀県", "京都府", "大阪府", "兵庫県", "奈良県", "和歌山県", "鳥取県", "島根県", "岡山県", "広島県", "山口県", "徳島県", "香川県", "愛媛県", "高知県", "福岡県", "佐賀県", "長崎県", "熊本県", "大分県", "宮崎県", "鹿児島県", "沖縄県"})
        Me.ComboBox都道府県.Location = New System.Drawing.Point(91, 81)
        Me.ComboBox都道府県.Name = "ComboBox都道府県"
        Me.ComboBox都道府県.Size = New System.Drawing.Size(199, 27)
        Me.ComboBox都道府県.TabIndex = 6
        '
        'ComboBox記念品結合
        '
        Me.ComboBox記念品結合.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox記念品結合.FormattingEnabled = True
        Me.ComboBox記念品結合.Items.AddRange(New Object() {"", "かつ", "または"})
        Me.ComboBox記念品結合.Location = New System.Drawing.Point(1004, 102)
        Me.ComboBox記念品結合.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComboBox記念品結合.Name = "ComboBox記念品結合"
        Me.ComboBox記念品結合.Size = New System.Drawing.Size(67, 27)
        Me.ComboBox記念品結合.TabIndex = 23
        '
        'ComboBox累積石高結合
        '
        Me.ComboBox累積石高結合.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox累積石高結合.FormattingEnabled = True
        Me.ComboBox累積石高結合.Items.AddRange(New Object() {"", "かつ", "または"})
        Me.ComboBox累積石高結合.Location = New System.Drawing.Point(1005, 17)
        Me.ComboBox累積石高結合.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComboBox累積石高結合.Name = "ComboBox累積石高結合"
        Me.ComboBox累積石高結合.Size = New System.Drawing.Size(67, 27)
        Me.ComboBox累積石高結合.TabIndex = 16
        '
        'ComboBox寄付金額結合
        '
        Me.ComboBox寄付金額結合.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox寄付金額結合.FormattingEnabled = True
        Me.ComboBox寄付金額結合.Items.AddRange(New Object() {"", "かつ", "または"})
        Me.ComboBox寄付金額結合.Location = New System.Drawing.Point(1005, 136)
        Me.ComboBox寄付金額結合.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComboBox寄付金額結合.Name = "ComboBox寄付金額結合"
        Me.ComboBox寄付金額結合.Size = New System.Drawing.Size(67, 27)
        Me.ComboBox寄付金額結合.TabIndex = 26
        '
        'Button検索
        '
        Me.Button検索.BackColor = System.Drawing.Color.Aqua
        Me.Button検索.Location = New System.Drawing.Point(1093, 14)
        Me.Button検索.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Button検索.Name = "Button検索"
        Me.Button検索.Size = New System.Drawing.Size(173, 161)
        Me.Button検索.TabIndex = 30
        Me.Button検索.Text = "検索"
        Me.Button検索.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(792, 106)
        Me.Label8.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 19)
        Me.Label8.TabIndex = 79
        Me.Label8.Text = "～"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(793, 21)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 19)
        Me.Label7.TabIndex = 78
        Me.Label7.Text = "～"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(793, 140)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 19)
        Me.Label6.TabIndex = 77
        Me.Label6.Text = "～"
        '
        'NumericUpDown寄附金額To
        '
        Me.NumericUpDown寄附金額To.Location = New System.Drawing.Point(843, 136)
        Me.NumericUpDown寄附金額To.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.NumericUpDown寄附金額To.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.NumericUpDown寄附金額To.Name = "NumericUpDown寄附金額To"
        Me.NumericUpDown寄附金額To.Size = New System.Drawing.Size(154, 26)
        Me.NumericUpDown寄附金額To.TabIndex = 25
        Me.NumericUpDown寄附金額To.Value = New Decimal(New Integer() {5000, 0, 0, 0})
        '
        'NumericUpDown寄附金額From
        '
        Me.NumericUpDown寄附金額From.Location = New System.Drawing.Point(608, 136)
        Me.NumericUpDown寄附金額From.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.NumericUpDown寄附金額From.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.NumericUpDown寄附金額From.Name = "NumericUpDown寄附金額From"
        Me.NumericUpDown寄附金額From.Size = New System.Drawing.Size(154, 26)
        Me.NumericUpDown寄附金額From.TabIndex = 24
        '
        'NumericUpDown累積石高To
        '
        Me.NumericUpDown累積石高To.Location = New System.Drawing.Point(843, 17)
        Me.NumericUpDown累積石高To.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.NumericUpDown累積石高To.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.NumericUpDown累積石高To.Name = "NumericUpDown累積石高To"
        Me.NumericUpDown累積石高To.Size = New System.Drawing.Size(154, 26)
        Me.NumericUpDown累積石高To.TabIndex = 15
        Me.NumericUpDown累積石高To.Value = New Decimal(New Integer() {5000, 0, 0, 0})
        '
        'NumericUpDown累積石高From
        '
        Me.NumericUpDown累積石高From.Location = New System.Drawing.Point(608, 17)
        Me.NumericUpDown累積石高From.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.NumericUpDown累積石高From.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.NumericUpDown累積石高From.Name = "NumericUpDown累積石高From"
        Me.NumericUpDown累積石高From.Size = New System.Drawing.Size(154, 26)
        Me.NumericUpDown累積石高From.TabIndex = 14
        '
        'DateTimePicker記念品送付日To
        '
        Me.DateTimePicker記念品送付日To.Location = New System.Drawing.Point(820, 102)
        Me.DateTimePicker記念品送付日To.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.DateTimePicker記念品送付日To.Name = "DateTimePicker記念品送付日To"
        Me.DateTimePicker記念品送付日To.Size = New System.Drawing.Size(176, 26)
        Me.DateTimePicker記念品送付日To.TabIndex = 22
        Me.DateTimePicker記念品送付日To.Value = New Date(2023, 10, 3, 11, 50, 46, 0)
        '
        'DateTimePicker記念品送付日From
        '
        Me.DateTimePicker記念品送付日From.Location = New System.Drawing.Point(607, 102)
        Me.DateTimePicker記念品送付日From.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.DateTimePicker記念品送付日From.Name = "DateTimePicker記念品送付日From"
        Me.DateTimePicker記念品送付日From.Size = New System.Drawing.Size(181, 26)
        Me.DateTimePicker記念品送付日From.TabIndex = 21
        Me.DateTimePicker記念品送付日From.Value = New Date(2023, 10, 1, 0, 0, 0, 0)
        '
        'ComboBox電話番号結合
        '
        Me.ComboBox電話番号結合.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox電話番号結合.FormattingEnabled = True
        Me.ComboBox電話番号結合.Items.AddRange(New Object() {"", "かつ", "または"})
        Me.ComboBox電話番号結合.Location = New System.Drawing.Point(382, 148)
        Me.ComboBox電話番号結合.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComboBox電話番号結合.Name = "ComboBox電話番号結合"
        Me.ComboBox電話番号結合.Size = New System.Drawing.Size(67, 27)
        Me.ComboBox電話番号結合.TabIndex = 13
        '
        'ComboBox電話番号パターン
        '
        Me.ComboBox電話番号パターン.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox電話番号パターン.FormattingEnabled = True
        Me.ComboBox電話番号パターン.Items.AddRange(New Object() {"一致", "前方", "後方", "部分"})
        Me.ComboBox電話番号パターン.Location = New System.Drawing.Point(297, 148)
        Me.ComboBox電話番号パターン.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComboBox電話番号パターン.Name = "ComboBox電話番号パターン"
        Me.ComboBox電話番号パターン.Size = New System.Drawing.Size(78, 27)
        Me.ComboBox電話番号パターン.TabIndex = 12
        '
        'TextBox電話番号
        '
        Me.TextBox電話番号.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox電話番号.Location = New System.Drawing.Point(90, 148)
        Me.TextBox電話番号.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TextBox電話番号.Name = "TextBox電話番号"
        Me.TextBox電話番号.Size = New System.Drawing.Size(200, 26)
        Me.TextBox電話番号.TabIndex = 11
        '
        'ComboBox市区町村結合
        '
        Me.ComboBox市区町村結合.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox市区町村結合.FormattingEnabled = True
        Me.ComboBox市区町村結合.Items.AddRange(New Object() {"", "かつ", "または"})
        Me.ComboBox市区町村結合.Location = New System.Drawing.Point(383, 114)
        Me.ComboBox市区町村結合.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComboBox市区町村結合.Name = "ComboBox市区町村結合"
        Me.ComboBox市区町村結合.Size = New System.Drawing.Size(67, 27)
        Me.ComboBox市区町村結合.TabIndex = 10
        '
        'ComboBox市区町村パターン
        '
        Me.ComboBox市区町村パターン.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox市区町村パターン.FormattingEnabled = True
        Me.ComboBox市区町村パターン.Items.AddRange(New Object() {"一致", "前方", "後方", "部分"})
        Me.ComboBox市区町村パターン.Location = New System.Drawing.Point(298, 114)
        Me.ComboBox市区町村パターン.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComboBox市区町村パターン.Name = "ComboBox市区町村パターン"
        Me.ComboBox市区町村パターン.Size = New System.Drawing.Size(78, 27)
        Me.ComboBox市区町村パターン.TabIndex = 9
        '
        'TextBox市区町村
        '
        Me.TextBox市区町村.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox市区町村.Location = New System.Drawing.Point(91, 114)
        Me.TextBox市区町村.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TextBox市区町村.Name = "TextBox市区町村"
        Me.TextBox市区町村.Size = New System.Drawing.Size(200, 26)
        Me.TextBox市区町村.TabIndex = 8
        '
        'ComboBox都道府県結合
        '
        Me.ComboBox都道府県結合.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox都道府県結合.FormattingEnabled = True
        Me.ComboBox都道府県結合.Items.AddRange(New Object() {"", "かつ", "または"})
        Me.ComboBox都道府県結合.Location = New System.Drawing.Point(383, 81)
        Me.ComboBox都道府県結合.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComboBox都道府県結合.Name = "ComboBox都道府県結合"
        Me.ComboBox都道府県結合.Size = New System.Drawing.Size(67, 27)
        Me.ComboBox都道府県結合.TabIndex = 7
        '
        'ComboBoxカナ結合
        '
        Me.ComboBoxカナ結合.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxカナ結合.FormattingEnabled = True
        Me.ComboBoxカナ結合.Items.AddRange(New Object() {"", "かつ", "または"})
        Me.ComboBoxカナ結合.Location = New System.Drawing.Point(383, 49)
        Me.ComboBoxカナ結合.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComboBoxカナ結合.Name = "ComboBoxカナ結合"
        Me.ComboBoxカナ結合.Size = New System.Drawing.Size(67, 27)
        Me.ComboBoxカナ結合.TabIndex = 5
        '
        'ComboBoxカナパターン
        '
        Me.ComboBoxカナパターン.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxカナパターン.FormattingEnabled = True
        Me.ComboBoxカナパターン.Items.AddRange(New Object() {"一致", "前方", "後方", "部分"})
        Me.ComboBoxカナパターン.Location = New System.Drawing.Point(298, 49)
        Me.ComboBoxカナパターン.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComboBoxカナパターン.Name = "ComboBoxカナパターン"
        Me.ComboBoxカナパターン.Size = New System.Drawing.Size(78, 27)
        Me.ComboBoxカナパターン.TabIndex = 4
        '
        'TextBoxカナ
        '
        Me.TextBoxカナ.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBoxカナ.Location = New System.Drawing.Point(91, 49)
        Me.TextBoxカナ.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TextBoxカナ.Name = "TextBoxカナ"
        Me.TextBoxカナ.Size = New System.Drawing.Size(200, 26)
        Me.TextBoxカナ.TabIndex = 3
        '
        'ComboBoxランク
        '
        Me.ComboBoxランク.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxランク.FormattingEnabled = True
        Me.ComboBoxランク.Location = New System.Drawing.Point(608, 49)
        Me.ComboBoxランク.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComboBoxランク.Name = "ComboBoxランク"
        Me.ComboBoxランク.Size = New System.Drawing.Size(154, 27)
        Me.ComboBoxランク.TabIndex = 17
        '
        'ComboBoxランク結合
        '
        Me.ComboBoxランク結合.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxランク結合.FormattingEnabled = True
        Me.ComboBoxランク結合.Items.AddRange(New Object() {"", "かつ", "または"})
        Me.ComboBoxランク結合.Location = New System.Drawing.Point(1005, 49)
        Me.ComboBoxランク結合.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComboBoxランク結合.Name = "ComboBoxランク結合"
        Me.ComboBoxランク結合.Size = New System.Drawing.Size(67, 27)
        Me.ComboBoxランク結合.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 152)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 19)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "電話番号"
        '
        'ComboBox氏名結合
        '
        Me.ComboBox氏名結合.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox氏名結合.FormattingEnabled = True
        Me.ComboBox氏名結合.Items.AddRange(New Object() {"", "かつ", "または"})
        Me.ComboBox氏名結合.Location = New System.Drawing.Point(383, 17)
        Me.ComboBox氏名結合.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComboBox氏名結合.Name = "ComboBox氏名結合"
        Me.ComboBox氏名結合.Size = New System.Drawing.Size(67, 27)
        Me.ComboBox氏名結合.TabIndex = 2
        '
        'ComboBox氏名パターン
        '
        Me.ComboBox氏名パターン.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox氏名パターン.FormattingEnabled = True
        Me.ComboBox氏名パターン.Items.AddRange(New Object() {"一致", "前方", "後方", "部分"})
        Me.ComboBox氏名パターン.Location = New System.Drawing.Point(298, 17)
        Me.ComboBox氏名パターン.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ComboBox氏名パターン.Name = "ComboBox氏名パターン"
        Me.ComboBox氏名パターン.Size = New System.Drawing.Size(78, 27)
        Me.ComboBox氏名パターン.TabIndex = 1
        '
        'TextBox氏名
        '
        Me.TextBox氏名.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBox氏名.Location = New System.Drawing.Point(91, 17)
        Me.TextBox氏名.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TextBox氏名.Name = "TextBox氏名"
        Me.TextBox氏名.Size = New System.Drawing.Size(200, 26)
        Me.TextBox氏名.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 118)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 19)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "市区町村"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 85)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 19)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "都道府県"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 53)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 19)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "フリガナ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(44, 21)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 19)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "名前"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button検索２)
        Me.TabPage2.Controls.Add(Me.CheckBox全選択2)
        Me.TabPage2.Controls.Add(Me.RadioButtonランクアップ者)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1276, 216)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "検索２"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button検索２
        '
        Me.Button検索２.BackColor = System.Drawing.Color.Aqua
        Me.Button検索２.Location = New System.Drawing.Point(1093, 14)
        Me.Button検索２.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Button検索２.Name = "Button検索２"
        Me.Button検索２.Size = New System.Drawing.Size(173, 161)
        Me.Button検索２.TabIndex = 85
        Me.Button検索２.Text = "検索"
        Me.Button検索２.UseVisualStyleBackColor = False
        '
        'CheckBox全選択2
        '
        Me.CheckBox全選択2.AutoSize = True
        Me.CheckBox全選択2.Font = New System.Drawing.Font("MS UI Gothic", 14.0!)
        Me.CheckBox全選択2.Location = New System.Drawing.Point(8, 186)
        Me.CheckBox全選択2.Name = "CheckBox全選択2"
        Me.CheckBox全選択2.Size = New System.Drawing.Size(85, 23)
        Me.CheckBox全選択2.TabIndex = 90
        Me.CheckBox全選択2.Text = "全選択"
        Me.CheckBox全選択2.UseVisualStyleBackColor = True
        '
        'RadioButtonランクアップ者
        '
        Me.RadioButtonランクアップ者.AutoSize = True
        Me.RadioButtonランクアップ者.Checked = True
        Me.RadioButtonランクアップ者.Location = New System.Drawing.Point(19, 21)
        Me.RadioButtonランクアップ者.Name = "RadioButtonランクアップ者"
        Me.RadioButtonランクアップ者.Size = New System.Drawing.Size(270, 23)
        Me.RadioButtonランクアップ者.TabIndex = 83
        Me.RadioButtonランクアップ者.TabStop = True
        Me.RadioButtonランクアップ者.Text = "ランクアップ者(記念品未送付者)"
        Me.RadioButtonランクアップ者.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(1284, 366)
        Me.DataGridView1.TabIndex = 0
        '
        'FormKifuKensaku
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
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "FormKifuKensaku"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "寄附者検索"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.NumericUpDown寄附金額To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown寄附金額From, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown累積石高To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown累積石高From, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 閉じるToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents 出力ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EXCELToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ランク及び累積石高の通知ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents ComboBox記念品結合 As ComboBox
    Friend WithEvents ComboBox累積石高結合 As ComboBox
    Friend WithEvents ComboBox寄付金額結合 As ComboBox
    Friend WithEvents Button検索 As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents NumericUpDown寄附金額To As NumericUpDown
    Friend WithEvents NumericUpDown寄附金額From As NumericUpDown
    Friend WithEvents NumericUpDown累積石高To As NumericUpDown
    Friend WithEvents NumericUpDown累積石高From As NumericUpDown
    Friend WithEvents DateTimePicker記念品送付日To As DateTimePicker
    Friend WithEvents DateTimePicker記念品送付日From As DateTimePicker
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
    Friend WithEvents ComboBoxランク As ComboBox
    Friend WithEvents ComboBoxランク結合 As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboBox氏名結合 As ComboBox
    Friend WithEvents ComboBox氏名パターン As ComboBox
    Friend WithEvents TextBox氏名 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents ComboBox都道府県 As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents CheckBox全選択 As CheckBox
    Friend WithEvents RadioButtonランクアップ者 As RadioButton
    Friend WithEvents CheckBox全選択2 As CheckBox
    Friend WithEvents Button検索２ As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents ComboBox入金日結合 As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents DateTimePicker入金日To As DateTimePicker
    Friend WithEvents DateTimePicker入金日From As DateTimePicker
    Friend WithEvents Button検索クリア As Button
    Friend WithEvents 記念品送り状ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents RadioButton送付日すべて As RadioButton
    Friend WithEvents RadioButton最終送付日 As RadioButton
    Friend WithEvents 記念品送り状WORDToolStripMenuItem As ToolStripMenuItem
End Class
