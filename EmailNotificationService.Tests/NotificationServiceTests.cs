using EmailNotificationService.Application.Services;
using EmailNotificationService.Domain;
using EmailNotificationService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailNotificationService.Tests
{
    public class NotificationServiceTests
    {
        private readonly NotificationService _service;
        private readonly NotificationDbContext _context;

        public NotificationServiceTests()
        {
            var options = new DbContextOptionsBuilder<NotificationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new NotificationDbContext(options);
            _service = new NotificationService(_context);
        }

        [Fact]
        public async Task SendNotificationAsync_ShouldAddNotificationRequestToDatabase()
        {
            var request = new NotificationRequest
            {
                Email = "sylviauwa@gmail.com",
                Subject = "Test Subject",
                Message = "Test Message",
                CreatedAt = DateTime.UtcNow
            };

            await _service.SendNotification(request);

            Assert.Equal(1, await _context.NotificationRequests.CountAsync());
        }
    }
}
