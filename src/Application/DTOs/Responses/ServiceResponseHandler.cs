using FluentValidation.Results;

namespace Application.DTOs.Responses
{
    public static class ServiceResponseHandler
    {
        public static ServiceResponse HandleSuccess()
        {
            ServiceResponse response = new();
            response.SetSuccess();
            return response;
        }

        public static ServiceResponse HandleSuccess(dynamic data)
        {
            ServiceResponse response = new();
            response.SetSuccess(data);
            return response;
        }

        public static ServiceResponse HandleError(List<string> errorMessages)
        {
            ServiceResponse response = new();
            response.SetError(errorMessages);
            return response;
        }

        public static ServiceResponse HandleValidationError(List<ValidationFailure> validationFailures)
        {
            List<string> errorMessages = new();

            if (validationFailures.Count > 0)
            {
                foreach (ValidationFailure failure in validationFailures)
                {
                    errorMessages.Add(failure.ErrorMessage);
                }
            }

            ServiceResponse response = new();
            response.SetValidationError(errorMessages);
            return response;
        }
    }
}
