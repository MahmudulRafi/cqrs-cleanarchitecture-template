using Domain.Entities;

namespace Application.Services.Organizations
{
    public interface IOrganizationService
    {
        Task<List<Organization>> GetOrganizationsAsync();
    }
}
