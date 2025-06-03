using FluentValidation.Results;

namespace Application.Models.Common
{
    public static class ResponseHandler
    {
        public static Result<T> HandleSuccess<T>()
        {
            Result<T> response = new();

            response.SetSuccess();
            
            return response;
        }

        public static Result<T> HandleSuccess<T>(T data)
        {
            Result<T> response = new();

            response.SetSuccess(data);
            
            return response;
        }

        public static Result<T> HandleError<T>(string errorMessage)
        {
            Result<T> response = new();

            response.SetFailure(errorMessage);
            
            return response;
        }

        public static Result<T> HandleValidationError<T>(List<ValidationFailure> validationFailures)
        {
            List<ValidationErrorResponse> errorMessages = [];

            if (validationFailures.Count > 0)
            {
                foreach (ValidationFailure failure in validationFailures)
                {
                    errorMessages.Add(new ValidationErrorResponse(failure.PropertyName, failure.ErrorMessage));
                }
            }

            Result<T> response = new();

            response.SetValidationError(errorMessages);

            return response;
        }
    }
}
