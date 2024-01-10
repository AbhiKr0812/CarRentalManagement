using CarRentalManagement.Api.Contract;
using CarRentalManagement.Api.Exceptions;
using System.Net;
using System.Text.Json;

namespace CarRentalManagement.Api.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
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
            else if (exceptionType == typeof(NotImplementedException))
            {
                message = e.Message;
                statusCode = HttpStatusCode.NotImplemented;
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
}
