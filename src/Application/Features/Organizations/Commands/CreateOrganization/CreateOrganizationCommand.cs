<<<<<<< HEAD
﻿using Application.Models.Common;
using Application.Shared.Interfaces.Messaging;
using Domain.Entities;

namespace Application.Features.Organizations.Commands.CreateOrganization
{
    public class CreateOrganizationCommand : ICommand<Result<Organization>>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string ReportingUserId { get; set; } = string.Empty;
=======
﻿using Application.Abstractions.Messaging;
using Application.DTOs.Responses;

namespace Application.Features.Organizations.Commands
{
    public class CreateOrganizationCommand : ICommand<ServiceResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string ReportingUserId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
    }
}
