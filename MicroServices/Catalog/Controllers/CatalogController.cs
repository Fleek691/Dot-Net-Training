using Catalog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("api/catalog")]
    public class CatalogController : ControllerBase
    {
        [HttpGet("products")]
        public IActionResult GetProducts()
        {
            var products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 70000 },
            new Product { Id = 2, Name = "Phone", Price = 30000 },
            new Product { Id = 3, Name = "Headphones", Price = 2000 }
        };

            return Ok(products);
        }
    }
}
