using System.ComponentModel.DataAnnotations;

namespace Taskflow.Application.Issue.DTO;

public sealed record AssignUserRequest(
    [Required(ErrorMessage = "UserId is required")]
    Guid UserId
);
