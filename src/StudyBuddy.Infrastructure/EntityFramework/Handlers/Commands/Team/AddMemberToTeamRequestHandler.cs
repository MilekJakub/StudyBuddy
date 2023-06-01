using StudyBuddy.Application.Teams.Commands.AddMember;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.Team;

public class AddMemberToTeamRequestHandler : ICommandHandler<AddMemberToTeamRequest>
{
    public Task Handle(AddMemberToTeamRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}