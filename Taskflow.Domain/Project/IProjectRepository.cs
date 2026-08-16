namespace Taskflow.Domain.Project;

public interface IProjectRepository
{
  Task<ProjectAggregate?> GetByIdAsync(Guid id);
  Task<ProjectAggregate?> GetByUserId(Guid userId);
  Task AddAsync(ProjectAggregate project);
  Task RemoveAsync(ProjectAggregate project);
}
