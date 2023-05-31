using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Commands.ChangeTopic;

public record ChangeProjectTopicRequest(Guid ProjectId, string ProjectTopic) : ICommand;