using Bogus;
using VinylRecordSale.Domain.Entities;
using Xunit;

namespace VinylRecordSale.Domain.Tests.Entities
{
    public class ItemSaleTestTest
    {
        [Fact(DisplayName = "New item sale valid")]
        [Trait("Category", "Entities")]
        public void ItemSale_NewItemSale_Valid()
        {
            // Arrange
            var itemSale = GetItemSaleValid();

            // Act
            var isValid = itemSale.IsValid();

            // Assert
            Assert.True(isValid);
            Assert.Empty(itemSale.ValidationResult.Errors);
        }

        [Fact(DisplayName = "New item sale invalid")]
        [Trait("Category", "Entities")]
        public void ItemSale_NewItemSale_Invalid()
        {
            // Arrange
            var itemSale = GetItemSaleInvalid();

            // Act
            var isValid = itemSale.IsValid();

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(itemSale.ValidationResult.Errors);
        }


        private static ItemSale GetItemSaleValid()
        {
            return new Faker<ItemSale>()
                .RuleFor(i => i.SaleId, (f, i) => f.Random.Int(1, 400))
                .RuleFor(i => i.VinylDiscId, (f, i) => f.Random.Int(1, 200))
                .RuleFor(i => i.Quantity, (f, i) => f.Random.Int(1, 10))
                .RuleFor(i => i.Value, (f, i) => f.Random.Decimal(10.9M, 99.9M))
                .RuleFor(i => i.Cashback, (f, i) => f.Random.Decimal(5, 50))
                .Generate();
        }

        private static ItemSale GetItemSaleInvalid()
        {
            return new Faker<ItemSale>()
                .RuleFor(i => i.SaleId, (f, i) => f.Random.Int(1, 400))
                .RuleFor(i => i.VinylDiscId, (f, i) => f.Random.Int(-100, -1))
                .RuleFor(i => i.Quantity, (f, i) => f.Random.Int(1, 10))
                .RuleFor(i => i.Cashback, (f, i) => f.Random.Decimal(5, 50))
                .Generate();
        }
    }
}