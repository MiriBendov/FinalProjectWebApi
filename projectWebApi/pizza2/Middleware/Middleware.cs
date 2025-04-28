using FileService.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace pizza2.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        string path = @"pizza2/actionLog.txt";
        IfileService<string> _fileService;
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next,IfileService<string> fileService)
        {
            _fileService=fileService;
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {

            var request = context.Request;

            _fileService.Write("request time: " + DateTime.Now.ToString(), path);
            _fileService.Write("Httpmethod: " + request.Method.ToString(), path);
            // _fileService.Write("the action: " + request.GetEndpoint().Metadata.ToString(), path);
            _fileService.Write("body parameters: " + request.Body.ToString(), path);
            _fileService.Write("recuest headers: " + request.Headers.ToString(), path);

            var Task= _next(context);
            // fileService.Write("response time: " + DateTime.Now.ToString(), path);
            return Task;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustom(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
