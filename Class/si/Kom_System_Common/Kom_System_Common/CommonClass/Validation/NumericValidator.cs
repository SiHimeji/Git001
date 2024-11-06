using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Kom_System_Common.CommonClass.Validation
{
    /// <summary>
    /// 数値検証クラス
    /// </summary>
    public class NumericValidator : ValidatorBase
    {

        private string _ControlName;
        private int _IntDigit;
        private int _DecimalDigit;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="controlName">検証コントロール名</param>
        /// <param name="intDigit">整数部分桁数</param>
        /// <param name="decimalDigit">小数部分桁数</param>
        public NumericValidator(string controlName, int intDigit, int decimalDigit)
        {

            this._ControlName = controlName;
            this._IntDigit = intDigit;
            this._DecimalDigit = decimalDigit;

        }

        /// <summary>
        /// 数値の検証
        /// </summary>
        /// <param name="control">数値検証コントロール</param>
        /// <returns>検証結果 OK:true、NG:false</returns>
        public override bool DoValidate(Control control)
        {
            if (string.IsNullOrEmpty(control.Text))
            {
                // null、空文字（未入力）はOKとする。
                return true;
            }

            double controlDouble;

            if (double.TryParse(control.Text, out controlDouble))
            {
                // 桁数チェックは絶対値で行う
                string absControlDouble = Math.Abs(controlDouble).ToString();
                int index = absControlDouble.IndexOf(".");
                string controlIntPart;
                string controlDecimalPart;

                if (index != -1)
                {
                    // 小数点がある場合、小数点前後を設定
                    controlIntPart = absControlDouble.Substring(0,index);
                    controlDecimalPart = absControlDouble.Substring(index+1);

                }
                else
                {
                    // 小数点がない場合、入力値を整数部分にセット
                    controlIntPart = absControlDouble;
                    controlDecimalPart = string.Empty;

                }

                if (controlIntPart.Length <= _IntDigit && controlDecimalPart.Length <= _DecimalDigit)
                {
                    // 指定桁数以内であればOK
                    return true;

                }
                else
                {
                    // 指定桁数超過であればNG
                    SetMessage(MessageManager.GetMessageById("CM-E-0002", _ControlName, $"整数{_IntDigit}桁、小数{_DecimalDigit}桁"));
                    return false;

                }
            }
            else
            {
                //double型変換出来ない場合エラー
                this.SetMessage(MessageManager.GetMessageById("CM-E-0002", _ControlName, "数値"));
                return false;

            }
        }
    }
}