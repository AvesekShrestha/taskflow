using System.ComponentModel.DataAnnotations;

namespace Taskflow.Application.Project.DTO;

public sealed record ChangeMemberRoleRequest(
    [Required(ErrorMessage = "Role is required")]
    string Role
);
