namespace Slon.SharedAssets.Application.Messaging;

/// <summary>
/// Represents an integration event in a distributed system.
/// </summary>
public interface IIntegrationEvent
{
    /// <summary>
    /// Gets the unique identifier of the integration event.
    /// </summary>
    Guid Id { get; init; }
}
