using handydandy.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace handydandy.Helpers
{
    public class GenerateJWT
    {

        private readonly IConfiguration _configuration;

        public GenerateJWT(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateJWTToken(User user)
        {
            var claims = new List<Claim> {
        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
        new Claim(ClaimTypes.Email, user.Email),
    };
            var jwtToken = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(30),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                       Encoding.UTF8.GetBytes(_configuration["ApplicationSettings:JWT_Secret"])
                        ),
                    SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }


        //version for tradesman login
        public string GenerateJWTToken_Tradesman(Tradesman tradesman)
        {
            var claims = new List<Claim> {
        new Claim(ClaimTypes.NameIdentifier, tradesman.TradesmanId.ToString()),
        new Claim(ClaimTypes.Email, tradesman.Email),
    };
            var jwtToken = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(30),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                       Encoding.UTF8.GetBytes(_configuration["ApplicationSettings:JWT_Secret"])
                        ),
                    SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

    }
}
