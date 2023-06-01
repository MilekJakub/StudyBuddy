using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Projects.Enums.ProjectState;

public class ProjectState : Entity
{
    private readonly List<Project> _projects = new();

    private ProjectState()
    {
        // For Entity Framework
    }
    
    public ProjectState(string state)
    {
        // TODO: checks
        State = state;
    }

    public ProjectStateId Id { get; init; }
    public string State { get; private set; }
    public IReadOnlyCollection<Project> Projects => _projects;

    public override string ToString()
    {
        return State;
    }
}