using System.ComponentModel.DataAnnotations;

namespace Taskflow.Application.Project.DTO;

public sealed record MemberRequest(

    [Required(ErrorMessage = "UserId is required")]
    Guid UserId,

    [Required(ErrorMessage = "Role is required")]
    string Role
);
