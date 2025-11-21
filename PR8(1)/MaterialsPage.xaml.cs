using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace PR8_1_
{
    /// <summary>
    /// Логика взаимодействия для MaterialsPage.xaml
    /// </summary>
    public partial class MaterialsPage : Page
    {
        private DispatcherTimer _progressTimer;
        private int _currentProgress;
        private int _lectureNumber;
        public MaterialsPage()
        {
            InitializeComponent();
            InitializeProgressTimer();
        }

        private void InitializeProgressTimer()
        {
            _progressTimer = new DispatcherTimer();
            _progressTimer.Interval = TimeSpan.FromSeconds(5); // 5 секунд
            _progressTimer.Tick += ProgressTimer_Tick;
        }
        private void MaterialsPage_Unloaded(object sender, RoutedEventArgs e)
        {
            // Очистка ресурсов при выгрузке страницы
            if (_progressTimer != null && _progressTimer.IsEnabled)
            {
                _progressTimer.Stop();
            }
        }

        private async void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            Button downloadButton = sender as Button;
            if (downloadButton == null) return;

            // Получаем номер лекции из Tag
            if (int.TryParse(downloadButton.Tag?.ToString(), out _lectureNumber))
            {
                // Скрываем кнопку
                downloadButton.Visibility = Visibility.Collapsed;

                // Показываем прогресс бар
                ShowProgressBar(_lectureNumber);

                // Запускаем имитацию скачивания
                await StartDownloadSimulation(_lectureNumber);
            }
        }

        private void ShowProgressBar(int lectureNumber)
        {
            // Показываем соответствующий прогресс бар
            switch (lectureNumber)
            {
                case 1:
                    ProgressGrid1.Visibility = Visibility.Visible;
                    DownloadProgress1.Value = 0;
                    ProgressText1.Text = "0% завершено";
                    break;
                case 2:
                    ProgressGrid2.Visibility = Visibility.Visible;
                    DownloadProgress2.Value = 0;
                    ProgressText2.Text = "0% завершено";
                    break;
                case 3:
                    ProgressGrid3.Visibility = Visibility.Visible;
                    DownloadProgress3.Value = 0;
                    ProgressText3.Text = "0% завершено";
                    break;
            }

            _currentProgress = 0;
        }

        private async Task StartDownloadSimulation(int lectureNumber)
        {
            // Имитация задержки перед началом скачивания
            await Task.Delay(500);

            // Запускаем таймер для обновления прогресса
            _progressTimer.Start();
        }

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            _currentProgress += rnd.Next(rnd.Next(-50,10),rnd.Next(11,80)); // Увеличиваем прогресс на 20%

            // Обновляем соответствующий прогресс бар
            UpdateProgressBar(_lectureNumber, _currentProgress);

            // Если достигли 100%, останавливаем таймер и скрываем прогресс бар
            if (_currentProgress >= 100)
            {
                _currentProgress = 100;
                _progressTimer.Stop();

                // Ждем немного перед скрытием, чтобы пользователь увидел 100%
                Task.Delay(rnd.Next(rnd.Next(-50,0),rnd.Next(1,100))).ContinueWith(_ =>
                {
                    Dispatcher.Invoke(() =>
                    {
                        HideProgressBar(_lectureNumber);
                    });
                });
            }
        }

        private void UpdateProgressBar(int lectureNumber, int progress)
        {
            switch (lectureNumber)
            {
                case 1:
                    DownloadProgress1.Value = progress;
                    ProgressText1.Text = $"{progress}% завершено";
                    break;
                case 2:
                    DownloadProgress2.Value = progress;
                    ProgressText2.Text = $"{progress}% завершено";
                    break;
                case 3:
                    DownloadProgress3.Value = progress;
                    ProgressText3.Text = $"{progress}% завершено";
                    break;
            }
        }

        private void HideProgressBar(int lectureNumber)
        {
            switch (lectureNumber)
            {
                case 1:
                    ProgressGrid1.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    ProgressGrid2.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    ProgressGrid3.Visibility = Visibility.Collapsed;
                    break;
            }

            // Показываем сообщение об успешном скачивании
            ShowDownloadCompleteMessage(lectureNumber);
        }

        private void ShowDownloadCompleteMessage(int lectureNumber)
        {
            string lectureName = GetLectureName(lectureNumber);

            MessageBox.Show($"Лекция '{lectureName}' успешно скачана!\n\nФайл сохранен в папке 'Загрузки'.",
                          "Скачивание завершено",
                          MessageBoxButton.OK,
                          MessageBoxImage.Information);
        }

        private string GetLectureName(int lectureNumber)
        {
            // Заменяем switch expression на обычный switch для C# 7.3
            switch (lectureNumber)
            {
                case 1:
                    return "Лекция 1: Введение в анализ";
                case 2:
                    return "Лекция 2: Пределы функций";
                case 3:
                    return "Практика: Основы C#";
                default:
                    return "Неизвестная лекция";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.InDevelopmentBox();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.InDevelopmentBox();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.InDevelopmentBox();
        }
    }
}
