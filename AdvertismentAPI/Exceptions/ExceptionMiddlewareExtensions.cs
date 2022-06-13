using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace AdvertismentAPI.Exceptions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    await context.Response.WriteAsync(new Error
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "Internal Server Error, Please Try Again Later.",
                        ErrorDetails = contextFeature.Error.ToString(),
                        Endpoint = contextFeature.Endpoint.ToString(),
                    }.ToString());
                }
            });
        });
    }
}
