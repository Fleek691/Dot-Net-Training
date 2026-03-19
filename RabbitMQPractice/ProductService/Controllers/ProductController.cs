using RabbitMQ.Client;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ProductService.Model;
using RabbitMQ.Client;
namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Bike", Price = 50000 },
            new Product { Id = 2, Name = "Phone", Price = 20000 }
        };
        [HttpGet]
        public async Task<List<Product>> GetProducts()
        {
            return products.ToList();
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMessage()
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

            var message = "Hello from Product Service";
            var body = Encoding.UTF8.GetBytes(message);

            await channel.BasicPublishAsync(
                exchange: "",
                routingKey: "testqueue",
                body: body);

            return Ok("Message sent to RabbitMQ");
        }
    }

}