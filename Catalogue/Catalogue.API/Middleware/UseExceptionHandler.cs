using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogue.API.Middleware
{
    public static class UseExceptionHandler
    {
        public static IApplicationBuilder UseCustomExceptionHanlder(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandle>();
        }
    }
}
