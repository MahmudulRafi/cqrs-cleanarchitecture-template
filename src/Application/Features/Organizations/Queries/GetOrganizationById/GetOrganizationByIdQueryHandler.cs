using Application.Interfaces.Organizations;
using Application.Models.Common;
using Application.Shared.Interfaces.Messaging;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Features.Organizations.Queries.GetOrganizationById
{
    public class GetOrganizationByIdQueryHandler : IQueryHandler<GetOrganizationByIdQuery, Result<Organization>>
    {
        private readonly IOrganizationService _organizationService;
        private readonly IValidator<GetOrganizationByIdQuery> _validator;
        public GetOrganizationByIdQueryHandler(IOrganizationService organizationService, IValidator<GetOrganizationByIdQuery> validator)
        {
            _organizationService = organizationService;
            _validator = validator;
        }

        public async Task<Result<Organization>> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return ResponseHandler.HandleValidationError<Organization>(validationResult.Errors);
            }

            Organization organization = await _organizationService.GetOrganizationByIdAsync(Guid.Parse(request.Id), cancellationToken);

            return ResponseHandler.HandleSuccess(organization);
        }
    }
}
