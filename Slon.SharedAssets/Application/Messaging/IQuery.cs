using MediatR;
using Slon.SharedAssets.Common;

namespace Slon.SharedAssets.Application.Messaging;

/// <summary>
/// Represents the base interface for a query with a response.
/// </summary>
/// <typeparam name="TResponse">The type of the response expected from the query.</typeparam>
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}