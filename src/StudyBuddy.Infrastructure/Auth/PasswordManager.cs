using Microsoft.AspNetCore.Identity;
using StudyBuddy.Application.Auth;
using StudyBuddy.Application.Services;
using StudyBuddy.Domain.Users;
using StudyBuddy.Domain.Users.ValueObjects;

namespace StudyBuddy.Infrastructure.Auth;

public class PasswordManager : IPasswordManager
{
    private readonly IPasswordHasher<User> _passwordHasher;
    
    public PasswordManager(IPasswordHasher<User> passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public string HashPassword(Password password)
        => _passwordHasher.HashPassword(null!, password.ToString());

    public bool Validate(Password providedPassword, PasswordHash userHash)
        => _passwordHasher.VerifyHashedPassword(
            null!,
            userHash.Value,
            providedPassword.Value) == PasswordVerificationResult.Success;
}