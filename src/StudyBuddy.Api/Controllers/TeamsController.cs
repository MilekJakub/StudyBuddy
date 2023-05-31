using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudyBuddy.Application.Teams.Commands.AddMember;
using StudyBuddy.Application.Teams.Commands.ChangeLeader;
using StudyBuddy.Application.Teams.Commands.ChangeName;
using StudyBuddy.Application.Teams.Commands.Create;
using StudyBuddy.Application.Teams.Commands.Delete;
using StudyBuddy.Application.Teams.Commands.GetMembers;
using StudyBuddy.Application.Teams.Commands.KickMember;
using StudyBuddy.Application.Teams.Queries;
using StudyBuddy.Application.Teams.Queries.GetAll;
using StudyBuddy.Application.Teams.Queries.GetById;
using StudyBuddy.Shared.API;

namespace StudyBuddy.Api.Controllers;

[ApiController]
[Route("api")]
public sealed class TeamsController : ApiController
{
    public TeamsController(ISender sender) : base(sender)
    {
    }
    
    [HttpGet("teams")]
    public async Task<IResult> GetTeamById([FromBody] GetTeamByIdRequest request, CancellationToken cancellationToken)
    {
        var teamDto = await Sender.Send(request, cancellationToken);
        return Results.Ok(teamDto);
    }
    
    [HttpGet("teams/all")]
    public async Task<IResult> GetAllTeams([FromBody] GetAllTeamsRequest request, CancellationToken cancellationToken)
    {
        var teamDtos = await Sender.Send(request, cancellationToken);
        return Results.Ok(teamDtos);
    }

    [HttpPost("teams")]
    public async Task<IResult> CreateTeam([FromBody] CreateTeamRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.Created(request.Id.ToString(), null);
    }
    
    [HttpDelete("teams")]
    public async Task<IResult> DeleteTeam([FromBody] DeleteTeamRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.NoContent();
    }
    
    
    [HttpPut("teams/leader")]
    public async Task<IResult> ChangeLeader(ChangeTeamLeaderRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.Ok();
    }

    [HttpPut("teams/name")]
    public async Task<IResult> ChangeName(ChangeTeamNameRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.Ok();
    }

    [HttpGet("teams/members")]
    public async Task<IResult> GetMembers(GetTeamMembersRequest request, CancellationToken cancellationToken)
    {
        var memberDtos = await Sender.Send(request, cancellationToken);
        return Results.Ok(memberDtos);
    }
    
    [HttpPost("teams/members/{Id}")]
    public async Task<IResult> AddMember([FromBody] AddMemberToTeamRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.Ok();
    }
    
    [HttpDelete("teams/members/{Id}")]
    public async Task<IResult> KickMember([FromBody] KickTeamMemberRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.Ok();
    }

    [HttpGet("teams/projects")]
    public async Task<IResult> GetProjects([FromBody] GetProjectsRequest request, CancellationToken cancellationToken)
    {
        var projectDtos = await Sender.Send(request, cancellationToken);
        return Results.Ok(projectDtos);
    }
}
