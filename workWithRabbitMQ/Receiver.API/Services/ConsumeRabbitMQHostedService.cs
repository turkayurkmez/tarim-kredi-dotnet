
using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Receiver.API.Services
{
    public class ConsumeRabbitMQHostedService(ILogger<ConsumeRabbitMQHostedService> logger) : BackgroundService
    {
         
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {

            logger.LogInformation("Gelen mesaj işleniyor....");
            var factory = new ConnectionFactory { HostName = "localhost", Port = 5672 };

            using var connection = factory.CreateConnection();
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "my_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);

                // channel.QueueBind("my_queue", exchange: string.Empty, routingKey: "my_queue");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, arg) =>
                {
                    var body = arg.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    logger.LogInformation($"Gelen mesaj: {message}");
                };

                channel.BasicConsume(queue: "my_queue", autoAck: true, consumer: consumer);
                logger.LogInformation("Gelen mesaj işleniyor....");
            }

            return Task.CompletedTask;
        }
    }
}
