using RabbitMQ.Client;
using System.Text;

namespace Sender.API.Services
{


    public class NewTaskSenderFirst : INewTaskSender
    {


        private readonly string queueName;
        private readonly IModel model;
        private readonly ILogger<NewTaskSenderFirst> logger;

        public NewTaskSenderFirst(string queueName, ILogger<NewTaskSenderFirst> logger)
        {
            this.queueName = queueName;
            this.logger = logger;
        }

        public void Send(string message)
        {
            //1. bağlantı kuracak nesne:
            var factory = new ConnectionFactory { HostName = "localhost", Port = 5672 };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(
                exchange: string.Empty,
                routingKey: queueName,
                basicProperties: null,
                body: body);

            logger.LogInformation("Mesaj başarıyla gönderildi");

        }
    }
}
