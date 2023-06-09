using StudyBuddy.Application.Services;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Domain.Teams.Entities;
using StudyBuddy.Domain.Teams.ValueObjects;
using StudyBuddy.Domain.Users.ValueObjects;
using StudyBuddy.Shared.Application.Interfaces;
using StudyBuddy.Shared.Exceptions.Teams.NotFound;

namespace StudyBuddy.Application.Teams.Commands.AddMember;

public class AddMemberToTeamRequestHandler
    : ICommandHandler<AddMemberToTeamRequest>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddMemberToTeamRequestHandler(
        ITeamRepository teamRepository,
        IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _teamRepository = teamRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        AddMemberToTeamRequest request,
        CancellationToken cancellationToken)
    {
        var team = await _teamRepository
            .GetByIdAsync(request.TeamId, cancellationToken);
            
        if (team is null)
        {
            throw new TeamNotFoundException(request.TeamId.ToString());
        }
        
        var user = await _userRepository
            .GetByIdAsync(new UserId(request.UserId), cancellationToken);

        var membership = new Membership(
            id: new MembershipId(Guid.NewGuid()),
            team: team,
            user: user,
            role: new ProjectRole(request.Role),
            joinDate: DateTime.UtcNow);
        
        team.AddMember(membership);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}