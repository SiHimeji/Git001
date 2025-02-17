
namespace CoRepView
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripComboBoxPRN = new System.Windows.Forms.ToolStripComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem印刷 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripComboBoxTRY = new System.Windows.Forms.ToolStripComboBox();
            this.ToolStripTextBoxPOSy = new System.Windows.Forms.ToolStripTextBox();
            this.cnView1 = new Hos.CnView.CnView();
            this.Label5577 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(62, 33);
            this.終了ToolStripMenuItem.Text = "終了";
            this.終了ToolStripMenuItem.Click += new System.EventHandler(this.終了ToolStripMenuItem_Click);
            // 
            // ToolStripComboBoxPRN
            // 
            this.ToolStripComboBoxPRN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ToolStripComboBoxPRN.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ToolStripComboBoxPRN.Name = "ToolStripComboBoxPRN";
            this.ToolStripComboBoxPRN.Size = new System.Drawing.Size(360, 33);
            this.ToolStripComboBoxPRN.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxPrinter_SelectedIndexChanged);
            this.ToolStripComboBoxPRN.Leave += new System.EventHandler(this.ToolStripComboBoxPRN_Leave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.終了ToolStripMenuItem,
            this.toolStripMenuItem印刷,
            this.ToolStripComboBoxPRN,
            this.ToolStripComboBoxTRY,
            this.ToolStripTextBoxPOSy});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(998, 37);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem印刷
            // 
            this.toolStripMenuItem印刷.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toolStripMenuItem印刷.Name = "toolStripMenuItem印刷";
            this.toolStripMenuItem印刷.Size = new System.Drawing.Size(62, 33);
            this.toolStripMenuItem印刷.Text = "印刷";
            this.toolStripMenuItem印刷.Click += new System.EventHandler(this.toolStripMenuItem印刷_Click);
            // 
            // ToolStripComboBoxTRY
            // 
            this.ToolStripComboBoxTRY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ToolStripComboBoxTRY.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ToolStripComboBoxTRY.Name = "ToolStripComboBoxTRY";
            this.ToolStripComboBoxTRY.Size = new System.Drawing.Size(240, 33);
            this.ToolStripComboBoxTRY.SelectedIndexChanged += new System.EventHandler(this.ToolStripComboBoxTRY_SelectedIndexChanged);
            // 
            // ToolStripTextBoxPOSy
            // 
            this.ToolStripTextBoxPOSy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ToolStripTextBoxPOSy.Name = "ToolStripTextBoxPOSy";
            this.ToolStripTextBoxPOSy.Size = new System.Drawing.Size(100, 33);
            this.ToolStripTextBoxPOSy.Leave += new System.EventHandler(this.ToolStripTextBoxPOSy_Leave);
            // 
            // cnView1
            // 
            this.cnView1.CausesValidation = false;
            this.cnView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cnView1.DocumentFileName = "";
            this.cnView1.DocumentPath = "";
            this.cnView1.DrawLevel = Hos.CnView.ConDrawLevel.Level3;
            this.cnView1.Flags = Hos.CnView.ConFlags.Unknown;
            this.cnView1.FormFrameColor = System.Drawing.Color.Red;
            this.cnView1.HardwareOffsetColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.cnView1.Location = new System.Drawing.Point(0, 37);
            this.cnView1.Name = "cnView1";
            this.cnView1.Page = -1;
            this.cnView1.PageTreeWidth = 127;
            this.cnView1.Password = "";
            this.cnView1.PasswordCrypto = false;
            this.cnView1.PreviewAtDesignLayer = false;
            this.cnView1.PrintMode = Hos.CnView.ConPrintMode.DocumentDefault;
            this.cnView1.ShowFormFrame = false;
            this.cnView1.ShowHardwareOffset = false;
            this.cnView1.ShowPageTree = false;
            this.cnView1.ShowStatusBar = true;
            this.cnView1.ShowToolBars = ((long)(7));
            this.cnView1.Size = new System.Drawing.Size(998, 483);
            this.cnView1.TabIndex = 2;
            this.cnView1.TouchMode = false;
            this.cnView1.Unit = Hos.CnView.ConUnit.Mm100;
            this.cnView1.ViewScale = 100;
            this.cnView1.ViewScaleMode = Hos.CnView.ConScaleMode.Value;
            this.cnView1.WorkPath = "";
            // 
            // Label5577
            // 
            this.Label5577.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Label5577.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label5577.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Label5577.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label5577.ForeColor = System.Drawing.Color.Red;
            this.Label5577.Location = new System.Drawing.Point(291, 158);
            this.Label5577.Name = "Label5577";
            this.Label5577.Size = new System.Drawing.Size(371, 174);
            this.Label5577.TabIndex = 3;
            this.Label5577.Text = "\r\n\r\n      プリンター５５７７が\r\n　     設定されていません";
            this.Label5577.Click += new System.EventHandler(this.Label5577_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 520);
            this.ControlBox = false;
            this.Controls.Add(this.Label5577);
            this.Controls.Add(this.cnView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "印刷プレビュー";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox ToolStripComboBoxPRN;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem印刷;
        private Hos.CnView.CnView cnView1;
        private System.Windows.Forms.ToolStripComboBox ToolStripComboBoxTRY;
        private System.Windows.Forms.ToolStripTextBox ToolStripTextBoxPOSy;
        internal System.Windows.Forms.Label Label5577;
    }
}