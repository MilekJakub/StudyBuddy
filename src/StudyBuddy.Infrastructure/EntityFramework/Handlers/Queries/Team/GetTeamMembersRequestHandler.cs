using StudyBuddy.Application.Teams.Commands.GetMembers;
using StudyBuddy.Application.Teams.DTOs;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.Team;

public class GetTeamMembersRequestHandler : IQueryHandler<GetTeamMembersRequest, ICollection<MemberDto>>
{
    public Task<ICollection<MemberDto>> Handle(GetTeamMembersRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}