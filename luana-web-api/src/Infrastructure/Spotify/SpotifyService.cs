using System.Net.Http.Headers;

namespace luana_web_api.src.Infrastructure.SpotifyService
{
    public class SpotifyService
    {
        private readonly SpotifyAuthService _authService;
        private readonly HttpClient _httpClient;

        public SpotifyService(SpotifyAuthService authService, HttpClient httpClient)
        {
            _authService = authService;
            _httpClient = httpClient;
        }

        public async Task<string> SearchAsync(string query)
        {
            var token = await _authService.GetAccessTokenAsync();
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var url = $"https://api.spotify.com/v1/search?q={Uri.EscapeDataString(query)}&type=track";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }

}
