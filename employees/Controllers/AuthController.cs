using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    IConfiguration _configuration;
    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // GET: api/Employee
    [HttpPost]
    public IActionResult Auth([FromBody] User user)
    {
        IActionResult response = Unauthorized();

        if (user != null)
        {
            if (user.UserName.Equals("random@gmail.com") && user.Password.Equals("strongpassword"))
            {
                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];
                var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
                var signingCredentials = new SigningCredentials(
                                new SymmetricSecurityKey(key),
                                SecurityAlgorithms.HmacSha512Signature
                                );

                var subject = new ClaimsIdentity(new[]
                    {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                });


                var expires = DateTime.UtcNow.AddMinutes(10);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = subject,
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = signingCredentials
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                
                var token = tokenHandler.CreateToken(tokenDescriptor);
                
                var jwtToken = tokenHandler.WriteToken(token);

                  var authToken = new AuthToken
                {
                    Token = jwtToken
                };

                return Ok(authToken);

            }

        }

        return response;
    }
}


public class AuthToken 
{
    public string Token { get; set;}
}
