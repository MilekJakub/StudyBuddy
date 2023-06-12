using System.Security.Claims;
using StudyBuddy.Application.Services;
using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Shared.Application.Interfaces;
using StudyBuddy.Shared.Exceptions.Projects.NotFound;
using StudyBuddy.Shared.Exceptions.Responses;

namespace StudyBuddy.Application.Projects.Commands.Update;

public class UpdateProjectRequestHandler
    : ICommandHandler<UpdateProjectRequest>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProjectRequestHandler(
        IProjectRepository projectRepository,
        IUnitOfWork unitOfWork)
    {
        _projectRepository = projectRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        UpdateProjectRequest request,
        CancellationToken cancellationToken)
    {
        if (!IsValid(request))
        {
            throw new Exception("Cannot update the project. No values provided.");
        }
        
        var claims = request.GetClaims();
        var userId = claims.FirstOrDefault(x => x.Type == "userId")?.Value;
        var role = claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var isAdminOrTeacher = role is "admin" or "teacher";

        if (userId is null && !isAdminOrTeacher)
        {
            throw new UnauthorizedException();
        }

        var project = await _projectRepository.GetByIdAsync(new ProjectId(request.ProjectId));

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

        if (request.Topic is not null)
        {
            project.ChangeTopic(new ProjectTopic(request.Topic));
        }

        if (request.Description is not null)
        {
            project.ChangeDescription(new ProjectDescription(request.Description));
        }

        if (request.EstimatedTimeToFinish is not null)
        {
            project.ChangeEstimatedTimeToFinish(
                new EstimatedTime(
                    request.EstimatedTimeToFinish.Days,
                    request.EstimatedTimeToFinish.Hours,
                    request.EstimatedTimeToFinish.Minutes,
                    request.EstimatedTimeToFinish.Seconds));
        }
        
        if (request.Deadline is not null)
        {
            project.ChangeDeadline(new Deadline(request.Deadline.Value));
        }

        if (request.DifficultyId is not null)
        {
            var difficulty = await _projectRepository
                .GetDifficultyByIdAsync((byte) request.DifficultyId, cancellationToken);

            project.ChangeDifficulty(difficulty);
        }

        if (request.StateId is not null)
        {
            var state = await _projectRepository
                .GetDifficultyByIdAsync((byte) request.StateId, cancellationToken);

            project.ChangeDifficulty(state);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public static bool IsValid(object? value)
    {
        if (value == null)
            return false;

        var typeInfo = value.GetType();

        var propertyInfo = typeInfo.GetProperties();

        return propertyInfo.Any(property => property.GetValue(value) is not null);
    }
}