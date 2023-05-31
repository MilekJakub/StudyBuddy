using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Users.Commands.ChangeEmail;

public record ChangeEmailRequest(string Email) : ICommand;