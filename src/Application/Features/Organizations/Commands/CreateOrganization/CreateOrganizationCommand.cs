using Application.Models.Common;
using Application.Shared.Interfaces.Messaging;
using Domain.Entities;

namespace Application.Features.Organizations.Commands.CreateOrganization
{
    public class CreateOrganizationCommand : ICommand<Result<Organization>>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string ReportingUserId { get; set; } = string.Empty;
    }
}
