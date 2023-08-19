using MediatR;
using Slon.SharedAssets.Domain.Interfaces;

namespace Slon.SharedAssets.Application.Messaging;

#pragma warning disable CA1711 // Identifiers should not have incorrect suffix

/// <summary>
/// Represents a handler for domain events.
/// </summary>
public interface IDomainEventHandler<TDomainEvent>
    : INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
}
#pragma warning restore CA1711 // Identifiers should not have incorrect suffix