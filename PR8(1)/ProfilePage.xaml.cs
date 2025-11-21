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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
            int currentProfile = Properties.Settings.Default.CurrentProfile;
            SetProfileData(currentProfile);
        }
        private void SetProfileData(int profile)
        {
            switch (profile)
            {
                case 1:
                    SetProfile1Data();
                    break;
                case 2:
                    SetProfile2Data();
                    break;
                case 3:
                    SetProfile3Data();
                    break;
                case 4:
                    SetProfile4Data();
                    break;
                default:
                    SetGuestProfileData();
                    break;
            }
        }
        private void SetProfile1Data()
        {
            // Основная информация
            AvatarText.Text = "ИП";
            AvatarBorder.Background = new SolidColorBrush(Color.FromRgb(52, 152, 219)); // Синий
            ProfileNameText.Text = "Иван Петров";
            ProfileRoleText.Text = "Студент";
            ProfileGroupText.Text = "Группа: ИВТ-21";

            // Контактная информация
            EmailText.Text = "i.petrov@university.ru";
            PhoneText.Text = "+7 (912) 345-67-89";
            AddressText.Text = "ул. Студенческая, 15, кв. 42";

            // Академическая информация
            FacultyText.Text = "Информационных технологий";
            SpecialtyText.Text = "Информатика и вычислительная техника";
            CourseText.Text = "2";

            // Статистика
            AverageScoreText.Text = "4.7";
            AttendanceText.Text = "85%";
            CompletedCoursesText.Text = "12";
            CurrentCoursesText.Text = "3";
        }

        private void SetProfile2Data()
        {
            // Основная информация
            AvatarText.Text = "Т2";
            AvatarBorder.Background = new SolidColorBrush(Color.FromRgb(231, 76, 60)); // Красный
            ProfileNameText.Text = "Тоха 2х2";
            ProfileRoleText.Text = "Ценитель КФС";
            ProfileGroupText.Text = "Группа: 6ИСтрипс22п";

            // Контактная информация
            EmailText.Text = "nuggets@max.rf";
            PhoneText.Text = "+7 (923) 456-78-90";
            AddressText.Text = "ул. Центральная, 25, кв. 17";

            // Академическая информация
            FacultyText.Text = "Технологии прикладной кулинарии";
            SpecialtyText.Text = "Частный дегустатор";
            CourseText.Text = "10";

            // Статистика
            AverageScoreText.Text = "Сьел";
            AttendanceText.Text = "3%";
            CompletedCoursesText.Text = "4";
            CurrentCoursesText.Text = "6";
        }

        private void SetProfile3Data()
        {
            // Основная информация
            AvatarText.Text = "ПЧ";
            AvatarBorder.Background = new SolidColorBrush(Color.FromRgb(155, 89, 182)); // Фиолетовый
            ProfileNameText.Text = "Папич";
            ProfileRoleText.Text = "Стример";
            ProfileGroupText.Text = "Контент-мейкер";

            // Контактная информация
            EmailText.Text = "papich@stream.ru";
            PhoneText.Text = "+7 (934) 567-89-01";
            AddressText.Text = "ул. Геймерская, 7, кв. 1337";

            // Академическая информация
            FacultyText.Text = "Медиа и коммуникации";
            SpecialtyText.Text = "Стриминг и контент";
            CourseText.Text = "∞";

            // Статистика
            AverageScoreText.Text = "5.0";
            AttendanceText.Text = "99%";
            CompletedCoursesText.Text = "1";
            CurrentCoursesText.Text = "1";
        }

        private void SetProfile4Data()
        {
            // Основная информация
            AvatarText.Text = "ЛФ";
            AvatarBorder.Background = new SolidColorBrush(Color.FromRgb(155, 89, 182)); // Фиолетовый
            ProfileNameText.Text = "Луффи";
            ProfileRoleText.Text = "Пират";
            ProfileGroupText.Text = "42ППш67г";

            // Контактная информация
            EmailText.Text = "pirat1488@more.org";
            PhoneText.Text = "+1 (934) 999-52-01";
            AddressText.Text = "ул. Пещерная, 1, кв. 1";

            // Академическая информация
            FacultyText.Text = "Морские навигация и коммуникации";
            SpecialtyText.Text = "Охотник за головами";
            CourseText.Text = "3";

            // Статистика
            AverageScoreText.Text = "4.7";
            AttendanceText.Text = "1%";
            CompletedCoursesText.Text = "1";
            CurrentCoursesText.Text = "2";
        }


        private void SetGuestProfileData()
        {
            // Основная информация
            AvatarText.Text = "Г";
            AvatarBorder.Background = new SolidColorBrush(Color.FromRgb(149, 165, 166)); // Серый
            ProfileNameText.Text = "Гость";
            ProfileRoleText.Text = "Временный доступ";
            ProfileGroupText.Text = "Не определено";

            // Контактная информация
            EmailText.Text = "Не доступно";
            PhoneText.Text = "Не доступно";
            AddressText.Text = "Не доступно";

            // Академическая информация
            FacultyText.Text = "Не доступно";
            SpecialtyText.Text = "Не доступно";
            CourseText.Text = "0";

            // Статистика
            AverageScoreText.Text = "0.0";
            AttendanceText.Text = "0%";
            CompletedCoursesText.Text = "0";
            CurrentCoursesText.Text = "0";
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
    }
}
