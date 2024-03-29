﻿using Application.Abstractions.Messaging;
using Application.Common.DTOs.Response;

namespace Application.Organizations.Queries.GetOrganizationById
{
    public class GetOrganizationByIdQuery : IQuery<ServiceResponse>
    {
        public string Id { get; set; } = string.Empty;
    }
}
