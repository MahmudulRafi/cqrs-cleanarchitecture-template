namespace Application.Models.Common
{
    public record ValidationErrorResponse(string PropertyName, string ErrorMessage);
}
