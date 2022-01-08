using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ShopFolio.Api.Services
{
    public class AccountsService
    {
        private readonly IConfiguration configuration;

        public AccountsService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public JwtSecurityToken CreateJwtToken(string userId)
        {
            var issuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["Jwt:Key"])
            );
            var tokenExpiration = Int32.Parse(configuration["Jwt:Expire"]);
            var issuer = configuration["Jwt:Issuer"];
            var audience = configuration["Jwt:Audience"];
            return new JwtSecurityToken(issuer, audience, GetTokenClaims(userId), DateTime.Now,
                            DateTime.Now.AddMinutes(tokenExpiration), new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha512));

        }
        private IEnumerable<Claim> GetTokenClaims(string userId)
        {
            return new List<Claim>{
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString())
            };
        }
    }
}