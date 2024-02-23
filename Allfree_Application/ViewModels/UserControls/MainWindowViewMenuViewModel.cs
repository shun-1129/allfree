using CommonLibrary.Command;
using CommonLibrary.ViewModelBase;

namespace Allfree_Application.ViewModels.UserControls
{
    public class MainWindowViewMenuViewModel : ViewModelBase
    {
        #region 内部クラス
        #endregion

        #region 定数
        #endregion

        #region メンバ変数
        private MainWindowViewModel _mainWindowViewModel;
        #endregion

        #region プロパティ
        public DelegateCommand TestBtn { get; }
        #endregion

        #region コンストラクタ
        public MainWindowViewMenuViewModel ( MainWindowViewModel mainWindowViewModel )
        {
            _mainWindowViewModel = mainWindowViewModel;
            TestBtn = new DelegateCommand ( Test );
        }
        #endregion

        #region 内部メソッド
        private void Test ()
        {
            _mainWindowViewModel.MasterEditWindowOpen ();
        }
        #endregion

        #region 公開メソッド
        #endregion
    }
}
