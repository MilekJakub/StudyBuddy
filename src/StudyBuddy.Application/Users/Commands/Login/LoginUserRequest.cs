using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Users.Commands.Login;

public record LoginUserRequest(string Username, string Password);