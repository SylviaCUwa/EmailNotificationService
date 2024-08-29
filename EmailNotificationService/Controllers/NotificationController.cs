using EmailNotificationService.Application.Interface;
using EmailNotificationService.Domain;
using Microsoft.AspNetCore.Mvc;

namespace EmailNotificationService.Controllers
{
  
        [ApiController]
        [Route("api/[controller]")]
        public class NotificationController : ControllerBase
        {
            private readonly INotificationService _notificationService;

            public NotificationController(INotificationService notificationService)
            {
                _notificationService = notificationService;
            }
        

        [HttpPost]
        public async Task<IActionResult> SendNotification([FromBody] NotificationRequest request)
        {
            await _notificationService.SendNotification(request);
            return Ok("Notification sent successfully!");
        }

    }
}
