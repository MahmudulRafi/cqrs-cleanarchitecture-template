using Domain.Entities;

namespace Application.Organizations.Services
{
    public interface IOrganizationService
    {
        Task<List<Organization>> GetOrganizationsAsync();
        Task<Organization> GetOrganizationByIdAsync(string id);
    }
}
