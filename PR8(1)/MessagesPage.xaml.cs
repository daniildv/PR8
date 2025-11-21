using PR8_1_;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace PR8_1_
{
    public partial class MessagesPage : Page
    {
        private int _currentProfile;
        private string _currentChatId;
        private DispatcherTimer _typingTimer;

        public MessagesPage()
        {
            InitializeComponent();

            // Получаем текущий профиль
            _currentProfile = Properties.Settings.Default.CurrentProfile;

            InitializeTypingTimer();
            InitializeChatList();

            // Подписываемся на событие загрузки страницы
            this.Loaded += MessagesPage_Loaded;
            this.Unloaded += MessagesPage_Unloaded;
        }

        private void MessagesPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Активируем первый чат
            if (Chat1Border.Visibility == Visibility.Visible)
            {
                SwitchChat("chat1");
            }

            // Устанавливаем фокус на поле ввода после загрузки страницы
            MessageTextBox.Focus();
        }

        private void InitializeTypingTimer()
        {
            _typingTimer = new DispatcherTimer();
            _typingTimer.Interval = TimeSpan.FromMilliseconds(100);
            _typingTimer.Tick += TypingTimer_Tick;
        }

        private void TypingTimer_Tick(object sender, EventArgs e)
        {
            // Автопрокрутка к последнему сообщению
            MessagesScrollViewer.ScrollToEnd();
            _typingTimer.Stop(); // Останавливаем таймер после прокрутки
        }

        private void InitializeChatList()
        {
            var chats = ChatManager.GetChatsForProfile(_currentProfile);

            // Показываем/скрываем чаты в зависимости от их наличия
            Chat1Border.Visibility = chats.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
            Chat2Border.Visibility = chats.Count > 1 ? Visibility.Visible : Visibility.Collapsed;
            Chat3Border.Visibility = chats.Count > 2 ? Visibility.Visible : Visibility.Collapsed;

            // Заполняем превью чатов
            if (chats.Count > 0)
            {
                var chat1 = chats[0];
                Chat1Preview.Text = chat1.LastMessagePreview;
                // Обновляем аватар и имя в превью чата 1
                UpdateChatPreview(Chat1Border, chat1);
            }

            if (chats.Count > 1)
            {
                var chat2 = chats[1];
                Chat2Preview.Text = chat2.LastMessagePreview;
                // Обновляем аватар и имя в превью чата 2
                UpdateChatPreview(Chat2Border, chat2);
            }

            if (chats.Count > 2)
            {
                var chat3 = chats[2];
                Chat3Preview.Text = chat3.LastMessagePreview;
                // Обновляем аватар и имя в превью чата 3
                UpdateChatPreview(Chat3Border, chat3);
            }
        }

        private void UpdateChatPreview(Border chatBorder, Chat chat)
        {
            // Находим элементы внутри шаблона чата
            var grid = chatBorder.Child as Grid;
            if (grid == null) return;

            // Первый элемент Grid - Border (аватар)
            var avatarBorder = grid.Children[0] as Border;
            if (avatarBorder != null)
            {
                avatarBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(chat.Color));

                // Текст внутри аватара
                var avatarText = avatarBorder.Child as TextBlock;
                if (avatarText != null)
                {
                    avatarText.Text = chat.Avatar;
                }
            }

            // Второй элемент Grid - StackPanel с информацией о чате
            var infoPanel = grid.Children[1] as StackPanel;
            if (infoPanel != null)
            {
                // Первый TextBlock в StackPanel - название чата
                var titleText = infoPanel.Children[0] as TextBlock;
                if (titleText != null)
                {
                    titleText.Text = chat.Title;
                }
            }
        }

        // Обработчики переключения чатов
        private void Chat1Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SwitchChat("chat1");
        }

        private void Chat2Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SwitchChat("chat2");
        }

        private void Chat3Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SwitchChat("chat3");
        }

        private void SwitchChat(string chatId)
        {
            _currentChatId = chatId;
            var chats = ChatManager.GetChatsForProfile(_currentProfile);
            var chat = chats.FirstOrDefault(c => c.Id == chatId);

            if (chat == null) return;

            // Сбрасываем выделение всех чатов
            ResetChatSelection();

            // Устанавливаем выделение активного чата
            switch (chatId)
            {
                case "chat1":
                    Chat1Border.Background = new SolidColorBrush(Color.FromRgb(232, 244, 253));
                    Chat1Border.BorderThickness = new Thickness(2);
                    Chat1Border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(chat.Color));
                    break;
                case "chat2":
                    Chat2Border.Background = new SolidColorBrush(Color.FromRgb(232, 246, 243));
                    Chat2Border.BorderThickness = new Thickness(2);
                    Chat2Border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(chat.Color));
                    break;
                case "chat3":
                    Chat3Border.Background = new SolidColorBrush(Color.FromRgb(253, 237, 237));
                    Chat3Border.BorderThickness = new Thickness(2);
                    Chat3Border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(chat.Color));
                    break;
            }

            SetChatContent(chat.Title, chat.Subtitle, chat.Avatar, chat.Color);
            LoadChatMessages(chat);

            // Фокусируемся на поле ввода
            MessageTextBox.Focus();
        }

        private void ResetChatSelection()
        {
            // Сбрасываем стили всех чатов
            Chat1Border.Background = Brushes.White;
            Chat1Border.BorderThickness = new Thickness(0);

            Chat2Border.Background = Brushes.White;
            Chat2Border.BorderThickness = new Thickness(0);

            Chat3Border.Background = Brushes.White;
            Chat3Border.BorderThickness = new Thickness(0);
        }

        private void SetChatContent(string title, string subtitle, string avatar, string color)
        {
            ChatTitleText.Text = title;
            ChatSubtitleText.Text = subtitle;
            ChatAvatarText.Text = avatar;

            Color bgColor = (Color)ColorConverter.ConvertFromString(color);
            ChatAvatarBorder.Background = new SolidColorBrush(bgColor);
            ChatHeaderBorder.Background = new SolidColorBrush(Color.FromArgb(50, bgColor.R, bgColor.G, bgColor.B));
        }

        private void LoadChatMessages(Chat chat)
        {
            MessagesPanel.Children.Clear();

            foreach (var message in chat.Messages)
            {
                if (message.IsFile)
                {
                    AddFileMessage(message.FileName, message.FileSize, message.Time);
                }
                else if (message.IsIncoming)
                {
                    AddIncomingMessage(message.Text, message.Time);
                }
                else
                {
                    AddOutgoingMessage(message.Text, message.Time);
                }
            }

            // Прокручиваем к последнему сообщению
            ScrollToBottom();
        }

        private void AddIncomingMessage(string text, string time)
        {
            var messageBorder = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(232, 244, 253)),
                CornerRadius = new CornerRadius(10),
                Padding = new Thickness(15),
                Margin = new Thickness(0, 0, 100, 10),
                HorizontalAlignment = HorizontalAlignment.Left
            };

            var stackPanel = new StackPanel();

            var messageText = new TextBlock
            {
                Text = text,
                TextWrapping = TextWrapping.Wrap,
                FontSize = 14
            };

            var timeText = new TextBlock
            {
                Text = time,
                FontSize = 11,
                Foreground = new SolidColorBrush(Color.FromRgb(102, 102, 102)),
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(0, 5, 0, 0)
            };

            stackPanel.Children.Add(messageText);
            stackPanel.Children.Add(timeText);
            messageBorder.Child = stackPanel;

            MessagesPanel.Children.Add(messageBorder);
        }

        private void AddOutgoingMessage(string text, string time)
        {
            var messageBorder = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(52, 152, 219)),
                CornerRadius = new CornerRadius(10),
                Padding = new Thickness(15),
                Margin = new Thickness(100, 0, 0, 10),
                HorizontalAlignment = HorizontalAlignment.Right
            };

            var stackPanel = new StackPanel();

            var messageText = new TextBlock
            {
                Text = text,
                TextWrapping = TextWrapping.Wrap,
                FontSize = 14,
                Foreground = Brushes.White
            };

            var timeText = new TextBlock
            {
                Text = time,
                FontSize = 11,
                Foreground = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(0, 5, 0, 0)
            };

            stackPanel.Children.Add(messageText);
            stackPanel.Children.Add(timeText);
            messageBorder.Child = stackPanel;

            MessagesPanel.Children.Add(messageBorder);
        }

        private void AddFileMessage(string fileName, string fileSize, string time)
        {
            var messageBorder = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(232, 244, 253)),
                CornerRadius = new CornerRadius(10),
                Padding = new Thickness(15),
                Margin = new Thickness(0, 0, 100, 10),
                HorizontalAlignment = HorizontalAlignment.Left
            };

            var stackPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };

            var fileIcon = new TextBlock
            {
                Text = "📎",
                FontSize = 16,
                Margin = new Thickness(0, 0, 10, 0),
                VerticalAlignment = VerticalAlignment.Center
            };

            var fileInfoPanel = new StackPanel();

            var fileNameText = new TextBlock
            {
                Text = fileName,
                FontWeight = FontWeights.SemiBold,
                FontSize = 14
            };

            var fileSizeText = new TextBlock
            {
                Text = fileSize,
                FontSize = 11,
                Foreground = new SolidColorBrush(Color.FromRgb(102, 102, 102))
            };

            fileInfoPanel.Children.Add(fileNameText);
            fileInfoPanel.Children.Add(fileSizeText);

            stackPanel.Children.Add(fileIcon);
            stackPanel.Children.Add(fileInfoPanel);
            messageBorder.Child = stackPanel;

            MessagesPanel.Children.Add(messageBorder);
        }

        // Обработчики отправки сообщений
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        private void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Keyboard.Modifiers != ModifierKeys.Shift)
            {
                SendMessage();
                e.Handled = true;
            }
        }

        private void SendMessage()
        {
            string messageText = MessageTextBox.Text.Trim();

            if (string.IsNullOrEmpty(messageText) || messageText == "Введите сообщение...")
                return;

            // Создаем новое сообщение
            var newMessage = new ChatMessage
            {
                Text = messageText,
                Time = DateTime.Now.ToString("HH:mm"),
                IsIncoming = false
            };

            // Добавляем сообщение в текущий чат
            ChatManager.AddMessageToChat(_currentProfile, _currentChatId, newMessage);

            // Добавляем исходящее сообщение в UI
            AddOutgoingMessage(messageText, newMessage.Time);

            // Очищаем поле ввода
            MessageTextBox.Text = "";

            // Обновляем превью чата
            UpdateChatPreview();

            // Прокручиваем к последнему сообщению
            ScrollToBottom();
        }

        private void UpdateChatPreview()
        {
            var chats = ChatManager.GetChatsForProfile(_currentProfile);
            var currentChat = chats.FirstOrDefault(c => c.Id == _currentChatId);

            if (currentChat != null)
            {
                switch (_currentChatId)
                {
                    case "chat1":
                        Chat1Preview.Text = currentChat.LastMessagePreview;
                        break;
                    case "chat2":
                        Chat2Preview.Text = currentChat.LastMessagePreview;
                        break;
                    case "chat3":
                        Chat3Preview.Text = currentChat.LastMessagePreview;
                        break;
                }
            }
        }

        private void AttachButton_Click(object sender, RoutedEventArgs e)
        {
            // Имитация прикрепления файла
            var fileMessage = new ChatMessage
            {
                Text = "Новый_файл.pdf",
                Time = DateTime.Now.ToString("HH:mm"),
                IsIncoming = false,
                IsFile = true,
                FileName = "Новый_файл.pdf",
                FileSize = "1.5 MB"
            };

            ChatManager.AddMessageToChat(_currentProfile, _currentChatId, fileMessage);
            AddFileMessage(fileMessage.FileName, fileMessage.FileSize, fileMessage.Time);

            // Обновляем превью чата
            UpdateChatPreview();

            // Прокручиваем к последнему сообщению
            ScrollToBottom();

            MessageBox.Show("Функция прикрепления файлов будет реализована в будущей версии",
                          "В разработке",
                          MessageBoxButton.OK,
                          MessageBoxImage.Information);
        }

        // Метод для прокрутки к последнему сообщению
        private void ScrollToBottom()
        {
            // Используем Dispatcher для обеспечения правильного времени выполнения
            Dispatcher.BeginInvoke(new Action(() =>
            {
                MessagesScrollViewer.ScrollToEnd();
            }), DispatcherPriority.ContextIdle);
        }

        // Обработчики для улучшения UX поля ввода
        private void MessageTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (MessageTextBox.Text == "Введите сообщение...")
            {
                MessageTextBox.Text = "";
                MessageTextBox.Foreground = Brushes.Black;
            }
        }

        private void MessageTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(MessageTextBox.Text))
            {
                MessageTextBox.Text = "Введите сообщение...";
                MessageTextBox.Foreground = Brushes.Gray;
            }
        }

        // Очистка ресурсов
        private void MessagesPage_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_typingTimer != null && _typingTimer.IsEnabled)
            {
                _typingTimer.Stop();
            }
        }
    }
}