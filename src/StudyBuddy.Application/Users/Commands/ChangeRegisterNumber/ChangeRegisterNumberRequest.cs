using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Users.Commands.ChangeRegisterNumber;

public record ChangeRegisterNumberRequest(string RegisterNumber) : ICommand;