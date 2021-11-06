using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Procuratio.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Concurrent;
using System.Net;
using System.Threading.Tasks;

namespace Procuratio.Shared.Infrastructure.Exceptions
{
    internal class ErrorHandlerMiddleware : IMiddleware
    {
        private readonly ConcurrentDictionary<Type, string> _codes = new();
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                int statusCode = (int)HttpStatusCode.InternalServerError;
                string code = "internal_server_error";
                string errorMessage = exception.Message;

                if (exception is CustomExceptionBase customExceptionBase)
                {
                    statusCode = (int)HttpStatusCode.BadRequest;
                    Type exceptionType = customExceptionBase.GetType();

                    if (!_codes.TryGetValue(exceptionType, out string errorCode))
                    {
                        code = customExceptionBase.GetType().Name.Underscore().Replace("_exception", string.Empty);
                        _codes.TryAdd(exceptionType, code);
                    }
                    else
                    {
                        code = errorCode;
                    }

                    errorMessage = customExceptionBase.Message;
                }

                if (exception.Message == exception.Message && exception.InnerException is not null)
                {
                    errorMessage = exception.InnerException.Message;
                }

                _logger.LogError(exception, errorMessage);

                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsJsonAsync(new { code, errorMessage });
            }
        }
    }
}
