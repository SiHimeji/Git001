using System.Collections.Generic;
using System.Data;
using static Kom_System_Common.CommonClass.Services.MeishoMasterService;

namespace Kom_System_Common.CommonClass.Services
{
    /// <summary>
    /// 製品マスタサービスクラス
    /// </summary>
    public static class SeihinMasterService
    {
        /// <summary>
        /// 製品マスタデータ取得
        /// </summary>
        /// <param name="seicd">製品コード</param>
        /// <param name="isExistsDelete">削除データ除外フラグ。true：削除データを除外する</param>
        /// <returns>製品コードに紐づく単一レコードを返す</returns>
        public static DataTable GetSeihinMaster(string seicd, bool isExistsDelete = true)
        {

            DataTable data = new DataTable("KMSEIH");

            string sql = null;
            if (isExistsDelete)
            {
                sql = "select * from KMSEIH where DEFLG = 0 and SEICD = @seicd";
            }
            else
            {
                sql = "select * from KMSEIH where SEICD = @seicd";
            }

            var parameters = new Dictionary<string, (object Value, SqlDbType Type)>
            {
                { "@seicd", (seicd, SqlDbType.VarChar) },
            };

            if (SqlSeverControl.DbConnect())
            {
                bool result = SqlSeverControl.ExecuteSqlSelectQuery(sql, ref data, parameters);
            }

            return data;
        }

        /// <summary>
        /// セット区分
        /// </summary>
        public static class KBN
        {
            /// <summary>
            /// 製品
            /// </summary>
            public const decimal SEIHIN = 0;

            /// <summary>
            /// セット区分
            /// </summary>
            public const decimal SETHIN = 1;
        }

        /// <summary>
        /// 製品区分
        /// </summary>
        public static class SEIKBN
        {
            /// <summary>
            /// 出荷基準売上
            /// </summary>
            public const decimal SHUKKA_URIAGE = 0;

            /// <summary>
            /// その他売上
            /// </summary>
            public const decimal SONOTA_URIAGE = 1;
        }
    }
}
