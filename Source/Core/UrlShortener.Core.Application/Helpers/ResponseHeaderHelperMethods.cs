using System.Net;
using UrlShortener.Core.Application.DataTransferObjects.ServicesDTOs._Shared;

namespace UrlShortener.Core.Application.Helpers;

internal class ResponseHeaderHelperMethods
{
    public static ResponseHeader SuccessResponse() =>
        new ResponseHeader()
        {
            StatusCode = HttpStatusCode.OK,
            Succeeded = true,
            Message = "OK"
        };

    public static ResponseHeader UnsuccessResponse(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) =>
        new ResponseHeader()
        {
            StatusCode = statusCode,
            Succeeded = false,
            Message = message
        };

    public static ResponseHeader NoContentResponse(string message = "سرویس با موفقیت پردازش شد اما متناسب با درخواست، هیچ پاسخی دریافت نکرد") =>
        new ResponseHeader()
        {
            Succeeded = true,
            Message = message,
            StatusCode = HttpStatusCode.NoContent
        };

    public static ResponseHeader ExceptionResponse(Exception exception)
    {
        string innerException = exception.InnerException != null ? $" - InnerException: {exception.InnerException.Message}" : "";
        return UnsuccessResponse(message: exception.Message + innerException);
    }

    public static ResponseHeader BadGatewayResponse(string message = "در پردازش درخواست، سرویس پاسخ مناسبی دریافت نکرد. باری دیگر تلاش کنید") =>
        UnsuccessResponse(message: message, statusCode: HttpStatusCode.BadGateway);

    public static ResponseHeader BadRequestResponse(string message = "مشخصات ورودی درخواست، نامعتبر است") =>
        UnsuccessResponse(message: message, statusCode: HttpStatusCode.BadRequest);
}
