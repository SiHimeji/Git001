using System;
using System.Windows.Forms;

namespace Kom_System_Common.CommonClass
{
    public class FormClearer
    {
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <param name="form"></param>
        public static void ClearAllControls(Form form)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form), "Form cannot be null");
            }

            ClearControlsRecursive(form);
        }

        /// <summary>
        /// クリア条件
        /// </summary>
        /// <param name="control"></param>
        private static void ClearControlsRecursive(Control control)
        {
            foreach (Control childControl in control.Controls)
            {

                switch (childControl)
                {
                    case TextBox textBox:
                        if (-1 == textBox.Name.IndexOf("hdr") && -1 == textBox.Name.IndexOf("lbl"))
                        {
                            textBox.Clear();
                        }
                        break;
                    case ComboBox comboBox:
                        if (-1 == comboBox.Name.IndexOf("sh"))
                        {
                            comboBox.SelectedIndex = -1;
                        }
                        break;
                    case CheckBox checkBox:
                        checkBox.Checked = false;
                        break;
                    case RadioButton radioButton:
                        radioButton.Checked = false;
                        break;
                    case GroupBox groupBox:
                    case Panel panel:
                        ClearControlsRecursive(childControl);
                        break;
                    case SplitContainer splitContainer:
                        ClearControlsRecursive(childControl);
                        break;

                }

            }
        }
    }
}
