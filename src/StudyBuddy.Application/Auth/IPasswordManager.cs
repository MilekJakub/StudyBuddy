using StudyBuddy.Domain.Users.ValueObjects;

namespace StudyBuddy.Application.Auth;

public interface IPasswordManager
{
    string HashPassword(Password password);
    bool Validate(Password providedPassword, PasswordHash userHash);
}