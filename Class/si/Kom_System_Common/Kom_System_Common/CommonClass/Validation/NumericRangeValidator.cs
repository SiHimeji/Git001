using System;
using System.Windows.Forms;

namespace Kom_System_Common.CommonClass.Validation
{
    /// <summary>
    /// 数値範囲検証クラス
    /// </summary>
    public class NumericRangeValidator : ValidatorBase
    {

        private string _ControlName;
        private int _LengthKbn;
        private double _BaseDouble;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="controlName">検証コントロール名</param>
        /// <param name="kbn">区分（0：以下、1：以上）</param>
        /// <param name="baseDouble">基準値</param>
        public NumericRangeValidator(string controlName, int kbn ,double baseDouble)
        {
            this._ControlName = controlName;
            this._LengthKbn = kbn;
            this._BaseDouble = baseDouble;
        }

        /// <summary>
        /// 数値範囲の検証を行います
        /// </summary>
        /// <param name="control">数値範囲を検証したいコントロール</param>
        /// <returns>検証結果 OK:true、NG:false</returns>
        public override bool DoValidate(Control control)
        {

            if (string.IsNullOrEmpty(control.Text))
            {
                // null、空文字（未入力）はOKとする。
                return true;
            }

            switch (_LengthKbn)
            {
                case NUMERICRANGEKBN.LESS: /// 以下
                    if (double.Parse(control.Text) <= _BaseDouble)
                    {
                        // コントロールの文字数が指定した文字数以下
                        return true;
                    }

                    // コントロールの文字数が指定した文字数超過の場合
                    SetMessage(MessageManager.GetMessageById("CM-E-0002", _ControlName, $"{_BaseDouble}以下"));
                    return false;

                case NUMERICRANGEKBN.GREATER: /// 以上
                    if (double.Parse(control.Text) >= _BaseDouble)
                    {
                        return true;
                    }

                    // コントロールの文字数が指定した文字数未満の場合
                    SetMessage(MessageManager.GetMessageById("CM-E-0002", _ControlName, $"{_BaseDouble}以上"));
                    return false;

                default:
                    new ArgumentException($"区分が不正です。:{_LengthKbn}");
                    break;
            }
            return false;
        }

        /// <summary>
        /// 数値範囲区分
        /// </summary>
        public static class NUMERICRANGEKBN
        {
            #region 文字数区分
            /// <summary>
            /// 以下
            /// </summary>
            public const int LESS = 0;
            /// <summary>
            /// 以上
            /// </summary>
            public const int GREATER = 1;

            #endregion
        }
    }
}
