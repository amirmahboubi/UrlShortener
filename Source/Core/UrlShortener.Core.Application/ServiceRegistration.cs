using UrlShortener.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Core.Application.Interfaces.IServices;

namespace UrlShortener.Core.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        #region Services
        services.AddScoped<IUrlShortenerService, UrlShortenerService>();
        #endregion
    }
}