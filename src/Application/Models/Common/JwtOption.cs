using Domain.Constants;
using System.Diagnostics.CodeAnalysis;

namespace Application.Models.Common
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
    public class JwtOption
    {
        public string ValidAudience { get; init; } = string.Empty;
        public string ValidIssuer { get; init; } = string.Empty;
        public string Secret { get; init; } = string.Empty;
        public int ExpiryHours { get; init; } = 3;
    }
}
