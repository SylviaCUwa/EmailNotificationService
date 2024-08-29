using EmailNotificationService.Application.Interface;
using EmailNotificationService.Domain;
using EmailNotificationService.Infrastructure;

namespace EmailNotificationService.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly NotificationDbContext _context;

        public NotificationService(NotificationDbContext context)
        {
            _context = context;
        }

        public async Task SendNotification(NotificationRequest request)
        {
           
            _context.NotificationRequests.Add(request);
            await _context.SaveChangesAsync();
        }
    }
}
 
