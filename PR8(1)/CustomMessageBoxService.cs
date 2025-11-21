using PR8_1_;
using System;
using System.Windows;

namespace PR8_1_
{
    public static class CustomMessageBoxService
    {
        public static MessageBoxResult Show(string message)
        {
            return Show(message, string.Empty, MessageBoxButton.OK);
        }

        public static MessageBoxResult Show(string message, string title)
        {
            return Show(message, title, MessageBoxButton.OK);
        }

        public static MessageBoxResult Show(string message, string title, MessageBoxButton buttons)
        {
            var dialog = new CustomMessageBox(message, title, buttons);

            // Устанавливаем владельца, если есть главное окно
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

        public static MessageBoxResult Show(Window owner, string message)
        {
            return Show(owner, message, string.Empty, MessageBoxButton.OK);
        }

        public static MessageBoxResult Show(Window owner, string message, string title)
        {
            return Show(owner, message, title, MessageBoxButton.OK);
        }

        public static MessageBoxResult Show(Window owner, string message, string title, MessageBoxButton buttons)
        {
            if (owner == null)
                throw new ArgumentNullException(nameof(owner));

            var dialog = new CustomMessageBox(message, title, buttons)
            {
                Owner = owner,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            dialog.ShowDialog();
            return dialog.Result;
        }
    }
}