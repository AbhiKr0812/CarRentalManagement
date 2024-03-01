
using CarRentalManagement.Api.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace CarRentalManagement.Api.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error has occured, While Processing{context.Request.Path}");
                
                await HandleException(context, ex);
            }
        }

        private static Task HandleException(HttpContext context, Exception e)
        {

            HttpStatusCode statusCode;
            string message = "";
            var exceptionType = e.GetType();

            if (exceptionType == typeof(NotFoundException))
            {
                message = e.Message;
                statusCode = HttpStatusCode.NotFound;

            }
            else if (exceptionType == typeof(BadRequestException))
            {
                message = e.Message;
                statusCode = HttpStatusCode.BadRequest;
            }
            else
            {
                message = e.Message;
                statusCode = HttpStatusCode.InternalServerError;
            }

            var exceptionResult = JsonSerializer.Serialize(new { error = message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(exceptionResult.ToString());

        }

    }

    // Extension method for this middleware
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }

    //

    

    //context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
    //ProblemDetails problem = new()
    //{
    //    Status = (int)HttpStatusCode.InternalServerError,
    //    Type = "Server error",
    //    Title = "Server error",
    //    Detail = "An internal server has occured"
    //};

    //string json = JsonSerializer.Serialize(problem);
    //context.Response.ContentType = "application/json";
    //await context.Response.WriteAsync(json);
}
