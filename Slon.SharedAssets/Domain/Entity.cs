using Slon.SharedAssets.Domain.Interfaces;

namespace Slon.SharedAssets.Domain;

/// <summary>
/// Represents an abstract base class for entities in Domain-Driven Design (DDD) principles.
/// Entities are distinct objects within the domain that have a unique identity.
/// </summary>
/// <typeparam name="TEntityId">The type of the entity's unique identifier.</typeparam>
public abstract class Entity<TEntityId> : IEntity<TEntityId>
    where TEntityId : new()
{
    /// <summary>
    /// Gets or sets the unique identifier of the entity.
    /// </summary>
    public TEntityId Id { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Entity{TEntityId}"/> class with the provided identifier.
    /// </summary>
    /// <param name="id">The unique identifier for the entity.</param>
    protected Entity(TEntityId id) => Id = id;

    /// <summary>
    /// Initializes a new instance of the <see cref="Entity{TEntityId}"/> class with a new identifier.
    /// </summary>
    protected Entity() => Id = new TEntityId();
}
