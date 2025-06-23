using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;
using Npgsql.NameTranslation;

namespace Syuyaku
{
    static public class ClassIF
    {
        //テーブル指定
        //const string TableName = "n2c.v_yuryo_tenken_syuyaku";
        const string TableName = "tenken.v_yuryo_tenken_syuyaku";
        //テーブルの列指定
        static string[] retumei = {
                        "帳票発行日"
                        ,"帳票発行者id"
                        ,"請求番号"
                        ,"点検受付番号"
                        ,"点検受付日"
                        ,"点検完了日"
                        ,"請求書印刷日"
                        ,"請求書再印刷日"
                        ,"回収予定日"
                        ,"回収完了日"
                        ,"技術料"
                        ,"出張料"
                        ,"諸経費"
                        ,"サポート料"
                        ,"その他料金"
                        ,"値引き"
                        ,"消費税額"
                        ,"cim番号"
                        ,"請求日"
                        ,"帳票発行者姓"
                        ,"帳票発行者名"
                                  };
        //取り込みCSV指定
        //const string FileName = "D:\\01_Work\\04_NR\\06_点検センター\\70_N2C対応\\ソース\\YURYO_SEIKYU_HAKKO.csv";
        const string FileName = "D:\\01_Work\\04_NR\\06_点検センター\\70_N2C対応\\ソース\\N2OK003T.csv";
        //const string FileName = "C:\\work\\06_点検センター\\70_N2C対応\\ソース\\N2OK003T.csv";
        //ClassNpgsql cNpgsql =new ClassNpgsql();
        static string csvFileName = string.Empty;

        static int GetField(string mei)
        {
            return Array.IndexOf(retumei, mei);
        }

        static public void csvINsert()
        {
            string sql0 = "";
            string sql1 = "";
            string ukno = "";
            //string sql1 = "";
            try
            {

                ClassLog.LogDelete();
                int ukeno = GetHairetu("点検受付番号");
                //int cimno = GetHairetu("cim番号");

                ClassNpgsql.DbOpen(1);

                var parser = new TextFieldParser(FileName, System.Text.Encoding.GetEncoding("UTF-8"));
                using (parser)
                {

                    //  区切りの指定
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    // フィールドが引用符で囲まれているか
                    parser.HasFieldsEnclosedInQuotes = true;
                    // フィールドの空白トリム設定
                    parser.TrimWhiteSpace = false;


                    // ファイルの終端までループ
                    var lists = parser.ReadFields();
                    while (!parser.EndOfData)
                    {

                        var line = new List<string>();
                        lists = parser.ReadFields();

                        sql0 = $@"insert into {TableName}(";
                        sql1 = "values("; 
                        
                        for (int i = 0; i < retumei.Length; i++)
                        {
                            if (retumei[i] != "") {
                                sql0 += $@"{retumei[i]},";
                                sql1 += $@"'{lists[i]}',";
                            }
                        }
                        sql0 += $@"newflg)";
                        sql1 += $@"'1')";                        
                        sql0 = sql0 + sql1+ $@" on conflict(点検受付番号)";

                        sql0 += $@" do update set";
                        for (int i = 0; i < retumei.Length; i++)
                        {
                            if (retumei[i] != "" && ukeno != i)
                            {
                                sql0 += $@" {retumei[i]} = EXCLUDED.{retumei[i]},";
                            }
                        }
                        sql0 += $@" newflg = '1';";

                        ClassLog.LogWrite(sql0);
                        Console.WriteLine(lists[ukeno]);
                        System.Windows.Forms.Application.DoEvents();

                        ClassNpgsql._EXEC(sql0);
                        //
                   

                    }
                }

                ClassNpgsql.trans.Commit();
                ClassNpgsql.DbClose();
            }
            catch (Exception ex)
            {
                ClassLog.LogWrite(ex.Message);
                ClassNpgsql.trans.Rollback();
                ClassNpgsql.DbClose();
            }


        }
        static private int GetHairetu(string nm)
        {
            List<string> lists = new List<string>();
            lists.AddRange(retumei);
            int num = lists.IndexOf(nm);
            return num;

        }
    }
}
