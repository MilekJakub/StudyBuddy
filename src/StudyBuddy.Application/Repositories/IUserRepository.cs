using StudyBuddy.Domain.Users;
using StudyBuddy.Domain.Users.ValueObjects;

namespace StudyBuddy.Application.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<bool> IsEmailUniqueAsync(Email email);
    Task<User> GetByIdAsync(UserId id);
    Task<IEnumerable<User>> GetAllUsers();
}