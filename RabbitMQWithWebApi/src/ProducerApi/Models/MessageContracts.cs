namespace ProducerApi.Models;

public sealed record PublishMessageRequest(string Sender, string Text);

public sealed record RabbitMessage(
    Guid Id,
    string Sender,
    string Text,
    DateTimeOffset SentAtUtc);
