using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kom_System_Common.CommonClass
{
    public partial class TitleLabel : TextBox
    {
        public TitleLabel()
        {
            InitializeComponent();

            Color titleLabelColor = new Color();
            titleLabelColor = Color.FromArgb(184, 204, 228);
            this.BackColor = titleLabelColor;
            this.ReadOnly = true;
            this.TabStop = false;
            this.Font = new Font("メイリオ", 10.5f);
            this.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
