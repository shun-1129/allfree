using Allfree_Application.ViewModels;
using System.Windows;

namespace Allfree_Application.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow ()
        {
            InitializeComponent ();
            MainWindowViewModel viewModel = new MainWindowViewModel(this);
            DataContext = viewModel;
        }
    }
}
