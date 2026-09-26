using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace БДШКА
{
    public class Product
    {
        public string Art { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
    }
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
        public static ValidationResult Success()
        {
            return new ValidationResult { IsValid = true, ErrorMessage = null };
        }
        public static ValidationResult Fail(string message)
        {
            return new ValidationResult { IsValid = false, ErrorMessage = message };
        }
    }
    public class ProductValidator
    {
        public ValidationResult Validate(
            string art,
            string name,
            string manufacturer,
            string category,
            string priceText,
            string quantityText)
        {
            if (string.IsNullOrWhiteSpace(art) ||
                string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(manufacturer))
            {
                return ValidationResult.Fail(
                    "Заполните артикул, название и производителя");
            }
            if (string.IsNullOrWhiteSpace(category))
            {
                return ValidationResult.Fail("Выберите категорию");
            }
            if (!decimal.TryParse(
                    (priceText ?? "").Trim().Replace(',', '.'),
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out decimal price))
            {
                return ValidationResult.Fail("Введите корректную цену");
            }
            if (price < 0)
            {
                return ValidationResult.Fail(
                    "Цена не может быть отрицательной");
            }
            if (!int.TryParse((quantityText ?? "").Trim(), out int quantity))
            {
                return ValidationResult.Fail(
                    "Введите корректное количество");
            }
            if (quantity < 0)
            {
                return ValidationResult.Fail(
                    "Количество на складе не может быть отрицательным");
            }
            return ValidationResult.Success();
        }
    }
    public class ProductSorter
    {
        public List<Product> SortByPrice(
            List<Product> products,
            bool ascending = true)
        {
            return ascending
                ? products.OrderBy(p => p.Price).ToList()
                : products.OrderByDescending(p => p.Price).ToList();
        }

        public List<Product> SortByManufacturer(
            List<Product> products,
            bool ascending = true)
        {
            return ascending
                ? products
                    .OrderBy(p => p.Manufacturer, StringComparer.OrdinalIgnoreCase)
                    .ToList()
                : products
                    .OrderByDescending(p => p.Manufacturer, StringComparer.OrdinalIgnoreCase)
                    .ToList();
        }
    }
}
