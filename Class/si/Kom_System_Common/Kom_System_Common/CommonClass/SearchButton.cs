using System.Drawing;
using System.Windows.Forms;

namespace Kom_System_Common.CommonClass
{
    public partial class SearchButton : Button
    {
        public SearchButton()
        {
            InitializeComponent();
            Font = new System.Drawing.Font("メイリオ", 10.5f, FontStyle.Bold);
            BackColor = SystemColors.ControlDark;
            FlatStyle = FlatStyle.Popup;
            TabStop = false;
        }
    }
}
