using Bogus;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Tests.Entities.Config;
using VinylRecordSale.Domain.Validations;
using Xunit;

namespace VinylRecordSale.Domain.Tests.Entities
{
    [Collection(nameof(ConfigCollection))]
    public class MusicGenreTest
    {
        private readonly ConfigTestFixture _configTestFixture;

        public MusicGenreTest(ConfigTestFixture configTestFixture)
        {
            _configTestFixture = configTestFixture;
        }


        [Fact(DisplayName = "New music genre valid")]
        [Trait("Category", "Entities")]
        public void MusicGenre_NewMusicGenre_Valid()
        {
            // Arrange
            var musicGenre = GetMusicGenreValid();

            // Act
            var isValid = _configTestFixture.ExecuteValidation(new MusicGenreValidation(), musicGenre);

            // Assert
            Assert.True(isValid);
            Assert.False(_configTestFixture.HaveNotification());
        }

        [Fact(DisplayName = "New music genre invalid")]
        [Trait("Category", "Entities")]
        public void MusicGenre_NewMusicGenre_Invalid()
        {
            // Arrange
            var musicGenre = GetMusicGenreInvalid();

            // Act
            var isValid = _configTestFixture.ExecuteValidation(new MusicGenreValidation(), musicGenre);

            // Assert
            Assert.False(isValid);
            Assert.True(_configTestFixture.HaveNotification());
        }


        private static MusicGenre GetMusicGenreValid()
        {
            return new Faker<MusicGenre>()
                .CustomInstantiator(f => new MusicGenre(0, f.Lorem.Letter(50)))
                .Generate();
        }

        private static MusicGenre GetMusicGenreInvalid()
        {
            return new Faker<MusicGenre>()
                .CustomInstantiator(f => new MusicGenre(0, f.Lorem.Letter(51)))
                .Generate();
        }
    }
}