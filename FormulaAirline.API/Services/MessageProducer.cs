using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace FormulaAirline.API.Services;

public class MessageProducer : IMessageProducer
{
    public void Sendingmessage<T>(T message)
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "wad*dr=9RlGl",
            VirtualHost = "/"
        };

        IConnection conn = factory.CreateConnection();
        using var channel = conn.CreateModel();
        channel.QueueDeclare("booking", true, false);

        var jsonString = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(jsonString);

        channel.BasicPublish("", "booking", body: body);
    }
}