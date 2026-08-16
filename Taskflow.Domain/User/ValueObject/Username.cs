namespace Taskflow.Domain.User.ValueObject;

using Taskflow.Domain.Shared;

public sealed class Username : ValueObject
{
  public string Value { get; }

  private Username(string value)
  {
    Value = value;
  }

  public static Username Create(string value)
  {
    if (string.IsNullOrWhiteSpace(value))
      throw new ArgumentException("Username cannot be empty.");

    return new Username(value);
  }

  public override string ToString()
  {
    return Value;
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}

