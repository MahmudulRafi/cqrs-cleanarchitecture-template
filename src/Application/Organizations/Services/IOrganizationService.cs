using Domain.Entities;

namespace Application.Organizations.Services
{
    public interface IOrganizationService
    {
        Task<List<Organization>> GetOrganizationsAsync(CancellationToken cancellationToken = default);
        Task<Organization> GetOrganizationByIdAsync(string id, CancellationToken cancellationToken = default);
    }
}
