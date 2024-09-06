using RabbitMQ.Client;
using System.Text;

namespace NewTask.API.Services
{
    public class NewTaskSender_FirstOne : INewTaskSender
    {
        private readonly string queueName;
        private readonly ILogger<NewTaskSender_FirstOne> logger;
        private readonly IModel model;

        public NewTaskSender_FirstOne(string queueName, ILogger<NewTaskSender_FirstOne> logger)
        {
            this.queueName = queueName;
            this.logger = logger;
        
        }

        public void Send(string message)
        {
            var factory = new ConnectionFactory { HostName = "localhost", Password="", Port=5672, UserName=""  };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            

            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(
                exchange: string.Empty,
                routingKey: model.CurrentQueue,
                basicProperties: null,
                body: body);

            logger.LogInformation("Mesaj gönderildi");




        }
    }
}
