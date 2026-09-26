using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace БДШКА
{
    public partial class GuestWindow : Window
    {
        private DataTable productsTable;

        public GuestWindow()
        {
            InitializeComponent();
            GuestNameTextBlock.Text = "Гость";
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
                    foreach (DataRow row in productsTable.Rows)
                    {
                        if (row["Image"] == DBNull.Value || string.IsNullOrWhiteSpace(row["Image"].ToString())) { row["Image"] = "no-image.png"; }
                        else
                        {
                            string path = row["Image"].ToString().Trim();
                            if (path.StartsWith("Images/",
                                StringComparison.OrdinalIgnoreCase))
                            {
                                row["Image"] = System.IO.Path.Combine(
                                    AppDomain.CurrentDomain.BaseDirectory,
                                    path);
                            }
                        }
                    }
                    ProductsListView.ItemsSource =
                        productsTable.DefaultView;
                    ProductsCountTextBlock.Text =
                        "Количество товаров: " +
                        productsTable.Rows.Count;
                    LoadManufacturers();
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
                    bool alreadyExists = false;
                    foreach (object item
                             in ManufacturerComboBox.Items)
                    {
                        if (item.ToString() == manufacturer)
                        {
                            alreadyExists = true;
                            break;
                        }
                    }
                    if (!alreadyExists)
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
            if (productsTable == null)
                return;
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
                filter =
                    "(Name LIKE '%" + search + "%' " +
                    "OR Manufacurer LIKE '%" + search + "%' " +
                    "OR Category LIKE '%" + search + "%')";
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
                    "Manufacurer = '" +
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
            ProductsCountTextBlock.Text =
                "Количество товаров: " +
                productsTable.DefaultView.Count;
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