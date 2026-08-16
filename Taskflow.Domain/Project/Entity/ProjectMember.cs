using Taskflow.Domain.Shared;

namespace Taskflow.Domain.Project.Entity;

public sealed class ProjectMember : Entity<Guid>
{
  public Guid UserId { get; private set; }
  public ProjectMemberRole Role { get; private set; }
  public DateTime JoinedAt { get; private set; } = DateTime.UtcNow;

  internal ProjectMember(Guid id, Guid userId, ProjectMemberRole role) : base(id)
  {
    UserId = userId;
    Role = role;
  }

  internal void ChangeRole(ProjectMemberRole newRole)
  {
    Role = newRole;
  }
}
