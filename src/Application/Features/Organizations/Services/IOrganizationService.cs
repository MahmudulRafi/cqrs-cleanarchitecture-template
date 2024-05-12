using Application.DTOs.Responses;
using Domain.Entities;
using Domain.Models.Responses;

namespace Application.Features.Organizations.Services
{
    public interface IOrganizationService
    {
        Task<bool> CreateOrganizationAsync(Organization organization);
        Task<List<Organization>> GetOrganizationsAsync(CancellationToken cancellationToken = default);
        Task<PaginatedResponse<List<Organization>>> GetOrganizationsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        Task<Organization> GetOrganizationByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<bool> OrganizationNameExistsAsync(string name, CancellationToken cancellationToken = default);
    }
}
