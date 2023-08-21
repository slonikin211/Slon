namespace Slon.SharedAssets.Domain.Interfaces;

/// <summary>
/// Represents the interface for an aggregate root in Domain-Driven Design (DDD) principles.
/// An aggregate root is a fundamental concept that acts as a boundary for a group of related
/// entities and value objects within the domain model.
/// </summary>
/// <typeparam name="TEntityId">The type of the aggregate root's unique identifier.</typeparam>
public interface IAggregateRoot<TEntityId> : IEntity<TEntityId>
{
    /// <summary>
    /// Gets the collection of domain events associated with the aggregate root.
    /// Domain events represent important changes or occurrences within the domain
    /// that need to be communicated to other parts of the application.
    /// </summary>
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    /// <summary>
    /// Clears the collection of domain events associated with the aggregate root.
    /// After the domain events have been processed, this method should be called
    /// to reset the state and prevent duplicate event processing.
    /// </summary>
    void ClearDomainEvents();
}
