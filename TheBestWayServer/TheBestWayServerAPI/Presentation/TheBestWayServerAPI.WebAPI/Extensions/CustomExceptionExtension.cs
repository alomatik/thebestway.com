using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using TheBestWayServerAPI.Application.Exceptions;
using TheBestWayServerAPI.WebAPI.Middlewares;

namespace TheBestWayServerAPI.WebAPI.Extensions
{
    public static class CustomExceptionExtension
    {
        public static void UseCustomGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(app =>
            {
                app.Run(async httpContext =>
                {
                    httpContext.Response.ContentType = MediaTypeNames.Application.Json;
                    var exceptionFeature = httpContext.Features.Get<IExceptionHandlerFeature>();
                    string message = String.Empty;

                    switch (exceptionFeature.Error)
                    {
                        case NotFoundException:
                            httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                            message = exceptionFeature.Error.Message;
                            break;
                        case IdentityException:
                            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                            message = exceptionFeature.Error.Message;
                            break;
                        default:
                            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                            message = exceptionFeature.Error.Message;
                            break;
                    }

                    await httpContext.Response.WriteAsJsonAsync(new
                    {
                        StatusCode = httpContext.Response.StatusCode,
                        Message = message
                    });

                });
            });
        }
    }
}
