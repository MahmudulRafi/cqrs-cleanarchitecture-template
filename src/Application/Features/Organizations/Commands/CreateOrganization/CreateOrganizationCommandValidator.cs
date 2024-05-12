using Application.Features.Organizations.Services;
using FluentValidation;

namespace Application.Features.Organizations.Commands
{
    public class CreateOrganizationCommandValidator : AbstractValidator<CreateOrganizationCommand>
    {
        private readonly IOrganizationService _organizationService;
        public CreateOrganizationCommandValidator(IOrganizationService organizationService)
        {
            _organizationService = organizationService;

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

        }
    }
}
