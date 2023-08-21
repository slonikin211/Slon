namespace Slon.SharedAssets.Application.Clock;

/// <summary>
/// Represents an interface for a date and time provider in an application.
/// Date and time providers are used to obtain the current Coordinated Universal Time (UTC) time.
/// </summary>
public interface IDateTimeProvider
{
    /// <summary>
    /// Gets the current Coordinated Universal Time (UTC) time.
    /// </summary>
    DateTime UtcNow { get; }
}

