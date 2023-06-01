using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Users.Commands.ChangePassword;

public record ChangePasswordRequest(string Password) : ICommand;