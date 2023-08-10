using MediatR;

namespace SharedAssets.Domain.Interfaces;

/// <summary>
/// Represents a domain event.
/// </summary>
public interface IDomainEvent : INotification
{
}
