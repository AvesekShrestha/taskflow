namespace Taskflow.Application.User.DTO;

public sealed record LoginRequest(
  string Email,
  string Password
);

