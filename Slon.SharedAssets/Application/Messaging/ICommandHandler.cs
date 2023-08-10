using MediatR;
using Slon.SharedAssets.Common;

namespace Slon.SharedAssets.Application.Messaging;

/// <summary>
/// Represents the base interface for a command handler without a response.
/// </summary>
/// <typeparam name="TCommand">The type of the command being handled.</typeparam>
public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{
}

/// <summary>
/// Represents the base interface for a command handler with a response.
/// </summary>
/// <typeparam name="TCommand">The type of the command being handled.</typeparam>
/// <typeparam name="TResponse">The type of the response expected from the command.</typeparam>
public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{
}
