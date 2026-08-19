using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taskflow.Application.User;
using Taskflow.Application.User.DTO;

namespace Taskflow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class UserController(IUserService userService) : ControllerBase
{
  private readonly IUserService _userService = userService;


  [HttpPost("register")]
  public async Task<IActionResult> Register(RegisterRequest request)
  {
    var result = await _userService.CreateUserAsync(request);
    return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
  }

  [Authorize]
  [HttpGet("{id:guid}")]
  public async Task<IActionResult> GetById(Guid id)
  {
    UserResponse result = await _userService.GetByIdAsync(id);
    return Ok(result);
  }

  [Authorize]
  [HttpGet("")]
  public async Task<IActionResult> GetAll()
  {
    List<UserResponse> result = await _userService.GetAllAsync();
    return Ok(result);
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login(LoginRequest request)
  {
    UserResponse result = await _userService.LoginAsync(request);
    return Ok(result);
  }
}
