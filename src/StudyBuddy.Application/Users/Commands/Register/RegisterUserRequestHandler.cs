using StudyBuddy.Application.Auth;
using StudyBuddy.Application.Services;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Domain.Users;
using StudyBuddy.Domain.Users.ValueObjects;
using StudyBuddy.Shared.Application.Interfaces;
using StudyBuddy.Shared.Domain.Interfaces;
using StudyBuddy.Shared.Exceptions.Users.BadRequest;

namespace StudyBuddy.Application.Users.Commands.Register;

public class RegisterUserRequestHandler : ICommandHandler<RegisterUserRequest>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordManager _passwordManager;
    private readonly IClock _clock;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtProvider _jwtProvider;

    public RegisterUserRequestHandler(
        IUserRepository userRepository,
        IPasswordManager passwordManager,
        IClock clock, IUnitOfWork unitOfWork,
        IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _passwordManager = passwordManager;
        _clock = clock;
        _unitOfWork = unitOfWork;
        _jwtProvider = jwtProvider;
    }

    public async Task Handle(
        RegisterUserRequest request,
        CancellationToken cancellationToken)
    {
        var validId = new UserId(Guid.NewGuid());
        var validUsername = new Username(request.Username);
        var validEmail = new Email(request.Email);
        var validPassword = new Password(request.Password);
        var validRole = new UserRole(request.Role);
        var validFirstname = new Firstname(request.Firstname);
        var validLastname = new Lastname(request.Lastname);
        var validRegisterNumber = new RegisterNumber(request.RegisterNumber);

        var passwordHash = _passwordManager.HashPassword(validPassword);
        var validPasswordHash = new PasswordHash(passwordHash);

        if (!await _userRepository.IsEmailUniqueAsync(validEmail))
        {
            throw new EmailIsNotUniqueException(validEmail.Value);
        }

        var user = new User(
            validId,
            validUsername,
            validEmail,
            validPasswordHash,
            validRole,
            validFirstname,
            validLastname,
            validRegisterNumber,
            _clock.Current()
        );

        await _userRepository.AddAsync(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        var token = _jwtProvider.Create(user);
        request.SetToken(token);
        request.SetId(user.Id.Value);
    }
}