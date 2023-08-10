using Slon.SharedAssets.Domain.Interfaces;

namespace Slon.SharedAssets.Domain;

/// <summary>
/// Represents an abstract base class for entities in the domain, implementing the <see cref="IEntity"/> interface.
/// </summary>
/// <typeparam name="TEntityId">The type of the entity's unique identifier.</typeparam>
public abstract class Entity<TEntityId> : IEntity
    where TEntityId : new()
{
    private readonly List<IDomainEvent> _domainEvents = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="Entity{TEntityId}"/> class with the provided identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    protected Entity(TEntityId id)
    {
        Id = id;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Entity{TEntityId}"/> class with a new identifier.
    /// </summary>
    protected Entity()
    {
        Id = new TEntityId();
    }

    /// <summary>
    /// Gets or sets the unique identifier of the entity.
    /// </summary>
    public TEntityId Id { get; init; }

    /// <summary>
    /// Retrieves a read-only list of domain events associated with the entity.
    /// </summary>
    /// <returns>A read-only list of domain events.</returns>
    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }

    /// <summary>
    /// Clears the list of domain events associated with the entity.
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    /// <summary>
    /// Adds a domain event to the list of events associated with the entity.
    /// </summary>
    /// <param name="domainEvent">The domain event to be added.</param>
    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}