using Taskflow.Application.Project.DTO;
using Taskflow.Domain.Project;

namespace Taskflow.Application.Project.Mapper;

public static class ProjectMapper
{

  public static ProjectAggregate ToAggregate(this ProjectRequest project, Guid id)
  {
    return ProjectAggregate.Create(
        id,
        project.ProjectName
        );
  }

  public static ProjectResponse ToResponse(this ProjectAggregate project)
  {
    return new ProjectResponse(
        project.Id,
        project.ProjectName,
        project.Members
        );
  }
}
