using Domain.Constants;
using System.Diagnostics.CodeAnalysis;

namespace Application.Common.Exceptions
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
