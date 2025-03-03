using Microsoft.AspNetCore.Mvc;
using UserManagment.Managers;
using UserManagment.Models;

namespace UserManagment.Controllers;
using UserManagment.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserManager _userManager;

    public UserController(IUserManager userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("CreateUser")]
    public IActionResult CreateUser(string username, string email)
    {
        var user = new User { Username = username, Email = email };
        _userManager.AddUser(user);
        return Ok($"User {username} created.");
    }

    [HttpDelete("RemoveUser")]
    public IActionResult RemoveUser(Guid userId)
    {
        if (_userManager.GetUser(userId) != null)
        {
            _userManager.DeleteUser(userId);
            return Ok($"User with ID {userId} removed.");
        }
        return NotFound($"User with ID {userId} not found.");
    }

    [HttpGet("ShowUser")]
    public IActionResult ShowUser(Guid userId)
    {
        var user = _userManager.GetUser(userId);
        if (user != null)
        {
            return Ok($"User: {user.Username}, Email: {user.Email}");
        }

        return NotFound("User not found.");
    }

    [HttpGet("ListUsers")]
    public IActionResult ListUsers()
    {
        var users = _userManager.GetAllUsers();
        foreach (var user in users)
        {
            Console.WriteLine($"{user.Id} {user.Username}, {user.Email}");
        }
        return Ok(users);
    }
}
