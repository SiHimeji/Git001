using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        /// 数字のみ返す
        /// </summary>
        public string value
        {
            set
            {
                this.Text = value;
            }
            get
            {
                return this.Text.Replace("/", "");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            DateTime day;
            try
            {
                if (this.Text.Trim().Length>0)
                {

                    switch (CountChar(this.Text, '/'))
                    {
                        case 0:
                            day = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/") + this.Text.ToString());
                            this.Text = day.ToString("yyyy/MM/dd");
                            break;
                        case 1:
                            day = DateTime.Parse(DateTime.Now.ToString("yyyy/") + this.Text.ToString());
                            this.Text = day.ToString("yyyy/MM/dd");
                            break;

                        case 2:
                            day = DateTime.Parse(this.Text.ToString());
                            this.Text = day.ToString("yyyy/MM/dd");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Text = ex.Message;
            }
        }
        private int CountChar(string s, char c)
        {
            return s.Length - s.Replace(c.ToString(), "").Length;
        }

    }
}
