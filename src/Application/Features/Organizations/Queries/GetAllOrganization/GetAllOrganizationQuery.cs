<<<<<<< HEAD
﻿using Application.Models.Common;
using Application.Shared.Interfaces.Messaging;
using Domain.Entities;
using Domain.Models.Responses;

namespace Application.Features.Organizations.Queries.GetAllOrganization
{
    public class GetAllOrganizationQuery : IQuery<Result<PaginatedResponse<List<Organization>>>>
=======
﻿using Application.Abstractions.Messaging;
using Application.DTOs.Responses;

namespace Application.Features.Organizations.Queries
{
    public class GetAllOrganizationQuery : IQuery<ServiceResponse>
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }
}
