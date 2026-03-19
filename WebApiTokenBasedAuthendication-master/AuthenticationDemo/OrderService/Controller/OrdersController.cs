using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetOrders()
        {
            var userName = User.FindFirstValue(ClaimTypes.Name) ?? User.Identity?.Name ?? "AuthenticatedUser";

            return Ok(new
            {
                Message = "JWT consumed successfully from AuthServer",
                User = userName,
                Orders = new[]
                {
                    new { Id = 1001, Product = "Laptop", Quantity = 1 },
                    new { Id = 1002, Product = "Keyboard", Quantity = 2 }
                }
            });
        }
    }
}
