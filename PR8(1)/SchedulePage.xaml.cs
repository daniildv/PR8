using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PR8_1_
{
    public partial class SchedulePage : Page
    {
        public SchedulePage()
        {
            InitializeComponent();

            // Получаем текущий профиль из настроек приложения
            int currentProfile = Properties.Settings.Default.CurrentProfile;
            SetScheduleData(currentProfile);
        }

        private void SetScheduleData(int profile)
        {
            switch (profile)
            {
                case 1:
                    SetProfile1Schedule();
                    break;
                case 2:
                    SetProfile2Schedule();
                    break;
                case 3:
                    SetProfile3Schedule();
                    break;
                case 4:
                    SetProfile4Schedule();
                    break;
                default:
                    SetGuestSchedule();
                    break;
            }
        }

        private void SetProfile1Schedule()
        {
            // Профиль 1: Иван Петров - стандартное расписание студента
            ScheduleTitle.Text = "📅 Расписание занятий - ИВТ-21";

            // Понедельник
            MondayTitle.Text = "Понедельник, 12 декабря";
            AddLessonToDay(MondayLessons, "10:00-11:30", "Математический анализ", "Ауд. 301", "Проф. Иванов");
            AddLessonToDay(MondayLessons, "12:00-13:30", "Программирование", "Комп. класс 2", "Доц. Петрова");
            AddLessonToDay(MondayLessons, "14:00-15:30", "Базы данных", "Ауд. 215", "Проф. Сидоров");

            // Вторник
            TuesdayTitle.Text = "Вторник, 13 декабря";
            AddLessonToDay(TuesdayLessons, "09:00-10:30", "Веб-разработка", "Комп. класс 1", "Доц. Смирнов");
            AddLessonToDay(TuesdayLessons, "11:00-12:30", "Иностранный язык", "Ауд. 105", "Преп. Джонсон");

            // Среда
            WednesdayTitle.Text = "Среда, 14 декабря";
            AddLessonToDay(WednesdayLessons, "10:00-11:30", "Математический анализ", "Ауд. 301", "Проф. Иванов");
            AddLessonToDay(WednesdayLessons, "13:00-14:30", "Физкультура", "Спортзал", "Преп. Сидоров");

            // Четверг
            ThursdayTitle.Text = "Четверг, 15 декабря";
            AddLessonToDay(ThursdayLessons, "09:00-10:30", "Программирование", "Комп. класс 2", "Доц. Петрова");
            AddLessonToDay(ThursdayLessons, "11:00-12:30", "Базы данных", "Ауд. 215", "Проф. Сидоров");

            // Пятница
            FridayTitle.Text = "Пятница, 16 декабря";
            AddLessonToDay(FridayLessons, "10:00-11:30", "Веб-разработка", "Комп. класс 1", "Доц. Смирнов");
            AddLessonToDay(FridayLessons, "12:00-13:30", "Проектная деятельность", "Ауд. 410", "Доц. Петрова");

            // Суббота
            SaturdayTitle.Text = "Суббота, 17 декабря";
            AddLessonToDay(SaturdayLessons, "09:00-10:30", "Элективный курс", "Ауд. 205", "Доц. Козлов");

            // Экзамены
            ExamsTitle.Text = "📝 Ближайшие экзамены";
            AddExam("20 декабря, 10:00", "Экзамен по математике", "Ауд. 401", "Проф. Иванов");
            AddExam("25 декабря, 14:00", "Экзамен по программированию", "Комп. класс 2", "Доц. Петрова");
        }

        private void SetProfile2Schedule()
        {
            // Профиль 2: Тоха 2х2 - нерегулярное расписание
            ScheduleTitle.Text = "📅 Расписание занятий - 6ИСтрипс22п";

            // Понедельник
            MondayTitle.Text = "Понедельник, 12 декабря";
            AddLessonToDay(MondayLessons, "11:00-12:30", "Кулинарная математика", "Кухня 1", "Шеф Поваров");
            AddLessonToDay(MondayLessons, "14:00-15:30", "Дегустация КФС", "Ресторан", "Менеджер КФС");

            // Вторник
            TuesdayTitle.Text = "Вторник, 13 декабря";
            AddLessonToDay(TuesdayLessons, "12:00-13:00", "Перерыв на обед", "Столовая", "-");

            // Среда
            WednesdayTitle.Text = "Среда, 14 декабря";
            AddLessonToDay(WednesdayLessons, "15:00-16:30", "Программирование микроволновок", "Лаб. 3", "Инж. Техников");

            // Четверг
            ThursdayTitle.Text = "Четверг, 15 декабря";
            AddLessonToDay(ThursdayLessons, "10:00-11:30", "Базы рецептов", "Комп. класс", "Доц. Рецептов");

            // Пятница
            FridayTitle.Text = "Пятница, 16 декабря";
            AddLessonToDay(FridayLessons, "13:00-14:30", "Практика в KFC", "KFC Центральный", "Менеджер");

            // Суббота
            SaturdayTitle.Text = "Суббота, 17 декабря";
            AddLessonToDay(SaturdayLessons, "16:00-17:30", "Вечерняя дегустация", "Ресторан", "Шеф");

            // Экзамены
            ExamsTitle.Text = "📝 Ближайшие зачеты";
            AddExam("22 декабря, 12:00", "Зачет по кулинарии", "Кухня 1", "Шеф Поваров");
            AddExam("28 декабря, 15:00", "Зачет по КФС-логистике", "Офис KFC", "Менеджер");
        }

        private void SetProfile3Schedule()
        {
            // Профиль 3: Папич - стримерское расписание
            ScheduleTitle.Text = "📅 Расписание стримов";

            // Понедельник
            MondayTitle.Text = "Понедельник, 12 декабря";
            AddLessonToDay(MondayLessons, "19:00-22:00", "Стрим: Игры", "Домашняя студия", "Зрители");
            AddLessonToDay(MondayLessons, "22:00-23:00", "Разбор донатов", "Онлайн", "Модераторы");

            // Вторник
            TuesdayTitle.Text = "Вторник, 13 декабря";
            AddLessonToDay(TuesdayLessons, "18:00-21:00", "Стрим: Обсуждение новостей", "Домашняя студия", "Зрители");

            // Среда
            WednesdayTitle.Text = "Среда, 14 декабря";
            AddLessonToDay(WednesdayLessons, "20:00-24:00", "Марафонский стрим", "Домашняя студия", "Все желающие");

            // Четверг
            ThursdayTitle.Text = "Четверг, 15 декабря";
            AddLessonToDay(ThursdayLessons, "17:00-19:00", "Подготовка к стриму", "Домашняя студия", "Команда");
            AddLessonToDay(ThursdayLessons, "19:00-22:00", "Стрим: Новая игра", "Домашняя студия", "Зрители");

            // Пятница
            FridayTitle.Text = "Пятница, 16 декабря";
            AddLessonToDay(FridayLessons, "15:00-17:00", "Работа с контентом", "Домашняя студия", "Редакторы");
            AddLessonToDay(FridayLessons, "19:00-23:00", "Пятничный стрим", "Домашняя студия", "Зрители");

            // Суббота
            SaturdayTitle.Text = "Суббота, 17 декабря";
            AddLessonToDay(SaturdayLessons, "14:00-18:00", "Субботний стрим", "Домашняя студия", "Зрители");
            AddLessonToDay(SaturdayLessons, "20:00-22:00", "Общение с подписчиками", "Онлайн", "Сообщество");

            // Экзамены
            ExamsTitle.Text = "📝 Ближайшие события";
            AddExam("20 декабря, 20:00", "Специальный стрим", "Домашняя студия", "Гости");
            AddExam("25 декабря, 19:00", "Рождественский стрим", "Домашняя студия", "Все");
        }

        private void SetProfile4Schedule()
        {
            // Профиль 4: Луффи - пиратское расписание
            ScheduleTitle.Text = "📅 Расписание плаваний";

            // Понедельник
            MondayTitle.Text = "Понедельник, 12 декабря";
            AddLessonToDay(MondayLessons, "08:00-10:00", "Навигация по картам", "Палуба", "Нами");
            AddLessonToDay(MondayLessons, "11:00-13:00", "Фехтование", "Палуба", "Зоро");
            AddLessonToDay(MondayLessons, "15:00-17:00", "Поиск сокровищ", "Остров", "Экипаж");

            // Вторник
            TuesdayTitle.Text = "Вторник, 13 декабря";
            AddLessonToDay(TuesdayLessons, "09:00-11:00", "Ремонт корабля", "Верфь", "Франки");
            AddLessonToDay(TuesdayLessons, "14:00-16:00", "Кулинария", "Камбуз", "Санджи");

            // Среда
            WednesdayTitle.Text = "Среда, 14 декабря";
            AddLessonToDay(WednesdayLessons, "10:00-12:00", "Морская битва", "Открытое море", "Экипаж");
            AddLessonToDay(WednesdayLessons, "16:00-18:00", "Изучение легенд", "Библиотека", "Робин");

            // Четверг
            ThursdayTitle.Text = "Четверг, 15 декабря";
            AddLessonToDay(ThursdayLessons, "08:00-10:00", "Тренировка силы", "Палуба", "Зоро");
            AddLessonToDay(ThursdayLessons, "13:00-15:00", "Медицина", "Лазарет", "Чоппер");

            // Пятница
            FridayTitle.Text = "Пятница, 16 декабря";
            AddLessonToDay(FridayLessons, "11:00-13:00", "Переговоры", "Каюта капитана", "Луффи");
            AddLessonToDay(FridayLessons, "15:00-17:00", "Планирование маршрута", "Штурманская", "Нами");

            // Суббота
            SaturdayTitle.Text = "Суббота, 17 декабря";
            AddLessonToDay(SaturdayLessons, "12:00-14:00", "Отдых и веселье", "Палуба", "Весь экипаж");
            AddLessonToDay(SaturdayLessons, "18:00-20:00", "Пиратский пир", "Камбуз", "Санджи");

            // Экзамены
            ExamsTitle.Text = "📝 Ближайшие цели";
            AddExam("20 декабря, 08:00", "Штурм морской базы", "База Морских", "Адмирал");
            AddExam("25 декабря, 12:00", "Поиск Ван-Пис", "Гранд-Лайн", "Роджер");
        }

        private void SetGuestSchedule()
        {
            // Гость - ограниченный доступ
            ScheduleTitle.Text = "📅 Расписание (ограниченный доступ)";

            // Понедельник
            MondayTitle.Text = "Понедельник";
            AddLessonToDay(MondayLessons, "--:--", "Не доступно", "Не доступно", "Не доступно");

            // Вторник
            TuesdayTitle.Text = "Вторник";
            AddLessonToDay(TuesdayLessons, "--:--", "Не доступно", "Не доступно", "Не доступно");

            // Среда
            WednesdayTitle.Text = "Среда";
            AddLessonToDay(WednesdayLessons, "--:--", "Не доступно", "Не доступно", "Не доступно");

            // Четверг
            ThursdayTitle.Text = "Четверг";
            AddLessonToDay(ThursdayLessons, "--:--", "Не доступно", "Не доступно", "Не доступно");

            // Пятница
            FridayTitle.Text = "Пятница";
            AddLessonToDay(FridayLessons, "--:--", "Не доступно", "Не доступно", "Не доступно");

            // Суббота
            SaturdayTitle.Text = "Суббота";
            AddLessonToDay(SaturdayLessons, "--:--", "Не доступно", "Не доступно", "Не доступно");

            // Экзамены
            ExamsTitle.Text = "📝 Экзамены";
            AddExam("--", "Не доступно", "Не доступно", "Не доступно");
        }

        private void AddLessonToDay(StackPanel dayPanel, string time, string subject, string room, string teacher)
        {
            var grid = new Grid();
            grid.Margin = new Thickness(0, 0, 0, 10);

            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(150) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });

            var timeText = new TextBlock
            {
                Text = time,
                FontWeight = FontWeights.SemiBold,
                VerticalAlignment = VerticalAlignment.Center
            };

            var subjectText = new TextBlock
            {
                Text = subject,
                FontWeight = FontWeights.SemiBold,
                VerticalAlignment = VerticalAlignment.Center
            };

            var roomText = new TextBlock
            {
                Text = room,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = Brushes.Gray
            };

            var teacherText = new TextBlock
            {
                Text = teacher,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = Brushes.Gray
            };

            Grid.SetColumn(timeText, 0);
            Grid.SetColumn(subjectText, 1);
            Grid.SetColumn(roomText, 2);
            Grid.SetColumn(teacherText, 3);

            grid.Children.Add(timeText);
            grid.Children.Add(subjectText);
            grid.Children.Add(roomText);
            grid.Children.Add(teacherText);

            dayPanel.Children.Add(grid);

            // Добавляем разделитель, если это не последний элемент
            if (dayPanel.Children.Count > 1)
            {
                var separator = new Rectangle
                {
                    Height = 1,
                    Fill = new SolidColorBrush(Color.FromRgb(238, 238, 238)),
                    Margin = new Thickness(0, 10, 0, 10)
                };
                dayPanel.Children.Add(separator);
            }
        }

        private void AddExam(string date, string subject, string room, string teacher)
        {
            var grid = new Grid();
            grid.Margin = new Thickness(0, 0, 0, 10);

            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(120) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(150) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });

            var dateText = new TextBlock
            {
                Text = date,
                FontWeight = FontWeights.SemiBold,
                VerticalAlignment = VerticalAlignment.Center
            };

            var subjectText = new TextBlock
            {
                Text = subject,
                FontWeight = FontWeights.SemiBold,
                VerticalAlignment = VerticalAlignment.Center
            };

            var roomText = new TextBlock
            {
                Text = room,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = Brushes.Gray
            };

            var teacherText = new TextBlock
            {
                Text = teacher,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = Brushes.Gray
            };

            Grid.SetColumn(dateText, 0);
            Grid.SetColumn(subjectText, 1);
            Grid.SetColumn(roomText, 2);
            Grid.SetColumn(teacherText, 3);

            grid.Children.Add(dateText);
            grid.Children.Add(subjectText);
            grid.Children.Add(roomText);
            grid.Children.Add(teacherText);

            ExamsList.Children.Add(grid);

            // Добавляем разделитель, если это не последний элемент
            if (ExamsList.Children.Count > 1)
            {
                var separator = new Rectangle
                {
                    Height = 1,
                    Fill = new SolidColorBrush(Color.FromRgb(255, 193, 7)),
                    Margin = new Thickness(0, 10, 0, 10)
                };
                ExamsList.Children.Add(separator);
            }
        }
    }
}