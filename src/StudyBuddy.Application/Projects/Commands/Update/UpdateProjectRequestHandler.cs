using StudyBuddy.Application.Services;
using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Shared.Application.Interfaces;

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

        var project = await _projectRepository.GetByIdAsync(request.ProjectId);

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