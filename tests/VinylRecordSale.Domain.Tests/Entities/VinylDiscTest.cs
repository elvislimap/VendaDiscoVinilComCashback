using Bogus;
using VinylRecordSale.Domain.Entities;
using Xunit;

namespace VinylRecordSale.Domain.Tests.Entities
{
    public class VinylDiscTest
    {
        [Fact(DisplayName = "New vinyl disc valid")]
        [Trait("Category", "Entities")]
        public void VinylDisc_NewVinylDisc_Valid()
        {
            // Arrange
            var vinylDisc = GetVinylDiscValid();

            // Act
            var isValid = vinylDisc.IsValid();

            // Assert
            Assert.True(isValid);
            Assert.Empty(vinylDisc.ValidationResult.Errors);
        }

        [Fact(DisplayName = "New vinyl disc invalid")]
        [Trait("Category", "Entities")]
        public void VinylDisc_NewVinylDisc_Invalid()
        {
            // Arrange
            var vinylDisc = GetVinylDiscInvalid();

            // Act
            var isValid = vinylDisc.IsValid();

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(vinylDisc.ValidationResult.Errors);
        }


        private static VinylDisc GetVinylDiscValid()
        {
            return new Faker<VinylDisc>()
                .RuleFor(v => v.MusicGenreId, (f, v) => f.Random.Int(1, 4))
                .RuleFor(v => v.Name, (f, v) => f.Name.JobTitle())
                .RuleFor(v => v.Value, (f, v) => f.Random.Decimal(10.9M, 99.9M))
                .Generate();
        }

        private static VinylDisc GetVinylDiscInvalid()
        {
            return new Faker<VinylDisc>()
                .RuleFor(v => v.Name, (f, v) => f.Name.JobTitle())
                .Generate();
        }
    }
}