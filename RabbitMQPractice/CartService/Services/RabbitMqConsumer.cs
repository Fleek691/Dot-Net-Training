using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace CartService.Services
{


    public class RabbitMqConsumer : BackgroundService
    {
        private static List<string> cart = new List<string>();
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
                queue: "testqueue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                cart.Add(message);

                Console.WriteLine($"Received in Cart Service: {cart.Count}");

                await Task.CompletedTask;

                await channel.QueueDeclareAsync(
                queue: "paymentqueue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

                var paymentMessage = Encoding.UTF8.GetBytes(message);

                await channel.BasicPublishAsync(
                    exchange: "",
                    routingKey: "paymentqueue",
                    body: paymentMessage);

                Console.WriteLine("Sent to Payment Service");
            };

            await channel.BasicConsumeAsync(
                queue: "testqueue",
                autoAck: true,
                consumer: consumer);
        }
    }
}