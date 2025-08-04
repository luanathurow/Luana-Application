using luana_web_api.src.Infrastructure.SpotifyService;
using luana_web_api.src.Api.Swagger.DependencyInjection;

namespace MeuProjeto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<SpotifySettings>(builder.Configuration.GetSection("Spotify"));
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<SpotifyAuthService>();
            builder.Services.AddScoped<SpotifyService>();
            builder.Services.AddControllers();
            builder.Services.AddCustomSwagger();

            var app = builder.Build();
            app.MapControllers();

            app.Run();
        }
    }
}
