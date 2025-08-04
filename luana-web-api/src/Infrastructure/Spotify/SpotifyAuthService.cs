using luana_web_api.src.Infrastructure.SpotifyService;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

public class SpotifyAuthService
{
    private readonly HttpClient _httpClient;
    private readonly SpotifySettings _settings;

    public SpotifyAuthService(HttpClient httpClient, IOptions<SpotifySettings> options)
    {
        _httpClient = httpClient;
        _settings = options.Value;
    }

    public async Task<string> GetAccessTokenAsync()
    {
        var auth = $"{_settings.ClientId}:{_settings.ClientSecret}";
        var authBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(auth));

        var request = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token");
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", authBase64);
        request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["grant_type"] = "client_credentials"
        });

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var json = JsonDocument.Parse(content);

        return json.RootElement.GetProperty("access_token").GetString();
    }
}
