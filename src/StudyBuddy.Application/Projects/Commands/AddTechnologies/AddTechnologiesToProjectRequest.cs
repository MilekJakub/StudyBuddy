using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Commands.AddTechnologies;

public record AddTechnologiesToProjectRequest(Guid ProjectId, IEnumerable<string> Technologies) : ICommand;