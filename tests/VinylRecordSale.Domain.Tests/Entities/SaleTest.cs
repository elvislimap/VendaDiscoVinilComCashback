using Bogus;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Tests.Entities.Config;
using VinylRecordSale.Domain.Validations;
using Xunit;

namespace VinylRecordSale.Domain.Tests.Entities
{
    [Collection(nameof(ConfigCollection))]
    public class SaleTestTest
    {
        private readonly ConfigTestFixture _configTestFixture;

        public SaleTestTest(ConfigTestFixture configTestFixture)
        {
            _configTestFixture = configTestFixture;
        }


        [Fact(DisplayName = "New sale valid")]
        [Trait("Category", "Entities")]
        public void Sale_NewSale_Valid()
        {
            // Arrange
            var sale = GetSaleValid();
            sale.AddItemSale(new ItemSale(1, 1, 1, 1, 1, 1));

            // Act
            var isValid = _configTestFixture.ExecuteValidation(new SaleValidation(), sale);

            // Assert
            Assert.True(isValid);
            Assert.False(_configTestFixture.HaveNotification());
        }

        [Fact(DisplayName = "New sale invalid")]
        [Trait("Category", "Entities")]
        public void Sale_NewSale_Invalid()
        {
            // Arrange
            var sale = GetSaleInvalid();

            // Act
            var isValid = _configTestFixture.ExecuteValidation(new SaleValidation(), sale);

            // Assert
            Assert.False(isValid);
            Assert.True(_configTestFixture.HaveNotification());
        }


        private static Sale GetSaleValid()
        {
            return new Faker<Sale>()
                .CustomInstantiator(f => new Sale(0, f.Random.Int(1, 100), f.Random.Decimal(10.9M, 99.9M),
                    f.Random.Decimal(5, 50), f.Date.Past()))
                .Generate();
        }

        private static Sale GetSaleInvalid()
        {
            return new Faker<Sale>()
                .CustomInstantiator(f => new Sale(0, f.Random.Int(-100, -1), f.Random.Decimal(10.9M, 99.9M),
                    f.Random.Decimal(5, 50), f.Date.Past()))
                .Generate();
        }
    }
}