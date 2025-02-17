 using Hos.CnView;
using System;
using System.Collections.Specialized;
using System.Deployment.Application;
using System.Web;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

/*
' \\Si-server2\web\CoReports\  
' \\Si-server2\web\CoReports\
'
'  ftp://scimco01.noritz.co.jp/CoReports/
'  http://scimco01.noritz.co.jp/CoReports/
'  ログイン：administrator																													
'  パスワード scimco01@2401                                                                                                                 
*/


namespace CoRepView
{
    public partial class FormMain : Form
    {

        string ver = "ver:ClickOnceバージョンが入ります";
        string update_date = "最終更新日:ClickOnce最終更新日が入ります";
        Boolean p5577 = false;
        string offsety = "";
        string coFileName = "";
        Boolean interrupt = true;


        public FormMain()
        {
            InitializeComponent();
        }
        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>
        private NameValueCollection GetQueryStringParameters()
        {
            NameValueCollection nameValueTable = new NameValueCollection();


            if (ApplicationDeployment.IsNetworkDeployed)
            {
                if (ApplicationDeployment.CurrentDeployment.ActivationUri != null)
                {
                    string queryString = ApplicationDeployment.CurrentDeployment.ActivationUri.Query;

                    nameValueTable = HttpUtility.ParseQueryString(queryString);
                }
            }
            return (nameValueTable);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                NameValueCollection collection = GetQueryStringParameters();
                if (collection.Count > 0)
                {

                    foreach (string key in collection.Keys)
                    {
                        if (key == "documentname")
                        {
                            coFileName = collection["documentname"];
                            //ドキュメントをオープン
                            if (cnView1.OpenDocument(coFileName) != ConError.NoError)
                            {
                                MessageBox.Show("ドキュメントが開けませんでした。", "CnViewForm");
                            }
                            else
                            {
                                //-Aが含まれる
                                if (0 <= coFileName.IndexOf("-A"))
                                {
                                    p5577 = true;
                                }
                                else
                                {
                                    p5577 = false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("本アプリケーションは単体で実行することはできません。", "CnViewForm");
                    //Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
                Close();
            }

            GetPrinter();
            DefPrinterGet();
            this.Label5577.Visible = false;
            this.ToolStripTextBoxPOSy.Visible = false;

            if (p5577)
            {
                Chk5577();
                offsety = ReadReg();
                if (offsety == "")
                {
                    offsety = "0";
                }
                this.ToolStripTextBoxPOSy.Text = offsety;
                this.ToolStripTextBoxPOSy.Visible = true;
                SetPageOffset();

            }

            this.cnView1.Printer = this.cnView1.Printers[this.ToolStripComboBoxPRN.Text];
            GetTry();
            interrupt = false;

            SetAppVer();
            this.Text = "CIM帳票印刷ビューワー    【" + ver + " " + update_date + "】";
            this.TopMost = !this.TopMost;

        }
        private void DefPrinterSet()
        {
            ClassLIB classLIB = new ClassLIB();
            classLIB.SetComboBox(this.ToolStripComboBoxPRN, this.ToolStripComboBoxPRN.Text);
        }

        private void DefPrinterGet()
        {
            ClassLIB classLIB = new ClassLIB();
            //PrintDocumentの作成
            System.Drawing.Printing.PrintDocument pd =
                new System.Drawing.Printing.PrintDocument();
            //プリンタ名の取得
            string defaultPrinterName = pd.PrinterSettings.PrinterName;
            //結果を表示
            this.ToolStripComboBoxPRN.Text = defaultPrinterName;
            classLIB.SetComboBox(this.ToolStripComboBoxPRN, this.ToolStripComboBoxPRN.Text);
        }
        /// <summary>
        /// プリンター取得
        /// </summary>
        private void GetPrinter()
        {
            this.ToolStripComboBoxPRN.Items.Clear();

            foreach (string s in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                this.ToolStripComboBoxPRN.Items.Add(s);
            }
        }
        /// <summary>
        /// CoRepotsのY方向オフセット
        /// </summary>
        private void SetPageOffset()
        {
            CnDocument document = cnView1.Document;
            for (int pg = 1; pg < document.AllPages+1; pg++)
            {
                document.SetOffsetY(pg, int.Parse(offsety));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param
        private void toolStripMenuItem印刷_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //印刷プリンター設定
            this.cnView1.Printer = this.cnView1.Printers[this.ToolStripComboBoxPRN.Text];
            //印刷実行
            this.cnView1.PrintOut();
            this.Cursor = Cursors.Default;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        /// <summary>
        /// 
        /// </summary>
        private void SetAppVer()
        {
            //初期値
            //現在のアプリケーションが ClickOnce アプリケーションかチェック
            //デバッグ時に呼び出すと例外になっちゃうので・・・。
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                //**バージョン取得
                ver = "ver(c#):" + ad.CurrentVersion.ToString() + "";
                //**最終更新日取得
                update_date = "最終更新日:" + ad.TimeOfLastUpdateCheck.ToLongDateString().ToString();
            }

        }
        /// <summary>//////////////////////////////////////////////////////
        /// 未使用
        /// </summary>
        private void GetUrlParameters()
        {
            // ClickOnceアプリの場合のときのみ以下のコードを実行
            if (ApplicationDeployment.IsNetworkDeployed == false)
            {
                return;
            }

            // 起動URLを取得
            string url = ApplicationDeployment.CurrentDeployment.ActivationUri.AbsoluteUri;


            // クエリ部分を抽出
            Uri myUri = new Uri(url);
            string queryString = myUri.Query;
            if (String.IsNullOrEmpty(queryString))
            {
                return;
            }

            // 各パラメータを分離して抽出
            string documentname = "無し";
            //string printer = "無し";
            string[] nameValuePairs = queryString.Split('&');
            foreach (string pair in nameValuePairs)
            {
                string[] vars = pair.Split('=');
                if (vars.Length != 2)
                {
                    continue;
                }
                vars[0] = vars[0].Replace("?", "");  // “?”は削る

                if (string.Compare(vars[0], "documentname", true) == 0)
                {
                    documentname = HttpUtility.UrlDecode(vars[1]);
                }
            }

            // 取得した各パラメータをメッセージボックスで表示
            MessageBox.Show(documentname + "");
        }
       /// <summary>
       /// 
       /// 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void toolStripComboBoxPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (interrupt) return;
            //印刷プリンター設定
            this.cnView1.Printer = this.cnView1.Printers[this.ToolStripComboBoxPRN.Text];
            GetTry();
        }
        private void ToolStripComboBoxPRN_Leave(object sender, EventArgs e)
        {
            //this.cnView1.Printer = this.cnView1.Printers[this.ToolStripComboBoxPRN.Text];
           // GetTry();

        }
        /////
        ///
        private void Chk5577()
        {
            for (int x = 0; x < this.ToolStripComboBoxPRN.Items.Count - 1; x++)
            {
                this.ToolStripComboBoxPRN.SelectedIndex = x;
                if (0 <= this.ToolStripComboBoxPRN.Text.IndexOf("5577"))
                {
                    return;
                }
            }
            DefPrinterSet();
            this.Label5577.Visible = true;
        }
        /// <summary>
        ///  5577 プリンターなし非表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label5577_Click(object sender, EventArgs e)
        {
            this.Label5577.Visible = false;
        }
        private void ToolStripComboBoxTRY_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTry();
        }
        /// <summary>
        ///  プリンタートレイを設定 
        /// </summary>
        private void SetTry()
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = this.ToolStripComboBoxPRN.Text;
            CnPrinter cnPrinter = cnView1.Printers[this.ToolStripComboBoxPRN.Text];
            foreach (PaperSource ps in printDoc.PrinterSettings.PaperSources)
            {
                string Nm = ps.SourceName; //'トレイ名 
                int no = ps.RawKind;       // 'トレイ番号 

                if (this.ToolStripComboBoxTRY.Text == Nm)
                {
                    cnPrinter.DefaultSource = no;
                    break;
                }
            }
            printDoc.Dispose();
        }
        /// <summary>
        ///  プリンタートレイを取得
        /// </summary>
        private void GetTry()
        {
            int printSelectNo = -1;
            string tryName = "";                                        //デフォルトのトレイ
            this.ToolStripComboBoxTRY.Items.Clear();


            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = this.ToolStripComboBoxPRN.Text;
            tryName = pd.DefaultPageSettings.PaperSource.SourceName;


            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = this.ToolStripComboBoxPRN.Text;
            CnPrinter cnPrinter = cnView1.Printers[this.ToolStripComboBoxPRN.Text];

            foreach (PaperSource ps in printDoc.PrinterSettings.PaperSources)
            {
                string tryNm = ps.SourceName;                               	//トレイ名 
                int tryno = tryno = ps.RawKind;                             	//トレイ番号 
                this.ToolStripComboBoxTRY.Items.Add(tryNm);

            }

            int i = 0;
            foreach (string nm in this.ToolStripComboBoxTRY.Items)
            {
                if (nm == tryName)
                {
                    printSelectNo = i;
                    break;
                }
            }
            this.ToolStripComboBoxTRY.SelectedIndex = printSelectNo;
            printDoc.Dispose();
        }

        /// <summary>
        ///  レジストリ読み込み
        /// </summary>
        private string ReadReg()
        {
            ClassLIB classLIB = new ClassLIB();
            return (classLIB.ReadReg("cnViewOffsetY"));
        }
        /// <summary>
        ///  レジストリ書き込み
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripTextBoxPOSy_Leave(object sender, EventArgs e)
        {
            ClassLIB classLIB = new ClassLIB();
            double d;
            if (double.TryParse(this.ToolStripTextBoxPOSy.Text, out d))
            {
                classLIB.WriteReg("cnViewOffsetY", this.ToolStripTextBoxPOSy.Text);
                offsety =  this.ToolStripTextBoxPOSy.Text;
                SetPageOffset();
            }
            else
            {
                MessageBox.Show("数字ではありません");
            }
        }

        /// <summary>
        /// 　全画面に表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCo_Leave(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }


        /// <summary>//////////////////////////////////////////////////////
    }
}
