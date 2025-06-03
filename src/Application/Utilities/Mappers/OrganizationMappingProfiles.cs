using Application.Features.Organizations.Commands;
using Application.Features.Organizations.Commands.CreateOrganization;
using AutoMapper;
using Domain.Entities;

namespace Application.Utilities.Mappers
{
    public class OrganizationMappingProfiles : Profile
    {
        public OrganizationMappingProfiles()
        {
            CreateMap<CreateOrganizationCommand, Organization>();
        }
    }
}
