using System.Windows;
using System.Windows.Controls;

namespace PR8_1_
{
    public partial class MainWindow : Window
    {
        private int _currentProfile;
        public MainWindow(int Profile)
        {
            InitializeComponent();
            _currentProfile = Profile;


            // Устанавливаем информацию о профиле
            Properties.Settings.Default.CurrentProfile = Profile;
            Properties.Settings.Default.Save();

            // Устанавливаем информацию о профиле
            SetProfileInfo(_currentProfile);

            LoadHomePage();

        }


        private void SetProfileInfo(int profile)
        {
            // Отладочная информация
            System.Diagnostics.Debug.WriteLine($"Установка профиля: {profile}");

            switch (profile)
            {
                case 1:
                    StudentName.Text = "Иван Петров";
                    StudentGroup.Text = "Студент, ИВТ-21";
                    break;
                case 2:
                    StudentName.Text = "Тоха 2х2";
                    StudentGroup.Text = "Ценитель КФС, 6ИСтрипс22п";
                    break;
                case 3:
                    StudentName.Text = "Папич";
                    StudentGroup.Text = "Стример";
                    break;
                case 4:
                    StudentName.Text = "Луффи";
                    StudentGroup.Text = "Пират";
                    break;
                case 0: // Гость
                    StudentName.Text = "Гость";
                    StudentGroup.Text = "Временный доступ";
                    break;
                default:
                    StudentName.Text = "Неизвестный пользователь";
                    StudentGroup.Text = "Роль не определена";
                    break;
            }
        }




        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string pageTag = button.Tag.ToString();

            switch (pageTag)
            {
                case "Home":
                    LoadHomePage();
                    break;
                case "Schedule":
                    LoadSchedulePage();
                    break;
                case "Courses":
                    LoadCoursesPage();
                    break;
                case "Materials":
                    LoadMaterialsPage();
                    break;
                case "Grades":
                    LoadGradesPage();
                    break;
                case "Messages":
                    LoadMessagesPage();
                    break;
                case "Events":
                    LoadEventsPage();
                    break;
                case "Profile":
                    LoadProfilePage();
                    break;
            }
        }

        public void NavigateToCoursesPage()
        {
            LoadCoursesPage();
        }

        public void NavigateToSchedulePage()
        {
            LoadSchedulePage();
        }
        public void NavigateToMessagesPage()
        {
            LoadMessagesPage();
        }

        public void LoadHomePage()
        {
            var page = new HomePage();
            MainFrame.Content = page;
        }

        private void LoadSchedulePage()
        {
            var page = new SchedulePage();
            MainFrame.Content = page;
        }

        private void LoadCoursesPage()
        {
            var page = new CoursesPage();
            MainFrame.Content = page;
        }

        private void LoadMaterialsPage()
        {
            var page = new MaterialsPage();
            MainFrame.Content = page;
        }

        private void LoadGradesPage()
        {
            var page = new GradesPage();
            MainFrame.Content = page;
        }

        private void LoadMessagesPage()
        {
            var page = new MessagesPage();
            MainFrame.Content = page;
        }

        private void LoadEventsPage()
        {
            var page = new EventsPage();
            MainFrame.Content = page;
        }

        private void LoadProfilePage()
        {
            var page = new ProfilePage();
            MainFrame.Content = page;
        }

        public void InDevelopmentBox()
        {
            CustomMessageBoxService.Show("🛠 В разработке. 🛠", "Внимание!");
        }

        public void YouAppliedBox()
        {
            CustomMessageBoxService.Show("Ты записан.", "Поздравляем!");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var page = new NotificationsPage();
            MainFrame.Content = page;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoginWindow mainWindow = new LoginWindow();
            this.Close();
            mainWindow.Show();
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var page = new SettingsPage();
            MainFrame.Content = page;
        }
    }
}