using Application.Abstractions.Messaging;
using Application.Common.DTOs.Response;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : ICommand<ServiceResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
