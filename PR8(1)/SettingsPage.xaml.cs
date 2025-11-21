using System.Windows;
using System.Windows.Controls;

namespace PR8_1_
{
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();

            // Инициализация выбора категории после загрузки компонентов
            this.Loaded += (s, e) =>
            {
                // Убедимся, что выбрана категория "Основные" по умолчанию
                if (SettingsCategories.SelectedItem == null && SettingsCategories.Items.Count > 0)
                {
                    SettingsCategories.SelectedIndex = 0;
                }
            };
        }

        private void SettingsCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Проверяем, что элементы инициализированы перед обращением к ним
            if (GeneralSettings == null || NotificationSettings == null ||
                PrivacySettings == null || AppearanceSettings == null ||
                AboutSettings == null || SettingsCategories.SelectedItem == null)
            {
                return;
            }

            // Скрываем все разделы
            GeneralSettings.Visibility = Visibility.Collapsed;
            NotificationSettings.Visibility = Visibility.Collapsed;
            PrivacySettings.Visibility = Visibility.Collapsed;
            AppearanceSettings.Visibility = Visibility.Collapsed;
            AboutSettings.Visibility = Visibility.Collapsed;

            // Показываем выбранный раздел
            if (SettingsCategories.SelectedItem is ListBoxItem selectedItem && selectedItem.Tag != null)
            {
                switch (selectedItem.Tag.ToString())
                {
                    case "general":
                        GeneralSettings.Visibility = Visibility.Visible;
                        break;
                    case "notifications":
                        NotificationSettings.Visibility = Visibility.Visible;
                        break;
                    case "privacy":
                        PrivacySettings.Visibility = Visibility.Visible;
                        break;
                    case "appearance":
                        AppearanceSettings.Visibility = Visibility.Visible;
                        break;
                    case "about":
                        AboutSettings.Visibility = Visibility.Visible;
                        break;
                }
            }
        }

        private void ClearCache_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Кеш приложения успешно очищен", "Очистка кеша",
                          MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void DeleteData_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите удалить все ваши данные? Это действие нельзя отменить.",
                                       "Удаление данных",
                                       MessageBoxButton.YesNo,
                                       MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Ваши данные были удалены", "Данные удалены",
                              MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void CheckUpdates_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Проверка обновлений...\nУ вас установлена последняя версия приложения.",
                          "Обновления",
                          MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ResetSettings_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите сбросить все настройки к значениям по умолчанию?",
                                       "Сброс настроек",
                                       MessageBoxButton.YesNo,
                                       MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Настройки были сброшены к значениям по умолчанию",
                              "Сброс настроек",
                              MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void SaveSettings_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Настройки успешно сохранены", "Сохранение",
                          MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}