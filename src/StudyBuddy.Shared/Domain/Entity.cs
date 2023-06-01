using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Shared.Domain;

public abstract class Entity
{
	private readonly List<IDomainEvent> _events = new();
    
    public IReadOnlyCollection<IDomainEvent> Events => _events;

    protected void AddEvent(IDomainEvent domainEvent) 
        => _events.Add(domainEvent);

    public void ClearEvents() => _events.Clear();
}