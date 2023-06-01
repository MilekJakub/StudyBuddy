using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Users.Commands.Register;

public record RegisterUserRequest(
    Guid Id,
    string Username,
    string Email,
    string Password,
    string Role,
    string Firstname,
    string Lastname,
    string RegisterNumber);