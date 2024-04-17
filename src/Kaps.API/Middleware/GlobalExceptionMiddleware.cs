using System.Diagnostics;
using System.Net;
using System.Text;
using Kaps.Domain.Exceptions;
using Newtonsoft.Json;

namespace Kaps.API.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate next;

    /// <summary>
    /// Ctor 
    /// </summary>
    /// <param name="next"></param>
    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    /// <summary>
    /// On Invoke Async
    /// </summary>
    /// <param name="httpContext"></param>
    /// <param name="logger"></param>
    public async Task InvokeAsync(HttpContext httpContext, ILogger<GlobalExceptionMiddleware> logger)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error on API");
            await HandleException(httpContext, ex);
        }
    }

    private async Task HandleException(HttpContext httpContext, Exception ex)
    {
        Activity.Current?.SetStatus(ActivityStatusCode.Error);
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var errorMessage = new ErrorMessage
        {
            Message = ex.Message,
            ErrorCode = "500",
            IsBusinessError = false,
            TraceId = Activity.Current?.TraceId.ToString()
        };

        switch (ex)
        {
            case BusinessException businessException:
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                errorMessage.Message = businessException.Message;
                errorMessage.ErrorCode = businessException.ErrorCode;
                errorMessage.IsBusinessError = true;
                break;
            }
            case ArgumentException _:
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                errorMessage.Message = ex.Message;
                errorMessage.IsBusinessError = false;
                break;
            }
            default:
            {
                errorMessage.Message = GetAllMessage(httpContext, ex);
                break;
            }
        }


        await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(errorMessage));
    }

    private string GetAllMessage(HttpContext context, Exception exception)
    {
        var env = context.RequestServices.GetRequiredService<IWebHostEnvironment>();
        if (exception is null) return "";
        if (env.IsProduction())
        {
            return "InternalServerError";
        }

        StringBuilder stringBuilder = new();
        stringBuilder.Append(exception.Message);
        var ex = exception.InnerException;
        while (ex != null)
        {
            stringBuilder.Append(ex.Message);
            ex = ex.InnerException;
        }

        return stringBuilder.ToString();
    }
}

public class ErrorMessage
{
    public string Message { get; set; }

    public string ErrorCode { get; set; }

    public bool IsBusinessError { get; set; }

    public string? TraceId { get; set; }
}