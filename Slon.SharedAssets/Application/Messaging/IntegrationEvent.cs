using Slon.SharedAssets.Domain;

namespace Slon.SharedAssets.Application.Messaging;

/// <summary>
/// Represents a base class for integration events used within the application.
/// </summary>
public abstract class IntegrationEvent : IIntegrationEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IntegrationEvent"/> class with the specified ID and occurrence timestamp.
    /// </summary>
    /// <param name="id">The unique identifier for the integration event.</param>
    /// <param name="occuredOnUtc">The timestamp indicating when the integration event occurred in Coordinated Universal Time (UTC).</param>
    protected IntegrationEvent(Guid id, DateTime occuredOnUtc)
        : this()
    {
        Id = id;
        OccurredOnUtc = occuredOnUtc;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IntegrationEvent"/> class.
    /// </summary>
    private IntegrationEvent()
    {
    }

    /// <summary>
    /// Gets the unique identifier for the integration event.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the timestamp indicating when the integration event occurred in Coordinated Universal Time (UTC).
    /// </summary>
    public DateTime OccurredOnUtc { get; init; }
}

