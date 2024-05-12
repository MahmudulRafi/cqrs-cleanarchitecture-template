using Application.Abstractions.Messaging;
using Application.DTOs.Responses;
using Application.Features.Organizations.Services;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Features.Organizations.Queries.GetOrganizationById
{
    public class GetOrganizationByIdQueryHandler : IQueryHandler<GetOrganizationByIdQuery, ServiceResponse>
    {
        private readonly IOrganizationService _organizationService;
        private readonly IValidator<GetOrganizationByIdQuery> _validator;
        public GetOrganizationByIdQueryHandler(IOrganizationService organizationService, IValidator<GetOrganizationByIdQuery> validator)
        {
            _organizationService = organizationService;
            _validator = validator;
        }

        public async Task<ServiceResponse> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return ServiceResponseHandler.HandleValidationError(validationResult.Errors);
            }

            Organization organization = await _organizationService.GetOrganizationByIdAsync(request.Id, cancellationToken);

            return ServiceResponseHandler.HandleSuccess(organization);
        }
    }
}
