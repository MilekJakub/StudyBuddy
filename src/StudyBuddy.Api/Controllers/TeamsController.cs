using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudyBuddy.Application.Teams.Commands.AddMember;
using StudyBuddy.Application.Teams.Commands.ChangeLeader;
using StudyBuddy.Application.Teams.Commands.Create;
using StudyBuddy.Application.Teams.Commands.Delete;
using StudyBuddy.Application.Teams.Commands.KickMember;
using StudyBuddy.Application.Teams.Commands.Update;
using StudyBuddy.Application.Teams.Queries.GetAll;
using StudyBuddy.Application.Teams.Queries.GetById;
using StudyBuddy.Application.Teams.Queries.GetMembers;
using StudyBuddy.Application.Teams.Queries.GetProjects;
using StudyBuddy.Shared.API;

namespace StudyBuddy.Api.Controllers;

[ApiController]
[Route("api")]
public sealed class TeamsController : ApiController
{
    public TeamsController(ISender sender) : base(sender)
    {
    }
    
    [HttpGet("teams/{Id}")]
    public async Task<IResult> GetTeamById([FromRoute] GetTeamByIdRequest request, CancellationToken cancellationToken)
    {
        var teamDto = await Sender.Send(request, cancellationToken);
        return Results.Ok(teamDto);
    }
    
    [HttpGet("teams/all")]
    public async Task<IResult> GetAllTeams([FromRoute] GetAllTeamsRequest request, CancellationToken cancellationToken)
    {
        var teamDtos = await Sender.Send(request, cancellationToken);
        return Results.Ok(teamDtos);
    }

    [HttpPost("teams")]
    public async Task<IResult> CreateTeam([FromBody] CreateTeamRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.Created($"{request.GetId}", null);
    }
    
    [HttpDelete("teams")]
    public async Task<IResult> DeleteTeam([FromBody] DeleteTeamRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.NoContent();
    }
    
    [HttpPut("teams")]
    public async Task<IResult> ChangeName(UpdateTeamRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.Ok();
    }
    
    [HttpPut("teams/leader")]
    public async Task<IResult> ChangeLeader(ChangeTeamLeaderRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.Ok();
    }

    [HttpGet("teams/members/{TeamId}")]
    public async Task<IResult> GetMembers([FromRoute] GetTeamMembersRequest request, CancellationToken cancellationToken)
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

    [HttpGet("teams/projects/{TeamId}")]
    public async Task<IResult> GetProjects([FromRoute] GetTeamProjectsRequest request, CancellationToken cancellationToken)
    {
        var projectDtos = await Sender.Send(request, cancellationToken);
        return Results.Ok(projectDtos);
    }
}
