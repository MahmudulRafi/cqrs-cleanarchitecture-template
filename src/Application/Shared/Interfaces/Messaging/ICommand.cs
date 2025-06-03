using MediatR;

namespace Application.Shared.Interfaces.Messaging
{
    public interface ICommand : IRequest
    {

    }

    public interface ICommand<out TResponse> : IRequest<TResponse>
    {

    }
}
