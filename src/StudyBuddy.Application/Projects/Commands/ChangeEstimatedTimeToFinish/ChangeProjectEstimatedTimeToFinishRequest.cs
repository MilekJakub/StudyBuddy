using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Commands.ChangeEstimatedTimeToFinish;

public record ChangeProjectEstimatedTimeToFinishRequest(Guid ProjectId, DateTime EstimatedTimeToFinish) : ICommand;