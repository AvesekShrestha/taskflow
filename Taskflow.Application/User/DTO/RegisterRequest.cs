using System.ComponentModel.DataAnnotations;

namespace Taskflow.Application.User.DTO;

public sealed record RegisterRequest(
   [Required(ErrorMessage = "Username is required")]
  string Username,

   [Required(ErrorMessage = "Email is required")]
  string Email,

   [Required(ErrorMessage = "Password is required")]
   [MinLength(8, ErrorMessage = "Minimum length for password should be atleast 8 character")]
  string Password
);
