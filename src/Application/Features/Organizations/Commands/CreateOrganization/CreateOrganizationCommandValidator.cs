using Application.Interfaces.Organizations;
using FluentValidation;

namespace Application.Features.Organizations.Commands.CreateOrganization
{
    public class CreateOrganizationCommandValidator : AbstractValidator<CreateOrganizationCommand>
    {
        private readonly IOrganizationService _organizationService;
        public CreateOrganizationCommandValidator(IOrganizationService organizationService)
        {
            _organizationService = organizationService;

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
        }
    }
}
