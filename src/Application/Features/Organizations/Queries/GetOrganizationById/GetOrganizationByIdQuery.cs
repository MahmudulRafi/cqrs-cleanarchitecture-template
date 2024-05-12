using Application.Abstractions.Messaging;
using Application.DTOs.Responses;

namespace Application.Features.Organizations.Queries;

public class GetOrganizationByIdQuery : IQuery<ServiceResponse>
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string CreateBy { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

}
