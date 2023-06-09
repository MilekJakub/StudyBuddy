using StudyBuddy.Domain.Projects;
using StudyBuddy.Domain.Teams.Entities;
using StudyBuddy.Domain.Teams.Events;
using StudyBuddy.Domain.Teams.ValueObjects;
using StudyBuddy.Domain.Users;
using StudyBuddy.Domain.Users.ValueObjects;
using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Exceptions.Teams.BadRequest;
using StudyBuddy.Shared.Exceptions.Teams.NotFound;

namespace StudyBuddy.Domain.Teams;

public class Team : Entity
{
	private readonly List<Membership> _memberships = new();
	private readonly List<Project> _projects = new();
	
	public Team(TeamId id, TeamName name, TeamDescription description, User teamFounder)
	{
		Id = id;
		Name = name;
		Description = description;

		var leader =
			new Membership(
			id: new MembershipId(Guid.NewGuid()),
			team: this,
			user: teamFounder,
			role: new ProjectRole("Leader"),
			joinDate: DateTime.UtcNow);

		_memberships.Add(leader);
	}

	public TeamId Id { get; private set; }
	public TeamName Name { get; private set; }
	public TeamDescription Description { get; private set; }
	public IReadOnlyCollection<Membership> Memberships => _memberships;
	public IReadOnlyCollection<Project> Projects => _projects;

	public void AddProject(Project project)
	{
		_projects.Add(project);
		AddEvent(new ProjectAddedToTeamEvent(this, project));
	}
	
	public void ChangeName(TeamName name)
	{
		Name = name;
		AddEvent(new TeamNameChangedEvent(this, name));
	}
	
	public void ChangeLeader(
		MembershipId newLeaderId,
		ProjectRole roleForPreviousLeader)
	{
		var currentLeader = GetLeader();
		var newLeader = GetMembership(newLeaderId);
		
		currentLeader.ChangeRole(roleForPreviousLeader);
		newLeader.ChangeRole(new ProjectRole("Leader"));
		
		AddEvent(new TeamLeaderChangedEvent(this, currentLeader));
	}

	public void AddMember(Membership membership)
	{
		_memberships.Add(membership);
		AddEvent(new MemberAddedToTeamEvent(this, membership));
	}

	public void KickMember(MembershipId id)
	{
		var member = GetMembership(id);
		_memberships.Remove(member);
		AddEvent(new MemberKickedFromProjectEvent(this, member));
	}

	private Membership GetMembership(MembershipId id)
	{
		var member = _memberships.SingleOrDefault(m => m.Id == id);
		return member ?? throw new MembershipNotFoundException(id.ToString());
	}

	public Membership GetLeader()
	{
		var leader = _memberships.SingleOrDefault(m => m.Role.Value == "Leader");

		if (leader is null)
		{
			throw new LeaderNotFoundException();
		}

		return leader;
	}

	private Team()
	{
		// For Entity Framework
	}
}