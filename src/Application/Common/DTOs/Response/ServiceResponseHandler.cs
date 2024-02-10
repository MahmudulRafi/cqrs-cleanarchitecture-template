namespace Application.Common.DTOs.Response
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

        public static ServiceResponse HandleError(string errorMessage)
        {
            ServiceResponse response = new();
            response.SetError(errorMessage);
            return response;
        }

        public static ServiceResponse HandleValidationError(string errorMessage)
        {
            ServiceResponse response = new();
            response.SetValidationError(errorMessage);
            return response;
        }
    }
}
