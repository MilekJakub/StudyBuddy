using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Projects.Enums.ProjectDifficulty;

public class ProjectDifficulty : Entity
{
    private readonly List<Project> _projects = new();

    private ProjectDifficulty()
    {
        // For Entity Framework 
    }
    
    public ProjectDifficulty(string difficulty)
    {
        // TODO: checks
        Difficulty = difficulty;
    }

    public ProjectDifficultyId Id { get; init; }
    public string Difficulty { get; private set; }
    public IReadOnlyCollection<Project> Projects => _projects;

    public override string ToString()
    {
        return Difficulty;
    }
}