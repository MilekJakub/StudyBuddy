using StudyBuddy.Application.Teams.DTOs;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Teams.Queries.GetById;

public record GetTeamByIdRequest(Guid Id) : IQuery<TeamDto>;