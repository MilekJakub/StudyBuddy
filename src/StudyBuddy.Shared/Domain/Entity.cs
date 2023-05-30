using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Shared.Domain;

public abstract class Entity<T> where T : IEquatable<T>
{
	private readonly List<IDomainEvent> _events = new();
    
    public T Id { get; init; }
    
    public IReadOnlyCollection<IDomainEvent> Events => _events;

    protected void AddEvent(IDomainEvent domainEvent) 
        => _events.Add(domainEvent);

    public void ClearEvents() => _events.Clear();

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        if (obj.GetType() != GetType())
            return false;

        if (obj is not Entity<T> entity)
            return false;

        return entity.Id.Equals(Id);
    }

    public bool Equals(Entity<T>? other)
    {
        if (other is null)
            return false;

        if (other.GetType() != GetType())
            return false;

        return other.Id.Equals(Id);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_events, Id);
    }

    public static bool operator ==(Entity<T>? first, Entity<T>? second) 
        => first is not null && second is not null && first.Equals(second);

    public static bool operator !=(Entity<T>? first, Entity<T>? second) 
        => !(first == second);
}