using MediatR;

namespace Application.Shared.Interfaces.Messaging
{
    public interface IQueryHandler<TQuery, TResponse>
        : IRequestHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
    {

    }
}
