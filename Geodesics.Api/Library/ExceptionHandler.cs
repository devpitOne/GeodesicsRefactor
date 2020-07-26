using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Geodesics.Api.Library
{
	public static class ExceptionHandler
    {
        public static void UseApiExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        //Log technical exception
                        var logger = loggerFactory.CreateLogger("GlobalException");
                        logger.LogError($"Exception occurred: {contextFeature.Error}");

						//Friendly Business Exception
						await context.Response.WriteAsync($"{context.Response.StatusCode}: Something went wrong. Please try again later");
					}
                });
            });
        }
    }
}
