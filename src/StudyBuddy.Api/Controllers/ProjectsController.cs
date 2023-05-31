using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudyBuddy.Application.Projects.Commands.AddProgrammingLanguages;
using StudyBuddy.Application.Projects.Commands.AddRequirements;
using StudyBuddy.Application.Projects.Commands.AddTechnologies;
using StudyBuddy.Application.Projects.Commands.ChangeDeadline;
using StudyBuddy.Application.Projects.Commands.ChangeDescription;
using StudyBuddy.Application.Projects.Commands.ChangeDifficulty;
using StudyBuddy.Application.Projects.Commands.ChangeEstimatedTimeToFinish;
using StudyBuddy.Application.Projects.Commands.ChangeState;
using StudyBuddy.Application.Projects.Commands.ChangeTopic;
using StudyBuddy.Application.Projects.Commands.Create;
using StudyBuddy.Application.Projects.Commands.RemoveProgrammingLanguages;
using StudyBuddy.Application.Projects.Commands.RemoveRequirements;
using StudyBuddy.Application.Projects.Commands.RemoveTechnologies;
using StudyBuddy.Application.Projects.Queries.GetAll;
using StudyBuddy.Application.Projects.Queries.GetById;
using StudyBuddy.Application.Projects.Queries.GetProgrammingLanguages;
using StudyBuddy.Application.Projects.Queries.GetRequirements;
using StudyBuddy.Application.Projects.Queries.GetTechnologies;
using StudyBuddy.Application.Teams.Commands.Delete;
using StudyBuddy.Shared.API;

namespace StudyBuddy.Api.Controllers;

[ApiController]
[Route("api")]
public sealed class ProjectsController : ApiController
{
    public ProjectsController(ISender sender) : base(sender)
    {
    }
    
    [HttpGet("projects")]
    public async Task<IResult> GetProjectById([FromBody] GetProjectByIdRequest request, CancellationToken cancellationToken)
    {
        var projectDto = await Sender.Send(request, cancellationToken);
        return Results.Ok(projectDto);
    }
    
    [HttpGet("projects/all")]
    public async Task<IResult> GetAllProjects([FromBody] GetAllProjectsRequest request, CancellationToken cancellationToken)
    {
        var projectDtos = await Sender.Send(request, cancellationToken);
        return Results.Ok(projectDtos);
    }

    [HttpPost("projects")]
    public async Task<IResult> CreateTeam([FromBody] CreateProjectRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.Created(request.Id.ToString(), null);
    }
    
    [HttpDelete("projects")]
    public async Task<IResult> DeleteTeam([FromBody] DeleteTeamRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.NoContent();
    }
    
    [HttpPut("projects/topic")]
    public async Task<IResult> ChangeTopic([FromBody] ChangeProjectTopicRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.Ok();
    }
    
    [HttpPut("projects/description")]
    public async Task<IResult> ChangeDescription([FromBody] ChangeProjectDescriptionRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.Ok();
    }
    
    [HttpPut("projects/difficulty")]
    public async Task<IResult> ChangeDifficulty([FromBody] ChangeProjectDifficultyRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.Ok();
    }
    
    [HttpPut("projects/estimated-time")]
    public async Task<IResult> ChangeEstimatedTime([FromBody] ChangeProjectEstimatedTimeToFinishRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.Ok();
    }
    
    [HttpPut("projects/deadline")]
    public async Task<IResult> ChangeDeadline([FromBody] ChangeProjectDeadlineRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.Ok();
    }
    
    [HttpPut("projects/state")]
    public async Task<IResult> ChangeState([FromBody] ChangeProjectStateRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.Ok();
    }

    [HttpGet("projects/requirements")]
    public async Task<IResult> GetRequirements([FromBody] GetProjectRequirementsRequest request, CancellationToken cancellationToken)
    {
        var requirementDtos = await Sender.Send(request, cancellationToken);
        return Results.Ok(requirementDtos);
    }
    
    [HttpPost("projects/requirements")]
    public async Task<IResult> AddRequirements([FromBody] AddRequirementsToProjectRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.Ok();
    }
    
    [HttpDelete("projects/requirements")]
    public async Task<IResult> RemoveRequirements([FromBody] RemoveRequirementsFromProjectRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.NoContent();
    }
    
    [HttpGet("projects/languages")]
    public async Task<IResult> GetProgrammingLanguages([FromBody] GetProjectProgrammingLanguagesRequest request, CancellationToken cancellationToken)
    {
        var languageDtos = await Sender.Send(request, cancellationToken);
        return Results.Ok(languageDtos);
    }
    
    [HttpPost("projects/languages")]
    public async Task<IResult> AddProgrammingLanguages([FromBody] AddProgrammingLanguagesToProjectRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.Ok();
    }
    
    [HttpDelete("projects/languages")]
    public async Task<IResult> RemoveProgrammingLanguages([FromBody] RemoveProgrammingLanguagesFromProjectRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.NoContent();
    }
    
    [HttpGet("projects/technologies")]
    public async Task<IResult> GetTechnologies([FromBody] GetProjectTechnologiesRequest request, CancellationToken cancellationToken)
    {
        var technologyDtos = await Sender.Send(request, cancellationToken);
        return Results.Ok(technologyDtos);
    }
    
    [HttpPost("projects/technologies")]
    public async Task<IResult> AddTechnologies([FromBody] AddTechnologiesToProjectRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.Ok();
    }
    
    [HttpDelete("projects/technologies")]
    public async Task<IResult> RemoveTechnologies([FromBody] RemoveTechnologiesFromProjectRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.NoContent();
    }
}
