using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Teams.Commands.Create;

public record CreateTeamRequest(string Name, string Description, Guid UserId) : ICommand
{
    private Guid? _id;
    public Guid? GetId => _id;
    public void SetId(Guid id) => _id = id;
}