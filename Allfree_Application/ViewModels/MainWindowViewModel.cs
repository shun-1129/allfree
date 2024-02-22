using Allfree_Application.Logics;
using Allfree_Application.Views;
using Allfree_Application.ViewModels.UserControls;
using CommonLibrary.Command;
using CommonLibrary.ViewModelBase;
using SQLiteDBEntity.Entities.System;
using System.Windows;

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
        private ViewModelBase _activeView;
        #endregion

        #region プロパティ
        public ViewModelBase ActiveView
        {
            get { return _activeView; }
            set
            {
                _activeView = value;
                RaisePropertyChanged(nameof(ActiveView));
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
        public DelegateCommand MasterEditWindowOpenBtn { get; }
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
            //MasterEditWindowOpenBtn = new DelegateCommand ( MasterEditWindowOpen );
            BtnTitle = "サブオープン";
            _mainWindow = mainWindow;
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
                ActiveView = new MainWindowViewMenuViewModel ( this );
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
                s_master_edit_password masterEditPassword = DBAccessor.Instance.GetMasterEditPassword(1, password);

                if ( masterEditPassword != null )
                {
                    // マスタテーブル変更ウィンドウをインスタンス化
                    MasterEditWindow masterEditWindow = new MasterEditWindow(new MasterEditWindowViewModel(this))
                    {
                        Owner = _mainWindow,
                        WindowStartupLocation = WindowStartupLocation.CenterOwner,
                        ResizeMode = ResizeMode.NoResize
                    };
                    // マスタテーブル変更ウィンドウを開く
                    masterEditWindow.ShowDialog ();
                }
            }
        }
        #endregion

        #region 公開メソッド
        #endregion
    }
}
