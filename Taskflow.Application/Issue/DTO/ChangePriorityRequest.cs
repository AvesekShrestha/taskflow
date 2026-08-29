using System.ComponentModel.DataAnnotations;

namespace Taskflow.Application.Issue.DTO;

public sealed record ChangePriorityRequest(
    [Required(ErrorMessage = "Priority is required")]
    string Priority
);
