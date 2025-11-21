using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PR8_1_
{
    public partial class GradesPage : Page
    {
        public GradesPage()
        {
            InitializeComponent();

            // Получаем текущий профиль из настроек приложения
            int currentProfile = Properties.Settings.Default.CurrentProfile;
            SetGradesData(currentProfile);
        }

        private void SetGradesData(int profile)
        {
            switch (profile)
            {
                case 1:
                    SetProfile1Grades();
                    break;
                case 2:
                    SetProfile2Grades();
                    break;
                case 3:
                    SetProfile3Grades();
                    break;
                case 4:
                    SetProfile4Grades();
                    break;
                default:
                    SetGuestGrades();
                    break;
            }
        }

        private void SetProfile1Grades()
        {
            // Профиль 1: Иван Петров - отличник
            AverageScoreText.Text = "4.7";
            AverageScoreBorder.Background = new SolidColorBrush(Color.FromRgb(52, 152, 219));
            ProgressPercentText.Text = "65%";
            SemesterProgressBar.Value = 65;
            DaysRemainingText.Text = "До конца семестра: 45 дней";

            // Математика
            MathSubjectText.Text = "Математический анализ";
            MathScore1.Text = "85";
            MathScore2.Text = "92";

            // Программирование
            ProgrammingSubjectText.Text = "Программирование на C#";
            ProgrammingScore1.Text = "95";
            ProgrammingScore2.Text = "88";

            // Базы данных
            DatabaseSubjectText.Text = "Базы данных";
            DatabaseScore1.Text = "78";
        }

        private void SetProfile2Grades()
        {
            // Профиль 2: Тоха 2х2 - проблемный студент
            AverageScoreText.Text = "Сьел";
            AverageScoreBorder.Background = new SolidColorBrush(Color.FromRgb(231, 76, 60));
            ProgressPercentText.Text = "3%";
            SemesterProgressBar.Value = 3;
            DaysRemainingText.Text = "До отчисления: 2 дня";

            // Математика
            MathSubjectText.Text = "Основы кулинарной математики";
            MathScore1.Text = "12";
            MathScore2.Text = "8";

            // Программирование
            ProgrammingSubjectText.Text = "Программирование микроволновок";
            ProgrammingScore1.Text = "25";
            ProgrammingScore2.Text = "18";

            // Базы данных
            DatabaseSubjectText.Text = "Базы рецептов";
            DatabaseScore1.Text = "5";
        }

        private void SetProfile3Grades()
        {
            // Профиль 3: Папич - идеальный студент
            AverageScoreText.Text = "5.0";
            AverageScoreBorder.Background = new SolidColorBrush(Color.FromRgb(155, 89, 182));
            ProgressPercentText.Text = "99%";
            SemesterProgressBar.Value = 99;
            DaysRemainingText.Text = "До конца семестра: 1 день";

            // Математика
            MathSubjectText.Text = "Математика стриминга";
            MathScore1.Text = "100";
            MathScore2.Text = "100";

            // Программирование
            ProgrammingSubjectText.Text = "Программирование стрим-ботов";
            ProgrammingScore1.Text = "100";
            ProgrammingScore2.Text = "100";

            // Базы данных
            DatabaseSubjectText.Text = "Базы донатов";
            DatabaseScore1.Text = "100";
        }

        private void SetProfile4Grades()
        {
            // Профиль 4: Луффи - пират
            AverageScoreText.Text = "4.7";
            AverageScoreBorder.Background = new SolidColorBrush(Color.FromRgb(46, 204, 113));
            ProgressPercentText.Text = "1%";
            SemesterProgressBar.Value = 1;
            DaysRemainingText.Text = "До поиска сокровищ: 7 дней";

            // Математика
            MathSubjectText.Text = "Навигационная математика";
            MathScore1.Text = "90";
            MathScore2.Text = "85";

            // Программирование
            ProgrammingSubjectText.Text = "Программирование карт";
            ProgrammingScore1.Text = "80";
            ProgrammingScore2.Text = "75";

            // Базы данных
            DatabaseSubjectText.Text = "Базы сокровищ";
            DatabaseScore1.Text = "85";
        }

        private void SetGuestGrades()
        {
            // Гость - нет доступа
            AverageScoreText.Text = "0.0";
            AverageScoreBorder.Background = new SolidColorBrush(Color.FromRgb(149, 165, 166));
            ProgressPercentText.Text = "0%";
            SemesterProgressBar.Value = 0;
            DaysRemainingText.Text = "Доступ ограничен";

            // Математика
            MathSubjectText.Text = "Математика";
            MathScore1.Text = "Н/Д";
            MathScore2.Text = "Н/Д";

            // Программирование
            ProgrammingSubjectText.Text = "Программирование";
            ProgrammingScore1.Text = "Н/Д";
            ProgrammingScore2.Text = "Н/Д";

            // Базы данных
            DatabaseSubjectText.Text = "Базы данных";
            DatabaseScore1.Text = "Н/Д";
        }
    }
}
