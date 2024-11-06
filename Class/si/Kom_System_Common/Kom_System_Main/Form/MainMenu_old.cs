using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Kom_System_Main
{
    public partial class MainMenu_old : Form
    {
        private string _loginUserId;

        public MainMenu_old(params string[] args)
        {
            InitializeComponent();
            // 画面の閉じるボタンが押された時のイベント
            this.Closing += MainMenu_Closing;

            // ログインユーザーIDをセット
            _loginUserId = args[0];
        }

        private void MainMenu_Closing(object sender, CancelEventArgs e)
        {
            // メインメニューを閉じる時にアプリケーションを終了する
            Application.Exit();
        }

        private void MainMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9 && e.Shift)
            {
                // Shift + F9の場合
                Application.Exit();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMenu00_Click(object sender, EventArgs e)
        {
            
        }
    }
}
