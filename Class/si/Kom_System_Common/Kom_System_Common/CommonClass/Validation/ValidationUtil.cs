using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Kom_System_Common.CommonClass.Validation
{
    public class ValidationUtil
    {
        private Dictionary<string, List<Control>> dicControls = new Dictionary<string, List<Control>>();

        private Dictionary<string, Dictionary<Control, List<ValidatorBase>>> dicValidations = new Dictionary<string, Dictionary<Control, List<ValidatorBase>>>();

        private string _Message;

        /// <summary>
        /// バリデーションチェック追加
        /// </summary>
        /// <param name="control">コントロール</param>
        /// <param name="validation">バリデーション種別</param>
        /// <param name="validationGroup">バリデーショングループ</param>
        public void Add(Control control, ValidatorBase validation, string validationGroup = "")
        {
            // dicControlsの登録
            if (dicControls.ContainsKey(validationGroup))
            {
                // バリデーショングループ登録あり
                var list = dicControls[validationGroup];
                if (!list.Contains(control))
                {
                    list.Add(control);
                }
            }
            else
            {
                // バリデーショングループ登録なし
                var list = new List<Control>();
                list.Add(control);
                dicControls.Add(validationGroup, list);
            }

            // dicValidationsの登録
            if (dicValidations.ContainsKey(validationGroup))
            {
                // バリデーショングループ登録あり
                var dicValidationCotrol = dicValidations[validationGroup];
                if (dicValidationCotrol.ContainsKey(control))
                {
                    // コントロール登録あり
                    var list = dicValidationCotrol[control];
                    if (!list.Contains(validation))
                    {
                        list.Add(validation);
                    }
                }
                else
                {
                    // コントロール登録なし
                    var list = new List<ValidatorBase>();
                    list.Add(validation);
                    dicValidationCotrol.Add(control, list);
                }
            }
            else
            {
                // バリデーショングループ登録なし
                var dicValidationControl = new Dictionary<Control, List<ValidatorBase>>();
                var list = new List<ValidatorBase>();
                list.Add(validation);
                dicValidationControl.Add(control, list);
                dicValidations.Add(validationGroup, dicValidationControl);
            }
        }

        /// <summary>
        /// 入力値チェック
        /// 入力チェックを行ってエラーがあった場合はメッセージラベルにエラーメッセージを表示します。
        /// </summary>
        /// <param name="validationGroup">検証グループ名</param>
        /// <returns>検証結果 OK:true、NG:false</returns>
        /// <exception cref="KeyNotFoundException">指定されていない検証グループキーが渡された場合に発行する例外</exception>
        public bool IsValid(string validationGroup = "")
        {
            // 指定のグループが無い場合
            if (!dicControls.ContainsKey(validationGroup))
            {
                throw new KeyNotFoundException(string.Format("指定されたValidationGroupは登録されていません:{0}", validationGroup));
            }

            _Message = string.Empty;

            // TabIndex順にソートしてチェック
            var controls = dicValidations[validationGroup];
            foreach (Control control in dicControls[validationGroup].OrderBy(x => x.TabIndex).ToArray())
            {
                foreach (ValidatorBase validation in controls[control])
                {
                    if (!validation.DoValidate(control))
                    {
                        if (control != null)
                        {
                            _Message = validation.GetMessage();
                        }

                        // エラーを検知したコントロールはbreakして次のコントロールの検証を行う
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 検証結果メッセージを返します
        /// </summary>
        /// <returns>検証結果メッセージ</returns>
        public string GetMessage()
        {
            return _Message;
        }
    }
}