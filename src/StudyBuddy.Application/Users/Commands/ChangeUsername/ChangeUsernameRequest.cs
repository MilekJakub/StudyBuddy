using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Users.Commands.ChangeUsername;

public record ChangeUsernameRequest(string Username) : ICommand;