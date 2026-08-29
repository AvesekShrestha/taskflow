using System.ComponentModel.DataAnnotations;

namespace Taskflow.Application.User.DTO;

public sealed record LoginRequest(
  [Required(ErrorMessage = "Email is required")]
  string Email,

  [Required(ErrorMessage = "Email is required")]
  [MinLength(8, ErrorMessage = "Minimum length of password must be atleast 8 character")]
  string Password
);

