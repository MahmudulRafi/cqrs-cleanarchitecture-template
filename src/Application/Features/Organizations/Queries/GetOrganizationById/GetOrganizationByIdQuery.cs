<<<<<<< HEAD
﻿using Application.Models.Common;
using Application.Shared.Interfaces.Messaging;
using Domain.Entities;

namespace Application.Features.Organizations.Queries.GetOrganizationById;

public class GetOrganizationByIdQuery : IQuery<Result<Organization>>
{
    public string Id { get; set; } = string.Empty;
=======
﻿using Application.Abstractions.Messaging;
using Application.DTOs.Responses;

namespace Application.Features.Organizations.Queries;

public class GetOrganizationByIdQuery : IQuery<ServiceResponse>
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string CreateBy { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
}
