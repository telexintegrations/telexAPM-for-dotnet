using Microsoft.AspNetCore.Builder;

namespace TelexApm.Extensions
{
    public static class AspNetCoreExtensions
    {
        public static IApplicationBuilder UseTelex(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TelexMiddleWare>();
        }
    }
}