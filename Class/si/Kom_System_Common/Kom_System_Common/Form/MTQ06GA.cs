using Kom_System_Common.CommonClass;
using Kom_System_Common.CommonClass.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kom_System_Common
{
    public partial class MTQ06GA : Form
    {
        private const int DEFAULT_SERACH_LIMIT = 1000;
        private const string SEARCH_LIMIT = "MTQ06GA_SearchLimit";

        private int _SearchLimit = 0;
        private LoggerService _Logger = new LoggerService();

        /// <summary>
        /// 戻り値
        /// </summary>
        public string ResultValue { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MTQ06GA()
        {
            InitializeComponent();

        }

        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MTQ06GA_Load(object sender, EventArgs e)
        {
            // 初期設定
            // 表示制限件数
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings[SEARCH_LIMIT]))
            {
                // 設定が無かったら初期値
                _SearchLimit = DEFAULT_SERACH_LIMIT;
            }
            else
            {
                // 設定値があれば設定値
                _SearchLimit = int.Parse(ConfigurationManager.AppSettings[SEARCH_LIMIT]);
            }
            dgv_Shizaif.AutoGenerateColumns = false;

            // 名称マスタから資材区分を取得してチェックボックスを作成する
            var shizaiKbn = MeishoMasterService.GetMeishoMasterTable(MeishoMasterService.NMKBN.ZAIRYO_KBN, MeishoMasterService.BRCD.MEISHO);
            foreach (DataRow row in shizaiKbn.Rows)
            {
                pnl_Zaikbn.Controls.Add(new CheckBox() { Name = $"chk_ShizaiKbn_{row["NMCD"].ToString()}", Text = row["NM"].ToString(), TabIndex = 2 });
            }
        }

        /// <summary>
        /// キーダウンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MTQ06GA_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (dgv_Shizaif.Focused)
                {
                    if (dgv_Shizaif.CurrentRow.Index >= 0)
                    {
                        this.SelectData();
                    }
                }

                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                e.Handled |= true;
            }

            switch (e.KeyCode)
            {
                case Keys.F1:
                    this.Search();
                    break;
                case Keys.F5:
                    if (dgv_Shizaif.CurrentRow == null)
                    {
                        MessageBox.Show(MessageManager.GetMessageById("CM-E-0004"), MessageManager.CAPTION.ERROR);
                        return;
                    }
                    this.SelectData();
                    break;
                case Keys.F9:
                    if (e.Shift)
                    {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                    }
                    break;
            }
        }

        /// <summary>
        /// 一覧ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        /// <summary>
        /// 終了ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Cancel();
        }

        /// <summary>
        /// 選択ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.SelectData();
        }

        /// <summary>
        /// データグリッドダブルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Shizai_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string zaicd = dgv_Shizaif.Rows[e.RowIndex].Cells["ZAICD"].Value.ToString();

            this.DialogResult = DialogResult.OK;
            this.ResultValue = zaicd;
        }

        #region 内部メソッド
        /// <summary>
        /// 検索処理
        /// </summary>
        private void Search()
        {

            // 資材区分テキストボックス作成
            List<string> inShizaiKbn = new List<string>();

            var checklist = new List<Control>();
            foreach (var ctrl in pnl_Zaikbn.Controls.OfType<CheckBox>())
            {

                if (ctrl.Checked)
                {
                    inShizaiKbn.Add(ctrl.Name.Replace("chk_ShizaiKbn_", String.Empty));
                }
            }


            StringBuilder sb = new StringBuilder();
            var param = new Dictionary<string, (object, SqlDbType)>();
            sb.AppendLine($"SELECT TOP {_SearchLimit}");
            sb.AppendLine("    ROW_NUMBER() OVER (ORDER BY KMZAIF.ZAICD, KMZAIF.KOJCD) AS RNUM ");
            sb.AppendLine("    , KMZAIF.KOJCD ");
            sb.AppendLine("    , KMZAIF.ZAICD ");
            sb.AppendLine("    , KMZAIR.NAME1 ");
            sb.AppendLine("    , KMZAIR.NAME2 ");
            sb.AppendLine("    , KMZAIR.NAME3 ");
            sb.AppendLine("    , KMMEIS.NM AS ZAIKBNNM ");
            sb.AppendLine("    , KMZAIR.TANINM  ");
            sb.AppendLine("FROM ");
            sb.AppendLine("    KMZAIF  ");
            sb.AppendLine("    INNER JOIN KMZAIR  ");
            sb.AppendLine("        ON KMZAIF.ZAICD = KMZAIR.ZAICD  ");
            sb.AppendLine("    INNER JOIN KMMEIS  ");
            sb.AppendLine($"    ON KMMEIS.NMKBN = '{MeishoMasterService.NMKBN.ZAIRYO_KBN}' ");
            sb.AppendLine($"    AND KMMEIS.BRCD = '{MeishoMasterService.BRCD.MEISHO}' ");
            sb.AppendLine("        AND KMZAIR.ZAIKBN = KMMEIS.NMCD ");
            sb.AppendLine("WHERE ");
            sb.AppendLine("    KMZAIF.DEFLG = 0 ");
            sb.AppendLine("    AND KMZAIR.DEFLG = 0 ");
            sb.AppendLine("    AND KMMEIS.DEFLG = 0 ");

            if (!string.IsNullOrEmpty(sh_Kojcd.Text.Trim()))
            {
                // 工場コード
                sb.AppendLine("AND KMZAIF.KOJCD LIKE @KOJCD");
                param.Add("@KOJCD", ($"{SqlEscapeUtil.ReplaceSqlLikeSearch(sh_Kojcd.Text.Trim())}%", SqlDbType.VarChar));

            }

            if (!string.IsNullOrEmpty(sh_Zaicd.Text.Trim()))
            {
                // 資材コード
                sb.AppendLine("AND KMZAIF.ZAICD LIKE @ZAICD");
                param.Add("@ZAICD", ($"{SqlEscapeUtil.ReplaceSqlLikeSearch(sh_Zaicd.Text.Trim())}%", SqlDbType.VarChar));

            }

            if (inShizaiKbn.Count > 0)
            {
                // 資材区分
                sb.AppendLine($"AND KMZAIR.ZAIKBN IN ({SqlEscapeUtil.ReplaceSqlLikeSearch(String.Join(",", inShizaiKbn))})");

            }

            if (!string.IsNullOrEmpty(sh_Name1.Text.Trim()))
            {
                // 資材名
                sb.AppendLine("AND KMZAIR.NAME1 LIKE @NAME1");
                param.Add("@NAME1", ($"%{SqlEscapeUtil.ReplaceSqlLikeSearch(sh_Name1.Text.Trim())}%", SqlDbType.VarChar));

            }

            if (!string.IsNullOrEmpty(sh_Name2.Text.Trim()))
            {
                // 型式・形状
                sb.AppendLine("AND KMZAIR.NAME2 LIKE @NAME2");
                param.Add("@NAME2", ($"%{SqlEscapeUtil.ReplaceSqlLikeSearch(sh_Name2.Text.Trim())}%", SqlDbType.VarChar));

            }

            if (!string.IsNullOrEmpty(sh_Name3.Text.Trim()))
            {
                // 資材コード
                sb.AppendLine("AND KMZAIR.NAME3 LIKE @NAME3");
                param.Add("@NAME3", ($"%{SqlEscapeUtil.ReplaceSqlLikeSearch(sh_Name3.Text.Trim())}%", SqlDbType.VarChar));
            }

            sb.AppendLine("ORDER BY ZAICD,KOJCD");

            try
            {
                DataTable table = new DataTable();

                if (!SqlSeverControl.DbConnect())
                {
                    MessageBox.Show("データベースへの接続に失敗しました", MessageManager.CAPTION.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!SqlSeverControl.ExecuteSqlSelectQuery(sb.ToString(), ref table, param))
                {
                    MessageBox.Show("SQL実行に失敗しました", MessageManager.CAPTION.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _Logger.LogDebug(sb.ToString());
                    return;
                }

                dgv_Shizaif.DataSource = table;

                if (table.Rows.Count >= _SearchLimit)
                {
                    MessageBox.Show(MessageManager.GetMessageById("CM-W-0001", _SearchLimit.ToString()), MessageManager.CAPTION.WARN, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (table.Rows.Count > 0)
                {
                    dgv_Shizaif.Focus();
                    dgv_Shizaif.CurrentCell = dgv_Shizaif.Rows[0].Cells[1];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("データベースへの接続に失敗しました", MessageManager.CAPTION.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _Logger.LogError(ex.Message);
            }
            finally
            {
                // コネクションを閉じる
                if (SqlSeverControl.sCon.State == ConnectionState.Open)
                {
                    SqlSeverControl.DbDisConnect();
                }
            }
        }

        /// <summary>
        /// 選択処理
        /// </summary>
        /// <param name="zaicd"></param>
        private void SelectData()
        {
            if (dgv_Shizaif.CurrentCell == null)
            {
                MessageBox.Show(MessageManager.GetMessageById("CM-E-0004"), MessageManager.CAPTION.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.ResultValue = dgv_Shizaif.CurrentRow.Cells["ZAICD"].Value.ToString();
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        private void Cancel()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

    }
}
