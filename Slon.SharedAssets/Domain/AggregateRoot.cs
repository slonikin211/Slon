using System.Collections.Generic;
using System.Linq;
using Slon.SharedAssets.Domain.Interfaces;

namespace Slon.SharedAssets.Domain;

/// <summary>
/// Represents an abstract base class for aggregate roots in Domain-Driven Design (DDD) principles.
/// An aggregate root is a fundamental concept that acts as a boundary for a group of related
/// entities and value objects within the domain model.
/// </summary>
/// <typeparam name="TEntityId">The type of the aggregate root's unique identifier.</typeparam>
public abstract class AggregateRoot<TEntityId> : IAggregateRoot<TEntityId>
    where TEntityId : new()
{
    /// <summary>
    /// Gets or sets the unique identifier of the aggregate root.
    /// </summary>
    public TEntityId Id { get; init; }

    private readonly List<IDomainEvent> _domainEvents = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="AggregateRoot{TEntityId}"/> class with a new identifier.
    /// </summary>
    protected AggregateRoot() => Id = new TEntityId();

    /// <summary>
    /// Initializes a new instance of the <see cref="AggregateRoot{TEntityId}"/> class with the provided identifier.
    /// </summary>
    /// <param name="id">The unique identifier for the aggregate root.</param>
    protected AggregateRoot(TEntityId id) => Id = id;

    /// <summary>
    /// Gets the collection of domain events associated with the aggregate root.
    /// Domain events represent important changes or occurrences within the domain
    /// that need to be communicated to other parts of the application.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.ToList().AsReadOnly();

    /// <summary>
    /// Clears the collection of domain events associated with the aggregate root.
    /// After the domain events have been processed, this method should be called
    /// to reset the state and prevent duplicate event processing.
    /// </summary>
    public void ClearDomainEvents() => _domainEvents.Clear();

    /// <summary>
    /// Adds a domain event to the collection of domain events associated with the aggregate root.
    /// </summary>
    /// <param name="domainEvent">The domain event to be added.</param>
    protected void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}
