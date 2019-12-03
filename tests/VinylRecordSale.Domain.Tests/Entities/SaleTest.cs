using Bogus;
using VinylRecordSale.Domain.Entities;
using Xunit;

namespace VinylRecordSale.Domain.Tests.Entities
{
    public class SaleTestTest
    {
        [Fact(DisplayName = "New sale valid")]
        [Trait("Category", "Entities")]
        public void Sale_NewSale_Valid()
        {
            // Arrange
            var sale = GetSaleValid();

            // Act
            var isValid = sale.IsValid();

            // Assert
            Assert.True(isValid);
            Assert.Empty(sale.ValidationResult.Errors);
        }

        [Fact(DisplayName = "New sale invalid")]
        [Trait("Category", "Entities")]
        public void Sale_NewSale_Invalid()
        {
            // Arrange
            var sale = GetSaleInvalid();

            // Act
            var isValid = sale.IsValid();

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(sale.ValidationResult.Errors);
        }


        private static Sale GetSaleValid()
        {
            return new Faker<Sale>()
                .RuleFor(s => s.ClientId, (f, s) => f.Random.Int(1, 100))
                .RuleFor(s => s.TotalValue, (f, s) => f.Random.Decimal(10.9M, 99.9M))
                .RuleFor(s => s.CashbackTotal, (f, s) => f.Random.Decimal(5, 50))
                .RuleFor(s => s.Date, (f, s) => f.Date.Past())
                .Generate();
        }

        private static Sale GetSaleInvalid()
        {
            return new Faker<Sale>()
                .RuleFor(s => s.ClientId, (f, s) => f.Random.Int(-100, -1))
                .RuleFor(s => s.TotalValue, (f, s) => f.Random.Decimal(10.9M, 99.9M))
                .RuleFor(s => s.CashbackTotal, (f, s) => f.Random.Decimal(5, 50))
                .RuleFor(s => s.Date, (f, s) => f.Date.Past())
                .Generate();
        }
    }
}