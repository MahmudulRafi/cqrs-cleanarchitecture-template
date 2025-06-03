<<<<<<< HEAD
﻿using Application.Interfaces.Organizations;
using Application.Models.Common;
using Application.Shared.Interfaces.Messaging;
=======
﻿using Application.Abstractions.Messaging;
using Application.DTOs.Responses;
using Application.Features.Organizations.Services;
using AutoMapper;
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

<<<<<<< HEAD
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
=======
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
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
<<<<<<< HEAD
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
=======
                return ServiceResponseHandler.HandleValidationError(validationResult.Errors);
            }

            Organization organization = _mapper.Map<Organization>(request);

            bool response = await _organizationService.CreateOrganizationAsync(organization);

            return ServiceResponseHandler.HandleSuccess(response);
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
        }
    }
}
