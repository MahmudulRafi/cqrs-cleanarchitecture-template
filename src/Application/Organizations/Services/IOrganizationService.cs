using Domain.Entities;

namespace Application.Organizations.Services
{
    public interface IOrganizationService
    {
        Task<List<Organization>> GetOrganizationsAsync();
    }
}
