using Microsoft.EntityFrameworkCore;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Domain.Teams;
using StudyBuddy.Domain.Teams.Entities;
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
    
    public async Task<Team> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var team = await _teams
            .Include(t => t.Memberships)
            .Include(t => t.Projects)
            .SingleOrDefaultAsync(t => t.Id.Value == id, cancellationToken);

        if (team is null)
        {
            throw new TeamNotFoundException(id.ToString());
        }

        return team;
    }

    public async Task<IEnumerable<Team>> GetAll(CancellationToken cancellationToken = default)
    {
        return await _teams
            .Include(t => t.Memberships)
            .Include(t => t.Projects)
            .ToListAsync(cancellationToken);
    }

    public async Task<Membership> GetMembershipByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var membership = await _memberships
            .SingleOrDefaultAsync(m => m.Id.Value == id, cancellationToken);

        if (membership is null)
        {
            throw new MembershipNotFoundException(id.ToString());
        }

        return membership;
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