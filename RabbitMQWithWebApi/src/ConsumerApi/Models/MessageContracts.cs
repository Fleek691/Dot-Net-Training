namespace ConsumerApi.Models;

public sealed record RabbitMessage(
    Guid Id,
    string Sender,
    string Text,
    DateTimeOffset SentAtUtc);
