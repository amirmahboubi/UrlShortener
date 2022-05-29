using UrlShortener.Core.Domain.Entities;
using UrlShortener.Core.Application.Helpers;
using UrlShortener.Core.Application.Interfaces.IServices;
using UrlShortener.Core.Application.Interfaces.IPersistenceRepositories;
using UrlShortener.Core.Application.DataTransferObjects.ServicesDTOs._Shared;

namespace UrlShortener.Core.Application.Services;

internal class UrlShortenerService : IUrlShortenerService
{
    private readonly IUrlRepositoryAsync _urlRepositoryAsync;

    public UrlShortenerService(IUrlRepositoryAsync urlRepositoryAsync) =>
        _urlRepositoryAsync = urlRepositoryAsync;

    public async Task<ResponseBase<string>> GenerateShortUrl(string originalUrl)
    {
        ResponseBase<string> response = new();
        try
        {
            if (string.IsNullOrWhiteSpace(originalUrl))
                response = ResponseBaseHelperMethods.BadRequestResponse<string>(message: "Url is null or empty");
            else
            {
                Url url = await _urlRepositoryAsync.AddAsync(entity: new Url()
                {
                    OriginalUrl = originalUrl,
                    VisitsCount = 0
                });
                url.ShortUrl = UrlShortenerHelperMethods.Encode(url.Id);
                await _urlRepositoryAsync.UpdateAsync(url);
                response = ResponseBaseHelperMethods.SuccessResponse(url.ShortUrl);
            }
        }
        catch (Exception ex)
        {
            response = ResponseBaseHelperMethods.ExceptionResponse<string>(ex);
        }
        return response;
    }

    public async Task<ResponseBase<string>> GetOriginalUrl(string shortUrl)
    {
        ResponseBase<string> response = new();
        try
        {
            Url? url = await _urlRepositoryAsync.GetByShortUrl(shortUrl);
            if (url is not null)
            {
                url.VisitsCount++;
                await _urlRepositoryAsync.UpdateAsync(url);
                response = ResponseBaseHelperMethods.SuccessResponse(contentData: url.OriginalUrl);
            }
            else response = ResponseBaseHelperMethods.NotFoundResponse<string>(message: "Not Found");
        }
        catch (Exception ex)
        {
            response = ResponseBaseHelperMethods.ExceptionResponse<string>(ex);
        }
        return response;
    }
}
