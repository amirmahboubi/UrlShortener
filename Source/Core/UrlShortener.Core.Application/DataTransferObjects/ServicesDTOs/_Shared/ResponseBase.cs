namespace UrlShortener.Core.Application.DataTransferObjects.ServicesDTOs._Shared;

public class ResponseBase<TResponse>
{
    public ResponseHeader Header { get; set; }
    public TResponse? ContentData { get; set; }
}

public class ResponseBase
{
    public ResponseHeader Header { get; set; }
}
