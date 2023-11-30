using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IOrganizationService
    {
        Task<List<Organization>> GetOrganizationsAsync();
    }
}
