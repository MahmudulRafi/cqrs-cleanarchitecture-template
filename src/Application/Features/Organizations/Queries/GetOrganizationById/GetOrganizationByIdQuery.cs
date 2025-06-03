using Application.Models.Common;
using Application.Shared.Interfaces.Messaging;
using Domain.Entities;

namespace Application.Features.Organizations.Queries.GetOrganizationById;

public class GetOrganizationByIdQuery : IQuery<Result<Organization>>
{
    public string Id { get; set; } = string.Empty;
}
