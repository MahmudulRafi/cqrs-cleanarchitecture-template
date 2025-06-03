using Domain.Entities;
using Domain.Models.Responses;

namespace Application.Interfaces.Organizations
{
    public interface IOrganizationService
    {
        Task<bool> CreateOrganizationAsync(Organization organization, CancellationToken cancellationToken = default);
        Task<List<Organization>> GetOrganizationsAsync(CancellationToken cancellationToken = default);
        Task<PaginatedResponse<List<Organization>>> GetOrganizationsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        Task<Organization> GetOrganizationByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> OrganizationNameExistsAsync(string name, CancellationToken cancellationToken = default);
    }
}
