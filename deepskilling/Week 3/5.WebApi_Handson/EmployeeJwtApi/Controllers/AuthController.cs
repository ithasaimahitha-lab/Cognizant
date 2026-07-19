using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeJwtApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    [HttpGet("token")]
    public IActionResult GetToken([FromQuery] int userId = 1, [FromQuery] string userRole = "Admin")
    {
        var token = GenerateJSONWebToken(userId, userRole);
        return Ok(new { token });
    }

    private string GenerateJSONWebToken(int userId, string userRole)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperdupersecretkeyforjwt12345"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Role, userRole),
            new Claim("UserId", userId.ToString())
        };

        var token = new JwtSecurityToken(
            issuer: "mySystem",
            audience: "myUsers",
            claims: claims,
            expires: DateTime.Now.AddMinutes(10),   // change to 2 minutes for expiry test
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}