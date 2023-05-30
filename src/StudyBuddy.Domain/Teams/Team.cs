using StudyBuddy.Domain.Projects;
using StudyBuddy.Domain.Teams.Entities;
using StudyBuddy.Domain.Teams.Events;
using StudyBuddy.Domain.Teams.ValueObjects;
using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Exceptions;
using StudyBuddy.Shared.Exceptions.Teams.NotFound;

namespace StudyBuddy.Domain.Teams;

public abstract class Team : Entity<TeamId>
{
	private readonly List<Membership> _memberships = new();
	private readonly List<Project> _completedProjects = new();

	public Team(
		TeamId id,
		TeamName name,
		Membership leader)
	{
		Id = id;
		Name = name;
		Leader = leader;
	}

	public TeamName Name { get; private set; }
	public Membership Leader { get; private set; }
	public IReadOnlyCollection<Membership> Memberships => _memberships;
	public IReadOnlyCollection<Project> CompletedProjects => _completedProjects;

	public void ChangeName(TeamName name)
	{
		Name = name;
		AddEvent(new TeamNameChangedEvent(this, name));
	}
	
	public void ChangeLeader(Membership leader)
	{
		Leader = leader;
		AddEvent(new TeamLeaderChangedEvent(this, leader));
	}

	public void AddMember(Membership membership)
	{
		_memberships.Add(membership);
		AddEvent(new MembershipAddedToTeamEvent(this, membership));
	}

	public void KickMember(MembershipId id)
	{
		var membership = GetMembership(id);
		_memberships.Remove(membership);
		AddEvent(new MemberKickedFromProjectEvent(this, membership));
	}
	
	public void AddCompletedProject(Project project)
	{
		_completedProjects.Add(project);
		AddEvent(new CompletedProjectAddedToTeamEvent(this, project));
	}

	private Membership GetMembership(MembershipId id)
	{
		foreach(var membership in _memberships)
		{
			if(membership.Id.Equals(id))
				return membership;
		}

		throw new MemberNotFoundException(id.ToString());
	}
}