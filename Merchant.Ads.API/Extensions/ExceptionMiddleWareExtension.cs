using Merchant.Ads.API.Models;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using Merchant.Ads.API.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;


namespace Merchant.Ads.API.Extensions
{
    public static class ExceptionMiddleWareExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager logger)
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
                        logger.LogError($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                    {
                         StatusCode = context.Response.StatusCode,
                         Message = "Internal Server Error."
                        }.ToString());
                    }
                });
            });
        }
    }
}
