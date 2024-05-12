using FluentValidation;

namespace Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(a => a.Id)
                .NotEmpty()
                .WithMessage("UserId is required")
                .NotNull()
                .WithMessage("UserId is required");
        }
    }
}
