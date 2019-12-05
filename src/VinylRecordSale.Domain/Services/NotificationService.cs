using System.Collections.Generic;
using System.Linq;
using VinylRecordSale.Domain.Interfaces.Services;
using VinylRecordSale.Domain.ValueObjects;

namespace VinylRecordSale.Domain.Services
{
    public class NotificationService : INotificationService
    {
        private List<Notification> _notifications;

        public NotificationService()
        {
            _notifications = new List<Notification>();
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public bool HaveNotification()
        {
            return _notifications.Any();
        }

        public void Clear()
        {
            _notifications = new List<Notification>();
        }
    }
}