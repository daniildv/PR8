using PR8_1_;
using System;
using System.Windows;

namespace PR8_1_
{
    public enum CustomMessageBoxImage
    {
        None,
        Error,
        Warning,
        Information,
        Question,
        Success
    }

    public static class CustomMessageBoxEx
    {
        public static MessageBoxResult Show(string message, string title, MessageBoxButton buttons, CustomMessageBoxImage icon)
        {
            var dialog = new CustomMessageBox(message, title, buttons);

            // Устанавливаем иконку (если у вас есть соответствующий Image в XAML)
            SetIcon(dialog, icon);

            if (Application.Current != null && Application.Current.MainWindow != null)
            {
                dialog.Owner = Application.Current.MainWindow;
                dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }
            else
            {
                dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }

            dialog.ShowDialog();
            return dialog.Result;
        }

        private static void SetIcon(CustomMessageBox dialog, CustomMessageBoxImage icon)
        {
            // Этот метод нужно адаптировать под вашу XAML разметку
            // Если у вас есть элемент Image с именем IconImage в XAML:

            /*
            switch (icon)
            {
                case CustomMessageBoxImage.Error:
                    dialog.IconImage.Source = new BitmapImage(new Uri("/Images/error.png", UriKind.Relative));
                    break;
                case CustomMessageBoxImage.Warning:
                    dialog.IconImage.Source = new BitmapImage(new Uri("/Images/warning.png", UriKind.Relative));
                    break;
                case CustomMessageBoxImage.Information:
                    dialog.IconImage.Source = new BitmapImage(new Uri("/Images/info.png", UriKind.Relative));
                    break;
                case CustomMessageBoxImage.Question:
                    dialog.IconImage.Source = new BitmapImage(new Uri("/Images/question.png", UriKind.Relative));
                    break;
                case CustomMessageBoxImage.Success:
                    dialog.IconImage.Source = new BitmapImage(new Uri("/Images/success.png", UriKind.Relative));
                    break;
                default:
                    dialog.IconImage.Visibility = Visibility.Collapsed;
                    break;
            }
            */
        }
    }
}