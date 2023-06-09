using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Users.Commands.Register;

public record RegisterUserRequest(
    string Username,
    string Email,
    string Password,
    string Role,
    string Firstname,
    string Lastname,
    string RegisterNumber) : ICommand
{
    private Guid? _id;
    private string? _token;

    public Guid? GetId() => _id;
    public void SetId(Guid id) => _id = id;
    public string? GetToken() => _token;
    public void SetToken(string token) => _token = token;
}