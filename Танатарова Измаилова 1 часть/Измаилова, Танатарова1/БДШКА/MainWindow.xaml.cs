using MySql.Data.MySqlClient;
using System;
using System.Windows;

namespace БДШКА
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string password = PasswordBox.Password;
            if (login == "" || password == "")
            {
                MessageBox.Show("Введите логин и пароль");
                return;
            }
            Database database = new Database();
            try
            {
                using (MySqlConnection connection = database.GetConnection())
                {
                    connection.Open();
                    string query = @"
                        SELECT employeeRole, Surname, Name, patronymic
                        FROM user_import
                        WHERE Login = @login
                        AND Password = @password";
                    using (MySqlCommand command =
                           new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@login", login);
                        command.Parameters.AddWithValue("@password", password);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string role =
                                    reader["employeeRole"].ToString();
                                string surname =
                                    reader["Surname"].ToString();
                                string name =
                                    reader["Name"].ToString();
                                string patronymic =
                                    reader["patronymic"].ToString();
                                if (role == "Администратор")
                                {
                                    AdminWindow adminWindow =
                                        new AdminWindow(
                                            surname,
                                            name,
                                            patronymic);
                                    adminWindow.Show();
                                    Close();
                                }
                                else if (role == "Менеджер")
                                {
                                    ManagerWindow managerWindow =
                                        new ManagerWindow(
                                            surname,
                                            name,
                                            patronymic);
                                    managerWindow.Show();
                                    Close();
                                }
                                else if (role == "Клиент")
                                {
                                    ClientWindow clientWindow =
                                        new ClientWindow(
                                            surname,
                                            name,
                                            patronymic);
                                    clientWindow.Show();
                                    Close();
                                }
                                else
                                {
                                    MessageBox.Show(
                                        "Вход выполнен.\nВаша роль: " +
                                        role);
                                }
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Неверный логин или пароль");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка подключения:\n" +
                    ex.Message);
            }
        }
        private void RegistrationButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow =
                new RegistrationWindow();
            registrationWindow.Show();
            Close();
        }
        private void GuestButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            GuestWindow guestWindow =
                new GuestWindow();
            guestWindow.Show();
            Close();
        }
    }
}