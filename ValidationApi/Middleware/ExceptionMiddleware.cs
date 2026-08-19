using System.Net;
using System.Text.Json;
using ValidationApi.Models;

namespace ValidationApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
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

        private static async Task HandleExceptionAsync(
            HttpContext context,
            Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode =
                (int)HttpStatusCode.InternalServerError;

            var response = new ApiResponse<object>
            {
                Success = false,
                Message = exception.Message,
                Data = null
            };

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var jsonResponse =
                JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(jsonResponse);
        }
    }
}