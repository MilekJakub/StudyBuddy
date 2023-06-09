using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Domain.Projects.Enums.ProjectDifficulty;
using StudyBuddy.Domain.Projects.Enums.ProjectState;
using StudyBuddy.Shared.Domain;
using StudyBuddy.Domain.Teams;
using StudyBuddy.Domain.Projects.Events;
using StudyBuddy.Domain.Teams.ValueObjects;
using StudyBuddy.Domain.Users;
using StudyBuddy.Shared.Exceptions.Projects.NotFound;

namespace StudyBuddy.Domain.Projects;

public class Project : Entity
{
	private readonly List<ProjectRequirement> _requirements = new();
	private readonly List<ProjectTechnology> _technologies = new();
	private readonly List<ProgrammingLanguage> _languages = new();

	public Project(
		ProjectId id,
		ProjectTopic topic,
		ProjectDescription description,
		ProjectDifficulty difficulty,
		EstimatedTime estimatedTimeToFinish,
		Deadline deadline,
		ProjectState state,
		User creator,
		Team? team = null)
	{
		Id = id;
		Topic = topic;
		Description = description;
		EstimatedTimeToFinish = estimatedTimeToFinish;
		Deadline = deadline;
		ProjectDifficultyId = difficulty.Id;
		ProjectDifficulty = difficulty;
		ProjectStateId = state.Id;
		ProjectState = state;

		if (team is null)
		{
			var defaultTeam = new Team(
				id: new TeamId(Guid.NewGuid()),
				description: new TeamDescription("Write something amazing about your team!"),
				name: new TeamName($"{id}"),
				teamFounder: creator);
		
			TeamId = defaultTeam.Id;
			Team = defaultTeam;
		}
		else
		{
			TeamId = team.Id;
			Team = team;
		}
	}

	public ProjectId Id { get; private set; }
	public ProjectTopic Topic { get; private set; }
	public ProjectDescription Description { get; private set; }
	public EstimatedTime EstimatedTimeToFinish { get; private set; }
	public Deadline Deadline { get; private set; }
	
	public IReadOnlyCollection<ProjectRequirement> Requirements
		=> _requirements;
	public IReadOnlyCollection<ProjectTechnology> Technologies
		=> _technologies;
	public IReadOnlyCollection<ProgrammingLanguage> ProgrammingLanguages
		=> _languages;
	
	public TeamId TeamId { get; private set; }
	public Team Team { get; private set; }
	public ProjectDifficultyId ProjectDifficultyId { get; private set; }
	public ProjectDifficulty ProjectDifficulty { get; private set; }
	public ProjectStateId ProjectStateId { get; private set; }
	public ProjectState ProjectState { get; private set; }

	public void ChangeTopic(ProjectTopic topic)
	{
		Topic = topic;
		AddEvent(new ProjectTopicChangedEvent(this, topic));
	}

	public void ChangeDescription(ProjectDescription description)
	{
		Description = description;
		AddEvent(new ProjectDescriptionChangedEvent(this, description));
	}
	
	public void AddRequirement(ProjectRequirement requirement)
	{
		_requirements.Add(requirement);
		AddEvent(new RequirementAddedToProjectEvent(this, requirement));
	}

	public void AddRequirements(IEnumerable<ProjectRequirement> requirements)
	{
		foreach(var requirement in requirements)
		{
			_requirements.Add(requirement);
		}

		AddEvent(new RequirementsAddedToProjectEvent(this, requirements));
	}

	public void RemoveRequirement(string name)
	{
		var requirement = GetRequirement(name);
		_requirements.Remove(requirement);
	}

	public void RemoveRequirements(IEnumerable<string> names)
	{
		foreach(var name in names)
		{
			RemoveRequirement(name);
		}
	}

	public void AddTechnology(ProjectTechnology technology)
	{
		_technologies.Add(technology);
		AddEvent(new TechnologyAddedToProjectEvent(this, technology));
	}

	public void AddTechnologies(IEnumerable<ProjectTechnology> technologies)
	{
		foreach(var technology in technologies)
		{
			_technologies.Add(technology);
		}
		AddEvent(new TechnologiesAddedToProjectEvent(this, technologies));
	}

	public void RemoveTechnology(string name)
	{
		var technology = GetTechnology(name);
		_technologies.Remove(technology);
	}

	public void RemoveTechnologies(IEnumerable<string> names)
	{
		foreach(var name in names)
		{
			RemoveTechnology(name);
		}
	}

	public void AddProgrammingLanguage(ProgrammingLanguage language)
	{
		_languages.Add(language);
		AddEvent(new ProgrammingLanguageAddedToProjectEvent(this, language));
	}

	public void AddProgrammingLanguages(IEnumerable<ProgrammingLanguage> languages)
	{
		foreach(var language in languages)
		{
			_languages.Add(language);
		}

		AddEvent(new ProgrammingLanguagesAddedToProjectEvent(this, languages));
	}

	public void RemoveProgrammingLanguage(string name)
	{
		var language = GetLanguage(name);
		_languages.Remove(language);
	}

	public void RemoveProgrammingLanguages(IEnumerable<string> names)
	{
		foreach(var name in names)
		{
			RemoveProgrammingLanguage(name);
		}
	}

	public void ChangeDifficulty(ProjectDifficulty difficulty)
	{
		ProjectDifficultyId = difficulty.Id;
		ProjectDifficulty = difficulty;
		AddEvent(new ProjectDifficultyChangedEvent(this, difficulty));
	}

	public void ChangeEstimatedTimeToFinish(EstimatedTime time)
	{
		EstimatedTimeToFinish = time;
		AddEvent(new ProjectEstimatedTimeToFinishChangedEvent(this, time));
	}

	public void ChangeDeadline(Deadline deadline)
	{
		Deadline = deadline;
		AddEvent(new ProjectDeadlineChangedEvent(this, deadline));
	}

	public void ChangeState(ProjectState state)
	{
		ProjectStateId = state.Id;
		ProjectState = state;
		AddEvent(new ProjectStateChangedEvent(this, state));
	}

	private ProjectRequirement GetRequirement(string name)
	{
		foreach(var requirement in Requirements)
		{
			if(requirement.Requirement == name)
				return requirement;
		}

		throw new RequirementNotFoundException(name);
	}

	private ProjectTechnology GetTechnology(string name)
	{
		foreach(var technology in Technologies)
		{
			if(technology.Name == name)
				return technology;
		}

		throw new TechnologyNotFoundException(name);
	}

	private ProgrammingLanguage GetLanguage(string name)
	{
		foreach(var language in ProgrammingLanguages)
		{
			if(language.Name == name)
				return language;
		}

		throw new LanguageNotFoundException(name);
	}
	
	private Project()
	{
		// For Entity Framework	
	}
}