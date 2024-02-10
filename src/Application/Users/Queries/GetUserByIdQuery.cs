using Application.Common.DTOs.Response;
using MediatR;

namespace Application.Users.Queries
{
    public class GetUserByIdQuery : IRequest<ServiceResponse>
    {
        public string Id { get; set; } = string.Empty;  
    }
}
