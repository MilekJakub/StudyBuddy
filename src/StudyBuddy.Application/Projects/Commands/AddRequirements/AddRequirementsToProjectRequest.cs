using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Commands.AddRequirements;

public record AddRequirementsToProjectRequest(Guid ProjectId, IEnumerable<string> Requirements) : ICommand;