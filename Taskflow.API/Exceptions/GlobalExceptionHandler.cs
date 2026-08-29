using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Taskflow.API.Exceptions;

public sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
  private readonly ILogger<GlobalExceptionHandler> _logger = logger;

  public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
  {
    _logger.LogError("Exception occured");
    int status = exception switch
    {
      KeyNotFoundException => StatusCodes.Status404NotFound,
      UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
      InvalidOperationException => StatusCodes.Status409Conflict,
      _ => StatusCodes.Status500InternalServerError
    };

    ProblemDetails? response = new()
    {
      Status = status,
      Title = exception switch
      {
        KeyNotFoundException => "Resource not found",
        UnauthorizedAccessException => "Unauthorized access",
        InvalidOperationException => "Invalid Operation",
        _ => "Internal Server error"
      },
      Detail = exception.Message
    };

    httpContext.Response.StatusCode = status;
    await httpContext.Response.WriteAsJsonAsync(
        response,
        cancellationToken
    );

    return true;
  }
}
