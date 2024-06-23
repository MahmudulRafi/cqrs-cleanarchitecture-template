using Application.Abstractions.Messaging;
using Application.DTOs.Responses;
using Application.Features.Organizations.Services;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Features.Organizations.Commands.CreateOrganization
{
    public class CreateOrganizationCommandHandler : ICommandHandler<CreateOrganizationCommand, ServiceResponse>
    {
        private readonly IOrganizationService _organizationService;
        private readonly IValidator<CreateOrganizationCommand> _validator;
        public CreateOrganizationCommandHandler(IOrganizationService organizationService, IValidator<CreateOrganizationCommand> validator)
        {
            _organizationService = organizationService;
            _validator = validator;
        }
        public async Task<ServiceResponse> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return ServiceResponseHandler.HandleValidationError(validationResult.Errors);
            }

            Organization organization = new()
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                ReportingUserId = request.ReportingUserId
            };

            bool response = await _organizationService.CreateOrganizationAsync(organization, cancellationToken);

            if (response) return ServiceResponseHandler.HandleSuccess();

            else return ServiceResponseHandler.HandleFailure("Unable create organization");
        }
    }
}
