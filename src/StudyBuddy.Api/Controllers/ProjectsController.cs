using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudyBuddy.Application.Projects.Commands.AddLanguages;
using StudyBuddy.Application.Projects.Commands.AddRequirements;
using StudyBuddy.Application.Projects.Commands.AddTechnologies;
using StudyBuddy.Application.Projects.Commands.Create;
using StudyBuddy.Application.Projects.Commands.Delete;
using StudyBuddy.Application.Projects.Commands.RemoveLanguages;
using StudyBuddy.Application.Projects.Commands.RemoveRequirements;
using StudyBuddy.Application.Projects.Commands.RemoveTechnologies;
using StudyBuddy.Application.Projects.Commands.Update;
using StudyBuddy.Application.Projects.Queries.GetAll;
using StudyBuddy.Application.Projects.Queries.GetById;
using StudyBuddy.Application.Projects.Queries.GetLanguages;
using StudyBuddy.Application.Projects.Queries.GetRequirements;
using StudyBuddy.Application.Projects.Queries.GetTechnologies;
using StudyBuddy.Shared.API;

namespace StudyBuddy.Api.Controllers;

[ApiController]
[Route("api")]
public sealed class ProjectsController : ApiController
{
    public ProjectsController(ISender sender) : base(sender)
    {
    }
    
    [HttpGet("projects/{Id}")]
    public async Task<IResult> GetProjectById([FromRoute] GetProjectByIdRequest request, CancellationToken cancellationToken)
    {
        var projectDto = await Sender.Send(request, cancellationToken);
        return Results.Ok(projectDto);
    }
    
    [HttpGet("projects/all")]
    public async Task<IResult> GetAllProjects([FromRoute] GetAllProjectsRequest request, CancellationToken cancellationToken)
    {
        var projectDtos = await Sender.Send(request, cancellationToken);
        return Results.Ok(projectDtos);
    }

    [HttpPost("projects")]
    public async Task<IResult> CreateTeam([FromBody] CreateProjectRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.Created($"{request.GetId}", null);
    }
    
    [HttpDelete("projects")]
    public async Task<IResult> DeleteTeam([FromBody] DeleteProjectRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.NoContent();
    }
    
    [HttpPut("projects")]
    public async Task<IResult> UpdateTeam([FromBody] UpdateProjectRequest request, CancellationToken cancellationToken)
    {
        await Sender.Send(request, cancellationToken);
        return Results.Ok();
    }
    
    [HttpGet("projects/requirements/{ProjectId}")]
    public async Task<IResult> GetRequirements([FromRoute] GetProjectRequirementsRequest request, CancellationToken cancellationToken)
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
    
    [HttpGet("projects/languages/{ProjectId}")]
    public async Task<IResult> GetProgrammingLanguages([FromRoute] GetProjectProgrammingLanguagesRequest request, CancellationToken cancellationToken)
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
    
    [HttpGet("projects/technologies/{ProjectId}")]
    public async Task<IResult> GetTechnologies([FromRoute] GetProjectTechnologiesRequest request, CancellationToken cancellationToken)
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
