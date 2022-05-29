using UrlShortener.Core.Domain.Entities;

namespace UrlShortener.Core.Application.Interfaces.IPersistenceRepositories;

internal interface IUrlRepositoryAsync : IGenericRepositoryAsync<Url>
{
    Task<string?> GetOriginalUrlByShortUrl(string shortUrl);
}
