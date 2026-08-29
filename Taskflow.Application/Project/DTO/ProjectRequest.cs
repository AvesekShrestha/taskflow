using System.ComponentModel.DataAnnotations;

namespace Taskflow.Application.Project.DTO;

public sealed record ProjectRequest(
    [Required(ErrorMessage = "Project name is required")]
    string ProjectName
);
