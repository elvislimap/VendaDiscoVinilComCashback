using Bogus;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Tests.Entities.Config;
using VinylRecordSale.Domain.Validations;
using Xunit;

namespace VinylRecordSale.Domain.Tests.Entities
{
    [Collection(nameof(ConfigCollection))]
    public class VinylDiscTest
    {
        private readonly ConfigTestFixture _configTestFixture;

        public VinylDiscTest(ConfigTestFixture configTestFixture)
        {
            _configTestFixture = configTestFixture;
        }



        [Fact(DisplayName = "New vinyl disc valid")]
        [Trait("Category", "Entities")]
        public void VinylDisc_NewVinylDisc_Valid()
        {
            // Arrange
            var vinylDisc = GetVinylDiscValid();

            // Act
            var isValid = _configTestFixture.ExecuteValidation(new VinylDiscValidation(), vinylDisc);

            // Assert
            Assert.True(isValid);
            Assert.False(_configTestFixture.HaveNotification());
        }

        [Fact(DisplayName = "New vinyl disc invalid")]
        [Trait("Category", "Entities")]
        public void VinylDisc_NewVinylDisc_Invalid()
        {
            // Arrange
            var vinylDisc = GetVinylDiscInvalid();

            // Act
            var isValid = _configTestFixture.ExecuteValidation(new VinylDiscValidation(), vinylDisc);

            // Assert
            Assert.False(isValid);
            Assert.True(_configTestFixture.HaveNotification());
        }


        private static VinylDisc GetVinylDiscValid()
        {
            return new Faker<VinylDisc>()
                .CustomInstantiator(f =>
                    new VinylDisc(0, f.Random.Int(1, 4), f.Name.JobTitle(), f.Random.Decimal(10.9M, 99.9M)))
                .Generate();
        }

        private static VinylDisc GetVinylDiscInvalid()
        {
            return new Faker<VinylDisc>()
                .CustomInstantiator(f => new VinylDisc(0, 0, f.Name.JobTitle(), 0))
                .Generate();
        }
    }
}