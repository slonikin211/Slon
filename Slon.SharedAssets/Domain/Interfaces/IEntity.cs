namespace Slon.SharedAssets.Domain.Interfaces;

/// <summary>
/// Represents an entity in the domain.
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Retrieves a read-only list of domain events associated with the entity.
    /// </summary>
    /// <returns>A read-only list of domain events.</returns>
    IReadOnlyList<IDomainEvent> GetDomainEvents();

    /// <summary>
    /// Clears the list of domain events associated with the entity.
    /// </summary>
    void ClearDomainEvents();
}