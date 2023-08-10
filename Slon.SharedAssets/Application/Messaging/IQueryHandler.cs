using MediatR;
using Slon.SharedAssets.Common;

namespace Slon.SharedAssets.Application.Messaging;

/// <summary>
/// Represents the base interface for a query handler.
/// </summary>
/// <typeparam name="TQuery">The type of the query being handled.</typeparam>
/// <typeparam name="TResponse">The type of the response expected from the query.</typeparam>
public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
