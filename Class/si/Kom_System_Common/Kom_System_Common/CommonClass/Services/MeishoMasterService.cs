using System.Collections.Generic;
using System.Data;

namespace Kom_System_Common.CommonClass.Services
{
    public static class MeishoMasterService
    {
        /// <summary>
        /// 名称マスタの一覧を取得します
        /// </summary>
        /// <param name="nmkbn">名称区分</param>
        /// <param name="brcd">分類CODE</param>
        /// <returns>名称マスタ（複数レコード）</returns>
        public static DataTable GetMeishoMasterTable(decimal nmkbn, decimal brcd)
        {
            DataTable data = new DataTable("KMMEIS");

            string sql = "select * from KMMEIS where DEFLG = 0 and NMKBN = @nmkbn and BRCD = @brcd order by HYOJIJUN, NMCD";

            var parameters = new Dictionary<string, (object Value, SqlDbType Type)>
            {
                { "@nmkbn", (nmkbn, SqlDbType.Decimal) },
                { "@brcd", (brcd, SqlDbType.Decimal) }
            };

            if (SqlSeverControl.DbConnect())
            {
                bool result = SqlSeverControl.ExecuteSqlSelectQuery(sql, ref data, parameters);
            }

            return data;
        }

        /// <summary>
        /// 名称マスタ情報を取得します
        /// </summary>
        /// <param name="nmkbn">名称区分</param>
        /// <param name="nmcd">名称CODE</param>
        /// <param name="brcd">分類CODE</param>
        /// <returns>名称マスタ（１レコード）</returns>
        public static DataTable GetMeishoMaster(decimal nmkbn, string nmcd, decimal brcd)
        {
            string sql = "select * from KMMEIS where DEFLG = 0 and NMKBN = @nmkbn and BRCD = @brcd and NMCD = @nmcd";

            var parameters = new Dictionary<string, (object Value, SqlDbType Type)>
            {
                { "@nmkbn", (nmkbn, SqlDbType.Decimal) },
                { "@brcd", (brcd, SqlDbType.Decimal) },
                { "@nmcd", (nmcd, SqlDbType.VarChar) }

            };

            DataTable data = new DataTable("KMMEIS");

            if (SqlSeverControl.DbConnect())
            {
                bool result = SqlSeverControl.ExecuteSqlSelectQuery(sql, ref data, parameters);
            }

            return data;
        }

        /// <summary>
        /// 名称分類を取得します
        /// </summary>
        /// <param name="nmkbn">名称区分</param>
        /// <returns>指定された名称区分の分類CD=0のレコード(単一レコード)</returns>
        public static DataTable GetMeishoKbn(decimal nmkbn)
        {
            string sql = "select * from KMMEIS where DEFLG = 0 and NMKBN = @nmkbn and BRCD = 0";

            DataTable data = new DataTable("KMMEIS");

            var parameters = new Dictionary<string, (object Value, SqlDbType Type)>
            {
                { "@nmKbn", (nmkbn, SqlDbType.Decimal) }
            };

            if (SqlSeverControl.DbConnect())
            {
                bool result = SqlSeverControl.ExecuteSqlSelectQuery(sql, ref data, parameters);
            }

            return data;
        }

        /// <summary>
        /// 名称マスタから分類CD=0の一覧を取得します
        /// </summary>
        /// <returns>分類CD=0の名称マスタ一覧</returns>
        public static DataTable GetNmkbnList()
        {
            string sql = "SELECT NMKBN, CONCAT(NMKBN, '：', NM) AS NM FROM KMMEIS WHERE DEFLG = 0 AND BRCD = 0 ORDER BY NMKBN";

            DataTable data = new DataTable("KMMEIS");

            if (SqlSeverControl.DbConnect())
            {
                bool result = SqlSeverControl.ExecuteSqlSelectQuery(sql, ref data);
            }

            return data;
        }
        /// <summary>
        /// 名称区分を表すクラスです
        /// </summary>
        public static class NMKBN
        {
            #region 名称区分
            /// <summary>
            /// 名称区分：事業所
            /// </summary>
            public const decimal JIGYOSHO = 1;
            /// <summary>
            /// 名称区分：工場
            /// </summary>
            public const decimal KOJO = 2;
            /// <summary>
            /// 名称区分：営業所
            /// </summary>
            public const decimal EIGYOSHO = 3;
            /// <summary>
            /// 名称区分：製品ランク
            /// </summary>
            public const decimal SEIHIN_RANK = 4;
            /// <summary>
            /// 名称区分：担当者
            /// </summary>
            public const decimal TANTOSHA = 5;
            /// <summary>
            /// 名称区分：施主
            /// </summary>
            public const decimal SESHU = 6;
            /// <summary>
            /// 名称区分：物件元
            /// </summary>
            public const decimal BUKKENMOTO = 7;
            /// <summary>
            /// 名称区分：資材グループ
            /// </summary>
            public const decimal SHIZAI_GROUP = 8;
            /// <summary>
            /// 名称区分：行程
            /// </summary>
            public const decimal KOTEI = 9;
            /// <summary>
            /// 名称区分：施主区分
            /// </summary>
            public const decimal SESHU_KBN = 10;
            /// <summary>
            /// 名称区分：運送種別
            /// </summary>
            public const decimal UNSO_SHUBETSU = 11;
            /// <summary>
            /// 名称区分：単位
            /// </summary>
            public const decimal TANI = 12;
            /// <summary>
            /// 名称区分：鉄筋異形区分
            /// </summary>
            public const decimal TEKKIN_IKEI_KBN = 13;
            /// <summary>
            /// 名称区分：都道府県
            /// </summary>
            public const decimal TODOFUKEN = 14;
            /// <summary>
            /// 名称区分：見積納期
            /// </summary>
            public const decimal MITSUMORI_NOKI = 15;
            /// <summary>
            /// 名称区分：見積納入場所
            /// </summary>
            public const decimal MITSUMORI_NONYU_BASHO = 16;
            /// <summary>
            /// 名称区分：見積支払条件
            /// </summary>
            public const decimal MITSUMORI_SHIHARAI_JOKEN = 17;
            /// <summary>
            /// 名称区分：見積有効期間
            /// </summary>
            public const decimal MITSUMORI_YUKO_KIKAN = 18;
            /// <summary>
            /// 名称区分：重量単位
            /// </summary>
            public const decimal JURYO_TANI = 19;
            /// <summary>
            /// 名称区分：備考
            /// </summary>
            public const decimal BIKO = 20;
            /// <summary>
            /// 名称区分：担当集計変換
            /// </summary>
            public const decimal TANTO_SHUKEI_HENKAN = 21;
            /// <summary>
            /// 名称区分：支店
            /// </summary>
            public const decimal SHITEN = 22;
            /// <summary>
            /// 名称区分：変換単位
            /// </summary>
            public const decimal HENKAN_TANI = 23;
            /// <summary>
            /// 名称区分：部門
            /// </summary>
            public const decimal BUMON = 30;
            /// <summary>
            /// 名称区分：科目
            /// </summary>
            public const decimal KAMOKU = 31;
            /// <summary>
            /// 名称区分：回収方法
            /// </summary>
            public const decimal KAISHU_HOUHOU = 32;
            /// <summary>
            /// 名称区分：出張所
            /// </summary>
            public const decimal SHUCCHOJO = 50;
            /// <summary>
            /// 名称区分：銀行名称
            /// </summary>
            public const decimal GINKO_MEISHO = 51;
            /// <summary>
            /// 名称区分：材料区分
            /// </summary>
            public const decimal ZAIRYO_KBN = 52;
            /// <summary>
            /// 名称区分：予算自仕区
            /// </summary>
            public const decimal YOSAN_JISHIKU = 53;
            /// <summary>
            /// 名称区分；第二ランク
            /// </summary>
            public const decimal DAINI_RANK = 55;
            /// <summary>
            /// 名称区分：工場／営業所
            /// </summary>
            public const decimal KOJO_EIGYOSHO = 60;
            /// <summary>
            /// 名称区分：サブ工場
            /// </summary>
            public const decimal SUB_KOJO = 61;
            /// <summary>
            /// 名称区分：組織変換CD
            /// </summary>
            public const decimal SOSHIKI_HENKAN_CD = 62;
            /// <summary>
            /// 名称区分：管轄部署
            /// </summary>
            public const decimal KANKATSU_BUSHO = 63;
            /// <summary>
            /// 名称区分：見積用出張所
            /// </summary>
            public const decimal MITSUMORIYO_SHUCCHOJO = 64;
            /// <summary>
            /// 名称区分：科目変換CD
            /// </summary>
            public const decimal KAMOKU_HENKAN = 65;
            /// <summary>
            /// 名称区分：略名称？
            /// </summary>
            public const decimal RYAKU_MEISHO = 66;
            /// <summary>
            /// 名称区分：HPCトラス筋変換CD
            /// </summary>
            public const decimal HPC_TRASSUJI_HENKANCD = 71;
            /// <summary>
            /// 名称区分：HPCメッシュ筋変換CD
            /// </summary>
            public const decimal HPC_MESSHUSUJI_HENKANCD = 72;
            /// <summary>
            /// 名称区分：型枠業者分類
            /// </summary>
            public const decimal KATAWAKU_GYOSHA_BUNRUI = 81;
            /// <summary>
            /// 名称区分：型枠地区番号
            /// </summary>
            public const decimal KAWATAKU_CHIKU_BANGO = 82;
            /// <summary>
            /// 名称区分：棚卸理由
            /// </summary>
            public const decimal TANAOROSHI_RIYU = 83;
            /// <summary>
            /// 名称区分：置場
            /// </summary>
            public const decimal OKIBA = 84;
            /// <summary>
            /// 名称区分：特殊機械
            /// </summary>
            public const decimal TOKUSHU_KIKAI = 85;
            /// <summary>
            /// 名称区分：重点ランク
            /// </summary>
            public const decimal JUTEN_RANK = 86;
            /// <summary>
            /// 名称区分：入金変動科目
            /// </summary>
            public const decimal NYUKIN_HENDO_KAMOKU = 87;
            #endregion
        }

        /// <summary>
        /// 分類CDを表すクラスです
        /// </summary>
        public static class BRCD
        {
            #region 分類CD
            /// <summary>
            /// 分類CD 0:分類
            /// </summary>
            public const decimal BUNRUI = 0;

            /// <summary>
            /// 分類CD 1:名称
            /// </summary>
            public const decimal MEISHO = 1;
            #endregion
        }
    }
}