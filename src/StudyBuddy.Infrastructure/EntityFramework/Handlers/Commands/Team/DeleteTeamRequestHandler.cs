using StudyBuddy.Application.Teams.Commands.Delete;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.Team;

public class DeleteTeamRequestHandler : ICommandHandler<DeleteTeamRequest>
{
    public Task Handle(DeleteTeamRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}