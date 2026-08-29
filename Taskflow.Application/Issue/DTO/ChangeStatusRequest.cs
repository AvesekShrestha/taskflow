using System.ComponentModel.DataAnnotations;

namespace Taskflow.Application.Issue.DTO;

public sealed record ChangeStatusRequest(
    [Required(ErrorMessage = "Status is required")]
    string Status
);
