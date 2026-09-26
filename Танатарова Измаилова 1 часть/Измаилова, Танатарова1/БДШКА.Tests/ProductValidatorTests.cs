using NUnit.Framework;
using БДШКА;

namespace БДШКА.Tests
{
    public class ProductValidatorTests
    {
        private ProductValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new ProductValidator();
        }

        // 1. Корректное название
        [Test]
        public void ValidName_ReturnsTrue()
        {
            bool result = validator.IsValidName("Корм для кошек");

            Assert.That(result, Is.True);
        }

        // 2. Пустое название
        [Test]
        public void EmptyName_ReturnsFalse()
        {
            bool result = validator.IsValidName("");

            Assert.That(result, Is.False);
        }

        // 3. Корректный производитель
        [Test]
        public void ValidManufacturer_ReturnsTrue()
        {
            bool result = validator.IsValidManufacturer("Purina");

            Assert.That(result, Is.True);
        }

        // 4. Пустой производитель
        [Test]
        public void EmptyManufacturer_ReturnsFalse()
        {
            bool result = validator.IsValidManufacturer("");

            Assert.That(result, Is.False);
        }

        // 5. Корректная категория
        [Test]
        public void ValidCategory_ReturnsTrue()
        {
            bool result = validator.IsValidCategory("Корма");

            Assert.That(result, Is.True);
        }

        // 6. Цена с сотыми частями
        [Test]
        public void PriceWithDecimal_ReturnsTrue()
        {
            bool result = validator.IsValidPrice(499.99m);

            Assert.That(result, Is.True);
        }

        // 7. Отрицательная цена
        [Test]
        public void NegativePrice_ReturnsFalse()
        {
            bool result = validator.IsValidPrice(-100m);

            Assert.That(result, Is.False);
        }

        // 8. Нулевое количество
        [Test]
        public void ZeroQuantity_ReturnsTrue()
        {
            bool result = validator.IsValidQuantity(0);

            Assert.That(result, Is.True);
        }

        // 9. Отрицательное количество
        [Test]
        public void NegativeQuantity_ReturnsFalse()
        {
            bool result = validator.IsValidQuantity(-5);

            Assert.That(result, Is.False);
        }

        // 10. Полностью корректный товар
        [Test]
        public void ValidProduct_ReturnsTrue()
        {
            bool result = validator.IsValidProduct(
                "Корм для кошек",
                "Корма",
                "Purina",
                499.99m,
                20);

            Assert.That(result, Is.True);
        }
    }
}