<<<<<<< HEAD
﻿using Application.Features.Organizations.Commands.CreateOrganization;
using Application.Features.Organizations.Queries.GetAllOrganization;
using Application.Features.Organizations.Queries.GetOrganizationById;
using Application.Models.Common;
using Asp.Versioning;
using Domain.Entities;
using Domain.Models.Responses;
=======
﻿using Application.Abstractions.Messaging;
using Application.DTOs.Responses;
using Application.Features.Organizations.Commands;
using Application.Features.Organizations.Queries;
using Asp.Versioning;
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [ApiVersion(1)]
<<<<<<< HEAD
    [Route("api/v{version:apiVersion}/organizations")]
=======
    [Route("api/v{version:apiVersion}/Organizations")]
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
    public sealed class OrganizationsController : ControllerBase
    {
        private readonly ISender _sender;
        public OrganizationsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
<<<<<<< HEAD
        public async Task<Result<PaginatedResponse<List<Organization>>>> GetOrganizations([FromQuery] GetAllOrganizationQuery query, CancellationToken cancellationToken)
=======
        public async Task<ServiceResponse> GetOrganizations([FromQuery] GetAllOrganizationQuery query, CancellationToken cancellationToken)
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
        {
            return await _sender.Send(query, cancellationToken);
        }

        [HttpGet("{organizationId}")]
<<<<<<< HEAD
        public async Task<Result<Organization>> GetOrganizationById(string organizationId, CancellationToken cancellationToken)
=======
        public async Task<ServiceResponse> GetOrganizationById(string organizationId, CancellationToken cancellationToken)
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
        {
            GetOrganizationByIdQuery query = new() { Id = organizationId };

            return await _sender.Send(query, cancellationToken);
        }

        [HttpPost]
<<<<<<< HEAD
        public async Task<Result<Organization>> CreateOrganization([FromBody] CreateOrganizationCommand command, CancellationToken cancellationToken)
        {
            return await _sender.Send(command, cancellationToken);
        }
=======
        public async Task<ServiceResponse> CreateOrganization([FromBody] CreateOrganizationCommand command, CancellationToken cancellationToken)
        {
            return await _sender.Send(command, cancellationToken);
        }

>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
    }
}
