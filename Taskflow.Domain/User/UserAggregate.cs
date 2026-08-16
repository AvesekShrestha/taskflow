using Taskflow.Domain.Shared;
using Taskflow.Domain.User.ValueObject;

namespace Taskflow.Domain.User;

public sealed class UserAggregate : AggregateRoot<Guid>
{
  public Username Username { get; private set; } = null!;
  public Email Email { get; private set; } = null!;
  public Password Password { get; private set; } = null!;
  public UserRole Role { get; private set; } = UserRole.User;

  private UserAggregate(Guid id) : base(id) { }

  private UserAggregate(Guid id, Username username, Email email, Password password) : base(id)
  {
    Username = username;
    Email = email;
    Password = password;
  }


  public static UserAggregate Create(Guid id, string username, string email, string password)
  {
    Username validUsername = Username.Create(username);
    Email validEmail = Email.Create(email);
    Password validPassword = Password.Create(password);

    return new UserAggregate(id, validUsername, validEmail, validPassword);
  }

  public void UpdateUsername(string newUsername)
  {
    Username = Username.Create(newUsername);
  }

  public void UpdateEmail(string email)
  {
    Email = Email.Create(email);
  }

  public void ChangePassword(string newPassword)
  {
    Password = Password.Create(newPassword);
  }

  public void ChangeRole(UserRole newRole)
  {
    Role = newRole;
  }
}
