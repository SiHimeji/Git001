using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Kom_System_Common.CommonClass.Validation
{
    /// <summary>
    /// 半角文字検証クラス
    /// </summary>
    /// <example>
    /// 例)
    /// <code>
    /// var validation = new ValidationUtil(label1);
    /// validation.Add(this.textBox1, new HalfCharValidator("コントロール名1")); // 記号なし
    /// validation.Add(this.textBox2, new HalfCharValidator("コントロール名2", true)); // 記号あり
    /// </code>
    /// </example>
    public class HalfCharValidator : ValidatorBase
    {
        /// <summary>
        /// コントローラー名
        /// </summary>
        private string _ControllName;

        /// <summary>
        /// 記号有効・無効フラグ
        /// </summary>
        private bool _IsEnabledSymbol = false;

        /// <summary>
        /// 記号有効パターン
        /// </summary>
        private const string PATTERN_ENABLED_SYMBOL = @"^[0-9a-zA-Z-_#$%&]+$";

        /// <summary>
        /// 記号無効パターン
        /// </summary>
        private const string PATTERN_DISABLED_SYMBOL = @"^[0-9a-zA-Z]+$";

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="isEnabledSymbol">記号が有効の場合:true、記号が無効の場合:false。デフォルト値:false</param>
        public HalfCharValidator(string controllName, bool isEnabledSymbol = false)
        {
            this._ControllName = controllName;
            this._IsEnabledSymbol = isEnabledSymbol;
        }

        /// <summary>
        /// 半角文字の検証を行います
        /// </summary>
        /// <param name="control">日付コントロール</param>
        /// <returns>検証結果 OK:true、NG:false</returns>
        public override bool DoValidate(Control control)
        {
            if (string.IsNullOrEmpty(control.Text))
            {
                return true;
            }
            string pattern = (this._IsEnabledSymbol) ? PATTERN_ENABLED_SYMBOL : PATTERN_DISABLED_SYMBOL;

            if (Regex.IsMatch(control.Text, pattern))
            {
                return true;
            }

            if (this._IsEnabledSymbol)
            {
                this.SetMessage(MessageManager.GetMessageById("CM-E-0002", _ControllName, $"半角英数字、記号（&&-_#$%）"));
            }
            else
            {
                this.SetMessage(MessageManager.GetMessageById("CM-E-0002", _ControllName, "半角英数字"));
            }
            return false;
        }
    }
}
