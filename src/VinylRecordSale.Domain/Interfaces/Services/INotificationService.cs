using System.Collections.Generic;
using VinylRecordSale.Domain.ValueObjects;

namespace VinylRecordSale.Domain.Interfaces.Services
{
    public interface INotificationService
    {
        void Handle(Notification notification);
        List<Notification> GetNotifications();
        bool HaveNotification();
        void Clear();
    }
}