namespace UrlShortener.Core.Domain.Entities;

public class Url
{
    public int Id { get; set; }
    public string OriginalUrl { get; set; }
    public string ShortUrl { get; set; }
    public int VisitsCount { get; set; }
}