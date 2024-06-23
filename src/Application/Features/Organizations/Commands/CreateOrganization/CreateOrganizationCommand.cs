using Application.Abstractions.Messaging;
using Application.DTOs.Responses;

namespace Application.Features.Organizations.Commands.CreateOrganization
{
    public class CreateOrganizationCommand : ICommand<ServiceResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string ReportingUserId { get; set; } = string.Empty;
    }
}
