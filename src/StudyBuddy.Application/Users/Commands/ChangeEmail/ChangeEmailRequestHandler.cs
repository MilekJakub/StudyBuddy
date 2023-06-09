using StudyBuddy.Application.Services;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Domain.Users.ValueObjects;
using StudyBuddy.Shared.Application.Interfaces;
using StudyBuddy.Shared.Exceptions.Users.NotFound;

namespace StudyBuddy.Application.Users.Commands.ChangeEmail;

public class ChangeEmailRequestHandler : ICommandHandler<ChangeEmailRequest>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChangeEmailRequestHandler(
        IUserRepository userRepository,
         IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        ChangeEmailRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository
            .GetByIdAsync(new UserId(request.UserId), cancellationToken);

        if (user is null)
        {
            throw new UserNotFoundException(request.UserId.ToString());
        }
        
        user.ChangeEmail(new Email(request.Email));
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}