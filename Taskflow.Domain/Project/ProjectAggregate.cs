using Taskflow.Domain.Project.Entity;
using Taskflow.Domain.Shared;

namespace Taskflow.Domain.Project;

public sealed class ProjectAggregate : AggregateRoot<Guid>
{
  private readonly List<ProjectMember> _members = new();

  public string ProjectName { get; private set; }
  public IReadOnlyCollection<ProjectMember> Members => _members.AsReadOnly();

  private ProjectAggregate(Guid id, string projectName) : base(id)
  {
    ProjectName = projectName;
  }

  public static ProjectAggregate Create(Guid id, string projectName)
  {
    if (string.IsNullOrWhiteSpace(projectName))
      throw new ArgumentException("Project name cannot be empty.");
    return new ProjectAggregate(id, projectName);
  }

  public void AddMember(Guid id, Guid userId, ProjectMemberRole role)
  {
    if (_members.Any(m => m.UserId == userId))
      throw new InvalidOperationException("User is already a member of the project.");

    _members.Add(new ProjectMember(id, userId, role));
  }

  public void RemoveMember(Guid userId)
  {
    ProjectMember? existingMember = _members.FirstOrDefault(m => m.UserId == userId)
      ??
      throw new InvalidOperationException("User is not a member of the project.");

    _members.Remove(existingMember);
  }

  public void ChangeMemberRole(Guid userId, ProjectMemberRole newRole)
  {
    ProjectMember existingMember = _members.FirstOrDefault(m => m.UserId == userId)
      ??
      throw new InvalidOperationException("User is not a member of the project.");
    existingMember.ChangeRole(newRole);
  }
}


