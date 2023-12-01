using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions.Cors;

public static class CorsExtensions
{
    private const string CorsPolicy = nameof(CorsPolicy);

    public static IServiceCollection AddCorsPolicy(this IServiceCollection services, IConfiguration config)
    {
        var corsSettings = config.GetSection(nameof(CorsSettings)).Get<CorsSettings>();
        var origins = new List<string>();
        if (corsSettings.Angular is not null)
            origins.AddRange(corsSettings.Angular.Split(';', StringSplitOptions.RemoveEmptyEntries));

        return services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicy,
                builder => builder
                    .AllowAnyOrigin() // Permitir cualquier origen
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
    }

    public static IApplicationBuilder UseCorsPolicy(this IApplicationBuilder app) =>
        app.UseCors(CorsPolicy);
}