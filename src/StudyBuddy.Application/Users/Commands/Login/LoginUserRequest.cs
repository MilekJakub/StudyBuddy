using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Users.Commands.Login;

public record LoginUserRequest(string Username, string Password) : ICommand
{
    private string? _token;

    public string? GetToken() => _token;
    public void SetToken(string token) => _token = token;
}