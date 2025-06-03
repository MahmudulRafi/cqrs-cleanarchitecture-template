<<<<<<< HEAD
﻿using Application.Interfaces.Organizations;
using Application.Models.Common;
using Application.Shared.Interfaces.Messaging;
=======
﻿using Application.Abstractions.Messaging;
using Application.DTOs.Responses;
using Application.Features.Organizations.Services;
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Features.Organizations.Queries.GetOrganizationById
{
<<<<<<< HEAD
    public class GetOrganizationByIdQueryHandler : IQueryHandler<GetOrganizationByIdQuery, Result<Organization>>
=======
    public class GetOrganizationByIdQueryHandler : IQueryHandler<GetOrganizationByIdQuery, ServiceResponse>
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
    {
        private readonly IOrganizationService _organizationService;
        private readonly IValidator<GetOrganizationByIdQuery> _validator;
        public GetOrganizationByIdQueryHandler(IOrganizationService organizationService, IValidator<GetOrganizationByIdQuery> validator)
        {
            _organizationService = organizationService;
            _validator = validator;
        }

<<<<<<< HEAD
        public async Task<Result<Organization>> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
=======
        public async Task<ServiceResponse> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
<<<<<<< HEAD
                return ResponseHandler.HandleValidationError<Organization>(validationResult.Errors);
            }

            Organization organization = await _organizationService.GetOrganizationByIdAsync(Guid.Parse(request.Id), cancellationToken);

            return ResponseHandler.HandleSuccess(organization);
=======
                return ServiceResponseHandler.HandleValidationError(validationResult.Errors);
            }

            Organization organization = await _organizationService.GetOrganizationByIdAsync(request.Id, cancellationToken);

            return ServiceResponseHandler.HandleSuccess(organization);
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
        }
    }
}
