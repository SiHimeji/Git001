namespace Kom_System_Common
{
    partial class MTQ03GA
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_LankSearch = new Kom_System_Common.CommonClass.SearchButton();
            this.sh_Lank = new System.Windows.Forms.TextBox();
            this.sh_Name3 = new System.Windows.Forms.TextBox();
            this.sh_Name2 = new System.Windows.Forms.TextBox();
            this.sh_Name1 = new System.Windows.Forms.TextBox();
            this.sh_Seicd = new System.Windows.Forms.TextBox();
            this.titleLabel3 = new Kom_System_Common.CommonClass.TitleLabel();
            this.titleLabel2 = new Kom_System_Common.CommonClass.TitleLabel();
            this.titleLabel4 = new Kom_System_Common.CommonClass.TitleLabel();
            this.titleLabel1 = new Kom_System_Common.CommonClass.TitleLabel();
            this.lbl_Seicd = new Kom_System_Common.CommonClass.TitleLabel();
            this.dgb_Seihin = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_Select = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.RNUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEICD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LANK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SITENAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgb_Seihin)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgb_Seihin, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1284, 729);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Search);
            this.panel1.Controls.Add(this.btn_LankSearch);
            this.panel1.Controls.Add(this.sh_Lank);
            this.panel1.Controls.Add(this.sh_Name3);
            this.panel1.Controls.Add(this.sh_Name2);
            this.panel1.Controls.Add(this.sh_Name1);
            this.panel1.Controls.Add(this.sh_Seicd);
            this.panel1.Controls.Add(this.titleLabel3);
            this.panel1.Controls.Add(this.titleLabel2);
            this.panel1.Controls.Add(this.titleLabel4);
            this.panel1.Controls.Add(this.titleLabel1);
            this.panel1.Controls.Add(this.lbl_Seicd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1258, 144);
            this.panel1.TabIndex = 0;
            // 
            // btn_Search
            // 
            this.btn_Search.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Search.Location = new System.Drawing.Point(1138, 108);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(120, 30);
            this.btn_Search.TabIndex = 5;
            this.btn_Search.TabStop = false;
            this.btn_Search.Text = "一覧(F1)";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btn_LankSearch
            // 
            this.btn_LankSearch.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_LankSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_LankSearch.Font = new System.Drawing.Font("メイリオ", 10.5F, System.Drawing.FontStyle.Bold);
            this.btn_LankSearch.Location = new System.Drawing.Point(760, 40);
            this.btn_LankSearch.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btn_LankSearch.Name = "btn_LankSearch";
            this.btn_LankSearch.Size = new System.Drawing.Size(30, 23);
            this.btn_LankSearch.TabIndex = 4;
            this.btn_LankSearch.TabStop = false;
            this.btn_LankSearch.Text = "…";
            this.btn_LankSearch.UseVisualStyleBackColor = false;
            this.btn_LankSearch.Click += new System.EventHandler(this.btnLankSearch_Click);
            // 
            // sh_Lank
            // 
            this.sh_Lank.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.sh_Lank.Location = new System.Drawing.Point(720, 38);
            this.sh_Lank.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.sh_Lank.MaxLength = 4;
            this.sh_Lank.Name = "sh_Lank";
            this.sh_Lank.Size = new System.Drawing.Size(40, 28);
            this.sh_Lank.TabIndex = 4;
            // 
            // sh_Name3
            // 
            this.sh_Name3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.sh_Name3.Location = new System.Drawing.Point(103, 108);
            this.sh_Name3.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.sh_Name3.MaxLength = 20;
            this.sh_Name3.Name = "sh_Name3";
            this.sh_Name3.Size = new System.Drawing.Size(500, 28);
            this.sh_Name3.TabIndex = 3;
            // 
            // sh_Name2
            // 
            this.sh_Name2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.sh_Name2.Location = new System.Drawing.Point(103, 72);
            this.sh_Name2.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.sh_Name2.MaxLength = 20;
            this.sh_Name2.Name = "sh_Name2";
            this.sh_Name2.Size = new System.Drawing.Size(250, 28);
            this.sh_Name2.TabIndex = 2;
            // 
            // sh_Name1
            // 
            this.sh_Name1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.sh_Name1.Location = new System.Drawing.Point(103, 37);
            this.sh_Name1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.sh_Name1.MaxLength = 20;
            this.sh_Name1.Name = "sh_Name1";
            this.sh_Name1.Size = new System.Drawing.Size(250, 28);
            this.sh_Name1.TabIndex = 1;
            // 
            // sh_Seicd
            // 
            this.sh_Seicd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.sh_Seicd.Location = new System.Drawing.Point(103, 2);
            this.sh_Seicd.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.sh_Seicd.MaxLength = 16;
            this.sh_Seicd.Name = "sh_Seicd";
            this.sh_Seicd.Size = new System.Drawing.Size(130, 28);
            this.sh_Seicd.TabIndex = 0;
            // 
            // titleLabel3
            // 
            this.titleLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(204)))), ((int)(((byte)(228)))));
            this.titleLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titleLabel3.Font = new System.Drawing.Font("メイリオ", 10.5F);
            this.titleLabel3.Location = new System.Drawing.Point(3, 108);
            this.titleLabel3.Margin = new System.Windows.Forms.Padding(3, 5, 0, 5);
            this.titleLabel3.Name = "titleLabel3";
            this.titleLabel3.ReadOnly = true;
            this.titleLabel3.Size = new System.Drawing.Size(100, 28);
            this.titleLabel3.TabIndex = 1;
            this.titleLabel3.TabStop = false;
            this.titleLabel3.Text = "寸法";
            // 
            // titleLabel2
            // 
            this.titleLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(204)))), ((int)(((byte)(228)))));
            this.titleLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titleLabel2.Font = new System.Drawing.Font("メイリオ", 10.5F);
            this.titleLabel2.Location = new System.Drawing.Point(3, 73);
            this.titleLabel2.Margin = new System.Windows.Forms.Padding(3, 5, 0, 5);
            this.titleLabel2.Name = "titleLabel2";
            this.titleLabel2.ReadOnly = true;
            this.titleLabel2.Size = new System.Drawing.Size(100, 28);
            this.titleLabel2.TabIndex = 1;
            this.titleLabel2.TabStop = false;
            this.titleLabel2.Text = "型式・形状";
            // 
            // titleLabel4
            // 
            this.titleLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(204)))), ((int)(((byte)(228)))));
            this.titleLabel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titleLabel4.Font = new System.Drawing.Font("メイリオ", 10.5F);
            this.titleLabel4.Location = new System.Drawing.Point(620, 38);
            this.titleLabel4.Margin = new System.Windows.Forms.Padding(3, 5, 0, 5);
            this.titleLabel4.Name = "titleLabel4";
            this.titleLabel4.ReadOnly = true;
            this.titleLabel4.Size = new System.Drawing.Size(100, 28);
            this.titleLabel4.TabIndex = 1;
            this.titleLabel4.TabStop = false;
            this.titleLabel4.Text = "製品ランク";
            // 
            // titleLabel1
            // 
            this.titleLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(204)))), ((int)(((byte)(228)))));
            this.titleLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titleLabel1.Font = new System.Drawing.Font("メイリオ", 10.5F);
            this.titleLabel1.Location = new System.Drawing.Point(3, 38);
            this.titleLabel1.Margin = new System.Windows.Forms.Padding(3, 5, 0, 5);
            this.titleLabel1.Name = "titleLabel1";
            this.titleLabel1.ReadOnly = true;
            this.titleLabel1.Size = new System.Drawing.Size(100, 28);
            this.titleLabel1.TabIndex = 1;
            this.titleLabel1.TabStop = false;
            this.titleLabel1.Text = "製品名";
            // 
            // lbl_Seicd
            // 
            this.lbl_Seicd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(204)))), ((int)(((byte)(228)))));
            this.lbl_Seicd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Seicd.Font = new System.Drawing.Font("メイリオ", 10.5F);
            this.lbl_Seicd.Location = new System.Drawing.Point(3, 3);
            this.lbl_Seicd.Margin = new System.Windows.Forms.Padding(3, 5, 0, 5);
            this.lbl_Seicd.Name = "lbl_Seicd";
            this.lbl_Seicd.ReadOnly = true;
            this.lbl_Seicd.Size = new System.Drawing.Size(100, 28);
            this.lbl_Seicd.TabIndex = 0;
            this.lbl_Seicd.TabStop = false;
            this.lbl_Seicd.Text = "製品コード";
            // 
            // dgb_Seihin
            // 
            this.dgb_Seihin.AllowUserToAddRows = false;
            this.dgb_Seihin.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(241)))), ((int)(((byte)(222)))));
            this.dgb_Seihin.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgb_Seihin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgb_Seihin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RNUM,
            this.SEICD,
            this.NAME1,
            this.NAME2,
            this.NAME3,
            this.LANK,
            this.SITENAME});
            this.dgb_Seihin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgb_Seihin.Location = new System.Drawing.Point(13, 163);
            this.dgb_Seihin.Name = "dgb_Seihin";
            this.dgb_Seihin.ReadOnly = true;
            this.dgb_Seihin.RowTemplate.Height = 21;
            this.dgb_Seihin.Size = new System.Drawing.Size(1258, 518);
            this.dgb_Seihin.TabIndex = 5;
            this.dgb_Seihin.TabStop = false;
            this.dgb_Seihin.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btn_Select);
            this.flowLayoutPanel1.Controls.Add(this.btn_Exit);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 687);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1258, 29);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(1138, 0);
            this.btn_Select.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(120, 30);
            this.btn_Select.TabIndex = 0;
            this.btn_Select.TabStop = false;
            this.btn_Select.Text = "選択(F5)";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(1015, 0);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(120, 30);
            this.btn_Exit.TabIndex = 1;
            this.btn_Exit.TabStop = false;
            this.btn_Exit.Text = "終了(F9)";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // RNUM
            // 
            this.RNUM.DataPropertyName = "RNUM";
            this.RNUM.Frozen = true;
            this.RNUM.HeaderText = "";
            this.RNUM.Name = "RNUM";
            this.RNUM.ReadOnly = true;
            this.RNUM.Width = 50;
            // 
            // SEICD
            // 
            this.SEICD.DataPropertyName = "SEICD";
            this.SEICD.Frozen = true;
            this.SEICD.HeaderText = "製品コード";
            this.SEICD.Name = "SEICD";
            this.SEICD.ReadOnly = true;
            this.SEICD.Width = 120;
            // 
            // NAME1
            // 
            this.NAME1.DataPropertyName = "NAME1";
            this.NAME1.Frozen = true;
            this.NAME1.HeaderText = "製品名";
            this.NAME1.Name = "NAME1";
            this.NAME1.ReadOnly = true;
            this.NAME1.Width = 200;
            // 
            // NAME2
            // 
            this.NAME2.DataPropertyName = "NAME2";
            this.NAME2.Frozen = true;
            this.NAME2.HeaderText = "型式・形状";
            this.NAME2.Name = "NAME2";
            this.NAME2.ReadOnly = true;
            this.NAME2.Width = 200;
            // 
            // NAME3
            // 
            this.NAME3.DataPropertyName = "NAME3";
            this.NAME3.Frozen = true;
            this.NAME3.HeaderText = "寸法";
            this.NAME3.Name = "NAME3";
            this.NAME3.ReadOnly = true;
            this.NAME3.Width = 300;
            // 
            // LANK
            // 
            this.LANK.DataPropertyName = "LANK";
            this.LANK.HeaderText = "製品ランク";
            this.LANK.Name = "LANK";
            this.LANK.ReadOnly = true;
            this.LANK.Width = 120;
            // 
            // SITENAME
            // 
            this.SITENAME.DataPropertyName = "SITENAME";
            this.SITENAME.HeaderText = "現場名";
            this.SITENAME.Name = "SITENAME";
            this.SITENAME.ReadOnly = true;
            this.SITENAME.Width = 300;
            // 
            // MTQ03GA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 729);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("メイリオ", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MTQ03GA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "製品M検索";
            this.Load += new System.EventHandler(this.MTQ03GA_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MTQ03GA_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgb_Seihin)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgb_Seihin;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.Button btn_Exit;
        private CommonClass.TitleLabel lbl_Seicd;
        private CommonClass.TitleLabel titleLabel1;
        private CommonClass.TitleLabel titleLabel3;
        private CommonClass.TitleLabel titleLabel2;
        private System.Windows.Forms.TextBox sh_Seicd;
        private System.Windows.Forms.TextBox sh_Name1;
        private System.Windows.Forms.TextBox sh_Name3;
        private System.Windows.Forms.TextBox sh_Name2;
        private CommonClass.TitleLabel titleLabel4;
        private System.Windows.Forms.TextBox sh_Lank;
        private CommonClass.SearchButton btn_LankSearch;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.DataGridViewTextBoxColumn RNUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEICD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME3;
        private System.Windows.Forms.DataGridViewTextBoxColumn LANK;
        private System.Windows.Forms.DataGridViewTextBoxColumn SITENAME;
    }
}