using System.Net;

namespace Intern.Web.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseEndpointValidationMiddleware(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                try
                {
                    await next();
                }
                catch (ArgumentException ex)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await context.Response.WriteAsJsonAsync(new { ex.Message });
                }
            });

            return app;
        }
    }
}
