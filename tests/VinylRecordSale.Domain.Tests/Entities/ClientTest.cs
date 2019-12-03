using Bogus;
using VinylRecordSale.Domain.Entities;
using Xunit;

namespace VinylRecordSale.Domain.Tests.Entities
{
    public class ClientTest
    {
        [Fact(DisplayName = "New client valid")]
        [Trait("Category", "Entities")]
        public void Client_NewClient_Valid()
        {
            // Arrange
            var client = GetClientValid();

            // Act
            var isValid = client.IsValid();

            // Assert
            Assert.True(isValid);
            Assert.Empty(client.ValidationResult.Errors);
        }

        [Fact(DisplayName = "New client invalid")]
        [Trait("Category", "Entities")]
        public void Client_NewClient_Invalid()
        {
            // Arrange
            var client = GetClientInvalid();

            // Act
            var isValid = client.IsValid();

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(client.ValidationResult.Errors);
        }


        private static Client GetClientValid()
        {
            return new Faker<Client>("pt_BR")
                .RuleFor(c => c.FullName, (f, c) => f.Name.FullName())
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.FullName.ToLower()))
                .Generate();
        }

        private static Client GetClientInvalid()
        {
            return new Faker<Client>("pt_BR")
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email())
                .Generate();
        }
    }
}