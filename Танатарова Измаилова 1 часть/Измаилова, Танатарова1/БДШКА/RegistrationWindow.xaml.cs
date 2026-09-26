using MySql.Data.MySqlClient;
using System;
using System.Windows;
namespace БДШКА
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow() { InitializeComponent(); }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string surname = SurnameTextBox.Text;
            string name = NameTextBox.Text;
            string patronymic = PatronymicTextBox.Text;
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;
            string repeatPassword = RepeatPasswordBox.Password;
            if (surname == "" ||
                name == "" ||
                patronymic == "" ||
                login == "" ||
                password == "" ||
                repeatPassword == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            if (password != repeatPassword)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }
            Database database = new Database();
            try
            {
                using (MySqlConnection connection = database.GetConnection())
                {
                    connection.Open();
                    string checkQuery = @"
                    SELECT COUNT(*)
                    FROM user_import
                    WHERE Login = @login";
                    using (MySqlCommand checkCommand =
                           new MySqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@login", login);
                        int count = Convert.ToInt32(
                            checkCommand.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Такой логин уже существует");
                            return;
                        }
                    }
                    string insertQuery = @"
                    INSERT INTO user_import
                    (employeeRole, Surname, Name, patronymic, Login, Password)
                    VALUES
                    (@employeeRole, @surname, @name, @patronymic, @login, @password)";
                    using (MySqlCommand insertCommand =
                           new MySqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue(
                           "@employeeRole", "Клиент");
                        insertCommand.Parameters.AddWithValue(
                            "@surname", surname);
                        insertCommand.Parameters.AddWithValue(
                            "@name", name);
                        insertCommand.Parameters.AddWithValue(
                            "@patronymic", patronymic);
                        insertCommand.Parameters.AddWithValue(
                            "@login", login);
                        insertCommand.Parameters.AddWithValue(
                            "@password", password);
                        insertCommand.ExecuteNonQuery();
                    }
                    MessageBox.Show("Регистрация прошла успешно!");
                    ClientWindow clientWindow = new ClientWindow(
                    surname,
                    name,
                    patronymic);
                    clientWindow.Show();
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка:\n" + ex.Message);
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}