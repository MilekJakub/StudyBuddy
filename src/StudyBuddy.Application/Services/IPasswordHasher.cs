using StudyBuddy.Domain.Users.ValueObjects;

namespace StudyBuddy.Application.Services;

public interface IPasswordHasher
{
    string HashPassword(Password password);
}