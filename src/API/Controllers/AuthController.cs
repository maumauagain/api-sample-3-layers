using API.Auth;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;
    private readonly IUserService _userService;

    public AuthController(AuthService authService, IUserService userService)
    {
        _authService = authService;
        _userService = userService;
    }
    [HttpPost("/authenticate")]
    public async Task<IActionResult> Post([FromBody] LoginRequest login)
    {
        var user = (await _userService.Get(u => u.Email == login.Email && u.Password == login.Password)).ToList().FirstOrDefault();
        if (user == null) return NotFound();

        return Ok(_authService.GenerateToken(user));
    }
}

public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}
