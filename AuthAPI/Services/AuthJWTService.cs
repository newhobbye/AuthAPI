using AuthAPI.Interfaces;
using AuthAPI.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthAPI.Services
{
    public class AuthJWTService : IAuthJWTService
    {
        private readonly TokenManagement _tokenManagement;
        private readonly IUserService _userService;

        public AuthJWTService(IOptions<TokenManagement> tokenManagement, IUserService userService)
        {
            _tokenManagement = tokenManagement.Value;
            _userService = userService;
        }

        public bool IsAuthenticated(UserViewModel user, out string token)
        {
            token = string.Empty;

            if (_userService.ValidateUser(user) is false) return false;

            var claim = new[] //cria o payload
            {
                new Claim("name", user.UserName)
            };

            //header com signature
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret)); //pega a secret e encoda
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); //assina e criptografa a secret

            var jwtToken = new JwtSecurityToken(_tokenManagement.Issuer, _tokenManagement.Audience, claim, //cria o token
                    expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration), signingCredentials: credentials);

            token = new JwtSecurityTokenHandler().WriteToken(jwtToken); //transforma ele em string

            return true;
        }

    }
}
