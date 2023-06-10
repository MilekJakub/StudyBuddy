using Microsoft.EntityFrameworkCore;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Domain.Teams;
using StudyBuddy.Domain.Teams.Entities;
using StudyBuddy.Domain.Teams.ValueObjects;
using StudyBuddy.Domain.Users.ValueObjects;
using StudyBuddy.Infrastructure.EntityFramework.Contexts;
using StudyBuddy.Shared.Exceptions.Teams.NotFound;

namespace StudyBuddy.Infrastructure.EntityFramework.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly DbSet<Team> _teams;
    private readonly DbSet<Membership> _memberships;

    public TeamRepository(ApplicationDbContext context)
    {
        _teams = context.Teams;
        _memberships = context.Memberships;
    }
    
    public async Task<Team?> GetByIdAsync(TeamId id, CancellationToken cancellationToken)
    {
        return await _teams
            .Include(t => t.Memberships).ThenInclude(m => m.User)
            .Include(t => t.Projects)
            .SingleOrDefaultAsync(t => t.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Team>> GetAll(CancellationToken cancellationToken = default)
    {
        return await _teams
            .Include(t => t.Memberships).ThenInclude(m => m.User)
            .Include(t => t.Projects)
            .ToListAsync(cancellationToken);
    }

    public async Task<Membership?> GetMembershipByIdAsync(MembershipId id, CancellationToken cancellationToken)
    {
        return await _memberships
            .Include(m => m.User)
            .Include(m => m.Team)
            .SingleOrDefaultAsync(m => m.Id == id, cancellationToken);
    }

    public async Task AddAsync(Team team, CancellationToken cancellationToken)
    {
        await _teams.AddAsync(team, cancellationToken);
    }

    public Task RemoveAsync(Team team, CancellationToken cancellationToken = default)
    {
        _teams.Remove(team);
        return Task.CompletedTask;
    }
}