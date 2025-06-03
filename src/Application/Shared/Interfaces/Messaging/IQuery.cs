using MediatR;

namespace Application.Shared.Interfaces.Messaging
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {

    }
}
