<<<<<<< HEAD
﻿using Application.Interfaces.Organizations;
using FluentValidation;

namespace Application.Features.Organizations.Commands.CreateOrganization
=======
﻿using Application.Features.Organizations.Services;
using FluentValidation;

namespace Application.Features.Organizations.Commands
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
{
    public class CreateOrganizationCommandValidator : AbstractValidator<CreateOrganizationCommand>
    {
        private readonly IOrganizationService _organizationService;
        public CreateOrganizationCommandValidator(IOrganizationService organizationService)
        {
            _organizationService = organizationService;

<<<<<<< HEAD
            Validate();
        }

        private void Validate()
        {
            RuleFor(command => command)
                .NotEmpty()
                .WithMessage("Invalid command");

            RuleFor(command => command.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MustAsync(async (string name, CancellationToken cancellationToken) =>
                {
                    return !await _organizationService.OrganizationNameExistsAsync(name, cancellationToken);
                }).WithMessage("Organization with this name already exists");

            RuleFor(command => command.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Provide a valid email address");

            RuleFor(command => command.Phone)
                .NotEmpty()
                .WithMessage("Phone is required");
=======
            ValidateCommand();
        }

        private void ValidateCommand()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Organization name required.")
                .NotNull()
                .WithMessage("Organization name required.")
                .MustAsync(async (name, cancellationToken) => !await _organizationService.OrganizationNameExistsAsync(name, cancellationToken))
                .WithMessage("Organization already exists!");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Organization email required.")
                .EmailAddress()
                .WithMessage("Please, provide a valid email address");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .NotNull()
                .WithMessage("Organization phone required.");

>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
        }
    }
}
