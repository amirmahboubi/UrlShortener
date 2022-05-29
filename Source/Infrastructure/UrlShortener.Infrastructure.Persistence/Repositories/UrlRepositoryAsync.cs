using Microsoft.EntityFrameworkCore;
using UrlShortener.Core.Domain.Entities;
using UrlShortener.Infrastructure.Persistence.Contexts;
using UrlShortener.Core.Application.Interfaces.IPersistenceRepositories;

namespace UrlShortener.Infrastructure.Persistence.Repositories;

internal class UrlRepositoryAsync : _GenericRepositoryAsync<Url>, IUrlRepositoryAsync
{
    private readonly DbSet<Url> _urls;

    public UrlRepositoryAsync(UrlShortenerContexts dbContext) : base(dbContext) => 
        _urls = dbContext.Set<Url>();

    public async Task<Url?> GetByShortUrl(string shortUrl) =>
        await _urls.FirstOrDefaultAsync(url => url.ShortUrl == shortUrl);
}
