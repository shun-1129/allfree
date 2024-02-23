using Allfree_Application.Logics.DBAccessor;
using Allfree_Application.Views;
using CommonLibrary.Command;
using CommonLibrary.ViewModelBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PostgresqlDBEntity.Entities.Master;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace Allfree_Application.ViewModels
{
    public class MasterEditWindowViewModel : ViewModelBase
    {
        #region 内部クラス
        public class GridItemData : ViewModelBase
        {
            #region メンバ変数
            /// <summary>
            /// マスタID
            /// </summary>
            private int _id;

            /// <summary>
            /// 論理削除
            /// </summary>
            private bool _isDeleted = false;

            /// <summary>
            /// プロパティ1
            /// </summary>
            private string _property1 = string.Empty;

            /// <summary>
            /// プロパティ2
            /// </summary>
            private string _property2 = string.Empty;
            #endregion

            #region プロパティ
            /// <summary>
            /// マスタID
            /// </summary>
            public int Id
            {
                get { return _id; }
                set
                {
                    _id = value;
                    RaisePropertyChanged(nameof(Id));
                }
            }

            /// <summary>
            /// 論理削除
            /// </summary>
            public bool IsDeleted
            {
                get { return _isDeleted; }
                set
                {
                    _isDeleted = value;
                    RaisePropertyChanged(nameof(IsDeleted));
                }
            }

            /// <summary>
            /// プロパティ1
            /// </summary>
            public string Property1
            {
                get { return _property1; }
                set
                {
                    _property1 = value;
                    RaisePropertyChanged ( nameof ( Property1 ) );
                }
            }

            /// <summary>
            /// プロパティ2
            /// </summary>
            public string Property2
            {
                get { return _property2; }
                set
                {
                    _property1 = value;
                    RaisePropertyChanged ( nameof ( Property2 ) );
                }
            }
            #endregion
        }
        #endregion

        #region メンバ変数
        /// <summary>
        /// 
        /// </summary>
        private MasterEditWindow _masterEditWindow;

        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<DataGridColumn> _columns = new ObservableCollection<DataGridColumn>();

        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<GridItemData> _gridItem = new ObservableCollection<GridItemData>();
        #endregion

        #region プロパティ
        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand<string> MasterSexBtn { get; }

        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand<string> MasterUserBtn { get; }

        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand<string> MasterLanguageBtn { get; }

        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand<string> MasterSecretQuestionBtn {  get; }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<DataGridColumn> Columns
        {
            get => _columns;
            private set
            {
                _columns = value;
                RaisePropertyChanged( nameof(Columns) );

                _masterEditWindow.AddColumnsDynamically (Columns);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<GridItemData> GridItem
        {
            get => _gridItem;
            set
            {
                _gridItem = value;
                RaisePropertyChanged( nameof( GridItem ) );
            }
        }
        #endregion

        #region コンストラクタ
        public MasterEditWindowViewModel (MasterEditWindow masterEditWindow)
        {
            _masterEditWindow = masterEditWindow;

            MasterSexBtn = new DelegateCommand<string> ( GetDynamicColumns );
            MasterUserBtn = new DelegateCommand<string> ( GetDynamicColumns );
            MasterLanguageBtn = new DelegateCommand<string> ( GetDynamicColumns );
            MasterSecretQuestionBtn = new DelegateCommand<string> ( GetDynamicColumns );

            GetDynamicColumns ();

            InitializeGridTable ();
        }
        #endregion

        #region 内部メソッド
        private void InitializeGridTable ()
        {
            GridItem.Clear ();

            List<m_sex> sexes = PosgresqlDBAccessor.Instance.MasterSet.m_sexes;

            foreach (m_sex sex in sexes )
            {
                GridItem.Add ( new GridItemData ()
                {
                    Id = sex.m_sex_id,
                    Property1 = sex.sex_info,
                    IsDeleted = sex.is_deleted
                } );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void GetDynamicColumns (string selectTable = "m_sex")
        {
            ObservableCollection<DataGridColumn> columns = new ObservableCollection<DataGridColumn> ();

            IEntityType? entityType = PosgresqlDBAccessor.Instance.GetTableColumnsProperty(selectTable);

            List<IProperty> columnsInfo = new List<IProperty> ();
            var primaryKey = entityType.FindPrimaryKey()?.Properties[0];

            columnsInfo.Add ( primaryKey );

            var properties = entityType.GetProperties();
            foreach ( var property in properties )
            {
                if (property.Name == primaryKey.Name )
                {
                    continue;
                }

                switch ( property.Name )
                {
                    case "create_at":
                        break;
                    case "create_user":
                        break;
                    case "create_program":
                        break;
                    case "update_at":
                        break;
                    case "update_user":
                        break;
                    case "update_program":
                        break;
                    case "is_deleted":
                        break;
                    default:
                        columnsInfo.Add ( property );
                        break;
                }
            }

            int count = 0;
            if ( columnsInfo.Count > count )
            {
                DataGridTextColumn textColumn1 = new DataGridTextColumn ();
                textColumn1.Header = columnsInfo[count].GetColumnName();
                textColumn1.Binding = new Binding ( "Id" );
                textColumn1.Width = new DataGridLength ( 1 , DataGridLengthUnitType.Star );
                columns.Add ( textColumn1 );

                count++;
            }

            if ( columnsInfo.Count > count )
            {
                DataGridTextColumn textColumn2 = new DataGridTextColumn ();
                textColumn2.Header = columnsInfo[count].GetColumnName ();
                textColumn2.Binding = new Binding ( "Property1" );
                textColumn2.Width = new DataGridLength ( 1 , DataGridLengthUnitType.Star );
                columns.Add ( textColumn2 );

                count++;
            }

            if ( columnsInfo.Count > count )
            {
                DataGridTextColumn textColumn3 = new DataGridTextColumn ();
                textColumn3.Header = columnsInfo[count].GetColumnName ();
                textColumn3.Binding = new Binding ( "Property2" );
                textColumn3.Width = new DataGridLength ( 1 , DataGridLengthUnitType.Star );
                columns.Add ( textColumn3 );

                count++;
            }

            DataGridCheckBoxColumn checkBoxColumn = new DataGridCheckBoxColumn ();
            checkBoxColumn.Header   = "論理削除";
            checkBoxColumn.Binding  = new Binding ( "IsDeleted" );
            checkBoxColumn.Width       = new DataGridLength ( 70 );
            columns.Add ( checkBoxColumn );

            Columns = columns;
        }
        #endregion

        #region 公開メソッド
        #endregion
    }
}
