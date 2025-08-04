namespace luana_web_api.src.Controller
{
    using luana_web_api.src.Infrastructure.SpotifyService;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using System.Net.Http.Headers;
    using System.Web;

    namespace SpotifyAuthDemo.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class SpotifyController : ControllerBase
        {
            private readonly SpotifySettings _settings;
            private readonly HttpClient _httpClient;

            public SpotifyController(IOptions<SpotifySettings> options, IHttpClientFactory factory)
            {
                _settings = options.Value;
                _httpClient = factory.CreateClient();
            }

            [HttpGet("login")]
            public IActionResult Login()
            {
                var scope = "user-read-private playlist-read-private";
                var query = HttpUtility.ParseQueryString(string.Empty);
                query["response_type"] = "code";
                query["client_id"] = _settings.ClientId!;
                query["scope"] = scope;
                query["redirect_uri"] = _settings.RedirectUri!;
                query["show_dialog"] = "true";

                var url = $"https://accounts.spotify.com/authorize/?{query}";
                return Redirect(url);
            }

            [HttpGet("callback")]
            public async Task<IActionResult> Callback([FromQuery] string code)
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token");

                request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    ["grant_type"] = "authorization_code",
                    ["code"] = code,
                    ["redirect_uri"] = _settings.RedirectUri!,
                    ["client_id"] = _settings.ClientId!,
                    ["client_secret"] = _settings.ClientSecret!
                });

                var response = await _httpClient.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();

                return Content(content, "application/json");
            }

            [HttpGet("me")]
            public async Task<IActionResult> GetUserProfile([FromQuery] string access_token)
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", access_token);

                var response = await _httpClient.GetAsync("https://api.spotify.com/v1/me");
                var content = await response.Content.ReadAsStringAsync();

                return Content(content, "application/json");
            }
        }
    }
}
