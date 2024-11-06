using System;
using System.Collections.Generic;
using System.Data;
using Kom_System_Common.CommonClass;

namespace Kom_System_Common.CommonClass.Services
{
    public static class ControlMasterService
    {
        // 静的なLoggerServiceインスタンスを一度だけ生成して再利用
        private static readonly LoggerService logger = new LoggerService();

        /// <summary>
        /// コントロールマスタの一覧を取得します
        /// </summary>
        /// <param name="cd1">コード</param>
        /// <param name="jcd1">事業所コード</param>
        /// <returns>コントロールマスタ（1レコード）</returns>
        public static DataTable GetControlMasterTable(string cd1, string jcd)
        {
            decimal jcd1 = 0;

            try
            {
                jcd1 = decimal.Parse(jcd);
            }
            catch (Exception ex)
            {   
                logger.LogError(ex.Message);
            }

            DataTable data = new DataTable("KMCONT");

            string sql = "select * from KMCONT where DEFLG1 = 0 and CD1 = @cd1 and JCD1 = @jcd1";

            var parameters = new Dictionary<string, (object Value, SqlDbType Type)>
            {
                { "@cd1", (cd1, SqlDbType.VarChar) },
                { "@jcd1", (jcd1, SqlDbType.Decimal) }
            };

            if (SqlSeverControl.DbConnect())
            {
                bool result = SqlSeverControl.ExecuteSqlSelectQuery(sql, ref data, parameters);
            }
            return data;
        }


        /// <summary>
        /// コードを表すクラスです
        /// </summary>
        public static class CD1
        {
            // 販売
            public const string CD1_A = "A";

            // 購買
            public const string CD1_C = "C";

            // 生産
            public const string CD1_E = "E";
        }

        /// <summary>
        /// 月次・年次FLGを表すクラスです
        /// </summary>
        public static class FLG
        {
            // 未処理
            public const string FLG_NO_START = "0";

            // 処理済
            public const string FLG_PROCESSED = "99";
        }
    }
}