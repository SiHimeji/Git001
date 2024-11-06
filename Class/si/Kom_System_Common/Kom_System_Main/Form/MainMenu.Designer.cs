namespace Kom_System_Main
{
    partial class MainMenu
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("00.マスタ管理");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("01.受注管理");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("02.出荷管理");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("03.売上管理");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("04.債権管理");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("05.商品仕入管理");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("01.コントロールM保守");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("02.名称M保守");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("03.事業所M保守");
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.treeView1.Location = new System.Drawing.Point(14, 18);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "ノード0";
            treeNode1.Text = "00.マスタ管理";
            treeNode2.Name = "ノード1";
            treeNode2.Text = "01.受注管理";
            treeNode3.Name = "ノード2";
            treeNode3.Text = "02.出荷管理";
            treeNode4.Name = "ノード3";
            treeNode4.Text = "03.売上管理";
            treeNode5.Name = "ノード4";
            treeNode5.Text = "04.債権管理";
            treeNode6.Name = "ノード5";
            treeNode6.Text = "05.商品仕入管理";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            this.treeView1.Size = new System.Drawing.Size(300, 530);
            this.treeView1.TabIndex = 0;
            // 
            // treeView2
            // 
            this.treeView2.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.treeView2.Location = new System.Drawing.Point(322, 18);
            this.treeView2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeView2.Name = "treeView2";
            treeNode7.Name = "ノード0";
            treeNode7.Text = "01.コントロールM保守";
            treeNode8.Name = "ノード1";
            treeNode8.Text = "02.名称M保守";
            treeNode9.Name = "ノード2";
            treeNode9.Text = "03.事業所M保守";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9});
            this.treeView2.Size = new System.Drawing.Size(449, 530);
            this.treeView2.TabIndex = 1;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.treeView1);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainMenu";
            this.Text = "メインメニュー";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TreeView treeView2;
    }
}