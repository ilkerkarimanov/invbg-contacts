using FluentValidation;
using System.Net;

namespace InvBG.Contacts.Backend.Middleware;

public class HttpStatusCodeInfo
{
    public HttpStatusCode Code { get; }
    public string Message { get; }

    public HttpStatusCodeInfo(HttpStatusCode code, string message)
    {
        Code = code;
        Message = message;
    }
}

public static class ExceptionToHttpStatusMapper
{
    public static Func<Exception, HttpStatusCode>? CustomMap { get; set; }

    public static HttpStatusCodeInfo Map(Exception exception)
    {
        var code = exception switch
        {
            NotImplementedException _ => HttpStatusCode.NotImplemented,
            InvalidOperationException _ => HttpStatusCode.Conflict,
            ArgumentException _ => HttpStatusCode.BadRequest,
            ValidationException _ => HttpStatusCode.BadRequest,
            _ => CustomMap?.Invoke(exception) ?? HttpStatusCode.InternalServerError
        };

        return new HttpStatusCodeInfo(code, exception.Message);
    }
}
