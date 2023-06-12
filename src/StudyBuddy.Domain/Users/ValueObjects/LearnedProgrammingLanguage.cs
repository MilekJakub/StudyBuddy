using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Users.ValueObjects;

public record LearnedProgrammingLanguage(string Value) : IValueObject;