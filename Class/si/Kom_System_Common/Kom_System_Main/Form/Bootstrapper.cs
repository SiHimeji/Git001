using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kom_System_Main
{
    public partial class Bootstrapper : Form
    {
        /// <summary>
        /// ローカルアプリケーションの置き場
        /// </summary>
        string loaclPath = System.AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// ネットワークパス（リリース場所）
        /// </summary>
        string networkPath = @"\\isv03001\Users\31_IMF\0100_オブジェクト\Kom_System\";

        /// <summary>
        /// アップデート対象のEXE名
        /// </summary>
        string exeFileNM = "";

        /// <summary>
        /// アップデート対象のEXE名
        /// </summary>
        string messageFile = "Kom_System_Message";

        /// <summary>
        /// 起動時の引継ぎID
        /// </summary>
        private string id = string.Empty;

        /// <summary>
        /// アップデートが必要
        /// </summary>
        private bool getNewExeFile = false;

        public Bootstrapper(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo(loaclPath);
            string parentPath = di.Parent.FullName;
            loaclPath = parentPath;

            if (args.Length == 0)
            {
                GetMessage();
                networkPath = networkPath + "Kom_System_Main";
                exeFileNM = "Kom_System_Main";
            }
            else
            {
                networkPath = networkPath + System.IO.Path.GetFileNameWithoutExtension(args[0]);
                exeFileNM = System.IO.Path.GetFileName(args[0]);
                id = args[1];
            }
            InitializeComponent();
        }

        private void Bootstrapper_Load(object sender, EventArgs e)
        {
            string localexePath = string.Empty;
            try
            {
                Version serverVersion = GetVersion(networkPath + "\\" + exeFileNM + ".exe");

                if (File.Exists(loaclPath + "\\" + Path.ChangeExtension(exeFileNM, null) + "\\" + exeFileNM))
                {
                    Version currentVersion = GetVersion(loaclPath + "\\" + Path.ChangeExtension(exeFileNM, null) + "\\" + exeFileNM);

                    if (serverVersion > currentVersion)
                    {
                        getNewExeFile = true;
                    }
                    else
                    {
                        getNewExeFile = false;
                    }
                }
                else
                {
                    if(!Directory.Exists(loaclPath + "\\" + Path.ChangeExtension(exeFileNM, null))) 
                    {
                        Directory.CreateDirectory(loaclPath + "\\" + Path.ChangeExtension(exeFileNM, null));
                    }
                    getNewExeFile = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Bootstrapper_Shown(object sender, EventArgs e)
        {
            if (getNewExeFile)
            {
                StartBootstrapper();
                StartApplication();
            }
            else
            {
                StartApplication();
            }

            this.Close();
            this.Dispose();
        }

        private Version GetVersion(string path)
        {
            var versionInfo = FileVersionInfo.GetVersionInfo(path);
            return new Version(versionInfo.FileVersion);
        }

        private void StartBootstrapper()
        {
            if (Process.GetProcessesByName(exeFileNM).Length > 0)
            {
                MessageBox.Show("すでに起動しているアプリケーションです。");
                return;
            }

            string xcopyCommand = $"/C xcopy \"{networkPath}\" \"{loaclPath + "\\" + Path.ChangeExtension(exeFileNM, null)}\" /Y";

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = xcopyCommand,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(startInfo))
            {
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    throw new InvalidOperationException($"XCOPY コマンドの実行に失敗しました: {error}");
                }
            }
        }

        private void GetMessage()
        {
            string xcopyCommand = $"/C xcopy \"{networkPath + messageFile} \" \"{loaclPath + "\\" + messageFile} \" /Y";

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = xcopyCommand,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(startInfo))
            {
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    throw new InvalidOperationException($"XCOPY コマンドの実行に失敗しました: {error}");
                }
            }
        }

        private void StartApplication()
        {
            string appPath = Path.Combine(loaclPath + "\\" + Path.ChangeExtension(exeFileNM, null), System.IO.Path.GetFileName(networkPath) + ".exe");

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = appPath,
                Arguments = id,
                UseShellExecute = true,
                CreateNoWindow = false
            };

            Process.Start(startInfo);
        }
    }
}

