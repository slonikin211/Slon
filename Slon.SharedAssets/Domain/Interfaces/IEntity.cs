namespace Slon.SharedAssets.Domain.Interfaces;

/// <summary>
/// Represents the interface for an entity in Domain-Driven Design (DDD) principles.
/// Entities are distinct objects within the domain that have a unique identity.
/// </summary>
/// <typeparam name="TEntityId">The type of the entity's unique identifier.</typeparam>
public interface IEntity<TEntityId>
{
    /// <summary>
    /// Gets or sets the unique identifier of the entity.
    /// </summary>
    TEntityId Id { get; init; }
}
