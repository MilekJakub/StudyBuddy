using StudyBuddy.Application.Teams.Commands.Create;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.Team;

public class CreateTeamRequestHandler : ICommandHandler<CreateTeamRequest>
{
    public Task Handle(CreateTeamRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}