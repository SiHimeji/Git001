<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSyuko
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.取り込みToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.出庫ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.訂正ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Button出庫取り込み = New System.Windows.Forms.Button()
        Me.Button検索出庫 = New System.Windows.Forms.Button()
        Me.TextBox出庫 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button訂正取り込み = New System.Windows.Forms.Button()
        Me.Button訂正 = New System.Windows.Forms.Button()
        Me.TextBox訂正 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了ToolStripMenuItem, Me.取り込みToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(649, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        '取り込みToolStripMenuItem
        '
        Me.取り込みToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.出庫ToolStripMenuItem, Me.訂正ToolStripMenuItem})
        Me.取り込みToolStripMenuItem.Name = "取り込みToolStripMenuItem"
        Me.取り込みToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.取り込みToolStripMenuItem.Text = "取り込み"
        '
        '出庫ToolStripMenuItem
        '
        Me.出庫ToolStripMenuItem.Name = "出庫ToolStripMenuItem"
        Me.出庫ToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.出庫ToolStripMenuItem.Text = "出庫"
        '
        '訂正ToolStripMenuItem
        '
        Me.訂正ToolStripMenuItem.Name = "訂正ToolStripMenuItem"
        Me.訂正ToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.訂正ToolStripMenuItem.Text = "訂正"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 157)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(649, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button出庫取り込み)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button検索出庫)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox出庫)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Button訂正取り込み)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Button訂正)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox訂正)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Size = New System.Drawing.Size(649, 133)
        Me.SplitContainer1.SplitterDistance = 58
        Me.SplitContainer1.TabIndex = 2
        '
        'Button出庫取り込み
        '
        Me.Button出庫取り込み.Location = New System.Drawing.Point(445, 24)
        Me.Button出庫取り込み.Name = "Button出庫取り込み"
        Me.Button出庫取り込み.Size = New System.Drawing.Size(75, 23)
        Me.Button出庫取り込み.TabIndex = 3
        Me.Button出庫取り込み.Text = "取り込み"
        Me.Button出庫取り込み.UseVisualStyleBackColor = True
        '
        'Button検索出庫
        '
        Me.Button検索出庫.Location = New System.Drawing.Point(364, 24)
        Me.Button検索出庫.Name = "Button検索出庫"
        Me.Button検索出庫.Size = New System.Drawing.Size(75, 23)
        Me.Button検索出庫.TabIndex = 2
        Me.Button検索出庫.Text = "検索"
        Me.Button検索出庫.UseVisualStyleBackColor = True
        '
        'TextBox出庫
        '
        Me.TextBox出庫.Location = New System.Drawing.Point(14, 26)
        Me.TextBox出庫.Name = "TextBox出庫"
        Me.TextBox出庫.Size = New System.Drawing.Size(343, 19)
        Me.TextBox出庫.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "出庫データ"
        '
        'Button訂正取り込み
        '
        Me.Button訂正取り込み.Location = New System.Drawing.Point(445, 20)
        Me.Button訂正取り込み.Name = "Button訂正取り込み"
        Me.Button訂正取り込み.Size = New System.Drawing.Size(75, 23)
        Me.Button訂正取り込み.TabIndex = 6
        Me.Button訂正取り込み.Text = "取り込み"
        Me.Button訂正取り込み.UseVisualStyleBackColor = True
        '
        'Button訂正
        '
        Me.Button訂正.Location = New System.Drawing.Point(364, 20)
        Me.Button訂正.Name = "Button訂正"
        Me.Button訂正.Size = New System.Drawing.Size(75, 23)
        Me.Button訂正.TabIndex = 5
        Me.Button訂正.Text = "検索"
        Me.Button訂正.UseVisualStyleBackColor = True
        '
        'TextBox訂正
        '
        Me.TextBox訂正.Location = New System.Drawing.Point(14, 22)
        Me.TextBox訂正.Name = "TextBox訂正"
        Me.TextBox訂正.Size = New System.Drawing.Size(343, 19)
        Me.TextBox訂正.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "訂正データ"
        '
        'FormSyuko
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(649, 179)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormSyuko"
        Me.Text = "出庫取り込み"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents 取り込みToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 出庫ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 訂正ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Button検索出庫 As Button
    Friend WithEvents TextBox出庫 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button訂正 As Button
    Friend WithEvents TextBox訂正 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button出庫取り込み As Button
    Friend WithEvents Button訂正取り込み As Button
End Class
