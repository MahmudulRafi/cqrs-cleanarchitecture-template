using Application.Abstractions.Messaging;
using Application.DTOs.Responses;
<<<<<<< HEAD
using Domain.Abstractions.Users.Service;
=======
using Application.Features.Users.Services;
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
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

<<<<<<< HEAD
            ApplicationUser user = await _userService.GetByIdAsync(request.Id, cancellationToken);
=======
            User user = await _userService.GetByIdAsync(request.Id, cancellationToken);
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694

            return ServiceResponseHandler.HandleSuccess(user);
        }
    }
}
