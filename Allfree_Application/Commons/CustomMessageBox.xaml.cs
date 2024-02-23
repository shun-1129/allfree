using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Allfree_Application.Commons
{
    /// <summary>
    /// CustomMessageBox.xaml の相互作用ロジック
    /// </summary>
    public partial class CustomMessageBox : Window
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
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public CustomMessageBox ()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }
        #endregion

        #region 内部メソッド
        #endregion

        #region 公開メソッド
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageBoxText"></param>
        /// <returns></returns>
        public static MessageBoxResult Show ( string messageBoxText )
        {
            CustomMessageBox customMessageBox = new CustomMessageBox();
            customMessageBox.Title = "CustomMessageBox";
            customMessageBox.Content = messageBoxText;
            customMessageBox.ShowDialog ();
            return MessageBoxResult.None; // 必要に応じて適切な戻り値を返す
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageBoxText"></param>
        /// <param name="messageBoxTitle"></param>
        /// <returns></returns>
        public static MessageBoxResult Show ( string messageBoxText , string messageBoxTitle )
        {
            CustomMessageBox customMessageBox = new CustomMessageBox();
            customMessageBox.Title = messageBoxTitle;
            customMessageBox.Content = messageBoxText;
            customMessageBox.ShowDialog ();
            return MessageBoxResult.None; // 必要に応じて適切な戻り値を返す
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageBoxText"></param>
        /// <param name="messageBoxTitle"></param>
        /// <param name="messageBoxButton"></param>
        /// <returns></returns>
        public static MessageBoxResult Show ( string messageBoxText , string messageBoxTitle, MessageBoxImage icon )
        {
            CustomMessageBox customMessageBox = new CustomMessageBox();
            customMessageBox.Title = messageBoxTitle;

            StackPanel stackPanel = new StackPanel();

            // メッセージテキストを表示
            TextBlock messageTextBlock = new TextBlock();
            messageTextBlock.Text = messageBoxText;
            stackPanel.Children.Add ( messageTextBlock );

            // アイコンを表示
            Image iconImage = new Image();
            switch ( icon )
            {
                case MessageBoxImage.Error:
                    iconImage.Source = new BitmapImage ( new System.Uri ( "pack://application:,,,/Resources/ErrorIcon.png" ) );
                    break;
                case MessageBoxImage.Information:
                    iconImage.Source = new BitmapImage ( new System.Uri ( "pack://application:,,,/Resources/InformationIcon.png" ) );
                    break;
                case MessageBoxImage.Question:
                    iconImage.Source = new BitmapImage ( new System.Uri ( "pack://application:,,,/Resources/QuestionIcon.png" ) );
                    break;
                case MessageBoxImage.Warning:
                    iconImage.Source = new BitmapImage ( new System.Uri ( "pack://application:,,,/Resources/WarningIcon.png" ) );
                    break;
                default:
                    break;
            }
            stackPanel.Children.Add ( iconImage );

            customMessageBox.Content = stackPanel;

            customMessageBox.ShowDialog ();
            return MessageBoxResult.None; // 
        }
        #endregion
    }
}
