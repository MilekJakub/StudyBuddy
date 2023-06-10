using StudyBuddy.Domain.Teams;
using StudyBuddy.Domain.Teams.Entities;
using StudyBuddy.Domain.Teams.ValueObjects;

namespace StudyBuddy.Domain.Repositories;

public interface ITeamRepository
{
    Task<Team?> GetByIdAsync(TeamId id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Team>> GetAll(CancellationToken cancellationToken = default);
    Task<Membership?> GetMembershipByIdAsync(MembershipId id, CancellationToken cancellationToken = default);
    Task AddAsync(Team team, CancellationToken cancellationToken = default);
    Task RemoveAsync(Team team, CancellationToken cancellationToken = default);
}