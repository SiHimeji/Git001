using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Kom_System_Common.CommonClass
{
    public class FunctionControl
    {
        const int wfWidth = 1485;                           //フォームの Width 初期値
        const int wfHeight = 870;                           //フォームの Height 初期値
        const int wdtBtn = 98;                              //ボタンの  幅
        const int htBtn = 38;                               //ボタンの 高さ
        const int htBtn2 = 51;                               //右の文字高さ

        private Color defIns = Color.GreenYellow;           //追加のバックカラー
        private Color defUpdate = Color.Yellow;            //更新のバックカラー


        int[] leftPos = { 1, 90, 179, 268, 377, 466, 555, 644, 753, 842, 931, 1020 };  //2024/10/07　位置微調整 CF

        private Button[] myFunction;
        private Label[] MyLavel;
        private Label[] KousinLavel;
        private Form form;
        private string[] FuncText = { "", "", "", "", "", "", "", "", "", "", "", "" };
        private string myLogin;
        private string myGijyosyo;
        private string myGijyosyoNo;
        private string myLoginNo;
        public FunctionControl(Form fm)
        {
            this.form = fm;
        }

        #region "プロパティ"
        /// <summary>
        /// 更新・追加　TEXTの内容を表示　　　追加 2024/10/01 CF
        ///  空白の場合は Visible = false;
        /// </summary>
        /// 
        public string kousinflg
        {
            get { return this.KousinLavel[0].Text; }     // 
            set
            {
                switch (value)
                {
                    case "0":
                        this.KousinLavel[0].Text = "";
                        this.KousinLavel[0].Visible = false;
                        break;
                    case "1":       //
                        this.KousinLavel[0].Text = "登録";
                        this.KousinLavel[0].Visible = true;
                        this.KousinLavel[0].BackColor = defIns;
                        break;
                    case "2":       //
                        this.KousinLavel[0].Text = "変更";
                        this.KousinLavel[0].Visible = true;
                        this.KousinLavel[0].BackColor = defUpdate;
                        break;
                }

            }
        }
        /// <summary>
        /// /
        /// </summary>
        public string kousin
        {
            get { return this.KousinLavel[0].Text; }     // 
            set
            {
                this.KousinLavel[0].Text = value;
                if (this.KousinLavel[0].Text == "") this.KousinLavel[0].Visible = false;
                else this.KousinLavel[0].Visible = true;
            }    //
        }
        /// <summary>
        /// バックカラーを設定する
        /// </summary>
        public Color kousinBackcolor
        {
            get { return this.KousinLavel[0].BackColor; }     // 
            set { this.KousinLavel[0].BackColor = value; }    //

        }
        public string Gijyosyo
        {
            get { return myGijyosyo; }     // 
            set { myGijyosyo = value; }    //
        }
        public string GijyosyoNo
        {
            get { return myGijyosyoNo; }     // 
            set { myGijyosyoNo = value; }    //
        }

        /// <summary>
        /// LOogin者の名前を設定
        /// </summary>
        public string Login
        {
            get { return myLogin; }     // 
            set { myLogin = value; }    //
        }
        public string LoginNo
        {
            get { return myLoginNo; }     // 
            set { myLoginNo = value; }    //
        }

        /// <summary>
        /// Fｘボタンの表示
        /// </summary>
        public string F1
        {
            get { return FuncText[0]; }     // 
            set { FuncText[0] = value; }    //
        }
        public string F2
        {
            get { return FuncText[1]; }     // 
            set { FuncText[1] = value; }    //
        }
        public string F3
        {
            get { return FuncText[2]; }     // 
            set { FuncText[2] = value; }    //
        }
        public string F4
        {
            get { return FuncText[3]; }     // 
            set { FuncText[3] = value; }    //
        }
        public string F5
        {
            get { return FuncText[4]; }     // 
            set { FuncText[4] = value; }    //
        }
        public string F6
        {
            get { return FuncText[5]; }     // 
            set { FuncText[5] = value; }    //
        }
        public string F7
        {
            get { return FuncText[6]; }     // 
            set { FuncText[6] = value; }    //
        }
        public string F8
        {
            get { return FuncText[7]; }     // 
            set { FuncText[7] = value; }    //
        }
        public string F9
        {
            get { return FuncText[8]; }     // 
            set { FuncText[8] = value; }    //
        }
        public string F10
        {
            get { return FuncText[9]; }     // 
            set { FuncText[9] = value; }    //
        }
        public string F11
        {
            get { return FuncText[10]; }     // 
            set { FuncText[10] = value; }    //
        }


        public string F12
        {
            get { return FuncText[11]; }     // 
            set { FuncText[11] = value; }    //
        }
        #endregion
        /// <summary>
        /// FUNCTIONの表示
        /// </summary>
        public void FunctionControlDisp()
        {
            /////////////////////////////////////////////////////////////////
            this.myFunction = new Button[12];
            for (int i = 0; i < this.myFunction.Length; i++)
            {
                this.myFunction[i] = new Button();

                // コントロールのプロパティ
                this.myFunction[i].Name = "Function" + (i + 1);
                this.myFunction[i].Text = FuncText[i];

                this.myFunction[i].Width = wdtBtn;
                this.myFunction[i].Height = htBtn;
                this.myFunction[i].Top = 3;
                this.myFunction[i].Left = leftPos[i];
                this.myFunction[i].TabStop = false;
                this.myFunction[i].BackColor = Color.LightGray;
                this.myFunction[i].FlatStyle = FlatStyle.Flat;
                this.myFunction[i].Font = new System.Drawing.Font("メイリオ", 10.5f);

                // フォームへの追加
                this.form.Controls.Add(this.myFunction[i]);
                // Clickイベントハンドラを追加する
                #region "イベント追加"               
                switch (i)
                {
                    case 0:
                        this.myFunction[i].Click += new EventHandler(Function1_Click);
                        break;
                    case 1:
                        this.myFunction[i].Click += new EventHandler(Function2_Click);
                        break;
                    case 2:
                        this.myFunction[i].Click += new EventHandler(Function3_Click);
                        break;
                    case 3:
                        this.myFunction[i].Click += new EventHandler(Function4_Click);
                        break;
                    case 4:
                        this.myFunction[i].Click += new EventHandler(Function5_Click);
                        break;
                    case 5:
                        this.myFunction[i].Click += new EventHandler(Function6_Click);
                        break;
                    case 6:
                        this.myFunction[i].Click += new EventHandler(Function7_Click);
                        break;
                    case 7:
                        this.myFunction[i].Click += new EventHandler(Function8_Click);
                        break;
                    case 8:
                        this.myFunction[i].Click += new EventHandler(Function9_Click);
                        break;
                    case 9:
                        this.myFunction[i].Click += new EventHandler(Function10_Click);
                        break;
                    case 10:
                        this.myFunction[i].Click += new EventHandler(Function11_Click);
                        break;
                    case 11:
                        this.myFunction[i].Click += new EventHandler(Function12_Click);
                        break;

                }
                #endregion
                this.myFunction[i].BringToFront();
            }
            //前面へ
            ////////////////////////////////////////////////////////////
            // ラベル追加
            //  LOGIN名
            //  system日
            //
            this.MyLavel = new Label[7];
            /////
            this.MyLavel[0] = new Label();
            this.MyLavel[0].Name = "LabelGijyosyo";
            this.MyLavel[0].Text = "事業所：";          // + myGijyosyo;
            this.MyLavel[0].Width = wdtBtn * 1;         //横幅
            this.MyLavel[0].Height = htBtn2 / 3;        //縦
            this.MyLavel[0].Top = 3 + ((htBtn2 / 3) * 0);
            this.MyLavel[0].Left = leftPos[11] + wdtBtn + 80;//  
            this.MyLavel[0].Font = new System.Drawing.Font("メイリオ", 10.5f);
            this.MyLavel[0].TextAlign = System.Drawing.ContentAlignment.MiddleRight;            
            this.form.Controls.Add(this.MyLavel[0]);    // フォームへの追加
            this.MyLavel[0].BringToFront();

            ///////
            this.MyLavel[1] = new Label();
            this.MyLavel[1].Name = "LabelLogin";
            this.MyLavel[1].Text = "ログイン：";// + myLogin
            this.MyLavel[1].Width = wdtBtn * 1;         //横幅
            this.MyLavel[1].Height = htBtn2 / 3;         //縦
            this.MyLavel[1].Top = 3 + ((htBtn2 / 3) * 1);
            this.MyLavel[1].Left = leftPos[11] + wdtBtn + 80;//  
            this.MyLavel[1].Font = new System.Drawing.Font("メイリオ", 10.5f);
            this.MyLavel[1].TextAlign=System.Drawing.ContentAlignment.MiddleRight;                         
            this.form.Controls.Add(this.MyLavel[1]);// フォームへの追加
            this.MyLavel[1].BringToFront();

            ///////
            this.MyLavel[2] = new Label();
            this.MyLavel[2].Name = "LabelToDay";
            this.MyLavel[2].Text = DateTime.Today.ToShortDateString();
            this.MyLavel[2].Width = wdtBtn * 2;
            this.MyLavel[2].Height = htBtn2 / 3;
            this.MyLavel[2].Top = 3 + ((htBtn2 / 3) * 2);
            this.MyLavel[2].Left = leftPos[11] + wdtBtn + 80;
            this.MyLavel[2].Font = new System.Drawing.Font("メイリオ", 10.5f);
            this.MyLavel[2].TextAlign = System.Drawing.ContentAlignment.MiddleRight;            
            this.form.Controls.Add(this.MyLavel[2]);// フォームへの追加
            this.MyLavel[2].BringToFront();
            /////////////////

            this.MyLavel[3] = new Label();
            this.MyLavel[3].Name = "LabelGijyosyoNo";
            this.MyLavel[3].Text = myGijyosyoNo;
            this.MyLavel[3].Width = wdtBtn /2;         //横幅
            this.MyLavel[3].Height = htBtn2 / 3;        //縦
            this.MyLavel[3].Top = 3 + ((htBtn2 / 3) * 0);
            this.MyLavel[3].Left = leftPos[11] + wdtBtn + 70 + (wdtBtn * 1);//  
            this.MyLavel[3].Font = new System.Drawing.Font("メイリオ", 10.5f);
            this.MyLavel[3].TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.form.Controls.Add(this.MyLavel[3]);    // フォームへの追加
            this.MyLavel[3].BringToFront();

            ///////
            this.MyLavel[4] = new Label();
            this.MyLavel[4].Name = "LabelLoginNo";
            this.MyLavel[4].Text = myLoginNo;
            this.MyLavel[4].Width = wdtBtn /2;         //横幅
            this.MyLavel[4].Height = htBtn2 / 3;         //縦
            this.MyLavel[4].Top = 3 + ((htBtn2 / 3) * 1);
            this.MyLavel[4].Left = leftPos[11] + wdtBtn + 70 + (wdtBtn * 1);//  
            this.MyLavel[4].Font = new System.Drawing.Font("メイリオ", 10.5f);
            this.MyLavel[4].TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.form.Controls.Add(this.MyLavel[4]);// フォームへの追加
            this.MyLavel[4].BringToFront();
            ////
            this.MyLavel[5] = new Label();
            this.MyLavel[5].Name = "LabelGijyosyo";
            this.MyLavel[5].Text = myGijyosyo;
            this.MyLavel[5].Width = wdtBtn / 1;         //横幅
            this.MyLavel[5].Height = htBtn2 / 3;        //縦
            this.MyLavel[5].Top = 3 + ((htBtn2 / 3) * 0);
            this.MyLavel[5].Left = leftPos[11] + wdtBtn + 70 + (wdtBtn * 1)+(wdtBtn / 2);//  
            this.MyLavel[5].Font = new System.Drawing.Font("メイリオ", 10.5f);
            this.MyLavel[5].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.form.Controls.Add(this.MyLavel[5]);    // フォームへの追加
            this.MyLavel[5].BringToFront();

            ///////
            this.MyLavel[6] = new Label();
            this.MyLavel[6].Name = "LabelLogin";
            this.MyLavel[6].Text = myLogin;
            this.MyLavel[6].Width = wdtBtn / 1;         //横幅
            this.MyLavel[6].Height = htBtn2 / 3;         //縦
            this.MyLavel[6].Top = 3 + ((htBtn2 / 3) * 1);
            this.MyLavel[6].Left = leftPos[11] + wdtBtn + 70 + (wdtBtn * 1)+(wdtBtn / 2);//  
            this.MyLavel[6].Font = new System.Drawing.Font("メイリオ", 10.5f);
            this.MyLavel[6].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.form.Controls.Add(this.MyLavel[6]);// フォームへの追加
            this.MyLavel[6].BringToFront();
            ////
            ///
            lblKousin();
            //
        }
        private void lblKousin()
        {

            this.KousinLavel = new Label[1];

            this.KousinLavel[0] = new Label();
            // コントロールのプロパティ
            this.KousinLavel[0].Name = "lblKkousin";
            this.KousinLavel[0].Text = "";

            this.KousinLavel[0].Width = wdtBtn / 2;            //横幅
            this.KousinLavel[0].Height = htBtn;                //縦
            this.KousinLavel[0].Top = 3;
            this.KousinLavel[0].Left = leftPos[11] + wdtBtn + 10;//  
            this.KousinLavel[0].Font = new System.Drawing.Font("メイリオ", 10.5f);
            this.KousinLavel[0].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.KousinLavel[0].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.KousinLavel[0].Visible = false;

            // フォームへの追加
            this.form.Controls.Add(this.KousinLavel[0]);
            this.KousinLavel[0].BringToFront();


        }
        #region "イベント"
        private void Function1_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F1}");
        }
        private void Function2_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F2}");
        }
        private void Function3_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F3}");
        }
        private void Function4_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }
        private void Function5_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F5}");
        }
        private void Function6_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F6}");
        }
        private void Function7_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F7}");
        }
        private void Function8_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F8}");
        }
        private void Function9_Click(object sender, EventArgs e)
        {
            SendKeys.Send("+{F9}");
        }
        private void Function10_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F10}");
        }
        private void Function11_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F11}");
        }
        private void Function12_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F12}");
        }
        #endregion

    }


}
