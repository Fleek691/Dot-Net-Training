using System.Text;
using System.Text.Json;
using ConsumerApi.Models;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
namespace ConsumerApi.Services;

public sealed class RabbitMqConsumerService : BackgroundService
{
    private readonly ILogger<RabbitMqConsumerService> _logger;
    private readonly ReceivedMessageStore _store;
    private readonly RabbitMqOptions _options;
    private IConnection? _connection;
    private IModel? _channel;

    public RabbitMqConsumerService(
        ILogger<RabbitMqConsumerService> logger,
        ReceivedMessageStore store,
        IOptions<RabbitMqOptions> options)
    {
        _logger = logger;
        _store = store;
        _options = options.Value;
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
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
        _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

        return base.StartAsync(cancellationToken);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (_channel is null)
        {
            throw new InvalidOperationException("RabbitMQ channel has not been initialized.");
        }

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (_, ea) =>
        {
            var json = Encoding.UTF8.GetString(ea.Body.ToArray());
            var message = JsonSerializer.Deserialize<RabbitMessage>(json);

            if (message is null)
            {
                _logger.LogWarning("Received an invalid message payload: {Payload}", json);
                _channel.BasicNack(ea.DeliveryTag, multiple: false, requeue: false);
                return;
            }

            _store.Add(message);
            _logger.LogInformation("Received message {MessageId} from {Sender}", message.Id, message.Sender);
            _channel.BasicAck(ea.DeliveryTag, multiple: false);
        };

        _channel.BasicConsume(_options.QueueName, autoAck: false, consumer);
        return Task.Delay(Timeout.Infinite, stoppingToken);
    }

    public override void Dispose()
    {
        _channel?.Dispose();
        _connection?.Dispose();
        base.Dispose();
    }
}
