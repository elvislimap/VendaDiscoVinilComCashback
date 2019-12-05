using Bogus;
using VinylRecordSale.Domain.Commons;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Tests.Entities.Fixtures;
using VinylRecordSale.Domain.Validations;
using Xunit;

namespace VinylRecordSale.Domain.Tests.Entities
{
    [Collection(nameof(ConfigCollection))]
    public class ClientTest
    {
        private readonly ConfigTestFixture _configTestFixture;

        public ClientTest(ConfigTestFixture configTestFixture)
        {
            _configTestFixture = configTestFixture;
        }


        [Fact(DisplayName = "New client valid")]
        [Trait("Category", "Entities")]
        public void Client_NewClient_Valid()
        {
            // Arrange
            var client = GetClientValid();

            // Act
            var isValid = _configTestFixture.ExecuteValidation(new ClientValidation(), client);

            // Assert
            Assert.True(isValid);
            Assert.False(_configTestFixture.HaveNotification());
        }

        [Fact(DisplayName = "New client invalid")]
        [Trait("Category", "Entities")]
        public void Client_NewClient_Invalid()
        {
            // Arrange
            var client = GetClientInvalid();

            // Act
            var isValid = _configTestFixture.ExecuteValidation(new ClientValidation(), client);

            // Assert
            Assert.False(isValid);
            Assert.True(_configTestFixture.HaveNotification());
        }


        private static Client GetClientValid()
        {
            var client = new Faker<Client>(Constants.LanguageBogus)
                .CustomInstantiator(f => new Client(0, f.Name.FullName(), null))
                .Generate();

            return new Faker<Client>(Constants.LanguageBogus)
                .CustomInstantiator(f => new Client(0, client.FullName, f.Internet.Email(client.FullName.ToLower())))
                .Generate();
        }

        private static Client GetClientInvalid()
        {
            return new Faker<Client>(Constants.LanguageBogus)
                .CustomInstantiator(f => new Client(0, null, f.Internet.Email()))
                .Generate();
        }
    }
}