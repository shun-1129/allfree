using Allfree_Application.Views;
using CommonLibrary.ViewModelBase;

namespace Allfree_Application.ViewModels
{
    public class MasterEditWindowViewModel : ViewModelBase
    {
        #region 内部クラス
        #endregion

        #region メンバ変数
        private MainWindowViewModel _mainWindowViewModel;
        #endregion

        #region プロパティ
        #endregion

        #region コンストラクタ
        public MasterEditWindowViewModel (MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }
        #endregion

        #region 内部メソッド
        #endregion

        #region 公開メソッド
        //public bool? ShowDialog ()
        //{
        //    MasterEditWindow view = new MasterEditWindow ();
        //    view.InitializeComponent ();
        //    return view.ShowDialog ();
        //}
        #endregion
    }
}
