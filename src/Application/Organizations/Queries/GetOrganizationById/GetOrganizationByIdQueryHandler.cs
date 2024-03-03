using Application.Abstractions.Messaging;
using Application.Common.DTOs.Response;
using Application.Organizations.Services;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Organizations.Queries.GetOrganizationById
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
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                {
                    return ServiceResponseHandler.HandleValidationError(validationResult.Errors);
                }

                Organization organization = await _organizationService.GetOrganizationByIdAsync(request.Id, cancellationToken);

                return ServiceResponseHandler.HandleSuccess(organization);
            }
            catch (Exception ex)
            {
                return ServiceResponseHandler.HandleError(new List<string> { ex.Message });
            }
        }
    }
}
