using Application.Common.DTOs.Response;
using MediatR;

namespace Application.Organizations.Queries
{
    public class GetOrganizationByIdQuery : IRequest<ServiceResponse>
    {
        public string Id { get; set; } = string.Empty;
    }
}
