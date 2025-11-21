using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PR8_1_
{
    public partial class CoursesPage : Page
    {
        public CoursesPage()
        {
            InitializeComponent();

            // Получаем текущий профиль из настроек приложения
            int currentProfile = Properties.Settings.Default.CurrentProfile;
            SetCoursesData(currentProfile);
        }

        private void SetCoursesData(int profile)
        {
            switch (profile)
            {
                case 1:
                    SetProfile1Courses();
                    break;
                case 2:
                    SetProfile2Courses();
                    break;
                case 3:
                    SetProfile3Courses();
                    break;
                case 4:
                    SetProfile4Courses();
                    break;
                default:
                    SetGuestCourses();
                    break;
            }
        }

        private void SetProfile1Courses()
        {
            // Профиль 1: Иван Петров - стандартные курсы
            // Курс 1
            Course1Header.Background = new SolidColorBrush(Color.FromRgb(52, 152, 219));
            Course1Code.Text = "МАТ";
            Course1Title.Text = "Математический анализ";
            Course1Teacher.Text = "Проф. Иванов А.В.";
            Course1Progress.Value = 75;
            Course1ProgressText.Text = "75% завершено";

            // Курс 2
            Course2Header.Background = new SolidColorBrush(Color.FromRgb(39, 174, 96));
            Course2Code.Text = "ПРОГ";
            Course2Title.Text = "Программирование на C#";
            Course2Teacher.Text = "Доц. Петрова Е.С.";
            Course2Progress.Value = 90;
            Course2ProgressText.Text = "90% завершено";

            // Курс 3
            Course3Header.Background = new SolidColorBrush(Color.FromRgb(231, 76, 60));
            Course3Code.Text = "БД";
            Course3Title.Text = "Базы данных";
            Course3Teacher.Text = "Проф. Сидоров П.К.";
            Course3Progress.Value = 60;
            Course3ProgressText.Text = "60% завершено";

            // Дополнительный курс
            AdditionalCourseHeader.Background = new SolidColorBrush(Color.FromRgb(155, 89, 182));
            AdditionalCourseCode.Text = "ВЕБ";
            AdditionalCourseTitle.Text = "Веб-разработка";
            AdditionalCourseDesc.Text = "Дополнительный курс";
        }

        private void SetProfile2Courses()
        {
            // Профиль 2: Тоха 2х2 - кулинарные курсы
            // Курс 1
            Course1Header.Background = new SolidColorBrush(Color.FromRgb(230, 126, 34));
            Course1Code.Text = "КМ";
            Course1Title.Text = "Кулинарная математика";
            Course1Teacher.Text = "Шеф Поваров";
            Course1Progress.Value = 10;
            Course1ProgressText.Text = "10% завершено";

            // Курс 2
            Course2Header.Background = new SolidColorBrush(Color.FromRgb(241, 196, 15));
            Course2Code.Text = "ПМ";
            Course2Title.Text = "Программирование микроволновок";
            Course2Teacher.Text = "Инж. Техников";
            Course2Progress.Value = 5;
            Course2ProgressText.Text = "5% завершено";

            // Курс 3
            Course3Header.Background = new SolidColorBrush(Color.FromRgb(211, 84, 0));
            Course3Code.Text = "БР";
            Course3Title.Text = "Базы рецептов";
            Course3Teacher.Text = "Доц. Рецептов";
            Course3Progress.Value = 0;
            Course3ProgressText.Text = "0% завершено";

            // Дополнительный курс
            AdditionalCourseHeader.Background = new SolidColorBrush(Color.FromRgb(231, 76, 60));
            AdditionalCourseCode.Text = "КФС";
            AdditionalCourseTitle.Text = "КФС-логистика";
            AdditionalCourseDesc.Text = "Дополнительный курс";
        }

        private void SetProfile3Courses()
        {
            // Профиль 3: Папич - стримерские курсы
            // Курс 1
            Course1Header.Background = new SolidColorBrush(Color.FromRgb(155, 89, 182));
            Course1Code.Text = "МС";
            Course1Title.Text = "Математика стриминга";
            Course1Teacher.Text = "Проф. Стримов";
            Course1Progress.Value = 100;
            Course1ProgressText.Text = "100% завершено";

            // Курс 2
            Course2Header.Background = new SolidColorBrush(Color.FromRgb(142, 68, 173));
            Course2Code.Text = "ПС";
            Course2Title.Text = "Программирование стрим-ботов";
            Course2Teacher.Text = "Доц. Ботов";
            Course2Progress.Value = 100;
            Course2ProgressText.Text = "100% завершено";

            // Курс 3
            Course3Header.Background = new SolidColorBrush(Color.FromRgb(123, 36, 28));
            Course3Code.Text = "БД";
            Course3Title.Text = "Базы донатов";
            Course3Teacher.Text = "Проф. Донатеров";
            Course3Progress.Value = 100;
            Course3ProgressText.Text = "100% завершено";

            // Дополнительный курс
            AdditionalCourseHeader.Background = new SolidColorBrush(Color.FromRgb(192, 57, 43));
            AdditionalCourseCode.Text = "ИС";
            AdditionalCourseTitle.Text = "Искусство стрима";
            AdditionalCourseDesc.Text = "Дополнительный курс";
        }

        private void SetProfile4Courses()
        {
            // Профиль 4: Луффи - пиратские курсы
            // Курс 1
            Course1Header.Background = new SolidColorBrush(Color.FromRgb(41, 128, 185));
            Course1Code.Text = "НМ";
            Course1Title.Text = "Навигационная математика";
            Course1Teacher.Text = "Капитан Флинт";
            Course1Progress.Value = 80;
            Course1ProgressText.Text = "80% завершено";

            // Курс 2
            Course2Header.Background = new SolidColorBrush(Color.FromRgb(52, 152, 219));
            Course2Code.Text = "ПК";
            Course2Title.Text = "Программирование карт";
            Course2Teacher.Text = "Штурман Нами";
            Course2Progress.Value = 70;
            Course2ProgressText.Text = "70% завершено";

            // Курс 3
            Course3Header.Background = new SolidColorBrush(Color.FromRgb(230, 126, 34));
            Course3Code.Text = "БС";
            Course3Title.Text = "Базы сокровищ";
            Course3Teacher.Text = "Проф. Сокровищ";
            Course3Progress.Value = 50;
            Course3ProgressText.Text = "50% завершено";

            // Дополнительный курс
            AdditionalCourseHeader.Background = new SolidColorBrush(Color.FromRgb(231, 76, 60));
            AdditionalCourseCode.Text = "МС";
            AdditionalCourseTitle.Text = "Морские сражения";
            AdditionalCourseDesc.Text = "Дополнительный курс";
        }

        private void SetGuestCourses()
        {
            // Гость - ограниченный доступ
            // Курс 1
            Course1Header.Background = new SolidColorBrush(Color.FromRgb(149, 165, 166));
            Course1Code.Text = "???";
            Course1Title.Text = "Курс недоступен";
            Course1Teacher.Text = "Преподаватель не указан";
            Course1Progress.Value = 0;
            Course1ProgressText.Text = "0% завершено";

            // Курс 2
            Course2Header.Background = new SolidColorBrush(Color.FromRgb(149, 165, 166));
            Course2Code.Text = "???";
            Course2Title.Text = "Курс недоступен";
            Course2Teacher.Text = "Преподаватель не указан";
            Course2Progress.Value = 0;
            Course2ProgressText.Text = "0% завершено";

            // Курс 3
            Course3Header.Background = new SolidColorBrush(Color.FromRgb(149, 165, 166));
            Course3Code.Text = "???";
            Course3Title.Text = "Курс недоступен";
            Course3Teacher.Text = "Преподаватель не указан";
            Course3Progress.Value = 0;
            Course3ProgressText.Text = "0% завершено";

            // Дополнительный курс
            AdditionalCourseHeader.Background = new SolidColorBrush(Color.FromRgb(149, 165, 166));
            AdditionalCourseCode.Text = "???";
            AdditionalCourseTitle.Text = "Курс недоступен";
            AdditionalCourseDesc.Text = "Требуется авторизация";

            // Скрываем кнопку записи для гостя
            UnenrolledState.Visibility = Visibility.Collapsed;
            EnrolledState.Visibility = Visibility.Collapsed;
        }

        // Обработчик кнопки записи (остается без изменений)
        private void EnrollButton_Click(object sender, RoutedEventArgs e)
        {
            

            // Скрываем кнопку
            UnenrolledState.Visibility = Visibility.Collapsed;
            EnrolledState.Visibility = Visibility.Visible;

            // Запускаем имитацию скачивания
            
        }

        
    }
}