using StudyBuddy.Application.Teams.Commands.KickMember;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.Team;

public class KickTeamMemberRequestHandler : ICommandHandler<KickTeamMemberRequest>
{
    public Task Handle(KickTeamMemberRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}