using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public string INeedToken()
        {
             
            return DateTime.Now.ToString();
        }
    }
}
