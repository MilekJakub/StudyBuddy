using StudyBuddy.Application.Services;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Domain.Users.ValueObjects;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Users.Commands.Update;

public class UpdateUserRequestHandler : ICommandHandler<UpdateUserRequest>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserRequestHandler(
    IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        UpdateUserRequest request,
        CancellationToken cancellationToken)
    {
        if (!IsValid(request))
        {
            throw new Exception("Cannot update the project. No values provided.");
        }

        var user = await _userRepository.GetByIdAsync(new UserId(request.Id));

        if (request.Firstname is not null)
        {
            user.ChangeFirstname(new Firstname(request.Firstname));
        }

        if (request.Lastname is not null)
        {
            user.ChangeLastname(new Lastname(request.Lastname));
        }
        
        if (request.RegisterNumber is not null)
        {
            user.ChangeRegisterNumber(new RegisterNumber(request.RegisterNumber));
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
    
    public static bool IsValid(object? value)
    {
        if (value == null)
            return false;

        var typeInfo = value.GetType();

        var propertyInfo = typeInfo.GetProperties();

        return propertyInfo.Any(property => property.GetValue(value) is not null);
    }
}