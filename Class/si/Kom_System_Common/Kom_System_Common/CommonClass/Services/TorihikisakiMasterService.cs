using System.Collections.Generic;
using System.Data;

namespace Kom_System_Common.CommonClass.Services
{
    /// <summary>
    /// 取引先マスタサービスクラス
    /// </summary>
    public static class TorihikisakiMasterService
    {

        /// <summary>
        /// 取引先マスタ情報を取得します
        /// </summary>
        /// <param name="thcd">取引先コード</param>
        /// <param name="isExistsDelete">削除データ除外フラグ true：削除データを除外する false：削除データを除外しない</param>
        /// <returns>取引先マスタ（１レコード）</returns>
        public static DataTable GetTorihikisaki(string thcd, bool isExistsDelete = true)
        {
            string sql = string.Empty;
            if (isExistsDelete)
            {
                sql = "select * from KMTORI where DEFLG = 0 and THCD = @thcd";
            }
            else
            {
                sql = "select * from KMTORI where THCD = @thcd";
            }

            var parameters = new Dictionary<string, (object Value, SqlDbType Type)>
            {
                { "@thcd", (thcd, SqlDbType.VarChar) },

            };

            DataTable data = new DataTable("KMTORI");

            if (SqlSeverControl.DbConnect())
            {
                bool result = SqlSeverControl.ExecuteSqlSelectQuery(sql, ref data, parameters);
            }

            return data;
        }

        /// <summary>
        /// 取引先区分
        /// </summary>
        public static class TKBN
        {
            /// <summary>
            /// 取引先区分 1:得意先
            /// </summary>
            public const decimal TOKUISAKI = 1;

            /// <summary>
            /// 取引先区分 2:仕入先
            /// </summary>
            public const decimal SHIRESAKI = 2;

            /// <summary>
            /// 取引先区分 9:全て
            /// </summary>
            public const decimal ALL = 9;
        }
    }
}
