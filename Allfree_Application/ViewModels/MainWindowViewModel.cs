using Allfree_Application.Views;
using Allfree_Application.ViewModels.UserControls;
using CommonLibrary.Command;
using CommonLibrary.ViewModelBase;
using SQLiteDBEntity.Entities.System;
using System.Windows;
using Allfree_Application.Commons;
using Allfree_Application.Logics.DBAccessor;
using System.Collections.Generic;
using PostgresqlDBEntity.Entities.Master;

namespace Allfree_Application.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region 内部クラス
        #endregion

        #region メンバ変数
        private MainWindow _mainWindow;
        /// <summary>
        /// 
        /// </summary>
        private string _btnTitle = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private int _userControlWidth = 0;
        /// <summary>
        /// 
        /// </summary>
        private string _settingBtnContent = "設定";
        /// <summary>
        /// 
        /// </summary>
        private ViewModelBase _menuActiveView = new ViewModelBase();
        #endregion

        #region プロパティ
        public ViewModelBase MenuActiveView
        {
            get { return _menuActiveView; }
            set
            {
                _menuActiveView = value;
                RaisePropertyChanged(nameof(MenuActiveView));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SettingBtnContent
        {
            get { return _settingBtnContent; }
            set
            {
                _settingBtnContent = value;
                RaisePropertyChanged(nameof(SettingBtnContent));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand SettingMenuBtn { get; }
        /// <summary>
        /// 
        /// </summary>
        public int UserControlWidth
        {
            get { return _userControlWidth; }
            set
            {
                _userControlWidth = value;
                RaisePropertyChanged(nameof( UserControlWidth ) );
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BtnTitle
        {
            get { return _btnTitle; }
            set
            {
                _btnTitle = value;
                RaisePropertyChanged ( nameof ( BtnTitle ) );
            }
        }
        #endregion

        #region コンストラクタ
        public MainWindowViewModel( MainWindow mainWindow )
        {
            SettingMenuBtn = new DelegateCommand ( SettingMenuOpenClose );
            BtnTitle = "サブオープン";
            _mainWindow = mainWindow;

            if ( !PosgresqlDBAccessor.Instance.DBOpen () )
            {
                MessageBox.Show ( "DB切断失敗" );
                PosgresqlDBAccessor.Instance.DBClose ();
            }
            else
            {
                PosgresqlDBAccessor.Instance.ReadMasterEditPassword ();
                PosgresqlDBAccessor.Instance.ReadMasterTableData ();

                List<m_sex> list = PosgresqlDBAccessor.Instance.MasterSet.m_sexes;
            }
        }
        #endregion

        #region 内部メソッド
        /// <summary>
        /// 
        /// </summary>
        private void SettingMenuOpenClose ()
        {
            if (UserControlWidth == 0 )
            {
                UserControlWidth = 200;
                SettingBtnContent = "閉じる";
                MenuActiveView = new MainWindowViewMenuViewModel ( this );
            }
            else
            {
                UserControlWidth = 0;
                SettingBtnContent = "設定";
            }
        }

        /// <summary>
        /// マスタテーブル変更用ウィンドウの表示
        /// </summary>
        public void MasterEditWindowOpen ()
        {
            SystemPasswordInputWindowViewModel systemPasswordInputWindowViewModel = new SystemPasswordInputWindowViewModel(this);
            SystemPasswordInputWindow systemPasswordInputWindow = new SystemPasswordInputWindow(systemPasswordInputWindowViewModel)
            {
                Owner = _mainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                ResizeMode = ResizeMode.NoResize,
                WindowStyle = WindowStyle.None,
            };
            systemPasswordInputWindow.ShowDialog ();

            if ( systemPasswordInputWindowViewModel.Ok && !systemPasswordInputWindowViewModel.Cancel )
            {
                string password = systemPasswordInputWindowViewModel.Password;
                string masterEditPassword = PosgresqlDBAccessor.Instance.MasterEditPassword;

                // マスタ変更パスワードが正しいか
                if ( !masterEditPassword.Equals(password) )
                {
                    masterEditPassword = string.Empty;
                }

                if ( masterEditPassword != null && masterEditPassword != "" )
                {
                    // マスタテーブル変更ウィンドウをインスタンス化
                    MasterEditWindow masterEditWindow = new MasterEditWindow()
                    {
                        Owner = _mainWindow,
                        WindowStartupLocation = WindowStartupLocation.CenterOwner,
                        ResizeMode = ResizeMode.NoResize
                    };
                    // マスタテーブル変更ウィンドウを開く
                    masterEditWindow.ShowDialog ();
                }
                else
                {
                    MessageBox.Show("パスワードが間違っています。", "ErrorMessage", MessageBoxButton.OK, MessageBoxImage.Error );
                }
            }
        }
        #endregion

        #region 公開メソッド
        #endregion
    }
}
