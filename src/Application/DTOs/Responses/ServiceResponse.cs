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
            ErrorMessages = [];
        }

        public dynamic? Response { get; set; }
        public bool? Successful { get; set; }
        public List<string> ErrorMessages { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public void SetSuccess()
        {
            Successful = true;
            StatusCode = HttpStatusCode.OK; 
        }

        public void SetSuccess(dynamic data)
        {
            Response = data;
            Successful = true;
            StatusCode = HttpStatusCode.OK;
        }

        public void SetFailure(string errorMessage)
        {
            ErrorMessages.Add(errorMessage);
            Successful = false;   
            StatusCode = HttpStatusCode.NoContent;
        }

        public void SetError(List<string> errorMessages)
        {
            ErrorMessages = errorMessages;
            Successful = false;
            StatusCode = HttpStatusCode.InternalServerError;
        }

        public void SetValidationError(List<string> errorMessages)
        {
            ErrorMessages = errorMessages;
            Successful = false;
            StatusCode = HttpStatusCode.BadRequest;
        }
    }
}
