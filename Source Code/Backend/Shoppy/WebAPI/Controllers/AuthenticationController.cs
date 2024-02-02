using System.Runtime.CompilerServices;
using Application.Dtos.Request.User;
using Application.Dtos.Response.User;
using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/v1/authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthenticationController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<LoginUserDto>> Register([FromBody] RegisterDto request)
    {
        var result = await _userService.RegisterAsync(request);
        return CreatedAtAction(nameof(Register), result);
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginUserDto>> Login([FromBody] LoginDto request)
    {
        var result = await _userService.LoginAsync(request);
        return Ok(result);
    }
}