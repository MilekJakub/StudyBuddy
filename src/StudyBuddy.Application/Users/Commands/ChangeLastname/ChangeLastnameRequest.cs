using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Users.Commands.ChangeLastname;

public record ChangeLastnameRequest(string Lastname) : ICommand;