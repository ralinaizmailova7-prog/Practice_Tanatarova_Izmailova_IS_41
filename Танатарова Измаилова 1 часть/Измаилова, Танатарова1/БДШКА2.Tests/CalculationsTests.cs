using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace БДШКА.Tests
{
    [TestClass]
    public class ProductValidatorTests
    {
        private ProductValidator validator;

        [TestInitialize]
        public void SetUp()
        {
            validator = new ProductValidator();
        }
        [TestMethod]
        public void Validate_AllFieldsValid_ReturnsSuccess()
        {
            ValidationResult result = validator.Validate(
                "V835G5",
                "Подвеска",
                "ЮвелирТорг",
                "Подвеска",
                "695",
                "6");
            Assert.IsTrue(result.IsValid);
            Assert.IsNull(result.ErrorMessage);
        }
        [TestMethod]
        public void Validate_EmptyArt_ReturnsError()
        {
            ValidationResult result = validator.Validate(
                "",
                "Подвеска",
                "ЮвелирТорг",
                "Подвеска",
                "695",
                "6");
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(
                "Заполните артикул, название и производителя",
                result.ErrorMessage);
        }
        [TestMethod]
        public void Validate_NoCategorySelected_ReturnsError()
        {
            ValidationResult result = validator.Validate(
                "V835G5",
                "Подвеска",
                "ЮвелирТорг",
                null,
                "695",
                "6");
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("Выберите категорию", result.ErrorMessage);
        }
        [TestMethod]
        public void Validate_PriceNotANumber_ReturnsError()
        {
            ValidationResult result = validator.Validate(
                "V835G5",
                "Подвеска",
                "ЮвелирТорг",
                "Подвеска",
                "abc",
                "6");
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("Введите корректную цену", result.ErrorMessage);
        }
        [TestMethod]
        public void Validate_NegativePrice_ReturnsError()
        {
            ValidationResult result = validator.Validate(
                "V835G5",
                "Подвеска",
                "ЮвелирТорг",
                "Подвеска",
                "-695",
                "6");

            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(
                "Цена не может быть отрицательной",
                result.ErrorMessage);
        }
        [TestMethod]
        public void Validate_QuantityNotANumber_ReturnsError()
        {
            ValidationResult result = validator.Validate(
                "V835G5",
                "Подвеска",
                "ЮвелирТорг",
                "Подвеска",
                "695",
                "шесть");

            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(
                "Введите корректное количество",
                result.ErrorMessage);
        }
        [TestMethod]
        public void Validate_NegativeQuantity_ReturnsError()
        {
            ValidationResult result = validator.Validate(
                "V835G5",
                "Подвеска",
                "ЮвелирТорг",
                "Подвеска",
                "695",
                "-6");
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(
                "Количество на складе не может быть отрицательным",
                result.ErrorMessage);
        }
    }
    [TestClass]
    public class ProductSorterTests
    {
        private ProductSorter sorter;
        private List<Product> products;
        private List<Product> manufacturerProducts;
        [TestInitialize]
        public void SetUp()
        {
            sorter = new ProductSorter();
            products = new List<Product>
            {
                new Product { Name = "Ожерелье", Manufacturer = "ЮвелирТорг", Price = 890 },
                new Product { Name = "Подвеска", Manufacturer = "ЮвелирТорг", Price = 140 },
                new Product { Name = "Серьги",   Manufacturer = "ЮвелирТорг", Price = 695 }
            };
            manufacturerProducts = new List<Product>
            {
                new Product { Name = "Подвеска", Manufacturer = "ЮвелирТорг", Price = 695 },
                new Product { Name = "Брошь",    Manufacturer = "ЮвелирКарат", Price = 7100 }
            };
        }
        [TestMethod]
        public void SortByPrice_Ascending_ReturnsCorrectOrder()
        {
            List<Product> result = sorter.SortByPrice(products, true);
            CollectionAssert.AreEqual(
                new[] { "Подвеска", "Серьги", "Ожерелье" },
                result.ConvertAll(p => p.Name));
        }
        [TestMethod]
        public void SortByPrice_Descending_ReturnsCorrectOrder()
        {
            List<Product> result = sorter.SortByPrice(products, false);
            CollectionAssert.AreEqual(
                new[] { "Ожерелье", "Серьги", "Подвеска" },
                result.ConvertAll(p => p.Name));
        }
        [TestMethod]
        public void SortByManufacturer_Ascending_ReturnsAlphabeticalOrder()
        {
            List<Product> result = sorter.SortByManufacturer(manufacturerProducts, true);
            CollectionAssert.AreEqual(
                new[] { "ЮвелирКарат", "ЮвелирТорг" },
                result.ConvertAll(p => p.Manufacturer));
        }
    }
}
