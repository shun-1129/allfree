using Allfree_Application.ViewModels;
using System.Windows;

namespace Allfree_Application.Views
{
    /// <summary>
    /// MasterEditWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MasterEditWindow : Window
    {
        public MasterEditWindow(MasterEditWindowViewModel masterEditWindowViewModel)
        {
            InitializeComponent();
            DataContext = masterEditWindowViewModel;
        }
    }
}
