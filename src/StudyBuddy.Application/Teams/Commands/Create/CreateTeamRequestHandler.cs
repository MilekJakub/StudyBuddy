using StudyBuddy.Application.Services;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Domain.Teams.ValueObjects;
using StudyBuddy.Domain.Users.ValueObjects;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Teams.Commands.Create;

public class CreateTeamRequestHandler
    : ICommandHandler<CreateTeamRequest>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTeamRequestHandler(
        ITeamRepository teamRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _teamRepository = teamRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        CreateTeamRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository
            .GetByIdAsync(new UserId(request.UserId), cancellationToken);

        var team = new Domain.Teams.Team(
            id: new TeamId(Guid.NewGuid()),
            name: new TeamName(request.Name),
            description: new TeamDescription(request.Description),
            teamFounder: user);

        await _teamRepository.AddAsync(team, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        request.SetId(team.Id.Value);
    }
}