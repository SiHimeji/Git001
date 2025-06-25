<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCSV
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCSV))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.閉じるToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabelIn = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelout = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label件数 = New System.Windows.Forms.Label()
        Me.Button更新 = New System.Windows.Forms.Button()
        Me.Button読込 = New System.Windows.Forms.Button()
        Me.Button検索 = New System.Windows.Forms.Button()
        Me.TextBoxFILE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.DataGridViewCSV = New System.Windows.Forms.DataGridView()
        Me.DataGridView累積 = New System.Windows.Forms.DataGridView()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.DataGridViewCSV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView累積, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.閉じるToolStripMenuItem})
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
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelIn, Me.ToolStripStatusLabelout})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 639)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 24, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1284, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabelIn
        '
        Me.ToolStripStatusLabelIn.Name = "ToolStripStatusLabelIn"
        Me.ToolStripStatusLabelIn.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabelIn.Text = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabelout
        '
        Me.ToolStripStatusLabelout.Name = "ToolStripStatusLabelout"
        Me.ToolStripStatusLabelout.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabelout.Text = "ToolStripStatusLabel1"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label件数)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button更新)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button読込)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button検索)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxFILE)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1284, 614)
        Me.SplitContainer1.SplitterDistance = 48
        Me.SplitContainer1.SplitterWidth = 6
        Me.SplitContainer1.TabIndex = 2
        '
        'Label件数
        '
        Me.Label件数.Location = New System.Drawing.Point(1177, 14)
        Me.Label件数.Name = "Label件数"
        Me.Label件数.Size = New System.Drawing.Size(100, 19)
        Me.Label件数.TabIndex = 106
        Me.Label件数.Text = "0件"
        Me.Label件数.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button更新
        '
        Me.Button更新.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button更新.Location = New System.Drawing.Point(929, 9)
        Me.Button更新.Name = "Button更新"
        Me.Button更新.Size = New System.Drawing.Size(115, 26)
        Me.Button更新.TabIndex = 4
        Me.Button更新.Text = "更新"
        Me.Button更新.UseMnemonic = False
        Me.Button更新.UseVisualStyleBackColor = False
        '
        'Button読込
        '
        Me.Button読込.BackColor = System.Drawing.Color.Aqua
        Me.Button読込.Location = New System.Drawing.Point(798, 9)
        Me.Button読込.Name = "Button読込"
        Me.Button読込.Size = New System.Drawing.Size(115, 26)
        Me.Button読込.TabIndex = 3
        Me.Button読込.Text = "読込開始"
        Me.Button読込.UseMnemonic = False
        Me.Button読込.UseVisualStyleBackColor = False
        '
        'Button検索
        '
        Me.Button検索.BackColor = System.Drawing.Color.Yellow
        Me.Button検索.Location = New System.Drawing.Point(677, 9)
        Me.Button検索.Name = "Button検索"
        Me.Button検索.Size = New System.Drawing.Size(115, 26)
        Me.Button検索.TabIndex = 2
        Me.Button検索.Text = "ファイル選択"
        Me.Button検索.UseVisualStyleBackColor = False
        '
        'TextBoxFILE
        '
        Me.TextBoxFILE.Location = New System.Drawing.Point(118, 9)
        Me.TextBoxFILE.Name = "TextBoxFILE"
        Me.TextBoxFILE.ReadOnly = True
        Me.TextBoxFILE.Size = New System.Drawing.Size(553, 26)
        Me.TextBoxFILE.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CSVファイル"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.DataGridViewCSV)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.DataGridView累積)
        Me.SplitContainer2.Size = New System.Drawing.Size(1284, 560)
        Me.SplitContainer2.SplitterDistance = 331
        Me.SplitContainer2.SplitterWidth = 6
        Me.SplitContainer2.TabIndex = 1
        '
        'DataGridViewCSV
        '
        Me.DataGridViewCSV.AllowUserToAddRows = False
        Me.DataGridViewCSV.AllowUserToDeleteRows = False
        Me.DataGridViewCSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewCSV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewCSV.Location = New System.Drawing.Point(0, 0)
        Me.DataGridViewCSV.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.DataGridViewCSV.Name = "DataGridViewCSV"
        Me.DataGridViewCSV.RowHeadersVisible = False
        Me.DataGridViewCSV.RowTemplate.Height = 21
        Me.DataGridViewCSV.Size = New System.Drawing.Size(1284, 331)
        Me.DataGridViewCSV.TabIndex = 0
        '
        'DataGridView累積
        '
        Me.DataGridView累積.AllowUserToAddRows = False
        Me.DataGridView累積.AllowUserToDeleteRows = False
        Me.DataGridView累積.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView累積.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView累積.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView累積.Name = "DataGridView累積"
        Me.DataGridView累積.RowHeadersVisible = False
        Me.DataGridView累積.RowTemplate.Height = 21
        Me.DataGridView累積.Size = New System.Drawing.Size(1284, 223)
        Me.DataGridView累積.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(1284, 560)
        Me.DataGridView1.TabIndex = 0
        '
        'FormCSV
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
        Me.Name = "FormCSV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CSV取り込み"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.DataGridViewCSV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView累積, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 閉じるToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents DataGridViewCSV As DataGridView
    Friend WithEvents TextBoxFILE As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button読込 As Button
    Friend WithEvents Button検索 As Button
    Friend WithEvents Button更新 As Button
    Friend WithEvents DataGridView累積 As DataGridView
    Friend WithEvents Label件数 As Label
    Friend WithEvents ToolStripStatusLabelIn As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelout As ToolStripStatusLabel
End Class
