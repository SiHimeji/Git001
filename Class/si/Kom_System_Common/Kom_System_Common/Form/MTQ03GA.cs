using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Kom_System_Common.CommonClass;
using Kom_System_Common.CommonClass.Services;

namespace Kom_System_Common
{
    public partial class MTQ03GA : Form
    {
        private const int DEFAULT_SERACH_LIMIT = 1000;
        private const string SEARCH_LIMIT = "MTQ03GA_SearchLimit";

        /// <summary>
        /// セット区分（0:製品　1:セット）
        /// </summary>
        private decimal? _Kbn= null;
        /// <summary>
        /// 製品区分（0:出荷基準売上 1:その他売上）
        /// </summary>
        private decimal? _Seikbn = null;
        private int _SearchLimit = 0;
        private LoggerService _Logger = new LoggerService();

        /// <summary>
        /// 戻り値
        /// </summary>
        public string ResultValue { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="args">製品区分</param>
        public MTQ03GA(params string[] args)
        {
            InitializeComponent();

            decimal kbn = 0;
            decimal seikbn = 0;
            if (args.Length == 0)
            {
                throw new ArgumentException("セット区分は必須です。");
            }
            if (!decimal.TryParse(args[0], out kbn))
            {
                throw new ArgumentException("セット区分が不正です。");
            }
            switch (kbn)
            {
                case SeihinMasterService.KBN.SEIHIN:
                case SeihinMasterService.KBN.SETHIN:
                    // 何もしない
                    break;
                default:
                    throw new ArgumentException("セット区分が不正です。");
            }
            _Kbn = kbn;

            if (args.Length > 1)
            {
                if (!decimal.TryParse(args[1], out seikbn))
                {
                    throw new ArgumentException("製品区分が不正です。");
                }
                switch (seikbn)
                {
                    case SeihinMasterService.SEIKBN.SHUKKA_URIAGE:
                    case SeihinMasterService.SEIKBN.SONOTA_URIAGE:
                        // 何もしない
                        break;
                    default:
                        throw new ArgumentException("製品区分が不正です。");
                }

                _Seikbn = seikbn;
            }
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MTQ03GA_Load(object sender, EventArgs e)
        {
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
            dgb_Seihin.AutoGenerateColumns = false;
        }

        /// <summary>
        /// キーダウンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MTQ03GA_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (dgb_Seihin.Focused)
                    {
                        if (dgb_Seihin.CurrentRow.Index >= 0)
                        {
                            this.SelectData();
                        }
                    }

                    this.ProcessTabKey(true);
                    e.Handled |= true;
                    break;
                case Keys.F1:
                    this.Search();
                    break;
                case Keys.F5:
                    if (dgb_Seihin.CurrentRow == null)
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
                case Keys.F12:
                    switch (this.ActiveControl.Name)
                    {
                        case "sh_Lank":
                            this.SearchLank();
                            break;
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelectData();
        }

        /// <summary>
        /// 製品ランク検索ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLankSearch_Click(object sender, EventArgs e)
        {
            this.SearchLank();
        }

        #region 内部メソッド
        /// <summary>
        /// 検索処理
        /// </summary>
        private void Search()
        {
            var sb = new StringBuilder();
            var parameters = new Dictionary<string, (object, SqlDbType)>();

            sb.AppendLine($"SELECT TOP {_SearchLimit}");
            sb.AppendLine("    ROW_NUMBER() OVER(ORDER BY NAME1, NAME2, NAME3) AS RNUM,");
            sb.AppendLine("    SEICD,");
            sb.AppendLine("    NAME1,");
            sb.AppendLine("    NAME2,");
            sb.AppendLine("    NAME3,");
            sb.AppendLine("    LANK,");
            sb.AppendLine("    SITENAME");
            sb.AppendLine("FROM KMSEIH");
            sb.AppendLine("WHERE DEFLG = 0");
            sb.AppendLine("AND KBN = @KBN");

            // 検索条件
            // 製品区分
            if (_Seikbn != null)
            {
                sb.AppendLine("AND SEIKBN = @SEIKBN");
                parameters.Add("@SEIKBN", (_Seikbn.Value, SqlDbType.Decimal)); // このパラメータはnull許容型なので指定されている場合だけパラメータ設定
            }

            // 製品コード
            if (!string.IsNullOrEmpty(sh_Seicd.Text))
            {
                sb.AppendLine("AND SEICD LIKE @SEICD");
            }
            // 製品名
            if (!string.IsNullOrEmpty(sh_Name1.Text))
            {
                sb.AppendLine("AND NAME1 LIKE @NAME1");
            }
            // 型式・形状
            if (!string.IsNullOrEmpty(sh_Name2.Text))
            {
                sb.AppendLine("AND NAME2 LIKE @NAME2");
            }
            // 寸法
            if (!string.IsNullOrEmpty(sh_Name3.Text))
            {
                sb.AppendLine("AND NAME3 LIKE @NAME3");
            }
            // 製品ランク
            if (!string.IsNullOrEmpty(sh_Lank.Text))
            {
                sb.AppendLine("AND LANK = @LANK");
            }
            parameters.Add("@KBN", (_Kbn.Value, SqlDbType.Decimal));
            parameters.Add("@SEICD", ($"{sh_Seicd.Text}%", SqlDbType.VarChar));
            parameters.Add("@NAME1", ($"%{sh_Name1.Text}%", SqlDbType.NVarChar));
            parameters.Add("@NAME2", ($"%{sh_Name2.Text}%", SqlDbType.NVarChar));
            parameters.Add("@NAME3", ($"%{sh_Name3.Text}%", SqlDbType.NVarChar));
            parameters.Add("@LANK", (sh_Lank.Text, SqlDbType.VarChar));

            sb.AppendLine("ORDER BY NAME1, NAME2, NAME3");

            // 検索処理
            try
            {
                DataTable table = new DataTable();

                if (!SqlSeverControl.DbConnect())
                {
                    MessageBox.Show("データベースへの接続に失敗しました", MessageManager.CAPTION.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!SqlSeverControl.ExecuteSqlSelectQuery(sb.ToString(), ref table, parameters))
                {
                    MessageBox.Show("SQL実行に失敗しました", MessageManager.CAPTION.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _Logger.LogDebug(sb.ToString());
                    return;
                }

                dgb_Seihin.DataSource = table;

                if (table.Rows.Count >= _SearchLimit)
                {
                    MessageBox.Show(MessageManager.GetMessageById("CM-W-0001", _SearchLimit.ToString()), MessageManager.CAPTION.WARN, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (table.Rows.Count > 0)
                {
                    dgb_Seihin.Focus();
                    dgb_Seihin.CurrentCell = dgb_Seihin.Rows[0].Cells[1];
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
        /// <param name="resultValue"></param>
        private void SelectData()
        {
            if (dgb_Seihin.CurrentCell == null)
            {
                MessageBox.Show(MessageManager.GetMessageById("CM-E-0004"), MessageManager.CAPTION.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.ResultValue = dgb_Seihin.CurrentRow.Cells["SEICD"].Value.ToString();
        }

        /// <summary>
        /// 製品ランク検索
        /// </summary>
        private void SearchLank()
        {
            MTQ01GA fm = new MTQ01GA(MeishoMasterService.NMKBN.SEIHIN_RANK.ToString());
            if (fm.ShowDialog() == DialogResult.OK)
            {
                sh_Lank.Text = fm.ResultValue;
                sh_Lank.Focus();
            }
        }
        #endregion
    }
}
