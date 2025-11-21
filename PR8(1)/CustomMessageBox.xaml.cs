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

namespace PR8_1_
{
    public partial class CustomMessageBox : Window
    {
        public MessageBoxResult Result { get; private set; }

        public CustomMessageBox(string message, string title, MessageBoxButton buttons)
        {
            InitializeComponent();
            MessageText.Text = message;
            TitleText.Text = title;
            SetupButtons(buttons);
            Result = MessageBoxResult.None;
        }

        private void SetupButtons(MessageBoxButton buttons)
        {
            // Скрыть все кнопки сначала
            YesButton.Visibility = Visibility.Collapsed;
            NoButton.Visibility = Visibility.Collapsed;
            OKButton.Visibility = Visibility.Collapsed;
            CancelButton.Visibility = Visibility.Collapsed;

            // Показать нужные кнопки в зависимости от параметра
            switch (buttons)
            {
                case MessageBoxButton.OK:
                    OKButton.Visibility = Visibility.Visible;
                    break;
                case MessageBoxButton.OKCancel:
                    OKButton.Visibility = Visibility.Visible;
                    CancelButton.Visibility = Visibility.Visible;
                    break;
                case MessageBoxButton.YesNo:
                    YesButton.Visibility = Visibility.Visible;
                    NoButton.Visibility = Visibility.Visible;
                    break;
                case MessageBoxButton.YesNoCancel:
                    YesButton.Visibility = Visibility.Visible;
                    NoButton.Visibility = Visibility.Visible;
                    CancelButton.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            switch (button.Name)
            {
                case "YesButton":
                    Result = MessageBoxResult.Yes;
                    break;
                case "NoButton":
                    Result = MessageBoxResult.No;
                    break;
                case "OKButton":
                    Result = MessageBoxResult.OK;
                    break;
                case "CancelButton":
                    Result = MessageBoxResult.Cancel;
                    break;
                default:
                    Result = MessageBoxResult.None;
                    break;
            }

            DialogResult = true;
            Close();
        }

        // Обработчик для закрытия окна по Escape
        protected override void OnKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
            {
                Result = MessageBoxResult.Cancel;
                DialogResult = false;
                Close();
            }
            base.OnKeyDown(e);
        }
    }
}
