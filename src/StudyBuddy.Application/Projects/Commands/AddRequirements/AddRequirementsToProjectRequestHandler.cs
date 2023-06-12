using System.Security.Claims;
using StudyBuddy.Application.Services;
using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Shared.Application.Interfaces;
using StudyBuddy.Shared.Exceptions.Projects.NotFound;
using StudyBuddy.Shared.Exceptions.Responses;

namespace StudyBuddy.Application.Projects.Commands.AddRequirements;

public class AddRequirementsToProjectRequestHandler
    : ICommandHandler<AddRequirementsToProjectRequest>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddRequirementsToProjectRequestHandler(
        IProjectRepository projectRepository,
        IUnitOfWork unitOfWork)
    {
        _projectRepository = projectRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        AddRequirementsToProjectRequest request,
        CancellationToken cancellationToken)
    {
        var claims = request.GetClaims();
        var userId = claims.FirstOrDefault(x => x.Type == "userId")?.Value;
        var role = claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var isAdminOrTeacher = role is "admin" or "teacher";

        if (userId is null && !isAdminOrTeacher)
        {
            throw new UnauthorizedException();
        }

        var project = await _projectRepository
            .GetByIdAsync(new ProjectId(request.ProjectId), cancellationToken);
        
        if (project is null)
        {
            throw new ProjectNotFoundException(request.ProjectId.ToString());
        }
        
        var userMembership = project.Team.Memberships.FirstOrDefault(x => x.UserId.Value.ToString() == userId);

        if (userMembership is null && !isAdminOrTeacher)
        {
            throw new Exception("NotTeamMemberException");
        }

        if (userMembership?.UserId != project.Team.GetLeader().UserId && !isAdminOrTeacher)
        {
            throw new Exception("NotTeamLeaderException");
        }

        var validRequirements = request.Requirements
            .Select(r => new ProjectRequirement(r.Name, r.Description));
        
        project.AddRequirements(validRequirements);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}