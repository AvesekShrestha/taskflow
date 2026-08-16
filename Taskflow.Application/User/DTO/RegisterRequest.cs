namespace Taskflow.Application.User.DTO;

public sealed record RegisterRequest(
  string Username,
  string Email,
  string Password
);
