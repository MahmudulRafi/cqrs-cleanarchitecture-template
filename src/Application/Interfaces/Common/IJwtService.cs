using Application.Models.Users;
using System.Security.Claims;

namespace Application.Interfaces.Common
{
    public interface IJwtService
    {
        Task<string> GenerateTokenAsync(string userId);
        ClaimsPrincipal? ValidateToken(string token);
    }
}
