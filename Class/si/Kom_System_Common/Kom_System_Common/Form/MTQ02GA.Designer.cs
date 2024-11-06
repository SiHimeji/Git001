namespace Kom_System_Common
{
    partial class MTQ02GA
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
            this.sh_Nm = new System.Windows.Forms.TextBox();
            this.sh_Thcd = new System.Windows.Forms.TextBox();
            this.lbl_Nm = new Kom_System_Common.CommonClass.TitleLabel();
            this.lbl_Nmcd = new Kom_System_Common.CommonClass.TitleLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_Select = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.dgb_Torihikisaki = new System.Windows.Forms.DataGridView();
            this.RNUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.THCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RMEI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgb_Torihikisaki)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgb_Torihikisaki, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
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
            this.panel1.Controls.Add(this.sh_Thcd);
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
            this.btn_Search.Location = new System.Drawing.Point(647, 49);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(120, 30);
            this.btn_Search.TabIndex = 3;
            this.btn_Search.TabStop = false;
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
            // sh_Thcd
            // 
            this.sh_Thcd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.sh_Thcd.Location = new System.Drawing.Point(126, 11);
            this.sh_Thcd.Margin = new System.Windows.Forms.Padding(0);
            this.sh_Thcd.MaxLength = 10;
            this.sh_Thcd.Name = "sh_Thcd";
            this.sh_Thcd.Size = new System.Drawing.Size(100, 28);
            this.sh_Thcd.TabIndex = 1;
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
            this.lbl_Nm.TabIndex = 6;
            this.lbl_Nm.TabStop = false;
            this.lbl_Nm.Text = "名称・カナ";
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
            this.lbl_Nmcd.TabIndex = 5;
            this.lbl_Nmcd.TabStop = false;
            this.lbl_Nmcd.Text = "コード";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btn_Select);
            this.flowLayoutPanel1.Controls.Add(this.btn_Cancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 523);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(778, 35);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(648, 3);
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
            this.btn_Cancel.Location = new System.Drawing.Point(515, 3);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(120, 30);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.TabStop = false;
            this.btn_Cancel.Text = "終了(F9)";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgb_Torihikisaki
            // 
            this.dgb_Torihikisaki.AllowUserToAddRows = false;
            this.dgb_Torihikisaki.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(241)))), ((int)(((byte)(222)))));
            this.dgb_Torihikisaki.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgb_Torihikisaki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgb_Torihikisaki.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RNUM,
            this.THCD,
            this.RMEI});
            this.dgb_Torihikisaki.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgb_Torihikisaki.Location = new System.Drawing.Point(3, 107);
            this.dgb_Torihikisaki.Name = "dgb_Torihikisaki";
            this.dgb_Torihikisaki.RowTemplate.Height = 21;
            this.dgb_Torihikisaki.Size = new System.Drawing.Size(778, 410);
            this.dgb_Torihikisaki.TabIndex = 4;
            this.dgb_Torihikisaki.TabStop = false;
            this.dgb_Torihikisaki.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // RNUM
            // 
            this.RNUM.DataPropertyName = "RNUM";
            this.RNUM.HeaderText = "";
            this.RNUM.Name = "RNUM";
            this.RNUM.ReadOnly = true;
            this.RNUM.Width = 50;
            // 
            // THCD
            // 
            this.THCD.DataPropertyName = "THCD";
            this.THCD.HeaderText = "コード";
            this.THCD.Name = "THCD";
            this.THCD.ReadOnly = true;
            this.THCD.Width = 150;
            // 
            // RMEI
            // 
            this.RMEI.DataPropertyName = "RMEI";
            this.RMEI.HeaderText = "名称";
            this.RMEI.Name = "RMEI";
            this.RMEI.ReadOnly = true;
            this.RMEI.Width = 500;
            // 
            // MTQ02GA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("メイリオ", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MTQ02GA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "取引先検索";
            this.Load += new System.EventHandler(this.MTQ02GA_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MTQ02GA_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgb_Torihikisaki)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dgb_Torihikisaki;
        private System.Windows.Forms.DataGridViewTextBoxColumn RNUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn THCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn RMEI;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.TextBox sh_Nm;
        private System.Windows.Forms.TextBox sh_Thcd;
        private CommonClass.TitleLabel lbl_Nm;
        private CommonClass.TitleLabel lbl_Nmcd;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.Button btn_Cancel;
    }
}