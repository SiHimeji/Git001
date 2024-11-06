using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kom_System_Common.CommonClass.Validation
{
    public abstract class ValidatorBase
    {
        private string _message;

        /// <summary>
        /// 検証処理を実行します
        /// </summary>
        /// <param name="control">検証対象のコントロール</param>
        /// <returns>検証結果 OK:true、NG:false</returns>
        public abstract bool DoValidate(Control control);

        /// <summary>
        /// エラーメッセージを設定します
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public void SetMessage(string message)
        {
            this._message = message;
        }

        /// <summary>
        /// エラーメッセージを返します
        /// </summary>
        /// <returns>エラーメッセージ</returns>
        public string GetMessage()
        {
            return _message;
        }

        /// <summary>
        /// エラーメッセージをクリアします
        /// </summary>
        public void ClearMessage()
        {
            _message = string.Empty;
        }
    }
}