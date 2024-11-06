using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Kom_System_Common.CommonClass.Validation
{
    /// <summary>
    /// 日付検証クラス
    /// </summary>
    public class DateValidator : ValidatorBase
    {

        private string _ControlName;
        private string _Format;

        // 月初
        private const string BEGIN_MONTH = "00";

       // 月末
        private const string END_MONTH = "99";

        // 日付整形用日付
        private const string DAY_ONE = "01";

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="controlName">検証コントロール名</param>
        /// <param name="format">日付フォーマット</param>
        public DateValidator(string controlName,string format)
        {

            this._ControlName = controlName;
            this._Format = format;

        }

        /// <summary>
        /// 日付の検証
        /// </summary>
        /// <param name="control">日付コントロール</param>
        /// <returns>検証結果 OK:true、NG:false</returns>
        public override bool DoValidate(Control control)
        {

            if (string.IsNullOrEmpty(control.Text))
            {
                // null、空文字（未入力）はOKとする。
                return true;
            }

            string year;
            string month;
            string day;

            switch (_Format)
            {
                case DateValidator.DATEKBN.YYYY_MM_DD:
                    // YYYY/MM/DDの場合

                    if (control.Text.Length == 10)
                    {
                        year = control.Text.Substring(0, 4);
                        month = control.Text.Substring(5, 2);
                        day = control.Text.Substring(8, 2);

                        if (this.IsYear(year) && this.IsMonth(month) && this.IsDay(day))
                        {

                            if (day.ToString() != BEGIN_MONTH && day.ToString() != END_MONTH)
                            {

                                if (IsDate(control.Text))
                                {
                                    // 00,99以外の場合日付チェック
                                    return true;
                                }

                            }
                            else
                            {
                                // 00,99以外の場合日付チェックスキップ
                                return true;
                            }
                        }
                    }

                    SetMessage(MessageManager.GetMessageById("CM-E-0002", _ControlName, "YYYY/MM/DD形式"));
                    return false;

                case DateValidator.DATEKBN.YYYY_MM:

                    // YYYY/MMの場合

                    if (control.Text.Length == 7)
                    {

                        year = control.Text.Substring(0, 4);
                        month = control.Text.Substring(5, 2);

                        if (this.IsYear(year) && this.IsMonth(month))
                        {
                            if (IsDate(control.Text + "/" + DAY_ONE))
                            {
                                return true;
                            }
                        }
                    }

                    SetMessage(MessageManager.GetMessageById("CM-E-0002", _ControlName, "YYYY/MM形式"));
                    return false;

                case
                    DateValidator.DATEKBN.MM_DD:

                    if (control.Text.Length == 5)
                    {

                        // MM/DDの場合

                        month = control.Text.Substring(0, 2);
                        day = control.Text.Substring(3, 2);

                        // 日付整形用年
                        string editYear = DateTime.Now.ToString("yyyy/");


                        if (this.IsMonth(month) && this.IsDay(day))
                        {

                            if (day.ToString() != BEGIN_MONTH && day.ToString() != END_MONTH)
                            {
                                if (IsDate(editYear + control.Text))
                                {
                                    // 00,99以外の場合日付チェック
                                    return true;
                                }
                            }
                            else
                            {
                                // 00,99以外の場合日付チェックスキップ
                                return true;
                            }
                        }
                    }

                    SetMessage(MessageManager.GetMessageById("CM-E-0002", _ControlName, "MM/DD形式"));
                    return false;

                case
                    DateValidator.DATEKBN.DD:

                    // DDの場合

                    if (control.Text.Length == 2)
                    {

                        if (this.IsDay(control.Text))
                        {
                            return true;

                        }
                    }
                    SetMessage(MessageManager.GetMessageById("CM-E-0002", _ControlName, "DD形式"));
                    return false;

                default:
                    new ArgumentException($"書式が不正です。:{_Format}");
                    break;
            }
            return false;
        }


        private bool IsInt(string data)
        {
            return Regex.IsMatch(data, @"^[0-9]+$");
        }

        /// <summary>
        /// 有効な年かチェック（1000～9999）
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>

        private bool IsYear(string year)
        {
            if (IsInt(year))
            {
                int yearInt = Int32.Parse(year);
                if (1000 <= yearInt && yearInt <= 9999)
                {
                    
                    return true;
                }
                else
                {
                    //1000～9999以外の場合はエラー
                    return false;
                }
            }
            // 数値でない場合エラー
            return false;
        }

        /// <summary>
        /// 有効な月かチェック（1～12）
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>

        private bool IsMonth(string month)
        {
            if (IsInt(month))
            {
                int monthInt = Int32.Parse(month);
                if (1 <= monthInt && monthInt <= 12)
                {
                    
                    return true;
                }
                else
                {
                    //1～12以外の場合はエラー
                    return false;
                }
            }
            // 数値でない場合エラー
            return false;
        }

        /// <summary>
        /// 有効な日かチェック
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>

        private bool IsDay(string day)
        {

            if (IsInt(day))
            {
                int dayInt = Int32.Parse(day);


                if (0 <= dayInt && dayInt <=31 || dayInt == 99)
                {
                    
                    return true;
                }
                else
                {
                    // 0～31、99以外の場合はエラー
                    return false;
                }

            }

            // 数値でない場合エラー
            return false;
        }

        /// <summary>
        /// YYYY/MM/DD型のデータが日付がどうかチェック
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        private bool IsDate(string day)
        {

            return DateTime.TryParse(day, out var dateTime);

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