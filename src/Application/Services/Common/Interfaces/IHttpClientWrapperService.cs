namespace Application.Services.Common.Interfaces
{
    public interface IHttpClientWrapperService
    {
        Task<TResponse> GetAsync<TResponse>(string url, string accessToken);
        Task<TResponse> PostAsync<TResponse, TContent>(string url, string accessToken, TContent postObject);
    }
}
