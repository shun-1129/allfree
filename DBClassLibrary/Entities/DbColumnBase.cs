namespace allfree.DBClassLibrary.Entities
{
    /// <summary>
    /// DB共通カラム定義
    /// </summary>
    public class DbColumnBase
    {
        /// <summary>
        /// 作成日時
        /// </summary>
        public DateTime create_at { get; set; }

        /// <summary>
        /// 作成者
        /// </summary>
        public string create_user { get; set; } = string.Empty;

        /// <summary>
        /// 作成ツール
        /// </summary>
        public string create_program { get; set; } = string.Empty;

        /// <summary>
        /// 更新日時
        /// </summary>
        public DateTime update_at { get; set; }

        /// <summary>
        /// 更新者
        /// </summary>
        public string update_user { get; set; } = string.Empty;

        /// <summary>
        /// 更新ツール
        /// </summary>
        public string update_program { get; set; } = string.Empty;
    }
}
