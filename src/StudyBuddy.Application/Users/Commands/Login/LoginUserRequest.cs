using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Users.Commands.LoginUser;

public record LoginUserRequest(string Username, string Password) : ICommand;