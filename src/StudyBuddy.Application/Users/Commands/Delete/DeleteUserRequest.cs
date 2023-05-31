using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Users.Commands.Delete;

public record DeleteUserRequest(Guid Id) : ICommand;