using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudyBuddy.Application.Services;
using StudyBuddy.Application.Users.Commands.Login;
using StudyBuddy.Application.Users.Commands.Register;
using StudyBuddy.Shared.API;

namespace StudyBuddy.Api.Controllers;

[ApiController]
[Route("api")]
public sealed class AuthController : ApiController
{
    public AuthController(ISender sender) : base(sender)
    {
    }
    
    [HttpPost("auth/register")]
    public async Task<IResult> RegisterUser([FromBody] RegisterUserRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        var response = new RegisterUserResponse(request.GetId().Value, request.GetToken());
        return Results.Ok(response);
    }
    
    [HttpPost("auth/login")]
    public async Task<IResult> Login([FromBody] LoginUserRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        var response = new LoginUserResponse(request.GetToken());
        return Results.Ok(response);
    }
}