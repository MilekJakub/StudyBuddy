using StudyBuddy.Application.Users.DTOs;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Users.Queries.GetAll;

public record GetAllUsersRequest() : IQuery<IEnumerable<UserDto>>;