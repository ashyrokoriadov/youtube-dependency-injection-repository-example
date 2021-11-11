using Microsoft.AspNetCore.Builder;

namespace RepositoryDesignPattern.Middleware
{
    public static class Extensions
    {
        public static IApplicationBuilder UseRequestCorrelationId(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CorrelationIdMiddleware>();
        }
    }
}
