using ArcheryHub.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ArcheryHub.Core.Entities.Users;

namespace ArcheryHub.Api.Controllers;


[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{

    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] User user)
    {
        var userId = await _userService.RegisterUserAsync(user);

        return Ok(new {UserId = userId});

    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _userService.LoginAsync(request.Identifier);
        return Ok(user);
    }

    [HttpGet("{userId}/performance")]
    public async Task<IActionResult> GetPerformance([FromRoute] int userId)
    {
        var performance = await _userService.GetUserPerformanceAsync(userId);
        return Ok(performance);
    }

    [HttpGet("{userId}/stats")]
    public async Task<IActionResult> GetYearlyStats([FromRoute] int userId, [FromQuery] int year)
    {
        var stats = await _userService.GetUserYearlyStatsAsync(userId, year);
        return Ok(stats);
    }
    
    
    
    public class LoginRequest
    {
        public string Identifier { get; set; } = string.Empty;
    }
    

}