using Taskflow.Application.User.Authentication;

namespace Taskflow.Infrastructure.Authentication;

public sealed class PasswordHasher : IPasswordHasher
{
  public string HashPassword(string rawPassword)
  {
    return BCrypt.Net.BCrypt.HashPassword(rawPassword);
  }

  public bool VerifyPassword(string rawPassword, string hashedPassword)
  {
    return BCrypt.Net.BCrypt.Verify(rawPassword, hashedPassword);
  }
}
