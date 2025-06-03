using MediatR;

namespace Application.Shared.Interfaces.Messaging
{
    public interface ICommandHandler<in TCommand>
        : IRequestHandler<TCommand> where TCommand : ICommand
    {

    }

    public interface ICommandHandler<TCommand, TResponse>
        : IRequestHandler<TCommand, TResponse> where TCommand : ICommand<TResponse>
    {

    }
}
