using Microsoft.AspNetCore.Mvc;
using dog_breed_world.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text.Json;
using System.Web.Helpers;
using System.Text.RegularExpressions;

namespace dog_breed_world.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class Register_Login : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly Context _context;
        private readonly ILogger<Register_Login> _logger;

        // Regex patterns
        private readonly string emailPattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        private readonly string usernamePattern = "^[a-zA-Z0-9]+$";
        private readonly string namePattern = @"/^[A-Za-z\x{00C0}-\x{00FF}][A-Za-z\x{00C0}-\x{00FF}\'\-]+([\ A-Za-z\x{00C0}-\x{00FF}][A-Za-z\x{00C0}-\x{00FF}\'\-]+)*/u";
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
    [Route("register")]
    public IResult Register(User user)
    {
      try
        {
        // backend validation for required values
              if(
                Regex.IsMatch(user.EmailAddress, emailPattern) &&
                Regex.IsMatch(user.Username, usernamePattern) &&
                Regex.IsMatch(user.GivenName, namePattern) &&
                Regex.IsMatch(user.Surname, namePattern)
                )
                  {
                    string rng = Crypto.GenerateSalt(16);
                    user.Id = null;
                    user.createdAt = DateTime.Now;
                    user.updatedAt = DateTime.Now;
                    user.Role = "user";
                    user.Salt = rng.ToString();
                    user.Hash = Crypto.Hash(user.Password + rng);
                    User? userCheck = _context.Users.FirstOrDefault(x => x.Username == user.Username || x.EmailAddress == user.EmailAddress);
                    if(userCheck != null)
                    {
                      _context.Add(user);
                      _context.SaveChanges();
                      Console.WriteLine(user.Salt);
                      return Results.Accepted();
                    }
                    return Results.Problem("Username or Email already in database", "register instance", 403);
                  }
              return Results.Problem("Entries did not follow requirements", "register instance", 403);
        }
      catch (Exception ex)
      {
        return Results.Problem($"Error: {ex.Message} ", "register instance", 500);
      }
      
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
