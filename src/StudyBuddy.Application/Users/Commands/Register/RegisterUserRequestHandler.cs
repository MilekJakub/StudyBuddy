using StudyBuddy.Application.Repositories;
using StudyBuddy.Application.Services;
using StudyBuddy.Domain.Users;
using StudyBuddy.Domain.Users.ValueObjects;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Users.Commands.RegisterUser;

public class RegisterUserRequestHandler : ICommandHandler<RegisterUserRequest>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;
    
    public RegisterUserRequestHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var (id, username, email, password, role, firstname, lastname, registerNumber) = request;
        
        var validId = new UserId(id.ToString());
        var validUsername = new Username(username);
        var validEmail = new Email(email);
        var validPassword = new Password(password);
        var validRole = new UserRole(role);
        var validFirstname = new Firstname(firstname);
        var validLastname = new Lastname(lastname);
        var validRegisterNumber = new RegisterNumber(registerNumber);

        if (!await _userRepository.IsEmailUniqueAsync(validEmail))
        {
            throw new Exception();
        }

        var passwordHash = _passwordHasher.HashPassword(validPassword);
        var validPasswordHash = new PasswordHash(passwordHash);

        var user = new User(
            validId, validUsername, validEmail, validPasswordHash, validRole,
            validFirstname, validLastname, validRegisterNumber, DateTime.UtcNow);

        await _userRepository.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();
        
        
    }
}