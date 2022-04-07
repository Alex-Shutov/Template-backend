 using System;
using System.Collections.Generic;
using System.Linq;
 using System.Threading;
 using System.Threading.Tasks;
 using Microsoft.AspNetCore.Http;
 using Template.WebAPI.Middleware.BaseMiddleware;

 namespace Template.WebAPI.Middleware
{
    internal class CustomExceptionHandlerMiddleware : BaseCustomMiddleware
    {

        public CustomExceptionHandlerMiddleware(RequestDelegate next) : base(next)
        {
        }

       
    }
    
}
