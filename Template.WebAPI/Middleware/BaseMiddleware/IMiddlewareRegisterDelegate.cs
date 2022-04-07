using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Template.WebAPI.Middleware.BaseMiddleware
{
    public interface IMiddlewareRegisterDelegate
    {
        public Task HandleMiddlewareFunction(HttpContext context);
    }
}
