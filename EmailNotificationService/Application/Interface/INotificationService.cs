using EmailNotificationService.Domain;

namespace EmailNotificationService.Application.Interface
{
    public interface INotificationService
    {
        Task SendNotification(NotificationRequest request);
    }  
}
