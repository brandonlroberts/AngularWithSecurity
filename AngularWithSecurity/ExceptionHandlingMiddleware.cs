using AngularWithSecurity.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AngularWithSecurity
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public ExceptionHandlingMiddleware(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;

                _logger.LogError("You errored out yo");
            }
        }
    }
}
