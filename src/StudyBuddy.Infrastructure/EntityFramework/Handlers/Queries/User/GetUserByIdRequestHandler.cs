using StudyBuddy.Application.Users.DTOs;
using StudyBuddy.Application.Users.Queries.GetById;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Queries.User;

public class GetUserByIdRequestHandler : IQueryHandler<GetUserByIdRequest, UserDto>
{
    public Task<UserDto> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}