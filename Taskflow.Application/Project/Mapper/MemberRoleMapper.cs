using Taskflow.Domain.Project;

namespace Taskflow.Application.Project.Mapper;

public static class MemberRoleMapper
{
  public static ProjectMemberRole ToProjectMemeberRole(string role)
  {
    bool success = Enum.TryParse(
        role,
        true,
        out ProjectMemberRole Role
        );

    if (!success) throw new InvalidOperationException("Invalid project member role");
    return Role;
  }
}
