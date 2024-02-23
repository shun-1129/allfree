using Microsoft.EntityFrameworkCore;
using SQLiteDBEntity.Entities.Master;
using SQLiteDBEntity.Entities.System;

namespace SQLiteDBEntity
{
    public class ApplicationDbContext : DbContext
    {
        #region メンバ変数
        /// <summary>
        /// DBパス
        /// </summary>
        private string _dbPath { get; }
        #endregion

        #region プロパティ
        #region マスタテーブル
        public DbSet<m_sex> m_sexs { get; set; }
        #endregion

        #region システムテーブル
        public DbSet<s_master_edit_password> s_master_edit_passwords { get; set; }
        #endregion
        #endregion

        #region コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public ApplicationDbContext ()
        {
            // DBファイルの保存先とDBファイル名をDbPathに格納
            _dbPath = $"C:{Path.DirectorySeparatorChar}allfree{Path.DirectorySeparatorChar}allfree_db.db";
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="inDBPath">DBパス</param>
        public ApplicationDbContext (string inDBPath )
        {
            _dbPath = inDBPath;
        }
        #endregion

        #region 内部メソッド
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        protected override void OnConfiguring ( DbContextOptionsBuilder options )
            => options.UseSqlite ( $"Data Source={_dbPath}" );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating ( ModelBuilder modelBuilder )
        {
            base.OnModelCreating ( modelBuilder );

            modelBuilder.Entity<m_sex> ( entity =>
            {
                entity.HasKey ( e => e.m_sex_id ).HasName ( "m_sex_PKC" );

                entity.HasQueryFilter ( e => !e.is_deleted );
            } );

            modelBuilder.Entity<s_master_edit_password> ( entity =>
            {
                entity.HasKey ( e => e.system_id ).HasName ( "s_master_edit_password_PKC" );
            } );
        }
        #endregion
    }
}