namespace Taskflow.Application.User.DTO;

public sealed record UserResponse(
  Guid Id,
  string Username,
  string Email,
  UserRole Role
);
