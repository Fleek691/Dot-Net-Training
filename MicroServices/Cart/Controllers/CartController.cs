using Cart.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCart()
        {
            var cart = new List<CartItem>
        {
            new CartItem { ProductId = 1, Quantity = 1 },
            new CartItem { ProductId = 3, Quantity = 2 }
        };

            return Ok(cart);
        }
    }
}
