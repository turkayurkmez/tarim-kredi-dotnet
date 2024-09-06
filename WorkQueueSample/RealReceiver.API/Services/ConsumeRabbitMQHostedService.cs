
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RealReceiver.API.Services
{
    public class ConsumeRabbitMQHostedService : BackgroundService
    {
        private readonly RabbitConnector rabbitConnector;
        private readonly ILogger<ConsumeRabbitMQHostedService> logger;

        public ConsumeRabbitMQHostedService(RabbitConnector rabbitConnector, ILogger<ConsumeRabbitMQHostedService> logger)
        {
            this.rabbitConnector = rabbitConnector;
            this.logger = logger;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var queueName = rabbitConnector.Channel.QueueDeclare().QueueName;
            rabbitConnector.Channel.QueueBind(queueName, exchange: "logs", routingKey: string.Empty);
            var consumer = new EventingBasicConsumer(rabbitConnector.Channel);
            consumer.Received += (sender, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                logger.LogInformation($"Gelen mesaj:{message}");
            };

            rabbitConnector.Channel.BasicConsume(queue: rabbitConnector.Channel.CurrentQueue,
                         autoAck: true,
                         consumer: consumer);
            return Task.CompletedTask;
        }
    }
}
