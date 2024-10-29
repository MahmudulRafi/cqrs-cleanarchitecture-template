using Application.Abstractions.Messaging;
using Application.DTOs.Responses;

namespace Application.Features.Organizations.Queries.GetAllOrganization
{
    public class GetAllOrganizationQuery : IQuery<ServiceResponse>
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }
}
