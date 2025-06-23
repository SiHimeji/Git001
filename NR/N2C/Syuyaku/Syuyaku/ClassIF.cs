using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;
using static System.Windows.Forms.LinkLabel;
namespace Syuyaku
{
    static public class ClassIF
    {
        //テーブル指定
        const string TableName = "tenken.v_yuryo_tenken_syuyaku";
        //const string TableName = "n2c.v_yuryo_tenken_syuyaku";
        //テーブルの列指定
        static string[] retumei = {
 "所有者登録意思区分"
,"所有者登録意思区分名"
,"ｄｍ番号"
,"点検台帳登録区分"
,"点検台帳登録区分名称"
,"所有者票ブランド"
,"所有者票ブランド名称"
,"製品名_通知"
,"製品名_完了"
,"製造番号_通知"
,"製造番号_完了"
,"点検開始年月"
,"点検終了年月"
,"点検通知種類"
,"点検通知種類名称"
,"点検通知年月"
,"ステータス"
,"ステータス名"
,"点検受付番号"
,"点検受付日"
,"点検完了日"
,"フロント承認日"
,"受付区分"
,"受付区分名称"
,"点検状態区分"
,"点検状態区分名称"
,"顧客id"
,"都道府県名"
,"市区町村名"
,"技術料"
,"出張料"
,"その他料金"
,""
,""
,"未着回数"
,"保証規定区分コード"
,"保証規定区分"
,"承認番号"
,"責任部門コード"
,"責任部門"
,"設計標準使用期間"
,"システム詳細区分"
,"システム詳細区分名"
,"表示解除区分"
,"表示解除方法通知日"
,"担当shopコード"
,"担当サービスマン"
,"所有者票顧客id"
,"回収金額"
,"集計基準日"
,"メーカーコード"
,"メーカー"
,"点検完了受付日"
,"製造年月"
,"所有者有無"
,"故障表示1"
,"依頼区分"
,"依頼区分内容"
,"tc店略称"
,"店略称"
,"キャンセル"
,"受付店"
,"受付者"
,"修理状況"
,"修理状況名称"
,"サポート料"
,"値引き"
,"消費税額"
,"請求合計金額"
,"点検結果伝票番号"
,"機器分類"
,"回収区分コード"
,"回収区分"
,"請求回収区分変更理由"
,"契約_安心プラン"
,"契約番号"
,"第１業務区分"
,"第１業務区分内容"
,"第２業務区分"
,"第２業務区分内容"
,"無償部品代"
,"無償出張料"
,"無償技術料"
,"無償出張料差額"
,"無償合計"
,"依頼元名"
,"依頼元カナ"
,"依頼元会社"
,"依頼元電話"
,"請求先名"
,"請求先カナ"
,"請求先会社"
,"請求先電話"
,"価格指示理由"
,"都道府県コード"
,"市区町村名コード"
,"更新日"
,"請求先部署"
,"請求先宛名"
,"請求先担当"
,"請求先住所"
,"サービスマン名"
,"注文no"
,"修理完了日"
,"新ステータス"
,"新ステータス名称"
,"マイページ連携仮id"
,"マイページ連携仮pw"
,"マイページid"
,"依頼元コード"
,"訪問先会社名"
,"訪問先部署"
,"訪問先氏名担当者"
,"訪問先氏名担当者カナ"
,"訪問先電話番号"
,"製造番号不明理由"
,"製造番号不明理由内容"
,"訪問予定日１"
,"依頼元fax番号"
,"無償承認日"
,"町域"
,"番地"
,"建物"
,"部屋"
,"cim番号"
,"ｄｍ番号id"
,"tc店略称id"
,"受付店Id"
,"受付者Id"
                                  };
        //取り込みCSV指定
        //const string FileName = "D:\\01_Work\\04_NR\\06_点検センター\\70_N2C対応\\ソース\\YURYO_TENKEN_SYUYAKU.csv";
        const string FileName = "D:\\01_Work\\04_NR\\06_点検センター\\70_N2C対応\\ソース\\N2OK002T.csv";
        //const string FileName = "C:\\work\\06_点検センター\\70_N2C対応\\ソース\\N2OK002T.csv";
        //
        //ClassNpgsql cNpgsql =new ClassNpgsql();
        static string csvFileName = string.Empty;

        static public void csvINsert()
        {
            string sql0 = "";
            string sql1 = "";
            string sql2 = "";
            int cnt;
            try
            {
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

                    GetHairetu("点検受付番号");
                    // ファイルの終端までループ
                    var lists = parser.ReadFields();
                    while (!parser.EndOfData)
                    {

                        var line = new List<string>();
                        lists = parser.ReadFields();

                        /*
                        if (lists[cimno] != "")
                        {
                            ukno = lists[cimno];
                            lists[cimno] = lists[ukeno];
                            lists[ukeno] = lists[cimno];
                        }
                        */
                        cnt = 0;
                        sql1 = $@"insert into {TableName} (";
                        sql2 = $@")values( ";
                        foreach (string value in lists)
                        {
                            if (retumei[cnt] != "")
                            {
                                if (cnt == 0)
                                {
                                    sql1 += retumei[cnt];
                                    sql2 += "'" + value.Trim().Replace("　", "").Replace(" ", "") + "'";
                                }
                                else
                                {
                                    sql1 += "," + retumei[cnt];
                                    sql2 += ",'" + value.Trim().Replace("　", "").Replace(" ", "") + "'";

                                }
                            }
                            cnt++;
                        }
                        sql1 += ",newflg";
                        sql2 += ",'1'";
                        sql0 = sql1 + sql2 + ")";
                        sql0 += " ON CONFLICT (点検受付番号) ";
                        sql0 += " DO UPDATE SET ";
                        cnt = 0;
                        foreach (string value in lists)
                        {
                            if (retumei[cnt] != "")
                            {
                                if (cnt == 0)
                                {
                                    //sql0 += retumei[cnt] + "= '" + value.Trim().Replace("　", "").Replace(" ", "") + "'";
                                    sql0 += retumei[cnt] + " = EXCLUDED." + retumei[cnt] + "";
                                }
                                else
                                {
                                    if (cnt != ukeno)
                                    {
                                        //sql0 += "," + retumei[cnt] + "= '" + value.Trim().Replace("　", "").Replace(" ", "") + "'";
                                        sql0 += "," + retumei[cnt] + "= EXCLUDED." + retumei[cnt] + "";
                                    }
                                }
                                cnt++;
                            }
                        }
                        sql0 += ", newflg = '1';";
                    ClassLog.LogWrite(sql0);
                    Console.WriteLine(lists[ukeno].ToString());
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nm"></param>
        /// <returns></returns>
        static private int GetHairetu(string nm)
        {
            List<string> lists = new List<string>();
            lists.AddRange(retumei);
            int num = lists.IndexOf(nm);
            return num;

        }

    }
}
