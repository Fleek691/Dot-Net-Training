using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using ProducerApi.Models;
using RabbitMQ.Client;

namespace ProducerApi.Services;

public sealed class RabbitMqPublisher : IDisposable
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly RabbitMqOptions _options;

    public RabbitMqPublisher(IOptions<RabbitMqOptions> options)
    {
        _options = options.Value;

        var factory = new ConnectionFactory
        {
            HostName = _options.HostName,
            Port = _options.Port,
            UserName = _options.UserName,
            Password = _options.Password
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.ExchangeDeclare(_options.ExchangeName, ExchangeType.Direct, durable: true);
        _channel.QueueDeclare(_options.QueueName, durable: true, exclusive: false, autoDelete: false);
        _channel.QueueBind(_options.QueueName, _options.ExchangeName, _options.RoutingKey);
    }

    public RabbitMessage Publish(PublishMessageRequest request)
    {
        var message = new RabbitMessage(
            Guid.NewGuid(),
            request.Sender.Trim(),
            request.Text.Trim(),
            DateTimeOffset.UtcNow);

        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
        var properties = _channel.CreateBasicProperties();
        properties.Persistent = true;
        properties.ContentType = "application/json";

        _channel.BasicPublish(
            exchange: _options.ExchangeName,
            routingKey: _options.RoutingKey,
            basicProperties: properties,
            body: body);

        return message;
    }

    public void Dispose()
    {
        _channel.Dispose();
        _connection.Dispose();
    }
}
