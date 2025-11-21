using System;
using System.Collections.Generic;
using System.Linq;

namespace PR8_1_
{
    // Класс для представления одного сообщения
    public class ChatMessage
    {
        public string Text { get; set; }
        public string Time { get; set; }
        public bool IsIncoming { get; set; }
        public bool IsFile { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
    }

    // Класс для представления чата
    public class Chat
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Avatar { get; set; }
        public string Color { get; set; }
        public string LastMessagePreview { get; set; }
        public string LastMessageTime { get; set; }
        public List<ChatMessage> Messages { get; set; } = new List<ChatMessage>();
    }

    // Статический класс для хранения всех чатов всех профилей
    public static class ChatManager
    {
        private static Dictionary<int, List<Chat>> _profileChats = new Dictionary<int, List<Chat>>();

        static ChatManager()
        {
            InitializeProfileChats();
        }

        public static List<Chat> GetChatsForProfile(int profileId)
        {
            if (_profileChats.ContainsKey(profileId))
            {
                return _profileChats[profileId];
            }
            return _profileChats[0]; // Возвращаем гостевые чаты по умолчанию
        }

        public static void AddMessageToChat(int profileId, string chatId, ChatMessage message)
        {
            var chats = GetChatsForProfile(profileId);
            var chat = chats.FirstOrDefault(c => c.Id == chatId);
            if (chat != null)
            {
                chat.Messages.Add(message);
                chat.LastMessagePreview = message.Text;
                chat.LastMessageTime = DateTime.Now.ToString("HH:mm");
            }
        }

        private static void InitializeProfileChats()
        {
            // Чат для гостя (профиль 0)
            _profileChats[0] = new List<Chat>
            {
                new Chat
                {
                    Id = "guest1",
                    Title = "Не доступно",
                    Subtitle = "Требуется авторизация",
                    Avatar = "?",
                    Color = "#95A5A6",
                    LastMessagePreview = "Не доступно",
                    LastMessageTime = "--:--",
                    Messages = new List<ChatMessage>
                    {
                        new ChatMessage { Text = "Чат недоступен для гостевого доступа", Time = "--:--", IsIncoming = true }
                    }
                }
            };

            // Чат для профиля 1 (Иван Петров)
            _profileChats[1] = new List<Chat>
            {
                new Chat
                {
                    Id = "chat1",
                    Title = "Проф. Иванов А.В.",
                    Subtitle = "Математический анализ",
                    Avatar = "ИИ",
                    Color = "#3498DB",
                    LastMessagePreview = "Жду ваше домашнее задание...",
                    LastMessageTime = "10:25",
                    Messages = new List<ChatMessage>
                    {
                        new ChatMessage { Text = "Добрый день! Жду ваше домашнее задание до конца недели.", Time = "10:25", IsIncoming = true },
                        new ChatMessage { Text = "Добрый день, Александр Владимирович! Отправляю задание во вложении.", Time = "10:30", IsIncoming = false },
                        new ChatMessage { Text = "ДЗ_Математика_Петров.pdf", Time = "10:30", IsIncoming = true, IsFile = true, FileName = "ДЗ_Математика_Петров.pdf", FileSize = "2.1 MB" },
                        new ChatMessage { Text = "Спасибо, получил. Проверю и выставлю оценку до пятницы.", Time = "10:35", IsIncoming = true }
                    }
                },
                new Chat
                {
                    Id = "chat2",
                    Title = "Доц. Петрова Е.С.",
                    Subtitle = "Программирование на C#",
                    Avatar = "ПЕ",
                    Color = "#27AE60",
                    LastMessagePreview = "Отличная работа на практике!",
                    LastMessageTime = "Вчера",
                    Messages = new List<ChatMessage>
                    {
                        new ChatMessage { Text = "Отличная работа на практике! Ваш код очень чистый и хорошо структурированный.", Time = "Вчера", IsIncoming = true },
                        new ChatMessage { Text = "Спасибо большое, Елена Сергеевна! Старался следовать best practices.", Time = "Вчера", IsIncoming = false },
                        new ChatMessage { Text = "Приходите завтра на консультацию, обсудим ваш проект.", Time = "Вчера", IsIncoming = true }
                    }
                },
                new Chat
                {
                    Id = "chat3",
                    Title = "Группа ИВТ-21",
                    Subtitle = "Общий чат группы",
                    Avatar = "ГР",
                    Color = "#E74C3C",
                    LastMessagePreview = "Мария: Кто идет на пары?",
                    LastMessageTime = "2 дн. назад",
                    Messages = new List<ChatMessage>
                    {
                        new ChatMessage { Text = "Мария: Кто идет на пары?", Time = "2 дн. назад", IsIncoming = true },
                        new ChatMessage { Text = "Алексей: Я буду, жду лекцию по математике", Time = "2 дн. назад", IsIncoming = true },
                        new ChatMessage { Text = "Дмитрий: +1", Time = "2 дн. назад", IsIncoming = true },
                        new ChatMessage { Text = "Я тоже буду, встретимся перед аудиторией?", Time = "2 дн. назад", IsIncoming = false },
                        new ChatMessage { Text = "Мария: Отлично! Встречаемся в 9:30 у 301 аудитории", Time = "2 дн. назад", IsIncoming = true }
                    }
                }
            };

            // Чат для профиля 2 (Тоха 2х2)
            _profileChats[2] = new List<Chat>
            {
                new Chat
                {
                    Id = "chat1",
                    Title = "Шеф Поваров",
                    Subtitle = "Кулинарная математика",
                    Avatar = "ШП",
                    Color = "#E67E22",
                    LastMessagePreview = "Где твои рецепты?",
                    LastMessageTime = "11:20",
                    Messages = new List<ChatMessage>
                    {
                        new ChatMessage { Text = "Тоха, где твои рецепты? Уже неделя прошла!", Time = "11:20", IsIncoming = true },
                        new ChatMessage { Text = "Шеф, я все съел...", Time = "11:25", IsIncoming = false },
                        new ChatMessage { Text = "Опять? Приходи завтра, дам новые задания.", Time = "11:30", IsIncoming = true }
                    }
                },
                new Chat
                {
                    Id = "chat2",
                    Title = "Менеджер КФС",
                    Subtitle = "Стажировка в KFC",
                    Avatar = "КФ",
                    Color = "#D35400",
                    LastMessagePreview = "Завтра дегустация новых наггетсов",
                    LastMessageTime = "09:15",
                    Messages = new List<ChatMessage>
                    {
                        new ChatMessage { Text = "Тоха, завтра дегустация новых наггетсов. Будешь?", Time = "09:15", IsIncoming = true },
                        new ChatMessage { Text = "Конечно! Я уже предвкушаю...", Time = "09:20", IsIncoming = false },
                        new ChatMessage { Text = "Приходи к 10 утра, не опаздывай!", Time = "09:25", IsIncoming = true }
                    }
                },
                new Chat
                {
                    Id = "chat3",
                    Title = "Друзья по КФС",
                    Subtitle = "Общество ценителей",
                    Avatar = "ДР",
                    Color = "#F39C12",
                    LastMessagePreview = "Сегодня в KFC акция!",
                    LastMessageTime = "Вчера",
                    Messages = new List<ChatMessage>
                    {
                        new ChatMessage { Text = "Ребята, сегодня в KFC акция - два наггетса по цене одного!", Time = "Вчера", IsIncoming = true },
                        new ChatMessage { Text = "Уже бегу! Кто со мной?", Time = "Вчера", IsIncoming = false },
                        new ChatMessage { Text = "Я уже в очереди, народу много!", Time = "Вчера", IsIncoming = true },
                        new ChatMessage { Text = "Держите мне место!", Time = "Вчера", IsIncoming = false }
                    }
                }
            };

            // Чат для профиля 3 (Папич)
            _profileChats[3] = new List<Chat>
            {
                new Chat
                {
                    Id = "chat1",
                    Title = "Модераторы",
                    Subtitle = "Управление стримом",
                    Avatar = "МД",
                    Color = "#9B59B6",
                    LastMessagePreview = "Готовим новый стрим",
                    LastMessageTime = "15:30",
                    Messages = new List<ChatMessage>
                    {
                        new ChatMessage { Text = "Папич, готовим новый стрим на завтра. Какая тема?", Time = "15:30", IsIncoming = true },
                        new ChatMessage { Text = "Давайте по новой игре, которую вчера получил.", Time = "15:35", IsIncoming = false },
                        new ChatMessage { Text = "Ок, готовим анонсы. Начало в 20:00?", Time = "15:40", IsIncoming = true },
                        new ChatMessage { Text = "Да, в 20:00. Не забудьте про донаты!", Time = "15:45", IsIncoming = false }
                    }
                },
                new Chat
                {
                    Id = "chat2",
                    Title = "Спонсоры",
                    Subtitle = "Рекламные интеграции",
                    Avatar = "СП",
                    Color = "#8E44AD",
                    LastMessagePreview = "Новое рекламное предложение",
                    LastMessageTime = "12:10",
                    Messages = new List<ChatMessage>
                    {
                        new ChatMessage { Text = "Есть новое рекламное предложение от энергетиков.", Time = "12:10", IsIncoming = true },
                        new ChatMessage { Text = "Интересует. Какие условия?", Time = "12:15", IsIncoming = false },
                        new ChatMessage { Text = "3 упоминания в стримах за месяц. Бюджет хороший.", Time = "12:20", IsIncoming = true }
                    }
                },
                new Chat
                {
                    Id = "chat3",
                    Title = "Зрители",
                    Subtitle = "Обратная связь",
                    Avatar = "ЗР",
                    Color = "#2980B9",
                    LastMessagePreview = "Когда следующий стрим?",
                    LastMessageTime = "10:45",
                    Messages = new List<ChatMessage>
                    {
                        new ChatMessage { Text = "Папич, когда следующий стрим? Соскучились!", Time = "10:45", IsIncoming = true },
                        new ChatMessage { Text = "Завтра в 20:00 будет новый стрим!", Time = "10:50", IsIncoming = false },
                        new ChatMessage { Text = "Ура! Ждем с нетерпением!", Time = "10:55", IsIncoming = true },
                        new ChatMessage { Text = "Приготовьте донаты!)", Time = "11:00", IsIncoming = false }
                    }
                }
            };

            // Чат для профиля 4 (Луффи)
            _profileChats[4] = new List<Chat>
            {
                new Chat
                {
                    Id = "chat1",
                    Title = "Зоро",
                    Subtitle = "Первый мечник",
                    Avatar = "ЗО",
                    Color = "#27AE60",
                    LastMessagePreview = "Нужна тренировка",
                    LastMessageTime = "08:30",
                    Messages = new List<ChatMessage>
                    {
                        new ChatMessage { Text = "Капитан, сегодня тренировка в 10 утра. Не проспи!", Time = "08:30", IsIncoming = true },
                        new ChatMessage { Text = "Мясо! Я уже проснулся и готов к тренировке!", Time = "08:35", IsIncoming = false },
                        new ChatMessage { Text = "Тогда встречаемся на палубе. Принесу мечи.", Time = "08:40", IsIncoming = true }
                    }
                },
                new Chat
                {
                    Id = "chat2",
                    Title = "Нами",
                    Subtitle = "Штурман",
                    Avatar = "НА",
                    Color = "#3498DB",
                    LastMessagePreview = "Новый маршрут к сокровищам",
                    LastMessageTime = "14:20",
                    Messages = new List<ChatMessage>
                    {
                        new ChatMessage { Text = "Луффи, я нашла новый маршрут к сокровищам!", Time = "14:20", IsIncoming = true },
                        new ChatMessage { Text = "Отлично! Плывем туда немедленно!", Time = "14:25", IsIncoming = false },
                        new ChatMessage { Text = "Но там опасно - говорят, морские чудовища.", Time = "14:30", IsIncoming = true },
                        new ChatMessage { Text = "Еще лучше! Новые приключения!", Time = "14:35", IsIncoming = false }
                    }
                },
                new Chat
                {
                    Id = "chat3",
                    Title = "Санджи",
                    Subtitle = "Кок",
                    Avatar = "СА",
                    Color = "#E74C3C",
                    LastMessagePreview = "Что приготовить на обед?",
                    LastMessageTime = "12:00",
                    Messages = new List<ChatMessage>
                    {
                        new ChatMessage { Text = "Капитан, что приготовить на обед? Мясо как обычно?", Time = "12:00", IsIncoming = true },
                        new ChatMessage { Text = "Да! Много мяса! И не забудь про десерт!", Time = "12:05", IsIncoming = false },
                        new ChatMessage { Text = "Хорошо, будет твоя любимая гигантская нога динозавра.", Time = "12:10", IsIncoming = true },
                        new ChatMessage { Text = "Уже текут слюнки! Спасибо, Санджи!", Time = "12:15", IsIncoming = false }
                    }
                }
            };
        }
    }
}