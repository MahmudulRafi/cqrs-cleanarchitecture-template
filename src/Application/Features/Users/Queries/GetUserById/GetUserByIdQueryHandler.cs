using Application.Abstractions.Messaging;
using Application.Common.DTOs.Response;
using Application.Features.Users.Services;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, ServiceResponse>
    {
        private readonly IUserService _userService;
        private readonly IValidator<GetUserByIdQuery> _validator;
        public GetUserByIdQueryHandler(IUserService userService, IValidator<GetUserByIdQuery> validator)
        {
            _userService = userService;
            _validator = validator;
        }

        public async Task<ServiceResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return ServiceResponseHandler.HandleValidationError(validationResult.Errors);
            }

            User user = await _userService.GetByIdAsync(request.Id, cancellationToken);

            return ServiceResponseHandler.HandleSuccess(user);
        }
    }
}
