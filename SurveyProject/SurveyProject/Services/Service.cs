using Microsoft.IdentityModel.Tokens;
using SurveyProject.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace SurveyProject.Services
{
    public  class Service
    {
        private readonly string? _secretKey;
        private readonly string? _application;
        private readonly string? _user;

        public Service(IConfiguration configuration)
        {
            _secretKey = configuration["JwtSettings:secretKey"];
            _application = configuration["JwtSettings:application"];
            _user = configuration["JwtSettings:user"];
        }


        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim("UserId", user.Id.ToString()),
            new Claim("AuthMenu", user.UserType.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey.PadRight(256/8)));
            var creds=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                
                _application,
                _user,
                claims,
                expires:DateTime.Now.AddHours(1),
                signingCredentials:creds
                
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

            



         }
           
        public ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _application,
                    ValidAudience = _user,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_secretKey))
                }, out _);

                return principal;
            }
            catch
            {
                return null;

            }
        }
    }
}
