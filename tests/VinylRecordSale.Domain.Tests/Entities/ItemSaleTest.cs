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
                .CustomInstantiator(f => new ItemSale(0, f.Random.Int(1, 400), f.Random.Int(1, 200),
                    f.Random.Int(1, 10), f.Random.Decimal(10.9M, 99.9M), f.Random.Decimal(5, 50)))
                .Generate();
        }

        private static ItemSale GetItemSaleInvalid()
        {
            return new Faker<ItemSale>()
                .CustomInstantiator(f => new ItemSale(0, f.Random.Int(1, 400), f.Random.Int(-100, -1),
                    f.Random.Int(1, 10), f.Random.Int(-100, -1), f.Random.Decimal(5, 50)))
                .Generate();
        }
    }
}