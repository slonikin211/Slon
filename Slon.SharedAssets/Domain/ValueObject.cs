namespace Slon.SharedAssets.Domain;

/// <summary>
/// Represents an abstract base class for value objects.
/// </summary>
public abstract class ValueObject
{
    /// <summary>
    /// Gets the equality components of the value object.
    /// </summary>
    /// <returns>An enumerable of the equality components.</returns>
    protected abstract IEnumerable<object> GetEqualityComponents();

    /// <summary>
    /// Determines whether the current value object is equal to another object.
    /// </summary>
    /// <param name="obj">The object to compare with the current value object.</param>
    /// <returns><c>true</c> if the objects are considered equal; otherwise, <c>false</c>.</returns>
    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObject)obj;
        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    /// <summary>
    /// Returns the hash code for the value object.
    /// </summary>
    /// <returns>A hash code value.</returns>
    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }
}
