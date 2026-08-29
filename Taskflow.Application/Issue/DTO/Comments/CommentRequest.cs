using System.ComponentModel.DataAnnotations;

namespace Taskflow.Application.Issue.DTO.Comments;

public sealed record CommentRequest(
  [Required(ErrorMessage = "Content is must")]
  [MinLength(1, ErrorMessage = "Content length should be atleast of 1 character")]
  string Content
);
