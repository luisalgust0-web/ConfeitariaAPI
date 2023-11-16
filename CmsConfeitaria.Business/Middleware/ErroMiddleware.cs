using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace CmsConfeitaria.WebApi.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErroMiddleware
    {
        private readonly RequestDelegate _next;

        public ErroMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CmsException ex)
            {
                int severity = 2;
                await TratamentoErro(httpContext, ex, severity);
            }
            catch (Exception ex)
            {
                int severity = 3;
                await TratamentoErro(httpContext, ex, severity);
            }
        }


        public Task TratamentoErro(HttpContext context, Exception ex, int severity)
        {
            int _statusCode;
            int _severity;
            string _stackTrace;
            string _message;

            _statusCode = context.Response.StatusCode;
            _stackTrace = ex.StackTrace;
            _message = ex.Message;
            _severity = severity;

            var result = JsonSerializer.Serialize(new { _statusCode, _message, _stackTrace, _severity });

            return context.Response.WriteAsync(result);

        }
    }


    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErroMiddlewareExtensions
    {
        public static IApplicationBuilder UseErroMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErroMiddleware>();
        }
    }
}
public class CmsException : Exception
{
    public CmsException()
    {
    }

    public CmsException(string? message) : base(message)
    {
    }

    public CmsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected CmsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
