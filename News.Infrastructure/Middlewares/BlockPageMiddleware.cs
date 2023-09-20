using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Infrastructure.Middlewares
{
    public class BlockPageMiddleware
    {
        private readonly RequestDelegate _next;

        public BlockPageMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/Identity/Account/Register")
            {
                context.Response.Redirect("/");
                return;
            }

            await _next(context);
        }
    }
}
