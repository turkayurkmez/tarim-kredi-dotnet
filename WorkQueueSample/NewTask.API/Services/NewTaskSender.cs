using System.Text;
using RabbitMQ.Client;
namespace NewTask.API.Services
{
    public class NewTaskSender : INewTaskSender
    {
        private readonly RabbitConnector rabbitConnector;

        public NewTaskSender(RabbitConnector rabbitConnector)
        {
            this.rabbitConnector = rabbitConnector;
        }
        public void Send(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            rabbitConnector.Channel.BasicPublish(
                exchange: "logs",
                routingKey: rabbitConnector.Channel.CurrentQueue ?? string.Empty,
                basicProperties: null,
                body: body
                );
        }
    }
}
