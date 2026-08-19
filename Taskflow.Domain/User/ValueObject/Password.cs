namespace Taskflow.Domain.User.ValueObject;

using Taskflow.Domain.Shared;

public sealed class Password : ValueObject
{
  public string Value { get; }

  private Password(string value)
  {
    Value = value;
  }

  public static Password Create(string value)
  {
    if (string.IsNullOrWhiteSpace(value))
      throw new ArgumentException("Password cannot be empty.");

    if (value.Length < 8)
      throw new ArgumentException("Password must be at least 8 characters long.");



    return new Password(value);
  }

  public bool VerifyPassword(string password)
  {
    if (password != Value) return false;
    else return true;
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
