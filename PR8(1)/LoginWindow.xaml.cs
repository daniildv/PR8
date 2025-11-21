using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Threading.Tasks;
using PR8_1_;


namespace PR8_1_
{
    public partial class LoginWindow : Window
    {
        public int Profile { get; private set; }
        private Random _random;

        public LoginWindow()
        {
            InitializeComponent();
            _random = new Random();
            Profile = 0;

            // Установка фокуса на поле логина при загрузке
            Loaded += (s, e) => UsernameTextBox.Focus();
            
        }
        
        private void LoginFields_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Активируем кнопку входа только если оба поля заполнены
            bool isUsernameEmpty = string.IsNullOrWhiteSpace(UsernameTextBox.Text);
            bool isPasswordEmpty = string.IsNullOrWhiteSpace(PasswordBox.Password);

            LoginButton.IsEnabled = !isUsernameEmpty && !isPasswordEmpty;

            // Скрываем сообщение об ошибке при изменении полей
            HideErrorMessage();
        }

        private void LoginFields_TextChanged(object sender, RoutedEventArgs e)
        {
            // Перегрузка для PasswordBox
            LoginFields_TextChanged(sender, new TextChangedEventArgs(e.RoutedEvent, UndoAction.None));
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Генерируем случайный профиль при нажатии на кнопку входа
            int profile = _random.Next(1, 5); // 1, 2 или 3

            // Сохраняем выбранный профиль в настройках приложения
            Properties.Settings.Default.CurrentProfile = profile;
            Properties.Settings.Default.Save();

            // Отладочная информация
            System.Diagnostics.Debug.WriteLine($"Сгенерирован профиль: {profile}");

            // Показываем прогресс и отключаем кнопку
            ShowProgress();
            LoginButton.IsEnabled = false;

            try
            {
                // Имитация задержки сети
                await Task.Delay(1500);

                // Простая проверка логина и пароля
                if (await AuthenticateUser(UsernameTextBox.Text, PasswordBox.Password))
                {
                    // Успешный вход
                    OpenMainWindow(profile);
                }
                else
                {
                    // Неверные учетные данные
                    ShowErrorMessage("Неверный логин или пароль. Пожалуйста, проверьте введенные данные.");
                }
            }
            catch (Exception ex)
            {
                // Ошибка при аутентификации
                ShowErrorMessage($"Ошибка подключения: {ex.Message}");
            }
            finally
            {
                // Скрываем прогресс и активируем кнопку
                HideProgress();
                LoginButton.IsEnabled = true;
            }
        }

        private async Task<bool> AuthenticateUser(string username, string password)
        {
            // Временная реализация аутентификации
            // В реальном приложении здесь должен быть вызов API или проверка в базе данных

            await Task.Delay(500); // Имитация сетевой задержки

            // Пример простой проверки (для демонстрации)
            var validUsers = new[]
            {
                new { Username = "student", Password = "password", Role = "Student" },
                new { Username = "teacher", Password = "password", Role = "Teacher" },
                new { Username = "admin", Password = "admin", Role = "Admin" }
            };

            foreach (var user in validUsers)
            {
                if (username.ToLower() == user.Username && password == user.Password)
                {
                    // Сохраняем информацию о пользователе (в реальном приложении использовать безопасное хранение)
                   

                    return true;
                }
            }

            return false;
        }

        private void OpenMainWindow(int profile)
        {
            // Создаем и показываем главное окно, передавая текущий профиль
            MainWindow mainWindow = new MainWindow(profile);
            mainWindow.Show();

            // Закрываем окно входа
            this.Close();
        }

        private void UniversityAccountButton_Click(object sender, RoutedEventArgs e)
        {
            // Вход через личный кабинет вуза
            MessageBox.Show("Функция входа через личный кабинет вуза будет реализована в будущей версии.",
                          "В разработке",
                          MessageBoxButton.OK,
                          MessageBoxImage.Information);
        }

        private void GuestLoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Гостевой вход
            var result = MessageBox.Show("Войти как гость? Гостевой доступ ограничен просмотром расписания и общих материалов.",
                                       "Гостевой вход",
                                       MessageBoxButton.YesNo,
                                       MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                int profile = 0; // Гостевой профиль
                Properties.Settings.Default.CurrentProfile = profile;
                Properties.Settings.Default.CurrentUser = "Гость";
                Properties.Settings.Default.UserRole = "Guest";
                Properties.Settings.Default.Save();

                OpenMainWindow(profile);
            }
        }

        private void ForgotPassword_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Восстановление пароля
            MessageBox.Show("Для восстановления пароля обратитесь в техническую поддержку университета.",
                          "Восстановление пароля",
                          MessageBoxButton.OK,
                          MessageBoxImage.Information);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Закрытие приложения
            Application.Current.Shutdown();
        }

        private void ShowProgress()
        {
            ProgressBorder.Visibility = Visibility.Visible;
            ErrorMessageBorder.Visibility = Visibility.Collapsed;
        }

        private void HideProgress()
        {
            ProgressBorder.Visibility = Visibility.Collapsed;
        }

        private void ShowErrorMessage(string message)
        {
            ErrorMessageText.Text = message;
            ErrorMessageBorder.Visibility = Visibility.Visible;
        }

        private void HideErrorMessage()
        {
            ErrorMessageBorder.Visibility = Visibility.Collapsed;
        }

        // Обработка перемещения окна
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }
    }
}