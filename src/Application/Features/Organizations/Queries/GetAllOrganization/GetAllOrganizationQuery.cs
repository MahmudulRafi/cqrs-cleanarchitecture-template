using Application.Models.Common;
using Application.Shared.Interfaces.Messaging;
using Domain.Entities;
using Domain.Models.Responses;

namespace Application.Features.Organizations.Queries.GetAllOrganization
{
    public class GetAllOrganizationQuery : IQuery<Result<PaginatedResponse<List<Organization>>>>
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }
}
