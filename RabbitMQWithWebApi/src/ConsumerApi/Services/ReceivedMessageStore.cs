using ConsumerApi.Models;
using System.Collections.Concurrent;

namespace ConsumerApi.Services;

public sealed class ReceivedMessageStore
{
    private readonly ConcurrentQueue<RabbitMessage> _messages = new();

    public void Add(RabbitMessage message) => _messages.Enqueue(message);

    public IReadOnlyCollection<RabbitMessage> GetAll() => _messages.ToArray();
}
