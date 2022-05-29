using UrlShortener.Core.Application.Interfaces.DataTransferObjects.ServicesDTOs._Shared;

namespace UrlShortener.Core.Application.Interfaces.IServices;

public interface IUrlShortenerService
{
    Task<ResponseBase<string>> GenerateShortUrl(string originalUrl);
    Task<ResponseBase<string>> GetOriginalUrl(string shortUrl);
}
