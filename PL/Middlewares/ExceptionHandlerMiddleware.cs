using BLL.Exceptions.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Middlewares
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger _logger;
        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger)
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
                var message = CreateMessage(context, ex);
                _logger.LogError(message, ex);

                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            var result = new ErrorModel { Message = e.Message };
            int statusCode;

            switch (e)
            {
                case NotFoundException _:
                    statusCode = StatusCodes.Status404NotFound;
                    break;
                case BadRequestException _:
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                case ForbiddenException _:
                    statusCode = StatusCodes.Status403Forbidden;
                    break;
                default:
                    statusCode = StatusCodes.Status500InternalServerError;
                    result.Message = "Unknown error, please contact the system administrator";
                    break;
            }

            _logger.LogError(e, e.Message);
            var response = JsonConvert.SerializeObject(result, Formatting.Indented,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(response);
        }

        private string CreateMessage(HttpContext context, Exception e)
        {
            var message = $"Exception caught in error handler middleware, exception message: {e.Message}, stack: {e.StackTrace}";

            if (e.InnerException != null)
            {
                message = $"{message}, inner message {e.InnerException.Message}, inner stack {e.InnerException.StackTrace}";
            }

            return $"{message} RequestId: {context.TraceIdentifier}";
        }
    }
}
