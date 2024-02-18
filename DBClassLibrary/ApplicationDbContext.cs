using DBClassLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace DBClassLibrary
{
    public class ApplicationDbContext : DbContext
    {
        #region メンバ変数
        /// <summary>
        /// DB接続情報
        /// </summary>
        private string _connectInfo = string.Empty;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <param name="inConnentInfo">DB接続情報</param>
        public ApplicationDbContext(string inConnentInfo) { _connectInfo = inConnentInfo; }
        #endregion

        #region 内部メソッド
        /// <summary>
        /// DB接続設定
        /// </summary>
        /// <param name="optionsBuilder">オプションビルダー</param>
        protected override void OnConfiguring ( DbContextOptionsBuilder optionsBuilder)
        {
            // DB接続
            optionsBuilder.UseNpgsql (_connectInfo);
            // 時間設定
            AppContext.SetSwitch ( "Npgsql.EnableLegacyTimestampBehavior" , true );
        }

        /// <summary>
        /// モデル作成
        /// </summary>
        /// <param name="modelBuilder">モデルビルダー</param>
        protected override void OnModelCreating ( ModelBuilder modelBuilder )
        {
            #region マスタテーブル
            // 性別マスタテーブル定義
            modelBuilder.Entity<m_sex> ( entity =>
            {
                // 主キー定義
                entity.HasKey ( e => e.m_sex_id );
                // 論理削除(Falseのみ)
                entity.HasQueryFilter ( e => !e.is_deleted );
            } );
            // ユーザマスタテーブル定義
            modelBuilder.Entity<m_user> ( entity =>
            {
                // 主キー定義
                entity.HasKey ( e => e.m_user_id );
                // 論理削除(Falseのみ)
                entity.HasQueryFilter ( e => !e.is_deleted );
            } );
            // 言語マスタテーブル定義
            modelBuilder.Entity<m_language> ( entity =>
            {
                // 主キー定義
                entity.HasKey ( e => e.m_language_id );
                // 論理削除(Falseのみ)
                entity.HasQueryFilter ( e => !e.is_deleted );
            } );
            // 秘密の質問マスタテーブル定義
            modelBuilder.Entity<m_secret_question> ( entity =>
            {
                // 主キー定義
                entity.HasKey ( e => e.m_secret_question_id );
                // 論理削除(Falseのみ)
                entity.HasQueryFilter ( e => !e.is_deleted );
            } );
            #endregion

            #region システムテーブル
            #endregion

            #region トランザクションテーブル
            #endregion
        }
        #endregion

        #region 公開メソッド
        #region マスタテーブル
        /// <summary>
        /// 性別マスタテーブル
        /// </summary>
        public DbSet<m_sex> m_sexes { get; set; }
        /// <summary>
        /// ユーザマスタテーブル
        /// </summary>
        public DbSet<m_user> m_users { get; set; }
        /// <summary>
        /// 言語マスタテーブル
        /// </summary>
        public DbSet<m_language> m_languages { get; set; }
        /// <summary>
        /// 秘密の質問マスタテーブル
        /// </summary>
        public DbSet<m_secret_question> m_secret_questions { get; set; }
        #endregion

        #region システムテーブル
        #endregion

        #region トランザクションテーブル
        #endregion
        #endregion
    }
}