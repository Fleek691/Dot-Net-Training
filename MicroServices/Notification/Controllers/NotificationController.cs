using Microsoft.AspNetCore.Mvc;

namespace Notification.Controllers
{
    [ApiController]
    [Route("api/notification")]
    public class NotificationController : ControllerBase
    {
        [HttpPost("send")]
        public IActionResult SendNotification()
        {
            return Ok("Notification Sent");
        }
    }   
}
