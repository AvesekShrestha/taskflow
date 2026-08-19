namespace Taskflow.Application.User.Authentication;

public interface IPasswordHasher
{

  string HashPassword(string rawPassword);
  bool VerifyPassword(string rawPassword, string hashedPassword);

}

