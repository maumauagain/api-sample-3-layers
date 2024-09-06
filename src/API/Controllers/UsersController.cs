using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Authorize]
    public async Task<IEnumerable<User>> GetAll()
    {
        return await _userService.GetAll();
    }

    [HttpGet("/users/{id}")]
    [Authorize(Roles = "User")]
    public async Task<User> GetById(Guid id)
    {
        return await _userService.GetById(id);
    }

    [HttpPost]
    public async Task<IActionResult> Post(User user)
    {
        await _userService.Add(user);
        return Ok(user);
    }

    [HttpPut]
    public async Task<IActionResult> Put(User user)
    {
        await _userService.Update(user);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete (Guid id)
    {
        await _userService.Delete(id);
        return Ok();
    }
}
