using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace БДШКА
{
    public partial class ProductWindow : Window
    {
        private bool editMode = false;
        private string oldArt = "";
        private string oldImagePath = "";
        private string newImagePath = "";

        public ProductWindow()
        {
            InitializeComponent();

            TitleTextBlock.Text = "Добавление товара";

            LoadCategories();

            ImagePreview.Source = LoadImage("no-image.png");
        }

        public ProductWindow(DataRowView row)
        {
            InitializeComponent();

            editMode = true;

            TitleTextBlock.Text = "Изменение товара";

            LoadCategories();

            ArtTextBox.Text = GetValue(row, "Art");
            NameTextBox.Text = GetValue(row, "Name");
            UnitTextBox.Text = GetValue(row, "UnitOfMeasurement");
            PriceTextBox.Text = GetValue(row, "price");
            SizeMaxSaleTextBox.Text = GetValue(row, "SizeMaxSale");
            ManufacturerTextBox.Text = GetValue(row, "Manufacurer");
            SupplierTextBox.Text = GetValue(row, "Supplier");

            string category = GetValue(row, "Category");

            if (!string.IsNullOrWhiteSpace(category))
            {
                CategoryComboBox.SelectedItem = category;
            }

            SaleTextBox.Text = GetValue(row, "Sale");
            QuantityTextBox.Text = GetValue(row, "QuantityInStock");
            DescriptionTextBox.Text = GetValue(row, "Description");
            ImageTextBox.Text = GetValue(row, "Image");

            oldArt = GetValue(row, "Art");
            oldImagePath = GetValue(row, "Image");

            if (!string.IsNullOrWhiteSpace(oldImagePath))
            {
                ImagePreview.Source = LoadImage(oldImagePath);
            }
            else
            {
                ImagePreview.Source = LoadImage("no-image.png");
            }

            ArtTextBox.IsReadOnly = true;
        }

        private string GetValue(
            DataRowView row,
            string column)
        {
            if (row[column] == DBNull.Value)
                return "";

            return row[column].ToString();
        }
        private void LoadCategories()
        {
            Database database = new Database();

            try
            {
                using (MySqlConnection connection =
                       database.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT DISTINCT Category
                        FROM product_import
                        WHERE Category IS NOT NULL
                        AND Category <> ''
                        ORDER BY Category";

                    using (MySqlCommand command =
                           new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader =
                               command.ExecuteReader())
                        {
                            CategoryComboBox.Items.Clear();

                            while (reader.Read())
                            {
                                string category =
                                    reader["Category"].ToString();

                                if (!string.IsNullOrWhiteSpace(category))
                                {
                                    CategoryComboBox.Items.Add(category);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка загрузки категорий:\n" +
                    ex.Message);
            }
        }

        private void SelectImageButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            OpenFileDialog dialog =
                new OpenFileDialog();

            dialog.Filter =
                "Изображения|*.jpg;*.jpeg;*.png;*.bmp";

            dialog.Title =
                "Выберите изображение";

            if (dialog.ShowDialog() != true)
                return;

            try
            {

                string imagesFolder =
                    Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        "Images");

                if (!Directory.Exists(imagesFolder))
                {
                    Directory.CreateDirectory(imagesFolder);
                }

                string fileName =
                    Guid.NewGuid().ToString("N") +
                    ".jpg";

                string destination =
                    Path.Combine(
                        imagesFolder,
                        fileName);

                ResizeImage(
                    dialog.FileName,
                    destination);

                newImagePath =
                    "Images/" + fileName;

                ImageTextBox.Text =
                    newImagePath;

                ImagePreview.Source =
                    LoadImage(newImagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка загрузки изображения:\n" +
                    ex.Message);
            }
        }

        private void ResizeImage(
            string sourcePath,
            string destinationPath)
        {
            BitmapImage source =
                new BitmapImage();

            source.BeginInit();

            source.UriSource =
                new Uri(
                    sourcePath,
                    UriKind.Absolute);

            source.CacheOption =
                BitmapCacheOption.OnLoad;

            source.EndInit();

            double scaleX =
                300.0 / source.PixelWidth;

            double scaleY =
                200.0 / source.PixelHeight;

            ScaleTransform transform =
                new ScaleTransform(
                    scaleX,
                    scaleY);

            TransformedBitmap resized =
                new TransformedBitmap(
                    source,
                    transform);

            JpegBitmapEncoder encoder =
                new JpegBitmapEncoder();

            encoder.Frames.Add(
                BitmapFrame.Create(resized));

            using (FileStream stream =
                   new FileStream(
                       destinationPath,
                       FileMode.Create))
            {
                encoder.Save(stream);
            }
        }

        private BitmapImage LoadImage(
            string imagePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(imagePath))
                    return null;

                string fullPath;

                if (Path.IsPathRooted(imagePath))
                {
                    fullPath = imagePath;
                }
                else
                {
                    fullPath =
                        Path.Combine(
                            AppDomain.CurrentDomain.BaseDirectory,
                            imagePath);
                }

                if (!File.Exists(fullPath))
                {
                    fullPath =
                        Path.Combine(
                            AppDomain.CurrentDomain.BaseDirectory,
                            Path.GetFileName(imagePath));
                }

                if (!File.Exists(fullPath))
                {
                    return null;
                }

                BitmapImage image =
                    new BitmapImage();

                image.BeginInit();

                image.UriSource =
                    new Uri(
                        fullPath,
                        UriKind.Absolute);

                image.CacheOption =
                    BitmapCacheOption.OnLoad;

                image.EndInit();

                return image;
            }
            catch
            {
                return null;
            }
        }

        private void SaveButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (ArtTextBox.Text.Trim() == "" ||
                NameTextBox.Text.Trim() == "" ||
                ManufacturerTextBox.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Заполните артикул, название и производителя");
                return;
            }

            if (CategoryComboBox.SelectedItem == null)
            {
                MessageBox.Show(
                    "Выберите категорию");
                return;
            }

            if (!decimal.TryParse(
                    PriceTextBox.Text.Trim()
                        .Replace(',', '.'),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out decimal price))
            {
                MessageBox.Show(
                    "Введите корректную цену");
                return;
            }

            if (price < 0)
            {
                MessageBox.Show(
                    "Цена не может быть отрицательной");
                return;
            }

            if (!int.TryParse(
                    QuantityTextBox.Text.Trim(),
                    out int quantity))
            {
                MessageBox.Show(
                    "Введите корректное количество");
                return;
            }

            if (quantity < 0)
            {
                MessageBox.Show(
                    "Количество на складе не может быть отрицательным");
                return;
            }

            Database database =
                new Database();

            try
            {
                using (MySqlConnection connection =
                       database.GetConnection())
                {
                    connection.Open();

                    if (!editMode)
                    {
                        string query = @"
                            INSERT INTO product_import
                            (
                                Art,
                                Name,
                                UnitOfMeasurement,
                                price,
                                SizeMaxSale,
                                Manufacurer,
                                Supplier,
                                Category,
                                Sale,
                                QuantityInStock,
                                Description,
                                Image
                            )
                            VALUES
                            (
                                @Art,
                                @Name,
                                @Unit,
                                @price,
                                @SizeMaxSale,
                                @Manufacurer,
                                @Supplier,
                                @Category,
                                @Sale,
                                @Quantity,
                                @Description,
                                @Image
                            )";

                        using (MySqlCommand command =
                               new MySqlCommand(
                                   query,
                                   connection))
                        {
                            AddParameters(
                                command,
                                price,
                                quantity);

                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show(
                            "Товар добавлен");
                    }
                    else
                    {
                        string query = @"
                            UPDATE product_import
                            SET
                                Name = @Name,
                                UnitOfMeasurement = @Unit,
                                price = @price,
                                SizeMaxSale = @SizeMaxSale,
                                Manufacurer = @Manufacurer,
                                Supplier = @Supplier,
                                Category = @Category,
                                Sale = @Sale,
                                QuantityInStock = @Quantity,
                                Description = @Description,
                                Image = @Image
                            WHERE Art = @OldArt";

                        using (MySqlCommand command =
                               new MySqlCommand(
                                   query,
                                   connection))
                        {
                            AddParameters(
                                command,
                                price,
                                quantity);

                            command.Parameters.AddWithValue(
                                "@OldArt",
                                oldArt);

                            command.ExecuteNonQuery();
                        }

                        if (!string.IsNullOrWhiteSpace(newImagePath))
                        {
                            DeleteOldImage();
                        }

                        MessageBox.Show(
                            "Товар изменён");
                    }

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка сохранения товара:\n\n" +
                    ex.Message);
            }
        }

        private void AddParameters(
            MySqlCommand command,
            decimal price,
            int quantity)
        {
            command.Parameters.AddWithValue(
                "@Art",
                ArtTextBox.Text.Trim());

            command.Parameters.AddWithValue(
                "@Name",
                NameTextBox.Text.Trim());

            command.Parameters.AddWithValue(
                "@Unit",
                UnitTextBox.Text.Trim());

            command.Parameters.AddWithValue(
                "@price",
                price);

            command.Parameters.AddWithValue(
                "@SizeMaxSale",
                GetInt(SizeMaxSaleTextBox.Text));

            command.Parameters.AddWithValue(
                "@Manufacurer",
                ManufacturerTextBox.Text.Trim());

            command.Parameters.AddWithValue(
                "@Supplier",
                SupplierTextBox.Text.Trim());

            command.Parameters.AddWithValue(
                "@Category",
                CategoryComboBox.SelectedItem.ToString());

            command.Parameters.AddWithValue(
                "@Sale",
                GetInt(SaleTextBox.Text));

            command.Parameters.AddWithValue(
                "@Quantity",
                quantity);

            command.Parameters.AddWithValue(
                "@Description",
                DescriptionTextBox.Text.Trim());

            command.Parameters.AddWithValue(
                "@Image",
                ImageTextBox.Text.Trim());
        }

        private int GetInt(string text)
        {
            if (int.TryParse(
                    text.Trim(),
                    out int value))
            {
                if (value < 0)
                    return 0;

                return value;
            }

            return 0;
        }

        private void DeleteOldImage()
        {
            if (string.IsNullOrWhiteSpace(oldImagePath))
                return;

            if (!oldImagePath.StartsWith(
                    "Images/",
                    StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            try
            {
                string fullPath =
                    Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        oldImagePath);

                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            }
            catch
            {
            }
        }

        private void CancelButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            Close();
        }
    }
}