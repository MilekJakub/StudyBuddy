using StudyBuddy.Application.Users.DTOs;
using StudyBuddy.Application.Users.Queries.GetAll;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Queries.User;

public class GetAllUsersRequestHandler : IQueryHandler<GetAllUsersRequest, ICollection<UserDto>>
{
    public Task<ICollection<UserDto>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}