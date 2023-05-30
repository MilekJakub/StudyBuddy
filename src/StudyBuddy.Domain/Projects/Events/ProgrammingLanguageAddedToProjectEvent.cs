using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Projects.Events;

public record ProgrammingLanguageAddedToProjectEvent(Project Project, ProgrammingLanguage Language) : IDomainEvent;