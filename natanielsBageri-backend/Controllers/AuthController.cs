using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Ganss.Xss;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using mormorsBageri.Entities;
using mormorsBageri.ViewModels;

namespace mormorsBageri.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(UserManager<User> userManager, IConfiguration config) : ControllerBase
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IConfiguration _config = config;

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        try
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return Unauthorized(new { success = false, message = "Unauthorized" });
            }
            return Ok(new { succes = true, user.UserName, token = CreateToken(user) });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { success = false, message = ex.Message });
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(RegisterUserViewModel model)
    {
        var sanitizer = new HtmlSanitizer();
        try
        {
            var user = new User
            {
                UserName = model.UserName,
                Email = model.UserName,
                FirstName = sanitizer.Sanitize(model.FirstName),
                LastName = sanitizer.Sanitize(model.LastName)
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return StatusCode(201);
            }
            return BadRequest(new { success = false, message = result.Errors });

        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }

    /* TOKEN SERVICE... */
    private string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Email, user.Email!),
            new(ClaimTypes.Name, user.UserName!),
            new("FirstName", user.FirstName),
            new("LastName", user.LastName)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["tokenSettings:tokenKey"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var options = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            expires: DateTime.Now.AddDays(10),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(options);
    }
}
