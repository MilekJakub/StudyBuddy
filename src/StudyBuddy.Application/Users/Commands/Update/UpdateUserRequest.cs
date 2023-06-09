using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Users.Commands.Update;

public record UpdateUserRequest(
    Guid Id,
    string? Firstname,
    string? Lastname,
    string? RegisterNumber) : ICommand;