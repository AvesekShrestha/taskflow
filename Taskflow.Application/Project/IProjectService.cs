using Taskflow.Application.Project.DTO;

namespace Taskflow.Application.Project;

public interface IProjectService
{
  Task<ProjectResponse> GetByIdAsync(Guid id);
  Task<ProjectResponse> AddProjectAsync(ProjectRequest request);
  Task RemoveProjectAsync(Guid id);
  Task<ProjectResponse> AddMemberAsync(Guid projectId, MemberRequest request);
  Task<ProjectResponse> RemoveMemberAsync(Guid projectId, Guid userId);
  Task<ProjectResponse> ChangeMemberRoleAsync(Guid projectId, Guid userId, ChangeMemberRoleRequest request);
}
