using StudyBuddy.Application.Users.DTOs;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Users.Queries.GetById;

public record GetUserByIdRequest(Guid Id) : IQuery<UserDto>;