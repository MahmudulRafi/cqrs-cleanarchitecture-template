using Domain.Constants;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Application.DTOs.Responses
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
    public class ServiceResponse
    {
        public ServiceResponse()
        {
            ErrorMessages = new List<string>();
        }

        public dynamic? Response { get; set; }
        public bool? IsSuccessful { get; set; }
        public List<string> ErrorMessages { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public void SetSuccess()
        {
            IsSuccessful = true;
        }

        public void SetSuccess(dynamic data)
        {
            Response = data;
            IsSuccessful = true;
            StatusCode = HttpStatusCode.OK;
        }

        public void SetError(List<string> errorMessages)
        {
            ErrorMessages = errorMessages;
            IsSuccessful = false;
            StatusCode = HttpStatusCode.InternalServerError;
        }

        public void SetValidationError(List<string> errorMessages)
        {
            ErrorMessages = errorMessages;
            IsSuccessful = false;
            StatusCode = HttpStatusCode.BadRequest;
        }
    }
}
