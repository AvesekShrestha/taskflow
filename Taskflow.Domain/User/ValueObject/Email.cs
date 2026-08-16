namespace Taskflow.Domain.User.ValueObject;

using Taskflow.Domain.Shared;

public sealed class Email : ValueObject
{

  public string Value { get; }

  private Email(string value)
  {
    Value = value;
  }

  public static Email Create(string value)
  {
    if (string.IsNullOrWhiteSpace(value))
      throw new ArgumentException("Email cannot be empty.");

    if (!value.Contains("@") || !value.Contains("."))
      throw new ArgumentException("Email is not valid.");

    return new Email(value);
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
