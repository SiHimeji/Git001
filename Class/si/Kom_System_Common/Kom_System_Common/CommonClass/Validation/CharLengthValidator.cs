using System;
using System.Windows.Forms;

namespace Kom_System_Common.CommonClass.Validation
{
    /// <summary>
    /// 文字数検証クラス
    /// </summary>
    public class CharLengthValidator : ValidatorBase
    {

        private string _ControlName;
        private int _LengthKbn;
        private int _Length;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="controlName">検証コントロール名</param>
        /// <param name="kbn">区分（0：以下、1：以上）</param>
        /// <param name="len">文字数</param>
        public CharLengthValidator(string controlName, int kbn ,int len)
        {
            this._ControlName = controlName;
            this._LengthKbn = kbn;
            this._Length = len;
        }

        /// <summary>
        /// 文字数の検証を行います
        /// </summary>
        /// <param name="control">文字数を検証したいコントロール</param>
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
                case CHARLENGTHKBN.LESS: /// 以下
                    if (control.Text.Length <= _Length)
                    {
                        // コントロールの文字数が指定した文字数以下
                        return true;
                    }

                    // コントロールの文字数が指定した文字数超過の場合
                    SetMessage(MessageManager.GetMessageById("CM-E-0002", _ControlName, $"{_Length}文字以下"));
                    return false;

                case CHARLENGTHKBN.GREATER: /// 以上
                    if (control.Text.Length >= _Length)
                    {
                        return true;
                    }

                    // コントロールの文字数が指定した文字数未満の場合
                    SetMessage(MessageManager.GetMessageById("CM-E-0002", _ControlName, $"{_Length}文字以上"));
                    return false;

                default:
                    new ArgumentException($"区分が不正です。:{_LengthKbn}");
                    break;
            }
            return false;
        }

        /// <summary>
        /// 文字数区分
        /// </summary>
        public static class CHARLENGTHKBN
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
