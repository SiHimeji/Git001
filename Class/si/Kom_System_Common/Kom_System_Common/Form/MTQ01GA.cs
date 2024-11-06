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
    public partial class MTQ01GA : Form
    {
        private const int DEFAULT_SERACH_LIMIT = 1000;
        private const string SEARCH_LIMIT = "MTQ01GA_SearchLimit";

        private string _Nmkbn;
        private int _SearchLimit = 0;
        private LoggerService _Logger = new LoggerService();

        /// <summary>
        /// 戻り値
        /// </summary>
        public string ResultValue { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="args">1:名称区分</param>
        public MTQ01GA(params string[] args)
        {
            InitializeComponent();

            if (args.Length == 0)
            {
                throw new ArgumentException("名称区分が不正です。");
            }

            decimal meishokbn = 0;
            if (!decimal.TryParse(args[0], out meishokbn))
            {
                throw new ArgumentException("名称区分が不正です。");
            }

            if (MeishoMasterService.GetMeishoKbn(meishokbn).Rows.Count == 0)
            {
                throw new ArgumentException("名称区分が不正です。");
            }

            // パラメータを設定
            _Nmkbn = args[0];
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MTQ01GA2_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings[SEARCH_LIMIT]))
            {
                _SearchLimit = DEFAULT_SERACH_LIMIT;
            }
            else
            {
                _SearchLimit = int.Parse(ConfigurationManager.AppSettings[SEARCH_LIMIT]);
            }
            dgb_Meisho.AutoGenerateColumns = false;

            var kmmeisTable = MeishoMasterService.GetMeishoKbn(decimal.Parse(_Nmkbn));
            if (kmmeisTable.Rows.Count == 0)
            {
                throw new ArgumentException("名称区分が不正です。");
            }
            this.Text = $"{kmmeisTable.Rows[0]["NM"].ToString().Trim()}検索";
        }

        /// <summary>
        /// キーダウンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MTQ01GA2_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (dgb_Meisho.Focused)
                    {
                        if (dgb_Meisho.CurrentRow.Index >= 0)
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
        /// データグリッドダブルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgb_Meisho_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            sb.AppendLine("    ROW_NUMBER() OVER(ORDER BY NMKBN) AS RNUM,");
            sb.AppendLine("    NMCD,");
            sb.AppendLine("    NM,");
            sb.AppendLine("    HYOJIJUN");
            sb.AppendLine("FROM KMMEIS");
            sb.AppendLine("WHERE NMKBN = @NMKBN");
            sb.AppendLine("AND BRCD = 1");

            var param = new Dictionary<string, (object, SqlDbType)>();
            param.Add("@NMKBN", (decimal.Parse(_Nmkbn), SqlDbType.Decimal));
            if (!string.IsNullOrEmpty(sh_Nmcd.Text.Trim()))
            {
                // 名称区分
                sb.AppendLine("AND NMCD LIKE @NMCD");
                param.Add("@NMCD", ($"{sh_Nmcd.Text.Trim()}%", SqlDbType.VarChar));
            }
            if (!string.IsNullOrEmpty(sh_Nm.Text.Trim()))
            {
                // 名称
                sb.AppendLine("AND NM LIKE @NM");
                param.Add("@NM", ($"%{sh_Nm.Text.Trim()}%", SqlDbType.VarChar));
            }
            sb.AppendLine($"ORDER BY HYOJIJUN, NMCD");

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

                dgb_Meisho.DataSource = table;

                if (table.Rows.Count >= _SearchLimit)
                {
                    MessageBox.Show(string.Format(MessageManager.GetMessageById("CM-W-0001"), _SearchLimit), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (table.Rows.Count > 0)
                {
                    dgb_Meisho.Focus();
                    dgb_Meisho.CurrentCell = dgb_Meisho.Rows[0].Cells[1];
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
            if (dgb_Meisho.CurrentCell == null)
            {
                MessageBox.Show(MessageManager.GetMessageById("CM-E-0004"), MessageManager.CAPTION.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.ResultValue = dgb_Meisho.CurrentRow.Cells["NMCD"].Value.ToString();
        }

        #endregion


    }
}
