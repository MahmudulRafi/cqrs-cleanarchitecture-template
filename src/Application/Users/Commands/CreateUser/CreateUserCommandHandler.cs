using Application.Abstractions.Messaging;
using Application.Common.DTOs.Response;
using Application.Users.Services;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Users.Commands.CreateUser
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
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                {
                    return ServiceResponseHandler.HandleValidationError(validationResult.Errors);
                }

                User user = new() { Name = request.Name, Email = request.Email, Phone = request.Phone };

                bool reponse = await _userService.CreateUserAsync(user, cancellationToken);

                if (reponse)
                    return ServiceResponseHandler.HandleSuccess();
                else
                    return ServiceResponseHandler.HandleError(new List<string> { "Can't create user" });
            }
            catch (Exception ex)
            {
                return ServiceResponseHandler.HandleError(new List<string> { ex.Message });
            }
        }
    }
}
