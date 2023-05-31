using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudyBuddy.Application.Services;
using StudyBuddy.Application.Users.Commands.LoginUser;
using StudyBuddy.Application.Users.Commands.RegisterUser;
using StudyBuddy.Shared.API;

namespace StudyBuddy.Api.Controllers;

[ApiController]
[Route("api/auth")]
public sealed class AuthController : ApiController
{
    private readonly IAuthService _authService;
    
    public AuthController(ISender sender, IAuthService authService) : base(sender)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IResult> RegisterUser([FromBody] RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var response = await _authService.Register(request, cancellationToken);
        return Results.Created($"/api/users/{response.Id}", null);
    }

    [HttpPost("login")]
    public async Task<IResult> Login([FromBody] LoginUserRequest request, CancellationToken cancellationToken)
    {
        return Results.Ok(await _authService.Login(request, cancellationToken));
    }
}