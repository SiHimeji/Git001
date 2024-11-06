using System.Collections.Generic;
using System.Data;

namespace Kom_System_Common.CommonClass.Services
{
    /// <summary>
    /// 資材マスタサービス
    /// </summary>
    public static class ShizaiMasterService
    {
        public static DataTable GetShizai(string zaicd, bool isExistsDelete = true)
        {
            string sql = string.Empty;
            if (isExistsDelete)
            {
                sql = "select * from KMZAIR where DEFLG = 0 and ZAICD = @zaicd";
            }
            else
            {
                sql = "select * from KMZAIR where ZAICD = @zaicd";
            }

            var parameters = new Dictionary<string, (object Value, SqlDbType Type)>
            {
                { "@zaicd", (zaicd, SqlDbType.VarChar) },

            };

            DataTable data = new DataTable("KMZAIR");

            if (SqlSeverControl.DbConnect())
            {
                bool result = SqlSeverControl.ExecuteSqlSelectQuery(sql, ref data, parameters);
            }

            return data;

        }

        /// <summary>
        /// 資材区分
        /// </summary>
        public static class ZAIKBN
        {

            /// <summary>
            /// 資材区分 0:主要材料
            /// </summary>
            public const decimal SHUYO = 0;

            /// <summary>
            /// 資材区分 1:鉄筋
            /// </summary>
            public const decimal TEKKIN = 1;

            /// <summary>
            /// 取引先区分 2:個別補助材料
            /// </summary>
            public const decimal KOBETSUHOJOZAI = 2;

            /// <summary>
            /// 資材区分 3:その他補助材
            /// </summary>
            public const decimal SONOTAHOJOZAI = 1;

            /// <summary>
            /// 取引先区分 4:消耗工具備品
            /// </summary>
            public const decimal SHOMOKOGUBIHIN = 2;

            /// <summary>
            /// 資材区分 5:間接外注費
            /// </summary>
            public const decimal KANSETSUGAICHUHI = 1;

            /// <summary>
            /// 取引先区分 6:その他経費
            /// </summary>
            public const decimal SONOTAKEIHI = 2;

        }
    }
}
