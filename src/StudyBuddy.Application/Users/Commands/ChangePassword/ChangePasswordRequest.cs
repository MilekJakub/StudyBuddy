using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Users.Commands.ChangePassword;

public record ChangePasswordRequest(Guid UserId, string Password) : ICommand;