using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Configuration;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;

namespace Kom_System_Common.CommonClass
{
    static public class SqlSeverControl
    {
        static string connectionString = "";

        #region　領域定義
        static public OleDbConnection oCon = null;              // コネクション のインスタンス化
        #endregion

        static SqlSeverControl()
        {
#if DEBUG

            string sqlUser = "si";
            string sqlPass = "0251";
            string SqlService = "Kom";
            string SqlServer = "SQLOLEDB";
            string SqlTns = "192.168.1.55";
/*
            string sqlUser = "sa";
            string sqlPass = "123456";
            string SqlService = "Kom";
            string SqlServer = "SQLOLEDB";
            string SqlTns = "localhost";
*/
/*
            string sqlUser = "sa";
            string sqlPass = "sa";
            string SqlService = "BBX61;";
            string SqlServer = "SQLOLEDB";
            string SqlTns = "ISV03006\\SQLEXPRESS01";
*/



#else
                string sqlUser = "sa";
                string sqlPass = "sa";
                string SqlService = "BBX61;";
                string SqlServer = "SQLOLEDB";
                string SqlTns = "ISV03006\\SQLEXPRESS01";
#endif
            //connectionString = ConfigurationManager.ConnectionStrings["KomSystem"].ConnectionString;
            connectionString = $"Provider={SqlServer};Data Source={SqlTns};Initial Catalog={SqlService};User ID={sqlUser};Password={sqlPass};Connection Timeout=4000";
        }

        #region　SQLSever接続に関するメソッド
        /// <summary>
        /// SQLSever接続
        /// </summary>
        /// <returns></returns>
        public static bool DbConnect()
        {
            if (oCon != null)
            {
                if (oCon.State == System.Data.ConnectionState.Open)
                {
                    return true;
                }
            }
            try
            {
                oCon = new OleDbConnection(connectionString);
                oCon.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region　SQLSever切断に関するメソッド
        static public bool DbDisConnect()
        {
            try
            {
                if (oCon.ConnectionString != null)
                { oCon.Close(); oCon.Dispose(); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region　データ取得に関するメソッド
        /// <summary>
        /// データの取得
        /// </summary>
        /// <returns>取得したデータテーブル</returns>
        public static System.Data.DataTable Read(string query, OleDbTransaction transaction)
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();

            using (OleDbCommand oCmd = new OleDbCommand(query, transaction.Connection, transaction))
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(oCmd))
            {
                try
                {
                    dataTable.Clear();
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading data: {ex.Message}");
                }
            }

            return dataTable;
        }

        #endregion

        #region　データ登録・更新に関するメソッド
        /// <summary>
        /// 新規作成処理
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columns"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static int Insert(string tableName, (string columnName, object Value)[] columns, OleDbTransaction transaction)
        {
            if (columns.Length == 0)
            {
                return 0;
            }

            var columnNames = string.Join(", ", columns.Select(c => c.columnName));
            var parameters = string.Join(", ", columns.Select(_ => "?"));
            var query = $"INSERT INTO {tableName} ({columnNames}) VALUES ({parameters})";

            int rowsAffected = 0;

            using (OleDbCommand oCmd = new OleDbCommand(query, transaction.Connection, transaction))
            {
                try
                {
                    foreach (var column in columns)
                    {
                        oCmd.Parameters.AddWithValue("?", column.Value ?? DBNull.Value);
                    }
#if DEBUG
                    string executedQuery = GenerateExecutableQuery(query, oCmd);
                    Console.WriteLine(executedQuery);
#endif
                    rowsAffected = oCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error executing query: {ex.Message}");
                    rowsAffected = 0;
                }
            }

            return rowsAffected;
        }

        /// <summary>
        /// データ更新処理
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columns"></param>
        /// <param name="whereClause"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static int Update(string tableName, (string columnName, object Value)[] columns, string whereClause, OleDbTransaction transaction)
        {
            if (columns.Length == 0 || string.IsNullOrEmpty(whereClause))
            {
                return 0;
            }

            // SET句の作成
            var setClause = string.Join(", ", columns.Select((c, i) => $"{c.columnName} = @param{i}"));
            var query = $"UPDATE {tableName} SET {setClause} WHERE {whereClause}";

            int rowsAffected = 0;

            using (OleDbCommand oCmd = new OleDbCommand(query, transaction.Connection, transaction))
            {
                try
                {
                    // パラメータの追加
                    for (int i = 0; i < columns.Length; i++)
                    {
                        var parameter = new OleDbParameter($"@param{i}", columns[i].Value ?? DBNull.Value);
                        oCmd.Parameters.Add(parameter);
                    }
#if DEBUG
                    string executedQuery = GenerateExecutableQuery(query, oCmd);
                    Console.WriteLine(executedQuery);
#endif
                    // クエリの実行
                    rowsAffected = oCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error executing query: {ex.Message}");
                    rowsAffected = 0;
                }
            }

            return rowsAffected;
        }

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="whereClause"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static int Delete(string tableName, string whereClause, OleDbTransaction transaction)
        {
            if (string.IsNullOrEmpty(whereClause))
            {
                return 0;
            }

            var query = $"DELETE FROM {tableName} WHERE {whereClause}";

            int rowsAffected = 0;

            using (OleDbCommand oCmd = new OleDbCommand(query, transaction.Connection, transaction))
            {
                try
                {

#if DEBUG
                    string executedQuery = GenerateExecutableQuery(query, oCmd);
                    Console.WriteLine(executedQuery);
#endif
                    rowsAffected = oCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error executing query: {ex.Message}");
                    rowsAffected = 0;
                }
            }

            return rowsAffected;
        }

        #endregion

        // パラメータを実際の値に置き換えたSQL文を生成するヘルパーメソッド
        private static string GenerateExecutableQuery(string query, OleDbCommand cmd)
        {
            var parameterIndex = 0;

            foreach (OleDbParameter param in cmd.Parameters)
            {
                // プレースホルダーを ? で置換
                var valueStr = param.Value is string || param.Value is DateTime
                    ? $"'{param.Value}'"
                    : param.Value.ToString();

                // ? プレースホルダーの位置を取得して置換
                var placeholder = new string('?', 1); // プレースホルダーのサイズは 1 文字
                var placeholderIndex = query.IndexOf(placeholder);

                if (placeholderIndex != -1)
                {
                    query = query.Remove(placeholderIndex, 1);
                    query = query.Insert(placeholderIndex, valueStr);
                }

                parameterIndex++;
            }

            return query;
        }

        #region データ取得処理
        /// <summary>
        /// 
        /// </summary>
        /// <param name="datatable">検索結果データテーブル</param>
        /// <param name="strSQL">実行SQL</param>
        /// <param name="Trncmd">SQLコマンド（Tran有の場合のみ）Trn内ではない場合はnull指定</param>
        /// <returns>true：正常　false：異常</returns>
        static public bool GetDataTable(ref System.Data.DataTable datatable, string strSQL, OleDbCommand Trncmd = null)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();

                if (Trncmd != null)
                {
                    cmd = Trncmd;
                }

                cmd.Connection = oCon;
                cmd.CommandText = strSQL;

                OleDbDataAdapter daAdapter = new OleDbDataAdapter(cmd);
                daAdapter.Fill(datatable);

                if (Trncmd == null)
                {
                    if (cmd != null) { cmd.Dispose(); cmd = null; }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region DBバックアップ処理
        public static bool MakeBackupFile(string BackupFilePath)
        {
            // BACKUP DATABASE コマンド
            string backupQuery = $@"BACKUP DATABASE [データベース名] TO DISK = '{BackupFilePath}' WITH INIT;";

            try
            {
                // SQL コマンドを実行
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = oCon;
                    cmd.CommandText = backupQuery;
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("データベースのバックアップが正常に完了しました。");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"エラーが発生しました: {ex.Message}");
                return false;
            }

            return true;   
        }
        #endregion

    }
}
