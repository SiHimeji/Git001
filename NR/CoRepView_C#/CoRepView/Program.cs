using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Deployment.Application;


namespace CoRepView
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {

            //バージョンチェック＆更新処理
            ApplicationDeployment deploy;
            deploy = ApplicationDeployment.CurrentDeployment;

            bool bolCheckUpdate = false;
            //アップデートがあるかチェック
            bolCheckUpdate = deploy.CheckForUpdate();

            if (bolCheckUpdate)
            {
                //アップデートがあるので、アップデート処理
                bool bolUpdate = deploy.Update();
                if (bolUpdate == true)
                {
                    //更新処理が終わったのでアプリケーションをリスタートする
                    Application.Restart();
                }
                else
                {
                    //更新がエラーしたので任意の処理
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
