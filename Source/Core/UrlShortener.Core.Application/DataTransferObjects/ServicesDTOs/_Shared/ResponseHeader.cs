using System.Net;

namespace UrlShortener.Core.Application.DataTransferObjects.ServicesDTOs._Shared
{
    public class ResponseHeader
    {
        public bool Succeeded { get; set; }
        public string? Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public List<string>? Errors { get; set; }
    }
}