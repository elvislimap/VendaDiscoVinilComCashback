using Bogus;
using VinylRecordSale.Domain.Entities;
using Xunit;

namespace VinylRecordSale.Domain.Tests.Entities
{
    public class MusicGenreTest
    {
        [Fact(DisplayName = "New music genre valid")]
        [Trait("Category", "Entities")]
        public void MusicGenre_NewMusicGenre_Valid()
        {
            // Arrange
            var musicGenre = GetMusicGenreValid();

            // Act
            var isValid = musicGenre.IsValid();

            // Assert
            Assert.True(isValid);
            Assert.Empty(musicGenre.ValidationResult.Errors);
        }

        [Fact(DisplayName = "New music genre invalid")]
        [Trait("Category", "Entities")]
        public void MusicGenre_NewMusicGenre_Invalid()
        {
            // Arrange
            var musicGenre = GetMusicGenreInvalid();

            // Act
            var isValid = musicGenre.IsValid();

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(musicGenre.ValidationResult.Errors);
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