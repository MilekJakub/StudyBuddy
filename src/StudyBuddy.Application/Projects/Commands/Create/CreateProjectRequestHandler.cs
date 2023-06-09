using StudyBuddy.Application.Services;
using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Domain.Users.ValueObjects;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Commands.Create;

public class CreateProjectRequestHandler : ICommandHandler<CreateProjectRequest>
{
    private readonly IProjectRepository _projectRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProjectRequestHandler(
        IProjectRepository projectRepository,
        ITeamRepository teamRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _projectRepository = projectRepository;
        _teamRepository = teamRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        CreateProjectRequest request,
        CancellationToken cancellationToken)
    {
        var validId = new ProjectId(Guid.NewGuid());
        var validTopic = new ProjectTopic(request.Topic);
        var validDescription = new ProjectDescription(request.Description);
        var validEstimatedTime = new EstimatedTime(
            request.EstimatedTimeToFinish.Days,
            request.EstimatedTimeToFinish.Hours,
            request.EstimatedTimeToFinish.Minutes,
            request.EstimatedTimeToFinish.Seconds);
        var validDeadline = new Deadline(request.Deadline);
        
        var difficulty = await _projectRepository
            .GetDifficultyByIdAsync((byte) request.DifficultyId, cancellationToken);

        var state = await _projectRepository
            .GetStateByIdAsync((byte) request.StateId, cancellationToken);

        var user = await _userRepository
            .GetByIdAsync(new UserId(request.UserId), cancellationToken);

        var team = request.TeamId is null ? null
            : await _teamRepository.GetByIdAsync(request.TeamId.Value, cancellationToken);

        var project = new Domain.Projects.Project(
            id: validId,
            topic: validTopic,
            description: validDescription,
            difficulty: difficulty,
            estimatedTimeToFinish: validEstimatedTime,
            deadline: validDeadline,
            state: state,
            creator: user,
            team: team);
        
        request.SetId(project.Id.Value);

        await _projectRepository.AddAsync(project, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}