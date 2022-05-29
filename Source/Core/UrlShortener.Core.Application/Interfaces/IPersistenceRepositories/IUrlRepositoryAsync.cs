using UrlShortener.Core.Domain.Entities;

namespace UrlShortener.Core.Application.Interfaces.IPersistenceRepositories;

public interface IUrlRepositoryAsync : IGenericRepositoryAsync<Url>
{
    Task<string?> GetOriginalUrlByShortUrl(string shortUrl);
}
