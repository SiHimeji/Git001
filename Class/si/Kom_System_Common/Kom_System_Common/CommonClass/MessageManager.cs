using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kom_System_Common.CommonClass
{
    static public class MessageManager
    {
        public static Dictionary<string, string> MessegeDictionary;

        /// <summary>
        /// キャプション名称を表すクラスです
        /// </summary>
        public static class CAPTION
        {
            #region キャプション名称
            /// <summary>
            /// キャプション名称：エラー
            /// </summary>
            public const string ERROR = "エラー";
            /// <summary>
            /// キャプション名称：警告
            /// </summary>
            public const string WARN = "警告";
            /// <summary>
            /// キャプション名称：情報
            /// </summary>
            public const string INFO = "情報";
            /// <summary>
            /// キャプション名称：確認
            /// </summary>
            public const string CONFIRM = "確認";
            #endregion
        }


        /// <summary>
        /// メッセージリストを取得
        /// </summary>
        public static void GetMessegeData()
        {
#if DEBUG
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string csvFilePath = path + "Kom_System_Message\\Message.csv";
#else
            string path = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
            string csvFilePath = path.Substring(0, path.LastIndexOf(@"\") + 1) + "Kom_System_Message\\Message.csv";
#endif
            MessegeDictionary = new Dictionary<string, string>();
            try
            {
                // Shift-JISエンコーディングでファイルを読み込む
                Encoding encoding = Encoding.GetEncoding("Shift_JIS");
                using (StreamReader sr = new StreamReader(csvFilePath, encoding))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length == 2)
                        {
                            string key = parts[0];
                            string value = parts[1];
                            MessegeDictionary[key] = value;
                        }
                        else
                        {
                            Console.WriteLine($"不正な行: {line}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"エラーが発生しました: {ex.Message}");
            }
        }

        /// <summary>
        /// メッセージを取得
        /// </summary>
        /// <param name="id">メッセージID</param>
        /// <param name="args">メッセージパラメータ</param>
        /// <returns>メッセージ本文</returns>
        public static string GetMessageById(string id, params string[] args)
        {
            if (MessegeDictionary.TryGetValue(id, out string value))
            {
                return string.Format(value, args);
            }
            else
            {
                return id;
            }
        }


    }
}
