using StudyBuddy.Domain.Users;
using StudyBuddy.Domain.Users.ValueObjects;

namespace StudyBuddy.Domain.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user, CancellationToken cancellationToken = default);
    Task<bool> IsUsernameUniqueAsync(Username username, CancellationToken cancellationToken = default);
    Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken = default);
    Task<User> GetByIdAsync(UserId id, CancellationToken cancellationToken = default);
    Task<User> GetByUsernameAsync(Username username, CancellationToken cancellationToken = default);
    Task<IEnumerable<User>> GetAllUsers(CancellationToken cancellationToken = default);
    Task RemoveAsync(User user, CancellationToken cancellationToken = default);
}