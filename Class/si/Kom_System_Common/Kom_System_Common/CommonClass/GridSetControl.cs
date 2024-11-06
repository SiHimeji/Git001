using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Kom_System_Common.CommonClass
{
    public class GridSetControl
    {
        /// <summary>
        /// 一覧部の表示
        /// </summary>
        /// <param name="gridRowCount">一覧部行数</param>
        /// <param name="tgtRow">表示開始行</param>
        /// <param name="gridData">表示するデータ</param>
        /// <param name="form">呼び出しフォーム</param>
        /// <param name="ReadOnly">一覧部のREADONLY属性</param>
        public static void SetGrid(int gridRowCount, int tgtRow, DataTable gridData, Form form, bool ReadOnly)
        {
            if (tgtRow < 0)
            {
                tgtRow = 0;
            }
            using (var sus = new FormRedrawSuspension(form))
            {
                if (tgtRow < 0 || tgtRow >= gridData.Rows.Count)
                {
                    MessageBox.Show("指定された行番号は存在しません。");
                    return;
                }
                int cnt = 1;
                for (int a = 0; a < gridRowCount; a++)
                {
                    if (gridData.Columns.Contains("STSKBN"))
                    {
                        if ((gridData.Rows[gridRowCount]["STSKBN"] + "").ToString() != "3")
                        {
                            if (a < gridData.Rows.Count)
                            {
                                DataRow row = gridData.Rows[tgtRow + a];

                                foreach (DataColumn column in gridData.Columns)
                                {
                                    var control = form.Controls.Find(column.ColumnName + "_" + cnt.ToString(), true).FirstOrDefault();

                                    if (control is TextBox textBox)
                                    {
                                        textBox.Text = row[column].ToString();
                                        textBox.Visible = true;
                                        if (ReadOnly)
                                        {
                                            textBox.ReadOnly = true;
                                        }
                                        else
                                        {
                                            textBox.ReadOnly = false;
                                        }

                                    }
                                    else if (control is ComboBox comboBox)
                                    {
                                        string value = row[column].ToString();
                                        comboBox.Visible = true;
                                        if (comboBox.Items.Contains(value))
                                        {
                                            comboBox.SelectedItem = value;
                                        }
                                        else
                                        {
                                            comboBox.SelectedIndex = -1;
                                        }

                                        if (ReadOnly)
                                        {
                                            comboBox.Enabled = true;
                                        }
                                        else
                                        {
                                            comboBox.Enabled = false;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                DataRow row = gridData.Rows[0];
                                foreach (DataColumn column in gridData.Columns)
                                {
                                    var control = form.Controls.Find(column.ColumnName + "_" + cnt.ToString(), true).FirstOrDefault();
                                    if (control != null)
                                    {
                                        control.Visible = false;
                                    }
                                }
                            }
                            cnt++;
                        }
                    }
                    else
                    {
                        if (a < gridData.Rows.Count)
                        {
                            DataRow row = gridData.Rows[tgtRow + a];

                            foreach (DataColumn column in gridData.Columns)
                            {
                                var control = form.Controls.Find(column.ColumnName + "_" + cnt.ToString(), true).FirstOrDefault();

                                if (control is TextBox textBox)
                                {
                                    textBox.Text = row[column].ToString();
                                    textBox.Visible = true;
                                    if (ReadOnly)
                                    {
                                        textBox.ReadOnly = true;
                                    }
                                    else
                                    {
                                        textBox.ReadOnly = false;
                                    }

                                }
                                else if (control is ComboBox comboBox)
                                {
                                    string value = row[column].ToString();
                                    comboBox.Visible = true;
                                    if (comboBox.Items.Contains(value))
                                    {
                                        comboBox.SelectedItem = value;
                                    }
                                    else
                                    {
                                        comboBox.SelectedIndex = -1;
                                    }

                                    if (ReadOnly)
                                    {
                                        comboBox.Enabled = true;
                                    }
                                    else
                                    {
                                        comboBox.Enabled = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            DataRow row = gridData.Rows[0];
                            foreach (DataColumn column in gridData.Columns)
                            {
                                var control = form.Controls.Find(column.ColumnName + "_" + cnt.ToString(), true).FirstOrDefault();
                                if (control != null)
                                {
                                    control.Visible = false;
                                }
                            }
                        }
                        cnt++;
                    }
                }
            }
        }

        /// <summary>
        /// カーソル移動によるヘッダー部の色変更処理
        /// </summary>
        /// <param name="form"></param>
        /// <param name="Control"></param>
        /// <param name="ChgClolor"></param>
        public static void HederTextBackColorChange(Form form, Object Control, Color ChgClolor)
        {
            if (Control is System.Windows.Forms.TextBox)
            {
                TextBox Tet = (TextBox)Control;
                string[] strFLD = Tet.Name.Split('_');
                Control control = form.Controls.Find("hdr_" + strFLD[0], true).FirstOrDefault();
                if (control != null)
                {
                    control.BackColor = ChgClolor;
                }
            }
            else
            {
                ComboBox Cmb = (ComboBox)Control;
                string[] strFLD = Cmb.Name.Split('_');
                Control control = form.Controls.Find("hdr_" + strFLD[0], true).FirstOrDefault();
                if (control != null)
                {
                    control.BackColor = ChgClolor;
                }
            }
        }

        /// <summary>
        /// 行追加処理
        /// </summary>
        /// <param name="gridData"></param>
        public static void GridDataRowAdd(ref DataTable gridData)
        {
            gridData.Rows.Add();
        }
    }
}
