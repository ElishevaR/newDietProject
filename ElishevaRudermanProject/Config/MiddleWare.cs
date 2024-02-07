using Core.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;

namespace WebApi.Config
{
    public class MiddleWare
    {
        private readonly RequestDelegate next;
        private readonly ILogger<MiddleWare> _loger;

        public MiddleWare(RequestDelegate next, ILogger<MiddleWare> loger)
        { this.next = next;
            _loger = loger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                _loger.LogDebug($"client start using {context.Request.Method} now ");
                await next(context);
                _loger.LogInformation($"client got his response");
            }
            catch (MyException ex)
            
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, MyException ex)
        {
            var result = JsonConvert.SerializeObject(new { error = ex.nameTable });
            context.Response.StatusCode = ex.status;
            return context.Response.WriteAsync(result);
        }
    }
}
