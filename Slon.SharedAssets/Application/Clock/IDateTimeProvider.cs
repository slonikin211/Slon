namespace Slon.SharedAssets.Application.Clock;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
