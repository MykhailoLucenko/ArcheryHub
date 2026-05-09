namespace ArcheryHub.Api.Middlewares;
using ArcheryHub.Application.Exceptions;
using System.Net;
using System.Text.Json;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    
    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = HttpStatusCode.InternalServerError;
        var message = "An unexpected server error occurred.";

        if (exception is DomainValidationException domainEx)
        {
            statusCode = HttpStatusCode.BadRequest;
            message = domainEx.Message;
        }
        else if (exception is NotFoundException notFoundEx)
        {
            statusCode = HttpStatusCode.NotFound;
            message = notFoundEx.Message;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var result = JsonSerializer.Serialize(new { error = message });

        return context.Response.WriteAsync(result);
    }
}