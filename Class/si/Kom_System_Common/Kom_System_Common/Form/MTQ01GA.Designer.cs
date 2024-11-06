namespace Kom_System_Common
{
    partial class MTQ01GA
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Search = new System.Windows.Forms.Button();
            this.sh_Nm = new System.Windows.Forms.TextBox();
            this.sh_Nmcd = new System.Windows.Forms.TextBox();
            this.lbl_Nm = new Kom_System_Common.CommonClass.TitleLabel();
            this.lbl_Nmcd = new Kom_System_Common.CommonClass.TitleLabel();
            this.dgb_Meisho = new System.Windows.Forms.DataGridView();
            this.RNUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NMCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HYOJIJUN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_Select = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgb_Meisho)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgb_Meisho, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Search);
            this.panel1.Controls.Add(this.sh_Nm);
            this.panel1.Controls.Add(this.sh_Nmcd);
            this.panel1.Controls.Add(this.lbl_Nm);
            this.panel1.Controls.Add(this.lbl_Nmcd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 96);
            this.panel1.TabIndex = 0;
            // 
            // btn_Search
            // 
            this.btn_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Search.Font = new System.Drawing.Font("メイリオ", 10.5F);
            this.btn_Search.Location = new System.Drawing.Point(646, 49);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(120, 30);
            this.btn_Search.TabIndex = 3;
            this.btn_Search.Text = "一覧(F1)";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // sh_Nm
            // 
            this.sh_Nm.Location = new System.Drawing.Point(126, 49);
            this.sh_Nm.Margin = new System.Windows.Forms.Padding(0);
            this.sh_Nm.Name = "sh_Nm";
            this.sh_Nm.Size = new System.Drawing.Size(300, 28);
            this.sh_Nm.TabIndex = 2;
            // 
            // sh_Nmcd
            // 
            this.sh_Nmcd.Location = new System.Drawing.Point(126, 11);
            this.sh_Nmcd.Margin = new System.Windows.Forms.Padding(0);
            this.sh_Nmcd.Name = "sh_Nmcd";
            this.sh_Nmcd.Size = new System.Drawing.Size(100, 28);
            this.sh_Nmcd.TabIndex = 1;
            // 
            // lbl_Nm
            // 
            this.lbl_Nm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(204)))), ((int)(((byte)(228)))));
            this.lbl_Nm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Nm.Font = new System.Drawing.Font("メイリオ", 10.5F);
            this.lbl_Nm.Location = new System.Drawing.Point(10, 48);
            this.lbl_Nm.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.lbl_Nm.Name = "lbl_Nm";
            this.lbl_Nm.ReadOnly = true;
            this.lbl_Nm.Size = new System.Drawing.Size(116, 28);
            this.lbl_Nm.TabIndex = 1;
            this.lbl_Nm.TabStop = false;
            this.lbl_Nm.Text = "名称";
            this.lbl_Nm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_Nmcd
            // 
            this.lbl_Nmcd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(204)))), ((int)(((byte)(228)))));
            this.lbl_Nmcd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Nmcd.Font = new System.Drawing.Font("メイリオ", 10.5F);
            this.lbl_Nmcd.Location = new System.Drawing.Point(10, 10);
            this.lbl_Nmcd.Margin = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.lbl_Nmcd.Name = "lbl_Nmcd";
            this.lbl_Nmcd.ReadOnly = true;
            this.lbl_Nmcd.Size = new System.Drawing.Size(116, 28);
            this.lbl_Nmcd.TabIndex = 0;
            this.lbl_Nmcd.TabStop = false;
            this.lbl_Nmcd.Text = "コード";
            this.lbl_Nmcd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgb_Meisho
            // 
            this.dgb_Meisho.AllowUserToAddRows = false;
            this.dgb_Meisho.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(241)))), ((int)(((byte)(222)))));
            this.dgb_Meisho.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgb_Meisho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgb_Meisho.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RNUM,
            this.NMCD,
            this.NM,
            this.HYOJIJUN});
            this.dgb_Meisho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgb_Meisho.Location = new System.Drawing.Point(4, 108);
            this.dgb_Meisho.Margin = new System.Windows.Forms.Padding(4);
            this.dgb_Meisho.MultiSelect = false;
            this.dgb_Meisho.Name = "dgb_Meisho";
            this.dgb_Meisho.RowTemplate.Height = 21;
            this.dgb_Meisho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgb_Meisho.Size = new System.Drawing.Size(776, 408);
            this.dgb_Meisho.TabIndex = 4;
            this.dgb_Meisho.TabStop = false;
            this.dgb_Meisho.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgb_Meisho_CellContentClick);
            // 
            // RNUM
            // 
            this.RNUM.DataPropertyName = "RNUM";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.RNUM.DefaultCellStyle = dataGridViewCellStyle2;
            this.RNUM.HeaderText = "";
            this.RNUM.Name = "RNUM";
            this.RNUM.ReadOnly = true;
            this.RNUM.Width = 50;
            // 
            // NMCD
            // 
            this.NMCD.DataPropertyName = "NMCD";
            this.NMCD.HeaderText = "コード";
            this.NMCD.Name = "NMCD";
            this.NMCD.ReadOnly = true;
            this.NMCD.Width = 150;
            // 
            // NM
            // 
            this.NM.DataPropertyName = "NM";
            this.NM.HeaderText = "名称";
            this.NM.Name = "NM";
            this.NM.ReadOnly = true;
            this.NM.Width = 500;
            // 
            // HYOJIJUN
            // 
            this.HYOJIJUN.DataPropertyName = "HYOJIJUN";
            this.HYOJIJUN.HeaderText = "表示順";
            this.HYOJIJUN.Name = "HYOJIJUN";
            this.HYOJIJUN.ReadOnly = true;
            this.HYOJIJUN.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.btn_Select);
            this.flowLayoutPanel1.Controls.Add(this.btn_Cancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 524);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(776, 33);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btn_Select
            // 
            this.btn_Select.Font = new System.Drawing.Font("メイリオ", 10.5F);
            this.btn_Select.Location = new System.Drawing.Point(646, 3);
            this.btn_Select.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(120, 30);
            this.btn_Select.TabIndex = 6;
            this.btn_Select.TabStop = false;
            this.btn_Select.Text = "選択(F5)";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("メイリオ", 10.5F);
            this.btn_Cancel.Location = new System.Drawing.Point(513, 3);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(120, 30);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.TabStop = false;
            this.btn_Cancel.Text = "終了(F9)";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // MTQ01GA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("メイリオ", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MTQ01GA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "名称マスタ検索";
            this.Load += new System.EventHandler(this.MTQ01GA2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MTQ01GA2_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgb_Meisho)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private CommonClass.TitleLabel lbl_Nm;
        private CommonClass.TitleLabel lbl_Nmcd;
        private System.Windows.Forms.DataGridView dgb_Meisho;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.TextBox sh_Nm;
        private System.Windows.Forms.TextBox sh_Nmcd;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn RNUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn NMCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NM;
        private System.Windows.Forms.DataGridViewTextBoxColumn HYOJIJUN;
    }
}