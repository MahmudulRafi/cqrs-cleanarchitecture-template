using Application.Common.DTOs.Response;
using Application.Users.Queries.Validators;
using Application.Users.Services;
using Domain.Entities;
using FluentValidation.Results;
using MediatR;

namespace Application.Users.Queries.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ServiceResponse>
    {
        private readonly IUserService _userService;
        private readonly GetUserByIdQueryValidator _validator;
        public GetUserByIdQueryHandler(IUserService userService, GetUserByIdQueryValidator validator)
        {
            _userService = userService;
            _validator = validator;
        }

        public async Task<ServiceResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                {
                    return ServiceResponseHandler.HandleValidationError(validationResult.Errors);
                }

                User user = await _userService.GetByIdAsync(request.Id);

                return ServiceResponseHandler.HandleSuccess(user);
            }
            catch (Exception ex)
            {
                return ServiceResponseHandler.HandleError(new List<string>() { ex.Message });
            }
        }
    }
}
