using StudyBuddy.Domain.Teams;
using StudyBuddy.Domain.Teams.Entities;

namespace StudyBuddy.Domain.Repositories;

public interface ITeamRepository
{
    Task<Team> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Team>> GetAll(CancellationToken cancellationToken = default);
    Task<Membership> GetMembershipByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(Team team, CancellationToken cancellationToken = default);
    Task RemoveAsync(Team team, CancellationToken cancellationToken = default);
}