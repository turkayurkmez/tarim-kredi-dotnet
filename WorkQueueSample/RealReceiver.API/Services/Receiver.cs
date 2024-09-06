using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;

namespace RealReceiver.API.Services
{
    public class Receiver
    {
        private readonly RabbitConnector _rabbitConnector;
        private readonly ILogger<Receiver> logger;

        public Receiver(RabbitConnector rabbitConnector, ILogger<Receiver> logger)
        {
            _rabbitConnector = rabbitConnector;
            this.logger = logger;
            var consumer = new EventingBasicConsumer(_rabbitConnector.Channel);
            consumer.Received += Consumer_Received;
            var queueName = _rabbitConnector.Channel.QueueDeclare().QueueName;

            rabbitConnector.Channel.BasicConsume(queue: queueName,
                         autoAck: true,
                         consumer: consumer);

        }

        private void Consumer_Received(object? sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            logger.LogInformation($"Gelen mesaj:{message}");
        }
    }
}
