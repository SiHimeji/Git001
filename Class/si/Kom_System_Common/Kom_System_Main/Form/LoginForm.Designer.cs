namespace Kom_System_Main
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_LoginUserId = new Kom_System_Common.CommonClass.TitleLabel();
            this.txt_LoginUserId = new System.Windows.Forms.TextBox();
            this.lbl_LoginUserName = new System.Windows.Forms.Label();
            this.btn_Login = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbl_Blank = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_ProgramId = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_Version = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_Title, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_Login, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("メイリオ", 9F);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(6, 0, 6, 8);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(624, 361);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbl_Title
            // 
            this.lbl_Title.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Title.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Title.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbl_Title.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbl_Title.Location = new System.Drawing.Point(64, 38);
            this.lbl_Title.Margin = new System.Windows.Forms.Padding(58, 38, 58, 38);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(496, 53);
            this.lbl_Title.TabIndex = 0;
            this.lbl_Title.Text = "■　Kom System　■";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.lbl_LoginUserId);
            this.flowLayoutPanel1.Controls.Add(this.txt_LoginUserId);
            this.flowLayoutPanel1.Controls.Add(this.lbl_LoginUserName);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(81, 160);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(462, 33);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // lbl_LoginUserId
            // 
            this.lbl_LoginUserId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(204)))), ((int)(((byte)(228)))));
            this.lbl_LoginUserId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_LoginUserId.Font = new System.Drawing.Font("メイリオ", 9F);
            this.lbl_LoginUserId.Location = new System.Drawing.Point(4, 4);
            this.lbl_LoginUserId.Margin = new System.Windows.Forms.Padding(4);
            this.lbl_LoginUserId.Name = "lbl_LoginUserId";
            this.lbl_LoginUserId.ReadOnly = true;
            this.lbl_LoginUserId.Size = new System.Drawing.Size(121, 25);
            this.lbl_LoginUserId.TabIndex = 2;
            this.lbl_LoginUserId.TabStop = false;
            this.lbl_LoginUserId.Text = "担当者コード";
            this.lbl_LoginUserId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_LoginUserId
            // 
            this.txt_LoginUserId.Font = new System.Drawing.Font("メイリオ", 9F);
            this.txt_LoginUserId.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_LoginUserId.Location = new System.Drawing.Point(133, 4);
            this.txt_LoginUserId.Margin = new System.Windows.Forms.Padding(4);
            this.txt_LoginUserId.MaxLength = 4;
            this.txt_LoginUserId.Name = "txt_LoginUserId";
            this.txt_LoginUserId.Size = new System.Drawing.Size(119, 25);
            this.txt_LoginUserId.TabIndex = 1;
            this.txt_LoginUserId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputComp);
            this.txt_LoginUserId.Validating += new System.ComponentModel.CancelEventHandler(this.UserIdValidate);
            // 
            // lbl_LoginUserName
            // 
            this.lbl_LoginUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_LoginUserName.Font = new System.Drawing.Font("メイリオ", 9F);
            this.lbl_LoginUserName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_LoginUserName.Location = new System.Drawing.Point(260, 4);
            this.lbl_LoginUserName.Margin = new System.Windows.Forms.Padding(4);
            this.lbl_LoginUserName.Name = "lbl_LoginUserName";
            this.lbl_LoginUserName.Size = new System.Drawing.Size(198, 25);
            this.lbl_LoginUserName.TabIndex = 3;
            this.lbl_LoginUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Login
            // 
            this.btn_Login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Login.AutoSize = true;
            this.btn_Login.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.btn_Login.Location = new System.Drawing.Point(212, 245);
            this.btn_Login.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(200, 56);
            this.btn_Login.TabIndex = 2;
            this.btn_Login.Text = "ログイン";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.BtnLoginClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_Blank,
            this.lbl_ProgramId,
            this.lbl_Version});
            this.statusStrip1.Location = new System.Drawing.Point(0, 339);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(624, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbl_Blank
            // 
            this.lbl_Blank.Name = "lbl_Blank";
            this.lbl_Blank.Size = new System.Drawing.Size(442, 17);
            this.lbl_Blank.Spring = true;
            // 
            // lbl_ProgramId
            // 
            this.lbl_ProgramId.Name = "lbl_ProgramId";
            this.lbl_ProgramId.Size = new System.Drawing.Size(104, 17);
            this.lbl_ProgramId.Text = "プログラムID：Login";
            // 
            // lbl_Version
            // 
            this.lbl_Version.Name = "lbl_Version";
            this.lbl_Version.Size = new System.Drawing.Size(63, 17);
            this.lbl_Version.Text = "バージョン：";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 361);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("メイリオ", 9F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ログイン";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginKeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txt_LoginUserId;
        private System.Windows.Forms.Button btn_Login;
        private Kom_System_Common.CommonClass.TitleLabel lbl_LoginUserId;
        private System.Windows.Forms.Label lbl_LoginUserName;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_Blank;
        private System.Windows.Forms.ToolStripStatusLabel lbl_ProgramId;
        private System.Windows.Forms.ToolStripStatusLabel lbl_Version;
    }
}