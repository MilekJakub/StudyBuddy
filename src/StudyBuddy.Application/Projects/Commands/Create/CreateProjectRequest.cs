using StudyBuddy.Domain.Projects.Enums;
using StudyBuddy.Domain.Projects.Enums.ProjectDifficulty;
using StudyBuddy.Domain.Projects.Enums.ProjectState;
using StudyBuddy.Domain.Users.ValueObjects;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Commands.Create;

public record CreateProjectRequest(
    string Topic,
    string Description,
    ProjectDifficultyId DifficultyId,
    EstimatedTimeToFinish EstimatedTimeToFinish,
    DateTime Deadline,
    ProjectStateId StateId,
    Guid UserId,
    Guid? TeamId) : ICommand
{
    private Guid? _id;
    public Guid? GetId => _id;
    public void SetId(Guid id) => _id = id;
}

public record EstimatedTimeToFinish(int Days, int Hours, int Minutes, int Seconds);