using StudyBuddy.Application.Services;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Domain.Users.ValueObjects;
using StudyBuddy.Shared.Application.Interfaces;
using StudyBuddy.Shared.Exceptions.Users.NotFound;

namespace StudyBuddy.Application.Users.Commands.Delete;

public class DeleteUserRequestHandler : ICommandHandler<DeleteUserRequest>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserRequestHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        DeleteUserRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository
            .GetByIdAsync(new UserId(request.Id), cancellationToken);

        if (user is null)
        {
            throw new UserNotFoundException(request.Id.ToString());
        }
        
        await _userRepository.RemoveAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}