using Microsoft.AspNetCore.Mvc;
using dog_breed_world.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text.Json;

namespace dog_breed_world.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class Register_Login : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly Context _context;
        private readonly ILogger<Register_Login> _logger;

        public Register_Login(ILogger<Register_Login> logger, Context context, IConfiguration config)
        {
            _logger = logger;
            _context = context;
            _config = config;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user, Example, Example123")]
        public bool LoginWithGoogle(object googJWT)
        {
            Console.WriteLine(googJWT);
            return true;
        }
    [HttpPost]
    [Route("login")]
    public IResult Login(UserLogin user)
        {
          if(!string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.Password))
          {

        User? loggedInUser = _context.Users.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);

        if (loggedInUser is null)
              {
                  return Results.Problem("No user found", "login instance", 403);
              }

              Claim[] claims = new[]
                    {
                      new Claim(ClaimTypes.NameIdentifier, loggedInUser.Username),
                      new Claim(ClaimTypes.Email, loggedInUser.EmailAddress),
                      new Claim(ClaimTypes.GivenName, loggedInUser.GivenName),
                      new Claim(ClaimTypes.Surname, loggedInUser.Surname),
                      new Claim(ClaimTypes.Role, loggedInUser.Role)
                    };

        JwtSecurityToken token = new JwtSecurityToken
          (
              issuer: _config["Jwt:Issuer"],
              audience: _config["Jwt:Audience"],
              claims: claims,
              expires: DateTime.UtcNow.AddDays(7),
              notBefore: DateTime.UtcNow,
              signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])),
              SecurityAlgorithms.HmacSha256)
          );

          string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return Results.Ok(tokenString);
          }
      return Results.Problem();
        }

    }
}
