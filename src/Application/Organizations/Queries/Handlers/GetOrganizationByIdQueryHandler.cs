using Application.Common.DTOs.Response;
using Application.Organizations.Queries.Validators;
using Application.Organizations.Services;
using Domain.Entities;
using FluentValidation.Results;
using MediatR;

namespace Application.Organizations.Queries.Handlers
{
    public class GetOrganizationByIdQueryHandler : IRequestHandler<GetOrganizationByIdQuery, ServiceResponse>
    {
        private readonly IOrganizationService _organizationService;
        private readonly GetOrganizationByIdQueryValidator _validator;
        public GetOrganizationByIdQueryHandler(IOrganizationService organizationService, GetOrganizationByIdQueryValidator validator)
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

                Organization organization = await _organizationService.GetOrganizationByIdAsync(request.Id);

                return ServiceResponseHandler.HandleSuccess(organization);
            }
            catch (Exception ex)
            {
                return ServiceResponseHandler.HandleError(new List<string> { ex.Message });
            }
        }
    }
}
