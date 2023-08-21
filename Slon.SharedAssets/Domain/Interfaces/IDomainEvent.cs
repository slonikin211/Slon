using MediatR;

namespace Slon.SharedAssets.Domain.Interfaces;

/// <summary>
/// Represents the interface for a domain event in Domain-Driven Design (DDD) principles.
/// Domain events capture significant occurrences or changes within the domain and are used
/// to communicate these events to other parts of the application.
/// </summary>
public interface IDomainEvent : INotification
{
    /// <summary>
    /// Gets the unique identifier for the domain event.
    /// </summary>
    Guid Id { get; init; }

    /// <summary>
    /// Gets the timestamp indicating when the domain event occurred in Coordinated Universal Time (UTC).
    /// </summary>
    DateTime OccurredOnUtc { get; init; }
}
