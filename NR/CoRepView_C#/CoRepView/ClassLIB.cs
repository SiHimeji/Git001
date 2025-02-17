using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CoRepView
{
    public class ClassLIB
    {

        public string messgErr= string.Empty;
        /// <summary>
        /// 
        /// 0 タイトル
        /// 1 説明
        /// 2 会社
        /// 3 製品
        /// 4 著作権
        /// 5 商標
        /// 6 ファイルバージョン
        /// 7 アセンブリバージョン
        /// 
        public string GetAsmTitle()
        {
            string[] asm = new string[8];
            System.Reflection.AssemblyTitleAttribute asmttl =
            (System.Reflection.AssemblyTitleAttribute)
                Attribute.GetCustomAttribute(
                    System.Reflection.Assembly.GetExecutingAssembly(),
                    typeof(System.Reflection.AssemblyTitleAttribute));
            return (asmttl.Title);

        }
        public string GetAsmDescription()
        {

            //AssemblyDescriptionの取得
            System.Reflection.AssemblyDescriptionAttribute asmdc =
                (System.Reflection.AssemblyDescriptionAttribute)
                Attribute.GetCustomAttribute(
                System.Reflection.Assembly.GetExecutingAssembly(),
                typeof(System.Reflection.AssemblyDescriptionAttribute));
            return (asmdc.Description);
        }
        public string GetAsmCompany()
        {
            //AssemblyCompanyの取得
            System.Reflection.AssemblyCompanyAttribute asmcmp =
            (System.Reflection.AssemblyCompanyAttribute)
            Attribute.GetCustomAttribute(
            System.Reflection.Assembly.GetExecutingAssembly(),
            typeof(System.Reflection.AssemblyCompanyAttribute));
            return (asmcmp.Company);
        }
        public string GetAsmProduct()
        {
            //AssemblyProductの取得
            System.Reflection.AssemblyProductAttribute asmprd =
                (System.Reflection.AssemblyProductAttribute)
                Attribute.GetCustomAttribute(
                System.Reflection.Assembly.GetExecutingAssembly(),
                typeof(System.Reflection.AssemblyProductAttribute));
            return (asmprd.Product);
        }
        public string GetAsmCopyright()
        {

            //AssemblyCopyrightの取得
            System.Reflection.AssemblyCopyrightAttribute asmcpy =
                (System.Reflection.AssemblyCopyrightAttribute)
                Attribute.GetCustomAttribute(
                System.Reflection.Assembly.GetExecutingAssembly(),
                typeof(System.Reflection.AssemblyCopyrightAttribute));
            return(asmcpy.Copyright);
        }

        public string GetAsmTrademark()
        {

            //AssemblyTrademarkの取得
            System.Reflection.AssemblyTrademarkAttribute asmtmk =
                (System.Reflection.AssemblyTrademarkAttribute)
                Attribute.GetCustomAttribute(
                System.Reflection.Assembly.GetExecutingAssembly(),
                typeof(System.Reflection.AssemblyTrademarkAttribute));
            return (asmtmk.Trademark);
        }

        public string GetAsmProductVersion()
        {

            //ファイルバージョンの取得
            System.Diagnostics.FileVersionInfo ver =
                System.Diagnostics.FileVersionInfo.GetVersionInfo(
                System.Reflection.Assembly.GetExecutingAssembly().Location);
            return (ver.ProductVersion.ToString());
        }
        public string GetAsmVersion()
        {
            //アセンブリバージョンの取得
            System.Reflection.Assembly assm =
            System.Reflection.Assembly.GetExecutingAssembly();
            System.Version ver1 = assm.GetName().Version;
            return( ver1.ToString()); 

        }
        /// <summary>
        /// 次のバージョンを計算
        /// </summary>
        /// <returns></returns>
    
        /// <summary>
        /// 　ファイル削除
        /// </summary>
        /// <param name="targetDirectoryPath"></param>
        /// 
        public void DirFIleDell(string targetDirectoryPath)
        {
            try
            {
                string[] filePaths = Directory.GetFiles(targetDirectoryPath);
                foreach (string filePath in filePaths)
                {
                    File.SetAttributes(filePath, FileAttributes.Normal);
                    File.Delete(filePath);
                }
            }
            catch(Exception e)
            {
                messgErr = e.Message;
            }

        }
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetFaileName(string kaktyousi, string defdir)
        {

            OpenFileDialog ofd = new OpenFileDialog();

            ofd.FileName = "default." + kaktyousi;
            ofd.InitialDirectory = defdir;
            ofd.Filter = "ファイル(*." + kaktyousi + ";*." + kaktyousi + ")|*." + kaktyousi + ";*." + kaktyousi + "|すべてのファイル(*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.Title = "開くファイルを選択してください";
            ofd.RestoreDirectory = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                return (ofd.FileName);
            }
            return ("");

        }
        /// <summary>
        ///  フォルダーを選択する
        /// 
        /// </summary>
        /// <param name="Defdir"></param>
        /// <returns></returns>
        public string GetFolder(string Defdir)
        {
            string ret = "";
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "フォルダを選択してください。";
            folderBrowserDialog.SelectedPath = Defdir;
            folderBrowserDialog.ShowNewFolderButton = true;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                ret = folderBrowserDialog.SelectedPath;
            }
            else
            {
                ret = "";
            }
            folderBrowserDialog.Dispose();
            return ret;
        }


        public string GetSaveFile(string Defdir)
        {
            string ret;
            SaveFileDialog ofDialog = new SaveFileDialog();

            // デフォルトのフォルダを指定する
            ofDialog.InitialDirectory = Defdir;

            //ダイアログのタイトルを指定する
            ofDialog.Title = "ダイアログのタイトル";

            //ダイアログを表示する
            if (ofDialog.ShowDialog() == DialogResult.OK)
            {
                ret=ofDialog.FileName;
            }
            else
            {
                ret="";
            }

            // オブジェクトを破棄する
            ofDialog.Dispose();
            //FolderBrowserDialogクラスのインスタンスを作成
            return (ret);


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="CsvFaileNmae"></param>
        public void ReadCcvToDataGred(DataGridView gv, string CsvFaileNmae)
        {

            string line;
            string[] values;
            gv.Rows.Clear();
            try
            {
                // 読み込みたいCSVファイルのパスを指定して開く
                StreamReader sr = new StreamReader(CsvFaileNmae, System.Text.Encoding.GetEncoding("shift_jis"));
                // 末尾まで繰り返す
                while (!sr.EndOfStream)
                {
                    // CSVファイルの一行を読み込む
                    line = sr.ReadLine();
                    line = line.Replace("\"", "");
                    values = line.Split(',');
                    gv.Rows.Add(values);
                }
                sr.Close();
            }catch(Exception ex)
            {
                messgErr = ex.Message;
                //MessageBox.Show(ex.Message, "ReadCcvToDataGred");

            }
        }
        /// <summary>
        /// 文字列の指定した位置から指定した長さを取得する
        /// </summary>
        /// <param name="str">文字列</param>
        /// <param name="start">開始位置</param>
        /// <param name="len">長さ</param>
        /// <returns>取得した文字列</returns>
        public static string Mid(string str, int start, int len)
        {
            if (start <= 0)
            {
                throw new ArgumentException("引数'start'は1以上でなければなりません。");
            }
            if (len < 0)
            {
                throw new ArgumentException("引数'len'は0以上でなければなりません。");
            }
            if (str == null || str.Length < start)
            {
                return "";
            }
            if (str.Length < (start + len))
            {
                return str.Substring(start - 1);
            }
            return str.Substring(start - 1, len);
        }

        /// <summary>
        /// 文字列の指定した位置から末尾までを取得する
        /// </summary>
        /// <param name="str">文字列</param>
        /// <param name="start">開始位置</param>
        /// <returns>取得した文字列</returns>
        public static string Mid(string str, int start)
        {
            return Mid(str, start, str.Length);
        }

        /// <summary>
        /// 文字列の先頭から指定した長さの文字列を取得する
        /// </summary>
        /// <param name="str">文字列</param>
        /// <param name="len">長さ</param>
        /// <returns>取得した文字列</returns>
        public static string Left(string str, int len)
        {
            if (len < 0)
            {
                throw new ArgumentException("引数'len'は0以上でなければなりません。");
            }
            if (str == null)
            {
                return "";
            }
            if (str.Length <= len)
            {
                return str;
            }
            return str.Substring(0, len);
        }

        /// <summary>
        /// 文字列の末尾から指定した長さの文字列を取得する
        /// </summary>
        /// <param name="str">文字列</param>
        /// <param name="len">長さ</param>
        /// <returns>取得した文字列</returns>
        public static string Right(string str, int len)
        {
            if (len < 0)
            {
                throw new ArgumentException("引数'len'は0以上でなければなりません。");
            }
            if (str == null)
            {
                return "";
            }
            if (str.Length <= len)
            {
                return str;
            }
            return str.Substring(str.Length - len, len);
        }

        /// <summary>
        /// 
        /// 
        /// </summary>
        /// 
        /// <returns></returns>
        public string GetWindosTemp()
        {
            return Path.GetTempPath();
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        //
        public string GetDirectory(string FileName)
        {
            return System.IO.Path.GetDirectoryName(FileName);
        }
        /// <summary>
        ///  ファイル削除
        /// </summary>
        /// <param name="FileName"></param>
        public void FileDell(string FileName)
        {
            try
            {
                if(FileChk(FileName))
                    File.Delete(FileName);

            }catch(Exception ex)
            {
                messgErr = ex.Message;
                //MessageBox.Show(ex.Message, "FileDell="+ FileName);

            }
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="fl"></param>
        public void CleatFolder(string fl)
        {
            Directory.CreateDirectory(fl);
        }
        public void DeleteFolder(string fl)
        {
            if (Directory.Exists(fl)) Directory.Delete(fl, true);
        }
        public void FileCopy(string moto, string saki)
        {
            System.IO.File.Copy(moto, saki);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="moto"></param>
        /// <param name="saki"></param>
        public void PdfCopy(string moto ,string saki)
        {
            //ClassPDF ClassPDF = new ClassPDF();
            List<string> sStrList = new List<string>();

            sStrList.Clear();

            if (GetAllFileList(moto, "*.pdf", ref sStrList) )
            {
                foreach (var b in sStrList)
                {
                    System.IO.File.Copy(b, saki);
                }
            }
        }
        /// <summary>
        /// ディレクトリをコピーする
        /// </summary>
        /// <param name="sourceDirName">コピーするディレクトリ</param>
        /// <param name="destDirName">コピー先のディレクトリ</param>
        public void CopyDirectory(
            string sourceDirName, string destDirName)
        {
            //コピー先のディレクトリがないときは作る
            if (!System.IO.Directory.Exists(destDirName))
            {
                System.IO.Directory.CreateDirectory(destDirName);
                //属性もコピー
                System.IO.File.SetAttributes(destDirName,
                    System.IO.File.GetAttributes(sourceDirName));
            }

            //コピー先のディレクトリ名の末尾に"\"をつける
            if (destDirName[destDirName.Length - 1] !=
                    System.IO.Path.DirectorySeparatorChar)
                destDirName = destDirName + System.IO.Path.DirectorySeparatorChar;

            //コピー元のディレクトリにあるファイルをコピー
            string[] files = System.IO.Directory.GetFiles(sourceDirName);
            foreach (string file in files)
                System.IO.File.Copy(file,
                    destDirName + System.IO.Path.GetFileName(file), true);

            //コピー元のディレクトリにあるディレクトリについて、再帰的に呼び出す
            string[] dirs = System.IO.Directory.GetDirectories(sourceDirName);
            foreach (string dir in dirs)
                CopyDirectory(dir, destDirName + System.IO.Path.GetFileName(dir));
        }
        /// <summary>
        /// ファイル存在チェック
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public Boolean FileChk(string filePath)
        {
            if (File.Exists(filePath))
            {
                return true;
            }
            return false;
        }

        public string GetFileName(string FileName)
        {
            int ln = FileName.Length;
            int x;
            for( x=ln-1 ; x>0 ; x--)
            {
                if (FileName.Substring(x, 1) == "\\") break;

            }
            return FileName.Substring(x+1, ln-x-1);

        }
        public string GetAppDir()
        {
            return System.IO.Directory.GetCurrentDirectory();
        }
        /// <summary>
        /// /
        /// </summary>
        public void LogSave(string Msg)
        {
            using (StreamWriter sw = new StreamWriter(@"E:\\log.txt", true, Encoding.UTF8))
            {
                    sw.WriteLine(Msg);
            }

        }
        /// <summary>
        ///  フォルダーを探す
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="foldr"></param>
        /// <returns></returns>
        public static string[] GetDirectry(string dir ,string foldr)
        {
            string[] subFolders = System.IO.Directory.GetDirectories(dir, foldr, System.IO.SearchOption.AllDirectories);
            return subFolders;

        }

        /// ---------------------------------------------------------------------------------------
        /// <summary>
        ///     指定した検索パターンに一致するファイルを最下層まで検索しすべて返します。</summary>
        /// <param name="stRootPath">
        ///     検索を開始する最上層のディレクトリへのパス。</param>
        /// <param name="stPattern">
        ///     パス内のファイル名と対応させる検索文字列。</param>
        /// <returns>
        ///     検索パターンに一致したすべてのファイルパス。</returns>
        /// ---------------------------------------------------------------------------------------
        public static string[] GetFilesMostDeep(string stRootPath, string stPattern)
        {
            System.Collections.Specialized.StringCollection hStringCollection = (
                new System.Collections.Specialized.StringCollection()
            );

            // このディレクトリ内のすべてのファイルを検索する
            foreach (string stFilePath in System.IO.Directory.GetFiles(stRootPath, stPattern))
            {
                hStringCollection.Add(stFilePath);
            }

            // このディレクトリ内のすべてのサブディレクトリを検索する (再帰)
            foreach (string stDirPath in System.IO.Directory.GetDirectories(stRootPath))
            {
                string[] stFilePathes = GetFilesMostDeep(stDirPath, stPattern);

                // 条件に合致したファイルがあった場合は、ArrayList に加える
                if (stFilePathes != null)
                {
                    hStringCollection.AddRange(stFilePathes);
                }
            }

            // StringCollection を 1 次元の String 配列にして返す
            string[] stReturns = new string[hStringCollection.Count];
            hStringCollection.CopyTo(stReturns, 0);

            return stReturns;
        }
        /// <summary>
        /// 指定ディレクトリのファイルリストを返却する
        /// </summary>
        /// <param name="sDirPath">
        /// 検索対象のディレクトリ
        /// </param>
        /// <param name="searchPattern">
        /// 検索文字列(*.pdf など)
        /// </param>
        /// <param name="sStrList">
        /// 返却用のListオブジェクト　List<string[]>
        /// xmlxmlxml</param>
        /// <returns>
        /// true:正常
        /// false:以上
        /// </returns>
        /// 
        public  Boolean GetAllFileList(string sDirPath,
                                    string searchPattern,
                                    ref List<string> sStrList)
        {

            // ファイルを最下層まで検索し取得する
            string[] stFilePathes = GetFilesMostDeep(sDirPath, searchPattern);
            //string stPrompt = string.Empty;

            // 取得したファイル名を列挙する
            foreach (string stFilePath in stFilePathes)
            {
                sStrList.Add ( stFilePath + System.Environment.NewLine);
            }

            return true;

        }
        /// <summary>
        /// 
        /// </summary>
        ///
        public void SetComboBox(ComboBox cb, string nm)
        {
            for (int i=0;i<cb.Items.Count;i++)
            {
                cb.SelectedIndex = i;    
                if (cb.Text ==nm)
                {
                    return;
                }
            }
        }
        public Boolean SetComboBox(ToolStripComboBox cb, string nm)
        {
            for (int i = 0; i < cb.Items.Count; i++)
            {
                cb.SelectedIndex = i;

                //if (cb.Text.Contains(nm))
                if (cb.Text.Equals(nm))
                {
                    return true;
                }
            }
            return false;
        }

        /**
        */
        /// <summary>
        /// チェックデジット計算（モジュラス10 ウェイト3・1分割）
        /// </summary>
        ///
        public string calcCheckDigit3(string x)
        {
            string[] DIGIT_TBL = { "0", "9", "8", "7", "6", "5", "4", "3", "2", "1" };
            int sum = 0;

            char[] c = x.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                sum += (c[i] & 0xf) * (((i ^ c.Length) & 1) << 1 | 1);
            }
            return DIGIT_TBL[sum % 10];
        }
        /// <summary>
        /// チェックデジット計算（モジュラス10 ウェイト2・1分割）
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string calcCheckDigit2(string code)
        {
            string ret = "";

            List<string> oddList = new List<string>();
            List<string> evenList = new List<string>();
            // reverse
            code = string.Join("", code.Reverse());
            bool oddFlg = false;

            for (int i = 0; i < code.Length; i++)
            {
                if (oddFlg)
                {
                    oddList.Add(code.Substring(i, 1));
                }
                else
                {
                    evenList.Add(code.Substring(i, 1));
                }

                oddFlg = !oddFlg;
            }

            // 奇数処理
            int kisu = 0;
            foreach (string s in oddList)
            {
                kisu = kisu + int.Parse(s);
            }

            // 偶数処理
            int gusu = 0;
            foreach (string s in evenList)
            {
                int num = int.Parse(s);
                num = num * 2;
                string str = num.ToString();
                if (str.Length == 1)
                {
                    gusu = gusu + num;
                }
                else
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        string str2 = str.Substring(i, 1);
                        gusu = gusu + int.Parse(str2);
                    }
                }
            }

            int mod = 10 - ((kisu + gusu) % 10);
            if (mod == 10)
            {
                mod = 0;
            }

            ret = mod.ToString();

            return ret;
        }
        /// 
        ///cnViewOffsetY
        const string RegKey = @"Software\";
        public string ReadReg(string strRegKey)
        {

            //キー（HKEY_CURRENT_USER\Software\test\sub）を読み取り専用で開く
            Microsoft.Win32.RegistryKey regkey =
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey(RegKey + strRegKey, false);
            //キーが存在しないときは null が返される
            if (regkey == null) return "";

            //文字列を読み込む
            //指定した名前の値が存在しないときは null が返される
            string stringValue = (string)regkey.GetValue("ExpandString");


            //キーに値が存在しないときに指定した値を返すようにするには、次のようにする
            //（ここでは"default"を返す）
            //string stringValue = (string) regkey.GetValue("string", "default");

            //整数（REG_DWORD）を読み込む
            //int intValue = (int)regkey.GetValue("int");

            //整数（REG_QWORD）を読み込む
            //long longVal = (long)regkey.GetValue("QWord");

            //文字列配列を読み込む
            //string[] strings = (string[])regkey.GetValue("StringArray");

            //バイト配列を読み込む
            //byte[] bytes = (byte[])regkey.GetValue("Bytes");

            //閉じる
            regkey.Close();

            return stringValue;

        }

        public void WriteReg(string strRegKey, string strKey)
        {

            //キー（HKEY_CURRENT_USER\Software\test\sub）を開く
            Microsoft.Win32.RegistryKey regkey =
                Microsoft.Win32.Registry.CurrentUser.CreateSubKey(RegKey + strRegKey);
            //上のコードでは、指定したキーが存在しないときは新しく作成される。
            //作成されないようにするには、次のようにする。
            //Microsoft.Win32.RegistryKey regkey =
            //    Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\test\sub", true);

            //レジストリに書き込み
            //文字列を書き込む（REG_SZで書き込まれる）
            regkey.SetValue("ExpandString", strKey);

            //整数（Int32）を書き込む（REG_DWORDで書き込まれる）
            //regkey.SetValue("int", 100);

            //文字列配列を書き込む（REG_MULTI_SZで書き込まれる）
            //string[] s = new string[] { "1", "2", "3" };
            //regkey.SetValue("StringArray", s);

            //バイト配列を書き込む（REG_BINARYで書き込まれる）
            //byte[] bs = new byte[] { 0, 1, 2 };
            //regkey.SetValue("Bytes", bs);

            //閉じる
            regkey.Close();

        }





        //
        // end ///
        //
    }
}
