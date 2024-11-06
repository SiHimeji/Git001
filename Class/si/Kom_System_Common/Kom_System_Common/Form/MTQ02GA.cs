using Kom_System_Common.CommonClass;
using Kom_System_Common.CommonClass.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Kom_System_Common
{
    public partial class MTQ02GA : Form
    {
        private const int DEFAULT_SERACH_LIMIT = 1000;
        private const string SEARCH_LIMIT = "MTQ02GA_SearchLimit";

        private decimal? _Tkbn;
        private int _SearchLimit = 0;
        private LoggerService _Logger = new LoggerService();

        /// <summary>
        /// 戻り値
        /// </summary>
        public string ResultValue { get; set; }

        /// <summary>
        /// 取引先検索
        /// </summary>
        /// <param name="args">取引区分　1：得意先区分、2：仕入先区分</param>
        /// <exception cref="ArgumentException">取引区分が1、2以外の場合</exception>
        public MTQ02GA(params string[] args)
        {
            InitializeComponent();

            if (args.Length == 0)
            {
                throw new ArgumentException("取引区分が不正です。");
            }

            decimal tkbn = 0;
            if (!decimal.TryParse(args[0], out tkbn))
            {
                throw new ArgumentException("取引区分が不正です。");
            }
            switch (tkbn)
            {
                case TorihikisakiMasterService.TKBN.TOKUISAKI:
                case TorihikisakiMasterService.TKBN.SHIRESAKI:
                case TorihikisakiMasterService.TKBN.ALL:
                    // 何もしない
                    break;
                default:
                    throw new ArgumentException("取引区分が不正です。");
            }
            _Tkbn = tkbn;
        }

        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MTQ02GA_Load(object sender, System.EventArgs e)
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
            dgb_Torihikisaki.AutoGenerateColumns = false;
            switch (_Tkbn)
            {
                case 1: // 得意先
                    this.Text = "得意先検索";
                    break;
                case 2: // 仕入先
                    this.Text = "仕入先検索";
                    break;
            }
        }

        /// <summary>
        /// キーダウンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MTQ02GA_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (dgb_Torihikisaki.Focused)
                    {
                        if (dgb_Torihikisaki.CurrentRow.Index >= 0)
                        {
                            this.SelectData();
                        }
                    }
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    e.Handled |= true;
                    break;
                case Keys.F1:
                    this.Search();
                    break;
                case Keys.F5:
                    this.SelectData();
                    break;
                case Keys.F9:
                    if (e.Shift)
                    {
                        this.Cancel();
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
        private void btnCancel_Click(object sender, EventArgs e)
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
        /// データグリッドビューダブルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.SelectData();
            }
        }

        #region 内部メソッド
        /// <summary>
        /// 検索処理
        /// </summary>
        private void Search()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"SELECT TOP {_SearchLimit}");
            sb.AppendLine("    ROW_NUMBER() OVER(ORDER BY THCD) AS RNUM,");
            sb.AppendLine("    THCD,");
            sb.AppendLine("    RMEI");
            sb.AppendLine("FROM KMTORI");
            sb.AppendLine("WHERE DEFLG = 0");

            if (TorihikisakiMasterService.TKBN.ALL != this._Tkbn)
            {
                sb.AppendLine("AND TKBN = @TKBN");
            }

            var param = new Dictionary<string, (object, SqlDbType)>();
            param.Add("@TKBN", ($"{_Tkbn.Value}", SqlDbType.Decimal));
            if (!string.IsNullOrEmpty(sh_Thcd.Text.Trim()))
            {
                // コード
                sb.AppendLine("AND THCD LIKE @THCD");
                param.Add("@THCD", ($"{sh_Thcd.Text.Trim()}%", SqlDbType.VarChar));
            }
            if (!string.IsNullOrEmpty(sh_Nm.Text.Trim()))
            {
                // 名称
                sb.AppendLine("AND (RMEI LIKE @RMEI OR KANA LIKE @KANA)");
                param.Add("@RMEI", ($"%{sh_Nm.Text.Trim()}%", SqlDbType.VarChar));
                param.Add("@KANA", ($"%{sh_Nm.Text.Trim()}%", SqlDbType.VarChar));
            }
            sb.AppendLine("ORDER BY THCD");

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

                dgb_Torihikisaki.DataSource = table;

                if (table.Rows.Count >= _SearchLimit)
                {
                    MessageBox.Show(MessageManager.GetMessageById("CM-W-0001", _SearchLimit.ToString()), MessageManager.CAPTION.WARN, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (table.Rows.Count > 0)
                {
                    dgb_Torihikisaki.Focus();
                    dgb_Torihikisaki.CurrentCell = dgb_Torihikisaki.Rows[0].Cells[1];
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
        /// 終了処理
        /// </summary>
        private void Cancel()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 選択処理
        /// </summary>
        private void SelectData()
        {
            if (dgb_Torihikisaki.CurrentCell == null)
            {
                MessageBox.Show(MessageManager.GetMessageById("CM-E-0004"), MessageManager.CAPTION.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.ResultValue = dgb_Torihikisaki.CurrentRow.Cells["THCD"].Value.ToString();
        }




        #endregion
    }
}
