using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace БДШКА
{
    public partial class AdminWindow : Window
    {
        private DataTable productsTable;

        public AdminWindow(string surname, string name, string patronymic)
        {
            InitializeComponent();
            AdminNameTextBlock.Text =
                surname + " " +
                name + " " +
                patronymic;
            LoadProducts();
        }
        private void LoadProducts()
        {
            Database database = new Database();
            try
            {
                using (MySqlConnection connection =
                       database.GetConnection())
                {
                    connection.Open();
                    string query =
                        "SELECT * FROM product_import";
                    MySqlDataAdapter adapter =
                        new MySqlDataAdapter(query, connection);
                    productsTable = new DataTable();
                    adapter.Fill(productsTable);
                    if (!productsTable.Columns.Contains("ImageForDisplay"))
                    {
                        productsTable.Columns.Add(
                            "ImageForDisplay",
                            typeof(string));
                    }
                    foreach (DataRow row in productsTable.Rows)
                    {
                        string imagePath = "";
                        if (row["Image"] != DBNull.Value)
                        {
                            imagePath =
                                row["Image"].ToString().Trim();
                        }
                        if (string.IsNullOrWhiteSpace(imagePath))
                        {
                            row["ImageForDisplay"] =
                                "no-image.png";
                        }
                        else if (imagePath.StartsWith(
                                     "Images/",
                                     StringComparison.OrdinalIgnoreCase))
                        {
                            string fullPath =
                                System.IO.Path.Combine(
                                    AppDomain.CurrentDomain.BaseDirectory,
                                    imagePath);
                            row["ImageForDisplay"] =
                                fullPath;
                        }        
                        else
                        {
                            row["ImageForDisplay"] =
                                imagePath;
                        }
                    }
                    ProductsListView.ItemsSource =
                        productsTable.DefaultView;
                    LoadManufacturers();
                    UpdateCount();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка загрузки товаров:\n" +
                    ex.Message);
            }
        }
        private void LoadManufacturers()
        {
            ManufacturerComboBox.Items.Clear();
            ManufacturerComboBox.Items.Add(
                "Все производители");
            foreach (DataRow row in productsTable.Rows)
            {
                string manufacturer =
                    row["Manufacurer"].ToString();
                if (!string.IsNullOrWhiteSpace(manufacturer))
                {
                    bool exists = false;
                    foreach (object item
                             in ManufacturerComboBox.Items)
                    {
                        if (item.ToString() == manufacturer)
                        {
                            exists = true;
                            break;
                        }
                    }
                    if (!exists)
                    {
                        ManufacturerComboBox.Items.Add(
                            manufacturer);
                    }
                }
            }
            ManufacturerComboBox.SelectedIndex = 0;
        }
        private void SearchTextBox_TextChanged(
            object sender,
            TextChangedEventArgs e)
        {
            ApplyFilterAndSort();
        }
        private void SearchButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            ApplyFilterAndSort();
        }
        private void SortComboBox_SelectionChanged(
            object sender,
            SelectionChangedEventArgs e)
        {
            if (productsTable == null)
                return;
            ApplyFilterAndSort();
        }
        private void ManufacturerComboBox_SelectionChanged(
            object sender,
            SelectionChangedEventArgs e)
        {
            if (productsTable == null)
                return;
            ApplyFilterAndSort();
        }
        private void ApplyFilterAndSort()
        {
            if (productsTable == null)
                return;
            string filter = "";
            string search =
                SearchTextBox.Text.Trim();
            if (search != "")
            {
                search =
                    search.Replace("'", "''");
                string[] columns =
                {
                    "Art",
                    "Name",
                    "UnitOfMeasurement",
                    "price",
                    "SizeMaxSale",
                    "Manufacurer",
                    "Supplier",
                    "Category",
                    "Sale",
                    "QuantityInStock",
                    "Description",
                    "Image"
                };
                for (int i = 0; i < columns.Length; i++)
                {
                    string part =
                        "CONVERT([" +
                        columns[i] +
                        "], 'System.String') LIKE '%" +
                        search +
                        "%'";
                    if (i == 0)
                        filter = "(" + part;
                    else
                        filter += " OR " + part;
                }
                filter += ")";
            }
            if (ManufacturerComboBox.SelectedIndex > 0)
            {
                string manufacturer =
                    ManufacturerComboBox.SelectedItem
                    .ToString()
                    .Replace("'", "''");
                if (filter != "")
                    filter += " AND ";
                filter +=
                    "[Manufacurer] = '" +
                    manufacturer +
                    "'";
            }
            productsTable.DefaultView.RowFilter =
                filter;
            if (SortComboBox.SelectedIndex == 0)
            {
                productsTable.DefaultView.Sort = "";
            }
            else if (SortComboBox.SelectedIndex == 1)
            {
                productsTable.DefaultView.Sort =
                    "price ASC";
            }
            else if (SortComboBox.SelectedIndex == 2)
            {
                productsTable.DefaultView.Sort =
                    "price DESC";
            }
            UpdateCount();
        }
        private void UpdateCount()
        {
            if (productsTable == null)
                return;
            ProductsCountTextBlock.Text =
                ProductsListView.Items.Count +
                " из " +
                productsTable.Rows.Count;
        }
        private void AddButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            ProductWindow productWindow =
                new ProductWindow();
            productWindow.ShowDialog();
            LoadProducts();
        }
        private void EditButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            Button button =
                sender as Button;
            if (button == null)
                return;
            DataRowView row =
                button.DataContext as DataRowView;
            if (row == null)
            {
                MessageBox.Show(
                    "Не удалось выбрать товар");
                return;
            }
            ProductWindow productWindow =
                new ProductWindow(row);

            productWindow.ShowDialog();
            LoadProducts();
        }
        private void DeleteButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            Button button =
                sender as Button;
            if (button == null)
                return;
            DataRowView row =
                button.DataContext as DataRowView;
            if (row == null)
            {
                MessageBox.Show(
                    "Не удалось выбрать товар");
                return;
            }
            string art =
                row["Art"].ToString();
            MessageBoxResult result =
                MessageBox.Show(
                    "Удалить товар \"" +
                    row["Name"].ToString() +
                    "\"?",
                    "Удаление товара",
                    MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes)
                return;
            Database database =
                new Database();
            try
            {
                using (MySqlConnection connection =
                       database.GetConnection())
                {
                    connection.Open();
                    string query =
                        "DELETE FROM product_import " +
                        "WHERE Art = @art";
                    using (MySqlCommand command =
                           new MySqlCommand(
                               query,
                               connection))
                    {
                        command.Parameters.AddWithValue(
                            "@art",
                            art);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show(
                        "Товар удалён");
                    LoadProducts();
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    MessageBox.Show(
                        "Этот товар нельзя удалить, " +
                        "так как он используется в заказе.");
                }
                else
                {
                    MessageBox.Show(
                        "Ошибка удаления:\n" +
                        ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка удаления:\n" +
                    ex.Message);
            }
        }
        private void ExitButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            MainWindow mainWindow =
                new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}