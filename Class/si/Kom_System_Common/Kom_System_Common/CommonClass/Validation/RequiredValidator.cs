using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Kom_System_Common.CommonClass.Validation
{
    /// <summary>
    /// 必須検証クラス
    /// </summary>
    public class RequiredValidator : ValidatorBase
    {

        private string _ControlName;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="controlName">検証コントロール名</param>
        public RequiredValidator(string controlName)
        {

            this._ControlName = controlName;

        }

        /// <summary>
        /// 必須入力の検証
        /// </summary>
        /// <param name="control">必須入力対象コントロール</param>
        /// <returns>検証結果 OK:true、NG:false</returns>
        public override bool DoValidate(Control control)
        {

            if (!string.IsNullOrEmpty(control.Text))
            {
                // null、空文字（未入力）でなければOK
                return true;
            }

            // null、空文字（未入力）NG
            SetMessage(MessageManager.GetMessageById("CM-E-0001", _ControlName));
            return false;

        }

    }
}