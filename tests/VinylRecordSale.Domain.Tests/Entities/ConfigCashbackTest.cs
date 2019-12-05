using Bogus;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Tests.Entities.Config;
using VinylRecordSale.Domain.Validations;
using Xunit;

namespace VinylRecordSale.Domain.Tests.Entities
{
    [Collection(nameof(ConfigCollection))]
    public class ConfigCashbackTest
    {
        private readonly ConfigTestFixture _configTestFixture;

        public ConfigCashbackTest(ConfigTestFixture configTestFixture)
        {
            _configTestFixture = configTestFixture;
        }


        [Fact(DisplayName = "New config cashback valid")]
        [Trait("Category", "Entities")]
        public void ConfigCashback_NewConfigCashback_Valid()
        {
            // Arrange
            var configCashback = GetConfigCashbackValid();

            // Act
            var isValid = _configTestFixture
                .ExecuteValidation(new ConfigCashbackValidation(), configCashback);

            // Assert
            Assert.True(isValid);
            Assert.False(_configTestFixture.HaveNotification());
        }

        [Fact(DisplayName = "New config cashback invalid")]
        [Trait("Category", "Entities")]
        public void ConfigCashback_NewConfigCashback_Invalid()
        {
            // Arrange
            var configCashback = GetConfigCashbackInvalid();

            // Act
            var isValid = _configTestFixture
                .ExecuteValidation(new ConfigCashbackValidation(), configCashback);

            // Assert
            Assert.False(isValid);
            Assert.True(_configTestFixture.HaveNotification());
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