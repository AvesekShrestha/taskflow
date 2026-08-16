namespace Taskflow.Domain.Shared;

public abstract class ValueObject : IEquatable<ValueObject>
{
  protected abstract IEnumerable<object> GetEqualityComponents();

  public override bool Equals(object? obj)
  {
    if (obj is null || obj.GetType() != GetType())
    {
      return false;
    }

    ValueObject valueObject = (ValueObject)obj;
    return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
  }

  public override int GetHashCode()
  {
    return GetEqualityComponents().Aggregate(0, (hash, component) => HashCode.Combine(hash, component));
  }

  public bool Equals(ValueObject? other)
  {
    return Equals((object?)other);
  }

  public static bool operator ==(ValueObject? left, ValueObject? right)
  {
    return Equals(left, right);
  }

  public static bool operator !=(ValueObject? left, ValueObject? right)
  {
    return !Equals(left, right);
  }
}

