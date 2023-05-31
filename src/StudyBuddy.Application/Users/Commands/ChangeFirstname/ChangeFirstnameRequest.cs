using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Users.Commands.ChangeFirstname;

public record ChangeFirstnameRequest(string Firstname) : ICommand;