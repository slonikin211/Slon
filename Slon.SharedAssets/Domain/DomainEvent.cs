using Slon.SharedAssets.Domain.Interfaces;

namespace Slon.SharedAssets.Domain;

/// <summary>
/// Represents a base class for domain events in the application.
/// </summary>
public abstract class DomainEvent : IDomainEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainEvent"/> class with the specified ID and occurrence timestamp.
    /// </summary>
    /// <param name="id">The unique identifier for the domain event.</param>
    /// <param name="occuredOnUtc">The timestamp indicating when the domain event occurred in Coordinated Universal Time (UTC).</param>
    protected DomainEvent(Guid id, DateTime occuredOnUtc)
        : this()
    {
        Id = id;
        OccurredOnUtc = occuredOnUtc;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainEvent"/> class.
    /// </summary>
    private DomainEvent()
    {
    }

    /// <summary>
    /// Gets the unique identifier for the domain event.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the timestamp indicating when the domain event occurred in Coordinated Universal Time (UTC).
    /// </summary>
    public DateTime OccurredOnUtc { get; init; }
}
