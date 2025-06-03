using Application.Interfaces.Organizations;
using Application.Models.Common;
using Application.Shared.Interfaces.Messaging;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Features.Organizations.Commands.CreateOrganization
{
    public class CreateOrganizationCommandHandler : ICommandHandler<CreateOrganizationCommand, Result<Organization>>
    {
        private readonly IOrganizationService _organizationService;
        private readonly IValidator<CreateOrganizationCommand> _validator;
        public CreateOrganizationCommandHandler(IOrganizationService organizationService, IValidator<CreateOrganizationCommand> validator)
        {
            _organizationService = organizationService;
            _validator = validator;
        }
        public async Task<Result<Organization>> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return ResponseHandler.HandleValidationError<Organization>(validationResult.Errors);
            }

            Organization organization = new()
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone
            };

            bool response = await _organizationService.CreateOrganizationAsync(organization, cancellationToken);

            if (response) return ResponseHandler.HandleSuccess<Organization>(organization);

            else return ResponseHandler.HandleError<Organization>("Unable create organization");
        }
    }
}
