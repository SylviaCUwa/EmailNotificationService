using EmailNotificationService.Domain;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;

namespace EmailNotificationService.Infrastructure.MessageQueue
{
    public class RabbitMQProducer
    {
        private readonly RabbitMQSettings _settings;

        public RabbitMQProducer(IOptions<RabbitMQSettings> options)
        {
            _settings = options.Value;
        }

        public void Publish(NotificationRequest notificationRequest)
        {
            var factory = new ConnectionFactory() { HostName = _settings.HostName };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: _settings.QueueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var message = JsonSerializer.Serialize(notificationRequest);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                 routingKey: _settings.QueueName,
                                 basicProperties: null,
                                 body: body);
        }
    }
}