using Microsoft.EntityFrameworkCore;
using Taskflow.Domain.Project;

namespace Taskflow.Infrastructure.Persistence.Repository;

public sealed class ProjectRepository(AppDbContext db) : IProjectRepository
{
  private readonly AppDbContext _db = db;

  public async Task AddAsync(ProjectAggregate project)
  {
    await _db.AddAsync(project);
  }

  public async Task<ProjectAggregate?> GetByIdAsync(Guid id)
  {
    return await _db.Project
      .FirstOrDefaultAsync(property => property.Id == id);
  }

  public async Task<ProjectAggregate?> GetByUserId(Guid userId)
  {
    return await _db.Project.FirstOrDefaultAsync(project =>
      project.Members.Any(member =>
        member.UserId == userId)
    );
  }

  public async Task RemoveAsync(ProjectAggregate project)
  {
    _db.Project.Remove(project);
  }
}
