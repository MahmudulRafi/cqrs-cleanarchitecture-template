﻿using Application.Abstractions.Messaging;
using Application.DTOs.Responses;

namespace Application.Features.Organizations.Queries;

public class GetOrganizationByIdQuery : IQuery<ServiceResponse>
{
    public string Id { get; set; } = string.Empty;
}