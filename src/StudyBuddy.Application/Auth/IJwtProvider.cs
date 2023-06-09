using StudyBuddy.Domain.Users;

namespace StudyBuddy.Application.Auth;

public interface IJwtProvider
{
    string Create(User user);
}