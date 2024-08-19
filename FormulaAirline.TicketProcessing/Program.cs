// See https://aka.ms/new-console-template for more information

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Welcome to the ticketing service");

var factory = new ConnectionFactory
{
    HostName = "localhost",
    UserName = "guest",
    Password = "wad*dr=9RlGl",
    VirtualHost = "/"
};

IConnection conn = factory.CreateConnection();
using var channel = conn.CreateModel();
channel.QueueDeclare("booking", durable: true, exclusive: false);
var consumer = new EventingBasicConsumer(channel);

consumer.Received += (sender, args) =>
{
    //getting my byte[]
    var body = args.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"New ticket processing is initiated for - {message}");
};

channel.BasicConsume("booking", autoAck: true, consumer: consumer);
Console.ReadKey();