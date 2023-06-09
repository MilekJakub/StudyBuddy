using StudyBuddy.Application.Users.DTOs;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Users.Queries.GetAll;

public class GetAllUsersRequestHandler
    : IQueryHandler<GetAllUsersRequest, IEnumerable<UserDto>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersRequestHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserDto>> Handle(
        GetAllUsersRequest request,
        CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllUsers(cancellationToken);
        var list = users.ToList();

        if (!list.Any())
        {
            throw new Exception("No user found in the database.");
        }

        return list.Select(u => Mapper.UserDto(u));
    }
}