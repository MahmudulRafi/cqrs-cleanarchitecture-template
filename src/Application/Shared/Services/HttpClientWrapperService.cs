using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Application.Shared.Interfaces;

namespace Application.Shared.Services
{
    public class HttpClientWrapperService : IHttpClientWrapperService
    {
        private readonly HttpClient _httpClient;

        public HttpClientWrapperService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TResponse?> GetAsync<TResponse>(string url, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                {
                    return await JsonSerializer.DeserializeAsync<TResponse>(
                        responseStream,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                    );
                }
            }
            else
            {
                throw new HttpRequestException($"Get request failed with status code {response.StatusCode}");
            }
        }

        public async Task<TResponse?> PostAsync<TResponse, TContent>(string url, string accessToken, TContent postObject)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(postObject),
                Encoding.UTF8,
                "application/json"
            );

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            HttpResponseMessage response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                {
                    return await JsonSerializer.DeserializeAsync<TResponse>(
                        responseStream,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                    );
                }
            }
            else
            {
                throw new HttpRequestException($"Post request failed with status code {response.StatusCode}");
            }
        }
    }
}
