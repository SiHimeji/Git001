using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
/////in     -> out
///  4      -> 2024/10/04
///  1/2    -> 2024/01/02
/// 50/10/4 -> 1950/10/04
//  49/4/8  -> 2049/04/08
///
namespace Kom_System_Common.CommonClass
{
    public partial class dayTextBox : TextBox
    {

        /// <summary>
        /// 
        /// </summary>
        private int  modeSw=2;      // 0:=今月末日　1:来月末日 2:フリー
        private string yyyyMM = ""; // コントロール日
        private string jcd1 = "";   // 事業所コード
        private DateTime lastDay;    // 最後の日
        //


        public dayTextBox()
        {
            InitializeComponent();
            this.Font = new Font("メイリオ", 10.5f);
        }

        public dayTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        /// <summary>
        /// 事業所コード
        /// </summary>
        public string jigyosyoCd
        {
            set { jcd1 = value; }
            get { return jcd1; }
        }

        /// <summary>
        /// 末日チェックモード
        /// </summary>
        public int Mode
        {
            set { modeSw = value;
                if (modeSw == 2) { jcd1 = ""; yyyyMM = "";  }            
            }
            get { return modeSw; }

        }
        /// <summary>
        /// 数字のみ返す
        /// </summary>
        public string value
        {
            set{this.Text = value;}
            get{ return this.Text.Replace("/", ""); }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        
        {
            base.OnKeyPress(e);
            if (e.KeyChar == (char)Keys.Enter)
            {
                checkText();
                    SendKeys.Send(("({TAB})"));
            }
            else
            {
                if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '/' && e.KeyChar != '\b' && e.KeyChar != '\t')
                {
                    //イベントをキャンセルする
                    e.Handled = true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            checkText();
        }
        /// <summary>
        /// 
        /// </summary>
        private void checkText()
        {
            DateTime day;
            try
            {
                if (this.Text.Trim().Length > 0)
                {

                    switch (CountChar(this.Text, '/'))
                    {
                        case 0:
                            //数字のみ
                            if (this.Text.All(char.IsDigit))
                            {










                            }
                            if (this.Text == "00" || this.Text == "99")
                            {
                                day = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd"));
                                this.Text = day.ToString("yyyy/MM/") + this.Text;
                                if (checkDay()) { this.Text = ""; }
                            
                            }
                            else
                            {
                                day = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/") + this.Text.ToString());
                                this.Text = day.ToString("yyyy/MM/dd");
                                if (checkDay()) { this.Text = ""; }
                            }
                            break;
                        case 1:
                            if (this.Text.Substring(this.Text.Length - 2, 2) == "00" || this.Text.Substring(this.Text.Length - 2, 2) == "99")
                            {
                                day = DateTime.Parse(DateTime.Now.ToString("yyyy/") + this.Text.ToString().Replace("00", "01").Replace("99", "01"));

                                this.Text = day.ToString("yyyy/MM/") + this.Text.Substring(this.Text.Length - 2, 2);
                                if (checkDay()) { this.Text = ""; }
                            }
                            else
                            {
                                day = DateTime.Parse(DateTime.Now.ToString("yyyy/") + this.Text.ToString());
                                this.Text = day.ToString("yyyy/MM/dd");
                                if (checkDay()) { this.Text = ""; }
                            }
                            break;
                        case 2:
                            if (this.Text.Substring(this.Text.Length - 2, 2) == "00" || this.Text.Substring(this.Text.Length - 2, 2) == "99")
                            {
                                day = DateTime.Parse(Sura(this.Text) + "/" + Surasura(this.Text) + "/01");

                                this.Text = day.ToString("yyyy/MM/") + this.Text.Substring(this.Text.Length - 2, 2);
                                if (checkDay()) { this.Text = ""; }
                            }
                            else
                            {
                                if (this.Text.Substring(0, 1) == "/")
                                {
                                    day= DateTime.Parse(DateTime.Now.ToString("yyyy")+ "/"+Surasura(this.Text)+"/"+ SuraE(this.Text));
                                    this.Text = day.ToString("yyyy/MM/dd");
                                    if (checkDay()) { this.Text = ""; }

                                }
                                else
                                {
                                    day = DateTime.Parse(this.Text.ToString());
                                    this.Text = day.ToString("yyyy/MM/dd");
                                    if (checkDay()) { this.Text = ""; }
                                }
                            }
                            break;
                        }
                }
                else
                {
                    this.Text = DateTime.Now.ToString("yyyy/MM/dd");
                    if (checkDay()) { this.Text = ""; }
                }
            }
                catch (Exception ex)
            {
                this.Text = "Error";
            }
        }
        /// <summary>
        /// 文字の数を数える
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private int CountChar(string s, char c)
        {
            return s.Length - s.Replace(c.ToString(), "").Length;
        }
        private string Sura(string s)
        {
            int x = 0;
            int x0 = 0;
            for (x = 0; x < s.Length; x++)
            {
                if (s.Substring(x, 1) == "/")
                {
                    if (x0 == 0)
                    {
                        x0 = x;
                        break;
                    }
                }
            }
            if (x0 <1)
            {
                return DateTime.Now.ToString("yyyy");
            }
            return s.Substring(0 ,  x0 );
        }
        /// <summary>
        ///  /間の数字を戻す
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
         private string Surasura(string s)
        {
            Boolean fst = true;
            int x = 0;
            int x0 = 0;
            int x1 = 0;
            for (x = 0; x < s.Length; x++)
            {
                if (s.Substring(x, 1) == "/")
                {
                    if (fst) { x0 = x; fst = false; }
                    else x1 = x;
                }
            }
            if (x1 - x0 - 1 <1)
            {
                return DateTime.Now.ToString("MM");
            }
            return s.Substring(x0+1, x1 - x0 - 1);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string SuraE(string s)
        {
            int x = 0;
            int x0 = 0;
            for (x = s.Length - 1 ; x > 0  ; x--)
            {
                if (s.Substring(x, 1) == "/")
                {
                    x0 = x;
                    break;
                }
            }
            if (s.Length - x0 - 1 < 1)
            {
                return DateTime.Now.ToString("dd");
            }
            return s.Substring(x0 + 1,  s.Length - x0 - 1);
        }
        //
        /// <summary>
        ///  コントロールマスタ読み込み
        /// </summary>
        /// <returns></returns>
        private Boolean getContMast()
        {
            if (modeSw < 2 && yyyyMM !="")
            {
                string strSQL = "SELECT SGETU FROM KMCONT WHERE JCD1 ='" + jcd1 + "' AND CD1='A' ";
                try
                {
                    if (SqlSeverControl.DbConnect())
                    {
                        DataTable dt = new DataTable();
                        SqlSeverControl.GetDataTable(ref dt, strSQL);
                        foreach (DataRow dtax in dt.Rows)
                        {
                            yyyyMM = (dtax[0].ToString());
                        }
                        setLastDay();
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            modeSw = 2;
            return true;
        }
        /// <summary>
        /// 最終日をセットする
        /// </summary>
        /// <returns></returns>
        private Boolean setLastDay()
        {
            try
            {
                lastDay = DateTime.Parse(yyyyMM + "01");
                if (modeSw == 0)
                {
                    lastDay = lastDay.AddMonths(1).AddDays(-1);
                }else if (modeSw == 1)
                {
                    lastDay = lastDay.AddMonths(2).AddDays(-1);
                }
                else
                {
                    lastDay = lastDay.AddMonths(12).AddDays(-1);
                }
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        private Boolean checkDay()
        {
            if(modeSw==2)return true;

            try
            {
                DateTime dy = DateTime.Parse(this.Text);
                if (dy <= lastDay)return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        ///
    }
}
