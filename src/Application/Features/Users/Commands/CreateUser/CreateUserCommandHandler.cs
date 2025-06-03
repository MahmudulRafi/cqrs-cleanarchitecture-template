using Application.Abstractions.Messaging;
using Application.DTOs.Responses;
<<<<<<< HEAD
using Domain.Abstractions.Users.Service;
=======
using Application.Features.Users.Services;
using Domain.Entities;
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
using FluentValidation;
using FluentValidation.Results;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, ServiceResponse>
    {
        private readonly IUserService _userService;
        private readonly IValidator<CreateUserCommand> _validator;

        public CreateUserCommandHandler(IUserService userService, IValidator<CreateUserCommand> validator)
        {
            _userService = userService;
            _validator = validator;
        }

        public async Task<ServiceResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return ServiceResponseHandler.HandleValidationError(validationResult.Errors);
            }

<<<<<<< HEAD
            ApplicationUser user = new() { FirstName = request.Name, Email = request.Email, LastName = request.Phone };
=======
            User user = new() { FirstName = request.Name, Email = request.Email, LastName = request.Phone };
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694

            bool reponse = await _userService.CreateUserAsync(user, cancellationToken);

            if (reponse)
                return ServiceResponseHandler.HandleSuccess();
            else
                return ServiceResponseHandler.HandleError(new List<string> { "Can't create user" });
        }
    }
}
