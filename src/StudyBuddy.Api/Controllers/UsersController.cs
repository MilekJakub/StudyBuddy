using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudyBuddy.Application.Users.Commands.ChangeEmail;
using StudyBuddy.Application.Users.Commands.ChangeFirstname;
using StudyBuddy.Application.Users.Commands.ChangeLastname;
using StudyBuddy.Application.Users.Commands.ChangePassword;
using StudyBuddy.Application.Users.Commands.ChangeRegisterNumber;
using StudyBuddy.Application.Users.Commands.ChangeUsername;
using StudyBuddy.Application.Users.Commands.Delete;
using StudyBuddy.Application.Users.Queries.GetAll;
using StudyBuddy.Application.Users.Queries.GetById;
using StudyBuddy.Shared.API;

namespace StudyBuddy.Api.Controllers;

[ApiController]
[Route("api")]
public sealed class UsersController : ApiController
{
    public UsersController(ISender sender) : base(sender)
    {
    }

    [HttpGet("users")]
    public async Task<IResult> GetUserById([FromBody] GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var userDto = await Sender.Send(request, cancellationToken);
        return Results.Ok(userDto);
    }
    
    [HttpGet("users/all")]
    public async Task<IResult> GetAllUsers([FromBody] GetAllUsersRequest request, CancellationToken cancellationToken)
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
    
    [HttpPut("users/username")]
    public async Task<IResult> ChangeUsername([FromBody] ChangeUsernameRequest request, CancellationToken cancellationToken)
    {
       await Sender.Send(request, cancellationToken);
       return Results.Ok();
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
    
    [HttpPut("users/firstname")]
    public async Task<IResult> ChangeFirstname([FromBody] ChangeFirstnameRequest request, CancellationToken cancellationToken)
    {
       await Sender.Send(request, cancellationToken);
       return Results.Ok();
    }
    
    [HttpPut("users/lastname")]
    public async Task<IResult> ChangeLastname([FromBody] ChangeLastnameRequest request, CancellationToken cancellationToken)
    {
       await Sender.Send(request, cancellationToken);
       return Results.Ok();
    }
    
    [HttpPut("users/register-number")]
    public async Task<IResult> ChangeRegisterNumber([FromBody] ChangeRegisterNumberRequest request, CancellationToken cancellationToken)
    {
       await Sender.Send(request, cancellationToken);
       return Results.Ok();
    }
}