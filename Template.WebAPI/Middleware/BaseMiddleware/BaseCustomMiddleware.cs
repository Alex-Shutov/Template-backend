using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Utf8Json;
using Microsoft.SqlServer;
using Template.Application.Common.Exceptions;
using Utf8Json.Resolvers;

namespace Template.WebAPI.Middleware
{
    internal abstract class BaseCustomMiddleware
    {

        private const string APPLICATION_JSON = "application/json";

        private readonly RequestDelegate _next;

        private Func<HttpContext, Task> _funcDelegateBeforeNext;
        protected BaseCustomMiddleware(RequestDelegate next) => _next = next;

        public void RegisterDelegate(Func<HttpContext, Task> @delegate)
        {
            _funcDelegateBeforeNext = @delegate;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                if (_funcDelegateBeforeNext != null)
                    await _funcDelegateBeforeNext(context);
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleMiddlewareActionAsync(context, e);
            }
        }

        private Task HandleMiddlewareActionAsync(HttpContext context, Exception exception)
        {
            JsonSerializer.SetDefaultResolver(StandardResolver.AllowPrivateExcludeNullSnakeCase);
            var code = HttpStatusCode.InternalServerError;
            string result;

            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.ToJsonString(validationException.Errors);
                    break;
                case NotFoundEntityException notFoundException:
                    code = HttpStatusCode.NotFound;
                    result = JsonSerializer.ToJsonString(notFoundException);
                    break;
                default:
                    result = JsonSerializer.ToJsonString(new {error = exception.Message});
                    break;
                
            }

            context.Response.ContentType = APPLICATION_JSON;
            context.Response.StatusCode = (int) code;

            return context.Response.WriteAsync(result);
        }
    }
}
