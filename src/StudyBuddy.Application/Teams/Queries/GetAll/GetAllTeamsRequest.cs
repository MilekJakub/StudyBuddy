using StudyBuddy.Application.Teams.DTOs;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Teams.Queries.GetAll;

public record GetAllTeamsRequest() : IQuery<IEnumerable<TeamDto>>;