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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PR8_1_
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;

            if (mainWindow != null)
            {
                // Вызываем метод навигации из главного окна
                mainWindow.NavigateToCoursesPage();
            }
            else
            {
                // Альтернативный способ, если не удалось получить главное окно
                NavigationService?.Navigate(new CoursesPage());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;

            if (mainWindow != null)
            {
                // Вызываем метод навигации из главного окна
                mainWindow.NavigateToSchedulePage();
            }
            else
            {
                // Альтернативный способ, если не удалось получить главное окно
                NavigationService?.Navigate(new SchedulePage());
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;

            if (mainWindow != null)
            {
                // Вызываем метод навигации из главного окна
                mainWindow.NavigateToMessagesPage();
            }
            else
            {
                // Альтернативный способ, если не удалось получить главное окно
                NavigationService?.Navigate(new MessagesPage());
            }
        }
    }
}
