namespace ProducerApi.Services;

public sealed class RabbitMqOptions
{
    public const string SectionName = "RabbitMq";

    public string HostName { get; init; } = "localhost";
    public int Port { get; init; } = 5672;
    public string UserName { get; init; } = "guest";
    public string Password { get; init; } = "guest";
    public string ExchangeName { get; init; } = "demo.exchange";
    public string QueueName { get; init; } = "demo.queue";
    public string RoutingKey { get; init; } = "demo.message";
}
