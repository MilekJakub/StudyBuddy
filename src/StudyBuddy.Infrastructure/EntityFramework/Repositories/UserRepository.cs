using Microsoft.EntityFrameworkCore;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Domain.Users;
using StudyBuddy.Domain.Users.ValueObjects;
using StudyBuddy.Infrastructure.EntityFramework.Contexts;
using StudyBuddy.Shared.Exceptions.Users.BadRequest;
using StudyBuddy.Shared.Exceptions.Users.NotFound;

namespace StudyBuddy.Infrastructure.EntityFramework.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DbSet<User> _users;

    public UserRepository(ApplicationDbContext context)
    {
        _users = context.Users;
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        await _users.AddAsync(user, cancellationToken);
    }

    public async Task<bool> IsUsernameUniqueAsync(Username username, CancellationToken cancellationToken = default)
    {
        return !(await _users.AnyAsync(u => u.Username == username, cancellationToken));
    }

    public async Task<bool> IsEmailUniqueAsync(
        Email email,
        CancellationToken cancellationToken = default)
    {
        return !(await _users.AnyAsync(u => u.Email == email, cancellationToken));
    }

    public async Task<User> GetByIdAsync(
        UserId id,
        CancellationToken cancellationToken = default)
    {
        var user = await _users
            .Include(u => u.Memberships)
            .SingleOrDefaultAsync(u => u.Id == id, cancellationToken: cancellationToken);

        if (user is null)
        {
            throw new UserNotFoundException(id.ToString());
        }

        return user;
    }

    public async Task<User> GetByUsernameAsync(Username username, CancellationToken cancellationToken = default)
    {
        var user = await _users
            .Include(u => u.Memberships)
            .SingleOrDefaultAsync(u => u.Username == username, cancellationToken: cancellationToken);

        if (user is null)
        {
            throw new InvalidCredentialsException();
        }

        return user;
    }

    public async Task<IEnumerable<User>> GetAllUsers(CancellationToken cancellationToken = default)
    {
        return await _users
            .Include(u => u.Memberships)
            .ToListAsync(cancellationToken);
    }

    public Task RemoveAsync(User user, CancellationToken cancellationToken = default)
    {
        _users.Remove(user);
        return Task.CompletedTask;
    }
}