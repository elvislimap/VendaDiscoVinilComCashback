using Bogus;
using FluentValidation.Results;
using System.Collections.Generic;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Services;
using VinylRecordSale.Domain.Validations;
using Xunit;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace VinylRecordSale.Domain.Tests.Services
{
    public class BaseServiceTest : BaseService
    {
        public BaseServiceTest() : base(new NotificationService()) { }

        [Fact(DisplayName = "Notify message")]
        [Trait("Category", "Services")]
        public void BaseService_NotifyMessage()
        {
            // Arrange & Act
            Notify("Test notification by message");

            // Assert
            Assert.True(HaveNotification());
        }

        [Fact(DisplayName = "Notify validation result")]
        [Trait("Category", "Services")]
        public void BaseService_NotifyValidationResult()
        {
            // Arrange
            var validationFailures = new List<ValidationFailure>
            {
                new ValidationFailure("test1", "error1"),
                new ValidationFailure("test2", "error2")
            };

            // Act
            Notify(new ValidationResult(validationFailures));

            // Assert
            Assert.True(HaveNotification());
        }

        [Fact(DisplayName = "Execute validation is valid")]
        [Trait("Category", "Services")]
        public void BaseService_ExecuteValidation_IsValid()
        {
            // Arrange
            var client = new Faker<Client>()
                .CustomInstantiator(f => new Client(f.Random.Int(1, 100), f.Name.FullName(), f.Internet.Email()))
                .Generate();

            // Act
            var isValid = ExecuteValidation(new ClientValidation(), client);

            // Assert
            Assert.True(isValid);
        }

        [Fact(DisplayName = "Execute validation is false")]
        [Trait("Category", "Services")]
        public void BaseService_ExecuteValidation_IsFalse()
        {
            // Arrange & Act
            var isValid = ExecuteValidation(new ClientValidation(), new Client());

            // Assert
            Assert.False(isValid);
        }
    }
}