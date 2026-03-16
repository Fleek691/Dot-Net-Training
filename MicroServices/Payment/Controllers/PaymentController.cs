using Microsoft.AspNetCore.Mvc;

namespace Payment.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : ControllerBase
    {
        [HttpPost("pay")]
        public IActionResult MakePayment()
        {
            return Ok(new
            {
                Status = "Success",
                Message = "Payment Completed"
            });
        }
    }
}
