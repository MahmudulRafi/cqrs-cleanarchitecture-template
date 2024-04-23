using Domain.Constants;
using System.Diagnostics.CodeAnalysis;

namespace Application.Common.Exceptions
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
