using System.Net;
using System.Text.Json;
using Tourism.Application.Exceptions;

namespace Tourism.API.Middlewares;

public sealed class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(
        RequestDelegate next,
        ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await LogExceptionAsync(context, ex);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(
        HttpContext context,
        Exception exception)
    {
        var (statusCode, message) = exception switch
        {
            BusinessException =>
                (HttpStatusCode.BadRequest, exception.Message),

            PersistenceException =>
                (HttpStatusCode.InternalServerError, exception.Message),

            NotFoundException =>
                (HttpStatusCode.NotFound, exception.Message),

            _ =>
                (HttpStatusCode.InternalServerError, "Ocorreu um problema no sistema. Contate os responsáveis.")
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var response = new
        {
            status = context.Response.StatusCode,
            error = message
        };

        return context.Response.WriteAsync(
            JsonSerializer.Serialize(response));
    }

    private Task LogExceptionAsync(HttpContext context, Exception exception)
    {
        var correlationId = context.Request.Headers.TryGetValue("X-Correlation-Id", out var value)
            ? value.ToString()
            : context.TraceIdentifier;

        _logger.LogError(
            exception,
            "Unhandled exception | CorrelationId={CorrelationId} | Method={Method} | Path={Path} | StatusCode={StatusCode}",
            correlationId,
            context.Request.Method,
            context.Request.Path,
            context.Response.StatusCode
        );

        return Task.CompletedTask;
    }
}
