<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMSTnayose
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMSTnayose))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.閉じるToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Button更新 = New System.Windows.Forms.Button()
        Me.ComboBox名前 = New System.Windows.Forms.ComboBox()
        Me.ComboBoxフリガナ = New System.Windows.Forms.ComboBox()
        Me.ComboBox都道府県 = New System.Windows.Forms.ComboBox()
        Me.ComboBox市区町村 = New System.Windows.Forms.ComboBox()
        Me.ComboBox番地マンション名 = New System.Windows.Forms.ComboBox()
        Me.ComboBox電話番号 = New System.Windows.Forms.ComboBox()
        Me.ComboBoxメール = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.閉じるToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(10, 3, 0, 3)
        Me.MenuStrip1.Size = New System.Drawing.Size(884, 25)
        Me.MenuStrip1.TabIndex = 8
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
        'Button更新
        '
        Me.Button更新.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button更新.Location = New System.Drawing.Point(660, 35)
        Me.Button更新.Margin = New System.Windows.Forms.Padding(4)
        Me.Button更新.Name = "Button更新"
        Me.Button更新.Size = New System.Drawing.Size(94, 29)
        Me.Button更新.TabIndex = 7
        Me.Button更新.Text = "更新"
        Me.Button更新.UseVisualStyleBackColor = False
        '
        'ComboBox名前
        '
        Me.ComboBox名前.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox名前.FormattingEnabled = True
        Me.ComboBox名前.Items.AddRange(New Object() {"", "1", "2", "3", "4", "5", "6", "7"})
        Me.ComboBox名前.Location = New System.Drawing.Point(336, 94)
        Me.ComboBox名前.Name = "ComboBox名前"
        Me.ComboBox名前.Size = New System.Drawing.Size(121, 27)
        Me.ComboBox名前.TabIndex = 0
        '
        'ComboBoxフリガナ
        '
        Me.ComboBoxフリガナ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxフリガナ.FormattingEnabled = True
        Me.ComboBoxフリガナ.Items.AddRange(New Object() {"", "1", "2", "3", "4", "5", "6", "7"})
        Me.ComboBoxフリガナ.Location = New System.Drawing.Point(336, 131)
        Me.ComboBoxフリガナ.Name = "ComboBoxフリガナ"
        Me.ComboBoxフリガナ.Size = New System.Drawing.Size(121, 27)
        Me.ComboBoxフリガナ.TabIndex = 1
        '
        'ComboBox都道府県
        '
        Me.ComboBox都道府県.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox都道府県.FormattingEnabled = True
        Me.ComboBox都道府県.Items.AddRange(New Object() {"", "1", "2", "3", "4", "5", "6", "7"})
        Me.ComboBox都道府県.Location = New System.Drawing.Point(336, 170)
        Me.ComboBox都道府県.Name = "ComboBox都道府県"
        Me.ComboBox都道府県.Size = New System.Drawing.Size(121, 27)
        Me.ComboBox都道府県.TabIndex = 2
        '
        'ComboBox市区町村
        '
        Me.ComboBox市区町村.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox市区町村.FormattingEnabled = True
        Me.ComboBox市区町村.Items.AddRange(New Object() {"", "1", "2", "3", "4", "5", "6", "7"})
        Me.ComboBox市区町村.Location = New System.Drawing.Point(336, 206)
        Me.ComboBox市区町村.Name = "ComboBox市区町村"
        Me.ComboBox市区町村.Size = New System.Drawing.Size(121, 27)
        Me.ComboBox市区町村.TabIndex = 3
        '
        'ComboBox番地マンション名
        '
        Me.ComboBox番地マンション名.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox番地マンション名.FormattingEnabled = True
        Me.ComboBox番地マンション名.Items.AddRange(New Object() {"", "1", "2", "3", "4", "5", "6", "7"})
        Me.ComboBox番地マンション名.Location = New System.Drawing.Point(336, 242)
        Me.ComboBox番地マンション名.Name = "ComboBox番地マンション名"
        Me.ComboBox番地マンション名.Size = New System.Drawing.Size(121, 27)
        Me.ComboBox番地マンション名.TabIndex = 4
        '
        'ComboBox電話番号
        '
        Me.ComboBox電話番号.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox電話番号.FormattingEnabled = True
        Me.ComboBox電話番号.Items.AddRange(New Object() {"", "1", "2", "3", "4", "5", "6", "7"})
        Me.ComboBox電話番号.Location = New System.Drawing.Point(336, 276)
        Me.ComboBox電話番号.Name = "ComboBox電話番号"
        Me.ComboBox電話番号.Size = New System.Drawing.Size(121, 27)
        Me.ComboBox電話番号.TabIndex = 5
        '
        'ComboBoxメール
        '
        Me.ComboBoxメール.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxメール.FormattingEnabled = True
        Me.ComboBoxメール.Items.AddRange(New Object() {"", "1", "2", "3", "4", "5", "6", "7"})
        Me.ComboBoxメール.Location = New System.Drawing.Point(336, 312)
        Me.ComboBoxメール.Name = "ComboBoxメール"
        Me.ComboBoxメール.Size = New System.Drawing.Size(121, 27)
        Me.ComboBoxメール.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(283, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 19)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "名前"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(267, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 19)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "フリガナ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(245, 174)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 19)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "都道府県"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(245, 210)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 19)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "市区町村"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(186, 246)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(144, 19)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "番地・マンション名"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(245, 280)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 19)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "電話番号"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(276, 316)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 19)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "メール"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(339, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 19)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "名寄せ順"
        '
        'FormMSTnayose
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBoxメール)
        Me.Controls.Add(Me.ComboBox電話番号)
        Me.Controls.Add(Me.ComboBox番地マンション名)
        Me.Controls.Add(Me.ComboBox市区町村)
        Me.Controls.Add(Me.ComboBox都道府県)
        Me.Controls.Add(Me.ComboBoxフリガナ)
        Me.Controls.Add(Me.ComboBox名前)
        Me.Controls.Add(Me.Button更新)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "FormMSTnayose"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "名寄せマスタ"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 閉じるToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents Button更新 As Button
    Friend WithEvents ComboBox名前 As ComboBox
    Friend WithEvents ComboBoxフリガナ As ComboBox
    Friend WithEvents ComboBox都道府県 As ComboBox
    Friend WithEvents ComboBox市区町村 As ComboBox
    Friend WithEvents ComboBox番地マンション名 As ComboBox
    Friend WithEvents ComboBox電話番号 As ComboBox
    Friend WithEvents ComboBoxメール As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
End Class
