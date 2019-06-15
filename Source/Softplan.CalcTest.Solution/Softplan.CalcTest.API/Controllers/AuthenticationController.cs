using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Softplan.CalcTest.Infrastructure.Configurations;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Softplan.CalcTest.API.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IOptions<KeysConfig> KeyConfiguration;

        public AuthenticationController(IOptions<KeysConfig> keyConfiguration)
            => KeyConfiguration = keyConfiguration;
        
        [HttpPost]
        public IActionResult Create(string email, string password)
        {
            if (ValidateUserPassword(email, password))
                return new ObjectResult(GenarateToken(email));

            return BadRequest();
        }

        private bool ValidateUserPassword(string email, string password) 
            => !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password) && Logon(email, password);

        private bool Logon(string email, string password)
        {
            if (email == password)
                return true;
            else
                return false;
        }

        private string GenarateToken(string email)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, email),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KeyConfiguration.Value.SecretKey)),
                                             SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}