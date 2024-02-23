using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PostgresqlDBEntity;
using PostgresqlDBEntity.Entities.Master;
using PostgresqlDBEntity.Entities.System;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Allfree_Application.Logics.DBAccessor
{
    public class PosgresqlDBAccessor
    {
        #region 内部クラス
        #endregion

        #region 定数
        #endregion

        #region メンバ変数
        /// <summary>
        /// DBコンテキスト
        /// </summary>
        ApplicationDbContext _db = null;

        /// <summary>
        /// マスタ変更用パスワード
        /// </summary>
        private string _masterEditPassword = string.Empty;

        /// <summary>
        /// マスタテーブルデータ
        /// </summary>
        private MasterSet _masterSet = new MasterSet();
        #endregion

        #region プロパティ
        /// <summary>
        /// インスタンス
        /// </summary>
        public static PosgresqlDBAccessor Instance { get; } = new PosgresqlDBAccessor();

        /// <summary>
        /// マスタ変更用パスワード
        /// </summary>
        public string MasterEditPassword { get => _masterEditPassword; private set => _masterEditPassword = value; }

        /// <summary>
        /// マスタテーブルデータ
        /// </summary>
        public MasterSet MasterSet { get => _masterSet; private set => _masterSet = value; }
        #endregion

        #region コンストラクタ
        public PosgresqlDBAccessor() { }
        #endregion

        #region 公開メソッド
        #region DB接続／切断
        /// <summary>
        /// DB接続
        /// </summary>
        /// <returns>接続状況(true:成功, false:失敗)</returns>
        public bool DBOpen ()
        {
            string connect = "Server=localhost;Port=5433;Database=allfree;Username=postgres;Password=postgres";
            _db = new ApplicationDbContext ( connect );

            if ( _db != null )
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// DB切断
        /// </summary>
        public void DBClose ()
        {
            _db = null;
        }
        #endregion

        #region データ取得
        #region マスタ取得
        public void ReadMasterTableData ()
        {
            if ( GetSexMaster () )
            {
                Debug.WriteLine ( "性別マスタテーブル読込失敗" );
            }

            if ( GetUserMaster () )
            {

            }

            if (GetLanguageMaster () )
            {

            }

            if (GetSecretQuestionMaster () )
            {

            }
        }
        #endregion

        #region システムテーブル取得
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ReadMasterEditPassword ()
        {
            s_master_edit_password? masterEditPassword = _db.s_master_edit_passwords.Where(x => x.system_id == 1).FirstOrDefault();

            if ( masterEditPassword != null )
            {
                MasterEditPassword = masterEditPassword.password;
                return true;
            }

            return false;
        }
        #endregion

        #region その他
        public IEntityType? GetTableColumnsProperty (string inTableName )
        {
            Type type = typeof(m_sex);
            IEntityType? entityType = _db.Model.FindEntityType ( type );

            switch ( inTableName )
            {
                case "m_sex":
                    type = typeof(m_sex);
                    entityType = _db.Model.FindEntityType ( type );
                    break;
                case "m_user":
                    type = typeof(m_user);
                    entityType = _db.Model.FindEntityType ( type );
                    break;
                case "m_language":
                    type = typeof ( m_language );
                    entityType = _db.Model.FindEntityType ( type );
                    break;
                case "m_secret_question":
                    type = typeof ( m_secret_question );
                    entityType = _db.Model.FindEntityType ( type );
                    break;
                default:
                    entityType = null;
                    break;
            }

            return entityType;
        }
        #endregion
        #endregion

        #region データ追加
        #endregion

        #region データ更新
        #endregion

        #region データ削除
        #endregion

        #endregion

        #region 内部メソッド
        #region マスタ取得
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool GetSexMaster ()
        {
            IEnumerable<m_sex> sexes = _db.m_sexes.AsNoTracking().AsEnumerable();

            var type = typeof(m_sex);
            var entityType = _db.Model.FindEntityType ( type );

            var columns = entityType.GetProperties();

            foreach ( var column in columns )
            {
                var columnName = column.GetColumnName();
                var columnType = column.GetColumnType();
            }


            if (sexes.Any())
            {
                _masterSet.m_sexes = sexes.ToList();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool GetUserMaster ()
        {
            IEnumerable<m_user> users = _db.m_users.AsNoTracking().AsEnumerable();

            if ( users.Any() )
            {
                MasterSet.m_users = users.ToList();
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool GetLanguageMaster ()
        {
            IEnumerable<m_language> languages = _db.m_languages.AsNoTracking().AsEnumerable();

            if ( languages.Any() )
            {
                MasterSet.m_languages = languages.ToList();
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool GetSecretQuestionMaster ()
        {
            IEnumerable<m_secret_question> questions = _db.m_secret_questions.AsNoTracking().AsEnumerable();

            if ( questions.Any() )
            {
                MasterSet.m_secret_question = questions.ToList();
                return true;
            }

            return false;
        }
        #endregion
        #endregion
    }
}
