namespace Kom_System_Common.CommonClass
{
    /// <summary>
    /// ComboBoxのItemsに設定するTextとValueを持ったクラスです
    /// </summary>
    public class ComboBoxItem
    {
        /// <summary>
        /// ValueMemberに対応するValue
        /// </summary>
        public object Value { get; set; }
        /// <summary>
        /// DisplayMemberに対応するText
        /// </summary>
        public string Text { get; set; }

        public ComboBoxItem(object value, string text)
        {
            this.Value = value;
            this.Text = text;
        }
    }
}
