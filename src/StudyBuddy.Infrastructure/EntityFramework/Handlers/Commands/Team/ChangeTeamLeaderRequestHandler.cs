using StudyBuddy.Application.Teams.Commands.ChangeLeader;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.Team;

public class ChangeTeamLeaderRequestHandler : ICommandHandler<ChangeTeamLeaderRequest>
{
    public Task Handle(ChangeTeamLeaderRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}