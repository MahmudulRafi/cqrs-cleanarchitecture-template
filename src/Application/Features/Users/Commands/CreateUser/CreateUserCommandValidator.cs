using Domain.Abstractions.Users.Service;
using FluentValidation;

namespace Application.Features.Users.Commands.CreateUser
{
    internal class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IUserService _userService;

        public CreateUserCommandValidator(IUserService userService)
        {
            _userService = userService;

            Validate();
        }

        private void Validate()
        {
            RuleFor(a => a.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Name can't be empty")
                .NotNull()
                .WithMessage("Name can't be null")
                .MaximumLength(100)
                .WithMessage("Maximum length exceeded");

            RuleFor(a => a.Email)
                .NotEmpty()
                .WithMessage("Email can't be empty")
                .NotNull()
                .WithMessage("Email can't be null")
                .EmailAddress()
                .WithMessage("Provide a valid email address")
                .MustAsync(async (email, cancellationToken) =>
                {
                    return !await _userService.UserEmailExists(email, cancellationToken);
                })
                .WithMessage("Email already exists");

            RuleFor(a => a.Phone)
                .NotEmpty()
                .WithMessage("Phone can't be empty")
                .NotNull()
                .WithMessage("Phone can't be null");
        }
    }
}
