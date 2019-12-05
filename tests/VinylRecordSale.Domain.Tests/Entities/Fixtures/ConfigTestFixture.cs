using FluentValidation;
using FluentValidation.Results;
using System;
using System.Linq;
using VinylRecordSale.Domain.Entities;
using VinylRecordSale.Domain.Interfaces.Services;
using VinylRecordSale.Domain.Services;
using VinylRecordSale.Domain.ValueObjects;
using Xunit;

namespace VinylRecordSale.Domain.Tests.Entities.Fixtures
{
    [CollectionDefinition(nameof(ConfigCollection))]
    public class ConfigCollection : ICollectionFixture<ConfigTestFixture> { }

    public class ConfigTestFixture : IDisposable
    {
        private readonly INotificationService _notificationService = new NotificationService();

        public bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid)
                return true;

            Notify(validator);

            return false;
        }

        public bool HaveNotification()
        {
            var haveNotification = _notificationService.HaveNotification();
            _notificationService.Clear();

            return haveNotification;
        }

        public void Dispose() { }


        private void Notify(ValidationResult validationResult)
        {
            validationResult.Errors.ToList().ForEach(e => Notify(e.ErrorMessage));
        }

        private void Notify(string message)
        {
            _notificationService.Handle(new Notification(message));
        }
    }
}