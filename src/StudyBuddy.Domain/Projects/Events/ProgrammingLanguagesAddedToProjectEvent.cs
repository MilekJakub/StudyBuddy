using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Projects.Events;

public record ProgrammingLanguagesAddedToProjectEvent(Project Project, IEnumerable<ProgrammingLanguage> Language) : IDomainEvent;