using System.Net.Http;

namespace PollyRetry.API.Services
{
    public class PollyRetryService : IPollyRetryService
    {
        private readonly HttpClient _httpClient;

        public PollyRetryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> TestGetAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5198/api/fake");
            return response.IsSuccessStatusCode;
        }
    }
}
