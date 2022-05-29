using System.Net;
using UrlShortener.Core.Application.DataTransferObjects.ServicesDTOs._Shared;

namespace UrlShortener.Core.Application.Helpers;

internal static class ResponseBaseHelperMethods
{
	public static ResponseBase<T> SuccessResponse<T>(T contentData) =>
		new ResponseBase<T>()
		{
			ContentData = contentData,
			Header = ResponseHeaderHelperMethods.SuccessResponse()
		};

	public static ResponseBase<T> NoContentResponse<T>(string message = "سرویس با موفقیت پردازش شد اما متناسب با درخواست، هیچ پاسخی دریافت نکرد") =>
		new ResponseBase<T>()
		{
			ContentData = default(T),
			Header = ResponseHeaderHelperMethods.NoContentResponse(message)
		};

	public static ResponseBase<T> UnsuccessResponse<T>(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) =>
		new ResponseBase<T>()
		{
			ContentData = default(T),
			Header = ResponseHeaderHelperMethods.UnsuccessResponse(message, statusCode)
		};

	public static ResponseBase<T> ExceptionResponse<T>(Exception exception) =>
		new ResponseBase<T>()
		{
			ContentData = default(T),
			Header = ResponseHeaderHelperMethods.ExceptionResponse(exception)
		};

	public static ResponseBase<T> BadGatewayResponse<T>(string message = "در پردازش درخواست، سرویس پاسخ مناسبی دریافت نکرد. باری دیگر تلاش کنید") =>
		UnsuccessResponse<T>(message, HttpStatusCode.BadGateway);

	public static ResponseBase<T> BadRequestResponse<T>(string message = "مشخصات ورودی درخواست، نامعتبر است") =>
		UnsuccessResponse<T>(message, HttpStatusCode.BadRequest);

	public static ResponseBase<T> NotFoundResponse<T>(string message = "اطلاعات مورد نظر پیدا نشد") =>
		UnsuccessResponse<T>(message, HttpStatusCode.NotFound);
}
