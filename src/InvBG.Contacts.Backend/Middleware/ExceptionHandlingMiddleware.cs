using System.Net;
using System.Text.Json;

namespace InvBG.Contacts.Backend.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate next;

    public ExceptionHandlingMiddleware(
        RequestDelegate next
    )
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex).ConfigureAwait(false);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var codeInfo = ExceptionToHttpStatusMapper.Map(exception);
        var result = JsonSerializer.Serialize(new HttpExceptionWrapper((int)codeInfo.Code, codeInfo.Message));
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)codeInfo.Code;
        return context.Response.WriteAsync(result);
    }
}

public class HttpExceptionWrapper
{
    public int StatusCode { get; }

    public string Error { get; }

    public HttpExceptionWrapper(int statusCode, string error)
    {
        StatusCode = statusCode;
        Error = error;
    }
}

public static class ExceptionHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(
        this IApplicationBuilder app,
        Func<Exception, HttpStatusCode>? customMap = null
    )
    {
        ExceptionToHttpStatusMapper.CustomMap = customMap;
        return app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
