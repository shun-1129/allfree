using PostgresqlDBEntity.Entities.Master;

namespace PostgresqlDBEntity
{
    public class MasterSet
    {
        /// <summary>
        /// 性別マスタテーブル
        /// </summary>
        public List<m_sex> m_sexes { get; set; } = new List<m_sex>();

        /// <summary>
        /// ユーザマスタテーブル
        /// </summary>
        public List<m_user> m_users { get; set; } = new List<m_user> ();

        /// <summary>
        /// 言語マスタテーブル
        /// </summary>
        public List<m_language> m_languages { get; set; } = new List<m_language> ();

        /// <summary>
        /// 秘密の質問マスタテーブル
        /// </summary>
        public List<m_secret_question> m_secret_question { get; set; } = new List<m_secret_question> ();
    }
}
