using Application.Abstractions.Messaging;
using Application.DTOs.Responses;
using Application.Features.Organizations.Services;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Features.Organizations.Commands
{
    public class CreateOrganizationCommandHandler : ICommandHandler<CreateOrganizationCommand, ServiceResponse>
    {
        private readonly IOrganizationService _organizationService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateOrganizationCommand> _validator;
        public CreateOrganizationCommandHandler(IOrganizationService organizationService, IMapper mapper, IValidator<CreateOrganizationCommand> validator)
        {
            _organizationService = organizationService;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ServiceResponse> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return ServiceResponseHandler.HandleValidationError(validationResult.Errors);
            }

            Organization organization = _mapper.Map<Organization>(request);

            bool response = await _organizationService.CreateOrganizationAsync(organization);

            return ServiceResponseHandler.HandleSuccess(response);
        }
    }
}
