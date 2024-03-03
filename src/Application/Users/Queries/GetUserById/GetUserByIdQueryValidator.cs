using Application.Users.Queries.GetUserById;
using FluentValidation;

namespace Application.Users.Queries.GetUserById
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
