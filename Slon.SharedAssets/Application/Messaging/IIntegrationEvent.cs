namespace Slon.SharedAssets.Application.Messaging;

/// <summary>
/// Represents an integration event in a distributed system.
/// </summary>
public interface IIntegrationEvent
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
