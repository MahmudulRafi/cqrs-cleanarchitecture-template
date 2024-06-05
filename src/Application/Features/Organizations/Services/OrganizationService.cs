using Application.DTOs.Responses;
using Domain.Entities;
using Domain.Models.Requests;
using Domain.Models.Responses;
using Domain.Repositories.Common;
using System.Linq.Expressions;

namespace Application.Features.Organizations.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrganizationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateOrganizationAsync(Organization organization)
        {
            await _unitOfWork.Organizations.AddAsync(organization);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Organization> GetOrganizationByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Organizations.GetByIdAsync(id, cancellationToken);
        }

        public async Task<List<Organization>> GetOrganizationsAsync(CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Organizations.GetItemsAsync(cancellationToken);
        }

        public async Task<PaginatedResponse<List<Organization>>> GetOrganizationsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var filtedRequest = new FilteredItemRequest<Organization>()
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return await _unitOfWork.Organizations.GetItemsAsync(filtedRequest, cancellationToken);
        }

        public async Task<bool> OrganizationNameExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Organizations.EntryExists(a => a.Name == name, cancellationToken);
        }
    }
}
