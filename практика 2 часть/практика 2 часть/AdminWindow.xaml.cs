using System;
using System.Collections.Generic;
using System.Windows;
using MySql.Data.MySqlClient;

namespace практика2часть
{
    public partial class AdminWindow : Window
    {
        string connectionString = "Server=192.168.227.14;Port=3306;Database=tradeddr;Uid=user07;Pwd=User07!Pass";

        // Класс для отображения пользователя в таблице
        public class UserRow
        {
            public int id { get; set; }
            public string login { get; set; }
            public string role { get; set; }
            public string is_blocked { get; set; }
        }

        public AdminWindow()
        {
            InitializeComponent();
            LoadUsers();
        }

        // Загружает всех пользователей из базы в таблицу
        private void LoadUsers()
        {
            List<UserRow> users = new List<UserRow>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id, login, role, is_blocked FROM `Пользователи`";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new UserRow
                    {
                        id = Convert.ToInt32(reader["id"]),
                        login = reader["login"].ToString(),
                        role = reader["role"].ToString(),
                        is_blocked = Convert.ToInt32(reader["is_blocked"]) == 1 ? "Да" : "Нет"
                    });
                }
            }

            UsersDataGrid.ItemsSource = users;
        }

        private void UsersDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // пока не требуется отдельная логика, оставлено для будущего расширения
        }

        // Добавление нового пользователя с проверкой на дубликат логина
        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            string newLogin = NewLoginBox.Text.Trim();
            string newPassword = NewPasswordBox.Text.Trim();
            string newRole = (NewRoleBox.SelectedItem as System.Windows.Controls.ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrEmpty(newLogin) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Заполните логин и пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // проверяем, существует ли уже такой логин
                string checkQuery = "SELECT COUNT(*) FROM `Пользователи` WHERE login = @login";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@login", newLogin);
                long existingCount = (long)checkCmd.ExecuteScalar();

                if (existingCount > 0)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string insertQuery = "INSERT INTO `Пользователи` (login, password, role, is_blocked, failed_attempts) VALUES (@login, @password, @role, 0, 0)";
                MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@login", newLogin);
                insertCmd.Parameters.AddWithValue("@password", newPassword);
                insertCmd.Parameters.AddWithValue("@role", newRole);
                insertCmd.ExecuteNonQuery();
            }

            MessageBox.Show("Пользователь успешно добавлен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            NewLoginBox.Clear();
            NewPasswordBox.Clear();
            LoadUsers(); // обновляем таблицу
        }

        // Снятие блокировки у выбранного в таблице пользователя
        private void Unblock_Click(object sender, RoutedEventArgs e)
        {
            var selected = UsersDataGrid.SelectedItem as UserRow;

            if (selected == null)
            {
                MessageBox.Show("Сначала выберите пользователя в таблице.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE `Пользователи` SET is_blocked = 0, failed_attempts = 0 WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", selected.id);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Блокировка снята.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            LoadUsers(); // обновляем таблицу
        }
    }
}