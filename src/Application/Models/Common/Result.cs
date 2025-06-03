using Domain.Constants;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Application.Models.Common
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
    public sealed class Result<T>
    {
        public T? Data { get; private set; }
        public bool? Successful { get; private set; }
        public string? ErrorMessage { get; private set; }
        public IEnumerable<ValidationErrorResponse>? ValidationErrors { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }

        public void SetSuccess()
        {
            Successful = true;
            StatusCode = HttpStatusCode.OK;
        }

        public void SetSuccess(T data)
        {
            Data = data;
            Successful = true;
            StatusCode = HttpStatusCode.OK;
        }

        public void SetFailure(string errorMessage)
        {
            ErrorMessage = errorMessage;
            Successful = false;
            StatusCode = HttpStatusCode.NoContent;
        }

        public void SetValidationError(IEnumerable<ValidationErrorResponse> validationErrors)
        {
            ValidationErrors = validationErrors;
            Successful = false;
            StatusCode = HttpStatusCode.BadRequest;
        }
    }
}
