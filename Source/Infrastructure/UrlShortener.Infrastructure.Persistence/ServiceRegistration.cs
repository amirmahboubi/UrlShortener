using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Infrastructure.Persistence.Contexts;
using UrlShortener.Infrastructure.Persistence.Repositories;
using UrlShortener.Core.Application.Interfaces.IPersistenceRepositories;

namespace UrlShortener.Infrastructure.Persistence;

public static class ServiceRegistration
{
    public static void AddInfrastructurePersistence(this IServiceCollection services, string connectionString)
    {
        #region DbContext
        services.AddDbContext<UrlShortenerContexts>(c => c.UseSqlServer(connectionString));
        #endregion

        #region Repositories
        services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(_GenericRepositoryAsync<>));
        services.AddTransient<IUrlRepositoryAsync, UrlRepositoryAsync>();
        #endregion
    }
}
