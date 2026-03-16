using Microsoft.AspNetCore.Mvc;

namespace Home.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Home Service Running");
        }
    }
}
