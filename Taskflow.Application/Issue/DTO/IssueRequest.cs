using System.ComponentModel.DataAnnotations;

namespace Taskflow.Application.Issue.DTO;

public sealed record IssueRequest(
  [Required(ErrorMessage = "Title is required")]
  string Title,

  [Required(ErrorMessage = "Description is required")]
  string Description,

  [Required(ErrorMessage = "ProjectId is required")]
  Guid ProjectId
);
