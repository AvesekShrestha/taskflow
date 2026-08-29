using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taskflow.Application.Project;
using Taskflow.Application.Project.DTO;

namespace Taskflow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ProjectController(IProjectService projectService) : ControllerBase
{

  private readonly IProjectService _projectService = projectService;

  [Authorize]
  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(Guid id)
  {
    ProjectResponse result = await _projectService.GetByIdAsync(id);
    return Ok(result);
  }

  [Authorize]
  [HttpPost]
  public async Task<IActionResult> AddProject(ProjectRequest request)
  {
    ProjectResponse result = await _projectService.AddProjectAsync(request);
    return CreatedAtAction(
        nameof(GetById),
        new { id = result.Id },
        result
        );
  }

  [Authorize]
  [HttpPost("{projectId}/member")]
  public async Task<IActionResult> AddMember(Guid projectId, MemberRequest request)
  {
    Console.WriteLine("Inside the add member controller");
    ProjectResponse result = await _projectService.AddMemberAsync(projectId, request);
    return Ok(result);
  }

  [Authorize]
  [HttpPatch("{projectId}/member/{userId}")]
  public async Task<IActionResult> ChangeMemberRole(Guid projectId, Guid userId, ChangeMemberRoleRequest request)
  {
    ProjectResponse result = await _projectService.ChangeMemberRoleAsync(projectId, userId, request);
    return Ok(result);
  }

  [Authorize]
  [HttpDelete("{projectId}/member/{userId}")]
  public async Task<IActionResult> RemoveMember(Guid projectId, Guid userId)
  {
    ProjectResponse result = await _projectService.RemoveMemberAsync(projectId, userId);
    return Ok(result);
  }

  [Authorize]
  [HttpDelete("{projectId}")]
  public async Task<IActionResult> RemoveProject(Guid projectId)
  {
    await _projectService.RemoveProjectAsync(projectId);
    return Ok("Project Deleted Successfully");
  }

}

