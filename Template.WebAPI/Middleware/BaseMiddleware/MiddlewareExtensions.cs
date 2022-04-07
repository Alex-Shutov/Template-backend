using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Template.Application.Common.Exceptions;

namespace Template.WebAPI.Middleware.BaseMiddleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder, Type typeOfMiddleware)
        {
            
           return typeOfMiddleware.BaseType == typeof(BaseCustomMiddleware) 
               ? builder.UseMiddleware(typeOfMiddleware) 
               : throw new NotInstanceOfBaseClass(typeOfMiddleware,typeof(BaseCustomMiddleware));
        } 
    }
}
