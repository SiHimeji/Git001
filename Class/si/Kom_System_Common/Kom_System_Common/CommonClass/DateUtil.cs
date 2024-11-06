using Kom_System_Common.CommonClass.Validation;
using System;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Kom_System_Common.CommonClass
{
    /// <summary>
    /// 日付型ユーティリティ
    /// </summary>
    public class DateUtil
    {

        // 日付整形用日付
        private const string DAY_ONE = "01";

        /// <summary>
        /// String型→Decimal型変換
        /// </summary>
        /// <param name="form"></param>
        public static decimal? DateStringToDecimal(string stringDate)
        {
            if (string.IsNullOrEmpty(stringDate))
            {
                return null;
            }

            return decimal.Parse(stringDate.Replace("/", ""));

        }

        /// <summary>
        /// String型→DataTime型変換
        /// </summary>
        /// <param name="stringDate"></param>
        /// <returns></returns>
        public static DateTime? DateStringToDateTime(string stringDate,string kbn)
        {

            if (string.IsNullOrEmpty(stringDate))
            {
                return null;
            }


            DateTime? date = null;
            string editYear = DateTime.Now.ToString("yyyy/");
            string editYearMonth = DateTime.Now.ToString("yyyy/MM/");

            switch (kbn)
            {
                case DateUtil.DATEKBN.YYYY_MM_DD:
                    // YYYY/MM/DDの場合

                    return DateTime.Parse(stringDate);


                case DateUtil.DATEKBN.YYYY_MM:

                    // YYYY/MMの場合
                    return DateTime.Parse(stringDate+ "/" + DAY_ONE);

                case DateUtil.DATEKBN.MM_DD:
                    // MM/DDの場合

                    return DateTime.Parse(editYear + stringDate);

                case DateUtil.DATEKBN.DD:
                    // DDの場合
                    return DateTime.Parse(editYearMonth + stringDate);

                default:
                    new ArgumentException($"書式が不正です。:{kbn}");
                    return date;
                    
            }
            
        }


        /// <summary>
        /// 日付型区分
        /// </summary>
        public static class DATEKBN
        {
            #region 日付型区分
            /// <summary>
            /// 日付型区分：YYYY/MM/DD
            /// </summary>
            public const string YYYY_MM_DD = "YYYY/MM/DD";
            /// <summary>
            /// 日付型区分：YYYY/MM
            /// </summary>
            public const string YYYY_MM = "YYYY/MM";
            /// <summary>
            /// 日付型区分：MM_DD
            /// </summary>
            public const string MM_DD = "MM/DD";
            /// <summary>
            /// 日付型区分：DD
            /// </summary>
            public const string DD = "DD";

            #endregion
        }
    }
}
