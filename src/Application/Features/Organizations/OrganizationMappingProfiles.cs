using Application.Features.Organizations.Commands;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Organizations
{
    public class OrganizationMappingProfiles : Profile
    {
        public OrganizationMappingProfiles()
        {
            CreateMap<CreateOrganizationCommand, Organization>();
        }
    }
}
