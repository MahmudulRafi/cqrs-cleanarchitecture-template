﻿using FluentValidation;

namespace Application.Organizations.Queries.GetOrganizationById
{
    public class GetOrganizationByIdQueryValidator : AbstractValidator<GetOrganizationByIdQuery>
    {
        public GetOrganizationByIdQueryValidator()
        {
            RuleFor(a => a.Id)
                .NotEmpty()
                .WithMessage("OrganizationId is required")
                .NotNull()
                .WithMessage("OrganizationId is required");
        }
    }
}
