using AuthAPI.Interfaces;
using AuthAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthJWTService _auth;

        public AuthController(IAuthJWTService auth)
        {
            _auth = auth;
        }

        [HttpPost]
        public IActionResult GetToken([FromBody] UserViewModel user)
        {
            string token = string.Empty;
            TokenResponseModel tokenResponse = new();

            if (_auth.IsAuthenticated(user, out token) is false) return BadRequest();

            tokenResponse.Token = token;
            tokenResponse.ExpiresIn = 30;

            return Ok(tokenResponse);
        }
    }
}