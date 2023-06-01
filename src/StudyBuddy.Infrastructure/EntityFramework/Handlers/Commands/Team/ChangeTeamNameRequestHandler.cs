using StudyBuddy.Application.Teams.Commands.ChangeName;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.Team;

public class ChangeTeamNameRequestHandler : ICommandHandler<ChangeTeamNameRequest>
{
    public Task Handle(ChangeTeamNameRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}