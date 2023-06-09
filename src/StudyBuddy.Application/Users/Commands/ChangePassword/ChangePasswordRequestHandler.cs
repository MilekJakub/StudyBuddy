using StudyBuddy.Application.Auth;
using StudyBuddy.Application.Services;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Domain.Users.ValueObjects;
using StudyBuddy.Shared.Application.Interfaces;
using StudyBuddy.Shared.Exceptions.Users.NotFound;

namespace StudyBuddy.Application.Users.Commands.ChangePassword;

public class ChangePasswordRequestHandler : ICommandHandler<ChangePasswordRequest>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordManager _passwordManager;
    private readonly IUnitOfWork _unitOfWork;

    public ChangePasswordRequestHandler(
        IUserRepository userRepository,
        IPasswordManager passwordManager,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _passwordManager = passwordManager;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository
            .GetByIdAsync(new UserId(request.UserId), cancellationToken);

        if (user is null)
        {
            throw new UserNotFoundException(request.UserId.ToString());
        }

        var hash = _passwordManager.HashPassword(new Password(request.Password));
        var validHash = new PasswordHash(hash);
        
        user.ChangePassword(validHash);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}