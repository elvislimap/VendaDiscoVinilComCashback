using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using VinylRecordSale.Domain.Commons;
using VinylRecordSale.Domain.Enums;
using Xunit;

namespace VinylRecordSale.Domain.Tests.Commons
{
    public class ExtensionsTest
    {
        [Fact(DisplayName = "ToBase64")]
        [Trait("Category", "DomainCommons")]
        public void Commons_ToBase64()
        {
            // Arrange
            const string value = "Test base64";

            // Act & Assert
            Assert.Equal(Convert.ToBase64String(Encoding.UTF8.GetBytes(value)), value.ToBase64());
        }

        [Fact(DisplayName = "ToText")]
        [Trait("Category", "DomainCommons")]
        public void Commons_ToText()
        {
            // Arrange
            object value = "Test totext";

            // Act & Assert
            Assert.Equal(string.IsNullOrEmpty(value.ToString()) ? string.Empty : value.ToString(), value.ToText());
        }

        [Fact(DisplayName = "GetNameMusicGenre")]
        [Trait("Category", "DomainCommons")]
        public void Commons_GetNameMusicGenre()
        {
            // Arrange & Act & Assert
            Assert.Equal("rock", MusicGenreEnum.Rock.GetNameMusicGenre());
        }

        [Fact(DisplayName = "ToValidationResult")]
        [Trait("Category", "DomainCommons")]
        public void Commons_ToValidationResult()
        {
            // Arrange
            var validationFailure = new ValidationFailure("test", "error");
            var resultExpected = new ValidationResult(new List<ValidationFailure> {validationFailure});

            // Act
            var result = validationFailure.ToValidationResult();

            // Assert
            Assert.Equal(resultExpected.IsValid, result.IsValid);
            Assert.Equal(resultExpected.Errors, result.Errors);
        }
    }
}