using UrlShortener.Core.Application;
using UrlShortener.Infrastructure.Persistence;

namespace UrlShortener.Presentation.API.Extensions;

public static class ApplicationServiceExtensions
{
    public static void AddServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddInfrastructurePersistence(
            connectionString: configuration.GetConnectionString(name: "UrlShortenerDbConnection"));
        services.AddApplicationServices();
    }

    public static void AddCorsExtension(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            // this defines a CORS policy called "default"
            options.AddPolicy("default", policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
    }
}

