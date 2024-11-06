namespace Kom_System_Common.CommonClass
{
    /// <summary>
    /// SQLエスケープユーティリティ
    /// </summary>
    public class SqlEscapeUtil
    {

        /// <summary>
        /// SQLServerでエスケープ対象の文字を変換する
        /// %,_,[,^
        /// </summary>
        /// <param name="form"></param>
        public static string ReplaceSqlLikeSearch(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return null;
            }

            return search.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]").Replace("^", "[^]");

        }
    }
}
