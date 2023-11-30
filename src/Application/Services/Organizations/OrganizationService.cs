﻿using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories.Common;

namespace Application.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrganizationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Organization>> GetOrganizationsAsync()
        {
            return await _unitOfWork.Organizations.GetAllAsync();
        }
    }
}