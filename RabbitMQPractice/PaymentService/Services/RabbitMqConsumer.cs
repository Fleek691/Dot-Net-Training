using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace PaymentService.Services
{
    public class RabbitMqConsumer : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            var connection = await factory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(
                queue: "paymentqueue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine($"💰 Payment processed for: {message}");

                await Task.CompletedTask;
            };

            await channel.BasicConsumeAsync(
                queue: "paymentqueue",
                autoAck: true,
                consumer: consumer);
        }
    }
}