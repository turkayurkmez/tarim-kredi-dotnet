// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Hello, World!");

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
        Console.WriteLine($"Gelen mesaj: {message}");
    };

    channel.BasicConsume(queue: "my_queue", autoAck: true, consumer: consumer);


    Console.ReadLine();
}
