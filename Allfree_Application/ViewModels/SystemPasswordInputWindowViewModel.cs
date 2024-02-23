using Allfree_Application.Views;
using CommonLibrary.Command;
using CommonLibrary.ViewModelBase;
using System.Security;
using System.Windows;

namespace Allfree_Application.ViewModels
{
    public class SystemPasswordInputWindowViewModel : ViewModelBase
    {
        #region 内部クラス
        #endregion

        #region 定数
        #endregion

        #region メンバ変数
        private MainWindowViewModel _mainWindowViewModel;
        /// <summary>
        /// 
        /// </summary>
        private string _windowTitle = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private string _password = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private bool _ok = false;
        /// <summary>
        /// 
        /// </summary>
        private bool _cancel = false;
        #endregion

        #region プロパティ
        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand<Window> OKBtn { get; }
        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand<Window> CancelBtn { get; }
        /// <summary>
        /// 
        /// </summary>
        public string WindowTitle
        {
            get { return _windowTitle; }
            set
            {
                _windowTitle = value;
                RaisePropertyChanged(nameof(WindowTitle));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Ok
        {
            get => _ok;
            set
            {
                _ok = value;
                RaisePropertyChanged(nameof(Ok));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Cancel
        {
            get => _cancel;
            set
            {
                _cancel = value;
                RaisePropertyChanged(nameof(Cancel));
            }
        }
        #endregion

        #region コンストラクタ
        public SystemPasswordInputWindowViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            WindowTitle = "システムパスワード入力画面";

            OKBtn = new DelegateCommand<Window> ( OKBtnExcute );
            CancelBtn = new DelegateCommand<Window> ( CancelBtnExcute );
        }
        #endregion

        #region 内部メソッド
        /// <summary>
        /// 
        /// </summary>
        private void OKBtnExcute (Window param)
        {
            Password = ( param as SystemPasswordInputWindow ).passwordBox.Password;

            if ( Password == null || Password == "" )
            {
                Ok = false;
                MessageBox.Show ( "パスワードが入力されていません。" , "ErrorMessage" , MessageBoxButton.OK , MessageBoxImage.Error );
            }
            else
            {
                Ok = true;
                ( param as Window )?.Close ();
            }
        }

        private void CancelBtnExcute (Window param)
        {
            Cancel = true;
            ( param as Window )?.Close ();
        }
        #endregion

        #region 公開メソッド
        #endregion
    }
}
