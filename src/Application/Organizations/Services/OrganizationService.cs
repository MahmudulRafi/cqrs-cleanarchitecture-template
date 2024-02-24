using Domain.Entities;
using Domain.Repositories.Common;

namespace Application.Organizations.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrganizationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Organization> GetOrganizationByIdAsync(string id)
        {
            return await _unitOfWork.Organizations.GetByIdAsync(id);
        }

        public async Task<List<Organization>> GetOrganizationsAsync()
        {
            return await _unitOfWork.Organizations.GetAllAsync();
        }
    }
}
