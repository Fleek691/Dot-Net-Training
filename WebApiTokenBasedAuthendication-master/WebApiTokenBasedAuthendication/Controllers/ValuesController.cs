using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTokenBasedAuthendication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PeopleController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> GetPeople()
        {
            return Ok("Authedicated users Senthil,Nagaraj,Muthraj");
        }
    }
}
