using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Procuratio.Shared.Abstractions.Exceptions;

namespace Procuratio.Shared.Infrastructure.Exceptions
{
    internal class ErrorHandlerMiddleware : IMiddleware
    {
        private readonly ConcurrentDictionary<Type, string> _codes = new ConcurrentDictionary<Type, string>();
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
                int statusCode = 500;
                string code = "error";
                string errorMessage = "Hubo un error.";

                _logger.LogError(exception, exception.Message);

                if (exception is CustomExceptionBase customExceptionBase)
                {
                    statusCode = 400;
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

                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new { code, errorMessage }));
            }
        }
    }
}
