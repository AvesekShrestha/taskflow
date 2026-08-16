using Taskflow.Application.Project.DTO;
using Taskflow.Application.Project.Mapper;
using Taskflow.Domain.Project;
using Taskflow.Domain.Shared.Interfaces;

namespace Taskflow.Application.Project;

public sealed class ProjectService(IProjectRepository projectRepository, IUnitOfWork unitOfWork) : IProjectService
{

  private readonly IProjectRepository _projectRepository = projectRepository;
  private readonly IUnitOfWork _unitOfWork = unitOfWork;

  public async Task<ProjectResponse> AddProjectAsync(ProjectRequest request)
  {
    Guid Id = Guid.NewGuid();
    ProjectAggregate project = ProjectAggregate.Create(
        Id,
        request.ProjectName
        );

    await _projectRepository.AddAsync(project);
    await _unitOfWork.SaveChangesAsync();

    return project.ToResponse();
  }

  public async Task<ProjectResponse> AddMemberAsync(Guid projectId, MemberRequest request)
  {
    ProjectAggregate project = await _projectRepository.GetByIdAsync(projectId)
      ??
      throw new KeyNotFoundException("No such project exists");

    Guid memberId = Guid.NewGuid();

    project.AddMember(memberId, request.UserId, MemberRoleMapper.ToProjectMemeberRole(request.Role));
    Console.WriteLine($"Project : {project}");

    await _unitOfWork.SaveChangesAsync();
    return project.ToResponse();
  }

  public async Task<ProjectResponse> ChangeMemberRoleAsync(Guid projectId, Guid userId, ChangeMemberRoleRequest request)
  {
    ProjectAggregate project = await _projectRepository.GetByIdAsync(projectId)
      ?? throw new KeyNotFoundException("No such project");

    project.ChangeMemberRole(userId, MemberRoleMapper.ToProjectMemeberRole(request.Role));
    await _unitOfWork.SaveChangesAsync();

    return project.ToResponse();
  }

  public async Task<ProjectResponse> GetByIdAsync(Guid id)
  {
    ProjectAggregate project = await _projectRepository.GetByIdAsync(id)
      ?? throw new KeyNotFoundException("Project doesnot exits");

    return project.ToResponse();
  }

  public async Task RemoveProjectAsync(Guid id)
  {
    ProjectAggregate project = await _projectRepository.GetByIdAsync(id)
          ?? throw new KeyNotFoundException("Project doesnot exits");
    await _projectRepository.RemoveAsync(project);
    await _unitOfWork.SaveChangesAsync();
  }

  public async Task<ProjectResponse> RemoveMemberAsync(Guid projectId, Guid userId)
  {
    ProjectAggregate project = await _projectRepository.GetByIdAsync(projectId)
          ?? throw new KeyNotFoundException("Project doesnot exit");

    project.RemoveMember(userId);
    await _unitOfWork.SaveChangesAsync();

    return project.ToResponse();
  }
}
