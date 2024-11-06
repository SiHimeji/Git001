using Kom_System_Common.CommonClass;
using Kom_System_Common.CommonClass.Services;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;


namespace Kom_System_Main
{
    public partial class LoginForm : Form
    {
        // エラーメッセージ
        private const string USER_CD = "担当者コード";
        // 正常コード
        private const int SUCCESS_CODE = 0;
        // 入力エラーコード
        private const int INPUT_ERR_CODE = 2;
        // 存在エラーコード
        private const int EXIST_ERR_CODE = 9;
        // 担当者コード
        private string userId = string.Empty;

        /// <summary>
        /// ログイン画面を表示
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();

            // 画面の閉じるボタンが押された時のイベント
            this.Closing += LoginFromClose;

            //バージョンの取得
            //自分自身のAssemblyを取得
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            System.Version ver = asm.GetName().Version;
            lbl_Version.Text = lbl_Version.Text + ver.ToString();
        }

        /// <summary>
        /// ログイン画面読込時
        /// </summary>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            // メッセージファイルの読み込み
            MessageManager.GetMessegeData();
        }

        /// <summary>
        /// ログインボタン押下
        /// </summary>
        private void BtnLoginClick(object sender, EventArgs e)
        {

            userId = txt_LoginUserId.Text;

            // 入力チェック
            if(InputCheck(userId) != SUCCESS_CODE)
            {
                MessageBox.Show(MessageManager.GetMessageById("CM-E-0001", USER_CD), MessageManager.CAPTION.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 存在チェック
            if (ExistenceCheck(userId) != SUCCESS_CODE)
            {
                MessageBox.Show(MessageManager.GetMessageById("CM-E-0005", USER_CD), MessageManager.CAPTION.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // メニュー画面を表示
             MainMenu_old menu = new MainMenu_old(userId);
            menu.Show();

            // ログイン画面を非表示
            this.Hide();
        }

        /// <summary>
        /// 担当者名取得
        /// </summary>
        private void UserIdValidate(object sender, System.ComponentModel.CancelEventArgs e)
        {
            userId = txt_LoginUserId.Text;

            // 入力チェック
            InputCheck(userId);

            // 存在チェック
            ExistenceCheck(userId);
        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        private int InputCheck(string userId) 
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                lbl_LoginUserName.Text = "";
                return INPUT_ERR_CODE;
            }
            return SUCCESS_CODE;
        }

        /// <summary>
        /// 存在チェック処理
        /// </summary>
        private int ExistenceCheck(string userId)
        {
            var userExistCheck = MeishoMasterService.GetMeishoMaster(MeishoMasterService.NMKBN.TANTOSHA, userId, MeishoMasterService.BRCD.MEISHO);
            
            if (userExistCheck.Rows.Count == 0)
            {
                lbl_LoginUserName.Text = "";
                return EXIST_ERR_CODE;
            }

            foreach (DataRow row in userExistCheck.Rows)
            {
                lbl_LoginUserName.Text = row["NM"].ToString();
            }
            return SUCCESS_CODE;
        }

        /// <summary>
        /// テキスト入力後、EnterKey押下時
        /// </summary>
        private void InputComp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                userId = txt_LoginUserId.Text;

                // 入力チェック
                if (InputCheck(userId) != SUCCESS_CODE)
                {
                    MessageBox.Show(MessageManager.GetMessageById("CM-E-0001", USER_CD), MessageManager.CAPTION.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 存在チェック
                if (ExistenceCheck(userId) != SUCCESS_CODE)
                {
                    MessageBox.Show(MessageManager.GetMessageById("CM-E-0005", USER_CD), MessageManager.CAPTION.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                e.SuppressKeyPress = true;
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        /// <summary>
        /// 閉じるボタン押下時
        /// </summary>
        private void LoginFromClose(object sender, CancelEventArgs e)
        {

            DialogResult result = MessageBox.Show(MessageManager.GetMessageById("CM-I-0004"), MessageManager.CAPTION.CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Shift + F9の場合
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Shift + F9ボタン押下時
        /// </summary>
        private void LoginKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9 && e.Shift)
            {
                DialogResult result = MessageBox.Show(MessageManager.GetMessageById("CM-I-0004"), MessageManager.CAPTION.CONFIRM, MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Shift + F9の場合
                    Application.Exit();
                }
            }
        }
    }
}
