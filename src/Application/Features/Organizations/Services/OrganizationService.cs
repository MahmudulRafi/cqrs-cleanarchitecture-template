using Domain.Entities;
using Domain.Repositories.Common;

namespace Application.Features.Organizations.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrganizationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Organization> GetOrganizationByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Organizations.GetByIdAsync(id, cancellationToken);
        }

        public async Task<List<Organization>> GetOrganizationsAsync(CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Organizations.GetAllAsync(cancellationToken);
        }
    }
}
