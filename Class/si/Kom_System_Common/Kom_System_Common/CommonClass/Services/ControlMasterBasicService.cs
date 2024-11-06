using System;
using System.Collections.Generic;
using System.Data;
using Kom_System_Common.CommonClass;

namespace Kom_System_Common.CommonClass.Services
{
    public static class ControlMasterBasicService
    {
        // 静的なLoggerServiceインスタンスを一度だけ生成して再利用
        private static readonly LoggerService logger = new LoggerService();

        /// <summary>
        /// コントロールマスタ（基本）の一覧を取得します
        /// </summary>
        /// <param name="jcd">事業所コード</param>
        /// <returns>コントロールマスタ（基本）（1レコード）</returns>
        public static DataTable GetControlMasterBasicTable(string jcd)
        {
            decimal jcd2 = 0;

            try
            {
                jcd2 = decimal.Parse(jcd);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            DataTable data = new DataTable("KMCONM");

            string sql = "select * from KMCONM where DEFLG2 = 0 and CD2 = '0' and JCD2 = @jcd2";

            var parameters = new Dictionary<string, (object Value, SqlDbType Type)>
            {
                { "@jcd2", (jcd2, SqlDbType.Decimal) }
            };

            if (SqlSeverControl.DbConnect())
            {
                bool result = SqlSeverControl.ExecuteSqlSelectQuery(sql, ref data, parameters);
            }
            return data;
        }
    }
}