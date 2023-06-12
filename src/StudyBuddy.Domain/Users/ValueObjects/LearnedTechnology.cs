using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Users.ValueObjects;

public record LearnedTechnology(string Value) : IValueObject;