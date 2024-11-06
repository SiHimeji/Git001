using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using System.Windows.Forms;

namespace Kom_System_Common.CommonClass
{
    static public class SqlSeverControl
    {
        static string connectionString = "";
        static string DbBackup_Query = "";

        #region　領域定義
        static public SqlConnection sCon = null;             // コネクション のインスタンス化
        #endregion

        static SqlSeverControl()
        {
#if DEBUG
            // string sqlUser = "sa";
            // string sqlPass = "sa";
            // string SqlService = "BBX61";
            // string SqlTns = Environment.MachineName + "\\SQLEXPRESS";
            // string SqlTimeout = "30";

            string sqlUser = "si";
            string sqlPass = "0251";
            string SqlService = "kcon";
            //string SqlServer = "SQLOLEDB";
            string SqlTns = "192.168.1.236";
            string SqlTimeout = "10";




#else
            string sqlUser = "sa";
            string sqlPass = "sa";
            string SqlService = "BBX61;";
            string SqlTimeout = "10";

#endif
            connectionString = $"Server ={SqlTns};Database={SqlService};User Id={sqlUser};Password={sqlPass};Connect Timeout={SqlTimeout};";

            DbBackup_Query = @"BACKUP DATABASE BBX61
                                    TO DISK = @BackupPath
                                    WITH NOFORMAT, NOINIT,
                                    NAME = @BackupName,
                                    SKIP, NOREWIND, NOUNLOAD, STATS = 10;";
        }

        #region　SQLSever接続に関するメソッド
        /// <summary>
        /// SQLSever接続
        /// </summary>
        /// <returns></returns>
        static public bool DbConnect()
        {
            if (sCon != null)
            {
                if (sCon.State == System.Data.ConnectionState.Open)
                {
                    return true;
                }
            }
            try
            {
                sCon = new SqlConnection(connectionString);
                sCon.Open();
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
                if (sCon.ConnectionString != null)
                { sCon.Close(); sCon.Dispose(); }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region SQL実行部関数

        /// <summary>
        /// 更新関連処理実行部
        /// </summary>
        /// <param name="query">SQL（パラメータ名称入り）</param>
        /// <param name="parameters">Dictionary<string, (object Value, SqlDbType Type)>　なければ省略可能</param>
        /// <param name="transaction">トランザクション</param>
        /// <returns></returns>
        public static bool ExecuteSqlQuery(string query, Dictionary<string, (object Value, SqlDbType Type)> parameters = null, SqlTransaction transaction = null)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, sCon))
                {
                    if (transaction != null)
                    {
                        cmd.Transaction = transaction;
                    }

                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            var sqlParameter = new SqlParameter(param.Key, param.Value.Type)
                            {
                                Value = param.Value.Value ?? DBNull.Value
                            };
                            cmd.Parameters.Add(sqlParameter);
                        }
                    }

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch(Exception ex)
            {
                LoggerService Log = new LoggerService();
                Log.LogWarning(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// データ取得処理実行部
        /// </summary>
        /// <param name="query">SQL（パラメータ名称入り）</param>
        /// <param name="dt">リターン用データテーブル（参照渡し）</param>
        /// <param name="parameters"> Dictionary<string, (object Value, SqlDbType Type)>　なければ省略可能</param>
        /// <param name="transaction">トランザクション　なければ省略可能</param>
        /// <returns>true:成功　false:失敗</returns>
        public static bool ExecuteSqlSelectQuery(string query, ref DataTable dt, Dictionary<string, (object Value, SqlDbType Type)> parameters = null, SqlTransaction transaction = null)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, sCon))
                {
                    if (transaction != null)
                    {
                        cmd.Transaction = transaction;
                    }

                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            var sqlParameter = new SqlParameter(param.Key, param.Value.Type)
                            {
                                Value = param.Value.Value ?? DBNull.Value
                            };
                            cmd.Parameters.Add(sqlParameter);
                        }
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        dt.Clear();
                        adapter.Fill(dt);
                    }
                }


                return true;
            }
            catch(Exception ex)
            {
                LoggerService Log = new LoggerService();
                Log.LogWarning(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// grid用データ取得処理(STS項目付)
        /// </summary>
        /// <param name="query">SQL（パラメータ名称入り）</param>
        /// <param name="dt">リターン用データテーブル（参照渡し）</param>
        /// <param name="parameters"> Dictionary<string, (object Value, SqlDbType Type)>　なければ省略可能</param>
        /// <param name="transaction">トランザクション　なければ省略可能</param>
        /// <returns>true:成功　false:失敗</returns>
        public static bool GridData_ExecuteSqlSelectQuery(string query, ref DataTable dt, Dictionary<string, (object Value, SqlDbType Type)> parameters = null, SqlTransaction transaction = null)
        {
            try
            {
                ExecuteSqlSelectQuery(query, ref dt, parameters, transaction);
                dt.Columns.Add("STSKBN");
                return true;
            }
            catch
            {
                return false;
            }

        }

        #endregion

        #region DBバックアップ処理
        public static bool MakeBackupFile(string BackupFilePath)
        {
            if(!DbConnect())
            {
                return false;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(DbBackup_Query, connection);
                    string backupName = $"BBX61 Full Backup - {DateTime.Now:yyyy_MM_dd_HH_mm_ss}";
                    command.Parameters.Add("@BackupPath", System.Data.SqlDbType.NVarChar).Value = BackupFilePath;
                    command.Parameters.Add("@BackupName", System.Data.SqlDbType.NVarChar).Value = backupName;
                    command.CommandTimeout = 300;
                    command.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {
                    LoggerService Log = new LoggerService();
                    Log.LogWarning(ex.ToString());
                    return false;

                }
                finally
                {
                    DbDisConnect();
                }
            }
        }
        #endregion
    }
}
