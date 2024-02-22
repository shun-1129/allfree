using Allfree_Application.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Allfree_Application.Views
{
    /// <summary>
    /// SystemPasswordInputWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SystemPasswordInputWindow : Window
    {
        #region 内部クラス
        #endregion

        #region 定数
        #endregion

        #region メンバ変数
        #endregion

        #region プロパティ
        #endregion

        #region コンストラクタ
        public SystemPasswordInputWindow (SystemPasswordInputWindowViewModel systemPasswordInputWindowViewModel)
        {
            InitializeComponent ();
            DataContext = systemPasswordInputWindowViewModel;
        }
        #endregion

        #region 内部メソッド
        #endregion

        #region 公開メソッド
        #endregion
    }
}
