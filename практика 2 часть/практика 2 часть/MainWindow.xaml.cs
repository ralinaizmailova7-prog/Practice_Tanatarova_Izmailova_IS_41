using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Imaging;

namespace практика2часть
{
    public partial class MainWindow : Window
    {
        // Строка подключения к твоей базе данных
        string connectionString = "Server=192.168.227.14;Port=3306;Database=tradeddr;Uid=user07;Pwd=User07!Pass";

  
        public MainWindow()
        {
            InitializeComponent();
            SetupPuzzle();
        }

        // Список: на какой картинке-кусочке какой номер должен быть в итоге (0,1,2,3)
        List<Image> puzzlePieces = new List<Image>();
        List<int> correctOrder = new List<int> { 0, 1, 2, 3 };
        List<int> currentOrder = new List<int> { 0, 1, 2, 3 };
        int firstClickedIndex = -1;
        bool puzzleSolved = false;
        int puzzleWrongAttempts = 0;

        // имена твоих 4 файлов-кусочков по порядку: 0=1.png(левый верх), 1=2.png(правый верх), 2=3.png(левый низ), 3=4.png(правый низ)
        string[] pieceFileNames = { "1.png", "2.png", "3.png", "4.png" };

        private void SetupPuzzle()
        {
            List<BitmapImage> pieces = new List<BitmapImage>();

            foreach (string fileName in pieceFileNames)
            {
                BitmapImage img = new BitmapImage(new Uri("pack://application:,,,/" + fileName));
                pieces.Add(img);
            }

            // перемешиваем порядок кусочков
            Random rnd = new Random();
            currentOrder = correctOrder.OrderBy(x => rnd.Next()).ToList();

            PuzzleGrid.Children.Clear();
            puzzlePieces.Clear();

            foreach (int pieceIndex in currentOrder)
            {
                Image img = new Image();
                img.Source = pieces[pieceIndex];
                img.Tag = pieceIndex; // запоминаем, какой это кусочек на самом деле
                img.MouseLeftButtonDown += PuzzlePiece_Click;
                img.Margin = new Thickness(1);
                img.Stretch = Stretch.UniformToFill;
                PuzzleGrid.Children.Add(img);
                puzzlePieces.Add(img);
            }
        }
        private void PuzzlePiece_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (puzzleSolved) return;

            Image clickedImage = sender as Image;
            int clickedPosition = PuzzleGrid.Children.IndexOf(clickedImage);

            if (firstClickedIndex == -1)
            {
                firstClickedIndex = clickedPosition;
                clickedImage.Opacity = 0.5; // подсветка выбранного кусочка
            }
            else
            {
                // меняем местами два кусочка в сетке
                Image firstImage = puzzlePieces[firstClickedIndex];
                Image secondImage = puzzlePieces[clickedPosition];

                var tempSource = firstImage.Source;
                firstImage.Source = secondImage.Source;
                secondImage.Source = tempSource;

                var tempTag = firstImage.Tag;
                firstImage.Tag = secondImage.Tag;
                secondImage.Tag = tempTag;

                firstImage.Opacity = 1;
                firstClickedIndex = -1;

                CheckPuzzle();
            }
        }

        private void CheckPuzzle()
        {
            bool solved = true;
            for (int i = 0; i < puzzlePieces.Count; i++)
            {
                if ((int)puzzlePieces[i].Tag != correctOrder[i])
                {
                    solved = false;
                    break;
                }
            }

            if (solved)
            {
                puzzleSolved = true;
                puzzleWrongAttempts = 0;
                PuzzleStatusText.Foreground = System.Windows.Media.Brushes.Green;
                PuzzleStatusText.Text = "Пазл собран верно!";
                LoginButton.IsEnabled = true; // теперь можно жать "Войти"
            }
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Password;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM `Пользователи` WHERE login = @login";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@login", login);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int userId = Convert.ToInt32(reader["id"]);
                    string dbPassword = reader["password"].ToString();
                    int isBlocked = Convert.ToInt32(reader["is_blocked"]);
                    string role = reader["role"].ToString();
                    // Общий счётчик неудачных попыток входа.
                    // Растёт как от неверного пазла, так и от неверного пароля — по заданию это одно и то же условие блокировки.
                    int loginFailCounter = Convert.ToInt32(reader["failed_attempts"]);
                    reader.Close();

                    if (isBlocked == 1)
                    {
                        MessageText.Text = "Вы заблокированы. Обратитесь к администратору";
                        return;
                    }

                    bool puzzleCorrect = IsPuzzleCorrect();
                    bool passwordCorrect = (dbPassword == password);

                    // Попытка считается неудачной, если неверен пазл ИЛИ неверен пароль
                    if (!puzzleCorrect || !passwordCorrect)
                    {
                        loginFailCounter++; // засчитываем неудачную попытку в общий счётчик

                        if (loginFailCounter >= 3)
                        {
                            BlockUser(conn, userId);
                            MessageText.Text = "Вы заблокированы. Обратитесь к администратору";
                        }
                        else
                        {
                            IncreaseAttempts(conn, userId, loginFailCounter);

                            if (!puzzleCorrect)
                            {
                                PuzzleStatusText.Text = "Пазл собран неверно, попробуйте снова";
                          
                            }
                            else
                            {
                                MessageText.Text = "Вы ввели неверный логин или пароль. Пожалуйста проверьте ещё раз введенные данные";
                            }
                        }
                        return;
                    }

                    // И пазл, и пароль верны — успешный вход, сбрасываем счётчик
                    ResetAttempts(conn, userId);
                    MessageText.Foreground = System.Windows.Media.Brushes.Green;
                    MessageText.Text = "Вы успешно авторизовались";
                    if (role == "Администратор")
                    {
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.Show();
                    }
                }
                else
                {
                    MessageText.Text = "Вы ввели неверный логин или пароль. Пожалуйста проверьте ещё раз введенные данные";
                }
            }
        }

        private bool IsPuzzleCorrect()
        {
            for (int i = 0; i < puzzlePieces.Count; i++)
            {
                if ((int)puzzlePieces[i].Tag != correctOrder[i])
                    return false;
            }
            return true;
        }
        private void IncreaseAttempts(MySqlConnection conn, int userId, int attempts)
        {
            string query = "UPDATE `Пользователи` SET failed_attempts = @attempts WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@attempts", attempts);
            cmd.Parameters.AddWithValue("@id", userId);
            cmd.ExecuteNonQuery();
        }

        private void BlockUser(MySqlConnection conn, int userId)
        {
            string query = "UPDATE `Пользователи` SET is_blocked = 1, failed_attempts = @attempts WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@attempts", 3);
            cmd.Parameters.AddWithValue("@id", userId);
            cmd.ExecuteNonQuery();
        }
        private void ShufflePuzzle_Click(object sender, RoutedEventArgs e)
        {
            if (!puzzleSolved)
            {
                puzzleWrongAttempts++;

                if (puzzleWrongAttempts >= 3)
                {
                    PuzzleStatusText.Text = "Вы заблокированы. Обратитесь к администратору";
                    LoginButton.IsEnabled = false;
                    PuzzleGrid.IsEnabled = false; // блокируем и сам пазл тоже
                    return;
                }
            }

            SetupPuzzle(); // перемешиваем заново
        }
        private void ResetAttempts(MySqlConnection conn, int userId)
        {
            string query = "UPDATE `Пользователи` SET failed_attempts = 0 WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", userId);
            cmd.ExecuteNonQuery();
        }

    }
}