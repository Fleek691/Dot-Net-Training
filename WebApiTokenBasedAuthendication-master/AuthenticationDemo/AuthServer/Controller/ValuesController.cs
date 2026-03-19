using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ValuesController : ControllerBase
    {
        public string GetToken()
        {
            string bodyContent = new StreamReader(Request.Body).ReadToEnd();
            return DateTime.Now.ToString();
        }
    }
}
