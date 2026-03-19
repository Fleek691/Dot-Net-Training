using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApiTokenBasedAuthendication.Controllers
{
    [ApiController]
    [Route("api/Authendication")]
    public class AuthendicationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthendicationController(IConfiguration configuration)
        {
            this._configuration = configuration?? throw new ArgumentNullException(nameof(configuration));
        }
        public class AuthendicateionRequestBody
        {
            public string? UserName { get; set; }
            public string? Password { get; set; }
        }

        private class RequestedUserinfo
        {
            public int UserId { get; set; }
            public string? UserName { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string City { get; set; }

            public RequestedUserinfo(int userId, string? userName, string? firstName, string? lastName, string city)
            {
                UserId = userId;
                UserName = userName;
                FirstName = firstName;
                LastName = lastName;
                City= city;
            }
        }

        [HttpPost("authendicate")]
        public ActionResult<string> Authendicate(AuthendicateionRequestBody authendicateionRequestBody)
        {
            var user = ValidateUserCredentials(authendicateionRequestBody.UserName, authendicateionRequestBody.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authendication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim> ();
            claimsForToken.Add(new Claim("sub",user.UserId.ToString()));
            claimsForToken.Add(new Claim("given_name", user.FirstName));
            claimsForToken.Add(new Claim("family_name", user.LastName));
            claimsForToken.Add(new Claim("city",user.City));
            
            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authendication:Issuer"],
                _configuration["Authendication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials);
           
            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);

        }

        private RequestedUserinfo ValidateUserCredentials(string? userName, string? password)
        {
            return new RequestedUserinfo(1,"Mr.X","FirestName","LastName","Acity");
        }
    }
}