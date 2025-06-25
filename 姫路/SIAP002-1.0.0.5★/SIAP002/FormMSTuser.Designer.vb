<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMSTuser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMSTuser))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.閉じるToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.出力ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXCELToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Buttonクリア = New System.Windows.Forms.Button()
        Me.CheckBox管理者 = New System.Windows.Forms.CheckBox()
        Me.TextBoxユーザー名 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxパスワード = New System.Windows.Forms.TextBox()
        Me.TextBoxユーザーID = New System.Windows.Forms.TextBox()
        Me.Button削除 = New System.Windows.Forms.Button()
        Me.Button更新 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.MenuStrip1.Size = New System.Drawing.Size(884, 25)
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
        Me.出力ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EXCELToolStripMenuItem})
        Me.出力ToolStripMenuItem.Name = "出力ToolStripMenuItem"
        Me.出力ToolStripMenuItem.Size = New System.Drawing.Size(43, 19)
        Me.出力ToolStripMenuItem.Text = "出力"
        '
        'EXCELToolStripMenuItem
        '
        Me.EXCELToolStripMenuItem.Name = "EXCELToolStripMenuItem"
        Me.EXCELToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.EXCELToolStripMenuItem.Text = "EXCEL"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 539)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 18, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(884, 22)
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
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Buttonクリア)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBox管理者)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxユーザー名)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxパスワード)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxユーザーID)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button削除)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button更新)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(884, 514)
        Me.SplitContainer1.SplitterDistance = 113
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 2
        '
        'Buttonクリア
        '
        Me.Buttonクリア.BackColor = System.Drawing.Color.Yellow
        Me.Buttonクリア.Location = New System.Drawing.Point(558, 10)
        Me.Buttonクリア.Margin = New System.Windows.Forms.Padding(4)
        Me.Buttonクリア.Name = "Buttonクリア"
        Me.Buttonクリア.Size = New System.Drawing.Size(94, 29)
        Me.Buttonクリア.TabIndex = 19
        Me.Buttonクリア.Text = "クリア"
        Me.Buttonクリア.UseVisualStyleBackColor = False
        '
        'CheckBox管理者
        '
        Me.CheckBox管理者.AutoSize = True
        Me.CheckBox管理者.Location = New System.Drawing.Point(411, 81)
        Me.CheckBox管理者.Name = "CheckBox管理者"
        Me.CheckBox管理者.Size = New System.Drawing.Size(85, 23)
        Me.CheckBox管理者.TabIndex = 18
        Me.CheckBox管理者.Text = "管理者"
        Me.CheckBox管理者.UseVisualStyleBackColor = True
        '
        'TextBoxユーザー名
        '
        Me.TextBoxユーザー名.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextBoxユーザー名.Location = New System.Drawing.Point(115, 43)
        Me.TextBoxユーザー名.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxユーザー名.MaxLength = 20
        Me.TextBoxユーザー名.Name = "TextBoxユーザー名"
        Me.TextBoxユーザー名.Size = New System.Drawing.Size(217, 26)
        Me.TextBoxユーザー名.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 46)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 19)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "ユーザー名"
        '
        'TextBoxパスワード
        '
        Me.TextBoxパスワード.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBoxパスワード.Location = New System.Drawing.Point(115, 77)
        Me.TextBoxパスワード.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxパスワード.MaxLength = 8
        Me.TextBoxパスワード.Name = "TextBoxパスワード"
        Me.TextBoxパスワード.Size = New System.Drawing.Size(150, 26)
        Me.TextBoxパスワード.TabIndex = 2
        '
        'TextBoxユーザーID
        '
        Me.TextBoxユーザーID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBoxユーザーID.Location = New System.Drawing.Point(115, 9)
        Me.TextBoxユーザーID.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxユーザーID.MaxLength = 8
        Me.TextBoxユーザーID.Name = "TextBoxユーザーID"
        Me.TextBoxユーザーID.Size = New System.Drawing.Size(150, 26)
        Me.TextBoxユーザーID.TabIndex = 0
        '
        'Button削除
        '
        Me.Button削除.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button削除.Location = New System.Drawing.Point(760, 10)
        Me.Button削除.Margin = New System.Windows.Forms.Padding(4)
        Me.Button削除.Name = "Button削除"
        Me.Button削除.Size = New System.Drawing.Size(94, 29)
        Me.Button削除.TabIndex = 5
        Me.Button削除.Text = "削除"
        Me.Button削除.UseVisualStyleBackColor = False
        '
        'Button更新
        '
        Me.Button更新.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button更新.Location = New System.Drawing.Point(660, 10)
        Me.Button更新.Margin = New System.Windows.Forms.Padding(4)
        Me.Button更新.Name = "Button更新"
        Me.Button更新.Size = New System.Drawing.Size(94, 29)
        Me.Button更新.TabIndex = 4
        Me.Button更新.Text = "更新"
        Me.Button更新.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(359, 83)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 19)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "権限"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 82)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "パスワード"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ユーザーID"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(884, 396)
        Me.DataGridView1.TabIndex = 0
        '
        'FormMSTuser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "FormMSTuser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ユーザーマスタ"
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
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button削除 As Button
    Friend WithEvents Button更新 As Button
    Friend WithEvents TextBoxパスワード As TextBox
    Friend WithEvents TextBoxユーザーID As TextBox
    Friend WithEvents TextBoxユーザー名 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents 出力ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EXCELToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckBox管理者 As CheckBox
    Friend WithEvents Buttonクリア As Button
End Class
