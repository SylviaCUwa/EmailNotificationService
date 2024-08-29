using EmailNotificationService.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmailNotificationService.Infrastructure
{
 
        public class NotificationDbContext : DbContext
        {
            public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options) { }

            public DbSet<NotificationRequest> NotificationRequests { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<NotificationRequest>().HasKey(n => n.Id);
         
            }
        }
    }

