using Application.Abstractions.Messaging;
using Application.DTOs.Responses;

namespace Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IQuery<ServiceResponse>
    {
        public string Id { get; set; } = string.Empty;
    }
}
