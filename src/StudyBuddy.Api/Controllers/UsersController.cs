using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudyBuddy.Application.Users.Commands.ChangeEmail;
using StudyBuddy.Application.Users.Commands.ChangePassword;
using StudyBuddy.Application.Users.Commands.Delete;
using StudyBuddy.Application.Users.Commands.Update;
using StudyBuddy.Application.Users.Queries.GetAll;
using StudyBuddy.Application.Users.Queries.GetById;
using StudyBuddy.Shared.API;

namespace StudyBuddy.Api.Controllers;

[ApiController]
[Route("api")]
[Authorize]
public sealed class UsersController : ApiController
{
    public UsersController(ISender sender) : base(sender)
    {
    }

    [HttpGet("users/{Id}")]
    public async Task<IResult> GetUserById([FromRoute] GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var userDto = await Sender.Send(request, cancellationToken);
        return Results.Ok(userDto);
    }
    
    [HttpGet("users/all")]
    public async Task<IResult> GetAllUsers([FromRoute] GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        var userDtos = await Sender.Send(request, cancellationToken);
        return Results.Ok(userDtos);
    }

    [HttpDelete("users")]
    public async Task<IResult> DeleteUser([FromBody] DeleteUserRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.NoContent();
    }
    
    [HttpPut("users/email")]
    public async Task<IResult> ChangeEmail([FromBody] ChangeEmailRequest request, CancellationToken cancellationToken)
    {
       await Sender.Send(request, cancellationToken);
       return Results.Ok();
    }
    
    [HttpPut("users/password")]
    public async Task<IResult> ChangePassword([FromBody] ChangePasswordRequest request, CancellationToken cancellationToken)
    {
       await Sender.Send(request, cancellationToken);
       return Results.Ok();
    }
    
    
    [HttpPut("users")]
    public async Task<IResult> ChangeFirstname([FromBody] UpdateUserRequest request, CancellationToken cancellationToken)
    {
       await Sender.Send(request, cancellationToken);
       return Results.Ok();
    }
}