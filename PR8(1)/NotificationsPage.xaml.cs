using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PR8_1_
{
    public partial class NotificationsPage : Page
    {
        public NotificationsPage()
        {
            InitializeComponent();
        }

        private void DeleteNotification_Click(object sender, RoutedEventArgs e)
        {
            Button deleteButton = sender as Button;
            if (deleteButton != null)
            {
                Border notificationBorder = FindParent<Border>(deleteButton);
                if (notificationBorder != null)
                {
                    // Анимация исчезновения (можно добавить позже)
                    notificationBorder.Visibility = Visibility.Collapsed;

                    // В реальном приложении здесь была бы логика удаления из базы данных
                    MessageBox.Show("Уведомление удалено", "Уведомление",
                                  MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void MarkAllAsRead_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Все уведомления помечены как прочитанные", "Уведомления",
                          MessageBoxButton.OK, MessageBoxImage.Information);

            // В реальном приложении здесь была бы логика обновления статуса всех уведомлений
        }

        // Вспомогательный метод для поиска родительского элемента
        private T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parent = VisualTreeHelper.GetParent(child);

            if (parent == null) return null;

            T parentOfType = parent as T;
            if (parentOfType != null)
            {
                return parentOfType;
            }

            return FindParent<T>(parent);
        }
    }
}