using StudyBuddy.Application.Projects.DTOs;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Queries.GetAll;

public class GetAllProjectsRequestHandler
    : IQueryHandler<GetAllProjectsRequest, IEnumerable<ProjectDto>>
{
    private readonly IProjectRepository _projectRepository;

    public GetAllProjectsRequestHandler(
        IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<IEnumerable<ProjectDto>> Handle(
        GetAllProjectsRequest request,
        CancellationToken cancellationToken)
    {
        var projects = await _projectRepository.GetAll(cancellationToken);
        var list = projects.ToList();
        
        if (!list.Any())
        {
            throw new Exception("No project found in the database.");
        }

        return list.Select(Mapper.ProjectDto);
    }
}