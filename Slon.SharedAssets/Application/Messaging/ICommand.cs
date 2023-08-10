using MediatR;
using Slon.SharedAssets.Common;

namespace Slon.SharedAssets.Application.Messaging;


/// <summary>
/// Represents the base interface for a command without a response.
/// </summary>
public interface ICommand : IRequest<Result>, IBaseCommand
{
}

/// <summary>
/// Represents the base interface for a command with a response.
/// </summary>
/// <typeparam name="TResponse">The type of the response expected from the command.</typeparam>
public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
{
}

/// <summary>
/// Represents the base interface for a command.
/// </summary>
public interface IBaseCommand
{
}
