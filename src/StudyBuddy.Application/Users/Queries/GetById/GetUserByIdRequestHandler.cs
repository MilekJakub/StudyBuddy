using StudyBuddy.Application.Users.DTOs;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Domain.Users.ValueObjects;
using StudyBuddy.Shared.Application.Interfaces;
using StudyBuddy.Shared.Exceptions.Users.NotFound;

namespace StudyBuddy.Application.Users.Queries.GetById;

public class GetUserByIdRequestHandler 
    : IQueryHandler<GetUserByIdRequest, UserDto>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdRequestHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto> Handle(
        GetUserByIdRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository
            .GetByIdAsync(new UserId(request.Id), cancellationToken);

        if (user is null)
        {
            throw new UserNotFoundException(request.Id.ToString());
        }

        return Mapper.UserDto(user);
    }
}