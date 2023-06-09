using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Users.Commands.ChangeEmail;

public record ChangeEmailRequest(Guid UserId, string Email) : ICommand;