using Application.Abstractions.Messaging;
using Application.Common.DTOs.Response;

namespace Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IQuery<ServiceResponse>
    {
        public string Id { get; set; } = string.Empty;  
    }
}
