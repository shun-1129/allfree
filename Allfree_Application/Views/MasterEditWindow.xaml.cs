using Allfree_Application.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Allfree_Application.Views
{
    /// <summary>
    /// MasterEditWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MasterEditWindow : Window
    {
        public MasterEditWindow()
        {
            InitializeComponent();
            DataContext = new MasterEditWindowViewModel(this);
        }

        public void AddColumnsDynamically (ObservableCollection<DataGridColumn> inColumns)
        {
            // データグリッドの列を削除（前の定義をクリアする）
            dynamicDataGrid.Columns.Clear ();

            // ViewModelから列の定義を取得する（仮定）
            MasterEditWindowViewModel viewModel = (MasterEditWindowViewModel)this.DataContext;
            ObservableCollection<DataGridColumn> columns = inColumns;

            // データグリッドに列を追加
            foreach ( DataGridColumn column in columns )
            {
                dynamicDataGrid.Columns.Add ( column );
            }
        }
    }
}
