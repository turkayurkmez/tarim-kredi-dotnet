using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace RealReceiver.API.Services
{
    public class RabbitConnector
    {
        private readonly RabbitConnectionOptions _options;

        public IModel Channel { get; init; }



        public RabbitConnector(IOptions<RabbitConnectionOptions> options)
        {
            _options = options.Value;


            var factory = new ConnectionFactory
            {
                UserName = _options.UserName,
                Password = _options.Password,
                Port = _options.Port,
                HostName = _options.HostName
            };

            var connection = factory.CreateConnection();
            Channel = connection.CreateModel();

            //var result = Channel.QueueDeclare(queue: _options.QueueName, durable: false, autoDelete: false, exclusive: false, arguments: null);

            Channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);


        }

    }
}
