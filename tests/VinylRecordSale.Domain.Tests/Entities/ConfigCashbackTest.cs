using Bogus;
using VinylRecordSale.Domain.Entities;
using Xunit;

namespace VinylRecordSale.Domain.Tests.Entities
{
    public class ConfigCashbackTest
    {
        [Fact(DisplayName = "New config cashback valid")]
        [Trait("Category", "Entities")]
        public void ConfigCashback_NewConfigCashback_Valid()
        {
            // Arrange
            var configCashback = GetConfigCashbackValid();

            // Act
            var isValid = configCashback.IsValid();

            // Assert
            Assert.True(isValid);
            Assert.Empty(configCashback.ValidationResult.Errors);
        }

        [Fact(DisplayName = "New config cashback invalid")]
        [Trait("Category", "Entities")]
        public void ConfigCashback_NewConfigCashback_Invalid()
        {
            // Arrange
            var configCashback = GetConfigCashbackInvalid();

            // Act
            var isValid = configCashback.IsValid();

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(configCashback.ValidationResult.Errors);
        }


        private static ConfigCashback GetConfigCashbackValid()
        {
            return new Faker<ConfigCashback>()
                .CustomInstantiator(f => new ConfigCashback(f.Random.Int(1, 4), f.Random.Decimal(0, 100),
                    f.Random.Decimal(0, 100), f.Random.Decimal(0, 100), f.Random.Decimal(0, 100),
                    f.Random.Decimal(0, 100), f.Random.Decimal(0, 100), f.Random.Decimal(0, 100)))
                .Generate();
        }

        private static ConfigCashback GetConfigCashbackInvalid()
        {
            return new Faker<ConfigCashback>()
                .CustomInstantiator(f => new ConfigCashback(f.Random.Int(1, 4), f.Random.Decimal(-100, -1),
                    f.Random.Decimal(0, 100), f.Random.Decimal(0, 100), f.Random.Decimal(0, 100),
                    f.Random.Decimal(0, 100), f.Random.Decimal(-100, -1), f.Random.Decimal(0, 100)))
                .Generate();
        }
    }
}