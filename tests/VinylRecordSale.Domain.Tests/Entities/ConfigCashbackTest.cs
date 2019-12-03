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
                .RuleFor(c => c.MusicGenreId, (f, c) => f.Random.Int(1, 4))
                .RuleFor(c => c.PercentageSunday, (f, c) => f.Random.Decimal(0, 100))
                .RuleFor(c => c.PercentageMonday, (f, c) => f.Random.Decimal(0, 100))
                .RuleFor(c => c.PercentageTuesday, (f, c) => f.Random.Decimal(0, 100))
                .RuleFor(c => c.PercentageWednesday, (f, c) => f.Random.Decimal(0, 100))
                .RuleFor(c => c.PercentageThursday, (f, c) => f.Random.Decimal(0, 100))
                .RuleFor(c => c.PercentageFriday, (f, c) => f.Random.Decimal(0, 100))
                .RuleFor(c => c.PercentageSaturday, (f, c) => f.Random.Decimal(0, 100))
                .Generate();
        }

        private static ConfigCashback GetConfigCashbackInvalid()
        {
            return new Faker<ConfigCashback>()
                .RuleFor(c => c.MusicGenreId, (f, c) => f.Random.Int(1, 4))
                .RuleFor(c => c.PercentageSunday, (f, c) => f.Random.Int(-100, -1))
                .RuleFor(c => c.PercentageMonday, (f, c) => f.Random.Decimal(0, 100))
                .RuleFor(c => c.PercentageTuesday, (f, c) => f.Random.Decimal(0, 100))
                .RuleFor(c => c.PercentageWednesday, (f, c) => f.Random.Int(-100, -1))
                .RuleFor(c => c.PercentageThursday, (f, c) => f.Random.Decimal(0, 100))
                .RuleFor(c => c.PercentageFriday, (f, c) => f.Random.Decimal(0, 100))
                .RuleFor(c => c.PercentageSaturday, (f, c) => f.Random.Decimal(0, 100))
                .Generate();
        }
    }
}