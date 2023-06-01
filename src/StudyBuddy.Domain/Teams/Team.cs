using StudyBuddy.Domain.Projects;
using StudyBuddy.Domain.Teams.Entities;
using StudyBuddy.Domain.Teams.Events;
using StudyBuddy.Domain.Teams.ValueObjects;
using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Exceptions.Teams.NotFound;

namespace StudyBuddy.Domain.Teams;

public class Team : Entity
{
	private readonly List<Member> _members = new();
	private readonly List<Project> _projects = new();

	private Team()
	{
		// For Entity Framework
	}
	
	public Team(
		TeamId id,
		TeamName name,
		Member leader)
	{
		Id = id;
		Name = name;
		_members.Add(leader);
	}

	public TeamId Id { get; init; }
	public TeamName Name { get; private set; }
	public Member Leader => _members.Single(m => m.Role.Value == "Leader");
	public IReadOnlyCollection<Member> Members => _members;
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
	
	public void ChangeLeader(Member leader, MemberRole previousLeaderRole)
	{
		Leader.ChangeRole(previousLeaderRole);
		leader.ChangeRole(new MemberRole("Leader"));
		AddEvent(new TeamLeaderChangedEvent(this, leader));
	}

	public void AddMember(Member member)
	{
		_members.Add(member);
		AddEvent(new MemberAddedToTeamEvent(this, member));
	}

	public void KickMember(MemberId id)
	{
		var member = GetMember(id);
		_members.Remove(member);
		AddEvent(new MemberKickedFromProjectEvent(this, member));
	}

	private Member GetMember(MemberId id)
	{
		foreach(var members in _members)
		{
			if(members.Id.Equals(id))
				return members;
		}

		throw new MemberNotFoundException(id.ToString());
	}
}