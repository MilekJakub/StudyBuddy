using System.Security.Authentication;
using StudyBuddy.Application.Auth;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Domain.Users.ValueObjects;
using StudyBuddy.Shared.Application.Interfaces;
using StudyBuddy.Shared.Exceptions.Users.BadRequest;

namespace StudyBuddy.Application.Users.Commands.Login;

public class LoginUserRequestHandler : ICommandHandler<LoginUserRequest>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordManager _passwordManager;
    private readonly IJwtProvider _jwtProvider;

    public LoginUserRequestHandler(
        IUserRepository userRepository,
        IPasswordManager passwordManager,
        IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _passwordManager = passwordManager;
        _jwtProvider = jwtProvider;
    }

    public async Task Handle(
        LoginUserRequest request,
        CancellationToken cancellationToken)
    {
        var validUsername = new Username(request.Username);
        var validPassword = new Password(request.Password);
        
        var user = await _userRepository.GetByUsernameAsync(validUsername, cancellationToken);

        if (user is null)
        {
            throw new InvalidCredentialException();
        }

        var isPasswordValid = _passwordManager.Validate(validPassword, user.PasswordHash);

        if (!isPasswordValid)
        {
            throw new InvalidCredentialsException();
        }

        var token = _jwtProvider.Create(user);
        request.SetToken(token);
    }
}